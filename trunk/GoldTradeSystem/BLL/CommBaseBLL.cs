namespace GoldTradeNaming.BLL
{
    using GoldTradeNaming.DAL;
    using System;
    using System.Data;

    public class CommBaseBLL
    {
        private CommBaseDAL dal = new CommBaseDAL();

        public static decimal GetAddMoneyTotal(int fran_id)
        {
            return CommBaseDAL.GetAddMoneyTotal(fran_id);
        }

        public static decimal GetBalance(int franID)
        {
            return CommBaseDAL.GetBalance(franID);
        }

        public DataSet getCurrentPrice()
        {
            return this.dal.getCurrentPrice();
        }

        public static string GetFranName(int fran_code)
        {
            GoldTradeNaming.BLL.franchiser_info bll = new GoldTradeNaming.BLL.franchiser_info();
            return bll.GetModel(fran_code).franchiser_name;
        }

        public decimal GetGoldNoReceiveValue(string franchiser_code)
        {
            return this.dal.GetGoldNoReceiveValue(franchiser_code);
        }

        public decimal GetGoldStockValue(string franchiser_code)
        {
            return this.dal.GetGoldStockValue(franchiser_code);
        }

        public DataSet GetLeftStock(string franchiser_code)
        {
            return this.dal.GetLeftStock(franchiser_code);
        }

        public DataSet GetList(string strWhere)
        {
            return this.dal.GetList(strWhere);
        }

        public static int GetNextOrderId()
        {
            return CommBaseDAL.GetNextOrderId();
        }

        public static int GetNextTradeId()
        {
            return CommBaseDAL.GetNextTradeId();
        }

        public static decimal GetOrderSumByFranId(int franid)
        {
            return CommBaseDAL.GetOrderSumByFranId(franid);
        }

        public static string GetProductTypeById(string type_id)
        {
            return CommBaseDAL.GetProductTypeById(type_id);
        }

        public static decimal getRealTimePrice()
        {
            return CommBaseDAL.getRealTimePrice();
        }

        public static DataSet GetReportData(string franId, string dateS, string dateE, string franName)
        {
            return CommBaseDAL.GetReportData(franId, dateS, dateE, franName);
        }

        public decimal GetSilverNoReceiveValue(string franchiser_code)
        {
            return this.dal.GetSilverNoReceiveValue(franchiser_code);
        }

        public decimal GetSilverStockValue(string franchiser_code)
        {
            return this.dal.GetSilverStockValue(franchiser_code);
        }

        public static DataSet GetStockReportData(string franname, string prdname, string dateS, string dateE)
        {
            return CommBaseDAL.GetStockReportData(franname, prdname, dateS, dateE);
        }

        public DataSet GetSumNoReceive(string franchiser_code)
        {
            return this.dal.GetSumNoReceive(franchiser_code);
        }

        public static decimal GetTradeBalance(int franID)
        {
            return CommBaseDAL.GetTradeBalance(franID);
        }

        public static decimal GetTradeSumByFranId(int franid)
        {
            return CommBaseDAL.GetTradeSumByFranId(franid);
        }

        public static bool HasRight(int sys_admin_id, string modelID)
        {
            return CommBaseDAL.HasRight(sys_admin_id, modelID);
        }
    }
}
