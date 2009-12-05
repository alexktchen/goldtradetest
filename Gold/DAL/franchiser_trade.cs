namespace GoldTradeNaming.DAL
{
    using GoldTradeNaming.Model;
    using Maticsoft.DBUtility;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Text;

    public class franchiser_trade
    {
        private static readonly object _sync = new object();

        public int Add(GoldTradeNaming.Model.franchiser_trade model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into franchiser_trade(");
            strSql.Append("franchiser_code,trade_time,realtime_base_price,gold_trade_price,trade_add_price,trade_total_weight,trade_total_money,canceled_reason,trade_state,ins_user,ins_date,upd_user,upd_date)");
            strSql.Append(" values (");
            strSql.Append("@franchiser_code,@trade_time,@realtime_base_price,@gold_trade_price,@trade_add_price,@trade_total_weight,@trade_total_money,@canceled_reason,@trade_state,@ins_user,@ins_date,@upd_user,@upd_date)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@franchiser_code", SqlDbType.SmallInt, 2), new SqlParameter("@trade_time", SqlDbType.SmallDateTime), new SqlParameter("@realtime_base_price", SqlDbType.Money, 8), new SqlParameter("@gold_trade_price", SqlDbType.Money, 8), new SqlParameter("@trade_add_price", SqlDbType.Money, 8), new SqlParameter("@trade_total_weight", SqlDbType.Int, 4), new SqlParameter("@trade_total_money", SqlDbType.Money, 8), new SqlParameter("@canceled_reason", SqlDbType.NVarChar, 100), new SqlParameter("@trade_state", SqlDbType.NVarChar, 50), new SqlParameter("@ins_user", SqlDbType.NVarChar, 50), new SqlParameter("@ins_date", SqlDbType.SmallDateTime), new SqlParameter("@upd_user", SqlDbType.NVarChar, 50), new SqlParameter("@upd_date", SqlDbType.SmallDateTime) };
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
            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 1;
            }
            return Convert.ToInt32(obj);
        }

        public bool AddTrandeInfo(List<ProductInfo> prInfos, TradeInfo trInfo, string iType)
        {
            lock (_sync)
            {
                SqlConnection conn;
                SqlTransaction trans;
                SqlCommand cmd;
                int maxID;
                int result;
                StringBuilder strSql;
                SqlParameter[] parameters;
                StringBuilder sb1;
                SqlParameter[] parameters_sb1;
                SqlParameter[] parameters2;
                if (iType == "0")
                {
                    using (conn = new SqlConnection(PubConstant.ConnectionString))
                    {
                        conn.Open();
                        using (trans = conn.BeginTransaction())
                        {
                            cmd = new SqlCommand();
                            try
                            {
                                maxID = CommBaseDAL.GetNextTradeId();
                                result = 0;
                                strSql = new StringBuilder();
                                strSql.Append("insert into franchiser_trade(");
                                strSql.Append("trade_id,franchiser_code,trade_time,realtime_base_price,trade_total_weight,trade_total_money,trade_state,ins_user,upd_user)");
                                strSql.Append(" values (");
                                strSql.Append(" @trade_id,@franchiser_code,getdate(),@realtime_base_price,@trade_total_weight,@trade_total_money,@trade_state,@ins_user,@upd_user) ");
                                strSql.Append(" update franchiser_info set franchiser_balance_money=franchiser_balance_money-@trade_total_money,upd_date=getdate(),upd_user=@upd_user where franchiser_code=@franchiser_code");
                                parameters = new SqlParameter[] { new SqlParameter("@trade_id", SqlDbType.Int, 4), new SqlParameter("@franchiser_code", SqlDbType.SmallInt, 2), new SqlParameter("@realtime_base_price", SqlDbType.Money, 50), new SqlParameter("@trade_total_weight", SqlDbType.Money, 8), new SqlParameter("@trade_total_money", SqlDbType.Money, 8), new SqlParameter("@trade_state", SqlDbType.NVarChar, 50), new SqlParameter("@ins_user", SqlDbType.NVarChar, 50), new SqlParameter("@upd_user", SqlDbType.NVarChar, 50) };
                                parameters[0].Value = maxID;
                                parameters[1].Value = trInfo.FranchiserCode;
                                parameters[2].Value = trInfo.RealTimePrice;
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
                                foreach (ProductInfo prInfo in prInfos)
                                {
                                    sb1 = new StringBuilder();
                                    sb1.Append("select stock_left from stock_main  ");
                                    sb1.Append(" where franchiser_code=@francode2 ");
                                    sb1.Append(" and product_id=@product_id and product_spec_id=@product_spec_id");
                                    parameters_sb1 = new SqlParameter[] { new SqlParameter("@francode2", SqlDbType.Int, 4), new SqlParameter("@product_id", SqlDbType.Int, 4), new SqlParameter("@product_spec_id", SqlDbType.Decimal, 4) };
                                    parameters_sb1[0].Value = trInfo.FranchiserCode;
                                    parameters_sb1[1].Value = prInfo.ProductID;
                                    parameters_sb1[2].Value = prInfo.ProductSpecID;
                                    cmd = new SqlCommand();
                                    cmd.CommandText = sb1.ToString();
                                    cmd.Transaction = trans;
                                    cmd.Connection = conn;
                                    cmd.Parameters.AddRange(parameters_sb1);
                                    if (Convert.ToDecimal(cmd.ExecuteScalar()) < prInfo.TradeWeight)
                                    {
                                        throw new Exception("重复交易！");
                                    }
                                    cmd = new SqlCommand();
                                    strSql = new StringBuilder();
                                    strSql.Append("insert into franchiser_trade_desc(");
                                    strSql.Append("trade_id,product_id,product_spec_id,realtime_base_price,trade_add_price,gold_trade_price,trade_amount,trade_weight,trade_money,ins_user,upd_user)");
                                    strSql.Append(" values (");
                                    strSql.Append("@trade_id2,@product_id,@product_spec_id,@realtime_base_price,@trade_add_price,@gold_trade_price,@trade_amount,@trade_weight,@trade_money,@ins_user2,@upd_user2); ");
                                    strSql.Append(" update stock_main set stock_left=@stockleft,upd_user=@upd_user2,upd_date=getdate() ");
                                    strSql.Append(" where franchiser_code=@franchiser_code2 and product_id=@product_id and product_spec_id=@product_spec_id; ");
                                    parameters2 = new SqlParameter[] { new SqlParameter("@trade_id2", SqlDbType.Int, 4), new SqlParameter("@product_id", SqlDbType.Int, 4), new SqlParameter("@product_spec_id", SqlDbType.Money, 8), new SqlParameter("@realtime_base_price", SqlDbType.Money, 8), new SqlParameter("@trade_add_price", SqlDbType.Money, 8), new SqlParameter("@gold_trade_price", SqlDbType.Money, 8), new SqlParameter("@trade_amount", SqlDbType.Int, 4), new SqlParameter("@trade_weight", SqlDbType.Money, 8), new SqlParameter("@trade_money", SqlDbType.Money, 8), new SqlParameter("@ins_user2", SqlDbType.NVarChar, 50), new SqlParameter("@upd_user2", SqlDbType.NVarChar, 50), new SqlParameter("@stockleft", SqlDbType.Money, 8), new SqlParameter("@franchiser_code2", SqlDbType.NVarChar, 50) };
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
                            catch (Exception ex)
                            {
                                trans.Rollback();
                                throw ex;
                            }
                        }
                    }
                }
                if (iType == "1")
                {
                    using (conn = new SqlConnection(PubConstant.ConnectionString))
                    {
                        conn.Open();
                        using (trans = conn.BeginTransaction())
                        {
                            cmd = new SqlCommand();
                            try
                            {
                                maxID = CommBaseDAL.GetNextTradeId();
                                result = 0;
                                strSql = new StringBuilder();
                                strSql.Append("insert into franchiser_trade(");
                                strSql.Append("trade_id,franchiser_code,trade_time,trade_total_weight,trade_total_money,trade_state,ins_user,upd_user)");
                                strSql.Append(" values (");
                                strSql.Append(" @trade_id,@franchiser_code,getdate(),@trade_total_weight,@trade_total_money,@trade_state,@ins_user,@upd_user) ");
                                strSql.Append(" update franchiser_info set franchiser_balance_money=franchiser_balance_money-@trade_total_money,upd_date=getdate(),upd_user=@upd_user where franchiser_code=@franchiser_code");
                                parameters = new SqlParameter[] { new SqlParameter("@trade_id", SqlDbType.Int, 4), new SqlParameter("@franchiser_code", SqlDbType.SmallInt, 2), new SqlParameter("@trade_total_weight", SqlDbType.Money, 8), new SqlParameter("@trade_total_money", SqlDbType.Money, 8), new SqlParameter("@trade_state", SqlDbType.NVarChar, 50), new SqlParameter("@ins_user", SqlDbType.NVarChar, 50), new SqlParameter("@upd_user", SqlDbType.NVarChar, 50) };
                                parameters[0].Value = maxID;
                                parameters[1].Value = trInfo.FranchiserCode;
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
                                foreach (ProductInfo prInfo in prInfos)
                                {
                                    sb1 = new StringBuilder();
                                    sb1.Append("select stock_left from stock_main  ");
                                    sb1.Append(" where franchiser_code=@francode2 ");
                                    sb1.Append(" and product_id=@product_id and product_spec_id=@product_spec_id");
                                    parameters_sb1 = new SqlParameter[] { new SqlParameter("@francode2", SqlDbType.Int, 4), new SqlParameter("@product_id", SqlDbType.Int, 4), new SqlParameter("@product_spec_id", SqlDbType.Decimal, 4) };
                                    parameters_sb1[0].Value = trInfo.FranchiserCode;
                                    parameters_sb1[1].Value = prInfo.ProductID;
                                    parameters_sb1[2].Value = prInfo.ProductSpecID;
                                    cmd = new SqlCommand();
                                    cmd.CommandText = sb1.ToString();
                                    cmd.Transaction = trans;
                                    cmd.Connection = conn;
                                    cmd.Parameters.AddRange(parameters_sb1);
                                    if (Convert.ToDecimal(cmd.ExecuteScalar()) < prInfo.TradeWeight)
                                    {
                                        throw new Exception("重复交易！");
                                    }
                                    cmd = new SqlCommand();
                                    strSql = new StringBuilder();
                                    strSql.Append("insert into franchiser_trade_desc(");
                                    strSql.Append("trade_id,product_id,product_spec_id,gold_trade_price,trade_amount,trade_weight,trade_money,ins_user,upd_user)");
                                    strSql.Append(" values (");
                                    strSql.Append("@trade_id2,@product_id,@product_spec_id,@gold_trade_price,@trade_amount,@trade_weight,@trade_money,@ins_user2,@upd_user2); ");
                                    strSql.Append(" update stock_main set stock_left=@stockleft,upd_user=@upd_user2,upd_date=getdate() ");
                                    strSql.Append(" where franchiser_code=@franchiser_code2 and product_id=@product_id and product_spec_id=@product_spec_id; ");
                                    parameters2 = new SqlParameter[] { new SqlParameter("@trade_id2", SqlDbType.Int, 4), new SqlParameter("@product_id", SqlDbType.Int, 4), new SqlParameter("@product_spec_id", SqlDbType.Money, 8), new SqlParameter("@gold_trade_price", SqlDbType.Int, 4), new SqlParameter("@trade_amount", SqlDbType.Int, 4), new SqlParameter("@trade_weight", SqlDbType.Money, 8), new SqlParameter("@trade_money", SqlDbType.Money, 8), new SqlParameter("@ins_user2", SqlDbType.NVarChar, 50), new SqlParameter("@upd_user2", SqlDbType.NVarChar, 50), new SqlParameter("@stockleft", SqlDbType.Money, 8), new SqlParameter("@franchiser_code2", SqlDbType.NVarChar, 50) };
                                    parameters2[0].Value = maxID;
                                    parameters2[1].Value = prInfo.ProductID;
                                    parameters2[2].Value = prInfo.ProductSpecID;
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
                }
                return false;
            }
        }

        public void Delete(int trade_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete franchiser_trade ");
            strSql.Append(" where trade_id=@trade_id ");
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@trade_id", SqlDbType.Int, 4) };
            parameters[0].Value = trade_id;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        public bool Exists(int trade_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from franchiser_trade");
            strSql.Append(" where trade_id=@trade_id ");
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@trade_id", SqlDbType.Int, 4) };
            parameters[0].Value = trade_id;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        public DataSet GetAllTrade(int franchiser_code, int trade_id, DateTime dtFrom, DateTime dtTo, bool isInit)
        {
            string strQuery = "";
            if (isInit)
            {
                strQuery = string.Format("select top 50 * from franchiser_trade where franchiser_code=@franchiser_code order by trade_time desc ", new object[0]);
            }
            else
            {
                strQuery = string.Format("select * from franchiser_trade where franchiser_code=@franchiser_code  ", new object[0]);
                if (trade_id != -1)
                {
                    strQuery = strQuery + "And trade_id=@trade_id ";
                }
                if (dtFrom.CompareTo(new DateTime(0x76c, 1, 1)) != 0)
                {
                    strQuery = strQuery + " And trade_time>=@dtFrom ";
                }
                if (dtTo.CompareTo(new DateTime(0x76c, 1, 1)) != 0)
                {
                    strQuery = strQuery + " And trade_time<@dtTo ";
                }
                strQuery = strQuery + " order by trade_time desc ";
            }
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@franchiser_code", SqlDbType.SmallInt, 2), new SqlParameter("@trade_id", SqlDbType.Int, 4), new SqlParameter("@dtFrom", SqlDbType.SmallDateTime, 8), new SqlParameter("@dtTo", SqlDbType.SmallDateTime, 8) };
            parameters[0].Value = franchiser_code;
            parameters[1].Value = trade_id;
            parameters[2].Value = dtFrom;
            parameters[3].Value = dtTo.AddDays(1.0);
            return DbHelperSQL.Query(strQuery, parameters);
        }

        public DataSet getCurrentPrice()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select realtime_base_price,realtime_time,sys_admin_id from realtime_price");
            strSql.Append(" where [id] in (select max([id]) as [id] from  realtime_price)");
            return DbHelperSQL.Query(strSql.ToString());
        }

        public DataSet GetFranList(int fran_code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select franchiser_code,franchiser_name,franchiser_balance_money,franchiser_asure_money,franchiser_tel,franchiser_cellphone,franchiser_address,ins_user,ins_date,upd_user,upd_date,IA100GUID FROM franchiser_info where franchiser_code=@franchiser_code ");
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@franchiser_code", SqlDbType.SmallInt, 2) };
            parameters[0].Value = fran_code;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

        public DataSet GetGoldNoReceive(string sFranchiser_code)
        {
            int franchiser_code = Convert.ToInt32(sFranchiser_code);
            string strSql = string.Format("select distinct a.*,b.trade_add_price from (\r\n                                            select franchiser_order_id,product_id, isnull(sum(product_unreceived),'0') as [count] from franchiser_order_desc \r\n                                            where franchiser_order_id in (select franchiser_order_id from franchiser_order where (franchiser_order_state='1' or franchiser_order_state='0') \r\n                                            and franchiser_code=@franchiser_code)\r\n                                            and product_id in (select product_type_id from product_type where type='0')\r\n                                            group by franchiser_order_id,product_id ) a inner  join product_type b on a.product_id=b.product_type_id", new object[0]);
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@franchiser_code", SqlDbType.SmallInt, 2) };
            parameters[0].Value = franchiser_code;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

        public decimal GetGoldNoReceiveValue(int franchiser_code)
        {
            string strSql = string.Format("select sum(a.[count]*(b.trade_add_price+c.realtime_base_price)) as goldValue  from \r\n                                            (\r\n                                                select franchiser_order_id,product_id,product_spec_id, isnull(sum(product_unreceived),0) as [count] from franchiser_order_desc\r\n                                                where franchiser_order_id in (select franchiser_order_id from franchiser_order where  (franchiser_order_state='1' or franchiser_order_state='0') \r\n                                                and franchiser_code=@franchiser_code) \r\n                                                and product_id in (select product_type_id from product_type where type='0')\r\n                                                group by franchiser_order_id,product_id ,product_spec_id\r\n                                            ) a, product_type b,realtime_price c where a.product_id=b.product_type_id and a.product_spec_id=b.product_spec_weight   and c.[id]=(select max([id]) from realtime_price)", new object[0]);
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@franchiser_code", SqlDbType.SmallInt, 2) };
            parameters[0].Value = franchiser_code;
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            decimal i = 0M;
            try
            {
                i = Convert.ToDecimal(ds.Tables[0].Rows[0][0].ToString().Trim());
            }
            catch
            {
            }
            return i;
        }

        public DataSet GetGoldStock(int franchiser_code)
        {
            string strSql = string.Format("select c.realtime_base_price , a.product_type_id ,a.product_type_name,a.trade_add_price, a.product_spec_weight,b.stock_left/b.product_spec_id as stock_num,b.stock_left\r\n                                            from realtime_price c, product_type a,stock_main b\r\n                                            where (a.product_type_id=b.product_id and a.product_spec_weight = b.product_spec_id) \r\n                                            and a.type='0' and b.franchiser_code =@franchiser_code and stock_left>0\r\n                                            and c.[id]=(select max([id]) as [id] from realtime_price) order by  a.product_type_id, a.product_spec_weight ;", new object[0]);
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@franchiser_code", SqlDbType.SmallInt, 2) };
            parameters[0].Value = franchiser_code;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

        public decimal GetGoldStockValue(int franchiser_code)
        {
            string strSql = string.Format("select sum((c.realtime_base_price+a.trade_add_price)*b.stock_left) as goldValue \r\n                                                from realtime_price c, product_type a,stock_main b\r\n                                                where (a.product_type_id=b.product_id and a.product_spec_weight = b.product_spec_id) \r\n                                                and a.type='0' and b.franchiser_code =@franchiser_code\r\n                                                and c.[id]=(select max([id]) as [id] from realtime_price) ", new object[0]);
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@franchiser_code", SqlDbType.SmallInt, 2) };
            parameters[0].Value = franchiser_code;
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            decimal i = 0M;
            try
            {
                i = Convert.ToDecimal(ds.Tables[0].Rows[0][0].ToString().Trim());
            }
            catch
            {
            }
            return i;
        }

        public DataSet GetLeftStock(string sFranchiser_code)
        {
            int franchiser_code = Convert.ToInt32(sFranchiser_code);
            string strSql = string.Format("select sum(stock_left) as stock_left from stock_main where franchiser_code=@franchiser_code; ", new object[0]) + string.Format("select a.product_id,a.product_spec_id ,a.stock_left*b.trade_add_price as [count] from stock_main a inner join product_type b \r\non a.product_id=b.product_type_id and a.product_spec_id=product_spec_weight where franchiser_code=@franchiser_code; ", new object[0]);
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@franchiser_code", SqlDbType.SmallInt, 2) };
            parameters[0].Value = franchiser_code;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("trade_id", "franchiser_trade");
        }

        public GoldTradeNaming.Model.franchiser_trade GetModel(int trade_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 trade_id,franchiser_code,trade_time,realtime_base_price,gold_trade_price,trade_add_price,trade_total_weight,trade_total_money,canceled_reason,trade_state,ins_user,ins_date,upd_user,upd_date from franchiser_trade ");
            strSql.Append(" where trade_id=@trade_id ");
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@trade_id", SqlDbType.Int, 4) };
            parameters[0].Value = trade_id;
            GoldTradeNaming.Model.franchiser_trade model = new GoldTradeNaming.Model.franchiser_trade();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["trade_id"].ToString() != "")
                {
                    model.trade_id = int.Parse(ds.Tables[0].Rows[0]["trade_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["franchiser_code"].ToString() != "")
                {
                    model.franchiser_code = int.Parse(ds.Tables[0].Rows[0]["franchiser_code"].ToString());
                }
                if (ds.Tables[0].Rows[0]["trade_time"].ToString() != "")
                {
                    model.trade_time = DateTime.Parse(ds.Tables[0].Rows[0]["trade_time"].ToString());
                }
                if (ds.Tables[0].Rows[0]["realtime_base_price"].ToString() != "")
                {
                    model.realtime_base_price = decimal.Parse(ds.Tables[0].Rows[0]["realtime_base_price"].ToString());
                }
                if (ds.Tables[0].Rows[0]["gold_trade_price"].ToString() != "")
                {
                    model.gold_trade_price = decimal.Parse(ds.Tables[0].Rows[0]["gold_trade_price"].ToString());
                }
                if (ds.Tables[0].Rows[0]["trade_add_price"].ToString() != "")
                {
                    model.trade_add_price = decimal.Parse(ds.Tables[0].Rows[0]["trade_add_price"].ToString());
                }
                if (ds.Tables[0].Rows[0]["trade_total_weight"].ToString() != "")
                {
                    model.trade_total_weight = int.Parse(ds.Tables[0].Rows[0]["trade_total_weight"].ToString());
                }
                if (ds.Tables[0].Rows[0]["trade_total_money"].ToString() != "")
                {
                    model.trade_total_money = decimal.Parse(ds.Tables[0].Rows[0]["trade_total_money"].ToString());
                }
                model.canceled_reason = ds.Tables[0].Rows[0]["canceled_reason"].ToString();
                model.trade_state = ds.Tables[0].Rows[0]["trade_state"].ToString();
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
                return model;
            }
            return null;
        }

        public decimal GetSilverNoReceiveValue(int franchiser_code)
        {
            string strSql = string.Format("select sum(a.[count]*b.trade_add_price) as silverValue from \r\n                                            (\r\n                                                select franchiser_order_id,product_id,product_spec_id, isnull(sum(product_unreceived),0) as [count] from franchiser_order_desc\r\n                                                where franchiser_order_id in (select franchiser_order_id from franchiser_order where  (franchiser_order_state='1' or franchiser_order_state='0') \r\n                                                and franchiser_code=@franchiser_code) \r\n                                                and product_id in (select product_type_id from product_type where type='1')\r\n                                                group by franchiser_order_id,product_id ,product_spec_id\r\n                                             ) a ,product_type b where a.product_id=b.product_type_id  and a.product_spec_id=b.product_spec_weight ", new object[0]);
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@franchiser_code", SqlDbType.SmallInt, 2) };
            parameters[0].Value = franchiser_code;
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            decimal i = 0M;
            try
            {
                i = Convert.ToDecimal(ds.Tables[0].Rows[0][0].ToString().Trim());
            }
            catch
            {
            }
            return i;
        }

        public DataSet GetSilverStock(int franchiser_code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select  a.product_type_id ,a.product_type_name, a.product_spec_weight,a.trade_add_price as price,b.stock_left/b.product_spec_id  as stock_num,b.stock_left\r\n                                    from  product_type a,stock_main b\r\n                                    where (a.product_type_id=b.product_id and a.product_spec_weight = b.product_spec_id) ");
            strSql.Append("  and a.type='1'  and b.franchiser_code =@franchiser_code and stock_left>0 order by a.product_type_id, a.product_spec_weight ;");
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@franchiser_code", SqlDbType.SmallInt, 2) };
            parameters[0].Value = franchiser_code;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

        public decimal GetSilverStockValue(int franchiser_code)
        {
            string strSql = string.Format("select sum(a.trade_add_price*b.stock_left) as silverValue \r\n                                                from product_type a,stock_main b\r\n                                                where (a.product_type_id=b.product_id and a.product_spec_weight = b.product_spec_id) \r\n                                                and a.type='1' and b.franchiser_code =@franchiser_code ", new object[0]);
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@franchiser_code", SqlDbType.SmallInt, 2) };
            parameters[0].Value = franchiser_code;
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            decimal i = 0M;
            try
            {
                i = Convert.ToDecimal(ds.Tables[0].Rows[0][0].ToString().Trim());
            }
            catch
            {
            }
            return i;
        }

        public DataSet GetTradeAdd(int product_id)
        {
            string strSql = string.Format("select trade_add_price from product_type where product_type_id=@product_id ; ", new object[0]);
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@product_id", SqlDbType.Int, 4) };
            parameters[0].Value = product_id;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

        public DataSet GetTradeByM(int franchiser_code, int trade_id, string franchiser_name, bool isInit)
        {
            StringBuilder strSql = new StringBuilder();
            if (isInit)
            {
                strSql.Append("select top 50 a.*,b.franchiser_name from franchiser_trade a left join franchiser_info b on a.franchiser_code=b.franchiser_code order by a.trade_time desc ");
            }
            else
            {
                strSql.Append("select a.*,b.franchiser_name  from franchiser_trade a left join franchiser_info b  on a.franchiser_code=b.franchiser_code where 1=1 ");
                if (franchiser_code != -1)
                {
                    strSql.Append(" And a.franchiser_code=@franchiser_code ");
                }
                if (trade_id != -1)
                {
                    strSql.Append(" And a.trade_id=@trade_id ");
                }
                if (franchiser_name != string.Empty)
                {
                    strSql.Append(" And b.franchiser_name=@franchiser_name ");
                }
                strSql.Append(" order by a.trade_time desc ");
            }
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@franchiser_code", SqlDbType.SmallInt, 2), new SqlParameter("@trade_id", SqlDbType.Int, 4), new SqlParameter("@franchiser_name", SqlDbType.NVarChar, 50) };
            parameters[0].Value = franchiser_code;
            parameters[1].Value = trade_id;
            parameters[2].Value = franchiser_name;
            try
            {
                return DbHelperSQL.Query(strSql.ToString(), parameters);
            }
            catch
            {
                return null;
            }
        }

        public DataSet GetTradeDesc(int trade_id)
        {
            string strQuery = string.Format("select distinct a.*,b.product_type_name,b.type from franchiser_trade_desc a inner join product_type b on b.product_type_id=a.product_id  where a.trade_id=@trade_id order by a.ins_date desc; ", new object[0]);
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@trade_id", SqlDbType.Int, 4) };
            parameters[0].Value = trade_id;
            return DbHelperSQL.Query(strQuery, parameters);
        }

        public DataSet GetTradeReportData(string tradeID, string timeS, string timeE)
        {
            string strQuery = "\r\n                            SELECT a.trade_id,a.trade_time,\r\nrealtime_base_price=(select realtime_base_price from realtime_price where [id] in (select max([id]) as [id] from  realtime_price))\r\n\r\n,c.product_type_name,b.product_spec_id,b.trade_amount,b.trade_money\r\n                            FROM franchiser_trade a\r\n                            INNER join franchiser_trade_desc b\r\n                            ON a.trade_id = b.trade_id\r\n                            INNER join product_type c\r\n                            ON b.product_id = c.product_type_id AND b.product_spec_id = c.product_spec_weight\r\n                            WHERE a.trade_id like @tradeid AND a.trade_time BETWEEN @timeS AND @timeE\r\n                            ";
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@tradeid", SqlDbType.VarChar, 20), new SqlParameter("@timeS", SqlDbType.SmallDateTime), new SqlParameter("@timeE", SqlDbType.SmallDateTime) };
            if (string.IsNullOrEmpty(tradeID))
            {
                parameters[0].Value = "%";
            }
            else
            {
                parameters[0].Value = tradeID;
            }
            if (string.IsNullOrEmpty(timeS))
            {
                parameters[1].Value = Convert.ToDateTime("01/01/2000");
            }
            else
            {
                parameters[1].Value = Convert.ToDateTime(timeS);
            }
            if (string.IsNullOrEmpty(timeE))
            {
                parameters[2].Value = DateTime.Now;
            }
            else
            {
                parameters[2].Value = Convert.ToDateTime(timeE);
            }
            return DbHelperSQL.Query(strQuery, parameters);
        }

        public DataSet GetTradeReportData(string franid, string tradeID, string timeS, string timeE, string type, string franName)
        {
            string strQuery = @"
                        SELECT a.franchiser_code,d.franchiser_name,a.trade_id,a.trade_time,
                     realtime_base_price=b. realtime_base_price
       ,c.product_type_name,b.product_spec_id,b.trade_amount,b.trade_money
    FROM franchiser_trade a
INNER join franchiser_trade_desc b
ON a.trade_id = b.trade_id
INNER join product_type c
ON b.product_id = c.product_type_id AND b.product_spec_id = c.product_spec_weight
INNER JOIN franchiser_info d
ON a.franchiser_code = d.franchiser_code
WHERE a.franchiser_code like @fran_code AND a.trade_id like @tradeid 
AND a.trade_time BETWEEN @timeS AND @timeE
AND c.type like @type AND d.franchiser_name like @name
";
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@tradeid", SqlDbType.VarChar, 20), new SqlParameter("@timeS", SqlDbType.SmallDateTime), new SqlParameter("@timeE", SqlDbType.SmallDateTime), new SqlParameter("@fran_code", SqlDbType.VarChar), new SqlParameter("@type", SqlDbType.VarChar), new SqlParameter("@name", SqlDbType.VarChar) };
            if (string.IsNullOrEmpty(franid))
            {
                parameters[3].Value = "%";
            }
            else
            {
                parameters[3].Value = franid;
            }
            if (string.IsNullOrEmpty(tradeID))
            {
                parameters[0].Value = "%";
            }
            else
            {
                parameters[0].Value = tradeID;
            }
            if (string.IsNullOrEmpty(timeS))
            {
                parameters[1].Value = Convert.ToDateTime("01/01/2000");
            }
            else
            {
                parameters[1].Value = Convert.ToDateTime(timeS);
            }
            if (string.IsNullOrEmpty(timeE))
            {
                parameters[2].Value = DateTime.Now;
            }
            else
            {
                parameters[2].Value = Convert.ToDateTime(timeE);
            }
            if (string.IsNullOrEmpty(type))
            {
                parameters[4].Value = "%";
            }
            else
            {
                parameters[4].Value = type;
            }
            if (string.IsNullOrEmpty(franName))
            {
                parameters[5].Value = "%";
            }
            else
            {
                parameters[5].Value = franName;
            }
            return DbHelperSQL.Query(strQuery, parameters);
        }

        public DataSet GetTradetime()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select CONVERT(varchar(12),dtFrom,108) as dtFrom, CONVERT(varchar(12),dtTo,108 ) as dtTo from trade_time where [id]=(select max([id]) from trade_time) ");
            return DbHelperSQL.Query(strSql.ToString());
        }

        public int SetTradeTime(DateTime dtFrom, DateTime dtTo, string ins_user)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into trade_time (dtFrom,dtTo,ins_user,ins_date) ");
            strSql.Append("values(@dtFrom,@dtTo,@ins_user,getdate())");
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@dtFrom", SqlDbType.DateTime, 8), new SqlParameter("@dtTo", SqlDbType.DateTime, 8), new SqlParameter("@ins_user", SqlDbType.NVarChar, 50) };
            parameters[0].Value = dtFrom;
            parameters[1].Value = dtTo;
            parameters[2].Value = ins_user;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        public int TradeCount(DateTime dt)
        {
            string strQuery = string.Format("select count(trade_id) from franchiser_trade where trade_time >= @dtFrom and  trade_time < @dtTo", new object[0]);
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@dtFrom", SqlDbType.DateTime, 8), new SqlParameter("@dtTo", SqlDbType.DateTime, 8) };
            parameters[0].Value = dt;
            parameters[1].Value = dt.AddDays(1.0);
            try
            {
                return Convert.ToInt32(DbHelperSQL.Query(strQuery.ToString(), parameters).Tables[0].Rows[0][0].ToString().Trim());
            }
            catch
            {
                return 0;
            }
        }

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
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@trade_id", SqlDbType.Int, 4), new SqlParameter("@franchiser_code", SqlDbType.SmallInt, 2), new SqlParameter("@trade_time", SqlDbType.SmallDateTime), new SqlParameter("@realtime_base_price", SqlDbType.Money, 8), new SqlParameter("@gold_trade_price", SqlDbType.Money, 8), new SqlParameter("@trade_add_price", SqlDbType.Money, 8), new SqlParameter("@trade_total_weight", SqlDbType.Int, 4), new SqlParameter("@trade_total_money", SqlDbType.Money, 8), new SqlParameter("@canceled_reason", SqlDbType.NVarChar, 100), new SqlParameter("@trade_state", SqlDbType.NVarChar, 50), new SqlParameter("@ins_user", SqlDbType.NVarChar, 50), new SqlParameter("@ins_date", SqlDbType.SmallDateTime), new SqlParameter("@upd_user", SqlDbType.NVarChar, 50), new SqlParameter("@upd_date", SqlDbType.SmallDateTime) };
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
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
    }
}
