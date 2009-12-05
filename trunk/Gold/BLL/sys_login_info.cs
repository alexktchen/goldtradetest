namespace GoldTradeNaming.BLL
{
    using GoldTradeNaming.DAL;
    using GoldTradeNaming.Model;
    using LTP.Common;
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class sys_login_info
    {
        private readonly GoldTradeNaming.DAL.sys_login_info dal = new GoldTradeNaming.DAL.sys_login_info();

        public int Add(GoldTradeNaming.Model.sys_login_info model)
        {
            return this.dal.Add(model);
        }

        public void Delete(int ID)
        {
            this.dal.Delete(ID);
        }

        public bool Exists(int ID)
        {
            return this.dal.Exists(ID);
        }

        public DataSet GetAllList()
        {
            return this.GetList("");
        }

        public DataSet GetList(string strWhere)
        {
            return this.dal.GetList(strWhere);
        }

        public int GetMaxId()
        {
            return this.dal.GetMaxId();
        }

        public GoldTradeNaming.Model.sys_login_info GetModel(int ID)
        {
            return this.dal.GetModel(ID);
        }

        public GoldTradeNaming.Model.sys_login_info GetModelByCache(int ID)
        {
            string CacheKey = "sys_login_infoModel-" + ID;
            object objModel = DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = this.dal.GetModel(ID);
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
            return (GoldTradeNaming.Model.sys_login_info) objModel;
        }

        public List<GoldTradeNaming.Model.sys_login_info> GetModelList(string strWhere)
        {
            DataSet ds = this.dal.GetList(strWhere);
            List<GoldTradeNaming.Model.sys_login_info> modelList = new List<GoldTradeNaming.Model.sys_login_info>();
            int rowsCount = ds.Tables[0].Rows.Count;
            if (rowsCount > 0)
            {
                for (int n = 0; n < rowsCount; n++)
                {
                    GoldTradeNaming.Model.sys_login_info model = new GoldTradeNaming.Model.sys_login_info();
                    if (ds.Tables[0].Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(ds.Tables[0].Rows[n]["ID"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["IP"].ToString() != "")
                    {
                        model.IP = ds.Tables[0].Rows[n]["IP"].ToString();
                    }
                    if (ds.Tables[0].Rows[n]["login_time"].ToString() != "")
                    {
                        model.login_time = DateTime.Parse(ds.Tables[0].Rows[n]["login_time"].ToString());
                    }
                    model.login_ID = ds.Tables[0].Rows[n]["login_ID"].ToString();
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        public void Update(GoldTradeNaming.Model.sys_login_info model)
        {
            this.dal.Update(model);
        }
    }
}
