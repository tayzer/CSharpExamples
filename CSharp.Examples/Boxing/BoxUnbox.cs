using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Examples.Boxing
{
    public static class BoxUnbox
    {
        public static void Box()
        {
            var integerType = 123;

            object objectType = integerType;    // Boxing

            integerType = 456;

            Console.WriteLine($"The int type value is: {integerType}");
            Console.WriteLine($"The object type value is: {objectType}");

            //Output:
            //The int type value is: 456
            //The object type value is: 123
        }

        public static void Unbox()
        {
            var integerType = 123;
            object objectType = integerType;
            var newIntegerType = (int)objectType;   // Unboxing

            //Unboxing to a different reference type will result in an error, e.g. var newIntegerType = (string)objectType; 

            Console.WriteLine($"The int type value is: {integerType}");
            Console.WriteLine($"The object type value is: {objectType}");
            Console.WriteLine($"The new int type value is: {newIntegerType}");

            //Output
            //The int type value is: 123
            //The object type value is: 123
            //The new int type value is: 123
        }
    }
}
