namespace GoldTradeNaming.BLL
{
    using GoldTradeNaming.DAL;
    using GoldTradeNaming.Model;
    using LTP.Common;
    using System;
    using System.Data;

    public class goldtrade_db_admin
    {
        private readonly GoldTradeNaming.DAL.goldtrade_db_admin dal = new GoldTradeNaming.DAL.goldtrade_db_admin();

        public int Add(GoldTradeNaming.Model.goldtrade_db_admin model)
        {
            return this.dal.Add(model);
        }

        public void Delete(int sys_admin_id)
        {
            this.dal.Delete(sys_admin_id);
        }

        public bool Exists(int sys_admin_id)
        {
            return this.dal.Exists(sys_admin_id);
        }

        public bool Exists(string sAdminName)
        {
            return this.dal.Exists(sAdminName);
        }

        public bool Exists(int iAdminID, string sAdminName)
        {
            return this.dal.Exists(iAdminID, sAdminName);
        }

        public DataSet GetList(int sys_admin_id, string sys_admin_name, bool isInit)
        {
            return this.dal.GetList(sys_admin_id, sys_admin_name, isInit);
        }

        public int GetMaxId()
        {
            return this.dal.GetMaxId();
        }

        public GoldTradeNaming.Model.goldtrade_db_admin GetModel(int sys_admin_id)
        {
            return this.dal.GetModel(sys_admin_id);
        }

        public GoldTradeNaming.Model.goldtrade_db_admin GetModelByCache(int sys_admin_id)
        {
            string CacheKey = "goldtrade_db_adminModel-" + sys_admin_id;
            object objModel = DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = this.dal.GetModel(sys_admin_id);
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
            return (GoldTradeNaming.Model.goldtrade_db_admin) objModel;
        }

        public bool IA100InUsed(Guid sIA100GUID)
        {
            return this.dal.IA100InUsed(sIA100GUID);
        }

        public bool IA100InUsed(int iAdminID, Guid sIA100GUID)
        {
            return this.dal.IA100InUsed(iAdminID, sIA100GUID);
        }

        public void Update(GoldTradeNaming.Model.goldtrade_db_admin model)
        {
            this.dal.Update(model);
        }
    }
}
