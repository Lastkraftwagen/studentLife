using LabGames.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabGames.Data
{
    class Program
    {
        static void Main(string[] args)
        {
            using (UnitOfWork db = new UnitOfWork())
            {
                // создаем два объекта User
                User user1 = new User { Name = "Tom", Password = "pass", Email="test@test.com"};
                User user2 = new User { Name = "login", Password = "pass", Email="test@test.com" };

                // добавляем их в бд
                db.Users.Add(user1);
                db.Users.Add(user2);
                db.SaveChanges();
                Console.WriteLine("Объекты успешно сохранены");

                var users = db.Users;
                Console.WriteLine("Список объектов:");
                foreach (User u in users)
                {
                    Console.WriteLine("{0}.{1}", u.Name, u.Password);
                }
            }
            Console.Read();
        }
    }
}
