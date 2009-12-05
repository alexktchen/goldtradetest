namespace GoldTradeNaming.DAL
{
    using GoldTradeNaming.Model;
    using Maticsoft.DBUtility;
    using System;
    using System.Collections;
    using System.Data;
    using System.Data.SqlClient;
    using System.Text;

    public class sys_admin_authority
    {
        public void Add(GoldTradeNaming.Model.sys_admin_authority model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into sys_admin_authority(");
            strSql.Append("sys_admin_id,sys_module)");
            strSql.Append(" values (");
            strSql.Append("@sys_admin_id,@sys_module)");
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@sys_admin_id", SqlDbType.Int, 4), new SqlParameter("@sys_module", SqlDbType.NVarChar, 50) };
            parameters[0].Value = model.sys_admin_id;
            parameters[1].Value = model.sys_module;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        public void Delete(int sys_admin_id, string sys_module)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete sys_admin_authority ");
            strSql.Append(" where sys_admin_id=@sys_admin_id and sys_module=@sys_module ");
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@sys_admin_id", SqlDbType.Int, 4), new SqlParameter("@sys_module", SqlDbType.NVarChar, 50) };
            parameters[0].Value = sys_admin_id;
            parameters[1].Value = sys_module;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        public bool Exists(int sys_admin_id, string sys_module)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from sys_admin_authority");
            strSql.Append(" where sys_admin_id=@sys_admin_id and sys_module=@sys_module ");
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@sys_admin_id", SqlDbType.Int, 4), new SqlParameter("@sys_module", SqlDbType.NVarChar, 50) };
            parameters[0].Value = sys_admin_id;
            parameters[1].Value = sys_module;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select sys_admin_id,sys_module ");
            strSql.Append(" FROM sys_admin_authority ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("sys_admin_id", "sys_admin_authority");
        }

        public GoldTradeNaming.Model.sys_admin_authority GetModel(int sys_admin_id, string sys_module)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 sys_admin_id,sys_module from sys_admin_authority ");
            strSql.Append(" where sys_admin_id=@sys_admin_id and sys_module=@sys_module ");
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@sys_admin_id", SqlDbType.Int, 4), new SqlParameter("@sys_module", SqlDbType.NVarChar, 50) };
            parameters[0].Value = sys_admin_id;
            parameters[1].Value = sys_module;
            GoldTradeNaming.Model.sys_admin_authority model = new GoldTradeNaming.Model.sys_admin_authority();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["sys_admin_id"].ToString() != "")
                {
                    model.sys_admin_id = int.Parse(ds.Tables[0].Rows[0]["sys_admin_id"].ToString());
                }
                model.sys_module = ds.Tables[0].Rows[0]["sys_module"].ToString();
                return model;
            }
            return null;
        }

        public DataTable GetRightSet(int adminId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select sys_admin_id,sys_module ");
            strSql.Append(" FROM sys_admin_authority where sys_admin_id=@sys_admin_id");
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@sys_admin_id", SqlDbType.Int, 4) };
            parameters[0].Value = adminId;
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;
        }

        public void Update(GoldTradeNaming.Model.sys_admin_authority model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update sys_admin_authority set ");
            strSql.Append(" where sys_admin_id=@sys_admin_id and sys_module=@sys_module ");
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@sys_admin_id", SqlDbType.Int, 4), new SqlParameter("@sys_module", SqlDbType.NVarChar, 50) };
            parameters[0].Value = model.sys_admin_id;
            parameters[1].Value = model.sys_module;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        public void Update(int sys_admin_id, ArrayList sModule)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete sys_admin_authority ");
            strSql.Append(" where sys_admin_id=@sys_admin_id ");
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@sys_admin_id", SqlDbType.Int, 4) };
            parameters[0].Value = sys_admin_id;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            foreach (object o in sModule)
            {
                strSql = new StringBuilder();
                strSql.Append("insert into sys_admin_authority(");
                strSql.Append("sys_admin_id,sys_module)");
                strSql.Append(" values (");
                strSql.Append("@sys_admin_id,@sys_module); ");
                SqlParameter[] parameters2 = new SqlParameter[] { new SqlParameter("@sys_admin_id", SqlDbType.Int, 4), new SqlParameter("@sys_module", SqlDbType.NVarChar, 50) };
                parameters2[0].Value = sys_admin_id;
                parameters2[1].Value = o.ToString().Trim();
                DbHelperSQL.ExecuteSql(strSql.ToString(), parameters2);
            }
        }
    }
}
