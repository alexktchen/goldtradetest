using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//请先添加引用
namespace GoldTradeNaming.DAL
{
    /// <summary>
    /// 数据访问类product_type。
    /// </summary>
    public class product_type
    {
        public product_type()
        { }
        #region 自定义成员方法

        ///<summary>
        ///根据产品类别ID，产品类别名称，产品规格，产品状态进行查询
        ///</summary>
        ///<param>
        /// type_id:产品类别ID
        /// type_name:产品类别
        /// type_kind:产品类别K数
        /// type_status:产品状态
        /// </param>
        /// 提供模糊查询
        public DataSet queryAction(string type_id, string type_name, string type_kind, string type_status, string order_add_price, string trade_add_price, string type)
        {

            StringBuilder strQuery = new StringBuilder();
            try
            {
                strQuery.Append("select product_type_id,product_type_name,product_spec_weight,product_state,ins_user,ins_date,upd_user,upd_date,order_add_price,trade_add_price,type ");
                strQuery.Append(" FROM product_type ");
                strQuery.Append("WHERE ");
                if (type_id == null || type_id.Trim() == "")
                {
                    strQuery.Append(" product_type_id like '%'");

                }
                else
                {
                    strQuery.Append(" product_type_id like '%" + type_id + "%'");
                }


                if (type_name == null || type_name.Trim() == "")
                {
                    strQuery.Append(" and product_type_name like '%'");
                }
                else
                {

                    strQuery.Append(" and  product_type_name like '%" + type_name + "%'");
                }

                if (type_kind == null || type_kind.Trim() == "")
                {
                    strQuery.Append(" and product_spec_weight like '%' ");
                }
                else
                {
                    strQuery.Append(" and product_spec_weight like '%" + type_kind + "%' ");
                }


                if (type_status == null || type_status.Trim() == "")
                {
                    strQuery.Append(" and product_state like '%'");
                }
                else
                {
                    strQuery.Append(" and product_state like '%" + type_status + "%'");
                }

                if (order_add_price == null || order_add_price == "")
                {
                    strQuery.Append(" and 1=1");
                }
                else
                {

                    strQuery.Append(" and order_add_price = " + decimal.Parse(order_add_price));
                }

                if (trade_add_price == null || trade_add_price == "")
                {
                    strQuery.Append(" and 1=1 ");
                }
                else
                {

                    strQuery.Append(" and trade_add_price = " + decimal.Parse(trade_add_price));
                }

                if (type == null || type == "")
                {
                    strQuery.Append(" and type like '%' ");
                }
                else
                {

                    strQuery.Append(" and type like '" + type + "'");
                }





            }
            catch
            {
                throw;
            }
            return DbHelperSQL.Query(strQuery.ToString());


        }


        ///<summary>
        /// 判断product_type_id是否存在于product_type表中，存在返回对应的name，否则返回空
        /// </summary>

        public string check_id(string product_type_id)
        {

            string name = "";
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append("select product_type_name from product_type where product_type_id  like '" + product_type_id + "'");
                DataSet ds = DbHelperSQL.Query(sql.ToString());
                if (ds == null || ds.Tables[0].Rows.Count == 0)
                {
                    name = "";
                }
                else
                {

                    name = ds.Tables[0].Rows[0][0].ToString();
                }

            }
            catch
            {
                throw;
            }
            return name;


        }


        ///<summary>
        /// 判断product_name是否存在誉product_type表中，存在返回对应的ID，否则返回空
        /// </summary>

        public string check_name(string product_type_name)
        {

            string id = "";
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append("select product_type_id from product_type where  product_type_name like'" + product_type_name + "'");
                DataSet ds = DbHelperSQL.Query(sql.ToString());
                if (ds == null || ds.Tables[0].Rows.Count == 0)
                {
                    id = "";
                }
                else
                {

                    id = ds.Tables[0].Rows[0][0].ToString();
                }

            }
            catch
            {
                throw;
            }
            return id;


        }


        ///<sumary>
        /// product_name下拉框
        /// </sumary>

        public DataSet getAll(string type)
        {

            try
            {
                StringBuilder strSql = new StringBuilder();
                if (type == null || type == "")
                {
                    strSql.Append("SELECT DISTINCT product_type_name FROM product_type ");

                }
                else
                    strSql.Append("SELECT DISTINCT product_type_name FROM product_type where type ='" + type + "'");

                return DbHelperSQL.Query(strSql.ToString());
            }
            catch
            {
                throw;
            }

        }

        /// <summary>
        /// 返回数据库中白银的记录
        /// </summary>
        /// <returns></returns>
        public DataSet getSilver()
        {

            try
            {
                StringBuilder strsql = new StringBuilder();
                strsql.Append(" select order_add_price,trade_add_price from product_type where  type='1' ");
                DataSet ds= DbHelperSQL.Query(strsql.ToString());
                return ds;

            }
            catch
            {
                throw;
            }
       

        }

       

        #endregion





        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("product_type_id", "product_type");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int product_type_id, int product_spec_weight)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from product_type");
            strSql.Append(" where product_type_id=@product_type_id and product_spec_weight=@product_spec_weight ");
            SqlParameter[] parameters = {
					new SqlParameter("@product_type_id", SqlDbType.Int,4),
					new SqlParameter("@product_spec_weight", SqlDbType.Int,4)};
            parameters[0].Value = product_type_id;
            parameters[1].Value = product_spec_weight;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(GoldTradeNaming.Model.product_type model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into product_type(");
            strSql.Append("product_type_id,product_type_name,product_spec_weight,product_state,ins_user,ins_date,upd_user,upd_date,order_add_price,trade_add_price,type)");
            strSql.Append(" values (");
            strSql.Append("@product_type_id,@product_type_name,@product_spec_weight,@product_state,@ins_user,@ins_date,@upd_user,@upd_date,@order_add_price,@trade_add_price,@type)");
            SqlParameter[] parameters = {
					new SqlParameter("@product_type_id", SqlDbType.Int,4),
					new SqlParameter("@product_type_name", SqlDbType.NVarChar,50),
					new SqlParameter("@product_spec_weight", SqlDbType.Int,4),
					new SqlParameter("@product_state", SqlDbType.NVarChar,50),
					new SqlParameter("@ins_user", SqlDbType.NVarChar,50),
					new SqlParameter("@ins_date", SqlDbType.SmallDateTime),
					new SqlParameter("@upd_user", SqlDbType.NVarChar,50),
					new SqlParameter("@upd_date", SqlDbType.SmallDateTime),
                    new SqlParameter("@order_add_price",SqlDbType.Money,8),
                    new SqlParameter("@trade_add_price",SqlDbType.Money,8),
                    new SqlParameter("@type",SqlDbType.NVarChar,50)
                                        };
            parameters[0].Value = model.product_type_id;
            parameters[1].Value = model.product_type_name;
            parameters[2].Value = model.product_spec_weight;
            parameters[3].Value = model.product_state;
            parameters[4].Value = model.ins_user;
            parameters[5].Value = model.ins_date;
            parameters[6].Value = model.upd_user;
            parameters[7].Value = model.upd_date;
            parameters[8].Value = model.order_add_price;
            parameters[9].Value = model.trade_add_price;
            parameters[10].Value = model.type;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="tag">0：更新失败；>0:更新成功</param>
        public void Update(GoldTradeNaming.Model.product_type model)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update product_type set ");
                strSql.Append("product_type_name=@product_type_name,");
                strSql.Append("product_state=@product_state,");
                strSql.Append("upd_user=@upd_user,");
                strSql.Append("upd_date=@upd_date, ");

                strSql.Append("order_add_price=@order_add_price,");
                strSql.Append("trade_add_price=@trade_add_price,");
                strSql.Append("type=@type");

                strSql.Append(" where product_type_id=@product_type_id and product_spec_weight=@product_spec_weight ");
                SqlParameter[] parameters = {
					new SqlParameter("@product_type_id", SqlDbType.Int,4),
					new SqlParameter("@product_type_name", SqlDbType.NVarChar,50),
					new SqlParameter("@product_spec_weight", SqlDbType.Int,4),
					new SqlParameter("@product_state", SqlDbType.NVarChar,50),
		
					new SqlParameter("@upd_user", SqlDbType.NVarChar,50),
					new SqlParameter("@upd_date", SqlDbType.DateTime),
                                      
                    new SqlParameter("@order_add_price",SqlDbType.Money,8),
                    new SqlParameter("@trade_add_price",SqlDbType.Money,8),
                    new SqlParameter("@type",SqlDbType.NVarChar,50)};
                parameters[0].Value = model.product_type_id;
                parameters[1].Value = model.product_type_name;
                parameters[2].Value = model.product_spec_weight;
                parameters[3].Value = model.product_state;

                parameters[4].Value = model.upd_user;
                parameters[5].Value = model.upd_date;
                parameters[6].Value = model.order_add_price;
                parameters[7].Value = model.trade_add_price;
                parameters[8].Value = model.type;

                DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);


                //同步更新


                StringBuilder strSql1 = new StringBuilder();

                strSql1.Append("update product_type set ");
                strSql1.Append("product_type_name=@product_type_name,");
                strSql1.Append("order_add_price=@order_add_price,");
                strSql1.Append("trade_add_price=@trade_add_price, ");
                strSql1.Append("type=@type ");
                strSql1.Append(" where product_type_id=@product_type_id ");
                SqlParameter[] parameters1 = {
	                new SqlParameter("@product_type_id", SqlDbType.Int,4),
					new SqlParameter("@product_type_name", SqlDbType.NVarChar,50),
                    new SqlParameter("@order_add_price",SqlDbType.Money,8),
                    new SqlParameter("@trade_add_price",SqlDbType.Money,8),
                    new SqlParameter("@type", SqlDbType.NVarChar,50),};

                parameters1[0].Value = model.product_type_id;
                parameters1[1].Value = model.product_type_name;
                parameters1[2].Value = model.order_add_price;
                parameters1[3].Value = model.trade_add_price;
                parameters1[4].Value = model.type;


                DbHelperSQL.ExecuteSql(strSql1.ToString(), parameters1);

                //如果产品类别是白银，则需要更新所有银的价格
                if (model.type == "1")
                {
                    StringBuilder strSql2 = new StringBuilder();
                    strSql2.Append("update product_type set ");
                    strSql2.Append("order_add_price=@order_add_price,");
                    strSql2.Append("trade_add_price=@trade_add_price ");
                    strSql2.Append(" where type=@type ");
                    SqlParameter[] parameters2 = {
	              new SqlParameter("@order_add_price",SqlDbType.Money,8),
                  new SqlParameter("@trade_add_price",SqlDbType.Money,8),
                  new SqlParameter("@type", SqlDbType.NVarChar,50)
                   };

                    parameters2[0].Value = model.order_add_price;
                    parameters2[1].Value = model.trade_add_price;
                    parameters2[2].Value = model.type;
                    DbHelperSQL.ExecuteSql(strSql2.ToString(), parameters2);
                }
            }
            catch
            {
                throw;
            }

        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int product_type_id, int product_spec_weight)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete product_type ");
            strSql.Append(" where product_type_id=@product_type_id and product_spec_weight=@product_spec_weight ");
            SqlParameter[] parameters = {
					new SqlParameter("@product_type_id", SqlDbType.Int,4),
					new SqlParameter("@product_spec_weight", SqlDbType.Int,4)};
            parameters[0].Value = product_type_id;
            parameters[1].Value = product_spec_weight;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public GoldTradeNaming.Model.product_type GetModel(int product_type_id, int product_spec_weight)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 product_type_id,product_type_name,product_spec_weight,product_state,ins_user,ins_date,upd_user,upd_date,order_add_price,trade_add_price,type from product_type ");
            strSql.Append(" where product_type_id=@product_type_id and product_spec_weight=@product_spec_weight ");
            SqlParameter[] parameters = {
					new SqlParameter("@product_type_id", SqlDbType.Int,4),
					new SqlParameter("@product_spec_weight", SqlDbType.Int,4)};
            parameters[0].Value = product_type_id;
            parameters[1].Value = product_spec_weight;

            GoldTradeNaming.Model.product_type model = new GoldTradeNaming.Model.product_type();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["product_type_id"].ToString() != "")
                {
                    model.product_type_id = int.Parse(ds.Tables[0].Rows[0]["product_type_id"].ToString());
                }
                model.product_type_name = ds.Tables[0].Rows[0]["product_type_name"].ToString();
                if (ds.Tables[0].Rows[0]["product_spec_weight"].ToString() != "")
                {
                    model.product_spec_weight = int.Parse(ds.Tables[0].Rows[0]["product_spec_weight"].ToString());
                }
                model.product_state = ds.Tables[0].Rows[0]["product_state"].ToString();
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
                model.order_add_price = decimal.Parse(ds.Tables[0].Rows[0]["order_add_price"].ToString());
                model.trade_add_price = decimal.Parse(ds.Tables[0].Rows[0]["trade_add_price"].ToString());
                model.type = ds.Tables[0].Rows[0]["type"].ToString();
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
            strSql.Append("select product_type_id,product_type_name,product_spec_weight,product_state,ins_user,ins_date,upd_user,upd_date,order_add_price,trade_add_price,type ");
            strSql.Append(" FROM product_type");
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
            parameters[0].Value = "product_type";
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

