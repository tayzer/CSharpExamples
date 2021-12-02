using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Examples.Generics
{
    public class WriterBot
    {
        public void Write<T>(T data)
        {
            Console.WriteLine(data);
        }
    }

    public static class GenericMethod
    {
        public static void Example()
        {
            var writer = new WriterBot();

            writer.Write(100);
            writer.Write("Hello");
            writer.Write(new Person(){Forename = "John", Surname = "Lennon"});

            //Output:
            //100
            //Hello
            //CSharp.Examples.Person
        }
    }
}
