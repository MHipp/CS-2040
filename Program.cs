using System;

namespace Dog1
{
    class Dog
    {
        string name;
        string owner;
        int age;
        enum Gender
        {
            Male,
            Female
        }
        public Dog(string name1, string owner1, int age1)
        {
            name = name1;
            owner = owner1;
            age = age1;

        }
        /*public void GetTag()
        {
            if (Gender == Male)
            {
                string gender1 = "his";
                string gender2 = "he";
            }
            else
            {
                string gender1 = "her";
                string gender2 = "she";
            }
            Console.WriteLine("If lost, call " + owner + ". " + gender1 + " name is " + name + " and " + gender2 + " is " + age + " years old.");
        }*/
        public void Bark(int woofs)
        {
            for(; woofs > 0; woofs--)
            {
                Console.WriteLine("Bark!");
            }
        }
        static void Main(string[] args)
        {
            Dog puppy = Dog("Orion", "Shawn", 1, Gender.Male);  // create object instance
            puppy.Bark(3); // output: Woof!Woof!Woof!
            Console.WriteLine(puppy.GetTag()); // output: If lost, call Shawn. His name is Orion and he is 1 year old.

            Dog myDog = Dog("Lileu", "Dale", 4, Gender.Female);  // create object instance
            myDog.Bark(1); // output: Woof!
            Console.WriteLine(myDog.GetTag()); // output: If lost, call Dale. Her name is Lileu and she is 4 years old.
        }
    }
}
