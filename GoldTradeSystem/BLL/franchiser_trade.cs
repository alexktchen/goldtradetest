using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using GoldTradeNaming.Model;
namespace GoldTradeNaming.BLL
{
    /// <summary>
    /// ҵ���߼���franchiser_trade ��ժҪ˵����
    /// </summary>
    public class franchiser_trade
    {
        private readonly GoldTradeNaming.DAL.franchiser_trade dal = new GoldTradeNaming.DAL.franchiser_trade();
        public franchiser_trade()
        {
        }
        #region  ��Ա����

        /// <summary>
        /// ��ѯĳ�콻���� by yuxiaowei for TJ
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public int TradeCount(DateTime dt)
        {
            return dal.TradeCount(dt);
        }
        /// <summary>
        /// ������½���ʱ��  by yuxiaowei
        /// </summary>
        /// <returns></returns>
        public DataSet GetTradetime()
        {
            return dal.GetTradetime();
        }

        /// <summary>
        /// ���ƽ���ʱ��  byyuxiaowei
        /// </summary>
        /// <param name="dtFrom"></param>
        /// <param name="dtTo"></param>
        /// <param name="ins_user"></param>
        public int SetTradeTime(DateTime dtFrom,DateTime dtTo,string ins_user)
        {
            return dal.SetTradeTime(dtFrom,dtTo,ins_user);
        }

        /// <summary>
        ///  ����Ա ��ý����б�
        /// </summary>
        public DataSet GetTradeByM(string strWhere)
        {
            return dal.GetTradeByM(strWhere);
        }

        /// <summary>
        /// ����Ա ȷ�Ͻ���ȡ��
        /// </summary>
        /// <param name="trade_id"></param>
        /// <param name="franchiser_code"></param>
        /// <returns></returns>
        //public int ConfirmCancle(string trade_id, string franchiser_code)
        //{
        //    return dal.ConfirmCancle(trade_id, franchiser_code);
        //}

        /// <summary>
        /// ��Ӧ��ȡ������ by yuxiaowei
        /// </summary>
        /// <param name="franchiser_trade"></param>
        /// <returns></returns>
        //public int CancleTradeInfo(string trade_id, string reason)
        //{
        //    return dal.CancleTradeInfo(trade_id, reason);
        //}

        /// <summary>
        /// ���ӽ��׼�¼ by yuxiaowei
        /// </summary>
        /// <param name="prInfos"></param>
        /// <param name="trInfo"></param>
        /// <param name="iType">0�ƽ� 1����</param>
        /// <returns></returns>
        public bool AddTrandeInfo(List<ProductInfo> prInfos,TradeInfo trInfo,string iType)
        {
            return dal.AddTrandeInfo(prInfos,trInfo,iType);
        }

        /// <summary>
        /// ��ȡ���׼�¼ ������  by yuxiaowei
        /// </summary>
        /// <param name="franchiser_code"></param>
        /// <param name="trade_id"></param>
        /// <param name="dtFrom"></param>
        /// <param name="dtTo"></param>
        /// <param name="isInit">�Ƿ��һ�ν���ҳ��</param>
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
        /// ��ȡ������ϸ��¼  by yuxiaowei
        /// </summary>
        public DataSet GetTradeDesc(string trade_id)
        {
            return dal.GetTradeDesc(trade_id);
        }
        /// <summary>
        ///  ��������� by yuxiaowei
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
        /// ��þ����̸����Ѷ�����δ�ջ��ļ۸񣨿��*�����*���ۼӼۣ��� //�ƽ�
        /// </summary>
        /// <param name="franchiser_code"></param>
        /// <returns></returns>
        public decimal GetGoldNoReceiveValue(string franchiser_code)
        {
            return dal.GetGoldNoReceiveValue(franchiser_code);
        }
        /// <summary>
        /// ��þ����̸����Ѷ�����δ�ջ��ļ۸񣨿��*�̶��۸� //����
        /// </summary>
        /// <param name="franchiser_code"></param>
        /// <returns></returns>
        public decimal GetSilverNoReceiveValue(string franchiser_code)
        {
            return dal.GetSilverNoReceiveValue(franchiser_code);
        }
        /// <summary>
        /// ��þ����̿�����ļ�ֵ //�ƽ�
        /// </summary>
        /// <param name="franchiser_code"></param>
        /// <returns></returns>
        public decimal GetGoldStockValue(string franchiser_code)
        {
            return dal.GetGoldStockValue(franchiser_code);
        }
        /// <summary>
        /// ��þ����̿�����ļ�ֵ //����
        /// </summary>
        /// <param name="franchiser_code"></param>
        /// <returns></returns>
        public decimal GetSilverStockValue(string franchiser_code)
        {
            return dal.GetSilverStockValue(franchiser_code);
        }
        /// <summary>
        /// ����Ѷ�����δ�ջ���������  //�ƽ�
        /// ������ ��Ʒ���� δ�ջ����� �����Ӽ�
        /// franchiser_order_id  product_id count order_add_price
        /// </summary>
        /// <returns></returns>
        public DataSet GetGoldNoReceive(string franchiser_code)
        {
            return dal.GetGoldNoReceive(franchiser_code);
        }
        /// <summary>
        /// ��ò�Ʒ����б� ��� by yuxiaowei
        /// </summary>
        public DataSet GetGoldStock(string franchiser_code)
        {
            return dal.GetGoldStock(franchiser_code);
        }
        /// <summary>
        /// ��ò�Ʒ����б� ���� by yuxiaowei
        /// </summary>
        public DataSet GetSilverStock(string franchiser_code)
        {
            return dal.GetSilverStock(franchiser_code);
        }
        /// <summary>
        /// �õ����ID
        /// </summary>
        public int GetMaxId()
        {
            return dal.GetMaxId();
        }
        /// <summary>
        /// ��þ����������б�
        /// </summary>
        public DataSet GetFranList(string strWhere)
        {
            return dal.GetFranList(strWhere);
        }
        /// <summary>
        /// ������½�ۼ۸� add by yuxiaowei
        /// </summary>
        public DataSet getCurrentPrice()
        {
            return dal.getCurrentPrice();
        }

        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int trade_id)
        {
            return dal.Exists(trade_id);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(GoldTradeNaming.Model.franchiser_trade model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public void Update(GoldTradeNaming.Model.franchiser_trade model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public void Delete(int trade_id)
        {

            dal.Delete(trade_id);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public GoldTradeNaming.Model.franchiser_trade GetModel(int trade_id)
        {

            return dal.GetModel(trade_id);
        }

        /// <summary>
        /// �õ�һ������ʵ�壬�ӻ����С�
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
        /// ��������б�
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// ��������б�
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
        /// ��������б�
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  ��Ա����
    }
}

