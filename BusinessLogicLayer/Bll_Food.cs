using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using System.Data;
using System.Data.SqlClient;
namespace BusinessLogicLayer
{
    public class Bll_Food
    {
        public void AddFood(string _Category, string _Pname, string _PCode, string _PQty, string _PPrice)
        {
            DAL obj = new DAL();
            obj.OpenConnection();
            obj.LoadSpParameters("sp_insertItem", _Category, _Pname, _PCode, _PQty, _PPrice);
            obj.ExecuteQuery();
            obj.UnLoadSpParameters();
            obj.CloseConnection();
        }

        public void UpdateFood(string _Category, string _Pname, string _PCode, string _PQty, string _PPrice)
        {
            DAL obj = new DAL();
            obj.OpenConnection();
            obj.LoadSpParameters("sp_updateItem", _Category, _Pname, _PCode, _PQty, _PPrice);
            obj.ExecuteQuery();
            obj.UnLoadSpParameters();
            obj.CloseConnection();
        }

        public void DeleteFood( string _PCode)
        {
            DAL obj = new DAL();
            obj.OpenConnection();
            obj.LoadSpParameters("sp_deleteItem", _PCode);
            obj.ExecuteQuery();
            obj.UnLoadSpParameters();
            obj.CloseConnection();
        }


        public DataTable ShowEmployee(string _Category)
        {
            DataTable dt = new DataTable();
            DAL showobj = new DAL();
            showobj.OpenConnection();
            showobj.LoadSpParameters("sp_showFoodCategory", _Category);
            dt = showobj.GetDataTable();
            showobj.UnLoadSpParameters();
            showobj.CloseConnection();
            return dt;

            
        }
    }
}

