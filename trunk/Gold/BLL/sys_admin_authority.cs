namespace GoldTradeNaming.BLL
{
    using GoldTradeNaming.DAL;
    using GoldTradeNaming.Model;
    using LTP.Common;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;

    public class sys_admin_authority
    {
        private readonly GoldTradeNaming.DAL.sys_admin_authority dal = new GoldTradeNaming.DAL.sys_admin_authority();

        public void Add(GoldTradeNaming.Model.sys_admin_authority model)
        {
            this.dal.Add(model);
        }

        public void Delete(int sys_admin_id, string sys_module)
        {
            this.dal.Delete(sys_admin_id, sys_module);
        }

        public bool Exists(int sys_admin_id, string sys_module)
        {
            return this.dal.Exists(sys_admin_id, sys_module);
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

        public GoldTradeNaming.Model.sys_admin_authority GetModel(int sys_admin_id, string sys_module)
        {
            return this.dal.GetModel(sys_admin_id, sys_module);
        }

        public GoldTradeNaming.Model.sys_admin_authority GetModelByCache(int sys_admin_id, string sys_module)
        {
            string CacheKey = "sys_admin_authorityModel-" + sys_admin_id + sys_module;
            object objModel = DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = this.dal.GetModel(sys_admin_id, sys_module);
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
            return (GoldTradeNaming.Model.sys_admin_authority) objModel;
        }

        public List<GoldTradeNaming.Model.sys_admin_authority> GetModelList(string strWhere)
        {
            DataSet ds = this.dal.GetList(strWhere);
            List<GoldTradeNaming.Model.sys_admin_authority> modelList = new List<GoldTradeNaming.Model.sys_admin_authority>();
            int rowsCount = ds.Tables[0].Rows.Count;
            if (rowsCount > 0)
            {
                for (int n = 0; n < rowsCount; n++)
                {
                    GoldTradeNaming.Model.sys_admin_authority model = new GoldTradeNaming.Model.sys_admin_authority();
                    if (ds.Tables[0].Rows[n]["sys_admin_id"].ToString() != "")
                    {
                        model.sys_admin_id = int.Parse(ds.Tables[0].Rows[n]["sys_admin_id"].ToString());
                    }
                    model.sys_module = ds.Tables[0].Rows[n]["sys_module"].ToString();
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        public DataTable GetRightSet(int adminid)
        {
            return this.dal.GetRightSet(adminid);
        }

        public void Update(GoldTradeNaming.Model.sys_admin_authority model)
        {
            this.dal.Update(model);
        }

        public void Update(int sys_admin_id, ArrayList sModule)
        {
            this.dal.Update(sys_admin_id, sModule);
        }
    }
}
