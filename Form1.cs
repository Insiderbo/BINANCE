using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

//https://www.binance.com/ru/trade/EUR_USDT?layout=basic&type=spot

namespace RSI_test
{
	public partial class Form1 : Form
	{
		string ccy;
		readonly Dictionary<string, HashSet<string>> pairs = new Dictionary<string, HashSet<string>>();
		readonly Dictionary<string, DataGridViewRow> rows = new Dictionary<string, DataGridViewRow>();
		readonly Dictionary<string, List<Candle>> candles = new Dictionary<string, List<Candle>>();
		private readonly Dictionary<string, RsiCalculator> rsi_calculators = new Dictionary<string, RsiCalculator>();
		readonly int period = 3;

		public Form1()
		{
			InitializeComponent();
		}

		private async void Form1_LoadAsync(object sender, EventArgs e)
		{

			pairs["EUR"] = new HashSet<string>();
			pairs["RUB"] = new HashSet<string>();
			pairs["USDT"] = new HashSet<string>();
			await Get_Pairs();
			pairs["test"] = new HashSet<string>();
			pairs["test"].Add("EURUSDT");
			foreach (var currency in pairs.Keys)
			{
				comboBox1.Items.Add(currency);
			}
			dataGridView1.AllowUserToAddRows = false;
			dataGridView1.AllowUserToDeleteRows = false;
			dataGridView1.AllowUserToResizeRows = false;
			dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			//dataGridView1.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
			//dataGridView1.RowHeadersDefaultCellStyle = new DataGridViewCellStyle()
			dataGridView1.RowHeadersVisible = false;
		}


		public async Task Get_Pairs()
		{
			dynamic d = JsonConvert.DeserializeObject(await LoadUrlAsText("https://api.binance.com/api/v3/exchangeInfo"));
			int count = d.rateLimits[0]["limit"];
			foreach (var master in pairs.Keys)
			{
				for (var i = 0; i < count; i++)
				{
					string symbol = (d.symbols[i]["symbol"]).ToString();

					if (symbol.Contains(master))
					{
						pairs[master].Add(symbol);
						if (!candles.ContainsKey(symbol))
						{
							candles.Add(symbol, new List<Candle>());
						}
					}
				}
			}
		}

		public async Task<string> LoadUrlAsText(string url)
		{
			var request = WebRequest.Create(url);
			using (var response = await request.GetResponseAsync())
			{
				using (var stream = response.GetResponseStream())
				{
					var sr = new StreamReader(stream);
					return await sr.ReadToEndAsync();
				}
			}
		}

		public async Task<List<Candle>> LoadCandles(string pair, string interval, int limit)
		{
			dynamic d = JsonConvert.DeserializeObject(await LoadUrlAsText($"https://api.binance.com/api/v1/klines?symbol={pair}&interval={interval}&limit={limit}"));
			var candles = new List<Candle>();
			foreach (var candle in d)
			{
				candles.Add(Candle.Create(candle));
			}
			return candles;
		}

		public async Task LoadAllCandles(string pair)
		{
			candles[pair] = await LoadCandles(pair, "1d", 400);
			rsi_calculators[pair] = new RsiCalculator(candles[pair], period);
			UpdateRow(pair);
		}

		public async Task LoadOneCandle(string pair)
		{
			var all = await LoadCandles(pair, "1d", 1);
			var new_last = all.Single();
			var old_last =  candles[pair].Last();
			//if (new_last.timestamp==old_last.timestamp)
			//{
			//	return;
			//}
			Status($"{pair}: {old_last.сlosePrice} -> {new_last.сlosePrice}");
			candles[pair].RemoveAt(candles[pair].Count - 1);
			var previous = candles[pair].Last();
			candles[pair].Add(new_last);
			rsi_calculators[pair].RecalculateLast(new_last, previous);
			UpdateRow(pair);
		}
		private void UpdateRow(string pair)
		{
			var candles_for_pair = candles[pair];
			//var rsi = rsi_calculators[pair].rsi_list;

			var row = rows[pair];
			row.Cells[1].Value = Math.Round(rsi_calculators[pair].GetLast().value, 2);
			row.Cells[2].Value = Math.Round(
				CalculateStoch_RSI(
					rsi_calculators[pair].rsi_list.Select(r => r.value).ToList())
				, 2);
			row.Cells[3].Value = 
				CalculateGlobalAverage(
					candles_for_pair.Select(x => x.highPrice).ToList(), 
					candles_for_pair.Select(x => x.lowPrice).ToList());
			row.Cells[4].Value = Math.Round(
				Calculate_K(
					candles_for_pair.Select(x => x.сlosePrice).ToList(), 
					candles_for_pair.Select(x => x.highPrice).ToList(), 
					candles_for_pair.Select(x => x.lowPrice).ToList())
				, 2);
			//row.Cells[5].Value = Math.Round(Calculate_D(), 2);

			row.Cells[6].Value =  Math.Round(CaculateTrendStrength(candles[pair].Last())*100,1);
			row.Cells[7].Value = candles[pair].Count;
			row.Cells[8].Value = candles[pair].Last().highPrice;
			row.Cells[9].Value = candles[pair].Last().lowPrice;
		}

		private double CaculateTrendStrength(Candle c)
		{
			return (c.highPrice / c.lowPrice) - 1;
		}


		//private double Calculate_D()
		//{

		//}

		private double Calculate_K(List<double> closePrices, List<double> highPrices, List<double> lowPrices)
		{
			var max = highPrices.Max();
			var min = lowPrices.Min();
			var clouse = closePrices.Last();
			var k = ((clouse - min) / (max - min)) * 100;
			return k;
		}

		private double CalculateStoch_RSI(List<double> rsi)
		{
			var max = rsi.Max();
			var min = rsi.Min();
			var current = rsi[rsi.Count - 1];
			var Stoch_Rsi = ((current - min) / (max - min)) * 100;
			return Stoch_Rsi;
		}

		private object CalculateGlobalAverage(List<double> highPrices, List<double> lowPrices)
		{
			var max = highPrices.Max();
			var min = lowPrices.Min();
			return (max + min) / 2;
		}



		private void PaintRows()
		{
			foreach (DataGridViewRow r in dataGridView1.Rows)
			{
				if (!string.IsNullOrEmpty(r.Cells[1].Value?.ToString()) && double.Parse(r.Cells[1].Value.ToString()) < 20)////разобраться
					r.DefaultCellStyle.BackColor = Color.LightCyan;
			}
		}
		int timer_tick_count = 0;
		bool timer_cancelled = true;
		private async void timer1_Tick(object sender, EventArgs e)
		{
			Status($"{Thread.CurrentThread.ManagedThreadId} load last candles for {pairs[ccy].Count} pairs");
			if (timer_tick_count!=0 || timer_cancelled)
			{
				return;
			}
			Interlocked.Increment(ref timer_tick_count);
			foreach (var p in pairs[ccy])
			{
				//Status(p);
				await LoadOneCandle(p);
			}
			Interlocked.Decrement(ref timer_tick_count);

			Status($" loaded");
			PaintRows();
		}

		private void Status(string str)
		{
			toolStripStatusLabel1.Text = str;
		}


		private async void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{

			timer_cancelled = true;
			if (timer1.Enabled)
			{
				timer1.Stop();
			}
			ccy = comboBox1.Text;
			dataGridView1.Rows.Clear();
			rows.Clear();
			int i = 1;
			foreach (var p in pairs[ccy].OrderBy(x => x))
			{
				Status($"load {p} ({i++} of {pairs[ccy].Count})");
				var row = dataGridView1.Rows.Add(p, "", "", "");
				rows.Add(p, dataGridView1.Rows[row]);
				await LoadAllCandles(p);
			}

			timer1.Interval = 3000;
			timer1.Start();
			timer_cancelled = false;
		}

	}
}
