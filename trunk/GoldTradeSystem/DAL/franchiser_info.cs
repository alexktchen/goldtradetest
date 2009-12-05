namespace GoldTradeNaming.DAL
{
    using GoldTradeNaming.Model;
    using Maticsoft.DBUtility;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Text;

    public class franchiser_info
    {
        public int Add(GoldTradeNaming.Model.franchiser_info model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into franchiser_info(");
            strSql.Append("franchiser_name,franchiser_balance_money,franchiser_asure_money,franchiser_tel,franchiser_cellphone,franchiser_address,ins_user,upd_user,IA100GUID)");
            strSql.Append(" values (");
            strSql.Append("@franchiser_name,@franchiser_balance_money,@franchiser_asure_money,@franchiser_tel,@franchiser_cellphone,@franchiser_address,@ins_user,@upd_user,@IA100GUID)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@franchiser_name", SqlDbType.NVarChar, 50), new SqlParameter("@franchiser_balance_money", SqlDbType.Money, 8), new SqlParameter("@franchiser_asure_money", SqlDbType.Money, 8), new SqlParameter("@franchiser_tel", SqlDbType.NVarChar, 50), new SqlParameter("@franchiser_cellphone", SqlDbType.NVarChar, 50), new SqlParameter("@franchiser_address", SqlDbType.NVarChar, 50), new SqlParameter("@ins_user", SqlDbType.NVarChar, 50), new SqlParameter("@upd_user", SqlDbType.NVarChar, 50), new SqlParameter("@IA100GUID", SqlDbType.UniqueIdentifier, 0x10) };
            parameters[0].Value = model.franchiser_name;
            parameters[1].Value = model.franchiser_asure_money;
            parameters[2].Value = model.franchiser_asure_money;
            parameters[3].Value = model.franchiser_tel;
            parameters[4].Value = model.franchiser_cellphone;
            parameters[5].Value = model.franchiser_address;
            parameters[6].Value = model.ins_user;
            parameters[7].Value = model.upd_user;
            parameters[8].Value = model.IA100GUID;
            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 1;
            }
            return Convert.ToInt32(obj);
        }

        public void Delete(int franchiser_code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete franchiser_info ");
            strSql.Append(" where franchiser_code=@franchiser_code ");
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@franchiser_code", SqlDbType.SmallInt) };
            parameters[0].Value = franchiser_code;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        public int DisableIA(Guid IA100GUID, string reason)
        {
            return DbHelperSQL.ExecuteSql(string.Format("update goldtrade_IA100 set IA100State='1',StateChangeReason='{1}' where IA100GUID='{0}'", IA100GUID, reason));
        }

        public bool Exists(Guid guid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from franchiser_info");
            strSql.Append(" where IA100GUID=@IA100GUID ");
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@IA100GUID", SqlDbType.UniqueIdentifier) };
            parameters[0].Value = guid;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        public bool Exists(int franchiser_code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from franchiser_info");
            strSql.Append(" where franchiser_code=@franchiser_code ");
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@franchiser_code", SqlDbType.SmallInt) };
            parameters[0].Value = franchiser_code;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        public bool Exists(string franchiser_name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from franchiser_info");
            strSql.Append(" where franchiser_name=@franchiser_name ");
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@franchiser_name", SqlDbType.NVarChar, 50) };
            parameters[0].Value = franchiser_name;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        public bool Exists(int franchiser_code, Guid guid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from franchiser_info");
            strSql.Append(" where IA100GUID=@IA100GUID ");
            strSql.Append(" and franchiser_code!=@franchiser_code ");
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@IA100GUID", SqlDbType.UniqueIdentifier), new SqlParameter("@franchiser_code", SqlDbType.SmallInt) };
            parameters[0].Value = guid;
            parameters[1].Value = franchiser_code;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        public bool Exists(int franchiser_code, string franchiser_name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from franchiser_info");
            strSql.Append(" where franchiser_code!=@franchiser_code ");
            strSql.Append(" and  franchiser_name=@franchiser_name ");
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@franchiser_code", SqlDbType.SmallInt), new SqlParameter("@franchiser_name", SqlDbType.NVarChar, 50) };
            parameters[0].Value = franchiser_code;
            parameters[1].Value = franchiser_name;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        public DataSet GetFranAllInfo(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  franchiser_code,franchiser_name,franchiser_balance_money,\r\n                        franchiser_asure_money,franchiser_tel,franchiser_cellphone,franchiser_address,\r\n                        ins_user,ins_date,upd_user,upd_date,IA100GUID\r\n                        ,\r\n                         TotalMoney = (SELECT SUM(franchiser_added_money)  FROM franchiser_money\r\n                         where franchiser_money.franchiser_code=franchiser_info.franchiser_code )\r\n                        ,\r\n                        OrderMoney = (select SUM(franchiser_order.franchiser_order_amount_money)FROM franchiser_order \r\n                        where franchiser_order.franchiser_code=franchiser_info.franchiser_code )\r\n                        ,          \r\n                        TradeMoney = (select SUM(trade_total_money) from franchiser_trade \r\n                        where franchiser_trade.franchiser_code=franchiser_info.franchiser_code \r\n                        )\r\n                        FROM franchiser_info");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  franchiser_code,franchiser_name,franchiser_balance_money,franchiser_asure_money,franchiser_tel,franchiser_cellphone,franchiser_address,ins_user,ins_date,upd_user,upd_date,IA100GUID ");
            strSql.Append(" FROM franchiser_info ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("franchiser_code", "franchiser_info");
        }

        public GoldTradeNaming.Model.franchiser_info GetModel(int franchiser_code)
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

        public void Update(GoldTradeNaming.Model.franchiser_info model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update franchiser_info set ");
            strSql.Append("franchiser_name=@franchiser_name,");
            strSql.Append("franchiser_balance_money=franchiser_balance_money+@franchiser_asure_money-franchiser_asure_money,");
            strSql.Append("franchiser_asure_money=@franchiser_asure_money,");
            strSql.Append("franchiser_tel=@franchiser_tel,");
            strSql.Append("franchiser_cellphone=@franchiser_cellphone,");
            strSql.Append("franchiser_address=@franchiser_address,");
            strSql.Append("upd_user=@upd_user,");
            strSql.Append("upd_date=getdate(),");
            strSql.Append("IA100GUID=@IA100GUID");
            strSql.Append(" where franchiser_code=@franchiser_code ");
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@franchiser_code", SqlDbType.SmallInt, 2), new SqlParameter("@franchiser_name", SqlDbType.NVarChar, 50), new SqlParameter("@franchiser_balance_money", SqlDbType.Money, 8), new SqlParameter("@franchiser_asure_money", SqlDbType.Money, 8), new SqlParameter("@franchiser_tel", SqlDbType.NVarChar, 50), new SqlParameter("@franchiser_cellphone", SqlDbType.NVarChar, 50), new SqlParameter("@franchiser_address", SqlDbType.NVarChar, 50), new SqlParameter("@upd_user", SqlDbType.NVarChar, 50), new SqlParameter("@IA100GUID", SqlDbType.UniqueIdentifier, 0x10) };
            parameters[0].Value = model.franchiser_code;
            parameters[1].Value = model.franchiser_name;
            parameters[3].Value = model.franchiser_asure_money;
            parameters[4].Value = model.franchiser_tel;
            parameters[5].Value = model.franchiser_cellphone;
            parameters[6].Value = model.franchiser_address;
            parameters[7].Value = model.upd_user;
            parameters[8].Value = model.IA100GUID;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
    }
}
