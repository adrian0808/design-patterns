using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemindFactoryMethod
{
    class Program
    {
        public interface IFruit
        {
            string Taste { get; set; }
            string Color { get; set; }
            double Price { get; set; }
        }

        public class Banana : IFruit
        {
            public Banana() { }
            public Banana(string taste, string color, double price)
            {
                this.Taste = taste;
                this.Color = color;
                this.Price = price;
            }

            public string Taste { get; set; }
            public string Color { get; set; }
            public double Price { get; set; }
        }

        public class Lemon : IFruit
        {
            public Lemon() { }
            public Lemon(string taste, string color, double price)
            {
                this.Taste = taste;
                this.Color = color;
                this.Price = price;
            }

            public string Taste { get; set; }
            public string Color { get; set; }
            public double Price { get; set; }
        }

        public abstract class AbstractFactory
        {
            public abstract IFruit CreateInstance(string taste, string color, double price);
        }

        public class BananaFactory : AbstractFactory
        {
            public override IFruit CreateInstance(string taste, string color, double price)
            {
                return new Banana(taste, color, price);
            }
        }

        public class LemonFactory : AbstractFactory
        {
            public override IFruit CreateInstance(string taste, string color, double price)
            {
                return new Lemon(taste, color, price);
            }
        }


        static void Main(string[] args)
        {
            AbstractFactory abstractFactory = new LemonFactory();
            IFruit lemon = abstractFactory.CreateInstance("sour", "yellow", 1.23);
            Console.WriteLine(lemon.Price);

            IFruit banana = abstractFactory.CreateInstance("sweet", "yellow", 2.87);
            Console.WriteLine(banana.Price);
        }
    }
}
