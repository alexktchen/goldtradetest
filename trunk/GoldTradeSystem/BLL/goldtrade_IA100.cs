namespace GoldTradeNaming.BLL
{
    using GoldTradeNaming.DAL;
    using GoldTradeNaming.Model;
    using LTP.Common;
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class goldtrade_IA100
    {
        private readonly GoldTradeNaming.DAL.goldtrade_IA100 dal = new GoldTradeNaming.DAL.goldtrade_IA100();

        public void Add(GoldTradeNaming.Model.goldtrade_IA100 model)
        {
            this.dal.Add(model);
        }

        public void Delete(Guid IA100GUID)
        {
            this.dal.Delete(IA100GUID);
        }

        public bool Exists(Guid IA100GUID)
        {
            return this.dal.Exists(IA100GUID);
        }

        public bool ExistsAndNotInUse(Guid IA100GUID)
        {
            return this.dal.ExistsAndNotInUse(IA100GUID);
        }

        public DataSet GetAllList()
        {
            return this.GetList("");
        }

        public DataSet GetList(string strWhere)
        {
            return this.dal.GetList(strWhere);
        }

        public GoldTradeNaming.Model.goldtrade_IA100 GetModel(Guid IA100GUID)
        {
            return this.dal.GetModel(IA100GUID);
        }

        public GoldTradeNaming.Model.goldtrade_IA100 GetModelByCache(Guid IA100GUID)
        {
            string CacheKey = "goldtrade_IA100Model-" + IA100GUID;
            object objModel = DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = this.dal.GetModel(IA100GUID);
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
            return (GoldTradeNaming.Model.goldtrade_IA100) objModel;
        }

        public List<GoldTradeNaming.Model.goldtrade_IA100> GetModelList(string strWhere)
        {
            DataSet ds = this.dal.GetList(strWhere);
            List<GoldTradeNaming.Model.goldtrade_IA100> modelList = new List<GoldTradeNaming.Model.goldtrade_IA100>();
            int rowsCount = ds.Tables[0].Rows.Count;
            if (rowsCount > 0)
            {
                for (int n = 0; n < rowsCount; n++)
                {
                    GoldTradeNaming.Model.goldtrade_IA100 model = new GoldTradeNaming.Model.goldtrade_IA100();
                    if (ds.Tables[0].Rows[n]["IA100GUID"].ToString() != "")
                    {
                        model.IA100GUID = new Guid(ds.Tables[0].Rows[n]["IA100GUID"].ToString());
                    }
                    model.IA100Key = ds.Tables[0].Rows[n]["IA100Key"].ToString();
                    model.IA100SuperPswd = ds.Tables[0].Rows[n]["IA100SuperPswd"].ToString();
                    model.IA100State = ds.Tables[0].Rows[n]["IA100State"].ToString();
                    model.StateChangeReason = ds.Tables[0].Rows[n]["StateChangeReason"].ToString();
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        public void Update(GoldTradeNaming.Model.goldtrade_IA100 model)
        {
            this.dal.Update(model);
        }
    }
}
