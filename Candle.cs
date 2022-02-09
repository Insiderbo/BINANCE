using System.Globalization;

namespace RSI_test
{
    public class Candle
	{
		const int HighPrice = 2;
		const int LowPrice = 3;
		const int ClosePrice = 4;
		const int Timestamp = 0;
		const int Volume = 5;

		public double highPrice;
        public double lowPrice;
        public double сlosePrice;
        public long timestamp;
		public double volume;

		internal static Candle Create(dynamic candle)
		{
			var c = new Candle();
			c.highPrice = double.Parse(candle[HighPrice].ToString(), CultureInfo.InvariantCulture);
			c.lowPrice = double.Parse(candle[LowPrice].ToString(), CultureInfo.InvariantCulture);
			c.сlosePrice = double.Parse(candle[ClosePrice].ToString(), CultureInfo.InvariantCulture);
			c.timestamp = long.Parse(candle[Timestamp].ToString(), CultureInfo.InvariantCulture);
			c.volume = double.Parse(candle[Volume].ToString(), CultureInfo.InvariantCulture);
			return c;
		}
	}
}
