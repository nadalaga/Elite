using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OrderService
    {
        public Order order;
        private string dbFullPath;

        public OrderService(string dbFullPath)
        {
            this.dbFullPath = dbFullPath;
        }

        public OrderService()
        {
        }
        public async Task<int> Insert()
        {
            int result = 0;
            try
            {
              
                using (var db = new EliteContext(dbFullPath))
                {
                    //await db.Database.EnsureDeletedAsync();
                    await db.Database.EnsureCreatedAsync();
                    await db.Database.MigrateAsync(); // We need to ensure the latest Migration was added. This is different than EnsureDatabaseCreated.
                    //Add A few order 
                     Order order = new Order() {  name="T-shirt",description="Nice shirt",image="Images/Image1.png" };

                    List<Order> objOrder = new List<Order>() { order };
                    await db.Orders.AddRangeAsync(objOrder);
                    await db.SaveChangesAsync();

                    Order order1 = new Order() { name = "Dress", description = "Nice dress", image = "Images/Image2.png" };

                    List<Order> objOrder1 = new List<Order>() { order1 };
                    await db.Orders.AddRangeAsync(objOrder1);
                    await db.SaveChangesAsync();


                }
                
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
            return result;
        }


        public async Task<List<Order>> Get()
        {
            try
            {
                using (var db = new EliteContext(dbFullPath))
                {
                    return await db.Orders.ToListAsync();
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
