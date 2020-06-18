using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder2
{
    class Program
    {
        public enum Color
        {
            Black,
            White,
            Red,
            Blue,
            Grey
        };

        public interface IHandlebar
        {
            string Description { get; set; }
            string Material { get; set; }
            double ClampDiamater { get; set; }
            double Width { get; set; }
            double Uplift { get; set; }
            Color Color { get; set; }
        }

        public interface IWheel
        {
            double Size { get; set; }
            double Weight { get; set; }
            string Model { get; set; }
            int Spokes { get; set; }
        }

        public interface IChain
        {
            int Rows { get; set; }
            int Cells { get; set; }
            double Weight { get; set; }
        }

        public interface IPedals
        {
            double Weight { get; set; }
            double Width { get; set; }
            double Height { get; set; }
            double Thickness { get; set; }
        }

        public class Handlebar : IHandlebar
        {
            public string Description { get; set; }
            public string Material { get; set; }
            public double ClampDiamater { get; set; }
            public double Width { get; set; }
            public double Uplift { get; set; }
            public Color Color { get; set; }
        }

        public class Wheel : IWheel
        {
            public double Size { get; set; }
            public double Weight { get; set; }
            public string Model { get; set; }
            public int Spokes { get; set; }
         
        }

        public class Chain : IChain
        {
            public int Rows { get; set; }
            public int Cells { get; set; }
            public double Weight { get; set; }
        }

        public class Pedals : IPedals
        {
            public double Weight { get; set; }
            public double Width { get; set; }
            public double Height { get; set; }
            public double Thickness { get; set; }
        }

        public class Bike
        {
            private IHandlebar handlebar;
            private IWheel wheel;
            private IPedals pedals;
            private IChain chain;

            public void SetHandlebar(IHandlebar handlebar)
            {
                this.handlebar = handlebar;
            }

            public IHandlebar GetHandlebar()
            {
                return handlebar;
            }

            public void SetWheel(IWheel wheel)
            {
                this.wheel = wheel;
            }

            public IWheel GetWheel()
            {
                return wheel;
            }

            public void SetPedals(IPedals pedals)
            {
                this.pedals = pedals;
            }

            public IPedals GetPedals()
            {
                return pedals;
            }

            public void SetChain(IChain chain)
            {
                this.chain = chain;
            }

            public IChain GetChain()
            {
                return chain;
            }
        }

        public interface IBuilder
        {
            void BuildHandlebar();
            void BuildWheel();
            void BuildChain();
            void BuildPedals();
            Bike GetBike();
        }

        public class BuilderStandard : IBuilder
        {
            private Bike bike;

            public BuilderStandard()
            {
                this.bike = new Bike();
            }

            public void BuildChain()
            {
                IChain chain = new Chain();
                chain.Rows = 20;
                chain.Weight = 0.78;
                chain.Cells = 43;
                bike.SetChain(chain);       
            }

            public void BuildHandlebar()
            {
                IHandlebar handlebar = new Handlebar();
                handlebar.Description = "Kierownica Stylo T30 700 30 rise 31.8 Blast Black";
                handlebar.ClampDiamater = 31.88;
                handlebar.Material = "AL-6066";
                handlebar.Uplift = 30.00;
                handlebar.Color = Color.Black;
                handlebar.Width = 700.00;
                bike.SetHandlebar(handlebar);
            }

            public void BuildPedals()
            {
                IPedals pedals = new Pedals();
                pedals.Height = 125.4;
                pedals.Width = 87.1;
                pedals.Thickness = 23.14;
                pedals.Weight = 453.19;
                bike.SetPedals(pedals);
            }

            public void BuildWheel()
            {
                IWheel wheel = new Wheel();
                wheel.Model = "Stars Circle";
                wheel.Size = 26;
                wheel.Spokes = 36;
                wheel.Weight = 1215;
                bike.SetWheel(wheel);
            }

            public Bike GetBike()
            {
                return bike;
            }
        }


        public class BuilderExtension : IBuilder
        {
            private Bike bike;

            public BuilderExtension()
            {
                this.bike = new Bike();
            }

            public void BuildChain()
            {
                IChain chain = new Chain();
                chain.Rows = 28;
                chain.Weight = 0.48;
                chain.Cells = 83;
                bike.SetChain(chain);
            }

            public void BuildHandlebar()
            {
                IHandlebar handlebar = new Handlebar();
                handlebar.Description = "Kierownica version extended";
                handlebar.ClampDiamater = 39.88;
                handlebar.Material = "AL-4066";
                handlebar.Uplift = 18.00;
                handlebar.Color = Color.Red;
                handlebar.Width = 541.00;
                bike.SetHandlebar(handlebar);
            }

            public void BuildPedals()
            {
                IPedals pedals = new Pedals();
                pedals.Height = 121.4;
                pedals.Width = 76.1;
                pedals.Thickness = 18.34;
                pedals.Weight = 253.19;
                bike.SetPedals(pedals);
            }

            public void BuildWheel()
            {
                IWheel wheel = new Wheel();
                wheel.Model = "Big Stars Circle";
                wheel.Size = 30;
                wheel.Spokes = 46;
                wheel.Weight = 959;
                bike.SetWheel(wheel);
            }

            public Bike GetBike()
            {
                return bike;
            }

            
        }

        public class Director
        {
            private IBuilder builder;

            public Director() { }
            public Director(IBuilder builder)
            {
                this.builder = builder;
            }

            public void SetBuilder(IBuilder builder)
            {
                this.builder = builder;
            }

            public void BuildBike()
            {
                builder.BuildChain();
                builder.BuildHandlebar();
                builder.BuildPedals();
                builder.BuildWheel();
            }

            public Bike GetBike()
            {
                return builder.GetBike();
            }

        }




        static void Main(string[] args)
        {
            Director John = new Director();
            IBuilder Alan = new BuilderStandard();
            IBuilder Paul = new BuilderExtension();

            John.SetBuilder(Alan);
            John.BuildBike();
            Bike bike = John.GetBike();

            Console.WriteLine(bike.GetWheel().Size);

            John.SetBuilder(Paul);
            John.BuildBike();
            Bike bike2 = John.GetBike();

            Console.WriteLine(bike2.GetWheel().Size);

            John.SetBuilder(Alan);
            John.BuildBike();
            Bike bike3 = John.GetBike();

            Console.WriteLine(bike3.GetWheel().Size);
        }
    }
}
