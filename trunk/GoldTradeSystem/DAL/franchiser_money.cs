using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//请先添加引用
namespace GoldTradeNaming.DAL
{
    /// <summary>
    /// 数据访问类franchiser_money。
    /// </summary>
    public class franchiser_money
    {
        public franchiser_money()
        { }

        #region 自定义成员方法
        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="fran_id"></param>
        /// <param name="add_money"></param>
        /// <param name="time_from"></param>
        /// <param name="time_to"></param>
        /// <returns></returns>
        public DataSet queryAction(string fran_id, string add_money, string time_from, string time_to, string check)
        {
            StringBuilder strQuery = new StringBuilder();
            strQuery.Append(" SELECT     franchiser_money.id, franchiser_money.franchiser_code ,  franchiser_info.franchiser_name,   franchiser_money.franchiser_added_money, franchiser_money.added_time,franchiser_money.checked, franchiser_money.ins_user, franchiser_money.ins_date,       franchiser_money.upd_user, franchiser_money.upd_date ");
            strQuery.Append(" FROM franchiser_info INNER JOIN       franchiser_money ON        franchiser_info.franchiser_code = franchiser_money.franchiser_code");
            strQuery.Append(" where  ");
            if (fran_id == "")
            {
                strQuery.Append(" 1=1 ");

            }
            else
            {

                strQuery.Append(" franchiser_money.franchiser_code = '" + fran_id.Trim() + "'");
            }



            if (add_money == "")
            {
                strQuery.Append(" and  1=1 ");
            }
            else
            {
                strQuery.Append(" and franchiser_money.franchiser_added_money = " + add_money.Trim());
            }

            strQuery.Append(" and franchiser_money.added_time between ");


            if (time_from == "")
            {
                strQuery.Append("  '1900-01-01 00:00:00'  ");
            }
            else
            {

                strQuery.Append(" '" + time_from.Trim() + " 00:00:00' ");
            }


            strQuery.Append(" and ");

            if (time_to == "")
            {

                strQuery.Append(" '" + DateTime.Now.ToString("yyyy-MM-dd ") + "23:59:59'");

            }
            else
            {

                strQuery.Append("'" + time_to.Trim() + " 23:59:59'");
            }

            strQuery.Append(" and ");
            if (check == "")
            {

                strQuery.Append(" 1=1 ");
            }
            else
            {

                strQuery.Append(" checked ='" + check + "'");
            }




            return DbHelperSQL.Query(strQuery.ToString());




        }


        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="fran_id"></param>
        /// <param name="add_money"></param>
        /// <param name="time_from"></param>
        /// <param name="time_to"></param>
        /// <returns></returns>
        public DataSet queryAction(string fran_id, string add_money, string time_from, string time_to)
        {
            StringBuilder strQuery = new StringBuilder();
            strQuery.Append(" SELECT     franchiser_money.id, franchiser_money.franchiser_code ,  franchiser_info.franchiser_name,   franchiser_money.franchiser_added_money, franchiser_money.added_time, franchiser_money.ins_user, franchiser_money.ins_date,       franchiser_money.upd_user, franchiser_money.upd_date ");
            strQuery.Append(" FROM franchiser_info INNER JOIN       franchiser_money ON        franchiser_info.franchiser_code = franchiser_money.franchiser_code");
            strQuery.Append(" where  ");
            if (fran_id == "")
            {
                strQuery.Append(" 1=1 ");

            }
            else
            {

                strQuery.Append(" franchiser_money.franchiser_code = '" + fran_id.Trim() + "'");
            }



            if (add_money == "")
            {
                strQuery.Append(" and  1=1 ");
            }
            else
            {
                strQuery.Append(" and franchiser_money.franchiser_added_money = " + add_money.Trim());
            }

            strQuery.Append(" and franchiser_money.added_time between ");


            if (time_from == "")
            {
                strQuery.Append("  '1900-01-01 00:00:00'  ");
            }
            else
            {

                strQuery.Append(" '" + time_from.Trim() + " 00:00:00' ");
            }


            strQuery.Append(" and ");

            if (time_to == "")
            {

                strQuery.Append(" '" + DateTime.Now.ToString("yyyy-MM-dd ") + "23:59:59'");

            }
            else
            {

                strQuery.Append("'" + time_to.Trim() + " 23:59:59'");
            }


            return DbHelperSQL.Query(strQuery.ToString());




        }


        /// <summary>
        /// 查找数据库中该经销商编号是否存在
        /// </summary>
        /// <param name="fran_id"></param>
        /// <returns></returns>
        public bool fran_id_exists(int fran_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from franchiser_info");
            strSql.Append(" where franchiser_code=@franchiser_code ");
            SqlParameter[] parameters = {
					new SqlParameter("@franchiser_code", SqlDbType.Int,2)};
            parameters[0].Value = fran_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 用来同步更新franchiser_info表
        /// </summary>
        /// <param name="franchiser_code"></param>
        /// <param name="franchiser_balance_money"></param>
        /// <param name="tag">0：从总余额中加上入账金额   -1：从总余额中减去入账金额</param>
        /// <returns></returns>

        public int update_franchiser_info(int franchiser_code, decimal franchiser_balance_money, int tag)
        {



            StringBuilder strSql = new StringBuilder();
            strSql.Append("update franchiser_info set ");
            if (tag == 0)
            {
                strSql.Append("franchiser_balance_money= franchiser_balance_money +" + franchiser_balance_money);

            }
            else if (tag == -1)
            {

                strSql.Append("franchiser_balance_money= franchiser_balance_money -" + franchiser_balance_money);
            }

            strSql.Append(" where franchiser_code= " + franchiser_code);

            return DbHelperSQL.ExecuteSql(strSql.ToString());


        }




        #endregion



        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("id", "franchiser_money");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from franchiser_money");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(GoldTradeNaming.Model.franchiser_money model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into franchiser_money(");
            strSql.Append("franchiser_code,franchiser_added_money,added_time,ins_user,ins_date,upd_user,upd_date,checked)");
            strSql.Append(" values (");
            strSql.Append("@franchiser_code,@franchiser_added_money,@added_time,@ins_user,@ins_date,@upd_user,@upd_date,@checked)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@franchiser_code", SqlDbType.SmallInt,2),
					new SqlParameter("@franchiser_added_money", SqlDbType.Money,8),
					new SqlParameter("@added_time", SqlDbType.SmallDateTime),
					new SqlParameter("@ins_user", SqlDbType.NVarChar,50),
					new SqlParameter("@ins_date", SqlDbType.SmallDateTime),
					new SqlParameter("@upd_user", SqlDbType.NVarChar,50),
					new SqlParameter("@upd_date", SqlDbType.SmallDateTime),
                    new SqlParameter("@checked", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.franchiser_code;
            parameters[1].Value = model.franchiser_added_money;
            parameters[2].Value = model.added_time;
            parameters[3].Value = model.ins_user;
            parameters[4].Value = model.ins_date;
            parameters[5].Value = model.upd_user;
            parameters[6].Value = model.upd_date;
            parameters[7].Value = model.check;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
           
           
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(GoldTradeNaming.Model.franchiser_money model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update franchiser_money set ");
            strSql.Append("franchiser_code=@franchiser_code,");
            strSql.Append("franchiser_added_money=@franchiser_added_money,");
            strSql.Append("added_time=@added_time,");
            strSql.Append("ins_user=@ins_user,");
            strSql.Append("ins_date=@ins_date,");
            strSql.Append("upd_user=@upd_user,");
            strSql.Append("upd_date=@upd_date, ");
            strSql.Append("checked=@checked");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@franchiser_code", SqlDbType.SmallInt,2),
					new SqlParameter("@franchiser_added_money", SqlDbType.Money,8),
					new SqlParameter("@added_time", SqlDbType.SmallDateTime),
					new SqlParameter("@ins_user", SqlDbType.NVarChar,50),
					new SqlParameter("@ins_date", SqlDbType.SmallDateTime),
					new SqlParameter("@upd_user", SqlDbType.NVarChar,50),
					new SqlParameter("@upd_date", SqlDbType.SmallDateTime),
                                        new SqlParameter("@checked", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.id;
            parameters[1].Value = model.franchiser_code;
            parameters[2].Value = model.franchiser_added_money;
            parameters[3].Value = model.added_time;
            parameters[4].Value = model.ins_user;
            parameters[5].Value = model.ins_date;
            parameters[6].Value = model.upd_user;
            parameters[7].Value = model.upd_date;
            parameters[8].Value = model.check;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete franchiser_money ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public GoldTradeNaming.Model.franchiser_money GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,franchiser_code,franchiser_added_money,added_time,ins_user,ins_date,upd_user,upd_date,checked from franchiser_money ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            GoldTradeNaming.Model.franchiser_money model = new GoldTradeNaming.Model.franchiser_money();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["franchiser_code"].ToString() != "")
                {
                    model.franchiser_code = int.Parse(ds.Tables[0].Rows[0]["franchiser_code"].ToString());
                }
                if (ds.Tables[0].Rows[0]["franchiser_added_money"].ToString() != "")
                {
                    model.franchiser_added_money = decimal.Parse(ds.Tables[0].Rows[0]["franchiser_added_money"].ToString());
                }
                if (ds.Tables[0].Rows[0]["added_time"].ToString() != "")
                {
                    model.added_time = DateTime.Parse(ds.Tables[0].Rows[0]["added_time"].ToString());
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
                model.check = ds.Tables[0].Rows[0]["checked"].ToString();
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
            strSql.Append("select id,franchiser_code,franchiser_added_money,added_time,ins_user,ins_date,upd_user,upd_date,checked");
            strSql.Append(" FROM franchiser_money ");
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
            parameters[0].Value = "franchiser_money";
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

