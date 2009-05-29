using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
using GoldTradeNaming.Model;
using System.Collections.Generic;
namespace GoldTradeNaming.DAL
{
    ///田杰更改，添加取得订单号及交易号的方法

    /// <summary>
    /// 
    /// </summary>

    public class CommBaseDAL
    {
        public static int GetNextOrderId()
        {
            int nextorderid = DbHelperSQL.GetMaxID("franchiser_order_id", "franchiser_order");
            if (nextorderid != 1) nextorderid %= 10000;
            nextorderid = nextorderid/10 + 1;
            nextorderid = (DateTime.Now.Year - 2000) * 100000000 + DateTime.Now.Month * 1000000 + DateTime.Now.Day * 10000 + nextorderid*10 ;
            return nextorderid;
        }

        public static int GetNextTradeId()
        {
            int nextorderid = DbHelperSQL.GetMaxID("trade_id", "franchiser_trade");
            if (nextorderid != 1) nextorderid %= 1000;
            nextorderid = nextorderid / 10 + 1;
            nextorderid = (DateTime.Now.Year - 2000) * 100000000 + DateTime.Now.Month * 1000000 + DateTime.Now.Day * 10000 + nextorderid * 10+1;
            return nextorderid;
        }

        /// <summary>
        /// 获得产品的类型：黄金/白银
        /// </summary>
        /// <param name="type_id">产品类别ID</param>
        /// <returns></returns>
        public static string GetProductTypeById(string type_id)
        {
            string type = null;
            StringBuilder strQuery = new StringBuilder();
            try
            {
                strQuery.Append("select type ");
                strQuery.Append(" FROM product_type ");
                strQuery.Append("WHERE product_type_id=@type_id");
                SqlParameter[] parameters = {
					new SqlParameter("@type_id", SqlDbType.Int)};
                parameters[0].Value = type_id;
                DataSet dt = DbHelperSQL.Query(strQuery.ToString(), parameters);
                if (dt != null && dt.Tables.Count > 0 & dt.Tables[0].Rows.Count > 0)
                {
                    type = dt.Tables[0].Rows[0][0].ToString();
                }
            }
            catch
            {
                throw;
            }
            return type;
        }

        /// <summary>
        /// 查询某经销商的订货总额
        /// </summary>
        /// <param name="franid">经销商编号</param>
        /// <returns></returns>
        public static decimal GetOrderSumByFranId(int franid)
        {
            decimal OrderSum = 0.00M;
            string sql = "SELECT SUM(franchiser_order_amount_money) FROM franchiser_order WHERE franchiser_code = @franID";
            SqlParameter[] parameters = {
					new SqlParameter("@franID", SqlDbType.SmallInt)};
            parameters[0].Value = franid;
            DataSet ds = DbHelperSQL.Query(sql,parameters);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                OrderSum = Convert.ToDecimal(ds.Tables[0].Rows[0][0]);
            }
            return OrderSum;
        }

        /// <summary>
        /// 查询某经销商的交易总额
        /// </summary>
        /// <param name="franid">经销商编号</param>
        /// <returns></returns>
        public static decimal GetTradeSumByFranId(int franid)
        {
            decimal TradeSum = 0.00M;
            string sql = "SELECT SUM(trade_total_money) FROM franchiser_trade WHERE franchiser_code = @franID";
            SqlParameter[] parameters = {
					new SqlParameter("@franID", SqlDbType.SmallInt)};
            parameters[0].Value = franid;
            DataSet ds = DbHelperSQL.Query(sql, parameters);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                TradeSum = Convert.ToDecimal(ds.Tables[0].Rows[0][0]);
            }
            return TradeSum;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select franchiser_order_id,franchiser_code,franchiser_order_trans_type,
franchiser_order_address,franchiser_order_postcode,franchiser_order_handle_man,
franchiser_order_handle_tel,franchiser_order_handle_phone,franchiser_order_price,
franchiser_order_time,franchiser_order_state,franchiser_order_amount_money,
canceled_reason,ins_user,ins_date,upd_user,upd_date ");
            strSql.Append(" FROM franchiser_order ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary> 
        /// 库存中重量 by yuxiaowei
        /// </summary>
        /// <param name="franchiser_code"></param>
        /// <returns></returns>
        public DataSet GetLeftStock(string franchiser_code)
        {
            string strSql = string.Format("select sum(stock_left) as stock_left from stock_main where franchiser_code=N'" + franchiser_code + "'");
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得已定货但未收货的总重量 by yuxiaowei
        /// </summary>
        /// <returns></returns>
        public DataSet GetSumNoReceive(string franchiser_code)
        {
            string strSql = string.Format(@"select isnull(sum(product_unreceived),'0') as [sum] 
                                            from franchiser_order_desc 
                                            where franchiser_order_id in (select franchiser_order_id from franchiser_order 
                                            where franchiser_code=N'" + franchiser_code
                                            + "' and (franchiser_order_state='0' or franchiser_order_state='2'))");
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得当前实时金价信息
        /// </summary>
        public DataSet getCurrentPrice()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select realtime_base_price,realtime_time,sys_admin_id from realtime_price");
            strSql.Append(" where [id] in (select max([id]) as [id] from  realtime_price)");

            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得当前实时金价
        /// </summary>
        public static decimal getRealTimePrice()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select realtime_base_price from realtime_price");
            strSql.Append(" where [id] in (select max([id]) as [id] from  realtime_price)");

            DataSet ds =  DbHelperSQL.Query(strSql.ToString());

            return Convert.ToDecimal(ds.Tables[0].Rows[0][0]);
        }

        /// <summary>
        /// 获得定货可用余额
        /// </summary>
        /// <param name="franID"></param>
        public static decimal GetBalance(int franID)
        {
            decimal Balance = 0.00M;
            GoldTradeNaming.Model.franchiser_info franinfo = GetModel(franID);
            Balance = franinfo.franchiser_balance_money - franinfo.franchiser_asure_money;
            Balance -= GetStockBalance(franID);
            Balance -= GetUnreceivedBalance(franID);
            Balance -= GetHasSendButUnreceivedBalance(franID);
            return Balance;
        }

        /// <summary>
        /// 获得点价可用余额
        /// </summary>
        /// <param name="franID"></param>
        public static decimal GetTradeBalance(int franID)
        {
            decimal Balance = 0.00M;
            GoldTradeNaming.Model.franchiser_info franinfo = GetModel(franID);
            Balance = franinfo.franchiser_balance_money - franinfo.franchiser_asure_money;
            Balance -= GetStockBalanceForTrade(franID);
            Balance -= GetUnreceivedBalanceForTrade(franID);
            Balance -= GetHasSendButUnreceivedBalanceForTrade(franID);
            return Balance;
        }

        /// <summary>
        /// 获得库存剩余价值
        /// </summary>
        /// <param name="franID"></param>
        /// <returns></returns>
        private static decimal GetStockBalance(int franID)
        {
            decimal stockbalance = 0.00M;
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append(@"select SUM((c.realtime_base_price+a.order_add_price)*b.stock_left) as goldValue 
                            from realtime_price c, product_type a,stock_main b
                            where (a.product_type_id=b.product_id and a.product_spec_weight = b.product_spec_id) 
                            and a.type='0' and b.franchiser_code =@franID
                            and c.[id]=(select max([id]) as [id] from realtime_price)");
                SqlParameter[] parameters = {
					new SqlParameter("@franID", SqlDbType.SmallInt)};
                parameters[0].Value = franID;
                ///黄金剩余产品总价值
                DataSet goldSet = DbHelperSQL.Query(strSql.ToString(), parameters);

                strSql = new StringBuilder();
                strSql.Append(@"select total_money = SUM(s.stock_left*p.order_add_price)
                         from stock_main s,product_type p 
                        where s.product_id = p.product_type_id and s.product_spec_id = p.product_spec_weight and p.type='1' 
                        and franchiser_code = @franID");
                ///白银剩余产品总价值
                DataSet silverSet = DbHelperSQL.Query(strSql.ToString(), parameters);

                if (goldSet.Tables.Count > 0 && goldSet.Tables[0].Rows.Count > 0)
                {
                    try
                    {
                        stockbalance += Convert.ToDecimal(goldSet.Tables[0].Rows[0][0]);
                    }
                    catch
                    {
                        stockbalance += 0;
                    }
                }
                if (silverSet.Tables.Count > 0 && silverSet.Tables[0].Rows.Count > 0)
                {
                    try
                    {
                        stockbalance += Convert.ToDecimal(silverSet.Tables[0].Rows[0][0]);
                    }
                    catch
                    {
                        stockbalance += 0;
                    }
                }
            }
            catch
            {
                stockbalance = 0.00M;
            }
            return stockbalance;
        }

        /// <summary>
        /// 获得已订货未发货的价值
        /// </summary>
        /// <param name="franID"></param>
        /// <returns></returns>
        private static decimal GetUnreceivedBalance(int franID)
        {
            decimal unreceivedbalance = 0.00M;
            try
            {
                ///黄金已订货未发货产品总价值
                StringBuilder strSql = new StringBuilder();
                strSql.Append(@"
            select sum(

             a.[count]*(b.order_add_price+ c.realtime_base_price)) as goldvalue 
            from 
            ( 

            select franchiser_order_id,product_id,product_spec_id, isnull(sum(product_unreceived),0) 
             as [count] from franchiser_order_desc
             where franchiser_order_id 
             in (select franchiser_order_id from franchiser_order
             where (franchiser_order_state='1' or franchiser_order_state='0')
             and franchiser_code=@franID) 
             and product_id 
             in (select product_type_id from product_type where type='0')
             group by franchiser_order_id,product_id ,product_spec_id

            ) a 
            ,product_type b ,realtime_price c
             where a.product_id=b.product_type_id and a.product_spec_id=b.product_spec_weight  and c.[id]=(select max([id]) from realtime_price)
                    ");
                SqlParameter[] parameters = {
					new SqlParameter("@franID", SqlDbType.SmallInt)};
                parameters[0].Value = franID;
                
                DataSet goldSet = DbHelperSQL.Query(strSql.ToString(), parameters);

                ///白银已订货未发货产品总价值
                strSql = new StringBuilder();
                strSql.Append(@"select sum( a.[count]*b.order_add_price) as silverValue from 
                            (
                            select franchiser_order_id,product_id,product_spec_id, isnull(sum(product_unreceived),0) as [count] from franchiser_order_desc
                            where franchiser_order_id in 
                            (select franchiser_order_id from franchiser_order where  
                            (franchiser_order_state='1' or franchiser_order_state='0') 
                             and franchiser_code=@franID) 
                            and product_id in (select product_type_id from product_type where type='1')
                            group by franchiser_order_id,product_id,product_spec_id 
                             ) a ,product_type b where a.product_id=b.product_type_id  and a.product_spec_id=b.product_spec_weight ");
                
                DataSet silverSet = DbHelperSQL.Query(strSql.ToString(), parameters);

                if (goldSet.Tables.Count > 0 && goldSet.Tables[0].Rows.Count > 0)
                {
                    try
                    {
                        unreceivedbalance += Convert.ToDecimal(goldSet.Tables[0].Rows[0][0]);
                    }
                    catch
                    {
                        unreceivedbalance += 0;
                    }
                }
                if (silverSet.Tables.Count > 0 && silverSet.Tables[0].Rows.Count > 0)
                {
                    try
                    {
                        unreceivedbalance += Convert.ToDecimal(silverSet.Tables[0].Rows[0][0]);
                    }
                    catch
                    {
                        unreceivedbalance += 0;
                    }
                }
            }
            catch
            {
                unreceivedbalance = 0.00M;
            }
            return unreceivedbalance;

        }
        
        /// <summary>
        /// 获得已发货未收货的价值
        /// </summary>
        /// <param name="franID"></param>
        /// <returns></returns>
        private static decimal GetHasSendButUnreceivedBalance(int franID)
        {
            decimal unreceivedbalance = 0.00M;
            try
            {
                ///黄金已发货未收货产品总价值
                StringBuilder strSql = new StringBuilder();
                strSql.Append(@"
              select sum(

         a.[count]*(b.order_add_price+ c.realtime_base_price)) as goldvalue 
        from 
        ( 

         select send_id,product_id,product_spec_id, isnull(sum(send_amount_weight),0) as [count] 
         from send_desc
         where send_id 
           in (select send_id from send_main
         	where send_state='0'
         	and franchiser_order_id 
			in (select franchiser_order_id from franchiser_order where franchiser_code = @franID) --@franID
              ) 
         and product_id 
         in (select product_type_id from product_type where type='0') --黄金
         group by send_id,product_id ,product_spec_id

        ) a 
        ,product_type b ,realtime_price c
         where a.product_id=b.product_type_id and a.product_spec_id=b.product_spec_weight  and c.[id]=(select max([id]) from realtime_price)
                ");
                SqlParameter[] parameters = {
					new SqlParameter("@franID", SqlDbType.SmallInt)};
                parameters[0].Value = franID;

                DataSet goldSet = DbHelperSQL.Query(strSql.ToString(), parameters);

                ///白银已发货未收货产品总价值
                strSql = new StringBuilder();
                strSql.Append(@"
        select sum( a.[count]*b.order_add_price) as silverValue from 
        (
        select send_id,product_id,product_spec_id, isnull(sum(send_amount_weight),0) as [count] 
	from send_desc
        where send_id in 
             (select send_id from send_main 
	      where send_state='0' 
              and franchiser_order_id
		  in (select franchiser_order_id from franchiser_order where franchiser_code = @franID)--@franID
	     )
        and product_id 
	in (select product_type_id from product_type where type='1') --白银
        group by send_id,product_id,product_spec_id 
         ) a ,product_type b where a.product_id=b.product_type_id  and a.product_spec_id=b.product_spec_weight 
");

                DataSet silverSet = DbHelperSQL.Query(strSql.ToString(), parameters);

                if (goldSet.Tables.Count > 0 && goldSet.Tables[0].Rows.Count > 0)
                {
                    try
                    {
                        unreceivedbalance += Convert.ToDecimal(goldSet.Tables[0].Rows[0][0]);
                    }
                    catch
                    {
                        unreceivedbalance += 0;
                    }
                }
                if (silverSet.Tables.Count > 0 && silverSet.Tables[0].Rows.Count > 0)
                {
                    try
                    {
                        unreceivedbalance += Convert.ToDecimal(silverSet.Tables[0].Rows[0][0]);
                    }
                    catch
                    {
                        unreceivedbalance += 0;
                    }
                }
            }
            catch
            {
                unreceivedbalance = 0.00M;
            }
            return unreceivedbalance;

        }
        
        /// <summary>
        /// 得到经销商信息
        /// </summary>
        public static GoldTradeNaming.Model.franchiser_info GetModel(int franchiser_code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 franchiser_code,franchiser_name,franchiser_balance_money,franchiser_asure_money,franchiser_tel,franchiser_cellphone,franchiser_address,ins_user,ins_date,upd_user,upd_date,IA100GUID from franchiser_info ");
            strSql.Append(" where franchiser_code=@franchiser_code ");
            SqlParameter[] parameters = {
					new SqlParameter("@franchiser_code", SqlDbType.SmallInt)};
            parameters[0].Value = franchiser_code;

            GoldTradeNaming.Model.franchiser_info model = new GoldTradeNaming.Model.franchiser_info();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["franchiser_code"].ToString() != "")
                {
                    model.franchiser_code = int.Parse(ds.Tables[0].Rows[0]["franchiser_code"].ToString());
                }
                model.franchiser_name = ds.Tables[0].Rows[0]["franchiser_name"].ToString();
                if (ds.Tables[0].Rows[0]["franchiser_balance_money"].ToString() != "")
                {
                    model.franchiser_balance_money = decimal.Parse(ds.Tables[0].Rows[0]["franchiser_balance_money"].ToString());
                }
                if (ds.Tables[0].Rows[0]["franchiser_asure_money"].ToString() != "")
                {
                    model.franchiser_asure_money = decimal.Parse(ds.Tables[0].Rows[0]["franchiser_asure_money"].ToString());
                }
                model.franchiser_tel = ds.Tables[0].Rows[0]["franchiser_tel"].ToString();
                model.franchiser_cellphone = ds.Tables[0].Rows[0]["franchiser_cellphone"].ToString();
                model.franchiser_address = ds.Tables[0].Rows[0]["franchiser_address"].ToString();
                model.ins_user = ds.Tables[0].Rows[0]["ins_user"].ToString();
                if (ds.Tables[0].Rows[0]["ins_date"].ToString() != "")
                {
                    model.ins_date = DateTime.Parse(ds.Tables[0].Rows[0]["ins_date"].ToString());
                }
                model.upd_user = ds.Tables[0].Rows[0]["upd_user"].ToString();
                if (ds.Tables[0].Rows[0]["upd_date"].ToString() != "")
                {
                    model.upd_date = DateTime.Parse(ds.Tables[0].Rows[0]["upd_date"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IA100GUID"].ToString() != "")
                {
                    model.IA100GUID = new Guid(ds.Tables[0].Rows[0]["IA100GUID"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 查询某经销商的入帐总额
        /// </summary>
        /// <param name="fran_id"></param>
        /// <returns></returns>
        public static decimal GetAddMoneyTotal(int fran_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT SUM(franchiser_added_money) AS TotalMoney FROM franchiser_money");
            strSql.Append(" where franchiser_code=@franchiser_code ");
            SqlParameter[] parameters = {
					new SqlParameter("@franchiser_code", SqlDbType.Int,2)};
            parameters[0].Value = fran_id;

            DataSet ds = DbHelperSQL.Query(strSql.ToString(),parameters);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return Convert.ToDecimal(ds.Tables[0].Rows[0][0]);
            }
            return 0.00M;
        }

        /// <summary>
        /// 判断管理员是否具有某模块的操作权限
        /// </summary>
        /// <param name="sys_admin_id"></param>
        /// <param name="modelID"></param>
        /// <returns></returns>
        public static bool HasRight(int sys_admin_id, string modelID)
        {
            string strSql = string.Format(@"select * from sys_admin_authority where
                                            sys_admin_id='{0}' and sys_module='{1}'",
                                           sys_admin_id, modelID);

            return DbHelperSQL.Exists(strSql.ToString());
        }


        #region 点价余额计算
        /// <summary>
        /// 获得库存剩余价值
        /// </summary>
        /// <param name="franID"></param>
        /// <returns></returns>
        private static decimal GetStockBalanceForTrade(int franID)
        {
            decimal stockbalance = 0.00M;
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append(@"select SUM((c.realtime_base_price+a.trade_add_price)*b.stock_left) as goldValue 
                            from realtime_price c, product_type a,stock_main b
                            where (a.product_type_id=b.product_id and a.product_spec_weight = b.product_spec_id) 
                            and a.type='0' and b.franchiser_code =@franID
                            and c.[id]=(select max([id]) as [id] from realtime_price)");
                SqlParameter[] parameters = {
					new SqlParameter("@franID", SqlDbType.SmallInt)};
                parameters[0].Value = franID;
                ///黄金剩余产品总价值
                DataSet goldSet = DbHelperSQL.Query(strSql.ToString(), parameters);

                strSql = new StringBuilder();
                strSql.Append(@"select total_money = SUM(s.stock_left*p.trade_add_price)
                         from stock_main s,product_type p 
                        where s.product_id = p.product_type_id and s.product_spec_id = p.product_spec_weight and p.type='1' 
                        and franchiser_code = @franID");
                ///白银剩余产品总价值
                DataSet silverSet = DbHelperSQL.Query(strSql.ToString(), parameters);

                if (goldSet.Tables.Count > 0 && goldSet.Tables[0].Rows.Count > 0)
                {
                    try
                    {
                        stockbalance += Convert.ToDecimal(goldSet.Tables[0].Rows[0][0]);
                    }
                    catch
                    {
                        stockbalance += 0;
                    }
                }
                if (silverSet.Tables.Count > 0 && silverSet.Tables[0].Rows.Count > 0)
                {
                    try
                    {
                        stockbalance += Convert.ToDecimal(silverSet.Tables[0].Rows[0][0]);
                    }
                    catch
                    {
                        stockbalance += 0;
                    }
                }
            }
            catch
            {
                stockbalance = 0.00M;
            }
            return stockbalance;
        }

        /// <summary>
        /// 获得已订货未发货的价值
        /// </summary>
        /// <param name="franID"></param>
        /// <returns></returns>
        private static decimal GetUnreceivedBalanceForTrade(int franID)
        {
            decimal unreceivedbalance = 0.00M;
            try
            {
                ///黄金已订货未发货产品总价值
                StringBuilder strSql = new StringBuilder();
                strSql.Append(@"
            select sum(

             a.[count]*(b.trade_add_price+ c.realtime_base_price)) as goldvalue 
            from 
            ( 

            select franchiser_order_id,product_id,product_spec_id, isnull(sum(product_unreceived),0) 
             as [count] from franchiser_order_desc
             where franchiser_order_id 
             in (select franchiser_order_id from franchiser_order
             where (franchiser_order_state='1' or franchiser_order_state='0')
             and franchiser_code=@franID) 
             and product_id 
             in (select product_type_id from product_type where type='0')
             group by franchiser_order_id,product_id ,product_spec_id

            ) a 
            ,product_type b ,realtime_price c
             where a.product_id=b.product_type_id and a.product_spec_id=b.product_spec_weight  and c.[id]=(select max([id]) from realtime_price)
                    ");
                SqlParameter[] parameters = {
					new SqlParameter("@franID", SqlDbType.SmallInt)};
                parameters[0].Value = franID;

                DataSet goldSet = DbHelperSQL.Query(strSql.ToString(), parameters);

                ///白银已订货未发货产品总价值
                strSql = new StringBuilder();
                strSql.Append(@"select sum( a.[count]*b.trade_add_price) as silverValue from 
                            (
                            select franchiser_order_id,product_id,product_spec_id, isnull(sum(product_unreceived),0) as [count] from franchiser_order_desc
                            where franchiser_order_id in 
                            (select franchiser_order_id from franchiser_order where  
                            (franchiser_order_state='1' or franchiser_order_state='0') 
                             and franchiser_code=@franID) 
                            and product_id in (select product_type_id from product_type where type='1')
                            group by franchiser_order_id,product_id,product_spec_id 
                             ) a ,product_type b where a.product_id=b.product_type_id  and a.product_spec_id=b.product_spec_weight ");

                DataSet silverSet = DbHelperSQL.Query(strSql.ToString(), parameters);

                if (goldSet.Tables.Count > 0 && goldSet.Tables[0].Rows.Count > 0)
                {
                    try
                    {
                        unreceivedbalance += Convert.ToDecimal(goldSet.Tables[0].Rows[0][0]);
                    }
                    catch
                    {
                        unreceivedbalance += 0;
                    }
                }
                if (silverSet.Tables.Count > 0 && silverSet.Tables[0].Rows.Count > 0)
                {
                    try
                    {
                        unreceivedbalance += Convert.ToDecimal(silverSet.Tables[0].Rows[0][0]);
                    }
                    catch
                    {
                        unreceivedbalance += 0;
                    }
                }
            }
            catch
            {
                unreceivedbalance = 0.00M;
            }
            return unreceivedbalance;

        }

        /// <summary>
        /// 获得已发货未收货的价值
        /// </summary>
        /// <param name="franID"></param>
        /// <returns></returns>
        private static decimal GetHasSendButUnreceivedBalanceForTrade(int franID)
        {
            decimal unreceivedbalance = 0.00M;
            try
            {
                ///黄金已发货未收货产品总价值
                StringBuilder strSql = new StringBuilder();
                strSql.Append(@"
              select sum(

         a.[count]*(b.trade_add_price+ c.realtime_base_price)) as goldvalue 
        from 
        ( 

         select send_id,product_id,product_spec_id, isnull(sum(send_amount_weight),0) as [count] 
         from send_desc
         where send_id 
           in (select send_id from send_main
         	where send_state='0'
         	and franchiser_order_id 
			in (select franchiser_order_id from franchiser_order where franchiser_code = @franID) --@franID
              ) 
         and product_id 
         in (select product_type_id from product_type where type='0') --黄金
         group by send_id,product_id ,product_spec_id

        ) a 
        ,product_type b ,realtime_price c
         where a.product_id=b.product_type_id and a.product_spec_id=b.product_spec_weight  and c.[id]=(select max([id]) from realtime_price)
                ");
                SqlParameter[] parameters = {
					new SqlParameter("@franID", SqlDbType.SmallInt)};
                parameters[0].Value = franID;

                DataSet goldSet = DbHelperSQL.Query(strSql.ToString(), parameters);

                ///白银已发货未收货产品总价值
                strSql = new StringBuilder();
                strSql.Append(@"
        select sum( a.[count]*b.trade_add_price) as silverValue from 
        (
        select send_id,product_id,product_spec_id, isnull(sum(send_amount_weight),0) as [count] 
	from send_desc
        where send_id in 
             (select send_id from send_main 
	      where send_state='0' 
              and franchiser_order_id
		  in (select franchiser_order_id from franchiser_order where franchiser_code = @franID)--@franID
	     )
        and product_id 
	in (select product_type_id from product_type where type='1') --白银
        group by send_id,product_id,product_spec_id 
         ) a ,product_type b where a.product_id=b.product_type_id  and a.product_spec_id=b.product_spec_weight 
");

                DataSet silverSet = DbHelperSQL.Query(strSql.ToString(), parameters);

                if (goldSet.Tables.Count > 0 && goldSet.Tables[0].Rows.Count > 0)
                {
                    try
                    {
                        unreceivedbalance += Convert.ToDecimal(goldSet.Tables[0].Rows[0][0]);
                    }
                    catch
                    {
                        unreceivedbalance += 0;
                    }
                }
                if (silverSet.Tables.Count > 0 && silverSet.Tables[0].Rows.Count > 0)
                {
                    try
                    {
                        unreceivedbalance += Convert.ToDecimal(silverSet.Tables[0].Rows[0][0]);
                    }
                    catch
                    {
                        unreceivedbalance += 0;
                    }
                }
            }
            catch
            {
                unreceivedbalance = 0.00M;
            }
            return unreceivedbalance;

        }

        #endregion

        #region 晓炜方法

        ///点价余额用
        ///
        /// <summary>
        /// 获得经销商各类已定货但未收货的价值（库存*（金价*销售加价）） //黄金
        /// </summary>
        /// <param name="franchiser_code"></param>
        /// <returns></returns>
        public decimal GetGoldNoReceiveValue(string sFranchiser_code)
        {
            decimal i = 0;
            try
            {
                int franchiser_code = Convert.ToInt32(sFranchiser_code);
                string strSql = string.Format(@"select sum( a.[count]*(b.trade_add_price+c.realtime_base_price)) as goldValue  from 
                                            (
                                                select franchiser_order_id,product_id,product_spec_id, isnull(sum(product_unreceived),'0') as [count] from franchiser_order_desc
                                                where franchiser_order_id in (select franchiser_order_id from franchiser_order where  (franchiser_order_state='1' or franchiser_order_state='0') 
                                                and franchiser_code=@franchiser_code) 
                                                and product_id in (select product_type_id from product_type where type='0')
                                                group by franchiser_order_id,product_id ,product_spec_id
                                            ) a, product_type b,realtime_price c where a.product_id=b.product_type_id and a.product_spec_id=b.product_spec_weight   and c.[id]=(select max([id]) from realtime_price)");
                SqlParameter[] parameters = {
					new SqlParameter("@franchiser_code", SqlDbType.Int,2)};
                parameters[0].Value = franchiser_code;
                DataSet ds = DbHelperSQL.Query(strSql.ToString(),parameters);
                i = Convert.ToDecimal(ds.Tables[0].Rows[0][0].ToString().Trim());
            }
            catch
            {
            }
            return i;
        }

        /// <summary>
        /// 获得经销商各类已定货但未收货的价值（库存*固定价格） //白银
        /// </summary>
        /// <param name="franchiser_code"></param>
        /// <returns></returns>
        public decimal GetSilverNoReceiveValue(string sFranchiser_code)
        {
            decimal i = 0;
            try
            {
                int franchiser_code = Convert.ToInt32(sFranchiser_code);
                string strSql = string.Format(@"select sum( a.[count]*b.trade_add_price) as silverValue from 
                                            (
                                                select franchiser_order_id,product_id,product_spec_id, isnull(sum(product_unreceived),'0') as [count] from franchiser_order_desc
                                                where franchiser_order_id in (select franchiser_order_id from franchiser_order where  (franchiser_order_state='1' or franchiser_order_state='0') 
                                                and franchiser_code=@franchiser_code) 
                                                and product_id in (select product_type_id from product_type where type='1')
                                                group by franchiser_order_id,product_id ,product_spec_id
                                             ) a ,product_type b where a.product_id=b.product_type_id  and a.product_spec_id=b.product_spec_weight ");
                SqlParameter[] parameters = {
					new SqlParameter("@franchiser_code", SqlDbType.Int,2)};
                parameters[0].Value = franchiser_code;
                DataSet ds = DbHelperSQL.Query(strSql.ToString(),parameters);


                i = Convert.ToDecimal(ds.Tables[0].Rows[0][0].ToString().Trim());
            }
            catch
            {
            }
            return i;
        }

        /// <summary>
        /// 获得经销商库存货物的价值 //黄金
        /// </summary>
        /// <param name="franchiser_code"></param>
        /// <returns></returns>
        public decimal GetGoldStockValue(string sFranchiser_code)
        {
            decimal i = 0;
            try
            {
                int franchiser_code = Convert.ToInt32(sFranchiser_code);
                string strSql = string.Format(@"select sum((c.realtime_base_price+a.trade_add_price)*b.stock_left) as goldValue 
                                                from realtime_price c, product_type a,stock_main b
                                                where (a.product_type_id=b.product_id and a.product_spec_weight = b.product_spec_id) 
                                                and a.type='0' and b.franchiser_code =@franchiser_code
                                                and c.[id]=(select max([id]) as [id] from realtime_price) ");
                SqlParameter[] parameters = {
					new SqlParameter("@franchiser_code", SqlDbType.Int,2)};
                parameters[0].Value = franchiser_code;
                DataSet ds = DbHelperSQL.Query(strSql.ToString(),parameters);

                i = Convert.ToDecimal(ds.Tables[0].Rows[0][0].ToString().Trim());
            }
            catch
            {
            }
            return i;
        }

        /// <summary>
        /// 获得经销商库存货物的价值 //白银
        /// </summary>
        /// <param name="franchiser_code"></param>
        /// <returns></returns>
        public decimal GetSilverStockValue(string sFranchiser_code)
        {
            decimal i = 0;
            try
            {
                int franchiser_code = Convert.ToInt32(sFranchiser_code);
                string strSql = string.Format(@"select sum(a.trade_add_price*b.stock_left) as silverValue 
                                                from product_type a,stock_main b
                                                where (a.product_type_id=b.product_id and a.product_spec_weight = b.product_spec_id) 
                                                and a.type='1' and b.franchiser_code =@franchiser_code ");
                SqlParameter[] parameters = {
					new SqlParameter("@franchiser_code", SqlDbType.Int,2)};
                parameters[0].Value = franchiser_code;
                DataSet ds = DbHelperSQL.Query(strSql.ToString(),parameters);

                i = Convert.ToDecimal(ds.Tables[0].Rows[0][0].ToString().Trim());
            }
            catch
            {
            }
            return i;
        }

        #endregion



    }
}
