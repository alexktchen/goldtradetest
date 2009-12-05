namespace GoldTradeNaming.DAL
{
    using GoldTradeNaming.Model;
    using Maticsoft.DBUtility;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Text;

    public class goldtrade_IA100
    {
        public void Add(GoldTradeNaming.Model.goldtrade_IA100 model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into goldtrade_IA100(");
            strSql.Append("IA100GUID,IA100Key,IA100SuperPswd,IA100State,StateChangeReason)");
            strSql.Append(" values (");
            strSql.Append("@IA100GUID,@IA100Key,@IA100SuperPswd,@IA100State,@StateChangeReason)");
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@IA100GUID", SqlDbType.UniqueIdentifier, 0x10), new SqlParameter("@IA100Key", SqlDbType.VarChar, 0x20), new SqlParameter("@IA100SuperPswd", SqlDbType.VarChar, 0x20), new SqlParameter("@IA100State", SqlDbType.VarChar, 50), new SqlParameter("@StateChangeReason", SqlDbType.NVarChar, 100) };
            parameters[0].Value = model.IA100GUID;
            parameters[1].Value = model.IA100Key;
            parameters[2].Value = model.IA100SuperPswd;
            parameters[3].Value = model.IA100State;
            parameters[4].Value = model.StateChangeReason;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        public void Delete(Guid IA100GUID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete goldtrade_IA100 ");
            strSql.Append(" where IA100GUID=@IA100GUID ");
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@IA100GUID", SqlDbType.UniqueIdentifier) };
            parameters[0].Value = IA100GUID;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        public bool Exists(Guid IA100GUID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from goldtrade_IA100");
            strSql.Append(" where IA100GUID=@IA100GUID ");
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@IA100GUID", SqlDbType.UniqueIdentifier) };
            parameters[0].Value = IA100GUID;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        public bool ExistsAndNotInUse(Guid IA100GUID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from goldtrade_IA100");
            strSql.Append(" where IA100GUID=@IA100GUID AND IA100State='0'");
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@IA100GUID", SqlDbType.UniqueIdentifier) };
            parameters[0].Value = IA100GUID;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select IA100GUID,IA100Key,IA100SuperPswd,IA100State,StateChangeReason ");
            strSql.Append(" FROM goldtrade_IA100 ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        public GoldTradeNaming.Model.goldtrade_IA100 GetModel(Guid IA100GUID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 IA100GUID,IA100Key,IA100SuperPswd,IA100State,StateChangeReason from goldtrade_IA100 ");
            strSql.Append(" where IA100GUID=@IA100GUID ");
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@IA100GUID", SqlDbType.UniqueIdentifier) };
            parameters[0].Value = IA100GUID;
            GoldTradeNaming.Model.goldtrade_IA100 model = new GoldTradeNaming.Model.goldtrade_IA100();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["IA100GUID"].ToString() != "")
                {
                    model.IA100GUID = new Guid(ds.Tables[0].Rows[0]["IA100GUID"].ToString());
                }
                model.IA100Key = ds.Tables[0].Rows[0]["IA100Key"].ToString();
                model.IA100SuperPswd = ds.Tables[0].Rows[0]["IA100SuperPswd"].ToString();
                model.IA100State = ds.Tables[0].Rows[0]["IA100State"].ToString();
                model.StateChangeReason = ds.Tables[0].Rows[0]["StateChangeReason"].ToString();
                return model;
            }
            return null;
        }

        public void Update(GoldTradeNaming.Model.goldtrade_IA100 model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update goldtrade_IA100 set ");
            strSql.Append("IA100Key=@IA100Key,");
            strSql.Append("IA100SuperPswd=@IA100SuperPswd,");
            strSql.Append("IA100State=@IA100State,");
            strSql.Append("StateChangeReason=@StateChangeReason");
            strSql.Append(" where IA100GUID=@IA100GUID ");
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@IA100GUID", SqlDbType.UniqueIdentifier, 0x10), new SqlParameter("@IA100Key", SqlDbType.VarChar, 0x20), new SqlParameter("@IA100SuperPswd", SqlDbType.VarChar, 0x20), new SqlParameter("@IA100State", SqlDbType.VarChar, 50), new SqlParameter("@StateChangeReason", SqlDbType.NVarChar, 100) };
            parameters[0].Value = model.IA100GUID;
            parameters[1].Value = model.IA100Key;
            parameters[2].Value = model.IA100SuperPswd;
            parameters[3].Value = model.IA100State;
            parameters[4].Value = model.StateChangeReason;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
    }
}
