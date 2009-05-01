using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using Maticsoft.DBUtility;//请先添加引用
namespace GoldTradeNaming.DAL
{
    /// <summary>
    /// 数据访问类franchiser_order。
    /// </summary>
    public class franchiser_order
    {

        GoldTradeNaming.DAL.product_type product_type = new GoldTradeNaming.DAL.product_type();
        GoldTradeNaming.DAL.franchiser_info franchiser_info = new GoldTradeNaming.DAL.franchiser_info();
        public franchiser_order()
        { }
        #region 自定义成员方法
        /// <summary>
        /// 带出product_id下拉框
        /// </summary>
        /// <returns></returns>
        //public DataSet getproduct_type_id()
        //{

        //    return product_type.getAll();

        //}


        /// <summary>
        /// 更新订单order信息  by yuxiaowei 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateOrderInfo(GoldTradeNaming.Model.franchiser_order model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update franchiser_order set ");
            strSql.Append("franchiser_order_trans_type=@franchiser_order_trans_type,");
            strSql.Append("franchiser_order_address=@franchiser_order_address,");
            strSql.Append("franchiser_order_postcode=@franchiser_order_postcode,");
            strSql.Append("franchiser_order_handle_man=@franchiser_order_handle_man,");
            strSql.Append("franchiser_order_handle_tel=@franchiser_order_handle_tel,");
            strSql.Append("franchiser_order_handle_phone=@franchiser_order_handle_phone,");

            strSql.Append("upd_user=@upd_user,");
            strSql.Append("upd_date=getdate()");
            strSql.Append(" where franchiser_order_id=@franchiser_order_id ");
            SqlParameter[] parameters = {
					new SqlParameter("@franchiser_order_id", SqlDbType.Int,4),			
					new SqlParameter("@franchiser_order_trans_type", SqlDbType.NVarChar,50),
					new SqlParameter("@franchiser_order_address", SqlDbType.NVarChar,50),
					new SqlParameter("@franchiser_order_postcode", SqlDbType.NVarChar,50),
					new SqlParameter("@franchiser_order_handle_man", SqlDbType.NVarChar,50),
					new SqlParameter("@franchiser_order_handle_tel", SqlDbType.NVarChar,50),
					new SqlParameter("@franchiser_order_handle_phone", SqlDbType.NVarChar,50),				
					new SqlParameter("@upd_user", SqlDbType.NVarChar,50)};

            parameters[0].Value = model.franchiser_order_id;
            parameters[1].Value = model.franchiser_order_trans_type;
            parameters[2].Value = model.franchiser_order_address;
            parameters[3].Value = model.franchiser_order_postcode;
            parameters[4].Value = model.franchiser_order_handle_man;
            parameters[5].Value = model.franchiser_order_handle_tel;
            parameters[6].Value = model.franchiser_order_handle_phone;
            parameters[7].Value = model.upd_user;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 获得交易主表 by yuxiaowei
        /// </summary>
        public DataSet GetOrderInfo(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select franchiser_order_id,franchiser_code,
                                franchiser_order_trans_type=case when franchiser_order_trans_type='0' THEN '航空' 
                                when franchiser_order_trans_type='1' Then'邮寄' when franchiser_order_trans_type='2' Then '自取' ELSE '其他' END,
                                franchiser_order_address,franchiser_order_postcode,franchiser_order_handle_man,
                                franchiser_order_handle_tel,franchiser_order_handle_phone,franchiser_order_price,
                                franchiser_order_time, franchiser_order_state franchiser_order_amount_money,
                                canceled_reason,ins_user,ins_date,upd_user,upd_date ");
            strSql.Append(" FROM franchiser_order ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }



        /// <summary>
        /// 更具product_name带出product_spec_weight
        /// </summary>
        /// <param name="product_naem"></param>
        /// <returns></returns>
        public DataSet getproduct_spec(string product_name)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT DISTINCT product_spec_weight FROM product_type where product_type_name ='" + product_name + "'");

            return DbHelperSQL.Query(strSql.ToString());

        }


        /// <summary>
        /// 根据经销商号得到他的账面余额
        /// </summary>
        /// <param name="franchiser_code"></param>
        /// <returns></returns>
        public GoldTradeNaming.Model.franchiser_info GetInforModel(int franchiser_code)
        {
            return franchiser_info.GetModel(franchiser_code);
        }


        /// <summary>
        /// 更新账面余额
        /// </summary>
        /// <param name="model"></param>
        public void updateInfor(GoldTradeNaming.Model.franchiser_info model)
        {
            franchiser_info.Update(model);


        }

        /// <summary>
        /// 获得产品列表
        /// </summary>
        public DataSet GetProductList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select product_type_id,product_type_name,product_spec_weight,product_state,price_appraise=(
                            select realtime_base_price+order_add_price from realtime_price
                             where [id] = (select max([id]) as [id] from  realtime_price))  FROM product_type where product_state = '0'");

           // strSql.Append(" and type='" + prodtype + "'");

            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得黄金产品列表
        /// </summary>
        /// <returns></returns>
        public DataSet GetGoldProduct()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select product_type_id,product_type_name,product_spec_weight,order_add_price,
                            trade_add_price,product_state,type,price_appraise=order_add_price + (
                            select realtime_base_price from realtime_price
                            where [id] = (select max([id]) as [id] from  realtime_price))
                            FROM product_type where product_state = '0' and type='0'");
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得白银产品列表
        /// </summary>
        /// <returns></returns>
        public DataSet GetSilverProduct()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select product_type_id,product_type_name,product_spec_weight,order_add_price,
                            trade_add_price,product_state,type,price_appraise=order_add_price
                            FROM product_type where product_state = '0' and type='1'");
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得产品库存列别金块 by yuxiaowei
        /// </summary>
        public DataSet GetGoldStock(string franchiser_code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@" select c.realtime_base_price , a.product_type_id ,a.product_type_name,a.trade_add_price, a.product_spec_weight,b.stock_left
                                    from realtime_price c, product_type a,stock_main b
                                    where (a.product_type_id=b.product_id and a.product_spec_weight = b.product_spec_id) ");
            strSql.Append("and a.product_state='0' and a.type='0' and b.franchiser_code =N'" + franchiser_code + "'and c.[id]=(select max([id]) as [id] from realtime_price) order by  a.product_type_name, a.product_spec_weight ;");
            return DbHelperSQL.Query(strSql.ToString());
        }

         /// <summary>
        /// 获得产品库存列别白银 by yuxiaowei
        /// </summary>
        public DataSet GetSilverStock(string franchiser_code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@" select  a.product_type_id ,a.product_type_name, a.product_spec_weight,a.trade_add_price as price,b.stock_left
                                    from  product_type a,stock_main b
                                    where (a.product_type_id=b.product_id and a.product_spec_weight = b.product_spec_id) ");
            strSql.Append(" and a.product_state='0' and a.type='1'  and b.franchiser_code =N'" + franchiser_code + "'order by a.product_type_id, a.product_spec_weight ;");

            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 保存订货信息
        /// </summary>
        /// <param name="sm"></param>
        /// <param name="sdlst"></param>
        /// <returns></returns>
        public bool SaveOrderInfo(GoldTradeNaming.Model.franchiser_order model, List<GoldTradeNaming.Model.franchiser_order_desc> orderlst)
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
                        int nextorderid = DbHelperSQL.GetMaxID("franchiser_order_id", "franchiser_order");
                        StringBuilder strSql = new StringBuilder();
                        strSql.Append("insert into franchiser_order(");
                        strSql.Append(@"franchiser_code,franchiser_order_trans_type,franchiser_order_address,franchiser_order_postcode,
                                        franchiser_order_handle_man,franchiser_order_handle_tel,franchiser_order_handle_phone,
                                        franchiser_order_price,franchiser_order_time,
                                        franchiser_order_state,franchiser_order_amount_money,canceled_reason,ins_user,upd_user,franchiser_order_id)");
                        strSql.Append(" values (");
                        strSql.Append(@"@franchiser_code,@franchiser_order_trans_type,@franchiser_order_address,@franchiser_order_postcode,
                                        @franchiser_order_handle_man,@franchiser_order_handle_tel,@franchiser_order_handle_phone,
                                        @franchiser_order_price,@franchiser_order_time,
                                        @franchiser_order_state,@franchiser_order_amount_money,@canceled_reason,@ins_user,@upd_user,@franchiser_order_id)");

                        SqlParameter[] parameters = {
			                new SqlParameter("@franchiser_code", SqlDbType.SmallInt,2),
			                new SqlParameter("@franchiser_order_trans_type", SqlDbType.NVarChar,50),
			                new SqlParameter("@franchiser_order_address", SqlDbType.NVarChar,50),
			                new SqlParameter("@franchiser_order_postcode", SqlDbType.NVarChar,50),
			                new SqlParameter("@franchiser_order_handle_man", SqlDbType.NVarChar,50),
			                new SqlParameter("@franchiser_order_handle_tel", SqlDbType.NVarChar,50),
			                new SqlParameter("@franchiser_order_handle_phone", SqlDbType.NVarChar,50),
			                new SqlParameter("@franchiser_order_price", SqlDbType.Money,8),
			                //new SqlParameter("@franchiser_order_add_price", SqlDbType.Money,8),
			                //new SqlParameter("@franchiser_order_appraise", SqlDbType.Money,8),
			                new SqlParameter("@franchiser_order_time", SqlDbType.SmallDateTime),
			                new SqlParameter("@franchiser_order_state", SqlDbType.NVarChar,50),
			                new SqlParameter("@franchiser_order_amount_money", SqlDbType.Money,8),
			                new SqlParameter("@canceled_reason", SqlDbType.NVarChar,100),
			                new SqlParameter("@ins_user", SqlDbType.NVarChar,50),
			                new SqlParameter("@upd_user", SqlDbType.NVarChar,50),
			                new SqlParameter("@franchiser_order_id", SqlDbType.Int,4)};
                        parameters[0].Value = model.franchiser_code;
                        parameters[1].Value = model.franchiser_order_trans_type;
                        parameters[2].Value = model.franchiser_order_address;
                        parameters[3].Value = model.franchiser_order_postcode;
                        parameters[4].Value = model.franchiser_order_handle_man;
                        parameters[5].Value = model.franchiser_order_handle_tel;
                        parameters[6].Value = model.franchiser_order_handle_phone;
                        parameters[7].Value = model.franchiser_order_price;
                        //parameters[8].Value = model.franchiser_order_add_price;
                        //parameters[9].Value = model.franchiser_order_appraise;
                        parameters[10 - 2].Value = model.franchiser_order_time;
                        parameters[11 - 2].Value = model.franchiser_order_state;
                        parameters[12 - 2].Value = model.franchiser_order_amount_money;
                        parameters[13 - 2].Value = model.canceled_reason;
                        parameters[14 - 2].Value = model.ins_user;
                        parameters[15 - 2].Value = model.upd_user;
                        parameters[16 - 2].Value = nextorderid;
                        cmd.CommandText = strSql.ToString();
                        cmd.Transaction = trans;
                        cmd.Connection = conn;
                        cmd.Parameters.AddRange(parameters);
                        result += cmd.ExecuteNonQuery();

                        foreach (GoldTradeNaming.Model.franchiser_order_desc sd in orderlst)
                        {
                            cmd = new SqlCommand();
                            strSql = new StringBuilder();
                            strSql.Append("insert into franchiser_order_desc(");
                            strSql.Append(@"franchiser_order_id,product_id,product_spec_id,order_product_amount,product_received,
                                            product_unreceived,ins_user,upd_user, realtime_base_price, order_add_price, 
                                            order_appraise, order_weight)");
                            strSql.Append(" values (");
                            strSql.Append(@"@franchiser_order_id,@product_id,@product_spec_id,@order_product_amount,@product_received,
                                            @product_unreceived,@ins_user,@upd_user,@realtime_base_price, @order_add_price,  @order_appraise, @order_weight)");
                            SqlParameter[] parameters2 = {
					                new SqlParameter("@franchiser_order_id", SqlDbType.Int,4),
					                new SqlParameter("@product_id", SqlDbType.Int,4),
					                new SqlParameter("@product_spec_id", SqlDbType.Int,4),
					                new SqlParameter("@order_product_amount", SqlDbType.Int,4),
					                new SqlParameter("@product_received", SqlDbType.Int,4),
					                new SqlParameter("@product_unreceived", SqlDbType.Int,4),
					                new SqlParameter("@ins_user", SqlDbType.NVarChar,50),
					                new SqlParameter("@upd_user", SqlDbType.NVarChar,50),
                                    new SqlParameter("@realtime_base_price", SqlDbType.Decimal,4),
					                new SqlParameter("@order_add_price", SqlDbType.Decimal,4),
					                new SqlParameter("@order_appraise", SqlDbType.Decimal,50),
					                new SqlParameter("@order_weight", SqlDbType.NVarChar,50)              
                                                         };
                            parameters2[0].Value = nextorderid;
                            parameters2[1].Value = sd.product_id;
                            parameters2[2].Value = sd.product_spec_id;
                            parameters2[3].Value = sd.order_product_amount;
                            parameters2[4].Value = sd.product_received;//.product_received;
                            parameters2[5].Value = sd.product_unreceived;//.product_unreceived;
                            parameters2[6].Value = sd.ins_user;
                            parameters2[7].Value = sd.upd_user;
                            parameters2[8].Value = sd.realtime_base_price;
                            parameters2[9].Value = sd.order_add_price;
                            parameters2[10].Value = sd.order_appraise;
                            parameters2[11].Value = sd.order_weight;
                            cmd.Parameters.AddRange(parameters2);
                            cmd.CommandText = strSql.ToString();
                            cmd.Transaction = trans;
                            cmd.Connection = conn;
                            result += cmd.ExecuteNonQuery();
                        }
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
        /// 更新订单状态,确认订单
        /// </summary>
        public bool UpdateOrderState(int franchiser_order_id, string upduser)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update franchiser_order set ");
            strSql.Append("franchiser_order_state='1',");
            strSql.Append("upd_user=@upd_user,");
            strSql.Append("upd_date=getdate()");
            strSql.Append(" where franchiser_order_id=@franchiser_order_id ");
            SqlParameter[] parameters = {
					new SqlParameter("@franchiser_order_id", SqlDbType.Int,4),
					new SqlParameter("@upd_user", SqlDbType.NVarChar,50)};
            parameters[0].Value = franchiser_order_id;
            parameters[1].Value = upduser;

            if (DbHelperSQL.ExecuteSql(strSql.ToString(), parameters) > 0) return true;
            return false;
        }

        #endregion

        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("franchiser_order_id", "franchiser_order");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int franchiser_order_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from franchiser_order");
            strSql.Append(" where franchiser_order_id=@franchiser_order_id ");
            SqlParameter[] parameters = {
					new SqlParameter("@franchiser_order_id", SqlDbType.Int,4)};
            parameters[0].Value = franchiser_order_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(GoldTradeNaming.Model.franchiser_order model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into franchiser_order(");
            strSql.Append("franchiser_code,franchiser_order_trans_type,franchiser_order_address,franchiser_order_postcode,franchiser_order_handle_man,franchiser_order_handle_tel,franchiser_order_handle_phone,franchiser_order_price,franchiser_order_add_price,franchiser_order_appraise,franchiser_order_time,franchiser_order_state,franchiser_order_amount_money,canceled_reason,ins_user,ins_date,upd_user,upd_date)");
            strSql.Append(" values (");
            strSql.Append("@franchiser_code,@franchiser_order_trans_type,@franchiser_order_address,@franchiser_order_postcode,@franchiser_order_handle_man,@franchiser_order_handle_tel,@franchiser_order_handle_phone,@franchiser_order_price,@franchiser_order_add_price,@franchiser_order_appraise,@franchiser_order_time,@franchiser_order_state,@franchiser_order_amount_money,@canceled_reason,@ins_user,@ins_date,@upd_user,@upd_date)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@franchiser_code", SqlDbType.SmallInt,2),
					new SqlParameter("@franchiser_order_trans_type", SqlDbType.NVarChar,50),
					new SqlParameter("@franchiser_order_address", SqlDbType.NVarChar,50),
					new SqlParameter("@franchiser_order_postcode", SqlDbType.NVarChar,50),
					new SqlParameter("@franchiser_order_handle_man", SqlDbType.NVarChar,50),
					new SqlParameter("@franchiser_order_handle_tel", SqlDbType.NVarChar,50),
					new SqlParameter("@franchiser_order_handle_phone", SqlDbType.NVarChar,50),
					new SqlParameter("@franchiser_order_price", SqlDbType.Money,8),
					new SqlParameter("@franchiser_order_add_price", SqlDbType.Money,8),
					new SqlParameter("@franchiser_order_appraise", SqlDbType.Money,8),
					new SqlParameter("@franchiser_order_time", SqlDbType.SmallDateTime),
					new SqlParameter("@franchiser_order_state", SqlDbType.NVarChar,50),
					new SqlParameter("@franchiser_order_amount_money", SqlDbType.Money,8),
					new SqlParameter("@canceled_reason", SqlDbType.NVarChar,100),
					new SqlParameter("@ins_user", SqlDbType.NVarChar,50),
					new SqlParameter("@ins_date", SqlDbType.SmallDateTime),
					new SqlParameter("@upd_user", SqlDbType.NVarChar,50),
					new SqlParameter("@upd_date", SqlDbType.SmallDateTime)};
            parameters[0].Value = model.franchiser_code;
            parameters[1].Value = model.franchiser_order_trans_type;
            parameters[2].Value = model.franchiser_order_address;
            parameters[3].Value = model.franchiser_order_postcode;
            parameters[4].Value = model.franchiser_order_handle_man;
            parameters[5].Value = model.franchiser_order_handle_tel;
            parameters[6].Value = model.franchiser_order_handle_phone;
            parameters[7].Value = model.franchiser_order_price;
            parameters[8].Value = model.franchiser_order_add_price;
            parameters[9].Value = model.franchiser_order_appraise;
            parameters[10].Value = model.franchiser_order_time;
            parameters[11].Value = model.franchiser_order_state;
            parameters[12].Value = model.franchiser_order_amount_money;
            parameters[13].Value = model.canceled_reason;
            parameters[14].Value = model.ins_user;
            parameters[15].Value = model.ins_date;
            parameters[16].Value = model.upd_user;
            parameters[17].Value = model.upd_date;

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
        public void Update(GoldTradeNaming.Model.franchiser_order model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update franchiser_order set ");
            strSql.Append("franchiser_code=@franchiser_code,");
            strSql.Append("franchiser_order_trans_type=@franchiser_order_trans_type,");
            strSql.Append("franchiser_order_address=@franchiser_order_address,");
            strSql.Append("franchiser_order_postcode=@franchiser_order_postcode,");
            strSql.Append("franchiser_order_handle_man=@franchiser_order_handle_man,");
            strSql.Append("franchiser_order_handle_tel=@franchiser_order_handle_tel,");
            strSql.Append("franchiser_order_handle_phone=@franchiser_order_handle_phone,");
            strSql.Append("franchiser_order_price=@franchiser_order_price,");
            strSql.Append("franchiser_order_add_price=@franchiser_order_add_price,");
            strSql.Append("franchiser_order_appraise=@franchiser_order_appraise,");
            strSql.Append("franchiser_order_time=@franchiser_order_time,");
            strSql.Append("franchiser_order_state=@franchiser_order_state,");
            strSql.Append("franchiser_order_amount_money=@franchiser_order_amount_money,");
            strSql.Append("canceled_reason=@canceled_reason,");
            strSql.Append("ins_user=@ins_user,");
            strSql.Append("ins_date=@ins_date,");
            strSql.Append("upd_user=@upd_user,");
            strSql.Append("upd_date=@upd_date");
            strSql.Append(" where franchiser_order_id=@franchiser_order_id ");
            SqlParameter[] parameters = {
					new SqlParameter("@franchiser_order_id", SqlDbType.Int,4),
					new SqlParameter("@franchiser_code", SqlDbType.SmallInt,2),
					new SqlParameter("@franchiser_order_trans_type", SqlDbType.NVarChar,50),
					new SqlParameter("@franchiser_order_address", SqlDbType.NVarChar,50),
					new SqlParameter("@franchiser_order_postcode", SqlDbType.NVarChar,50),
					new SqlParameter("@franchiser_order_handle_man", SqlDbType.NVarChar,50),
					new SqlParameter("@franchiser_order_handle_tel", SqlDbType.NVarChar,50),
					new SqlParameter("@franchiser_order_handle_phone", SqlDbType.NVarChar,50),
					new SqlParameter("@franchiser_order_price", SqlDbType.Money,8),
					new SqlParameter("@franchiser_order_add_price", SqlDbType.Money,8),
					new SqlParameter("@franchiser_order_appraise", SqlDbType.Money,8),
					new SqlParameter("@franchiser_order_time", SqlDbType.SmallDateTime),
					new SqlParameter("@franchiser_order_state", SqlDbType.NVarChar,50),
					new SqlParameter("@franchiser_order_amount_money", SqlDbType.Money,8),
					new SqlParameter("@canceled_reason", SqlDbType.NVarChar,100),
					new SqlParameter("@ins_user", SqlDbType.NVarChar,50),
					new SqlParameter("@ins_date", SqlDbType.SmallDateTime),
					new SqlParameter("@upd_user", SqlDbType.NVarChar,50),
					new SqlParameter("@upd_date", SqlDbType.SmallDateTime)};
            parameters[0].Value = model.franchiser_order_id;
            parameters[1].Value = model.franchiser_code;
            parameters[2].Value = model.franchiser_order_trans_type;
            parameters[3].Value = model.franchiser_order_address;
            parameters[4].Value = model.franchiser_order_postcode;
            parameters[5].Value = model.franchiser_order_handle_man;
            parameters[6].Value = model.franchiser_order_handle_tel;
            parameters[7].Value = model.franchiser_order_handle_phone;
            parameters[8].Value = model.franchiser_order_price;
            parameters[9].Value = model.franchiser_order_add_price;
            parameters[10].Value = model.franchiser_order_appraise;
            parameters[11].Value = model.franchiser_order_time;
            parameters[12].Value = model.franchiser_order_state;
            parameters[13].Value = model.franchiser_order_amount_money;
            parameters[14].Value = model.canceled_reason;
            parameters[15].Value = model.ins_user;
            parameters[16].Value = model.ins_date;
            parameters[17].Value = model.upd_user;
            parameters[18].Value = model.upd_date;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int franchiser_order_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete franchiser_order ");
            strSql.Append(" where franchiser_order_id=@franchiser_order_id ");
            SqlParameter[] parameters = {
					new SqlParameter("@franchiser_order_id", SqlDbType.Int,4)};
            parameters[0].Value = franchiser_order_id;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public GoldTradeNaming.Model.franchiser_order GetModel(int franchiser_order_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 franchiser_order_id,franchiser_code,franchiser_order_trans_type,franchiser_order_address,franchiser_order_postcode,franchiser_order_handle_man,franchiser_order_handle_tel,franchiser_order_handle_phone,franchiser_order_price,franchiser_order_add_price,franchiser_order_appraise,franchiser_order_time,franchiser_order_state,franchiser_order_amount_money,canceled_reason,ins_user,ins_date,upd_user,upd_date from franchiser_order ");
            strSql.Append(" where franchiser_order_id=@franchiser_order_id ");
            SqlParameter[] parameters = {
					new SqlParameter("@franchiser_order_id", SqlDbType.Int,4)};
            parameters[0].Value = franchiser_order_id;

            GoldTradeNaming.Model.franchiser_order model = new GoldTradeNaming.Model.franchiser_order();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["franchiser_order_id"].ToString() != "")
                {
                    model.franchiser_order_id = int.Parse(ds.Tables[0].Rows[0]["franchiser_order_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["franchiser_code"].ToString() != "")
                {
                    model.franchiser_code = int.Parse(ds.Tables[0].Rows[0]["franchiser_code"].ToString());
                }
                model.franchiser_order_trans_type = ds.Tables[0].Rows[0]["franchiser_order_trans_type"].ToString();
                model.franchiser_order_address = ds.Tables[0].Rows[0]["franchiser_order_address"].ToString();
                model.franchiser_order_postcode = ds.Tables[0].Rows[0]["franchiser_order_postcode"].ToString();
                model.franchiser_order_handle_man = ds.Tables[0].Rows[0]["franchiser_order_handle_man"].ToString();
                model.franchiser_order_handle_tel = ds.Tables[0].Rows[0]["franchiser_order_handle_tel"].ToString();
                model.franchiser_order_handle_phone = ds.Tables[0].Rows[0]["franchiser_order_handle_phone"].ToString();
                if (ds.Tables[0].Rows[0]["franchiser_order_price"].ToString() != "")
                {
                    model.franchiser_order_price = decimal.Parse(ds.Tables[0].Rows[0]["franchiser_order_price"].ToString());
                }
                if (ds.Tables[0].Rows[0]["franchiser_order_add_price"].ToString() != "")
                {
                    model.franchiser_order_add_price = decimal.Parse(ds.Tables[0].Rows[0]["franchiser_order_add_price"].ToString());
                }
                if (ds.Tables[0].Rows[0]["franchiser_order_appraise"].ToString() != "")
                {
                    model.franchiser_order_appraise = decimal.Parse(ds.Tables[0].Rows[0]["franchiser_order_appraise"].ToString());
                }
                if (ds.Tables[0].Rows[0]["franchiser_order_time"].ToString() != "")
                {
                    model.franchiser_order_time = DateTime.Parse(ds.Tables[0].Rows[0]["franchiser_order_time"].ToString());
                }
                model.franchiser_order_state = ds.Tables[0].Rows[0]["franchiser_order_state"].ToString();
                if (ds.Tables[0].Rows[0]["franchiser_order_amount_money"].ToString() != "")
                {
                    model.franchiser_order_amount_money = decimal.Parse(ds.Tables[0].Rows[0]["franchiser_order_amount_money"].ToString());
                }
                model.canceled_reason = ds.Tables[0].Rows[0]["canceled_reason"].ToString();
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
            strSql.Append(@"select franchiser_order_id,franchiser_code,franchiser_order_trans_type,
franchiser_order_address,franchiser_order_postcode,franchiser_order_handle_man,
franchiser_order_handle_tel,franchiser_order_handle_phone,franchiser_order_price,
franchiser_order_time,franchiser_order_state,franchiser_order_amount_money,
canceled_reason,ins_user,ins_date,upd_user,upd_date ");
            strSql.Append(" FROM franchiser_order ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        public DataSet GetLatestList(int franID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select top 50 franchiser_order_id,franchiser_code,
                                        franchiser_order_trans_type,franchiser_order_address,
                                        franchiser_order_postcode,franchiser_order_handle_man,
                                        franchiser_order_handle_tel,franchiser_order_handle_phone,
                                        franchiser_order_price,
                                        franchiser_order_time,
                                        franchiser_order_state,franchiser_order_amount_money,
                                        canceled_reason,ins_user,ins_date,upd_user,upd_date 
                                        FROM franchiser_order where franchiser_code=@franchiser_code order by franchiser_order_id desc ");
            SqlParameter[] parameters = {
					new SqlParameter("@franchiser_code", SqlDbType.Int,4)
                                        };
            parameters[0].Value = franID;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
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
            parameters[0].Value = "franchiser_order";
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

