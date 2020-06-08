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
                Gender male = new Gender() { GenderName = "male" };
                Gender female = new Gender() { GenderName = "female" };


                db.Genders.Add(male);
                db.Genders.Add(female);
                db.Users.Add(user1);
                db.Records.Add(new Record()
                {
                    Date = DateTime.Now,
                    GenderId = 1,
                    UserId = 3,
                    PlayerName = "nick",
                    Points = 1123
                });
                db.SaveChanges();
                Console.WriteLine("Объекты успешно сохранены");
                Console.ReadLine();
            }
        }
    }
}
