using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using GoldTradeNaming.Model;
using GoldTradeNaming.DAL;

namespace GoldTradeNaming.BLL
{
    public class CommBaseBLL
    {
        private CommBaseDAL dal;

        public CommBaseBLL()
        {
            this.dal = new CommBaseDAL();
        }

        /// <summary>
        /// 得到下一订单编号
        /// </summary>
        /// <returns></returns>
        public static int GetNextOrderId()
        {
            return CommBaseDAL.GetNextOrderId();
        }
        
        /// <summary>
        /// 得到下一交易编号
        /// </summary>
        /// <returns></returns>
        public static int GetNextTradeId()
        {
            return CommBaseDAL.GetNextTradeId();
        }

        public static string GetProductTypeById(string type_id)
        {
            return CommBaseDAL.GetProductTypeById(type_id);
        }

          /// <summary>
        /// 查询某经销商的订货总额
        /// </summary>
        /// <param name="franid">经销商编号</param>
        /// <returns></returns>
        public static decimal GetOrderSumByFranId(int franid)
        {
            return CommBaseDAL.GetOrderSumByFranId(franid);
        }

        /// <summary>
        /// 查询某经销商的交易总额
        /// </summary>
        /// <param name="franid">经销商编号</param>
        /// <returns></returns>
        public static decimal GetTradeSumByFranId(int franid)
        {
            return CommBaseDAL.GetTradeSumByFranId(franid);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        /// <summary>
        /// 查询某管理员是否有该模块的权限 by yuxiaowei
        /// </summary>
        /// <param name="sys_admin_id"></param>
        /// <param name="modelID"></param>
        /// <returns></returns>
        public static bool HasRight(int sys_admin_id, string modelID)
        {
            return CommBaseDAL.HasRight(sys_admin_id, modelID);
        }


        /// <summary> 
        /// 库存中重量 by yuxiaowei
        /// </summary>
        /// <param name="franchiser_code"></param>
        /// <returns></returns>
        public DataSet GetLeftStock(string franchiser_code)
        {
            return this.dal.GetLeftStock(franchiser_code);
        }

        /// <summary>
        /// 获得已定货但未收货的总重量 by yuxiaowei
        /// </summary>
        /// <returns></returns>
        public DataSet GetSumNoReceive(string franchiser_code)
        {
            return this.dal.GetSumNoReceive(franchiser_code);
        }

        /// <summary>
        /// 获得当前实时金价信息（金价，时间，添加人）
        /// </summary>
        public DataSet getCurrentPrice()
        {
            return this.dal.getCurrentPrice();
        }

        /// <summary>
        /// 得到经销商名称
        /// </summary>
        /// <param name="fran_code"></param>
        /// <returns></returns>
        public static string GetFranName(int fran_code)
        {
            GoldTradeNaming.BLL.franchiser_info bll = new franchiser_info();
            GoldTradeNaming.Model.franchiser_info franinfo = bll.GetModel(fran_code);
            return franinfo.franchiser_name;
        }
        /// <summary>
        /// 获得订货可用余额
        /// </summary>
        /// <param name="franID"></param>
        public static decimal GetBalance(int franID)
        {
            return CommBaseDAL.GetBalance(franID);
        }

        /// <summary>
        /// 获得点价可用余额
        /// </summary>
        /// <param name="franID"></param>
        public static decimal GetTradeBalance(int franID)
        {
            return CommBaseDAL.GetTradeBalance(franID);
        }


        /// <summary>
        /// 取得当前实时金价
        /// </summary>
        /// <returns></returns>
        public static decimal getRealTimePrice()
        {
            return CommBaseDAL.getRealTimePrice();
        }

        /// <summary>
        /// 查询入帐总额
        /// </summary>
        /// <param name="fran_id"></param>
        /// <returns></returns>
        public static decimal GetAddMoneyTotal(int fran_id)
        {
            return CommBaseDAL.GetAddMoneyTotal(fran_id);
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
    }
}
