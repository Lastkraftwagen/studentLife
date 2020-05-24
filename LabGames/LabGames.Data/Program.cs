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
                db.Users.Add(user1);
                db.SaveChanges();
                Console.WriteLine("Объекты успешно сохранены");
            }
        }
    }
}
