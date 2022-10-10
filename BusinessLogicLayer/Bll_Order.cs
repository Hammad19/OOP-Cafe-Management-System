using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using System.Data;


namespace BusinessLogicLayer
{
    public class Bll_Order
    {
        public void AddOrder(string _Category, string _Name, string _UnitPrice, string _Qty, string _Total, string _User)
        {
            DAL obj = new DAL();
            obj.OpenConnection();
            obj.LoadSpParameters("sp_insertOrder", _Category, _Name, _UnitPrice, _Qty, _Total, _User);
            obj.ExecuteQuery();
            obj.UnLoadSpParameters();
            obj.CloseConnection();
        }

              
        public DataTable SelectItemFromCat(string _Category)
        {
            DataTable de = new DataTable();
            DAL obj = new DAL();
            obj.OpenConnection();
            obj.LoadSpParameters("sp_selectItemfromCat", _Category);
            de = obj.GetDataTable();
            obj.UnLoadSpParameters();
            obj.CloseConnection();
            return de;
        }
        public DataTable ShowOrderHistory()
        {
            DataTable de = new DataTable();
            DAL obj = new DAL();
            obj.OpenConnection();
            obj.LoadSpParameters("sp_selectallorderitem");
            de = obj.GetDataTable();
            obj.UnLoadSpParameters();
            obj.CloseConnection();
            return de;
        }
        public DataTable ShowOrderHistory(string _User)
        {
            DataTable de = new DataTable();
            DAL obj = new DAL();
            obj.OpenConnection();
            obj.LoadSpParameters("sp_selectHistoryfromUser", _User);
            de = obj.GetDataTable();
            obj.UnLoadSpParameters();
            obj.CloseConnection();
            return de;
        }
        

        
    }
}
