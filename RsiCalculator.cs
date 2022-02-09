using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSI_test
{
	public class RsiCalculator
	{
		public readonly List<Rsi> rsi_list = new List<Rsi>();
		private double averageGain;
		private double averageLoss;
		private double prev_avg_gain;
		private double prev_avg_loss;
		private readonly int period;

		public RsiCalculator(List<Candle> candles, int period)
		{
			this.period = period;
			CalculateAll(candles);
		}

		private void CalculateAll(List<Candle> candles)
		{
			rsi_list.Clear();

			double gainSum = 0;
			double lossSum = 0;
			for (int i = 1; i < period; i++)
			{
				double thisChange = candles[i].сlosePrice - candles[i - 1].сlosePrice;
				if (thisChange > 0)
				{
					gainSum += thisChange;
				}
				else
				{
					lossSum += (-1) * thisChange;
				}
			}

			averageGain = gainSum / period;
			averageLoss = lossSum / period;

			for (int i = period + 1; i < candles.Count; i++)
			{				
				rsi_list.Add(CalcuateRsi(candles[i], candles[i - 1]));
			}
		}

		private Rsi CalcuateRsi(Candle last, Candle prev)
		{
			prev_avg_gain = averageGain;
			prev_avg_loss = averageLoss;
			double thisChange = last.сlosePrice - prev.сlosePrice;
			if (thisChange > 0)
			{
				averageGain = (averageGain * (period - 1) + thisChange) / period;
				averageLoss = (averageLoss * (period - 1)) / period;
			}
			else
			{
				averageGain = (averageGain * (period - 1)) / period;
				averageLoss = (averageLoss * (period - 1) + (-1) * thisChange) / period;
			}
			double rs = averageGain / averageLoss;
			var rsi = new Rsi();
			rsi.value = 100 - (100 / (1 + rs));
			return rsi;
		}

		public void RecalculateLast(Candle last, Candle previous)
		{
			averageGain = prev_avg_gain;
			averageLoss = prev_avg_loss;
			rsi_list.RemoveAt(rsi_list.Count - 1);
			rsi_list.Add(CalcuateRsi(last, previous));
		}

		public Rsi GetLast() => rsi_list.Last();
	}
}
