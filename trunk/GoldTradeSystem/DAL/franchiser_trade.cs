using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
using GoldTradeNaming.Model;
using System.Collections.Generic;//请先添加引用
namespace GoldTradeNaming.DAL
{
    /// <summary>
    /// 数据访问类franchiser_trade。
    /// </summary>
    public class franchiser_trade
    {
        public franchiser_trade()
        {
        }
        #region  成员方法

        /// <summary>
        /// 获得最新交易时间  by yuxiaowei
        /// </summary>
        /// <returns></returns>
        public DataSet GetTradetime()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select CONVERT(varchar(12),dtFrom,108) as dtFrom, CONVERT(varchar(12),dtTo,108 ) as dtTo from trade_time where [id]=(select max([id]) from trade_time) ");

            return DbHelperSQL.Query(strSql.ToString());

        }

        /// <summary>
        /// 限制交易时间  byyuxiaowei
        /// </summary>
        /// <param name="dtFrom"></param>
        /// <param name="dtTo"></param>
        /// <param name="ins_user"></param>
        public int SetTradeTime(DateTime dtFrom,DateTime dtTo,string ins_user)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into trade_time (dtFrom,dtTo,ins_user,ins_date) ");
            strSql.Append("values(@dtFrom,@dtTo,@ins_user,getdate())");

            //   string strSql = string.Format(@"insert into trade_time (dtFrom,dtTo,ins_user,ins_date) values ()");

            SqlParameter[] parameters = {
					new SqlParameter("@dtFrom", SqlDbType.DateTime,8),
					new SqlParameter("@dtTo", SqlDbType.DateTime,8),
					new SqlParameter("@ins_user", SqlDbType.NVarChar,50)};
            parameters[0].Value = dtFrom;
            parameters[1].Value = dtTo;
            parameters[2].Value = ins_user;
            return DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
        }

        /// <summary>
        ///  管理员 获得交易列表  by yuxiaowei
        /// </summary>
        public DataSet GetTradeByM(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select top 50 a.*,b.franchiser_name  from franchiser_trade a left join franchiser_info b  on a.franchiser_code=b.franchiser_code ");
            if(strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by trade_time desc");
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 管理员 确认交易取消 by yuxiaowei  //取消
        /// </summary>
        /// <param name="trade_id"></param>
        /// <param name="franchiser_code"></param>
        /// <returns></returns>
        public int ConfirmCancle(string trade_id,string franchiser_code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update a set a.stock_left=a.stock_left+b.trade_weight/b.product_spec_id from stock_main a inner join franchiser_trade_desc b on a.product_id =b.product_id ");
            strSql.Append(" where trade_id=@trade_id;  ");

            strSql.Append("update a set a.franchiser_balance_money=a.franchiser_balance_money+b.trade_total_money from franchiser_info a inner join franchiser_trade b on a.franchiser_code=b.franchiser_code ");
            strSql.Append(" where a.franchiser_code=@franchiser_code and b.trade_id=@trade_id;  ");


            strSql.Append("update franchiser_trade set trade_state='2' ");
            strSql.Append(" where franchiser_code=@franchiser_code and trade_id=@trade_id ");


            SqlParameter[] parameters = {
					new SqlParameter("@trade_id", SqlDbType.NVarChar,50),
                    new SqlParameter("@franchiser_code", SqlDbType.NVarChar,100)};
            parameters[0].Value = trade_id;
            parameters[1].Value = franchiser_code;
            return DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);

        }

        /// <summary>
        /// 供应商取消交易 by yuxiaowei //取消
        /// </summary>
        /// <param name="franchiser_trade"></param>
        /// <returns></returns>
        public int CancleTradeInfo(string trade_id,string reason)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update franchiser_trade set trade_state='1',canceled_reason=@canceled_reason ");
            strSql.Append(" where trade_id=@trade_id ");
            SqlParameter[] parameters = {
					new SqlParameter("@trade_id", SqlDbType.NVarChar,50),
                    new SqlParameter("@canceled_reason", SqlDbType.NVarChar,100)};
            parameters[0].Value = trade_id;
            parameters[1].Value = reason;

            return DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);

        }

        /// <summary>
        /// 增加交易记录 by yuxiaowei
        /// </summary>
        /// <param name="prInfos"></param>
        /// <param name="trInfo"></param>
        /// <param name="iType">0黄金 1白银</param>
        /// <returns></returns>
        public bool AddTrandeInfo(List<ProductInfo> prInfos,TradeInfo trInfo,string iType)
        {
            if(iType == "0")
            {
                #region

                using(SqlConnection conn = new SqlConnection(PubConstant.ConnectionString))
                {
                    conn.Open();
                    using(SqlTransaction trans = conn.BeginTransaction())
                    {
                        SqlCommand cmd = new SqlCommand();
                        try
                        {
                            int maxID = GetMaxId();

                            int result = 0;
                            StringBuilder strSql = new StringBuilder();
                            strSql.Append("insert into franchiser_trade(");
                            strSql.Append("trade_id,franchiser_code,trade_time,realtime_base_price,trade_total_weight,trade_total_money,trade_state,ins_user,upd_user)");
                            strSql.Append(" values (");
                            strSql.Append(" @trade_id,@franchiser_code,getdate(),@realtime_base_price,@trade_total_weight,@trade_total_money,@trade_state,@ins_user,@upd_user) ");

                            strSql.Append(" update franchiser_info set franchiser_balance_money=franchiser_balance_money-@trade_total_money,upd_date=getdate(),upd_user=@upd_user where franchiser_code=@franchiser_code");

                            SqlParameter[] parameters = { 
                            new SqlParameter("@trade_id", SqlDbType.Int,4),
                            new SqlParameter("@franchiser_code", SqlDbType.SmallInt,2),             
                            new SqlParameter("@realtime_base_price", SqlDbType.Money,50),                        
                          //  new SqlParameter("@trade_add_price", SqlDbType.Money,8),
                            new SqlParameter("@trade_total_weight", SqlDbType.Int,4),              
                            new SqlParameter("@trade_total_money", SqlDbType.Money,8),
                            new SqlParameter("@trade_state", SqlDbType.NVarChar,50),
                            new SqlParameter("@ins_user", SqlDbType.NVarChar,50),
                            new SqlParameter("@upd_user", SqlDbType.NVarChar,50),
                          //  new SqlParameter("@upd_user", SqlDbType.NVarChar,50)
                                                    };
                            parameters[0].Value = maxID;
                            parameters[1].Value = trInfo.FranchiserCode;
                            parameters[2].Value = trInfo.RealTimePrice;
                            //parameters[3].Value = trInfo.GoldTradePrice;
                            // parameters[4].Value = trInfo.TradeAddPrice;
                            parameters[3].Value = trInfo.TradeTotalWeight;
                            parameters[4].Value = trInfo.TradeTotalMoney;
                            parameters[5].Value = trInfo.TradeState;
                            parameters[6].Value = trInfo.InsUser;
                            parameters[7].Value = trInfo.UpdUser;

                            cmd.CommandText = strSql.ToString();
                            cmd.Transaction = trans;
                            cmd.Connection = conn;
                            cmd.Parameters.AddRange(parameters);
                            result += cmd.ExecuteNonQuery();

                            foreach(ProductInfo prInfo in prInfos)
                            {
                                cmd = new SqlCommand();
                                strSql = new StringBuilder();
                                strSql.Append("insert into franchiser_trade_desc(");
                                strSql.Append("trade_id,product_id,product_spec_id,realtime_base_price,trade_add_price,gold_trade_price,trade_amount,trade_weight,trade_money,ins_user,upd_user)");
                                strSql.Append(" values (");
                                strSql.Append("@trade_id2,@product_id,@product_spec_id,@realtime_base_price,@trade_add_price,@gold_trade_price,@trade_amount,@trade_weight,@trade_money,@ins_user2,@upd_user2); ");

                                strSql.Append(" update stock_main set stock_left=@stockleft,upd_user=@upd_user2,upd_date=getdate() ");
                                strSql.Append(" where franchiser_code=@franchiser_code2 and product_id=@product_id and product_spec_id=@product_spec_id; ");

                                SqlParameter[] parameters2 = {                
                                    new SqlParameter("@trade_id2", SqlDbType.Int,4),
                                    new SqlParameter("@product_id", SqlDbType.Int,4),
                                    new SqlParameter("@product_spec_id", SqlDbType.Int,4),

                                    new SqlParameter("@realtime_base_price", SqlDbType.Int,4),
                                    new SqlParameter("@trade_add_price", SqlDbType.Int,4),
                                    new SqlParameter("@gold_trade_price", SqlDbType.Int,4),

                                    new SqlParameter("@trade_amount", SqlDbType.Int,4),
                                    new SqlParameter("@trade_weight", SqlDbType.Int,4),
                                    new SqlParameter("@trade_money", SqlDbType.Int,4),
                                    new SqlParameter("@ins_user2", SqlDbType.NVarChar,50),
                                    new SqlParameter("@upd_user2", SqlDbType.NVarChar,50),
                                    new SqlParameter("@stockleft", SqlDbType.Int,4),
                                    new SqlParameter("@franchiser_code2", SqlDbType.NVarChar,50)
                                                          };
                                parameters2[0].Value = maxID;
                                parameters2[1].Value = prInfo.ProductID;
                                parameters2[2].Value = prInfo.ProductSpecID;

                                parameters2[3].Value = prInfo.RealTimeBasePrice;
                                parameters2[4].Value = prInfo.TradeAddPrice;
                                parameters2[5].Value = prInfo.GoldTradePrice;

                                parameters2[6].Value = prInfo.TradeAmount;
                                parameters2[7].Value = prInfo.TradeWeight;
                                parameters2[8].Value = prInfo.TradeMoney;
                                parameters2[9].Value = trInfo.InsUser;
                                parameters2[10].Value = trInfo.UpdUser;
                                parameters2[11].Value = prInfo.StockLeft;
                                parameters2[12].Value = trInfo.FranchiserCode;


                                cmd.Parameters.AddRange(parameters2);
                                cmd.CommandText = strSql.ToString();
                                cmd.Transaction = trans;
                                cmd.Connection = conn;
                                result += cmd.ExecuteNonQuery();
                            }

                            trans.Commit();
                            return true;
                        }
                        catch
                        {
                            trans.Rollback();
                            return false;
                        }
                    }
                }
                #endregion
            }
            else if(iType == "1")
            {
                #region

                using(SqlConnection conn = new SqlConnection(PubConstant.ConnectionString))
                {
                    conn.Open();
                    using(SqlTransaction trans = conn.BeginTransaction())
                    {
                        SqlCommand cmd = new SqlCommand();
                        try
                        {
                            int maxID = GetMaxId();

                            int result = 0;
                            StringBuilder strSql = new StringBuilder();
                            strSql.Append("insert into franchiser_trade(");
                            strSql.Append("trade_id,franchiser_code,trade_time,trade_total_weight,trade_total_money,trade_state,ins_user,upd_user)");
                            strSql.Append(" values (");
                            strSql.Append(" @trade_id,@franchiser_code,getdate(),@trade_total_weight,@trade_total_money,@trade_state,@ins_user,@upd_user) ");

                            strSql.Append(" update franchiser_info set franchiser_balance_money=franchiser_balance_money-@trade_total_money,upd_date=getdate(),upd_user=@upd_user where franchiser_code=@franchiser_code");

                            SqlParameter[] parameters = { 
                            new SqlParameter("@trade_id", SqlDbType.Int,4),
                            new SqlParameter("@franchiser_code", SqlDbType.SmallInt,2),             
                            //new SqlParameter("@realtime_base_price", SqlDbType.Money,50),                        
                          //  new SqlParameter("@trade_add_price", SqlDbType.Money,8),
                            new SqlParameter("@trade_total_weight", SqlDbType.Int,4),              
                            new SqlParameter("@trade_total_money", SqlDbType.Money,8),
                            new SqlParameter("@trade_state", SqlDbType.NVarChar,50),
                            new SqlParameter("@ins_user", SqlDbType.NVarChar,50),
                            new SqlParameter("@upd_user", SqlDbType.NVarChar,50),
                          //  new SqlParameter("@upd_user", SqlDbType.NVarChar,50)
                                                    };
                            parameters[0].Value = maxID;
                            parameters[1].Value = trInfo.FranchiserCode;
                            //   parameters[2].Value = trInfo.RealTimePrice;
                            //parameters[3].Value = trInfo.GoldTradePrice;
                            // parameters[4].Value = trInfo.TradeAddPrice;
                            parameters[2].Value = trInfo.TradeTotalWeight;
                            parameters[3].Value = trInfo.TradeTotalMoney;
                            parameters[4].Value = trInfo.TradeState;
                            parameters[5].Value = trInfo.InsUser;
                            parameters[6].Value = trInfo.UpdUser;

                            cmd.CommandText = strSql.ToString();
                            cmd.Transaction = trans;
                            cmd.Connection = conn;
                            cmd.Parameters.AddRange(parameters);
                            result += cmd.ExecuteNonQuery();

                            foreach(ProductInfo prInfo in prInfos)
                            {
                                cmd = new SqlCommand();
                                strSql = new StringBuilder();
                                strSql.Append("insert into franchiser_trade_desc(");
                                strSql.Append("trade_id,product_id,product_spec_id,gold_trade_price,trade_amount,trade_weight,trade_money,ins_user,upd_user)");
                                strSql.Append(" values (");
                                strSql.Append("@trade_id2,@product_id,@product_spec_id,@gold_trade_price,@trade_amount,@trade_weight,@trade_money,@ins_user2,@upd_user2); ");

                                strSql.Append(" update stock_main set stock_left=@stockleft,upd_user=@upd_user2,upd_date=getdate() ");
                                strSql.Append(" where franchiser_code=@franchiser_code2 and product_id=@product_id and product_spec_id=@product_spec_id; ");

                                SqlParameter[] parameters2 = {                
                                    new SqlParameter("@trade_id2", SqlDbType.Int,4),
                                    new SqlParameter("@product_id", SqlDbType.Int,4),
                                    new SqlParameter("@product_spec_id", SqlDbType.Int,4),

                                  //  new SqlParameter("@realtime_base_price", SqlDbType.Int,4),
                                 //   new SqlParameter("@trade_add_price", SqlDbType.Int,4),
                                    new SqlParameter("@gold_trade_price", SqlDbType.Int,4),

                                    new SqlParameter("@trade_amount", SqlDbType.Int,4),
                                    new SqlParameter("@trade_weight", SqlDbType.Int,4),
                                    new SqlParameter("@trade_money", SqlDbType.Int,4),
                                    new SqlParameter("@ins_user2", SqlDbType.NVarChar,50),
                                    new SqlParameter("@upd_user2", SqlDbType.NVarChar,50),
                                    new SqlParameter("@stockleft", SqlDbType.Int,4),
                                    new SqlParameter("@franchiser_code2", SqlDbType.NVarChar,50)
                                                          };
                                parameters2[0].Value = maxID;
                                parameters2[1].Value = prInfo.ProductID;
                                parameters2[2].Value = prInfo.ProductSpecID;

                                //    parameters2[3].Value = prInfo.RealTimeBasePrice;
                                //    parameters2[4].Value = prInfo.TradeAddPrice;
                                parameters2[3].Value = prInfo.GoldTradePrice;

                                parameters2[4].Value = prInfo.TradeAmount;
                                parameters2[5].Value = prInfo.TradeWeight;
                                parameters2[6].Value = prInfo.TradeMoney;
                                parameters2[7].Value = trInfo.InsUser;
                                parameters2[8].Value = trInfo.UpdUser;
                                parameters2[9].Value = prInfo.StockLeft;
                                parameters2[10].Value = trInfo.FranchiserCode;


                                cmd.Parameters.AddRange(parameters2);
                                cmd.CommandText = strSql.ToString();
                                cmd.Transaction = trans;
                                cmd.Connection = conn;
                                result += cmd.ExecuteNonQuery();
                            }

                            trans.Commit();
                            return true;
                        }
                        catch
                        {
                            trans.Rollback();
                            return false;
                        }
                    }
                }
                #endregion
            }
            else
                return false;

        }

        /// <summary>
        /// 获取交易记录 经销商  by yuxiaowei
        /// </summary>
        public DataSet GetAllTrade(string franchiser_code,string trade_id,DateTime dtFrom,DateTime dtTo)
        {
            //            string strQuery = string.Format(@"select trade_id,franchiser_code ,trade_time ,realtime_base_price,
            //                                trade_total_weight , trade_total_money,
            //                                trade_state=case when trade_state=0 THEN '新增' when trade_state=1 THEN '请求取消'  when trade_state=2 THEN '已取消'  ELSE '未知' END, 
            //                                isnull(canceled_reason,'') as canceled_reason ,ins_user ,ins_date ,upd_user ,upd_date  
            //                                from franchiser_trade where franchiser_code='" + franchiser_code + "' and trade_id like '%" + trade_id + "%' and trade_time between '" + dtFrom.ToString("yyyy/MM/dd") + "' and '" + dtTo.ToString("yyyy/MM/dd 23:59:59") + "' order by trade_time desc; ");
            string strQuery = string.Format(@"select *  from franchiser_trade where franchiser_code='" + franchiser_code + "' and trade_id like '%" + trade_id + @"%'
                                             and trade_time between '" + dtFrom.ToString("yyyy/MM/dd") + "' and '" + dtTo.ToString("yyyy/MM/dd 23:59:59") + "' order by trade_time desc; ");
            return DbHelperSQL.Query(strQuery);
        }


        /// <summary>
        /// 获取交易详细记录 经销商 by yuxiaowei
        /// </summary>
        public DataSet GetTradeDesc(string trade_id)
        {
            string strQuery = string.Format(@"select distinct a.*,b.product_type_name from franchiser_trade_desc a inner join product_type b on b.product_type_id=a.product_id  where a.trade_id='" + trade_id + "' order by a.ins_date desc; ");

            return DbHelperSQL.Query(strQuery);
        }
        /// <summary> 
        /// 库存中各类产品的重量 by yuxiaowei
        /// </summary>
        /// <param name="franchiser_code"></param>
        /// <returns></returns>
        public DataSet GetLeftStock(string franchiser_code)
        {
            string strSql = string.Format("select sum(stock_left) as stock_left from stock_main where franchiser_code=N'" + franchiser_code + "'; ");
            strSql += string.Format(@"select a.product_id,a.product_spec_id ,a.stock_left*b.trade_add_price as [count] from stock_main a inner join product_type b 
on a.product_id=b.product_type_id and a.product_spec_id=product_spec_weight where franchiser_code=N'" + franchiser_code + "'; ");
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 获得已定货但未收货的重量 by yuxiaowei // 黄金
        /// 订单号 产品类别号 未收货重量 订购加价
        /// franchiser_order_id  product_id count trade_add_price
        /// </summary>
        /// <returns></returns>
        public DataSet GetGoldNoReceive(string franchiser_code)
        {
            string strSql = string.Format(@"select distinct a.*,b.trade_add_price from (
                                            select franchiser_order_id,product_id, isnull(sum(product_unreceived),'0') as [count] from franchiser_order_desc 
                                            where franchiser_order_id in (select franchiser_order_id from franchiser_order where (franchiser_order_state='1' or franchiser_order_state='0') 
                                            and franchiser_code=N'" + franchiser_code + @"')
                                            and product_id in (select product_type_id from product_type where type='0')
                                            group by franchiser_order_id,product_id ) a inner  join product_type b on a.product_id=b.product_type_id");
            return DbHelperSQL.Query(strSql.ToString());
        }


        /// <summary>
        /// 获得经销商各类已定货但未收货的价值（库存*（金价*销售加价）） //黄金
        /// </summary>
        /// <param name="franchiser_code"></param>
        /// <returns></returns>
        public decimal GetGoldNoReceiveValue(string franchiser_code)
        {
            string strSql = string.Format(@"select sum(a.[count]*(b.trade_add_price+c.realtime_base_price)) as goldValue  from 
                                            (
                                                select franchiser_order_id,product_id,product_spec_id, isnull(sum(product_unreceived),'0') as [count] from franchiser_order_desc
                                                where franchiser_order_id in (select franchiser_order_id from franchiser_order where  (franchiser_order_state='1' or franchiser_order_state='0') 
                                                and franchiser_code=N'" + franchiser_code + @"') 
                                                and product_id in (select product_type_id from product_type where type='0')
                                                group by franchiser_order_id,product_id ,product_spec_id
                                            ) a, product_type b,realtime_price c where a.product_id=b.product_type_id and a.product_spec_id=b.product_spec_weight   and c.[id]=(select max([id]) from realtime_price)");
            //            string strSql = string.Format(@"select sum(distinct a.[count]*(b.trade_add_price+c.realtime_base_price)) as goldValue  from 
            //                                            (
            //                                                select franchiser_order_id,product_id, isnull(sum(product_unreceived),'0') as [count] from franchiser_order_desc
            //                                                where franchiser_order_id in (select franchiser_order_id from franchiser_order where  (franchiser_order_state='1' or franchiser_order_state='0') 
            //                                                and franchiser_code=N'" + franchiser_code + @"') 
            //                                                and product_id in (select product_type_id from product_type where type='0')
            //                                                group by franchiser_order_id,product_id 
            //                                            ) a, product_type b,realtime_price c where a.product_id=b.product_type_id and c.[id]=(select max([id]) from realtime_price)");
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            decimal i = 0;
            try
            {
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
        public decimal GetSilverNoReceiveValue(string franchiser_code)
        {
            string strSql = string.Format(@"select sum(a.[count]*b.trade_add_price) as silverValue from 
                                            (
                                                select franchiser_order_id,product_id,product_spec_id, isnull(sum(product_unreceived),'0') as [count] from franchiser_order_desc
                                                where franchiser_order_id in (select franchiser_order_id from franchiser_order where  (franchiser_order_state='1' or franchiser_order_state='0') 
                                                and franchiser_code=N'" + franchiser_code + @"') 
                                                and product_id in (select product_type_id from product_type where type='1')
                                                group by franchiser_order_id,product_id ,product_spec_id
                                             ) a ,product_type b where a.product_id=b.product_type_id  and a.product_spec_id=b.product_spec_weight ");
            //            string strSql = string.Format(@"select sum(distinct a.[count]*b.trade_add_price) as silverValue from 
            //                                            (
            //                                                select franchiser_order_id,product_id, isnull(sum(product_unreceived),'0') as [count] from franchiser_order_desc
            //                                                where franchiser_order_id in (select franchiser_order_id from franchiser_order where  (franchiser_order_state='1' or franchiser_order_state='0') 
            //                                                and franchiser_code=N'" + franchiser_code + @"') 
            //                                                and product_id in (select product_type_id from product_type where type='1')
            //                                                group by franchiser_order_id,product_id 
            //                                             ) a ,product_type b where a.product_id=b.product_type_id");
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            decimal i = 0;
            try
            {
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
        public decimal GetGoldStockValue(string franchiser_code)
        {
            string strSql = string.Format(@"select sum((c.realtime_base_price+a.trade_add_price)*b.stock_left) as goldValue 
                                                from realtime_price c, product_type a,stock_main b
                                                where (a.product_type_id=b.product_id and a.product_spec_weight = b.product_spec_id) 
                                                and a.type='0' and b.franchiser_code =N'" + franchiser_code + @"'
                                                and c.[id]=(select max([id]) as [id] from realtime_price) ");
            //            string strSql = string.Format(@"select sum((c.realtime_base_price+a.trade_add_price)*b.stock_left) as goldValue 
            //                                                from realtime_price c, product_type a,stock_main b
            //                                                where (a.product_type_id=b.product_id and a.product_spec_weight = b.product_spec_id) 
            //                                                and a.type='0' and b.franchiser_code =N'" + franchiser_code + @"'
            //                                                and c.[id]=(select max([id]) as [id] from realtime_price) ");
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            decimal i = 0;
            try
            {
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
        public decimal GetSilverStockValue(string franchiser_code)
        {
            string strSql = string.Format(@"select sum(a.trade_add_price*b.stock_left) as silverValue 
                                                from product_type a,stock_main b
                                                where (a.product_type_id=b.product_id and a.product_spec_weight = b.product_spec_id) 
                                                and a.type='1' and b.franchiser_code =N'" + franchiser_code + "' ");
            //            string strSql = string.Format(@"select sum(a.trade_add_price*b.stock_left) as silverValue 
            //                                                from product_type a,stock_main b
            //                                                where (a.product_type_id=b.product_id and a.product_spec_weight = b.product_spec_id) 
            //                                                and a.type='1' and b.franchiser_code =N'" + franchiser_code + "' ");
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            decimal i = 0;
            try
            {
                i = Convert.ToDecimal(ds.Tables[0].Rows[0][0].ToString().Trim());
            }
            catch
            {
            }
            return i;
        }


        /// <summary>
        /// 获得产品的交易加价 //黄金
        /// </summary>
        /// <param name="product_id"></param>
        /// <returns></returns>
        public DataSet GetTradeAdd(string product_id)
        {
            string strSql = string.Format(@"select trade_add_price from product_type where product_type_id=N'" + product_id + "' ; ");
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 获得产品库存列别 黄金  by yuxiaowei
        /// </summary>
        public DataSet GetGoldStock(string franchiser_code)
        {
            string strSql = string.Format(@"select c.realtime_base_price , a.product_type_id ,a.product_type_name,a.trade_add_price, a.product_spec_weight,b.stock_left/b.product_spec_id as stock_num,b.stock_left
                                            from realtime_price c, product_type a,stock_main b
                                            where (a.product_type_id=b.product_id and a.product_spec_weight = b.product_spec_id) 
                                            and a.type='0' and b.franchiser_code =N'" + franchiser_code + @"' and stock_left>0
                                            and c.[id]=(select max([id]) as [id] from realtime_price) order by  a.product_type_id, a.product_spec_weight ;");

            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得产品库存列别 白银  by yuxiaowei
        /// </summary>
        public DataSet GetSilverStock(string franchiser_code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@" select  a.product_type_id ,a.product_type_name, a.product_spec_weight,a.trade_add_price as price,b.stock_left/b.product_spec_id  as stock_num,b.stock_left
                                    from  product_type a,stock_main b
                                    where (a.product_type_id=b.product_id and a.product_spec_weight = b.product_spec_id) ");
            strSql.Append("  and a.type='1'  and b.franchiser_code =N'" + franchiser_code + "' and stock_left>0 order by a.product_type_id, a.product_spec_weight ;");

            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 获得经销商数据列表
        /// </summary>
        public DataSet GetFranList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select franchiser_code,franchiser_name,franchiser_balance_money,franchiser_asure_money,franchiser_tel,franchiser_cellphone,franchiser_address,ins_user,ins_date,upd_user,upd_date,IA100GUID ");
            strSql.Append(" FROM franchiser_info ");
            if(strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("trade_id","franchiser_trade");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int trade_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from franchiser_trade");
            strSql.Append(" where trade_id=@trade_id ");
            SqlParameter[] parameters = {
					new SqlParameter("@trade_id", SqlDbType.Int,4)};
            parameters[0].Value = trade_id;

            return DbHelperSQL.Exists(strSql.ToString(),parameters);
        }

        /// <summary>
        /// 获得最新价格 add by yuxiaowei
        /// </summary>
        public DataSet getCurrentPrice()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select realtime_base_price,realtime_time,sys_admin_id from realtime_price");
            strSql.Append(" where [id] in (select max([id]) as [id] from  realtime_price)");

            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(GoldTradeNaming.Model.franchiser_trade model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into franchiser_trade(");
            strSql.Append("franchiser_code,trade_time,realtime_base_price,gold_trade_price,trade_add_price,trade_total_weight,trade_total_money,canceled_reason,trade_state,ins_user,ins_date,upd_user,upd_date)");
            strSql.Append(" values (");
            strSql.Append("@franchiser_code,@trade_time,@realtime_base_price,@gold_trade_price,@trade_add_price,@trade_total_weight,@trade_total_money,@canceled_reason,@trade_state,@ins_user,@ins_date,@upd_user,@upd_date)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@franchiser_code", SqlDbType.SmallInt,2),
					new SqlParameter("@trade_time", SqlDbType.SmallDateTime),
					new SqlParameter("@realtime_base_price", SqlDbType.Money,8),
					new SqlParameter("@gold_trade_price", SqlDbType.Money,8),
					new SqlParameter("@trade_add_price", SqlDbType.Money,8),
					new SqlParameter("@trade_total_weight", SqlDbType.Int,4),
					new SqlParameter("@trade_total_money", SqlDbType.Money,8),
					new SqlParameter("@canceled_reason", SqlDbType.NVarChar,100),
					new SqlParameter("@trade_state", SqlDbType.NVarChar,50),
					new SqlParameter("@ins_user", SqlDbType.NVarChar,50),
					new SqlParameter("@ins_date", SqlDbType.SmallDateTime),
					new SqlParameter("@upd_user", SqlDbType.NVarChar,50),
					new SqlParameter("@upd_date", SqlDbType.SmallDateTime)};
            parameters[0].Value = model.franchiser_code;
            parameters[1].Value = model.trade_time;
            parameters[2].Value = model.realtime_base_price;
            parameters[3].Value = model.gold_trade_price;
            parameters[4].Value = model.trade_add_price;
            parameters[5].Value = model.trade_total_weight;
            parameters[6].Value = model.trade_total_money;
            parameters[7].Value = model.canceled_reason;
            parameters[8].Value = model.trade_state;
            parameters[9].Value = model.ins_user;
            parameters[10].Value = model.ins_date;
            parameters[11].Value = model.upd_user;
            parameters[12].Value = model.upd_date;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
            if(obj == null)
            {
                return 1;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(GoldTradeNaming.Model.franchiser_trade model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update franchiser_trade set ");
            strSql.Append("franchiser_code=@franchiser_code,");
            strSql.Append("trade_time=@trade_time,");
            strSql.Append("realtime_base_price=@realtime_base_price,");
            strSql.Append("gold_trade_price=@gold_trade_price,");
            strSql.Append("trade_add_price=@trade_add_price,");
            strSql.Append("trade_total_weight=@trade_total_weight,");
            strSql.Append("trade_total_money=@trade_total_money,");
            strSql.Append("canceled_reason=@canceled_reason,");
            strSql.Append("trade_state=@trade_state,");
            strSql.Append("ins_user=@ins_user,");
            strSql.Append("ins_date=@ins_date,");
            strSql.Append("upd_user=@upd_user,");
            strSql.Append("upd_date=@upd_date");
            strSql.Append(" where trade_id=@trade_id ");
            SqlParameter[] parameters = {
					new SqlParameter("@trade_id", SqlDbType.Int,4),
					new SqlParameter("@franchiser_code", SqlDbType.SmallInt,2),
					new SqlParameter("@trade_time", SqlDbType.SmallDateTime),
					new SqlParameter("@realtime_base_price", SqlDbType.Money,8),
					new SqlParameter("@gold_trade_price", SqlDbType.Money,8),
					new SqlParameter("@trade_add_price", SqlDbType.Money,8),
					new SqlParameter("@trade_total_weight", SqlDbType.Int,4),
					new SqlParameter("@trade_total_money", SqlDbType.Money,8),
					new SqlParameter("@canceled_reason", SqlDbType.NVarChar,100),
					new SqlParameter("@trade_state", SqlDbType.NVarChar,50),
					new SqlParameter("@ins_user", SqlDbType.NVarChar,50),
					new SqlParameter("@ins_date", SqlDbType.SmallDateTime),
					new SqlParameter("@upd_user", SqlDbType.NVarChar,50),
					new SqlParameter("@upd_date", SqlDbType.SmallDateTime)};
            parameters[0].Value = model.trade_id;
            parameters[1].Value = model.franchiser_code;
            parameters[2].Value = model.trade_time;
            parameters[3].Value = model.realtime_base_price;
            parameters[4].Value = model.gold_trade_price;
            parameters[5].Value = model.trade_add_price;
            parameters[6].Value = model.trade_total_weight;
            parameters[7].Value = model.trade_total_money;
            parameters[8].Value = model.canceled_reason;
            parameters[9].Value = model.trade_state;
            parameters[10].Value = model.ins_user;
            parameters[11].Value = model.ins_date;
            parameters[12].Value = model.upd_user;
            parameters[13].Value = model.upd_date;

            DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int trade_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete franchiser_trade ");
            strSql.Append(" where trade_id=@trade_id ");
            SqlParameter[] parameters = {
					new SqlParameter("@trade_id", SqlDbType.Int,4)};
            parameters[0].Value = trade_id;

            DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public GoldTradeNaming.Model.franchiser_trade GetModel(int trade_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 trade_id,franchiser_code,trade_time,realtime_base_price,gold_trade_price,trade_add_price,trade_total_weight,trade_total_money,canceled_reason,trade_state,ins_user,ins_date,upd_user,upd_date from franchiser_trade ");
            strSql.Append(" where trade_id=@trade_id ");
            SqlParameter[] parameters = {
					new SqlParameter("@trade_id", SqlDbType.Int,4)};
            parameters[0].Value = trade_id;

            GoldTradeNaming.Model.franchiser_trade model = new GoldTradeNaming.Model.franchiser_trade();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(),parameters);
            if(ds.Tables[0].Rows.Count > 0)
            {
                if(ds.Tables[0].Rows[0]["trade_id"].ToString() != "")
                {
                    model.trade_id = int.Parse(ds.Tables[0].Rows[0]["trade_id"].ToString());
                }
                if(ds.Tables[0].Rows[0]["franchiser_code"].ToString() != "")
                {
                    model.franchiser_code = int.Parse(ds.Tables[0].Rows[0]["franchiser_code"].ToString());
                }
                if(ds.Tables[0].Rows[0]["trade_time"].ToString() != "")
                {
                    model.trade_time = DateTime.Parse(ds.Tables[0].Rows[0]["trade_time"].ToString());
                }
                if(ds.Tables[0].Rows[0]["realtime_base_price"].ToString() != "")
                {
                    model.realtime_base_price = decimal.Parse(ds.Tables[0].Rows[0]["realtime_base_price"].ToString());
                }
                if(ds.Tables[0].Rows[0]["gold_trade_price"].ToString() != "")
                {
                    model.gold_trade_price = decimal.Parse(ds.Tables[0].Rows[0]["gold_trade_price"].ToString());
                }
                if(ds.Tables[0].Rows[0]["trade_add_price"].ToString() != "")
                {
                    model.trade_add_price = decimal.Parse(ds.Tables[0].Rows[0]["trade_add_price"].ToString());
                }
                if(ds.Tables[0].Rows[0]["trade_total_weight"].ToString() != "")
                {
                    model.trade_total_weight = int.Parse(ds.Tables[0].Rows[0]["trade_total_weight"].ToString());
                }
                if(ds.Tables[0].Rows[0]["trade_total_money"].ToString() != "")
                {
                    model.trade_total_money = decimal.Parse(ds.Tables[0].Rows[0]["trade_total_money"].ToString());
                }
                model.canceled_reason = ds.Tables[0].Rows[0]["canceled_reason"].ToString();
                model.trade_state = ds.Tables[0].Rows[0]["trade_state"].ToString();
                model.ins_user = ds.Tables[0].Rows[0]["ins_user"].ToString();
                if(ds.Tables[0].Rows[0]["ins_date"].ToString() != "")
                {
                    model.ins_date = DateTime.Parse(ds.Tables[0].Rows[0]["ins_date"].ToString());
                }
                model.upd_user = ds.Tables[0].Rows[0]["upd_user"].ToString();
                if(ds.Tables[0].Rows[0]["upd_date"].ToString() != "")
                {
                    model.upd_date = DateTime.Parse(ds.Tables[0].Rows[0]["upd_date"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select trade_id,franchiser_code,trade_time,realtime_base_price,gold_trade_price,trade_add_price,trade_total_weight,trade_total_money,canceled_reason,trade_state,ins_user,ins_date,upd_user,upd_date ");
            strSql.Append(" FROM franchiser_trade ");
            if(strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "franchiser_trade";
            parameters[1].Value = "ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  成员方法
    }
}

