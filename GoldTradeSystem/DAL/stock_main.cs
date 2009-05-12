using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//请先添加引用
namespace GoldTradeNaming.DAL
{
    /// <summary>
    /// 数据访问类stock_main。
    /// </summary>
    public class stock_main
    {
        public stock_main()
        { }

        #region 自定义成员方法
        /// <summary>
        /// 返回库存修改记录
        /// </summary>
        /// <returns></returns>
        public DataSet getStockModifyLog()
        {
            DataSet ds;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select franchiser_code,product_spec_id,stock_total_changed,stock_left_changed,ins_user,ins_date,");
            strSql.Append("franchiser_name=(select top 1 franchiser_name from franchiser_info where stock_modify_log.franchiser_code=franchiser_info.franchiser_code),");
            strSql.Append("product_name=(select top 1 product_type_name from product_type where product_type.product_type_id=stock_modify_log.product_id)");
            strSql.Append(" from stock_modify_log");
            try
            {
                ds = DbHelperSQL.Query(strSql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        /// <summary>
        /// 显示经销商的库存信息
        /// </summary>
        /// <param name="Fran_ID">经销ID</param>
        /// <returns></returns>
        public DataSet getAllInfoAboutM(string Fran_ID)
        {
            DataSet ds;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT id,franchiser_code, franchiser_name");
            strSql.Append("=(select top 1 franchiser_name from franchiser_info where franchiser_info.franchiser_code=stock_main.franchiser_code)");
            strSql.Append(",product_id,product_spec_id,product_type_name");
            strSql.Append("=(select top 1 product_type_name from product_type where product_type.product_type_id=stock_main.product_id )");
            strSql.Append(",stock_total,count_total=(convert(int,stock_total/product_spec_id)), stock_left,count_left=(convert(int,stock_left/product_spec_id)), ins_user, ins_date, upd_user,upd_date ");
            strSql.Append(" FROM stock_main ");
            if (Fran_ID != "")
            {
                strSql.Append(" where " + " franchiser_code = '" + Fran_ID + "'");

            }
                try
                {
                    ds = DbHelperSQL.Query(strSql.ToString());
                }
                catch
                {

                    throw new Exception("操作过程出错");

                }

            return ds;

        }
        /// <summary>
        ///经销总余额
        ///writer:alex yi
        /// </summary>
        /// <returns></returns>
        public String getLeftMoney()
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select sum(franchiser_balance_money) as left_money from franchiser_info");
                DataSet ds = DbHelperSQL.Query(strSql.ToString());
                string returnValue = string.Empty;
                if (ds.Tables[0].Rows.Count <= 0)
                {
                    return "0";
                }
                else
                {
                    returnValue = ds.Tables[0].Rows[0][0].ToString();
                }
                return returnValue;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        /// <summary>
        /// 经销总交易额
        /// </summary>
        /// <returns></returns>
        public String getSumTrade()
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select sum(trade_total_money) from franchiser_trade");
                DataSet ds = DbHelperSQL.Query(strSql.ToString());
                if (ds.Tables[0].Rows.Count == 0)
                {
                    return "0";
                }
                string returnValue = ds.Tables[0].Rows[0][0].ToString().Trim();
                return returnValue;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        } /// <summary>
        /// 经销商入帐总额
        /// </summary>
        /// <returns></returns>
        public String getAddMoney()
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select sum(franchiser_added_money) as added_money from franchiser_money");
                DataSet ds = DbHelperSQL.Query(strSql.ToString());
                string retrunValue = string.Empty;
                if (ds.Tables[0].Rows.Count <= 0)
                {
                    return "0";
                }
                else
                {
                    retrunValue = ds.Tables[0].Rows[0][0].ToString();
                }
                return retrunValue;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 获取销售报表
        /// writer:yiyong 20090425
        /// </summary>
        /// <returns></returns>
        /// modify date:20090512
        /// modify content:(1)修改错误的传入参数
        ///                (2)修改stock_left,stock_total的类型(int,4)----->(decimal,8)
        public DataSet getSalesReport(string time_from,string time_to)
        {
            DataSet ds;
            try
            {
                StringBuilder strSql = new StringBuilder();
                string timeFrom = string.Empty;
                string timeTo = string.Empty;
                if (time_from == "")
                {
                    timeFrom=("1900-01-01 00:00:00");
                }
                else
                {

                    timeFrom=(time_from.Trim() + " 00:00:00");
                }

                if (time_to == "")
                {

                    timeTo=(DateTime.Now.ToString("yyyy-MM-dd") + " 23:59:59");
                    string temp = timeTo;

                }
                else
                {

                    timeTo = (time_to.Trim() + " 23:59:59");
                }
                strSql.Append("select product_type.product_type_id,product_type.product_spec_weight,product_type.product_type_name,");
                strSql.Append("order_product_amount=isnull((sum(franchiser_order_desc.order_product_amount)),''),");
                strSql.Append("stock_total=isnull(convert(int,(sum(stock_main.stock_total))),0),");
                strSql.Append("stock_left=isnull((convert(int,sum(stock_main.stock_left))),0),");
                strSql.Append("trade_money=isnull((sum(franchiser_trade_desc.trade_money)),0.0000),");
                strSql.Append("trade_weight=isnull((convert(int,sum(franchiser_trade_desc.trade_weight/franchiser_trade_desc.product_spec_id))),0)");
                strSql.Append("from product_type");
                strSql.Append(" left join franchiser_order_desc on (product_type.product_type_id=franchiser_order_desc.product_id");
                strSql.Append(" and product_type.product_spec_weight=franchiser_order_desc.product_spec_id and franchiser_order_desc.ins_date between @ins_date_begin and @ins_date_end)");
                strSql.Append(" left join stock_main  on(product_type.product_type_id=stock_main.product_id ");
                strSql.Append(" and product_type.product_spec_weight=stock_main.product_spec_id and stock_main.ins_date between @ins_date_begin and @ins_date_end)");
                strSql.Append(" left join franchiser_trade_desc  on(product_type.product_type_id=franchiser_trade_desc.product_id");
                strSql.Append(" and product_type.product_spec_weight=franchiser_trade_desc.product_spec_id and franchiser_trade_desc.ins_date between @ins_date_begin and @ins_date_end)");
                strSql.Append(" group by product_type.product_type_id,product_type.product_spec_weight,product_type.product_type_name");
                SqlParameter[] parameters = {
					new SqlParameter("@ins_date_begin", SqlDbType.NVarChar,50),
					new SqlParameter("@ins_date_end", SqlDbType.NVarChar,50)};
                parameters[0].Value = timeFrom;
                parameters[1].Value = timeTo;
				
               // strSql.Append(" select distinct product_type_id,product_type_name from product_type");

                ds = DbHelperSQL.Query(strSql.ToString(), parameters);

               
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        ///<summary>
        ///库存信息修改
        /// </summary>
        ///<param name="fran_id">经销商ID</param> 
        ///<param name="product_type_id">产品类别ID</param>
        ///<param name="product_kind_id">产品规格ID</param>
        ///<param name="tag">变更标记， 0-增加，1-减少</param>
        ///<param name="mount">库存变更量</param>
        ///<returns name="tmp_tag">true:执行成功，false:执行失败</returns>
        //////modify date:20090511
        ///modifier:yiyong
        ///modify content:(1)int product_kind_id----->decimal product_kind_id
        /// (2)修改stock_left,stock_total,product_spec_id三个变量为decimal,8 
        public bool stock_chang(string fran_id, int product_type_id, decimal product_kind_id, int tag, int mount)
        {
            Boolean tmp_tag = false;
            try
            {

                StringBuilder strQuery = new StringBuilder();
                strQuery.Append("select * from stock_main ");
                strQuery.Append(" where  franchiser_code=@franchiser_code and product_id=@product_id and product_spec_id=@product_spec_id ");
                SqlParameter[] parameters1 = {
					new SqlParameter("@franchiser_code", SqlDbType.NVarChar,50),
					new SqlParameter("@product_id", SqlDbType.Int,4),
					new SqlParameter("@product_spec_id", SqlDbType.Decimal,8)};//(2) 20090511 yiyong将SqlDbType由int 4变为 Decimal,8
                parameters1[0].Value = fran_id;
                parameters1[1].Value = product_type_id;
                parameters1[2].Value = product_kind_id;

                DataSet ds = DbHelperSQL.Query(strQuery.ToString(), parameters1);

                if (ds == null || ds.Tables[0].Rows.Count == 0)
                {
                    return tmp_tag;
                }

                decimal stock_total = Convert.ToDecimal(ds.Tables[0].Rows[0]["stock_total"]);
                decimal stock_left = Convert.ToDecimal(ds.Tables[0].Rows[0]["stock_left"]);

                StringBuilder strUpdate = new StringBuilder();

                strUpdate.Append(" update stock_main set stock_total=@stock_total and  stock_left=@stock_left  ");
                strUpdate.Append("  where  franchiser_code=@franchiser_code and product_id=@product_id and product_spec_id=@product_spec_id  ");
                SqlParameter[] parameters2 = {
					new SqlParameter("@franchiser_code", SqlDbType.NVarChar,50),
					new SqlParameter("@product_id", SqlDbType.Int,4),
					new SqlParameter("@product_spec_id", SqlDbType.Decimal,8),
                    new SqlParameter("@stock_total", SqlDbType.Decimal,8), 
					new SqlParameter("@stock_left", SqlDbType.Decimal,8)  
                                            };
                parameters2[0].Value = stock_total + mount;
                if (tag == 0) parameters2[1].Value = stock_left + mount;
                else if (tag == 1) parameters2[1].Value = stock_left - mount;
                parameters2[2].Value = fran_id;
                parameters2[3].Value = product_type_id;
                parameters2[4].Value = product_kind_id;


                int tmp = DbHelperSQL.ExecuteSql(strUpdate.ToString(), parameters2);
                if (tmp > 0)
                    tmp_tag = true;





            }
            catch { throw; }

            return tmp_tag;



        }






        #endregion


        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("id", "stock_main");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from stock_main");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(GoldTradeNaming.Model.stock_main model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into stock_main(");
            strSql.Append("franchiser_code,product_id,product_spec_id,stock_total,stock_left,ins_user,ins_date,upd_user,upd_date)");
            strSql.Append(" values (");
            strSql.Append("@franchiser_code,@product_id,@product_spec_id,@stock_total,@stock_left,@ins_user,@ins_date,@upd_user,@upd_date)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@franchiser_code", SqlDbType.NVarChar,50),
					new SqlParameter("@product_id", SqlDbType.Int,4),
					new SqlParameter("@product_spec_id", SqlDbType.Decimal,8),
					new SqlParameter("@stock_total", SqlDbType.Decimal,8),
					new SqlParameter("@stock_left", SqlDbType.Decimal,8),
					new SqlParameter("@ins_user", SqlDbType.NVarChar,50),
					new SqlParameter("@ins_date", SqlDbType.SmallDateTime),
					new SqlParameter("@upd_user", SqlDbType.NVarChar,50),
					new SqlParameter("@upd_date", SqlDbType.SmallDateTime)};
            parameters[0].Value = model.franchiser_code;
            parameters[1].Value = model.product_id;
            parameters[2].Value = model.product_spec_id;
            parameters[3].Value = model.stock_total;
            parameters[4].Value = model.stock_left;
            parameters[5].Value = model.ins_user;
            parameters[6].Value = model.ins_date;
            parameters[7].Value = model.upd_user;
            parameters[8].Value = model.upd_date;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
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
        public void Update(GoldTradeNaming.Model.stock_main model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update stock_main set ");
            strSql.Append("franchiser_code=@franchiser_code,");
            strSql.Append("product_id=@product_id,");
            strSql.Append("product_spec_id=@product_spec_id,");
            strSql.Append("stock_total=@stock_total,");
            strSql.Append("stock_left=@stock_left,");
            strSql.Append("ins_user=@ins_user,");
            strSql.Append("ins_date=@ins_date,");
            strSql.Append("upd_user=@upd_user,");
            strSql.Append("upd_date=@upd_date");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@franchiser_code", SqlDbType.NVarChar,50),
					new SqlParameter("@product_id", SqlDbType.Int,4),
					new SqlParameter("@product_spec_id", SqlDbType.Decimal,8),
					new SqlParameter("@stock_total", SqlDbType.Decimal,8),
					new SqlParameter("@stock_left", SqlDbType.Decimal,8),
					new SqlParameter("@ins_user", SqlDbType.NVarChar,50),
					new SqlParameter("@ins_date", SqlDbType.SmallDateTime),
					new SqlParameter("@upd_user", SqlDbType.NVarChar,50),
					new SqlParameter("@upd_date", SqlDbType.SmallDateTime)};
            parameters[0].Value = model.id;
            parameters[1].Value = model.franchiser_code;
            parameters[2].Value = model.product_id;
            parameters[3].Value = model.product_spec_id;
            parameters[4].Value = model.stock_total;
            parameters[5].Value = model.stock_left;
            parameters[6].Value = model.ins_user;
            parameters[7].Value = model.ins_date;
            parameters[8].Value = model.upd_user;
            parameters[9].Value = model.upd_date;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新库存中的库存总量,可用库存
        /// writeBy:yiyong
        /// writeDate:20090418
        /// modifyDate:20090512
        /// mdoify Content:将stock_left,stock_total的类型由（int,4）改为(decimal 8)
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int updateStock(GoldTradeNaming.Model.stock_main model)
        {
            int returnValue = int.MinValue;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update stock_main set ");
            strSql.Append("stock_total=@stock_total,");
            strSql.Append("stock_left=@stock_left,");
            strSql.Append("upd_user=@upd_user");
            strSql.Append(" where id=@id ");
            try
            {
                SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@stock_total", SqlDbType.Decimal,8),
					new SqlParameter("@stock_left", SqlDbType.Decimal,8),
					new SqlParameter("@upd_user", SqlDbType.NVarChar,50)};
                parameters[0].Value = model.id;
                parameters[1].Value = model.stock_total;
                parameters[2].Value = model.stock_left;
                parameters[3].Value = model.upd_user;
                returnValue = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            }
            catch {
                throw new Exception("操作过程中出错");
            }
            return returnValue;
        }
        public bool updateStock1(GoldTradeNaming.Model.stock_main model)
        {
            using (SqlConnection conn = new SqlConnection(PubConstant.ConnectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    int result = 0;
                    SqlCommand cmd = new SqlCommand();
                    try
                    {
                        StringBuilder strSql = new StringBuilder();
            strSql.Append("update stock_main set ");
            strSql.Append("stock_total=@stock_total,");
            strSql.Append("stock_left=@stock_left,");
            strSql.Append("upd_user=@upd_user");
            strSql.Append(" where id=@id ");
            
                SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@stock_total", SqlDbType.Decimal,8),
					new SqlParameter("@stock_left", SqlDbType.Decimal,8),
					new SqlParameter("@upd_user", SqlDbType.NVarChar,50)};
                    parameters[0].Value = model.id;
                    parameters[1].Value = model.stock_total;
                    parameters[2].Value = model.stock_left;
                    parameters[3].Value = model.upd_user;
                    cmd.CommandText = strSql.ToString();
                    cmd.Transaction = trans;
                    cmd.Connection = conn;
                    cmd.Parameters.AddRange(parameters);
                    result += cmd.ExecuteNonQuery();


                    strSql = new StringBuilder();
                    cmd = new SqlCommand();
                    strSql.Append("insert into stock_modify_log (");
                    strSql.Append("franchiser_code,product_id,product_spec_id,stock_total_changed,stock_left_changed,ins_user)");
                    strSql.Append(" values(");
                    strSql.Append("@franchiser_code,@product_id,@product_spec_id,@stock_total_changed,@stock_left_changed,@ins_user)");
                    SqlParameter[] parameter2 ={
                                                    new SqlParameter("@franchiser_code", SqlDbType.SmallInt,2),
                                                    new SqlParameter("@product_id", SqlDbType.Int,4),
                                                    new SqlParameter("@product_spec_id", SqlDbType.Decimal,8),
                                                    new SqlParameter("@stock_total_changed", SqlDbType.Decimal,8),
                                                    new SqlParameter("@stock_left_changed", SqlDbType.Decimal,8),
                                                    new SqlParameter("@ins_user", SqlDbType.NVarChar,50)

                                                  };
                    parameter2[0].Value = model.franchiser_code;
                    parameter2[1].Value = model.product_id;
                    parameter2[2].Value = model.product_spec_id;
                    parameter2[3].Value = model.changeMount;
                    parameter2[4].Value = model.changeMount;
                    parameter2[5].Value = model.upd_user;
                    cmd.Parameters.AddRange(parameter2);
                    cmd.CommandText = strSql.ToString();
                    cmd.Transaction = trans;
                    cmd.Connection = conn;
                    result += cmd.ExecuteNonQuery();
                    trans.Commit();
                    return true;
 
                    }
                    catch
                    {
                        trans.Rollback();
                        return false;
                    }
                }
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete stock_main ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public GoldTradeNaming.Model.stock_main GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            //strSql.Append("select  top 1 id,franchiser_code,product_id,product_spec_id,stock_total,stock_left,ins_user,ins_date,upd_user,upd_date from stock_main ");
            strSql.Append("select  top 1 id,franchiser_code,product_id,");
            strSql.Append("franchiser_name=(select top 1 franchiser_name from franchiser_info where franchiser_code=stock_main.franchiser_code),");
            strSql.Append("product_spec_id,product_type_name=(select top 1 product_type_name from product_type where product_type.product_type_id=stock_main.product_id ),");
            strSql.Append("stock_total,stock_left,ins_user,ins_date,upd_user,upd_date from stock_main");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;
            DataSet ds;
            GoldTradeNaming.Model.stock_main model = new GoldTradeNaming.Model.stock_main();
            try
            {
                 ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            }
            catch
            {
                throw new Exception("操作过程中出错");
            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                model.franchiser_code = ds.Tables[0].Rows[0]["franchiser_code"].ToString();
                if (ds.Tables[0].Rows[0]["product_id"].ToString() != "")
                {
                    model.product_id = int.Parse(ds.Tables[0].Rows[0]["product_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["product_spec_id"].ToString() != "")
                {
                    //model.product_spec_id = int.Parse(ds.Tables[0].Rows[0]["product_spec_id"].ToString());
                    decimal specId = Convert.ToDecimal(ds.Tables[0].Rows[0]["product_spec_id"].ToString());
                    model.product_spec_id = decimal.Round(specId, 4);
                }
                if (ds.Tables[0].Rows[0]["stock_total"].ToString() != "")
                {
                    //model.stock_total = int.Parse(ds.Tables[0].Rows[0]["stock_total"].ToString());
                    decimal stockTotal = Convert.ToDecimal(ds.Tables[0].Rows[0]["stock_total"].ToString());

                    model.stock_total = decimal.Round(stockTotal, 4);
                }
                if (ds.Tables[0].Rows[0]["stock_left"].ToString() != "")
                {
                    //model.stock_left = int.Parse(ds.Tables[0].Rows[0]["stock_left"].ToString());
                    decimal stockLeft = Convert.ToDecimal(ds.Tables[0].Rows[0]["stock_left"].ToString());
                    model.stock_left = decimal.Round(stockLeft, 4);
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
                if (ds.Tables[0].Rows[0]["product_type_name"].ToString() != "")
                {
                    model.product_name = ds.Tables[0].Rows[0]["product_type_name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["product_type_name"].ToString() != "")
                {
                    model.franchiser_name = ds.Tables[0].Rows[0]["franchiser_name"].ToString();
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
            strSql.Append("select id,franchiser_code,product_id,product_spec_id,stock_total,stock_left,ins_user,ins_date,upd_user,upd_date ");
            strSql.Append(" FROM stock_main ");
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
            parameters[0].Value = "stock_main";
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

