using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab_07_Entity.Entities;
using Lab_07_Entity.Homework;
using Microsoft.EntityFrameworkCore;

namespace Lab_07_Entity
{
    class Program
    {
        static async Task Main(string[] args)
        {
            HomeWorkContext homeWorkContext = new HomeWorkContext();
            
            // await InsertData(homeWorkContext);
            // await ReadFromServer(homeWorkContext);
            // UpdatePassword(homeWorkContext, "Sarah", "************");
            //RemoveReport(homeWorkContext, "report");

        }




        public static async Task InsertData(HomeWorkContext hc)
        {
            var usr = new Homework.User()
            {
                Name = "John",
                Password = "^#$%&%JoH^^",
                Roles = new Roles()
                {
                    Name = "Accountant",
                    Tasks = new List<Tasks>()
                    {
                        new Tasks {Name= "Reply to e-mails", Description="Reply to all e-mails" },
                        new Tasks {Name="Issue of invoice", Description="Issuing an invoice for sold furniture" }
                    }
                }
            };

            var usr2 = new Homework.User()
            {
                Name = "Sarah",
                Password = "^#$@r@^^",
                Roles = new Roles()
                {
                    Name = "manager",
                    Tasks = new List<Tasks>()
                    {
                        new Tasks {Name= "meeting", Description="meeting with the company's management" },
                        new Tasks {Name="report", Description="sales report from May(2021" }
                    }
                }
            };

            hc.Add(usr);
            hc.Add(usr2);

            await hc.SaveChangesAsync();
            Console.WriteLine("Done.");
        }

        public static async Task ReadFromServer(HomeWorkContext hc)
        {
            var usrFromServer = await hc.Users
                  .Include(u => u.Roles)
                  .ThenInclude(U => U.Tasks)
                  .Where(B => B.Name == "John")
                  .ToListAsync();

            foreach (var x in usrFromServer)
            {
                System.Console.WriteLine("User Name: " + x.Name);
                Console.WriteLine("Company roles: " + x.Roles.Name);
                foreach (var z in x.Roles.Tasks)
                {
                    Console.WriteLine("Task" + z.Name);
                    Console.WriteLine("    Description: " + z.Description);
                }
            }
        }
        public static void UpdatePassword(HomeWorkContext hc, string user, string newPassword)
        {
            var newPass = hc.Users.First(a => a.Name == user);
            newPass.Password = newPassword;
            hc.SaveChanges();
            Console.WriteLine(user + "Password updated");
        }

        public static void RemoveReport(HomeWorkContext hc, string remove)
        {
            hc.Remove(hc.Tasks.Single(a => a.Name == remove));
            hc.SaveChanges();
            Console.WriteLine("Task: " + remove + " is removed");
        }


    }
}
