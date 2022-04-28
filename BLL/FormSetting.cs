using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class FormSetting
    {
        string menuID, procedureName, tableName, selectCommandText;
        bool loadDataImmediately;
        public FormSetting(string _MenuID)
        {
            // load config
            this.MenuID = _MenuID;
        }
        
        public string MenuID { get => menuID; set => menuID = value; }
        public string ProcedureName { get => procedureName; set => procedureName = value; }
        public string TableName { get => tableName; set => tableName = value; }
        public bool LoadDataImmediately { get => loadDataImmediately; set => loadDataImmediately = value; }
        public string SelectCommandText { get => selectCommandText; set => selectCommandText = value; }

        public static FormSetting Instance(string menuID)
        {
            try
            {
                using (DataTable dt = DataConnection.ReturnDataTable("select * from FormSetting where MenuID = @MenuID", "@MenuID", menuID))
                {
                    if (dt.Rows.Count <= 0)
                    {
                        throw new Exception("This form hasn't been configured yet!");
                    }
                    FormSetting fs = new FormSetting(menuID);
                    PropertiesAdapter.AdapDataIntoObject(dt.Rows[0], fs);
                    return fs;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
