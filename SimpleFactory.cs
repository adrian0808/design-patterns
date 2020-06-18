using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace remindSimpleFactory
{
    public enum FruitType
    {
        Lemon, Peer
    }

    public interface IFruit
    {    
        string Taste { get; set; }
        string Color { get; set; }
        double Price { get; set; }
    }

    public class Lemon : IFruit
    {
        public string Taste { get; set; }
        public string Color { get; set; }
        public double Price { get; set; }
    }

    public class Peer : IFruit
    {
        public string Taste { get; set; }
        public string Color { get; set; }
        public double Price { get; set; }
    }

    public class FruitFactory
    {
        public IFruit CreateFruit(FruitType fruitType)
        {
            if (fruitType == FruitType.Lemon)
            {
                return new Lemon() { Taste = "sour", Color = "yellow", Price = 1.34 };
            }
            else if (fruitType == FruitType.Peer)
            {
                return new Peer() { Taste = "sweet", Color = "green", Price = 2.08 };
            }
            else
            {
                throw new ArgumentException("The argument is incorrect!");
            }              
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            FruitFactory fruitFactory = new FruitFactory();
            IFruit lemon = fruitFactory.CreateFruit(FruitType.Lemon);
            Console.WriteLine(lemon.Taste);
        }
    }
}
