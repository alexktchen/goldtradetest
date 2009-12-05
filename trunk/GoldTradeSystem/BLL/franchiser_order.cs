namespace GoldTradeNaming.BLL
{
    using GoldTradeNaming.DAL;
    using GoldTradeNaming.Model;
    using LTP.Common;
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class franchiser_order
    {
        private readonly GoldTradeNaming.DAL.franchiser_order dal = new GoldTradeNaming.DAL.franchiser_order();

        public int Add(GoldTradeNaming.Model.franchiser_order model)
        {
            return this.dal.Add(model);
        }

        public bool ConfirmOrder(int franchiser_order_id, string upduser)
        {
            return this.dal.UpdateOrderState(franchiser_order_id, upduser);
        }

        public void Delete(int franchiser_order_id)
        {
            this.dal.Delete(franchiser_order_id);
        }

        public bool Exists(int franchiser_order_id)
        {
            return this.dal.Exists(franchiser_order_id);
        }

        public DataSet GetAllList()
        {
            return this.GetList("");
        }

        public DataSet GetGoldProduct()
        {
            return this.dal.GetGoldProduct();
        }

        public GoldTradeNaming.Model.franchiser_info GetInfortModel(int franchiser_code)
        {
            return this.dal.GetInforModel(franchiser_code);
        }

        public DataSet GetLatestList(int franID)
        {
            return this.dal.GetLatestList(franID);
        }

        public DataSet GetList(string strWhere)
        {
            return this.dal.GetList(strWhere);
        }

        public int GetMaxId()
        {
            return this.dal.GetMaxId();
        }

        public GoldTradeNaming.Model.franchiser_order GetModel(int franchiser_order_id)
        {
            return this.dal.GetModel(franchiser_order_id);
        }

        public GoldTradeNaming.Model.franchiser_order GetModelByCache(int franchiser_order_id)
        {
            string CacheKey = "franchiser_orderModel-" + franchiser_order_id;
            object objModel = DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = this.dal.GetModel(franchiser_order_id);
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
            return (GoldTradeNaming.Model.franchiser_order) objModel;
        }

        public List<GoldTradeNaming.Model.franchiser_order> GetModelList(string strWhere)
        {
            DataSet ds = this.dal.GetList(strWhere);
            List<GoldTradeNaming.Model.franchiser_order> modelList = new List<GoldTradeNaming.Model.franchiser_order>();
            int rowsCount = ds.Tables[0].Rows.Count;
            if (rowsCount > 0)
            {
                for (int n = 0; n < rowsCount; n++)
                {
                    GoldTradeNaming.Model.franchiser_order model = new GoldTradeNaming.Model.franchiser_order();
                    if (ds.Tables[0].Rows[n]["franchiser_order_id"].ToString() != "")
                    {
                        model.franchiser_order_id = int.Parse(ds.Tables[0].Rows[n]["franchiser_order_id"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["franchiser_code"].ToString() != "")
                    {
                        model.franchiser_code = int.Parse(ds.Tables[0].Rows[n]["franchiser_code"].ToString());
                    }
                    model.franchiser_order_trans_type = ds.Tables[0].Rows[n]["franchiser_order_trans_type"].ToString();
                    model.franchiser_order_address = ds.Tables[0].Rows[n]["franchiser_order_address"].ToString();
                    model.franchiser_order_postcode = ds.Tables[0].Rows[n]["franchiser_order_postcode"].ToString();
                    model.franchiser_order_handle_man = ds.Tables[0].Rows[n]["franchiser_order_handle_man"].ToString();
                    model.franchiser_order_handle_tel = ds.Tables[0].Rows[n]["franchiser_order_handle_tel"].ToString();
                    model.franchiser_order_handle_phone = ds.Tables[0].Rows[n]["franchiser_order_handle_phone"].ToString();
                    if (ds.Tables[0].Rows[n]["franchiser_order_price"].ToString() != "")
                    {
                        model.franchiser_order_price = decimal.Parse(ds.Tables[0].Rows[n]["franchiser_order_price"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["franchiser_order_add_price"].ToString() != "")
                    {
                        model.franchiser_order_add_price = decimal.Parse(ds.Tables[0].Rows[n]["franchiser_order_add_price"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["franchiser_order_appraise"].ToString() != "")
                    {
                        model.franchiser_order_appraise = decimal.Parse(ds.Tables[0].Rows[n]["franchiser_order_appraise"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["franchiser_order_time"].ToString() != "")
                    {
                        model.franchiser_order_time = DateTime.Parse(ds.Tables[0].Rows[n]["franchiser_order_time"].ToString());
                    }
                    model.franchiser_order_state = ds.Tables[0].Rows[n]["franchiser_order_state"].ToString();
                    if (ds.Tables[0].Rows[n]["franchiser_order_amount_money"].ToString() != "")
                    {
                        model.franchiser_order_amount_money = decimal.Parse(ds.Tables[0].Rows[n]["franchiser_order_amount_money"].ToString());
                    }
                    model.canceled_reason = ds.Tables[0].Rows[n]["canceled_reason"].ToString();
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

        public DataSet GetOrderInfo(string strWhere)
        {
            return this.dal.GetOrderInfo(strWhere);
        }

        public DataSet getproduct_spec(string product_name)
        {
            return this.dal.getproduct_spec(product_name);
        }

        public DataSet GetProductList()
        {
            return this.dal.GetProductList();
        }

        public DataSet GetSilverProduct()
        {
            return this.dal.GetSilverProduct();
        }

        public bool SaveOrderInfo(GoldTradeNaming.Model.franchiser_order model, List<GoldTradeNaming.Model.franchiser_order_desc> orderlst)
        {
            return this.dal.SaveOrderInfo(model, orderlst);
        }

        public void Update(GoldTradeNaming.Model.franchiser_order model)
        {
            this.dal.Update(model);
        }

        public void updateInfor(GoldTradeNaming.Model.franchiser_info model)
        {
            this.dal.updateInfor(model);
        }

        public int UpdateOrderInfo(GoldTradeNaming.Model.franchiser_order model)
        {
            return this.dal.UpdateOrderInfo(model);
        }
    }
}
