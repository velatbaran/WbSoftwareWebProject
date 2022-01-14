using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WbSoftwareWebProject.DataAccessLayer.EntitiyFramework;
using WbSoftwareWebProject.Entities.Entity;

namespace WbSoftwareWebProject.DataAccessLayer.EntityFramework
{
    public class MyInitializer : CreateDatabaseIfNotExists<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            //Contact contact = new Contact()
            //{
            //    Address = "Dicle Üniversitesi Teknokent Binası Kat:2 Sur/Diyarbakır",
            //    Email = "baranvelat021@gmail.com",
            //    Phone = "5393711268",
            //    Github = "https://github.com/velatbaran",
            //    Twitter = "https://twitter.com/baranvelat021",
            //    Instagram = "https://www.instagram.com/baranvelat021/",
            //    Telegram = "https://t.me/baranvelat",
            //    CreatedOn = DateTime.Now,
            //    UpdatedOn = DateTime.Now.AddDays(2)
            //};


            //context.Contact.Add(contact);

            Services services1 = new Services()
            {
                Title = "Web Tasarım",
                Description = "AspNet Mvc5, Bootstrap,Entity Framework gibi teknolojiler kullanılarak projeler geliştirilir.",
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now.AddDays(2),
                SavedUsername = "welatbaran"

            };
            Services services2 = new Services()
            {
                Title = "Web Otomasyon",
                Description = "AspNet Mvc5, Bootstrap,Entity Framework gibi teknolojiler kullanılarak projeler geliştirilir.",
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now.AddDays(2),
                SavedUsername = "welatbaran"

            };

            context.Services.Add(services1);
            context.Services.Add(services2);
            context.SaveChanges();
        }
    }
}
