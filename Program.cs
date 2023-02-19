using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Module_8_4_3
{

    // Описываем наш класс и помечаем его атрибутом для последующей сериализации   
    [Serializable]
    class Contact
    {
        public string Name { get; set; }
        public long PhoneNumber { get; set; }
        public string Email { get; set; }

        public Contact(string name, long phoneNumber, string email)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            Email = email;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // объект для сериализации
            var person = new Contact("Kostya", 79129725388, "silen@inbox.ru");
            Console.WriteLine("Объект создан");

            BinaryFormatter formatter = new BinaryFormatter();
            // получаем поток, куда будем записывать сериализованный объект
            using (var fs = new FileStream("myContacts.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, person);
                Console.WriteLine("Объект сериализован");
            }
            // десериализация
            using (var fs = new FileStream("myContacts.dat", FileMode.OpenOrCreate))
            {
                var newPerson = (Contact)formatter.Deserialize(fs);
                Console.WriteLine("Объект десериализован");
                Console.WriteLine($"Имя: {newPerson.Name} --- телефон: {newPerson.PhoneNumber} --- email: {newPerson.Email}");
            }
            Console.ReadLine();
        }
    }
}