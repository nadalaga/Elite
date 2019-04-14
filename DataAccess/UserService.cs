using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class UserService
    {
        public User user;
        private string dbFullPath;

        public UserService(string dbFullPath)
        {
            this.dbFullPath = dbFullPath;
        }

        public UserService() {
        }
        public async void Insert()
        {
            try
            {
                using (var db = new EliteContext(dbFullPath))
                {
                    //await db.Database.EnsureDeletedAsync();
                    await db.Database.EnsureCreatedAsync();
                    await db.Database.MigrateAsync(); // We need to ensure the latest Migration was added. This is different than EnsureDatabaseCreated.

                  ////  User user = new User() { iduser = 1, username = "giang", password = "123456" ,
                   //     address ="1 huke lane", email="nadalaga2002" };

                    List<User> objuser = new List<User>() { user  };
                    await db.Users.AddRangeAsync(objuser);
                    await db.SaveChangesAsync();

             
                }

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }

        }



        public async Task<User> CheckLogin(string name, string password)
        {
            try
            {
                using (var db = new EliteContext(dbFullPath))
                {
                    return await db.Users.Where(a => a.username == name && a.password == password).FirstOrDefaultAsync();
                }

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }

            return null;
        }

        public async Task<List<User>> Get()
        {
            try
            {
                using (var db = new EliteContext(dbFullPath))
                {
                    return await db.Users.ToListAsync();
                }

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }

            return null;
        }

    }
}
