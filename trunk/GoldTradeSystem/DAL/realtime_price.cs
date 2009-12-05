namespace GoldTradeNaming.DAL
{
    using GoldTradeNaming.Model;
    using Maticsoft.DBUtility;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Text;

    public class realtime_price
    {
        public int Add(GoldTradeNaming.Model.realtime_price model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into realtime_price(");
            strSql.Append("realtime_base_price,realtime_time,sys_admin_id,ins_user,upd_user)");
            strSql.Append(" values (");
            strSql.Append("@realtime_base_price,getdate(),@sys_admin_id,@ins_user,@upd_user)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@realtime_base_price", SqlDbType.Money, 8), new SqlParameter("@sys_admin_id", SqlDbType.Int, 4), new SqlParameter("@ins_user", SqlDbType.NVarChar, 50), new SqlParameter("@upd_user", SqlDbType.NVarChar, 50) };
            parameters[0].Value = model.realtime_base_price;
            parameters[1].Value = model.sys_admin_id;
            parameters[2].Value = model.ins_user;
            parameters[3].Value = model.upd_user;
            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 1;
            }
            return Convert.ToInt32(obj);
        }

        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from realtime_price");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@id", SqlDbType.Int, 4) };
            parameters[0].Value = id;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        public DataSet getCurrentPrice()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select realtime_base_price,realtime_time,sys_admin_id from realtime_price");
            strSql.Append(" where [id] in (select max([id]) as [id] from  realtime_price)");
            return DbHelperSQL.Query(strSql.ToString());
        }

        public DataSet GetList(DateTime dtFrom, DateTime dtTo)
        {
            string strQuery = string.Format("select a.*,b.sys_admin_name FROM realtime_price a left join goldtrade_db_admin b on a.sys_admin_id=b.sys_admin_id \r\n                             where  a.realtime_time <@dtTo  ", new object[0]);
            if (dtFrom.CompareTo(new DateTime(0x76c, 1, 1)) != 0)
            {
                strQuery = strQuery + "AND a.realtime_time >=@dtFrom ";
            }
            strQuery = strQuery + " order by a.realtime_time desc";
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@dtFrom", SqlDbType.SmallDateTime, 4), new SqlParameter("@dtTo", SqlDbType.SmallDateTime, 4) };
            parameters[0].Value = dtFrom;
            parameters[1].Value = dtTo.AddDays(1.0);
            try
            {
                return DbHelperSQL.Query(strQuery.ToString(), parameters);
            }
            catch
            {
                return null;
            }
        }

        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("id", "realtime_price");
        }

        public GoldTradeNaming.Model.realtime_price GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,realtime_base_price,order_add_price,trade_add_price,realtime_time,sys_admin_id,ins_user,ins_date,upd_user,upd_date from realtime_price ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@id", SqlDbType.Int, 4) };
            parameters[0].Value = id;
            GoldTradeNaming.Model.realtime_price model = new GoldTradeNaming.Model.realtime_price();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["realtime_base_price"].ToString() != "")
                {
                    model.realtime_base_price = decimal.Parse(ds.Tables[0].Rows[0]["realtime_base_price"].ToString());
                }
                if (ds.Tables[0].Rows[0]["order_add_price"].ToString() != "")
                {
                    model.order_add_price = decimal.Parse(ds.Tables[0].Rows[0]["order_add_price"].ToString());
                }
                if (ds.Tables[0].Rows[0]["trade_add_price"].ToString() != "")
                {
                    model.trade_add_price = decimal.Parse(ds.Tables[0].Rows[0]["trade_add_price"].ToString());
                }
                if (ds.Tables[0].Rows[0]["realtime_time"].ToString() != "")
                {
                    model.realtime_time = DateTime.Parse(ds.Tables[0].Rows[0]["realtime_time"].ToString());
                }
                if (ds.Tables[0].Rows[0]["sys_admin_id"].ToString() != "")
                {
                    model.sys_admin_id = int.Parse(ds.Tables[0].Rows[0]["sys_admin_id"].ToString());
                }
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
    }
}
