namespace GoldTradeNaming.DAL
{
    using GoldTradeNaming.Model;
    using Maticsoft.DBUtility;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Text;

    public class CommBaseDAL
    {
        public static decimal GetAddMoneyTotal(int fran_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT SUM(franchiser_added_money) AS TotalMoney FROM franchiser_money");
            strSql.Append(" where franchiser_code=@franchiser_code ");
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@franchiser_code", SqlDbType.Int, 2) };
            parameters[0].Value = fran_id;
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if ((ds.Tables.Count > 0) && (ds.Tables[0].Rows.Count > 0))
            {
                return Convert.ToDecimal(ds.Tables[0].Rows[0][0]);
            }
            return 0.00M;
        }

        /// <summary>
        /// 订货可用余额
        /// </summary>
        /// <param name="franID"></param>
        /// <returns></returns>
        public static decimal GetBalance(int franID)
        {
            decimal Balance = 0.00M;
            GoldTradeNaming.Model.franchiser_info franinfo = GetModel(franID);
            Balance = franinfo.franchiser_balance_money - franinfo.franchiser_asure_money;
            Balance -= GetStockBalance(franID);
            Balance -= GetUnreceivedBalance(franID);
            return (Balance - GetHasSendButUnreceivedBalance(franID));
        }

        public DataSet getCurrentPrice()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select realtime_base_price,realtime_time,sys_admin_id from realtime_price");
            strSql.Append(" where [id] in (select max([id]) as [id] from  realtime_price)");
            return DbHelperSQL.Query(strSql.ToString());
        }

        public decimal GetGoldNoReceiveValue(string sFranchiser_code)
        {
            decimal i = 0M;
            try
            {
                int franchiser_code = Convert.ToInt32(sFranchiser_code);
                string strSql = string.Format("select sum( a.[count]*(b.trade_add_price+c.realtime_base_price)) as goldValue  from \r\n                                            (\r\n                                                select franchiser_order_id,product_id,product_spec_id, isnull(sum(product_unreceived),'0') as [count] from franchiser_order_desc\r\n                                                where franchiser_order_id in (select franchiser_order_id from franchiser_order where  (franchiser_order_state='1' or franchiser_order_state='0') \r\n                                                and franchiser_code=@franchiser_code) \r\n                                                and product_id in (select product_type_id from product_type where type='0')\r\n                                                group by franchiser_order_id,product_id ,product_spec_id\r\n                                            ) a, product_type b,realtime_price c where a.product_id=b.product_type_id and a.product_spec_id=b.product_spec_weight   and c.[id]=(select max([id]) from realtime_price)", new object[0]);
                SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@franchiser_code", SqlDbType.Int, 2) };
                parameters[0].Value = franchiser_code;
                i = Convert.ToDecimal(DbHelperSQL.Query(strSql.ToString(), parameters).Tables[0].Rows[0][0].ToString().Trim());
            }
            catch
            {
            }
            return i;
        }

        public decimal GetGoldStockValue(string sFranchiser_code)
        {
            decimal i = 0M;
            try
            {
                int franchiser_code = Convert.ToInt32(sFranchiser_code);
                string strSql = string.Format("select sum((c.realtime_base_price+a.trade_add_price)*b.stock_left) as goldValue \r\n                                                from realtime_price c, product_type a,stock_main b\r\n                                                where (a.product_type_id=b.product_id and a.product_spec_weight = b.product_spec_id) \r\n                                                and a.type='0' and b.franchiser_code =@franchiser_code\r\n                                                and c.[id]=(select max([id]) as [id] from realtime_price) ", new object[0]);
                SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@franchiser_code", SqlDbType.Int, 2) };
                parameters[0].Value = franchiser_code;
                i = Convert.ToDecimal(DbHelperSQL.Query(strSql.ToString(), parameters).Tables[0].Rows[0][0].ToString().Trim());
            }
            catch
            {
            }
            return i;
        }

        private static decimal GetHasSendButUnreceivedBalance(int franID)
        {
            decimal unreceivedbalance = 0.00M;
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("\r\n              select sum(\r\n\r\n         a.[count]*(b.order_add_price+ c.realtime_base_price)) as goldvalue \r\n        from \r\n        ( \r\n\r\n         select send_id,product_id,product_spec_id, isnull(sum(send_amount_weight),0) as [count] \r\n         from send_desc\r\n         where send_id \r\n           in (select send_id from send_main\r\n         \twhere send_state='0'\r\n         \tand franchiser_order_id \r\n\t\t\tin (select franchiser_order_id from franchiser_order where franchiser_code = @franID) --@franID\r\n              ) \r\n         and product_id \r\n         in (select product_type_id from product_type where type='0') --黄金\r\n         group by send_id,product_id ,product_spec_id\r\n\r\n        ) a \r\n        ,product_type b ,realtime_price c\r\n         where a.product_id=b.product_type_id and a.product_spec_id=b.product_spec_weight  and c.[id]=(select max([id]) from realtime_price)\r\n                ");
                SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@franID", SqlDbType.SmallInt) };
                parameters[0].Value = franID;
                DataSet goldSet = DbHelperSQL.Query(strSql.ToString(), parameters);
                strSql = new StringBuilder();
                strSql.Append("\r\n        select sum( a.[count]*b.order_add_price) as silverValue from \r\n        (\r\n        select send_id,product_id,product_spec_id, isnull(sum(send_amount_weight),0) as [count] \r\n\tfrom send_desc\r\n        where send_id in \r\n             (select send_id from send_main \r\n\t      where send_state='0' \r\n              and franchiser_order_id\r\n\t\t  in (select franchiser_order_id from franchiser_order where franchiser_code = @franID)--@franID\r\n\t     )\r\n        and product_id \r\n\tin (select product_type_id from product_type where type='1') --白银\r\n        group by send_id,product_id,product_spec_id \r\n         ) a ,product_type b where a.product_id=b.product_type_id  and a.product_spec_id=b.product_spec_weight \r\n");
                DataSet silverSet = DbHelperSQL.Query(strSql.ToString(), parameters);
                if ((goldSet.Tables.Count > 0) && (goldSet.Tables[0].Rows.Count > 0))
                {
                    try
                    {
                        unreceivedbalance += Convert.ToDecimal(goldSet.Tables[0].Rows[0][0]);
                    }
                    catch
                    {
                        unreceivedbalance = unreceivedbalance;
                    }
                }
                if ((silverSet.Tables.Count <= 0) || (silverSet.Tables[0].Rows.Count <= 0))
                {
                    return unreceivedbalance;
                }
                try
                {
                    unreceivedbalance += Convert.ToDecimal(silverSet.Tables[0].Rows[0][0]);
                }
                catch
                {
                    unreceivedbalance = unreceivedbalance;
                }
            }
            catch
            {
                unreceivedbalance = 0.00M;
            }
            return unreceivedbalance;
        }

        private static decimal GetHasSendButUnreceivedBalanceForTrade(int franID)
        {
            decimal unreceivedbalance = 0.00M;
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("\r\n              select sum(\r\n\r\n         a.[count]*(b.trade_add_price+ c.realtime_base_price)) as goldvalue \r\n        from \r\n        ( \r\n\r\n         select send_id,product_id,product_spec_id, isnull(sum(send_amount_weight),0) as [count] \r\n         from send_desc\r\n         where send_id \r\n           in (select send_id from send_main\r\n         \twhere send_state='0'\r\n         \tand franchiser_order_id \r\n\t\t\tin (select franchiser_order_id from franchiser_order where franchiser_code = @franID) --@franID\r\n              ) \r\n         and product_id \r\n         in (select product_type_id from product_type where type='0') --黄金\r\n         group by send_id,product_id ,product_spec_id\r\n\r\n        ) a \r\n        ,product_type b ,realtime_price c\r\n         where a.product_id=b.product_type_id and a.product_spec_id=b.product_spec_weight  and c.[id]=(select max([id]) from realtime_price)\r\n                ");
                SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@franID", SqlDbType.SmallInt) };
                parameters[0].Value = franID;
                DataSet goldSet = DbHelperSQL.Query(strSql.ToString(), parameters);
                strSql = new StringBuilder();
                strSql.Append("\r\n        select sum( a.[count]*b.trade_add_price) as silverValue from \r\n        (\r\n        select send_id,product_id,product_spec_id, isnull(sum(send_amount_weight),0) as [count] \r\n\tfrom send_desc\r\n        where send_id in \r\n             (select send_id from send_main \r\n\t      where send_state='0' \r\n              and franchiser_order_id\r\n\t\t  in (select franchiser_order_id from franchiser_order where franchiser_code = @franID)--@franID\r\n\t     )\r\n        and product_id \r\n\tin (select product_type_id from product_type where type='1') --白银\r\n        group by send_id,product_id,product_spec_id \r\n         ) a ,product_type b where a.product_id=b.product_type_id  and a.product_spec_id=b.product_spec_weight \r\n");
                DataSet silverSet = DbHelperSQL.Query(strSql.ToString(), parameters);
                if ((goldSet.Tables.Count > 0) && (goldSet.Tables[0].Rows.Count > 0))
                {
                    try
                    {
                        unreceivedbalance += Convert.ToDecimal(goldSet.Tables[0].Rows[0][0]);
                    }
                    catch
                    {
                        unreceivedbalance = unreceivedbalance;
                    }
                }
                if ((silverSet.Tables.Count <= 0) || (silverSet.Tables[0].Rows.Count <= 0))
                {
                    return unreceivedbalance;
                }
                try
                {
                    unreceivedbalance += Convert.ToDecimal(silverSet.Tables[0].Rows[0][0]);
                }
                catch
                {
                    unreceivedbalance = unreceivedbalance;
                }
            }
            catch
            {
                unreceivedbalance = 0.00M;
            }
            return unreceivedbalance;
        }

        public DataSet GetLeftStock(string franchiser_code)
        {
            return DbHelperSQL.Query(string.Format("select sum(stock_left) as stock_left from stock_main where franchiser_code=N'" + franchiser_code + "'", new object[0]).ToString());
        }

        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select franchiser_order_id,franchiser_code,franchiser_order_trans_type,\r\nfranchiser_order_address,franchiser_order_postcode,franchiser_order_handle_man,\r\nfranchiser_order_handle_tel,franchiser_order_handle_phone,franchiser_order_price,\r\nfranchiser_order_time,franchiser_order_state,franchiser_order_amount_money,\r\ncanceled_reason,ins_user,ins_date,upd_user,upd_date ");
            strSql.Append(" FROM franchiser_order ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        public static GoldTradeNaming.Model.franchiser_info GetModel(int franchiser_code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 franchiser_code,franchiser_name,franchiser_balance_money,franchiser_asure_money,franchiser_tel,franchiser_cellphone,franchiser_address,ins_user,ins_date,upd_user,upd_date,IA100GUID from franchiser_info ");
            strSql.Append(" where franchiser_code=@franchiser_code ");
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@franchiser_code", SqlDbType.SmallInt) };
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
            return null;
        }

        public static int GetNextOrderId()
        {
            int nextorderid = DbHelperSQL.GetMaxID("franchiser_order_id", "franchiser_order");
            if (nextorderid != 1)
            {
                nextorderid = nextorderid % 0x2710;
            }
            nextorderid = (nextorderid / 10) + 1;
            return (((((DateTime.Now.Year - 0x7d0) * 0x5f5e100) + (DateTime.Now.Month * 0xf4240)) + (DateTime.Now.Day * 0x2710)) + (nextorderid * 10));
        }

        public static int GetNextTradeId()
        {
            int nextorderid = DbHelperSQL.GetMaxID("trade_id", "franchiser_trade");
            if (nextorderid != 1)
            {
                nextorderid = nextorderid % 0x3e8;
            }
            nextorderid = (nextorderid / 10) + 1;
            return ((((((DateTime.Now.Year - 0x7d0) * 0x5f5e100) + (DateTime.Now.Month * 0xf4240)) + (DateTime.Now.Day * 0x2710)) + (nextorderid * 10)) + 1);
        }

        public static decimal GetOrderSumByFranId(int franid)
        {
            decimal OrderSum = 0.00M;
            string sql = "SELECT SUM(franchiser_order_amount_money) FROM franchiser_order WHERE franchiser_code = @franID";
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@franID", SqlDbType.SmallInt) };
            parameters[0].Value = franid;
            DataSet ds = DbHelperSQL.Query(sql, parameters);
            if (((ds != null) && (ds.Tables.Count > 0)) && (ds.Tables[0].Rows.Count > 0))
            {
                OrderSum = Convert.ToDecimal(ds.Tables[0].Rows[0][0]);
            }
            return OrderSum;
        }

        public static string GetProductTypeById(string type_id)
        {
            string type = null;
            StringBuilder strQuery = new StringBuilder();
            try
            {
                strQuery.Append("select type ");
                strQuery.Append(" FROM product_type ");
                strQuery.Append("WHERE product_type_id=@type_id");
                SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@type_id", SqlDbType.Int) };
                parameters[0].Value = type_id;
                DataSet dt = DbHelperSQL.Query(strQuery.ToString(), parameters);
                if ((dt != null) && ((dt.Tables.Count > 0) & (dt.Tables[0].Rows.Count > 0)))
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

        public static decimal getRealTimePrice()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select realtime_base_price from realtime_price");
            strSql.Append(" where [id] in (select max([id]) as [id] from  realtime_price)");
            return Convert.ToDecimal(DbHelperSQL.Query(strSql.ToString()).Tables[0].Rows[0][0]);
        }

        public static DataSet GetReportData(string franId, string dateS, string dateE, string franName)
        {
            string sql = "\r\nSELECT a.franchiser_code,a.franchiser_name ,a.franchiser_balance_money,\r\nmoneytotal = (SELECT SUM(b.franchiser_added_money) FROM franchiser_money b \r\n\tWHERE a.franchiser_code = b.franchiser_code AND b.added_time >= @start_time AND b.added_time<=@end_time),\r\nordertotal = (SELECT SUM(c.franchiser_order_amount_money) FROM franchiser_order c \r\n\tWHERE a.franchiser_code = c.franchiser_code  AND c.franchiser_order_time >= @start_time AND c.franchiser_order_time<=@end_time),\r\ntradetotal = (SELECT SUM(d.trade_total_money) FROM franchiser_trade d \r\n\tWHERE a.franchiser_code = d.franchiser_code  AND d.trade_time >= @start_time AND  d.trade_time<=@end_time)\r\nFROM franchiser_info a WHERE a.franchiser_code like  @code AND a.franchiser_name like @name ";
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@code", SqlDbType.VarChar, 20), new SqlParameter("@start_time", SqlDbType.DateTime, 20), new SqlParameter("@end_time", SqlDbType.DateTime, 20), new SqlParameter("@name", SqlDbType.VarChar, 100) };
            if (string.IsNullOrEmpty(franId))
            {
                parameters[0].Value = "%";
            }
            else
            {
                parameters[0].Value = franId;
            }
            parameters[1].Value = string.IsNullOrEmpty(dateS) ? new DateTime(0x7d0, 1, 1) : Convert.ToDateTime(dateS);
            parameters[2].Value = string.IsNullOrEmpty(dateE) ? DateTime.MaxValue : Convert.ToDateTime(dateE).AddMonths(1);
            if (string.IsNullOrEmpty(franName))
            {
                parameters[3].Value = "%";
            }
            else
            {
                parameters[3].Value = franName;
            }
            return DbHelperSQL.Query(sql, parameters);
        }

        public decimal GetSilverNoReceiveValue(string sFranchiser_code)
        {
            decimal i = 0M;
            try
            {
                int franchiser_code = Convert.ToInt32(sFranchiser_code);
                string strSql = string.Format("select sum( a.[count]*b.trade_add_price) as silverValue from \r\n                                            (\r\n                                                select franchiser_order_id,product_id,product_spec_id, isnull(sum(product_unreceived),'0') as [count] from franchiser_order_desc\r\n                                                where franchiser_order_id in (select franchiser_order_id from franchiser_order where  (franchiser_order_state='1' or franchiser_order_state='0') \r\n                                                and franchiser_code=@franchiser_code) \r\n                                                and product_id in (select product_type_id from product_type where type='1')\r\n                                                group by franchiser_order_id,product_id ,product_spec_id\r\n                                             ) a ,product_type b where a.product_id=b.product_type_id  and a.product_spec_id=b.product_spec_weight ", new object[0]);
                SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@franchiser_code", SqlDbType.Int, 2) };
                parameters[0].Value = franchiser_code;
                i = Convert.ToDecimal(DbHelperSQL.Query(strSql.ToString(), parameters).Tables[0].Rows[0][0].ToString().Trim());
            }
            catch
            {
            }
            return i;
        }

        public decimal GetSilverStockValue(string sFranchiser_code)
        {
            decimal i = 0M;
            try
            {
                int franchiser_code = Convert.ToInt32(sFranchiser_code);
                string strSql = string.Format("select sum(a.trade_add_price*b.stock_left) as silverValue \r\n                                                from product_type a,stock_main b\r\n                                                where (a.product_type_id=b.product_id and a.product_spec_weight = b.product_spec_id) \r\n                                                and a.type='1' and b.franchiser_code =@franchiser_code ", new object[0]);
                SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@franchiser_code", SqlDbType.Int, 2) };
                parameters[0].Value = franchiser_code;
                i = Convert.ToDecimal(DbHelperSQL.Query(strSql.ToString(), parameters).Tables[0].Rows[0][0].ToString().Trim());
            }
            catch
            {
            }
            return i;
        }

        private static decimal GetStockBalance(int franID)
        {
            decimal stockbalance = 0.00M;
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select SUM((c.realtime_base_price+a.order_add_price)*b.stock_left) as goldValue \r\n                            from realtime_price c, product_type a,stock_main b\r\n                            where (a.product_type_id=b.product_id and a.product_spec_weight = b.product_spec_id) \r\n                            and a.type='0' and b.franchiser_code =@franID\r\n                            and c.[id]=(select max([id]) as [id] from realtime_price)");
                SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@franID", SqlDbType.SmallInt) };
                parameters[0].Value = franID;
                DataSet goldSet = DbHelperSQL.Query(strSql.ToString(), parameters);
                strSql = new StringBuilder();
                strSql.Append("select total_money = SUM(s.stock_left*p.order_add_price)\r\n                         from stock_main s,product_type p \r\n                        where s.product_id = p.product_type_id and s.product_spec_id = p.product_spec_weight and p.type='1' \r\n                        and franchiser_code = @franID");
                DataSet silverSet = DbHelperSQL.Query(strSql.ToString(), parameters);
                if ((goldSet.Tables.Count > 0) && (goldSet.Tables[0].Rows.Count > 0))
                {
                    try
                    {
                        stockbalance += Convert.ToDecimal(goldSet.Tables[0].Rows[0][0]);
                    }
                    catch
                    {
                        stockbalance = stockbalance;
                    }
                }
                if ((silverSet.Tables.Count <= 0) || (silverSet.Tables[0].Rows.Count <= 0))
                {
                    return stockbalance;
                }
                try
                {
                    stockbalance += Convert.ToDecimal(silverSet.Tables[0].Rows[0][0]);
                }
                catch
                {
                    stockbalance = stockbalance;
                }
            }
            catch
            {
                stockbalance = 0.00M;
            }
            return stockbalance;
        }

        private static decimal GetStockBalanceForTrade(int franID)
        {
            decimal stockbalance = 0.00M;
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select SUM((c.realtime_base_price+a.trade_add_price)*b.stock_left) as goldValue \r\n                            from realtime_price c, product_type a,stock_main b\r\n                            where (a.product_type_id=b.product_id and a.product_spec_weight = b.product_spec_id) \r\n                            and a.type='0' and b.franchiser_code =@franID\r\n                            and c.[id]=(select max([id]) as [id] from realtime_price)");
                SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@franID", SqlDbType.SmallInt) };
                parameters[0].Value = franID;
                DataSet goldSet = DbHelperSQL.Query(strSql.ToString(), parameters);
                strSql = new StringBuilder();
                strSql.Append("select total_money = SUM(s.stock_left*p.trade_add_price)\r\n                         from stock_main s,product_type p \r\n                        where s.product_id = p.product_type_id and s.product_spec_id = p.product_spec_weight and p.type='1' \r\n                        and franchiser_code = @franID");
                DataSet silverSet = DbHelperSQL.Query(strSql.ToString(), parameters);
                if ((goldSet.Tables.Count > 0) && (goldSet.Tables[0].Rows.Count > 0))
                {
                    try
                    {
                        stockbalance += Convert.ToDecimal(goldSet.Tables[0].Rows[0][0]);
                    }
                    catch
                    {
                        stockbalance = stockbalance;
                    }
                }
                if ((silverSet.Tables.Count <= 0) || (silverSet.Tables[0].Rows.Count <= 0))
                {
                    return stockbalance;
                }
                try
                {
                    stockbalance += Convert.ToDecimal(silverSet.Tables[0].Rows[0][0]);
                }
                catch
                {
                    stockbalance = stockbalance;
                }
            }
            catch
            {
                stockbalance = 0.00M;
            }
            return stockbalance;
        }

        public static DataSet GetStockReportData(string franname, string prdname, string dateS, string dateE)
        {
            string sql = "\r\n                   SELECT * FROM (\r\n SELECT a.franchiser_name ,\r\n                    b.product_type_name,b.product_spec_weight,\r\n                    ordertoal = (SELECT SUM(c.order_product_amount) FROM franchiser_order_desc c,franchiser_order d\r\n                    WHERE c.franchiser_order_id = d.franchiser_order_id AND c.product_id = b.product_type_id AND c.product_spec_id=b.product_spec_weight \r\n                    AND d.franchiser_code = a.franchiser_code AND d.franchiser_order_time >= @start_time AND d.franchiser_order_time<=@end_time\r\n                    ),\r\n                    tradetotal = (SELECT SUM(e.trade_amount) FROM franchiser_trade_desc e,franchiser_trade f\r\n                    WHERE e.trade_id = f.trade_id AND e.product_id = b.product_type_id AND e.product_spec_id = b.product_spec_weight AND f.franchiser_code=a.franchiser_code\r\n                     AND f.trade_time >= @start_time AND  f.trade_time<=@end_time),\r\n                    stock_total = (SELECT CAST(g.stock_total/g.product_spec_id AS INT) FROM stock_main g\r\n                    WHERE g.franchiser_code = a.franchiser_code AND g.product_id = b.product_type_id AND g.product_spec_id =b.product_spec_weight \r\n                    ),\r\n                    stock_left = (SELECT CAST(h.stock_left/h.product_spec_id AS INT) FROM stock_main h \r\n                    WHERE h.franchiser_code = a.franchiser_code AND h.product_id = b.product_type_id AND h.product_spec_id =b.product_spec_weight \r\n                    )\r\n                    FROM product_type b ,franchiser_info a\r\n                    WHERE a.franchiser_name LIKE  @code AND b.product_type_name LIKE @prd_name \r\n                   \r\n) AS TBL\r\n WHERE ordertoal>0 OR tradetotal>0 OR stock_left>0 \r\nORDER BY franchiser_name,product_type_name,product_spec_weight\r\n                    ";
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@code", SqlDbType.VarChar, 100), new SqlParameter("@prd_name", SqlDbType.VarChar, 100), new SqlParameter("@start_time", SqlDbType.DateTime, 20), new SqlParameter("@end_time", SqlDbType.DateTime, 20) };
            if (string.IsNullOrEmpty(franname))
            {
                parameters[0].Value = "%";
            }
            else
            {
                parameters[0].Value = franname;
            }
            if (string.IsNullOrEmpty(prdname))
            {
                parameters[1].Value = "%";
            }
            else
            {
                parameters[1].Value = prdname;
            }
            parameters[2].Value = string.IsNullOrEmpty(dateS) ? new DateTime(0x7d0, 1, 1) : Convert.ToDateTime(dateS);
            parameters[3].Value = string.IsNullOrEmpty(dateE) ? DateTime.MaxValue : Convert.ToDateTime(dateE).AddMonths(1);
            return DbHelperSQL.Query(sql, parameters);
        }

        public DataSet GetSumNoReceive(string franchiser_code)
        {
            return DbHelperSQL.Query(string.Format("select isnull(sum(product_unreceived),'0') as [sum] \r\n                                            from franchiser_order_desc \r\n                                            where franchiser_order_id in (select franchiser_order_id from franchiser_order \r\n                                            where franchiser_code=N'" + franchiser_code + "' and (franchiser_order_state='0' or franchiser_order_state='2'))", new object[0]).ToString());
        }

        /// <summary>
        /// 点价可用余额
        /// </summary>
        /// <param name="franID"></param>
        /// <returns></returns>
        public static decimal GetTradeBalance(int franID)
        {
            decimal Balance = 0.00M;
            GoldTradeNaming.Model.franchiser_info franinfo = GetModel(franID);
            Balance = franinfo.franchiser_balance_money - franinfo.franchiser_asure_money;
            Balance -= GetStockBalanceForTrade(franID);
            Balance -= GetUnreceivedBalanceForTrade(franID);
            return (Balance - GetHasSendButUnreceivedBalanceForTrade(franID));
        }

        public static decimal GetTradeSumByFranId(int franid)
        {
            decimal TradeSum = 0.00M;
            string sql = "SELECT SUM(trade_total_money) FROM franchiser_trade WHERE franchiser_code = @franID";
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@franID", SqlDbType.SmallInt) };
            parameters[0].Value = franid;
            DataSet ds = DbHelperSQL.Query(sql, parameters);
            if (((ds != null) && (ds.Tables.Count > 0)) && (ds.Tables[0].Rows.Count > 0))
            {
                TradeSum = Convert.ToDecimal(ds.Tables[0].Rows[0][0]);
            }
            return TradeSum;
        }

        private static decimal GetUnreceivedBalance(int franID)
        {
            decimal unreceivedbalance = 0.00M;
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("\r\n            select sum(\r\n\r\n             a.[count]*(b.order_add_price+ c.realtime_base_price)) as goldvalue \r\n            from \r\n            ( \r\n\r\n            select franchiser_order_id,product_id,product_spec_id, isnull(sum(product_unreceived),0) \r\n             as [count] from franchiser_order_desc\r\n             where franchiser_order_id \r\n             in (select franchiser_order_id from franchiser_order\r\n             where (franchiser_order_state='1' or franchiser_order_state='0')\r\n             and franchiser_code=@franID) \r\n             and product_id \r\n             in (select product_type_id from product_type where type='0')\r\n             group by franchiser_order_id,product_id ,product_spec_id\r\n\r\n            ) a \r\n            ,product_type b ,realtime_price c\r\n             where a.product_id=b.product_type_id and a.product_spec_id=b.product_spec_weight  and c.[id]=(select max([id]) from realtime_price)\r\n                    ");
                SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@franID", SqlDbType.SmallInt) };
                parameters[0].Value = franID;
                DataSet goldSet = DbHelperSQL.Query(strSql.ToString(), parameters);
                strSql = new StringBuilder();
                strSql.Append("select sum( a.[count]*b.order_add_price) as silverValue from \r\n                            (\r\n                            select franchiser_order_id,product_id,product_spec_id, isnull(sum(product_unreceived),0) as [count] from franchiser_order_desc\r\n                            where franchiser_order_id in \r\n                            (select franchiser_order_id from franchiser_order where  \r\n                            (franchiser_order_state='1' or franchiser_order_state='0') \r\n                             and franchiser_code=@franID) \r\n                            and product_id in (select product_type_id from product_type where type='1')\r\n                            group by franchiser_order_id,product_id,product_spec_id \r\n                             ) a ,product_type b where a.product_id=b.product_type_id  and a.product_spec_id=b.product_spec_weight ");
                DataSet silverSet = DbHelperSQL.Query(strSql.ToString(), parameters);
                if ((goldSet.Tables.Count > 0) && (goldSet.Tables[0].Rows.Count > 0))
                {
                    try
                    {
                        unreceivedbalance += Convert.ToDecimal(goldSet.Tables[0].Rows[0][0]);
                    }
                    catch
                    {
                        unreceivedbalance = unreceivedbalance;
                    }
                }
                if ((silverSet.Tables.Count <= 0) || (silverSet.Tables[0].Rows.Count <= 0))
                {
                    return unreceivedbalance;
                }
                try
                {
                    unreceivedbalance += Convert.ToDecimal(silverSet.Tables[0].Rows[0][0]);
                }
                catch
                {
                    unreceivedbalance = unreceivedbalance;
                }
            }
            catch
            {
                unreceivedbalance = 0.00M;
            }
            return unreceivedbalance;
        }

        private static decimal GetUnreceivedBalanceForTrade(int franID)
        {
            decimal unreceivedbalance = 0.00M;
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("\r\n            select sum(\r\n\r\n             a.[count]*(b.trade_add_price+ c.realtime_base_price)) as goldvalue \r\n            from \r\n            ( \r\n\r\n            select franchiser_order_id,product_id,product_spec_id, isnull(sum(product_unreceived),0) \r\n             as [count] from franchiser_order_desc\r\n             where franchiser_order_id \r\n             in (select franchiser_order_id from franchiser_order\r\n             where (franchiser_order_state='1' or franchiser_order_state='0')\r\n             and franchiser_code=@franID) \r\n             and product_id \r\n             in (select product_type_id from product_type where type='0')\r\n             group by franchiser_order_id,product_id ,product_spec_id\r\n\r\n            ) a \r\n            ,product_type b ,realtime_price c\r\n             where a.product_id=b.product_type_id and a.product_spec_id=b.product_spec_weight  and c.[id]=(select max([id]) from realtime_price)\r\n                    ");
                SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@franID", SqlDbType.SmallInt) };
                parameters[0].Value = franID;
                DataSet goldSet = DbHelperSQL.Query(strSql.ToString(), parameters);
                strSql = new StringBuilder();
                strSql.Append("select sum( a.[count]*b.trade_add_price) as silverValue from \r\n                            (\r\n                            select franchiser_order_id,product_id,product_spec_id, isnull(sum(product_unreceived),0) as [count] from franchiser_order_desc\r\n                            where franchiser_order_id in \r\n                            (select franchiser_order_id from franchiser_order where  \r\n                            (franchiser_order_state='1' or franchiser_order_state='0') \r\n                             and franchiser_code=@franID) \r\n                            and product_id in (select product_type_id from product_type where type='1')\r\n                            group by franchiser_order_id,product_id,product_spec_id \r\n                             ) a ,product_type b where a.product_id=b.product_type_id  and a.product_spec_id=b.product_spec_weight ");
                DataSet silverSet = DbHelperSQL.Query(strSql.ToString(), parameters);
                if ((goldSet.Tables.Count > 0) && (goldSet.Tables[0].Rows.Count > 0))
                {
                    try
                    {
                        unreceivedbalance += Convert.ToDecimal(goldSet.Tables[0].Rows[0][0]);
                    }
                    catch
                    {
                        unreceivedbalance = unreceivedbalance;
                    }
                }
                if ((silverSet.Tables.Count <= 0) || (silverSet.Tables[0].Rows.Count <= 0))
                {
                    return unreceivedbalance;
                }
                try
                {
                    unreceivedbalance += Convert.ToDecimal(silverSet.Tables[0].Rows[0][0]);
                }
                catch
                {
                    unreceivedbalance = unreceivedbalance;
                }
            }
            catch
            {
                unreceivedbalance = 0.00M;
            }
            return unreceivedbalance;
        }

        public static bool HasRight(int sys_admin_id, string modelID)
        {
            return DbHelperSQL.Exists(string.Format("select * from sys_admin_authority where\r\n                                            sys_admin_id='{0}' and sys_module='{1}'", sys_admin_id, modelID).ToString());
        }
    }
}
