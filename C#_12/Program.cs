namespace C__12
{
    using System;

    public class Exchange
    {
        private Random random = new Random();
        private decimal currentRate;

        public event Action<decimal> RateChanged;
        public event Action<decimal> MaxRateReached;
        public event Action<decimal> MinRateReached;

        public decimal CurrentRate
        {
            get => currentRate;
            private set
            {
                currentRate = value;
                OnRateChanged(currentRate);

                if (currentRate >= 100)
                {
                    OnMaxRateReached(currentRate);
                }
                else if (currentRate <= 10)
                {
                    OnMinRateReached(currentRate);
                }
            }
        }

        public void GenerateNewRate()
        {
            CurrentRate = random.Next(5, 106);
        }

        protected virtual void OnRateChanged(decimal rate)
        {
            RateChanged?.Invoke(rate);
        }

        protected virtual void OnMaxRateReached(decimal rate)
        {
            MaxRateReached?.Invoke(rate);
        }

        protected virtual void OnMinRateReached(decimal rate)
        {
            MinRateReached?.Invoke(rate);
        }
    }

    public class Trader
    {
        public string Name { get; set; }
        public decimal Currency { get; private set; }
        public decimal Money { get; private set; }

        public Trader(string name, decimal initialCurrency, decimal initialMoney)
        {
            Name = name;
            Currency = initialCurrency;
            Money = initialMoney;
        }

        public void OnRateChanged(decimal rate)
        {
            Console.WriteLine($"{Name} received rate change notification: {rate}");

            if (rate < 20 && Money >= rate)
            {
                Buy(rate);
            }
            else if (rate > 90 && Currency > 0)
            {
                Sell(rate);
            }
        }

        private void Buy(decimal rate)
        {
            Console.WriteLine($"{Name} is buying at rate {rate}");
            Money -= rate;
            Currency++;
        }

        private void Sell(decimal rate)
        {
            Console.WriteLine($"{Name} is selling at rate {rate}");
            Money += rate;
            Currency--;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Exchange exchange = new Exchange();
            Trader trader1 = new Trader("Trader1", 10, 1000);
            Trader trader2 = new Trader("Trader2", 5, 500);

            exchange.RateChanged += trader1.OnRateChanged;
            exchange.RateChanged += trader2.OnRateChanged;

            for (int i = 0; i < 10; i++)
            {
                exchange.GenerateNewRate();
                System.Threading.Thread.Sleep(1000);
            }
        }
    }
}
