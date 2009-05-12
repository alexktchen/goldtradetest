using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
using System.Collections;//请先添加引用
namespace GoldTradeNaming.DAL
{
    /// <summary>
    /// 数据访问类sys_admin_authority。
    /// </summary>
    public class sys_admin_authority
    {
        #region Addby 田杰
        public DataTable GetRightSet(int adminId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select sys_admin_id,sys_module ");
            strSql.Append(" FROM sys_admin_authority where sys_admin_id=@sys_admin_id");
            SqlParameter[] parameters = {
					new SqlParameter("@sys_admin_id", SqlDbType.Int,4)};
            parameters[0].Value = adminId;
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables.Count > 0)
                return ds.Tables[0];
            return null;
        }

        #endregion
        public sys_admin_authority()
        {
        }
        #region  成员方法

        /// <summary>
        ///更新管理员权限 by yuxiaowei
        /// </summary>
        public void Update(int sys_admin_id,ArrayList sModule)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete sys_admin_authority ");
            strSql.Append(" where sys_admin_id=@sys_admin_id ");
            SqlParameter[] parameters = {
					new SqlParameter("@sys_admin_id", SqlDbType.Int,4)};
            parameters[0].Value = sys_admin_id;
            DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);


            foreach(object o in sModule)
            {
                strSql = new StringBuilder();
                strSql.Append("insert into sys_admin_authority(");
                strSql.Append("sys_admin_id,sys_module)");
                strSql.Append(" values (");
                strSql.Append("@sys_admin_id,@sys_module); ");
                SqlParameter[] parameters2 = {
					new SqlParameter("@sys_admin_id", SqlDbType.Int,4),
					new SqlParameter("@sys_module", SqlDbType.NVarChar,50)};
                parameters2[0].Value = sys_admin_id;
                parameters2[1].Value = o.ToString().Trim();
                DbHelperSQL.ExecuteSql(strSql.ToString(),parameters2);
            }

        }

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("sys_admin_id","sys_admin_authority");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int sys_admin_id,string sys_module)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from sys_admin_authority");
            strSql.Append(" where sys_admin_id=@sys_admin_id and sys_module=@sys_module ");
            SqlParameter[] parameters = {
					new SqlParameter("@sys_admin_id", SqlDbType.Int,4),
					new SqlParameter("@sys_module", SqlDbType.NVarChar,50)};
            parameters[0].Value = sys_admin_id;
            parameters[1].Value = sys_module;

            return DbHelperSQL.Exists(strSql.ToString(),parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(GoldTradeNaming.Model.sys_admin_authority model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into sys_admin_authority(");
            strSql.Append("sys_admin_id,sys_module)");
            strSql.Append(" values (");
            strSql.Append("@sys_admin_id,@sys_module)");
            SqlParameter[] parameters = {
					new SqlParameter("@sys_admin_id", SqlDbType.Int,4),
					new SqlParameter("@sys_module", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.sys_admin_id;
            parameters[1].Value = model.sys_module;

            DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(GoldTradeNaming.Model.sys_admin_authority model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update sys_admin_authority set ");
            //");
            strSql.Append(" where sys_admin_id=@sys_admin_id and sys_module=@sys_module ");
            SqlParameter[] parameters = {
					new SqlParameter("@sys_admin_id", SqlDbType.Int,4),
					new SqlParameter("@sys_module", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.sys_admin_id;
            parameters[1].Value = model.sys_module;

            DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int sys_admin_id,string sys_module)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete sys_admin_authority ");
            strSql.Append(" where sys_admin_id=@sys_admin_id and sys_module=@sys_module ");
            SqlParameter[] parameters = {
					new SqlParameter("@sys_admin_id", SqlDbType.Int,4),
					new SqlParameter("@sys_module", SqlDbType.NVarChar,50)};
            parameters[0].Value = sys_admin_id;
            parameters[1].Value = sys_module;

            DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public GoldTradeNaming.Model.sys_admin_authority GetModel(int sys_admin_id,string sys_module)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 sys_admin_id,sys_module from sys_admin_authority ");
            strSql.Append(" where sys_admin_id=@sys_admin_id and sys_module=@sys_module ");
            SqlParameter[] parameters = {
					new SqlParameter("@sys_admin_id", SqlDbType.Int,4),
					new SqlParameter("@sys_module", SqlDbType.NVarChar,50)};
            parameters[0].Value = sys_admin_id;
            parameters[1].Value = sys_module;

            GoldTradeNaming.Model.sys_admin_authority model = new GoldTradeNaming.Model.sys_admin_authority();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(),parameters);
            if(ds.Tables[0].Rows.Count > 0)
            {
                if(ds.Tables[0].Rows[0]["sys_admin_id"].ToString() != "")
                {
                    model.sys_admin_id = int.Parse(ds.Tables[0].Rows[0]["sys_admin_id"].ToString());
                }
                model.sys_module = ds.Tables[0].Rows[0]["sys_module"].ToString();
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
            strSql.Append("select sys_admin_id,sys_module ");
            strSql.Append(" FROM sys_admin_authority ");
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
            parameters[0].Value = "sys_admin_authority";
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

