using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace remindAbstractFactory
{
    class Program
    {
        public interface IPartOfBuilding { }
        public interface IWorker { }

        public class Roof : IPartOfBuilding { }
        public class Wall : IPartOfBuilding { }
        public class YoungerWorker : IWorker { }
        public class OlderWorker : IWorker { }

        public abstract class AbstractFactory
        {
            public abstract IPartOfBuilding CreatePartOfBuilding();
            public abstract IWorker CreateWorker();
        }

        public class CreateRoof : AbstractFactory
        {
            public override IPartOfBuilding CreatePartOfBuilding()
            {
                IPartOfBuilding partOfBuilding = new Roof();
                return partOfBuilding;
            }

            public override IWorker CreateWorker()
            {
                IWorker worker = new OlderWorker();
                return worker;
            }
        }

        public class CreateWall : AbstractFactory
        {
            public override IPartOfBuilding CreatePartOfBuilding()
            {
                IPartOfBuilding partOfBuilding = new Wall();
                return partOfBuilding;
            }

            public override IWorker CreateWorker()
            {
                IWorker worker = new YoungerWorker();
                return worker;
            }
        }

        public class Client
        {
            private AbstractFactory abstractFactory;

            public Client(AbstractFactory abstractFactory)
            {
                this.abstractFactory = abstractFactory;
            }

            public void MakeConstruction()
            {
                var part = abstractFactory.CreatePartOfBuilding();
                var worker = abstractFactory.CreateWorker();
                Console.WriteLine("Element was built");
            }
        }

        static void Main(string[] args)
        {
            Client client;
            client = new Client(new CreateWall());
            client.MakeConstruction();

            client = new Client(new CreateRoof());
            client.MakeConstruction();
        }
    }
}
