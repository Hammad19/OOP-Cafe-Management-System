using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using System.Data;

namespace BusinessLogicLayer
{
    public class Bll_Bill
    {
        public void AddBill(string _billid, string _cosid, string _cosname, string _date, string _total)
        {
            DAL obj = new DAL();
            obj.OpenConnection();
            obj.LoadSpParameters("sp_insertbill", _billid, _cosid, _cosname, _date, _total);
            obj.ExecuteQuery();
            obj.UnLoadSpParameters();
            obj.CloseConnection();
        }
        public void UpdateBill(string _billid, string _cosid, string _cosname, string _date, string _total)
        {
            DAL obj = new DAL();
            obj.OpenConnection();
            obj.LoadSpParameters("sp_updatebill", _billid, _cosid, _cosname, _date, _total);
            obj.ExecuteQuery();
            obj.UnLoadSpParameters();
            obj.CloseConnection();
        }
        public void DeleteBill(string _billid)
        {
            DAL obj = new DAL();
            obj.OpenConnection();
            obj.LoadSpParameters("sp_deletebill", _billid);
            obj.ExecuteQuery();
            obj.UnLoadSpParameters();
            obj.CloseConnection();
        }

        public DataTable ShowBill()
        {
            DataTable de = new DataTable();
            DAL obj = new DAL();
            obj.OpenConnection();
            obj.LoadSpParameters("sp_showbill");
            de = obj.GetDataTable();
            obj.UnLoadSpParameters();
            obj.CloseConnection();
            return de;
        }
        public DataTable BillsWithResToCustomer(string customer_id)
        {
            DataTable de = new DataTable();
            DAL obj = new DAL();
            obj.OpenConnection();
            obj.LoadSpParameters("sp_showbillwithrtcos",customer_id);
            de = obj.GetDataTable();
            obj.UnLoadSpParameters();
            obj.CloseConnection();
            return de;
        }

        public DataTable ShowBill(string _Bill_ID)
        {
            DataTable de = new DataTable();
            DAL obj = new DAL();
            obj.OpenConnection();
            obj.LoadSpParameters("sp_showbillforcust", _Bill_ID);
            de = obj.GetDataTable();
            obj.UnLoadSpParameters();
            obj.CloseConnection();
            return de;
        }


    }
}
