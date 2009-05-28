using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using GoldTradeNaming.Model;
namespace GoldTradeNaming.BLL
{
    /// <summary>
    /// 业务逻辑类franchiser_trade 的摘要说明。
    /// </summary>
    public class franchiser_trade
    {
        private readonly GoldTradeNaming.DAL.franchiser_trade dal = new GoldTradeNaming.DAL.franchiser_trade();
        public franchiser_trade()
        {
        }
        #region  成员方法

        /// <summary>
        /// 查询某天交易数 by yuxiaowei for TJ
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public int TradeCount(DateTime dt)
        {
            return dal.TradeCount(dt);
        }
        /// <summary>
        /// 获得最新交易时间  by yuxiaowei
        /// </summary>
        /// <returns></returns>
        public DataSet GetTradetime()
        {
            return dal.GetTradetime();
        }

        /// <summary>
        /// 限制交易时间  byyuxiaowei
        /// </summary>
        /// <param name="dtFrom"></param>
        /// <param name="dtTo"></param>
        /// <param name="ins_user"></param>
        public int SetTradeTime(DateTime dtFrom,DateTime dtTo,string ins_user)
        {
            return dal.SetTradeTime(dtFrom,dtTo,ins_user);
        }

        /// <summary>
        ///  管理员 获得交易列表
        /// </summary>
        public DataSet GetTradeByM(string strWhere)
        {
            return dal.GetTradeByM(strWhere);
        }

        /// <summary>
        /// 管理员 确认交易取消
        /// </summary>
        /// <param name="trade_id"></param>
        /// <param name="franchiser_code"></param>
        /// <returns></returns>
        //public int ConfirmCancle(string trade_id, string franchiser_code)
        //{
        //    return dal.ConfirmCancle(trade_id, franchiser_code);
        //}

        /// <summary>
        /// 供应商取消交易 by yuxiaowei
        /// </summary>
        /// <param name="franchiser_trade"></param>
        /// <returns></returns>
        //public int CancleTradeInfo(string trade_id, string reason)
        //{
        //    return dal.CancleTradeInfo(trade_id, reason);
        //}

        /// <summary>
        /// 增加交易记录 by yuxiaowei
        /// </summary>
        /// <param name="prInfos"></param>
        /// <param name="trInfo"></param>
        /// <param name="iType">0黄金 1白银</param>
        /// <returns></returns>
        public bool AddTrandeInfo(List<ProductInfo> prInfos,TradeInfo trInfo,string iType)
        {
            return dal.AddTrandeInfo(prInfos,trInfo,iType);
        }

        /// <summary>
        /// 获取交易记录 经销商  by yuxiaowei
        /// </summary>
        /// <param name="franchiser_code"></param>
        /// <param name="trade_id"></param>
        /// <param name="dtFrom"></param>
        /// <param name="dtTo"></param>
        /// <param name="isInit">是否第一次进入页面</param>
        /// <returns></returns>
        public DataSet GetAllTrade(int franchiser_code,int trade_id,DateTime dtFrom,DateTime dtTo,bool isInit)
        {
            return dal.GetAllTrade(franchiser_code,trade_id,dtFrom,dtTo,isInit);
        }
        //public DataSet GetAllTrade(string franchiser_code, string trade_id, DateTime dtFrom, DateTime dtTo, bool isInit)
        //{
        //    return dal.GetAllTrade(franchiser_code, trade_id, dtFrom, dtTo, isInit);
        //}
        /// <summary>
        /// 获取交易详细记录  by yuxiaowei
        /// </summary>
        public DataSet GetTradeDesc(string trade_id)
        {
            return dal.GetTradeDesc(trade_id);
        }
        /// <summary>
        ///  库存中重量 by yuxiaowei
        /// </summary>
        /// <param name="franchiser_code"></param>
        /// <returns></returns>
        public DataSet GetLeftStock(string franchiser_code)
        {
            return dal.GetLeftStock(franchiser_code);
        }

        public DataSet GetTradeAdd(string product_id)
        {
            return dal.GetTradeAdd(product_id);
        }
        /// <summary>
        /// 获得经销商各类已定货但未收货的价格（库存*（金价*销售加价）） //黄金
        /// </summary>
        /// <param name="franchiser_code"></param>
        /// <returns></returns>
        public decimal GetGoldNoReceiveValue(string franchiser_code)
        {
            return dal.GetGoldNoReceiveValue(franchiser_code);
        }
        /// <summary>
        /// 获得经销商各类已定货但未收货的价格（库存*固定价格） //白银
        /// </summary>
        /// <param name="franchiser_code"></param>
        /// <returns></returns>
        public decimal GetSilverNoReceiveValue(string franchiser_code)
        {
            return dal.GetSilverNoReceiveValue(franchiser_code);
        }
        /// <summary>
        /// 获得经销商库存货物的价值 //黄金
        /// </summary>
        /// <param name="franchiser_code"></param>
        /// <returns></returns>
        public decimal GetGoldStockValue(string franchiser_code)
        {
            return dal.GetGoldStockValue(franchiser_code);
        }
        /// <summary>
        /// 获得经销商库存货物的价值 //白银
        /// </summary>
        /// <param name="franchiser_code"></param>
        /// <returns></returns>
        public decimal GetSilverStockValue(string franchiser_code)
        {
            return dal.GetSilverStockValue(franchiser_code);
        }
        /// <summary>
        /// 获得已定货但未收货的总重量  //黄金
        /// 订单号 产品类别号 未收货重量 订购加价
        /// franchiser_order_id  product_id count order_add_price
        /// </summary>
        /// <returns></returns>
        public DataSet GetGoldNoReceive(string franchiser_code)
        {
            return dal.GetGoldNoReceive(franchiser_code);
        }
        /// <summary>
        /// 获得产品库存列别 金块 by yuxiaowei
        /// </summary>
        public DataSet GetGoldStock(string franchiser_code)
        {
            return dal.GetGoldStock(franchiser_code);
        }
        /// <summary>
        /// 获得产品库存列别 白银 by yuxiaowei
        /// </summary>
        public DataSet GetSilverStock(string franchiser_code)
        {
            return dal.GetSilverStock(franchiser_code);
        }
        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return dal.GetMaxId();
        }
        /// <summary>
        /// 获得经销商数据列表
        /// </summary>
        public DataSet GetFranList(string strWhere)
        {
            return dal.GetFranList(strWhere);
        }
        /// <summary>
        /// 获得最新金价价格 add by yuxiaowei
        /// </summary>
        public DataSet getCurrentPrice()
        {
            return dal.getCurrentPrice();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int trade_id)
        {
            return dal.Exists(trade_id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(GoldTradeNaming.Model.franchiser_trade model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(GoldTradeNaming.Model.franchiser_trade model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int trade_id)
        {

            dal.Delete(trade_id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public GoldTradeNaming.Model.franchiser_trade GetModel(int trade_id)
        {

            return dal.GetModel(trade_id);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中。
        /// </summary>
        public GoldTradeNaming.Model.franchiser_trade GetModelByCache(int trade_id)
        {

            string CacheKey = "franchiser_tradeModel-" + trade_id;
            object objModel = LTP.Common.DataCache.GetCache(CacheKey);
            if(objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(trade_id);
                    if(objModel != null)
                    {
                        int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
                        LTP.Common.DataCache.SetCache(CacheKey,objModel,DateTime.Now.AddMinutes(ModelCache),TimeSpan.Zero);
                    }
                }
                catch
                {
                }
            }
            return (GoldTradeNaming.Model.franchiser_trade)objModel;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<GoldTradeNaming.Model.franchiser_trade> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            List<GoldTradeNaming.Model.franchiser_trade> modelList = new List<GoldTradeNaming.Model.franchiser_trade>();
            int rowsCount = ds.Tables[0].Rows.Count;
            if(rowsCount > 0)
            {
                GoldTradeNaming.Model.franchiser_trade model;
                for(int n = 0;n < rowsCount;n++)
                {
                    model = new GoldTradeNaming.Model.franchiser_trade();
                    if(ds.Tables[0].Rows[n]["trade_id"].ToString() != "")
                    {
                        model.trade_id = int.Parse(ds.Tables[0].Rows[n]["trade_id"].ToString());
                    }
                    if(ds.Tables[0].Rows[n]["franchiser_code"].ToString() != "")
                    {
                        model.franchiser_code = int.Parse(ds.Tables[0].Rows[n]["franchiser_code"].ToString());
                    }
                    if(ds.Tables[0].Rows[n]["trade_time"].ToString() != "")
                    {
                        model.trade_time = DateTime.Parse(ds.Tables[0].Rows[n]["trade_time"].ToString());
                    }
                    if(ds.Tables[0].Rows[n]["realtime_base_price"].ToString() != "")
                    {
                        model.realtime_base_price = decimal.Parse(ds.Tables[0].Rows[n]["realtime_base_price"].ToString());
                    }
                    if(ds.Tables[0].Rows[n]["gold_trade_price"].ToString() != "")
                    {
                        model.gold_trade_price = decimal.Parse(ds.Tables[0].Rows[n]["gold_trade_price"].ToString());
                    }
                    if(ds.Tables[0].Rows[n]["trade_add_price"].ToString() != "")
                    {
                        model.trade_add_price = decimal.Parse(ds.Tables[0].Rows[n]["trade_add_price"].ToString());
                    }
                    if(ds.Tables[0].Rows[n]["trade_total_weight"].ToString() != "")
                    {
                        model.trade_total_weight = int.Parse(ds.Tables[0].Rows[n]["trade_total_weight"].ToString());
                    }
                    if(ds.Tables[0].Rows[n]["trade_total_money"].ToString() != "")
                    {
                        model.trade_total_money = decimal.Parse(ds.Tables[0].Rows[n]["trade_total_money"].ToString());
                    }
                    model.canceled_reason = ds.Tables[0].Rows[n]["canceled_reason"].ToString();
                    model.trade_state = ds.Tables[0].Rows[n]["trade_state"].ToString();
                    model.ins_user = ds.Tables[0].Rows[n]["ins_user"].ToString();
                    if(ds.Tables[0].Rows[n]["ins_date"].ToString() != "")
                    {
                        model.ins_date = DateTime.Parse(ds.Tables[0].Rows[n]["ins_date"].ToString());
                    }
                    model.upd_user = ds.Tables[0].Rows[n]["upd_user"].ToString();
                    if(ds.Tables[0].Rows[n]["upd_date"].ToString() != "")
                    {
                        model.upd_date = DateTime.Parse(ds.Tables[0].Rows[n]["upd_date"].ToString());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  成员方法
    }
}

