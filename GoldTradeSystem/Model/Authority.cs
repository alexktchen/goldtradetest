using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoldTradeNaming.Model
{
    public enum Authority
    {
        #region 金价管理
        /// <summary>
        /// 修改实时金价
        /// </summary>
        ChgPrice,


        /// <summary>
        /// 查看实时金价
        /// </summary>
        ViewPrice,
        #endregion

        #region 订单管理

        /// <summary>
        /// 查看订单
        /// </summary>
        ViewOrder,


        /// <summary>
        /// 确认订单
        /// </summary>
        ConOrder,


        /// <summary>
        /// 修改订单
        /// </summary>
       // ChgOrder,

        #endregion

        #region 产品管理

        /// <summary>
        /// 查看产品
        /// </summary>
        ViewProduct,


        /// <summary>
        /// 修改产品
        /// </summary>
        ChgProduct,


        /// <summary>
        /// 添加产品
        /// </summary>
        AddProduct,

        #endregion

        #region 财务管理

        /// <summary>
        /// 查看入账
        /// </summary>
        ViewAddMoney,

        /// <summary>
        /// 新增入账
        /// </summary>
        AddMoney,


        /// <summary>
        /// 审核入账
        /// </summary>
        CheckAddMoney,

        #endregion

        #region 经销商管理

        /// <summary>
        /// 查看经销商
        /// </summary>
        ViewFran,


        /// <summary>
        /// 修改经销商
        /// </summary>
        ChgFran,


        /// <summary>
        /// 添加经销商
        /// </summary>
        AddFran,

        #endregion

        #region 交易管理

        /// <summary>
        /// 查看交易
        /// </summary>
        ViewTrade,

        /// <summary>
        /// 锁定交易时间
        /// </summary>
        TradeLock,

        /// <summary>
        /// 销售报表
        /// </summary>
        TradeReport,

        #endregion

        #region 系统管理

        /// <summary>
        /// 添加管理员
        /// </summary>
        AddAdmin,


        /// <summary>
        /// 查看管理员
        /// </summary>
        ViewAdmin,


        /// <summary>
        /// 权限管理
        /// </summary>
        AuthMgn,


        /// <summary>
        /// 认证锁查询
        /// </summary>
        SearchIA,


        /// <summary>
        /// 认证锁添加
        /// </summary>
        AddIA,

        #endregion

        #region 库存发货

        /// <summary>
        /// 查看库存
        /// </summary>
        StockView,

        /// <summary>
        /// 修改库存
        /// </summary>
        StockMgn,

        /// <summary>
        /// 库存修改记录查看
        /// </summary>
        ViewStockLog,

        /// <summary>
        /// 在线发货
        /// </summary>
        Send

        #endregion
    }
}
