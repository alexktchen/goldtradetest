using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//请先添加引用
namespace GoldTradeNaming.DAL
{
    /// <summary>
    /// 数据访问类goldtrade_db_admin。
    /// </summary>
    public class goldtrade_db_admin
    {
        #region 自定义方法 Add by tianjie

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string sAdminName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from goldtrade_db_admin");
            strSql.Append(" where sys_admin_name=@sys_admin_name ");
            SqlParameter[] parameters = {
					new SqlParameter("@sys_admin_name", SqlDbType.NVarChar,50)};
            parameters[0].Value = sAdminName;

            return DbHelperSQL.Exists(strSql.ToString(),parameters);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int iAdminID,string sAdminName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from goldtrade_db_admin");
            strSql.Append(" where sys_admin_name=@sys_admin_name AND sys_admin_id<>@sys_admin_id");
            SqlParameter[] parameters = {
                    new SqlParameter("@sys_admin_id",SqlDbType.Int,4),
					new SqlParameter("@sys_admin_name", SqlDbType.NVarChar,50)};
            parameters[1].Value = sAdminName;
            parameters[0].Value = iAdminID;
            return DbHelperSQL.Exists(strSql.ToString(),parameters);
        }

        /// <summary>
        /// IA100锁是否已被使用
        /// </summary>
        /// <param name="sIA100GUID"></param>
        /// <returns></returns>
        public bool IA100InUsed(Guid sIA100GUID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from goldtrade_db_admin");
            strSql.Append(" where IA100GUID=@IA100GUID ");
            SqlParameter[] parameters = {
					new SqlParameter("@IA100GUID", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = sIA100GUID;

            return DbHelperSQL.Exists(strSql.ToString(),parameters);
        }

        /// <summary>
        /// IA100锁是否已被使用
        /// </summary>
        /// <param name="sIA100GUID"></param>
        /// <returns></returns>
        public bool IA100InUsed(int iAdminID,Guid sIA100GUID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from goldtrade_db_admin");
            strSql.Append(" where sys_admin_id<>@sys_admin_id AND IA100GUID=@IA100GUID ");
            SqlParameter[] parameters = {
                                            new SqlParameter("@sys_admin_id",SqlDbType.Int,4),
					new SqlParameter("@IA100GUID", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = iAdminID;
            parameters[1].Value = sIA100GUID;

            return DbHelperSQL.Exists(strSql.ToString(),parameters);
        }

        #endregion

        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("sys_admin_id","goldtrade_db_admin");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int sys_admin_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from goldtrade_db_admin");
            strSql.Append(" where sys_admin_id=@sys_admin_id ");
            SqlParameter[] parameters = {
					new SqlParameter("@sys_admin_id", SqlDbType.Int,4)};
            parameters[0].Value = sys_admin_id;

            return DbHelperSQL.Exists(strSql.ToString(),parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(GoldTradeNaming.Model.goldtrade_db_admin model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into goldtrade_db_admin(");
            strSql.Append("sys_admin_name,sys_admin_tel,sys_admin_cellphone,IA100GUID,ins_user,upd_user)");
            strSql.Append(" values (");
            strSql.Append("@sys_admin_name,@sys_admin_tel,@sys_admin_cellphone,@IA100GUID,@ins_user,@upd_user)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@sys_admin_name", SqlDbType.NVarChar,50),
					new SqlParameter("@sys_admin_tel", SqlDbType.NVarChar,50),
					new SqlParameter("@sys_admin_cellphone", SqlDbType.NVarChar,50),
					new SqlParameter("@IA100GUID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@ins_user", SqlDbType.NVarChar,50),
					//new SqlParameter("@ins_date", SqlDbType.SmallDateTime),
					new SqlParameter("@upd_user", SqlDbType.NVarChar,50)//,
					//new SqlParameter("@upd_date", SqlDbType.SmallDateTime)
                                        };
            parameters[0].Value = model.sys_admin_name;
            parameters[1].Value = model.sys_admin_tel;
            parameters[2].Value = model.sys_admin_cellphone;
            parameters[3].Value = model.IA100GUID;
            parameters[4].Value = model.ins_user;
            //parameters[5].Value = model.ins_date;
            parameters[5].Value = model.upd_user;
            //parameters[7].Value = model.upd_date;

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
        public void Update(GoldTradeNaming.Model.goldtrade_db_admin model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update goldtrade_db_admin set ");
            strSql.Append("sys_admin_name=@sys_admin_name,");
            strSql.Append("sys_admin_tel=@sys_admin_tel,");
            strSql.Append("sys_admin_cellphone=@sys_admin_cellphone,");
            strSql.Append("IA100GUID=@IA100GUID,");
            strSql.Append("ins_user=ins_user,");
            strSql.Append("ins_date=ins_date,");
            strSql.Append("upd_user=@upd_user,");
            strSql.Append("upd_date=getdate()");
            strSql.Append(" where sys_admin_id=@sys_admin_id ");
            SqlParameter[] parameters = {
					new SqlParameter("@sys_admin_id", SqlDbType.Int,4),
					new SqlParameter("@sys_admin_name", SqlDbType.NVarChar,50),
					new SqlParameter("@sys_admin_tel", SqlDbType.NVarChar,50),
					new SqlParameter("@sys_admin_cellphone", SqlDbType.NVarChar,50),
					new SqlParameter("@IA100GUID", SqlDbType.UniqueIdentifier,16),
					//new SqlParameter("@ins_user", SqlDbType.NVarChar,50),
					//new SqlParameter("@ins_date", SqlDbType.SmallDateTime),
					new SqlParameter("@upd_user", SqlDbType.NVarChar,50),
					new SqlParameter("@upd_date", SqlDbType.SmallDateTime)};
            parameters[0].Value = model.sys_admin_id;
            parameters[1].Value = model.sys_admin_name;
            parameters[2].Value = model.sys_admin_tel;
            parameters[3].Value = model.sys_admin_cellphone;
            parameters[4].Value = model.IA100GUID;
            //parameters[5].Value = model.ins_user;
            //parameters[6].Value = model.ins_date;
            parameters[5].Value = model.upd_user;
            parameters[6].Value = model.upd_date;

            DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int sys_admin_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete goldtrade_db_admin ");
            strSql.Append(" where sys_admin_id=@sys_admin_id ");
            SqlParameter[] parameters = {
					new SqlParameter("@sys_admin_id", SqlDbType.Int,4)};
            parameters[0].Value = sys_admin_id;

            DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public GoldTradeNaming.Model.goldtrade_db_admin GetModel(int sys_admin_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 sys_admin_id,sys_admin_name,sys_admin_tel,sys_admin_cellphone,IA100GUID,ins_user,ins_date,upd_user,upd_date from goldtrade_db_admin ");
            strSql.Append(" where sys_admin_id=@sys_admin_id ");
            SqlParameter[] parameters = {
					new SqlParameter("@sys_admin_id", SqlDbType.Int,4)};
            parameters[0].Value = sys_admin_id;

            GoldTradeNaming.Model.goldtrade_db_admin model = new GoldTradeNaming.Model.goldtrade_db_admin();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(),parameters);
            if(ds.Tables[0].Rows.Count > 0)
            {
                if(ds.Tables[0].Rows[0]["sys_admin_id"].ToString() != "")
                {
                    model.sys_admin_id = int.Parse(ds.Tables[0].Rows[0]["sys_admin_id"].ToString());
                }
                model.sys_admin_name = ds.Tables[0].Rows[0]["sys_admin_name"].ToString();
                model.sys_admin_tel = ds.Tables[0].Rows[0]["sys_admin_tel"].ToString();
                model.sys_admin_cellphone = ds.Tables[0].Rows[0]["sys_admin_cellphone"].ToString();
                if(ds.Tables[0].Rows[0]["IA100GUID"].ToString() != "")
                {
                    model.IA100GUID = new Guid(ds.Tables[0].Rows[0]["IA100GUID"].ToString());
                }
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
            strSql.Append("select top 50 sys_admin_id,sys_admin_name,sys_admin_tel,sys_admin_cellphone,IA100GUID,ins_user,ins_date,upd_user,upd_date ");
            strSql.Append(" FROM goldtrade_db_admin ");
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
            parameters[0].Value = "goldtrade_db_admin";
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

