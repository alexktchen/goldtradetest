namespace GoldTradeNaming.DAL
{
    using GoldTradeNaming.Model;
    using Maticsoft.DBUtility;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Text;

    public class sys_login_info
    {
        public int Add(GoldTradeNaming.Model.sys_login_info model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into sys_login_info(");
            strSql.Append("IP,login_time,login_ID)");
            strSql.Append(" values (");
            strSql.Append("@IP,getdate(),@login_ID)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@IP", SqlDbType.VarChar, 50), new SqlParameter("@login_ID", SqlDbType.VarChar, 50) };
            parameters[0].Value = model.IP;
            parameters[1].Value = model.login_ID;
            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 1;
            }
            return Convert.ToInt32(obj);
        }

        public void Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete sys_login_info ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@ID", SqlDbType.Int, 4) };
            parameters[0].Value = ID;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from sys_login_info");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@ID", SqlDbType.Int, 4) };
            parameters[0].Value = ID;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,IP,login_time,login_ID ");
            strSql.Append(" FROM sys_login_info ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("ID", "sys_login_info");
        }

        public GoldTradeNaming.Model.sys_login_info GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,IP,login_time,login_ID from sys_login_info ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@ID", SqlDbType.Int, 4) };
            parameters[0].Value = ID;
            GoldTradeNaming.Model.sys_login_info model = new GoldTradeNaming.Model.sys_login_info();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IP"].ToString() != "")
                {
                    model.IP = ds.Tables[0].Rows[0]["IP"].ToString();
                }
                if (ds.Tables[0].Rows[0]["login_time"].ToString() != "")
                {
                    model.login_time = DateTime.Parse(ds.Tables[0].Rows[0]["login_time"].ToString());
                }
                model.login_ID = ds.Tables[0].Rows[0]["login_ID"].ToString();
                return model;
            }
            return null;
        }

        public void Update(GoldTradeNaming.Model.sys_login_info model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update sys_login_info set ");
            strSql.Append("IP=@IP,");
            strSql.Append("login_time=@login_time,");
            strSql.Append("login_ID=@login_ID");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@ID", SqlDbType.Int, 4), new SqlParameter("@IP", SqlDbType.VarBinary, 50), new SqlParameter("@login_time", SqlDbType.SmallDateTime), new SqlParameter("@login_ID", SqlDbType.VarChar, 50) };
            parameters[0].Value = model.ID;
            parameters[1].Value = model.IP;
            parameters[2].Value = model.login_time;
            parameters[3].Value = model.login_ID;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
    }
}
