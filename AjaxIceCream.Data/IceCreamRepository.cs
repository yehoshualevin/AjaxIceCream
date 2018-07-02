using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AjaxIceCream.Data
{
    public class IceCreamRepository
    {
        
        public IEnumerable<IceCream> GetOrders()
        {
            using (var context = new IceCreamDataContext())
            {
                return context.IceCreams.ToList();
            }
        }
        public void Add(IceCream ice)
        {
            using (var context = new IceCreamDataContext())
            {
                context.IceCreams.InsertOnSubmit(ice);
                context.SubmitChanges();
            }
        }
        public void Update(IceCream ice)
        {
            using (var context = new IceCreamDataContext())
            {
                context.ExecuteCommand("update IceCream set Flavor = {0},Lowfat = {1} where Id = {2}", ice.Flavor, ice.LowFat,ice.Id);
            }
        }
        public void Delete(int id)
        {
            using (var context = new IceCreamDataContext())
            {
                context.ExecuteCommand("delete from IceCream where Id = {0}",id);
            }
        }
    }
}
