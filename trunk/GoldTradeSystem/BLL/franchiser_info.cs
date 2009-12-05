namespace GoldTradeNaming.BLL
{
    using GoldTradeNaming.DAL;
    using GoldTradeNaming.Model;
    using LTP.Common;
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class franchiser_info
    {
        private readonly GoldTradeNaming.DAL.franchiser_info dal = new GoldTradeNaming.DAL.franchiser_info();

        public int Add(GoldTradeNaming.Model.franchiser_info model)
        {
            return this.dal.Add(model);
        }

        public void Delete(int franchiser_code)
        {
            this.dal.Delete(franchiser_code);
        }

        public int DisableIA(Guid IA100GUID, string reason)
        {
            return this.dal.DisableIA(IA100GUID, reason);
        }

        public bool Exists(Guid guid)
        {
            return this.dal.Exists(guid);
        }

        public bool Exists(int franchiser_code)
        {
            return this.dal.Exists(franchiser_code);
        }

        public bool Exists(string franchiser_name)
        {
            return this.dal.Exists(franchiser_name);
        }

        public bool Exists(int franchiser_code, Guid guid)
        {
            return this.dal.Exists(franchiser_code, guid);
        }

        public bool Exists(int franchiser_code, string franchiser_name)
        {
            return this.dal.Exists(franchiser_code, franchiser_name);
        }

        public DataSet GetAllList()
        {
            return this.GetList("");
        }

        public DataSet GetFranAllInfo(string strWhere)
        {
            return this.dal.GetFranAllInfo(strWhere);
        }

        public DataSet GetList(string strWhere)
        {
            return this.dal.GetList(strWhere);
        }

        public int GetMaxId()
        {
            return this.dal.GetMaxId();
        }

        public GoldTradeNaming.Model.franchiser_info GetModel(int franchiser_code)
        {
            return this.dal.GetModel(franchiser_code);
        }

        public GoldTradeNaming.Model.franchiser_info GetModelByCache(int franchiser_code)
        {
            string CacheKey = "franchiser_infoModel-" + franchiser_code;
            object objModel = DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = this.dal.GetModel(franchiser_code);
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
            return (GoldTradeNaming.Model.franchiser_info) objModel;
        }

        public List<GoldTradeNaming.Model.franchiser_info> GetModelList(string strWhere)
        {
            DataSet ds = this.dal.GetList(strWhere);
            List<GoldTradeNaming.Model.franchiser_info> modelList = new List<GoldTradeNaming.Model.franchiser_info>();
            int rowsCount = ds.Tables[0].Rows.Count;
            if (rowsCount > 0)
            {
                for (int n = 0; n < rowsCount; n++)
                {
                    GoldTradeNaming.Model.franchiser_info model = new GoldTradeNaming.Model.franchiser_info();
                    if (ds.Tables[0].Rows[n]["franchiser_code"].ToString() != "")
                    {
                        model.franchiser_code = int.Parse(ds.Tables[0].Rows[n]["franchiser_code"].ToString());
                    }
                    model.franchiser_name = ds.Tables[0].Rows[n]["franchiser_name"].ToString();
                    if (ds.Tables[0].Rows[n]["franchiser_balance_money"].ToString() != "")
                    {
                        model.franchiser_balance_money = decimal.Parse(ds.Tables[0].Rows[n]["franchiser_balance_money"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["franchiser_asure_money"].ToString() != "")
                    {
                        model.franchiser_asure_money = decimal.Parse(ds.Tables[0].Rows[n]["franchiser_asure_money"].ToString());
                    }
                    model.franchiser_tel = ds.Tables[0].Rows[n]["franchiser_tel"].ToString();
                    model.franchiser_cellphone = ds.Tables[0].Rows[n]["franchiser_cellphone"].ToString();
                    model.franchiser_address = ds.Tables[0].Rows[n]["franchiser_address"].ToString();
                    model.ins_user = ds.Tables[0].Rows[n]["ins_user"].ToString();
                    if (ds.Tables[0].Rows[n]["ins_date"].ToString() != "")
                    {
                        model.ins_date = DateTime.Parse(ds.Tables[0].Rows[n]["ins_date"].ToString());
                    }
                    model.upd_user = ds.Tables[0].Rows[n]["upd_user"].ToString();
                    if (ds.Tables[0].Rows[n]["upd_date"].ToString() != "")
                    {
                        model.upd_date = DateTime.Parse(ds.Tables[0].Rows[n]["upd_date"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["IA100GUID"].ToString() != "")
                    {
                        model.IA100GUID = new Guid(ds.Tables[0].Rows[n]["IA100GUID"].ToString());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        public void Update(GoldTradeNaming.Model.franchiser_info model)
        {
            this.dal.Update(model);
        }
    }
}
