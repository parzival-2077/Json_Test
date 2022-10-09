using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;

namespace ConsoleApp2
{
    class Program
    {
        static async Task Main(string[] args)
        {
            
           string s = Console.ReadLine();
            if (s == "new")
            {
                string name = Console.ReadLine();
                string age = Console.ReadLine();
                using (FileStream fs = new FileStream("user.json", FileMode.OpenOrCreate))//запись
                {
                    Person tom = new Person(name, age);
                    await JsonSerializer.SerializeAsync<Person>(fs, tom);
                    Console.WriteLine("Data has been saved to file");
                }

            }
            else
            {
                
                // чтение данных
                using (FileStream fs = new FileStream("user.json", FileMode.OpenOrCreate))
                {
                    //Person person1 = new Person("A4", "0,8—1,0 ГГц");
                    if (s == "A5")
                    {
                        Person[] person1 = await JsonSerializer.DeserializeAsync<Person[]>(fs);
                        foreach (Person p :person1)
                        Console.WriteLine($"Name: {p?.Name}  Age: {p?.Age}");
                    }
                    
                }
            }



            
        }
    }


    class Person
    {
       
        public string Name { get; }
        public string Age { get; set; }
        
        public Person(string name, string age)
        {
            
            Name = name;
            Age = age;
        }
    }
}
