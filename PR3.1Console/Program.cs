using PR3._1Console.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR3._1Console
{
    class Program
    {
        LibraryEntities bd = Halper.GetContext();
        static void Main(string[] args)
        {
            Halper halper = new Halper();
            LibraryEntities db = Halper.GetContext();
            Console.WriteLine("Создание новой учетной записи для пользователя");
            Console.Write("Введите имя пользователя:");
            string name = Console.ReadLine();
            Console.Write("Введите фамилию пользователя:");
            string surname = Console.ReadLine();
            Console.Write("Введите отчество пользователя:");
            string patronymic = Console.ReadLine();
            Console.Write("Введите email пользователя:");
            string email = Console.ReadLine();
            Console.Write("Введите номер телефона пользователя:");
            string phone_number = Console.ReadLine();
            Console.Write("Введите пароль пользователя:");
            string password = Console.ReadLine();
            Console.Write("Введите логин пользователя:");
            string login = Console.ReadLine();
            HashPasword.Hash hash = new HashPasword.Hash();
            password = hash.Hashing(password);
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(surname)
&& string.IsNullOrEmpty(email) && string.IsNullOrEmpty(phone_number)
&& string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                Console.WriteLine("Не все данные введены");
            }
            else if (int.TryParse(name, out int n) || int.TryParse(surname, out int s)
            || int.TryParse(login, out int l))
            {
                Console.WriteLine("Данные введены не корректно");
            }
            else
            {
                Client client = new Client {F_Name = name, L_Name = surname, M_Name = patronymic, Email = email, Phone_Number = phone_number, Login = login, Password = password };
                halper.CreateUsers(client);
                Console.WriteLine("Учетная запись добавлена");
                Console.ReadLine();
            }
        }
    }
}
