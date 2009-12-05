namespace GoldTradeNaming.BLL
{
    using GoldTradeNaming.DAL;
    using GoldTradeNaming.Model;
    using LTP.Common;
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class franchiser_order_desc
    {
        private readonly GoldTradeNaming.DAL.franchiser_order_desc dal = new GoldTradeNaming.DAL.franchiser_order_desc();

        public int Add(GoldTradeNaming.Model.franchiser_order_desc model)
        {
            return this.dal.Add(model);
        }

        public void Delete(int id)
        {
            this.dal.Delete(id);
        }

        public bool Exists(int id)
        {
            return this.dal.Exists(id);
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

        public GoldTradeNaming.Model.franchiser_order_desc GetModel(int id)
        {
            return this.dal.GetModel(id);
        }

        public GoldTradeNaming.Model.franchiser_order_desc GetModelByCache(int id)
        {
            string CacheKey = "franchiser_order_descModel-" + id;
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
            return (GoldTradeNaming.Model.franchiser_order_desc) objModel;
        }

        public List<GoldTradeNaming.Model.franchiser_order_desc> GetModelList(string strWhere)
        {
            DataSet ds = this.dal.GetList(strWhere);
            List<GoldTradeNaming.Model.franchiser_order_desc> modelList = new List<GoldTradeNaming.Model.franchiser_order_desc>();
            int rowsCount = ds.Tables[0].Rows.Count;
            if (rowsCount > 0)
            {
                for (int n = 0; n < rowsCount; n++)
                {
                    GoldTradeNaming.Model.franchiser_order_desc model = new GoldTradeNaming.Model.franchiser_order_desc();
                    if (ds.Tables[0].Rows[n]["id"].ToString() != "")
                    {
                        model.id = int.Parse(ds.Tables[0].Rows[n]["id"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["franchiser_order_id"].ToString() != "")
                    {
                        model.franchiser_order_id = int.Parse(ds.Tables[0].Rows[n]["franchiser_order_id"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["product_id"].ToString() != "")
                    {
                        model.product_id = int.Parse(ds.Tables[0].Rows[n]["product_id"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["product_spec_id"].ToString() != "")
                    {
                        model.product_spec_id = int.Parse(ds.Tables[0].Rows[n]["product_spec_id"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["order_product_amount"].ToString() != "")
                    {
                        model.order_product_amount = int.Parse(ds.Tables[0].Rows[n]["order_product_amount"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["product_received"].ToString() != "")
                    {
                        model.product_received = int.Parse(ds.Tables[0].Rows[n]["product_received"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["product_unreceived"].ToString() != "")
                    {
                        model.product_unreceived = int.Parse(ds.Tables[0].Rows[n]["product_unreceived"].ToString());
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

        public void Update(GoldTradeNaming.Model.franchiser_order_desc model)
        {
            this.dal.Update(model);
        }
    }
}
