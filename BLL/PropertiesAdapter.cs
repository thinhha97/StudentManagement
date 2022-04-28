using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public static class PropertiesAdapter
    {
        public static void AdapDataIntoObject(DataRow dr, object obj)
        {
            var pros = obj.GetType().GetProperties();
            var datacolumns = dr.Table.Columns.Cast<DataColumn>().Select(c => c.ColumnName);
            var joined = from a in pros
                    join b in datacolumns
                    on a.Name.ToLower() equals b.ToLower()
                    select new
                    {
                        a,
                        val = dr[b]
                    };
            foreach ( var item in joined)
            {
                if (item.val != null && item.val != DBNull.Value)
                item.a.SetValue(obj, item.val);
            }
        }
    }
}
