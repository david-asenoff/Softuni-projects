using Animals.Cats;
using Animals.Dogs;
using Animals.Frogs;

namespace Animals
{
    using System;

    public class Engine
    {
        public void Run()
        {
            while (true)
            {
                try
                {
                    var command = Console.ReadLine();

                    if (command == "Beast!")
                    {
                        break;
                    }

                    var animalInfo = Console.ReadLine()
                        ?.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    if (animalInfo != null)
                    {
                        var animalName = animalInfo[0];
                        var animalAge = int.Parse(animalInfo[1]);
                        var animalGender = animalInfo[2];

                        if (command == "Dog")
                        {
                            var dog = new Dog(animalName, animalAge, animalGender);
                            Console.WriteLine(dog);
                        }
                        else if (command == "Cat")
                        {
                            var cat = new Cat(animalName, animalAge, animalGender);
                            Console.WriteLine(cat);
                        }
                        else if (command == "Frog")
                        {
                            var frog = new Frog(animalName, animalAge, animalGender);
                            Console.WriteLine(frog);
                        }
                        else if (command == "Kitten")
                        {
                            var kitten = new Kitten(animalName, animalAge);
                            Console.WriteLine(kitten);
                        }
                        else if (command == "Tomcat")
                        {
                            var tomcat = new Tomcat(animalName, animalAge);
                            Console.WriteLine(tomcat);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
            }
        }
    }
}