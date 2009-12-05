namespace GoldTradeNaming.BLL
{
    using GoldTradeNaming.DAL;
    using GoldTradeNaming.Model;
    using LTP.Common;
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class franchiser_money
    {
        private readonly GoldTradeNaming.DAL.franchiser_money dal = new GoldTradeNaming.DAL.franchiser_money();

        public int Add(GoldTradeNaming.Model.franchiser_money model)
        {
            return this.dal.Add(model);
        }

        public int Delete(int id)
        {
            return this.dal.Delete(id);
        }

        public bool Exists(int id)
        {
            return this.dal.Exists(id);
        }

        public bool fran_id_exists(int fran_id)
        {
            return this.dal.fran_id_exists(fran_id);
        }

        public decimal GetAddMoneyTotal(int fran_id)
        {
            return this.dal.GetAddMoneyTotal(fran_id);
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

        public GoldTradeNaming.Model.franchiser_money GetModel(int id)
        {
            return this.dal.GetModel(id);
        }

        public GoldTradeNaming.Model.franchiser_money GetModelByCache(int id)
        {
            string CacheKey = "franchiser_moneyModel-" + id;
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
            return (GoldTradeNaming.Model.franchiser_money) objModel;
        }

        public List<GoldTradeNaming.Model.franchiser_money> GetModelList(string strWhere)
        {
            DataSet ds = this.dal.GetList(strWhere);
            List<GoldTradeNaming.Model.franchiser_money> modelList = new List<GoldTradeNaming.Model.franchiser_money>();
            int rowsCount = ds.Tables[0].Rows.Count;
            if (rowsCount > 0)
            {
                for (int n = 0; n < rowsCount; n++)
                {
                    GoldTradeNaming.Model.franchiser_money model = new GoldTradeNaming.Model.franchiser_money();
                    if (ds.Tables[0].Rows[n]["id"].ToString() != "")
                    {
                        model.id = int.Parse(ds.Tables[0].Rows[n]["id"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["franchiser_code"].ToString() != "")
                    {
                        model.franchiser_code = int.Parse(ds.Tables[0].Rows[n]["franchiser_code"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["franchiser_added_money"].ToString() != "")
                    {
                        model.franchiser_added_money = decimal.Parse(ds.Tables[0].Rows[n]["franchiser_added_money"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["added_time"].ToString() != "")
                    {
                        model.added_time = DateTime.Parse(ds.Tables[0].Rows[n]["added_time"].ToString());
                    }
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
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        public DataSet queryAction(string fran_id, string add_money, string time_from, string time_to)
        {
            return this.dal.queryAction(fran_id, add_money, time_from, time_to);
        }

        public DataSet queryAction(string fran_id, string add_money, string time_from, string time_to, string check, int tag)
        {
            return this.dal.queryAction(fran_id, add_money, time_from, time_to, check, tag);
        }

        public int Update(GoldTradeNaming.Model.franchiser_money model)
        {
            return this.dal.Update(model);
        }

        public int update_franchiser_info(int franchiser_code, decimal franchiser_balance_money, int tag)
        {
            return this.dal.update_franchiser_info(franchiser_code, franchiser_balance_money, tag);
        }
    }
}
