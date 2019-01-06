using System;
using Microsoft.EntityFrameworkCore;

namespace EntitiyFrameworkDemo
{
    class Program
    {
        public class Recipient
        {
            public string name { get; set; }
            public string location { get; set; }
        };

        public class Paket
        {
            public Recipient recipient { get; set; }
            public int weight { get; set; }
        };

        public class PostDbContext :DbContext
        {
            public PostDbContext() : base()
            {
                //Database.EnsureCreated();
            }

            public DbSet<Paket> Pakete { get; set; }
            public DbSet<Recipient> Recipients { get; set; }

        }


        static void Main(string[] args)
        {
            using (var ctx = new PostDbContext())
            {
                var paket = new Paket() { weight = 20 };

                ctx.Pakete.Add(paket);
                ctx.SaveChanges();
            }
        }
    }
}
