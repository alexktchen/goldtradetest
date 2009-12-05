namespace GoldTradeNaming.BLL
{
    using GoldTradeNaming.DAL;
    using GoldTradeNaming.Model;
    using LTP.Common;
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class product_type
    {
        private readonly GoldTradeNaming.DAL.product_type dal = new GoldTradeNaming.DAL.product_type();

        public int Add(GoldTradeNaming.Model.product_type model)
        {
            return this.dal.Add(model);
        }

        public string check_id(string product_type_id)
        {
            return this.dal.check_id(product_type_id);
        }

        public string check_name(string product_type_name)
        {
            return this.dal.check_name(product_type_name);
        }

        public void Delete(int product_type_id, int product_spec_weight)
        {
            this.dal.Delete(product_type_id, product_spec_weight);
        }

        public bool Exists(int product_type_id, decimal product_spec_weight)
        {
            return this.dal.Exists(product_type_id, product_spec_weight);
        }

        public DataSet getAll(string type)
        {
            return this.dal.getAll(type);
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

        public GoldTradeNaming.Model.product_type GetModel(int product_type_id, int product_spec_weight)
        {
            return this.dal.GetModel(product_type_id, product_spec_weight);
        }

        public GoldTradeNaming.Model.product_type GetModelByCache(int product_type_id, int product_spec_weight)
        {
            string CacheKey = "product_typeModel-" + product_type_id + product_spec_weight;
            object objModel = DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = this.dal.GetModel(product_type_id, product_spec_weight);
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
            return (GoldTradeNaming.Model.product_type) objModel;
        }

        public List<GoldTradeNaming.Model.product_type> GetModelList(string strWhere)
        {
            DataSet ds = this.dal.GetList(strWhere);
            List<GoldTradeNaming.Model.product_type> modelList = new List<GoldTradeNaming.Model.product_type>();
            int rowsCount = ds.Tables[0].Rows.Count;
            if (rowsCount > 0)
            {
                for (int n = 0; n < rowsCount; n++)
                {
                    GoldTradeNaming.Model.product_type model = new GoldTradeNaming.Model.product_type();
                    if (ds.Tables[0].Rows[n]["product_type_id"].ToString() != "")
                    {
                        model.product_type_id = int.Parse(ds.Tables[0].Rows[n]["product_type_id"].ToString());
                    }
                    model.product_type_name = ds.Tables[0].Rows[n]["product_type_name"].ToString();
                    if (ds.Tables[0].Rows[n]["product_spec_weight"].ToString() != "")
                    {
                        model.product_spec_weight = int.Parse(ds.Tables[0].Rows[n]["product_spec_weight"].ToString());
                    }
                    model.product_state = ds.Tables[0].Rows[n]["product_state"].ToString();
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

        public DataSet getSilver()
        {
            return this.dal.getSilver();
        }

        public DataSet queryAction(string type_id, string type_name, string type_kind, string type_status, string order_add_price, string trade_add_price, string type)
        {
            DataSet ds;
            try
            {
                ds = this.dal.queryAction(type_id, type_name, type_kind, type_status, order_add_price, trade_add_price, type);
            }
            catch
            {
                throw;
            }
            return ds;
        }

        public void Update(GoldTradeNaming.Model.product_type model)
        {
            try
            {
                this.dal.Update(model);
            }
            catch
            {
                throw;
            }
        }
    }
}
