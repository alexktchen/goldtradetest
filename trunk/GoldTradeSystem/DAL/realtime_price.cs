using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//请先添加引用
namespace GoldTradeNaming.DAL
{
    /// <summary>
    /// 数据访问类realtime_price。
    /// </summary>
    public class realtime_price
    {
        public realtime_price()
        {
        }
        #region  成员方法


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
        /// 获得数据列表
        /// </summary>
        //public DataSet GetList(string strWhere)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("select *  FROM realtime_price");
        //    if (strWhere.Trim() != "")
        //    {
        //        strSql.Append(" where " + strWhere);
        //    }
        //    return DbHelperSQL.Query(strSql.ToString());
        //}


        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("id","realtime_price");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from realtime_price");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(),parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(GoldTradeNaming.Model.realtime_price model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into realtime_price(");
            strSql.Append("realtime_base_price,realtime_time,sys_admin_id,ins_user,upd_user)");
            strSql.Append(" values (");
            strSql.Append("@realtime_base_price,getdate(),@sys_admin_id,@ins_user,@upd_user)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@realtime_base_price", SqlDbType.Money,8),
				//	new SqlParameter("@order_add_price", SqlDbType.Money,8),
				//	new SqlParameter("@trade_add_price", SqlDbType.Money,8),
				//	new SqlParameter("@realtime_time", SqlDbType.SmallDateTime),
					new SqlParameter("@sys_admin_id", SqlDbType.Int,4),
					new SqlParameter("@ins_user", SqlDbType.NVarChar,50),
				//	new SqlParameter("@ins_date", SqlDbType.SmallDateTime),
					new SqlParameter("@upd_user", SqlDbType.NVarChar,50),};
            //	new SqlParameter("@upd_date", SqlDbType.SmallDateTime)
            parameters[0].Value = model.realtime_base_price;
            // parameters[1].Value = model.order_add_price;
            //parameters[2].Value = model.trade_add_price;
            //  parameters[3].Value = model.realtime_time;
            parameters[1].Value = model.sys_admin_id;
            parameters[2].Value = model.ins_user;
            // parameters[6].Value = model.ins_date;
            parameters[3].Value = model.upd_user;
            //  parameters[8].Value = model.upd_date;

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
        public void Update(GoldTradeNaming.Model.realtime_price model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update realtime_price set ");
            strSql.Append("realtime_base_price=@realtime_base_price,");
            strSql.Append("order_add_price=@order_add_price,");
            strSql.Append("trade_add_price=@trade_add_price,");
            strSql.Append("realtime_time=@realtime_time,");
            strSql.Append("sys_admin_id=@sys_admin_id,");
            strSql.Append("ins_user=@ins_user,");
            strSql.Append("ins_date=@ins_date,");
            strSql.Append("upd_user=@upd_user,");
            strSql.Append("upd_date=@upd_date");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@realtime_base_price", SqlDbType.Money,8),
					new SqlParameter("@order_add_price", SqlDbType.Money,8),
					new SqlParameter("@trade_add_price", SqlDbType.Money,8),
					new SqlParameter("@realtime_time", SqlDbType.SmallDateTime),
					new SqlParameter("@sys_admin_id", SqlDbType.Int,4),
					new SqlParameter("@ins_user", SqlDbType.NVarChar,50),
					new SqlParameter("@ins_date", SqlDbType.SmallDateTime),
					new SqlParameter("@upd_user", SqlDbType.NVarChar,50),
					new SqlParameter("@upd_date", SqlDbType.SmallDateTime)};
            parameters[0].Value = model.id;
            parameters[1].Value = model.realtime_base_price;
            parameters[2].Value = model.order_add_price;
            parameters[3].Value = model.trade_add_price;
            parameters[4].Value = model.realtime_time;
            parameters[5].Value = model.sys_admin_id;
            parameters[6].Value = model.ins_user;
            parameters[7].Value = model.ins_date;
            parameters[8].Value = model.upd_user;
            parameters[9].Value = model.upd_date;

            DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete realtime_price ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public GoldTradeNaming.Model.realtime_price GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,realtime_base_price,order_add_price,trade_add_price,realtime_time,sys_admin_id,ins_user,ins_date,upd_user,upd_date from realtime_price ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            GoldTradeNaming.Model.realtime_price model = new GoldTradeNaming.Model.realtime_price();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(),parameters);
            if(ds.Tables[0].Rows.Count > 0)
            {
                if(ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if(ds.Tables[0].Rows[0]["realtime_base_price"].ToString() != "")
                {
                    model.realtime_base_price = decimal.Parse(ds.Tables[0].Rows[0]["realtime_base_price"].ToString());
                }
                if(ds.Tables[0].Rows[0]["order_add_price"].ToString() != "")
                {
                    model.order_add_price = decimal.Parse(ds.Tables[0].Rows[0]["order_add_price"].ToString());
                }
                if(ds.Tables[0].Rows[0]["trade_add_price"].ToString() != "")
                {
                    model.trade_add_price = decimal.Parse(ds.Tables[0].Rows[0]["trade_add_price"].ToString());
                }
                if(ds.Tables[0].Rows[0]["realtime_time"].ToString() != "")
                {
                    model.realtime_time = DateTime.Parse(ds.Tables[0].Rows[0]["realtime_time"].ToString());
                }
                if(ds.Tables[0].Rows[0]["sys_admin_id"].ToString() != "")
                {
                    model.sys_admin_id = int.Parse(ds.Tables[0].Rows[0]["sys_admin_id"].ToString());
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
            strSql.Append("select a.*,b.sys_admin_name FROM realtime_price a left join goldtrade_db_admin b on a.sys_admin_id=b.sys_admin_id");
            if (strWhere.Trim() != "")
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
            parameters[0].Value = "realtime_price";
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

