namespace GoldTradeNaming.BLL
{
    using GoldTradeNaming.DAL;
    using GoldTradeNaming.Model;
    using LTP.Common;
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class send_desc
    {
        private readonly GoldTradeNaming.DAL.send_desc dal = new GoldTradeNaming.DAL.send_desc();

        public int Add(GoldTradeNaming.Model.send_desc model)
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

        public string getFranName(string fran_id)
        {
            return this.dal.getFranName(fran_id);
        }

        public DataSet GetList(string strWhere)
        {
            return this.dal.GetList(strWhere);
        }

        public int GetMaxId()
        {
            return this.dal.GetMaxId();
        }

        public GoldTradeNaming.Model.send_desc GetModel(int id)
        {
            return this.dal.GetModel(id);
        }

        public GoldTradeNaming.Model.send_desc GetModelByCache(int id)
        {
            string CacheKey = "send_descModel-" + id;
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
            return (GoldTradeNaming.Model.send_desc) objModel;
        }

        public List<GoldTradeNaming.Model.send_desc> GetModelList(string strWhere)
        {
            DataSet ds = this.dal.GetList(strWhere);
            List<GoldTradeNaming.Model.send_desc> modelList = new List<GoldTradeNaming.Model.send_desc>();
            int rowsCount = ds.Tables[0].Rows.Count;
            if (rowsCount > 0)
            {
                for (int n = 0; n < rowsCount; n++)
                {
                    GoldTradeNaming.Model.send_desc model = new GoldTradeNaming.Model.send_desc();
                    if (ds.Tables[0].Rows[n]["id"].ToString() != "")
                    {
                        model.id = int.Parse(ds.Tables[0].Rows[n]["id"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["send_id"].ToString() != "")
                    {
                        model.send_id = int.Parse(ds.Tables[0].Rows[n]["send_id"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["product_id"].ToString() != "")
                    {
                        model.product_id = int.Parse(ds.Tables[0].Rows[n]["product_id"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["product_spec_id"].ToString() != "")
                    {
                        model.product_spec_id = int.Parse(ds.Tables[0].Rows[n]["product_spec_id"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["send_amount_weight"].ToString() != "")
                    {
                        model.send_amount_weight = int.Parse(ds.Tables[0].Rows[n]["send_amount_weight"].ToString());
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

        public DataSet GetProdcut()
        {
            return this.dal.GetProdcut();
        }

        public string getSendAmountWeight(string send_id)
        {
            return this.dal.getSendAmountWeight(send_id);
        }

        public DataSet getSendDesc(string send_id)
        {
            return this.dal.getSendDesc(send_id);
        }

        public void Update(GoldTradeNaming.Model.send_desc model)
        {
            this.dal.Update(model);
        }
    }
}
