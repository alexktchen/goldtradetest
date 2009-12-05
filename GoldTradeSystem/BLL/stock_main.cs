namespace GoldTradeNaming.BLL
{
    using GoldTradeNaming.DAL;
    using GoldTradeNaming.Model;
    using LTP.Common;
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class stock_main
    {
        private readonly GoldTradeNaming.DAL.stock_main dal = new GoldTradeNaming.DAL.stock_main();

        public int Add(GoldTradeNaming.Model.stock_main model)
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

        public string getAdMoeney()
        {
            return this.dal.getAddMoney();
        }

        public DataSet getAllInfoAboutM(string Fran_ID)
        {
            DataSet ds;
            try
            {
                ds = this.dal.getAllInfoAboutM(Fran_ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet GetAllList()
        {
            return this.GetList("");
        }

        public string getLeftMoney()
        {
            return this.dal.getLeftMoney();
        }

        public DataSet GetList(string strWhere)
        {
            return this.dal.GetList(strWhere);
        }

        public int GetMaxId()
        {
            return this.dal.GetMaxId();
        }

        public GoldTradeNaming.Model.stock_main GetModel(int id)
        {
            GoldTradeNaming.Model.stock_main temp;
            try
            {
                temp = this.dal.GetModel(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return temp;
        }

        public GoldTradeNaming.Model.stock_main GetModelByCache(int id)
        {
            string CacheKey = "stock_mainModel-" + id;
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
            return (GoldTradeNaming.Model.stock_main) objModel;
        }

        public List<GoldTradeNaming.Model.stock_main> GetModelList(string strWhere)
        {
            DataSet ds = this.dal.GetList(strWhere);
            List<GoldTradeNaming.Model.stock_main> modelList = new List<GoldTradeNaming.Model.stock_main>();
            int rowsCount = ds.Tables[0].Rows.Count;
            if (rowsCount > 0)
            {
                for (int n = 0; n < rowsCount; n++)
                {
                    GoldTradeNaming.Model.stock_main model = new GoldTradeNaming.Model.stock_main();
                    if (ds.Tables[0].Rows[n]["id"].ToString() != "")
                    {
                        model.id = int.Parse(ds.Tables[0].Rows[n]["id"].ToString());
                    }
                    model.franchiser_code = ds.Tables[0].Rows[n]["franchiser_code"].ToString();
                    if (ds.Tables[0].Rows[n]["product_id"].ToString() != "")
                    {
                        model.product_id = int.Parse(ds.Tables[0].Rows[n]["product_id"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["product_spec_id"].ToString() != "")
                    {
                        model.product_spec_id = int.Parse(ds.Tables[0].Rows[n]["product_spec_id"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["stock_total"].ToString() != "")
                    {
                        model.stock_total = int.Parse(ds.Tables[0].Rows[n]["stock_total"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["stock_left"].ToString() != "")
                    {
                        model.stock_left = int.Parse(ds.Tables[0].Rows[n]["stock_left"].ToString());
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

        public DataSet getSalesReprot(string time_from, string time_to)
        {
            return this.dal.getSalesReport(time_from, time_to);
        }

        public DataSet getStockModifyLog()
        {
            return this.dal.getStockModifyLog();
        }

        public string getTotalTrade()
        {
            return this.dal.getSumTrade();
        }

        public bool stock_chang(string fran_id, int product_type_id, decimal product_kind_id, int tag, int mount)
        {
            return this.dal.stock_chang(fran_id, product_type_id, product_kind_id, tag, mount);
        }

        public void Update(GoldTradeNaming.Model.stock_main model)
        {
            this.dal.Update(model);
        }

        public int updateStock(GoldTradeNaming.Model.stock_main model)
        {
            int returnValue = -2147483648;
            try
            {
                returnValue = this.dal.updateStock(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return returnValue;
        }

        public bool updateStock1(GoldTradeNaming.Model.stock_main model)
        {
            return this.dal.updateStock1(model);
        }
    }
}
