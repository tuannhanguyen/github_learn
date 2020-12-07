using MobileStoreConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileStore.Models.BUS
{
    public class MobileStoreBUS
    {
       public static IEnumerable<Product> DanhSach()
        {
            var db = new MobileStoreConnectionDB();
            return db.Query<Product>("select * from Products Where Status = 'False'");
        }
        public static Product ChiTiet(int a)
        {
            var db = new MobileStoreConnectionDB();
            return db.SingleOrDefault<Product>("select * from Products Where ProductID = @0",a);
        }
    }
}