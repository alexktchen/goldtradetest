namespace GoldTradeNaming.BLL
{
    using GoldTradeNaming.DAL;
    using GoldTradeNaming.Model;
    using LTP.Common;
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class send_main
    {
        private readonly GoldTradeNaming.DAL.send_main dal = new GoldTradeNaming.DAL.send_main();

        public int Add(GoldTradeNaming.Model.send_main model)
        {
            return this.dal.Add(model);
        }

        public int CancelSend(GoldTradeNaming.Model.send_main s)
        {
            return this.dal.CancelSend(s);
        }

        public bool ConfirmReceive(int franId, int OrderId, int SendId)
        {
            return this.dal.ConfirmReceive(franId, OrderId, SendId);
        }

        public void Delete(int send_id)
        {
            this.dal.Delete(send_id);
        }

        public bool Exists(int send_id)
        {
            return this.dal.Exists(send_id);
        }

        public DataSet GetAllList()
        {
            return this.GetList("");
        }

        public DataSet GetList(string strWhere)
        {
            return this.dal.GetList(strWhere);
        }

        public DataSet GetListByFranID(string strWhere)
        {
            return this.dal.GetListByFranID(strWhere);
        }

        public int GetMaxId()
        {
            return this.dal.GetMaxId();
        }

        public GoldTradeNaming.Model.send_main GetModel(int send_id)
        {
            return this.dal.GetModel(send_id);
        }

        public GoldTradeNaming.Model.send_main GetModelByCache(int send_id)
        {
            string CacheKey = "send_mainModel-" + send_id;
            object objModel = DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = this.dal.GetModel(send_id);
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
            return (GoldTradeNaming.Model.send_main) objModel;
        }

        public List<GoldTradeNaming.Model.send_main> GetModelList(string strWhere)
        {
            DataSet ds = this.dal.GetList(strWhere);
            List<GoldTradeNaming.Model.send_main> modelList = new List<GoldTradeNaming.Model.send_main>();
            int rowsCount = ds.Tables[0].Rows.Count;
            if (rowsCount > 0)
            {
                for (int n = 0; n < rowsCount; n++)
                {
                    GoldTradeNaming.Model.send_main model = new GoldTradeNaming.Model.send_main();
                    if (ds.Tables[0].Rows[n]["send_id"].ToString() != "")
                    {
                        model.send_id = int.Parse(ds.Tables[0].Rows[n]["send_id"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["franchiser_order_id"].ToString() != "")
                    {
                        model.franchiser_order_id = int.Parse(ds.Tables[0].Rows[n]["franchiser_order_id"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["send_time"].ToString() != "")
                    {
                        model.send_time = DateTime.Parse(ds.Tables[0].Rows[n]["send_time"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["send_amount_weight"].ToString() != "")
                    {
                        model.send_amount_weight = int.Parse(ds.Tables[0].Rows[n]["send_amount_weight"].ToString());
                    }
                    model.send_state = ds.Tables[0].Rows[n]["send_state"].ToString();
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
                    model.canceled_reason = ds.Tables[0].Rows[n]["canceled_reason"].ToString();
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        public DataSet GetOrderedProductList(string strWhere)
        {
            return this.dal.GetOrderedProductList(strWhere);
        }

        public DataSet GetOrderInfo(string strWhere)
        {
            return this.dal.GetOrderInfo(strWhere);
        }

        public DataSet GetSendInfo(string where)
        {
            return this.dal.GetSendInfo(where);
        }

        public bool SaveSendInfo(GoldTradeNaming.Model.send_main sm, List<GoldTradeNaming.Model.send_desc> sdlst)
        {
            return this.dal.SaveSendInfo(sm, sdlst);
        }

        public void Update(GoldTradeNaming.Model.send_main model)
        {
            this.dal.Update(model);
        }
    }
}
