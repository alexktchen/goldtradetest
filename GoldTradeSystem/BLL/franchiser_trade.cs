namespace GoldTradeNaming.BLL
{
    using GoldTradeNaming.DAL;
    using GoldTradeNaming.Model;
    using LTP.Common;
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class franchiser_trade
    {
        private readonly GoldTradeNaming.DAL.franchiser_trade dal = new GoldTradeNaming.DAL.franchiser_trade();

        public int Add(GoldTradeNaming.Model.franchiser_trade model)
        {
            return this.dal.Add(model);
        }

        public bool AddTrandeInfo(List<ProductInfo> prInfos, TradeInfo trInfo, string iType)
        {
            return this.dal.AddTrandeInfo(prInfos, trInfo, iType);
        }

        public void Delete(int trade_id)
        {
            this.dal.Delete(trade_id);
        }

        public bool Exists(int trade_id)
        {
            return this.dal.Exists(trade_id);
        }

        public DataSet GetAllTrade(int franchiser_code, int trade_id, DateTime dtFrom, DateTime dtTo, bool isInit)
        {
            return this.dal.GetAllTrade(franchiser_code, trade_id, dtFrom, dtTo, isInit);
        }

        public DataSet getCurrentPrice()
        {
            return this.dal.getCurrentPrice();
        }

        public DataSet GetFranList(int fran_code)
        {
            return this.dal.GetFranList(fran_code);
        }

        public DataSet GetGoldNoReceive(string franchiser_code)
        {
            return this.dal.GetGoldNoReceive(franchiser_code);
        }

        public decimal GetGoldNoReceiveValue(int franchiser_code)
        {
            return this.dal.GetGoldNoReceiveValue(franchiser_code);
        }

        public DataSet GetGoldStock(int franchiser_code)
        {
            return this.dal.GetGoldStock(franchiser_code);
        }

        public decimal GetGoldStockValue(int franchiser_code)
        {
            return this.dal.GetGoldStockValue(franchiser_code);
        }

        public DataSet GetLeftStock(string franchiser_code)
        {
            return this.dal.GetLeftStock(franchiser_code);
        }

        public int GetMaxId()
        {
            return this.dal.GetMaxId();
        }

        public GoldTradeNaming.Model.franchiser_trade GetModel(int trade_id)
        {
            return this.dal.GetModel(trade_id);
        }

        public GoldTradeNaming.Model.franchiser_trade GetModelByCache(int trade_id)
        {
            string CacheKey = "franchiser_tradeModel-" + trade_id;
            object objModel = DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = this.dal.GetModel(trade_id);
                    if (objModel != null)
                    {
                        int ModelCache = ConfigHelper.GetConfigInt("ModelCache");
                        DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes((double) ModelCache), TimeSpan.Zero);
                    }
                }
                catch
                {
                }
            }
            return (GoldTradeNaming.Model.franchiser_trade) objModel;
        }

        public decimal GetSilverNoReceiveValue(int franchiser_code)
        {
            return this.dal.GetSilverNoReceiveValue(franchiser_code);
        }

        public DataSet GetSilverStock(int franchiser_code)
        {
            return this.dal.GetSilverStock(franchiser_code);
        }

        public decimal GetSilverStockValue(int franchiser_code)
        {
            return this.dal.GetSilverStockValue(franchiser_code);
        }

        public DataSet GetTradeAdd(int product_id)
        {
            return this.dal.GetTradeAdd(product_id);
        }

        public DataSet GetTradeByM(int franchiser_code, int trade_id, string franchiser_name, bool isInit)
        {
            return this.dal.GetTradeByM(franchiser_code, trade_id, franchiser_name, isInit);
        }

        public DataSet GetTradeDesc(int trade_id)
        {
            return this.dal.GetTradeDesc(trade_id);
        }

        public DataSet GetTradeReportData(string franid, string tradeID, string timeS, string timeE, string type, string franName)
        {
            return this.dal.GetTradeReportData(franid, tradeID, timeS, timeE, type, franName);
        }

        public DataSet GetTradetime()
        {
            return this.dal.GetTradetime();
        }

        public int SetTradeTime(DateTime dtFrom, DateTime dtTo, string ins_user)
        {
            return this.dal.SetTradeTime(dtFrom, dtTo, ins_user);
        }

        public int TradeCount(DateTime dt)
        {
            return this.dal.TradeCount(dt);
        }

        public void Update(GoldTradeNaming.Model.franchiser_trade model)
        {
            this.dal.Update(model);
        }
    }
}
