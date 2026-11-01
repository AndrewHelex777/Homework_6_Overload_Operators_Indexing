namespace Homework_6_Overload_Operators_Indexing
{
    class USD
    {
        public double Amount { get; set; }
        public string CurrencyName { get; set; } = "USD";
        public double ExchangeRateToEUR { get; set; } = 0.92;
        public double ExchangeRateToGBP { get; set; } = 0.79;
        public USD(double a)
        {
            Amount = a;
        }
        public static implicit operator USD(double a)
        {
            return new USD(a);
        }
        public static explicit operator EUR(USD u)
        {
            return new EUR(u.Amount * u.ExchangeRateToEUR);
        }
        public static explicit operator GBP(USD u)
        {
            return new GBP(u.Amount * u.ExchangeRateToGBP);
        }
        public override string ToString()
        {
            return $"{Amount:F2} {CurrencyName}";
        }
    }
    class EUR
    {
        public double Amount { get; set; }
        public string CurrencyName { get; set; } = "EUR";
        public double ExchangeRateToUSD { get; set; } = 1.0 / 0.92;
        public double ExchangeRateToGBP { get; set; } = 0.79 / 0.92;
        public EUR(double a)
        {
            Amount = a;
        }
        public static implicit operator EUR(double a)
        {
            return new EUR(a);
        }
        public static explicit operator USD(EUR e)
        {
            return new USD(e.Amount / e.ExchangeRateToUSD);
        }
        public static explicit operator GBP(EUR e)
        {
            return new GBP(e.Amount * e.ExchangeRateToGBP);
        }
        public override string ToString()
        {
            return $"{Amount:F2} {CurrencyName}";
        }
    }
    class GBP
    {
        public double Amount { get; set; }
        public string CurrencyName { get; set; } = "GBP";
        public double ExchangeRateToUSD { get; set; } = 1.0 / 0.79;
        public double ExchangeRateToEUR { get; set; } = 0.92 / 0.79;
        public GBP(double a)
        {
            Amount = a;
        }
        public static implicit operator GBP(double a)
        {
            return new GBP(a);
        }
        public static explicit operator USD(GBP g)
        {
            return new USD(g.Amount / g.ExchangeRateToUSD);
        }
        public static explicit operator EUR(GBP g)
        {
            return new EUR(g.Amount * g.ExchangeRateToEUR);
        }
        public override string ToString()
        {
            return $"{Amount:F2} {CurrencyName}";
        }
    }
    internal class Task3
    {
        static void Main(string[] args)
        {
            USD u1 = 100;
            EUR e1 = 100;
            GBP g1 = 100;
            Console.WriteLine("Start money:");
            Console.WriteLine($"{u1}\n{e1}\n{g1}");

            Console.WriteLine("Currency conversion:");
            Console.WriteLine("Explicit:");
            USD u2 = (USD)e1;
            USD u3 = (USD)g1;
            EUR e2 = (EUR)u1;
            EUR e3 = (EUR)g1;
            GBP g2 = (GBP)u1;
            GBP g3 = (GBP)e1;
            Console.WriteLine($"EUR to USD: {u2}");
            Console.WriteLine($"GBP to USD: {u3}");
            Console.WriteLine($"USD to EUR: {e2}");
            Console.WriteLine($"GBP to EUR: {e3}");
            Console.WriteLine($"USD to GBP: {g2}");
            Console.WriteLine($"EUR to GBP: {g3}");

            Console.WriteLine("Implicit:");
            USD u4 = 250;
            EUR e4 = 150;
            GBP g4 = 50;
            Console.WriteLine($"{u4}\n{e4}\n{g4}");
        }
    }
}
