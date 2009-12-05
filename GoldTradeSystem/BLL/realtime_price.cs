namespace GoldTradeNaming.BLL
{
    using GoldTradeNaming.DAL;
    using GoldTradeNaming.Model;
    using LTP.Common;
    using System;
    using System.Data;

    public class realtime_price
    {
        private readonly GoldTradeNaming.DAL.realtime_price dal = new GoldTradeNaming.DAL.realtime_price();

        public int Add(GoldTradeNaming.Model.realtime_price model)
        {
            return this.dal.Add(model);
        }

        public bool Exists(int id)
        {
            return this.dal.Exists(id);
        }

        public DataSet getCurrentPrice()
        {
            return this.dal.getCurrentPrice();
        }

        public DataSet GetList(DateTime dtFrom, DateTime dtTo)
        {
            return this.dal.GetList(dtFrom, dtTo);
        }

        public int GetMaxId()
        {
            return this.dal.GetMaxId();
        }

        public GoldTradeNaming.Model.realtime_price GetModel(int id)
        {
            return this.dal.GetModel(id);
        }

        public GoldTradeNaming.Model.realtime_price GetModelByCache(int id)
        {
            string CacheKey = "realtime_priceModel-" + id;
            object objModel = DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = this.dal.GetModel(id);
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
            return (GoldTradeNaming.Model.realtime_price) objModel;
        }
    }
}
