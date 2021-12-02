using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharp.Examples
{
    public static class AdvancedLinq
    {
        public static Dictionary<string, string> Scales => new Dictionary<string, string>
        {
            {"C major", "C D E F G A B C"},
            {"D major", "D E F# G A B C# D"},
            {"E major", "E F# G# A B C# D# E"}
        };

        public static void SelectMany()
        {
            var querySyntax = from scale in Scales
                              from note in scale.Value.Split(' ')
                where scale.Key == "C major"
                select note;

            var methodSyntax = Scales.Where(c => c.Key == "C major").SelectMany(d => d.Value.Split(' '));

            foreach (var q in querySyntax)
            {
                Console.WriteLine(q);
            }

            foreach (var m in methodSyntax)
            {
                Console.WriteLine(m);
            }

            /*
             * Output:
             * C
             * D
             * E
             * F
             * G
             * A
             * B
             * C
             */
        }

        public static void Aggregate()
        {
            var people = new List<Person>()
            {
                new Person() {Forename = "Nikola", Surname = "Tesla", Age = 50, Occupation = "Inventor"},
                new Person() {Forename = "Gerolamo", Surname = "Cardano", Age = 100, Occupation = "Mathematician"},
                new Person() {Forename = "Albert", Surname = "Einstein", Age = 21, Occupation = "Physicist"}
            };

            var methodSyntax = people.Aggregate("People: ",
                (s, person) => s += $"{person.Forename}, {person.Surname} the {person.Occupation} ");

            Console.WriteLine(methodSyntax);

            /*
             * Output:
             * People: Nikola, Tesla the Inventor, Gerolamo, Cardano the Mathematician, Albert, Einstein the Physicist
             */
        }

        public static void GroupJoin()
        {
            var computerComponents = new List<ComputerComponent>
            {
                new ComputerComponent() {CategoryId = 0, Name = "Nvidia GeForce RTX 3090"},
                new ComputerComponent() {CategoryId = 0, Name = "AMD Radeon RX 6900 XT"},
                new ComputerComponent() {CategoryId = 1, Name = "Asus TUF Gaming Z590-Plus WIFI"},
                new ComputerComponent() {CategoryId = 2, Name = "Intel Core i5 12600K"},
                new ComputerComponent() {CategoryId = 2, Name = "AMD Ryzen 7 5700G"}
            };

            var componentCategories = new List<ComponentCategory>()
            {
                new ComponentCategory(){Id = 0, Name = "GPU"},
                new ComponentCategory(){Id = 1, Name = "Motherboard"},
                new ComponentCategory(){Id = 2, Name = "CPU"}
            };

            var groupedComponentsUsingQuerySyntax = from category in componentCategories
                                    join computerComponent in computerComponents on category.Id equals computerComponent.CategoryId into components
                                    select components;

            var groupedComponentsUsingMethodSyntax = componentCategories.GroupJoin(computerComponents, category => category.Id,
                computerComponent => computerComponent.CategoryId, (category, components) => components);

            foreach (var components in groupedComponentsUsingQuerySyntax)
            {
                Console.WriteLine($"Group");
                foreach (var product in components)
                {
                    Console.WriteLine($"{product.Name}");
                }
            }

            foreach (var components in groupedComponentsUsingMethodSyntax)
            {
                Console.WriteLine($"Group");
                foreach (var product in components)
                {
                    Console.WriteLine($"{product.Name}");
                }
            }

            //Output:
            //Group
            //Nvidia GeForce RTX 3090
            //AMD Radeon RX 6900 XT
            //Group
            //Asus TUF Gaming Z590-Plus WIFI
            //Group
            //Intel Core i5 12600K
            //AMD Ryzen 7 5700G
            //Group
            //Nvidia GeForce RTX 3090
            //AMD Radeon RX 6900 XT
            //Group
            //Asus TUF Gaming Z590-Plus WIFI
            //Group
            //Intel Core i5 12600K
            //AMD Ryzen 7 5700G
        }
    }
}
