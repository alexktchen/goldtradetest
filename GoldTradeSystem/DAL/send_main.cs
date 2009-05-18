using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using Maticsoft.DBUtility;//请先添加引用
namespace GoldTradeNaming.DAL
{
	/// <summary>
	/// 数据访问类send_main。
	/// </summary>
	public class send_main
	{
        #region add by tianjie

        private static readonly object _sysn = new object();
        /// <summary>
        /// 得到订单信息
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetOrderInfo(string strWhere)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"
                        SELECT franchiser_order.franchiser_order_id AS orderID, franchiser_order.franchiser_code, 
                        franchiser_info.franchiser_name, 
                        franchiser_order.franchiser_order_price, 
                        franchiser_order.franchiser_order_handle_phone, 
                        franchiser_order.franchiser_order_handle_tel, 
                        franchiser_order.franchiser_order_handle_man, 
                        franchiser_order.franchiser_order_postcode, 
                        franchiser_order.franchiser_order_address, 
                        franchiser_order.franchiser_order_trans_type, 
                         franchiser_order.franchiser_order_time, 
                        franchiser_order.franchiser_order_state, 
                        franchiser_order.franchiser_order_amount_money, 
                        franchiser_order.canceled_reason
                        FROM franchiser_info INNER JOIN
                        franchiser_order ON 
                        franchiser_info.franchiser_code = franchiser_order.franchiser_code
                        WHERE (
                        (franchiser_order.franchiser_order_state = N'1'))");
            if (strWhere.Trim() != "")
            {
                sb.Append(strWhere);
            }
            return DbHelperSQL.Query(sb.ToString());
        }

        /// <summary>
        /// 获得订单详细数据列表
        /// </summary>
        public DataSet GetOrderedProductList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select id,franchiser_order_id,product_id,
                            product_type_name=(select top 1 product_type_name from product_type where product_type.product_type_id = franchiser_order_desc.product_id),
                            product_spec_weight=franchiser_order_desc.product_spec_id,
                            order_product_amount,
                            order_weight,
                            product_received,
                            received_num=convert(int,product_received/product_spec_id),
                            product_unreceived,
                            unreceived_num=convert(int,product_unreceived/product_spec_id),
                            ins_user,ins_date,upd_user,upd_date
                            FROM franchiser_order_desc
                         ");
            //strSql.Append(" FROM franchiser_order_desc ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 保存发货信息
        /// </summary>
        /// <param name="sm"></param>
        /// <param name="sdlst"></param>
        /// <returns></returns>
        public bool SaveSendInfo(GoldTradeNaming.Model.send_main sm, List<GoldTradeNaming.Model.send_desc> sdlst)
        {
            lock (_sysn)
            {
                using (SqlConnection conn = new SqlConnection(PubConstant.ConnectionString))
                {
                    conn.Open();
                    using (SqlTransaction trans = conn.BeginTransaction())
                    {
                        try
                        {
                            int result = 0;

                            SqlCommand cmd = new SqlCommand();

                            decimal OrderAmount = GetOrderAmount(sm.franchiser_order_id);
                            decimal SendAmount = GetSendAmount(sm.franchiser_order_id);
                            string newOrderState = SendAmount + sm.send_amount_weight == OrderAmount ? "2" : "1";

                            if (SendAmount + sm.send_amount_weight > OrderAmount) throw new Exception("重复发货！");
                            
                            //更改订单状态
                            StringBuilder updOrderStateSql = new StringBuilder();
                            updOrderStateSql.Append("update franchiser_order ");
                            updOrderStateSql.Append(" set franchiser_order_state = @new_order_state ");
                            updOrderStateSql.Append(" where franchiser_order_id = @franchiser_order_id");
                            SqlParameter[] parameters0 = {	
                            new SqlParameter("@new_order_state",SqlDbType.NVarChar,50),
		                    new SqlParameter("@franchiser_order_id", SqlDbType.Int,4)
                            };
                            parameters0[0].Value = newOrderState;
                            parameters0[1].Value = sm.franchiser_order_id;
                            cmd.CommandText = updOrderStateSql.ToString();
                            cmd.Transaction = trans;
                            cmd.Connection = conn;
                            cmd.Parameters.AddRange(parameters0);
                            result += cmd.ExecuteNonQuery();
                            
                            //保存发货主表信息
                            cmd = new SqlCommand();
                            int nextsendid = DbHelperSQL.GetMaxID("send_id", "send_main");
                            StringBuilder sb = new StringBuilder();
                            sb.Append("insert into send_main(");
                            sb.Append("franchiser_order_id,send_time,send_amount_weight,send_state,ins_user,upd_user,canceled_reason,send_id)");
                            sb.Append(" values (");
                            sb.Append("@franchiser_order_id,getdate(),@send_amount_weight,@send_state,@ins_user,@upd_user,@canceled_reason,@send_id)");
                            SqlParameter[] parameters = {	
                            new SqlParameter("@franchiser_order_id",SqlDbType.Int,4),
		                    new SqlParameter("@send_amount_weight", SqlDbType.Decimal,4),
		                    new SqlParameter("@send_state", SqlDbType.NVarChar,50),
		                    new SqlParameter("@ins_user", SqlDbType.NVarChar,50),					
		                    new SqlParameter("@upd_user", SqlDbType.NVarChar,50),					
		                    new SqlParameter("@canceled_reason", SqlDbType.NVarChar,100),
                            new SqlParameter("@send_id",SqlDbType.Int,4)
                            };
                            parameters[0].Value = sm.franchiser_order_id;
                            parameters[1].Value = sm.send_amount_weight;
                            parameters[2].Value = sm.send_state;
                            parameters[3].Value = sm.ins_user;
                            parameters[4].Value = sm.upd_user;
                            parameters[5].Value = sm.canceled_reason;
                            parameters[6].Value = nextsendid;
                            cmd.CommandText = sb.ToString();
                            cmd.Transaction = trans;
                            cmd.Connection = conn;
                            cmd.Parameters.AddRange(parameters);
                            result += cmd.ExecuteNonQuery();

                            //保存发货细表信息
                            foreach (GoldTradeNaming.Model.send_desc sd in sdlst)
                            {
                                //if()

                                StringBuilder sb1 = new StringBuilder();
                                sb1.Append("select product_unreceived from franchiser_order_desc  ");
                                sb1.Append(" where franchiser_order_id=@franchiser_order_id ");
                                sb1.Append(" and product_id=@product_id and product_spec_id=@product_spec_id");
                                SqlParameter[] parameters_sb1 = {					     
				                new SqlParameter("@franchiser_order_id", SqlDbType.Int,4),
				                new SqlParameter("@product_id", SqlDbType.Int,4),
				                new SqlParameter("@product_spec_id", SqlDbType.Decimal,4)
				               };
                                parameters_sb1[0].Value = sm.franchiser_order_id;
                                parameters_sb1[1].Value = sd.product_id;
                                parameters_sb1[2].Value = sd.product_spec_id;
                                cmd = new SqlCommand();
                                cmd.CommandText = sb1.ToString();
                                cmd.Transaction = trans;
                                cmd.Connection = conn;
                                cmd.Parameters.AddRange(parameters_sb1);
                                object o = cmd.ExecuteScalar();
                                decimal unreceive = Convert.ToDecimal(o);
                                if (unreceive < sd.send_amount_weight) throw new Exception("重复发货！");
                                
                                cmd = new SqlCommand();
                                StringBuilder strSql = new StringBuilder();
                                strSql.Append("insert into send_desc(");
                                strSql.Append("product_id,product_spec_id,send_amount_weight,ins_user,upd_user,send_id)");
                                strSql.Append(" values (");
                                strSql.Append("@product_id,@product_spec_id,@send_amount_weight,@ins_user,@upd_user,@send_id)");

                                SqlParameter[] parameters2 = {					               
				                new SqlParameter("@product_id", SqlDbType.Int,4),
				                new SqlParameter("@product_spec_id", SqlDbType.Decimal,4),
				                new SqlParameter("@send_amount_weight", SqlDbType.Decimal,4),
				                new SqlParameter("@ins_user", SqlDbType.NVarChar,50),
				                new SqlParameter("@upd_user", SqlDbType.NVarChar,50),
                                new SqlParameter("@send_id",SqlDbType.Int,4)
				               };
                                parameters2[0].Value = sd.product_id;
                                parameters2[1].Value = sd.product_spec_id;
                                parameters2[2].Value = sd.send_amount_weight;
                                parameters2[3].Value = sd.ins_user;
                                parameters2[4].Value = sd.upd_user;
                                parameters2[5].Value = nextsendid;
                                cmd.Parameters.AddRange(parameters2);
                                cmd.CommandText = strSql.ToString();
                                cmd.Transaction = trans;
                                cmd.Connection = conn;
                                result += cmd.ExecuteNonQuery();


                                //更改订单详细
                                cmd = new SqlCommand();
                                StringBuilder strSqlUpdOrderDesc = new StringBuilder();
                                strSqlUpdOrderDesc.Append("update franchiser_order_desc ");
                                strSqlUpdOrderDesc.Append(" set product_received = product_received + @this_receive,product_unreceived = product_unreceived -  @this_receive");
                                strSqlUpdOrderDesc.Append(" where franchiser_order_id=@franchiser_order_id ");
                                strSqlUpdOrderDesc.Append(" and product_id=@product_id and product_spec_id=@product_spec_id");

                                SqlParameter[] parameters3 = {					               
				                new SqlParameter("@this_receive", SqlDbType.Decimal,4),
				                new SqlParameter("@franchiser_order_id", SqlDbType.Int,4),
				                new SqlParameter("@product_id", SqlDbType.Int,4),
				                new SqlParameter("@product_spec_id", SqlDbType.Decimal,4)
				               };
                                parameters3[0].Value = sd.send_amount_weight;
                                parameters3[1].Value = sm.franchiser_order_id;
                                parameters3[2].Value = sd.product_id;
                                parameters3[3].Value = sd.product_spec_id;
                                cmd.CommandText = strSqlUpdOrderDesc.ToString();
                                cmd.Parameters.AddRange(parameters3);
                                cmd.Transaction = trans;
                                cmd.Connection = conn;
                                result += cmd.ExecuteNonQuery();
                            }
                            trans.Commit();
                            return true;
                        }
                        catch (Exception ex)
                        {
                            trans.Rollback();
                            throw ex;
                        }
                    }
                }
            }
        }
        
        /// <summary>
        /// 取消发货
        /// </summary>
        public int CancelSend(GoldTradeNaming.Model.send_main model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update send_main set ");
            strSql.Append("send_state=@send_state,");
            strSql.Append("upd_user=@upd_user,");
            strSql.Append("upd_date= getdate(),");
            strSql.Append("canceled_reason=@canceled_reason");
            strSql.Append(" where send_id=@send_id ");
            SqlParameter[] parameters = {
					new SqlParameter("@send_id", SqlDbType.Int,4),
					new SqlParameter("@send_state", SqlDbType.NVarChar,50),
					new SqlParameter("@upd_user", SqlDbType.NVarChar,50),
					new SqlParameter("@canceled_reason", SqlDbType.NVarChar,100)};
            parameters[0].Value = model.send_id;
            parameters[1].Value = model.send_state;
            parameters[2].Value = model.upd_user;
            parameters[3].Value = model.canceled_reason;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            
        }

        /// <summary>
        /// 确认收货
        /// </summary>
        /// <param name="franId"></param>
        /// <param name="OrderId"></param>
        /// <param name="SendId"></param>
        /// <returns></returns>
        public bool ConfirmReceive(int franId,int OrderId,int SendId)
        {
            #region SQL
            /*
             declare @franchiser_code int,@franchiser_order_id int,
	                @send_id int,@new_order_state varchar(1),
	                @product_id int,@product_spec_id int
            set @franchiser_code=1000
            set @franchiser_order_id=1
            set @send_id='17'
            set @new_order_state='3'
            set @product_id='1'
            set @product_spec_id='50'

            ------查询订单总额----------------------------------------------------------------------------------------------------
            select franchiser_order_amount_money from franchiser_order where franchiser_order_id = @franchiser_order_id

            ------查询发货总量-------------------------------------------------------------------------------------------------------
            select sum(send_amount_weight) from send_main where (send_state ='0' or send_state='1') 
            and franchiser_order_id=@franchiser_order_id 

            ----更改订单状态--------------------------------------------------------------------------------
            update franchiser_order set franchiser_order_state = @new_order_state where franchiser_order_id = @franchiser_order_id
            select franchiser_order_state from franchiser_order where franchiser_order_id=@franchiser_order_id

            ----更改发货状态---------------------------------------------------------------------
            update send_main set send_state='1' where send_id = @send_id
            select send_state from send_main where send_id = @send_id

            ------查询发货详细信息----------------------------------------------------------------------------------------------------------------
            select send_id, product_id,product_spec_id,send_amount_weight from send_desc where send_id=@send_id

            -----更改订单详细--------------------------------------------------------------------------------
            select * from franchiser_order_desc where franchiser_order_id=@franchiser_order_id 
            and product_id=@product_id and product_spec_id=@product_spec_id

            update franchiser_order_desc set product_received = product_received + 10,
	            product_unreceived = product_unreceived - 10 
            where franchiser_order_id=@franchiser_order_id 
            and product_id=@product_id and product_spec_id=@product_spec_id

            select * from franchiser_order_desc where franchiser_order_id=@franchiser_order_id 
            and product_id=@product_id and product_spec_id=@product_spec_id
            ---------------------------------------------------------------------------------------------
            -----更改库存信息-----------------------------------------------------------------------------------------
                           declare @franchiser_code int,@franchiser_order_id int,
	                @send_id int,@new_order_state varchar(1),
	                @product_id int,@product_spec_id int,@this_send int,@insuser varchar(50)
                set @franchiser_code=1000
                set @franchiser_order_id=1
                set @send_id=17
                set @new_order_state='3'
                set @product_id=1
                set @product_spec_id=50
                set @this_send = 10
                set @insuser='admin'
                select * from stock_main where franchiser_code = @franchiser_code 
                and product_id=@product_id and product_spec_id=@product_spec_id

                if not exists (select * from stock_main where franchiser_code = @franchiser_code 
		                and product_id=@product_id and product_spec_id=@product_spec_id)
                begin
                insert into stock_main (franchiser_code,product_id,product_spec_id,stock_total,stock_left,ins_user,upd_user)
                values (@franchiser_code,@product_id,@product_spec_id,@this_send,@this_send,@insuser,@insuser)
                --select * from stock_main where franchiser_code = @franchiser_code 
                --and product_id=@product_id and product_spec_id=@product_spec_id

                end
                else
                begin
                select * from stock_main where franchiser_code = @franchiser_code 
                and product_id=@product_id and product_spec_id=@product_spec_id

                update stock_main set stock_total = stock_total + 10,stock_left = stock_left+10
                where franchiser_code = @franchiser_code and product_id=@product_id and product_spec_id=@product_spec_id

                select * from stock_main where franchiser_code = @franchiser_code 
                and product_id=@product_id and product_spec_id=@product_spec_id
                end
             */

            /*int franId,int OrderId,int SendId
              set @franchiser_code=1000
            set @franchiser_order_id=1
            set @send_id='17'
            set @new_order_state='3'
            set @product_id='1'
            set @product_spec_id='50'
             *             */
            #endregion

            lock (_sysn)
            {
                //decimal OrderAmount = GetOrderAmount(OrderId);
                //decimal SendAmount = GetSendAmount(OrderId);
                DataTable tblSendDesc = GetSendDesc(SendId);
                //string newOrderState = SendAmount >= OrderAmount ? "2" : "1";

                using (SqlConnection conn = new SqlConnection(PubConstant.ConnectionString))
                {
                    conn.Open();
                    using (SqlTransaction trans = conn.BeginTransaction())
                    {
                        int result = 0;
                        SqlCommand cmd = new SqlCommand();
                        try
                        {
                            ////更改订单状态
                            // StringBuilder updOrderStateSql = new StringBuilder();
                            // updOrderStateSql.Append("update franchiser_order ");
                            // updOrderStateSql.Append(" set franchiser_order_state = @new_order_state ");
                            // updOrderStateSql.Append(" where franchiser_order_id = @franchiser_order_id");
                            // SqlParameter[] parameters = {	
                            //    new SqlParameter("@new_order_state",SqlDbType.NVarChar,50),
                            //    new SqlParameter("@franchiser_order_id", SqlDbType.Int,4)
                            //    };
                            // parameters[0].Value = newOrderState;
                            // parameters[1].Value = OrderId;
                            // cmd.CommandText = updOrderStateSql.ToString();
                            //cmd.Transaction = trans;
                            //cmd.Connection = conn;
                            //cmd.Parameters.AddRange(parameters);
                            //result += cmd.ExecuteNonQuery();

                            //更改发货状态
                            StringBuilder updSendStateSql = new StringBuilder();
                            updSendStateSql.Append("update send_main ");
                            updSendStateSql.Append(" set send_state='1' ");
                            updSendStateSql.Append(" where send_id = @send_id");
                            SqlParameter[] parameters2 = {	
		                    new SqlParameter("@send_id", SqlDbType.Int,4)
                            };
                            parameters2[0].Value = SendId;
                            cmd = new SqlCommand();
                            cmd.CommandText = updSendStateSql.ToString();
                            cmd.Transaction = trans;
                            cmd.Connection = conn;
                            cmd.Parameters.AddRange(parameters2);
                            result += cmd.ExecuteNonQuery();

                            foreach (DataRow dr in tblSendDesc.Rows)
                            {
                                //更改库存信息
                                cmd = new SqlCommand();
                                StringBuilder strSqlUpdStock = new StringBuilder();
                                strSqlUpdStock.Append(@"if not exists (select * from stock_main where franchiser_code = @franchiser_code 
		                                            and product_id=@product_id and product_spec_id=@product_spec_id)");
                                strSqlUpdStock.Append(" begin ");
                                strSqlUpdStock.Append(@"insert into stock_main (franchiser_code,product_id,product_spec_id,stock_total,stock_left,ins_user,upd_user)
                                                    values (@franchiser_code,@product_id,@product_spec_id,@this_send,@this_send,@insuser,@insuser)");
                                strSqlUpdStock.Append(" end ");
                                strSqlUpdStock.Append(" else begin ");
                                strSqlUpdStock.Append(@" update stock_main set stock_total = stock_total + @this_send,stock_left = stock_left+@this_send
                                                    where franchiser_code = @franchiser_code and product_id=@product_id and product_spec_id=@product_spec_id ");
                                strSqlUpdStock.Append(" end ");


                                SqlParameter[] parameters4 = {					               
				                new SqlParameter("@product_id", SqlDbType.Int,4),
				                new SqlParameter("@product_spec_id", SqlDbType.Decimal,4),
				                new SqlParameter("@franchiser_code", SqlDbType.Int,4),
				                new SqlParameter("@this_send", SqlDbType.Decimal,4),
                                new SqlParameter("@insuser",SqlDbType.NVarChar,50)
				               };
                                parameters4[0].Value = Convert.ToInt32(dr[1]);
                                parameters4[1].Value = Convert.ToDecimal(dr[2]);
                                parameters4[2].Value = franId;
                                parameters4[3].Value = Convert.ToDecimal(dr[3].ToString());
                                parameters4[4].Value = franId;
                                cmd.CommandText = strSqlUpdStock.ToString();
                                cmd.Parameters.AddRange(parameters4);
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
        }


        /// <summary>
        /// 获得订单订货总重量
        /// </summary>
        /// <param name="orderid">订单号</param>
        /// <returns></returns>
        public decimal GetOrderAmount(int orderid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SUM(order_product_amount*product_spec_id)");
            strSql.Append(" from franchiser_order_desc ");

            strSql.Append(" where franchiser_order_id = '" + orderid.ToString() + "'");
            
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            decimal rtn = int.MinValue;
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                rtn = ds.Tables[0].Rows[0][0].ToString()==""?0.00M:Convert.ToDecimal(ds.Tables[0].Rows[0][0].ToString());
            }
            return rtn;
        }

        /// <summary>
        /// 取得某一订单下的发货总量
        /// </summary>
        /// <param name="orderid">订单号</param>
        /// <returns></returns>
        public decimal GetSendAmount(int orderid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select sum(send_amount_weight) from send_main where (send_state ='0' or send_state='1') and franchiser_order_id='");           
            strSql.Append(orderid.ToString() + "'");

            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            decimal rtn = decimal.MinValue;
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                rtn = ds.Tables[0].Rows[0][0].ToString()==""?0.00M:Convert.ToDecimal(ds.Tables[0].Rows[0][0].ToString());
            }
            return rtn;
        }

        /// <summary>
        /// 查询发货详细信息,确认收货用
        /// </summary>
        /// <param name="sendid">发货单号</param>
        /// <returns></returns>
        public DataTable GetSendDesc(int sendid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select send_id, product_id,product_spec_id,send_amount_weight from send_desc where send_id='");
            strSql.Append(sendid.ToString() + "'");

            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            DataTable rtn = null;
            if (ds.Tables.Count > 0 )
            {
                rtn = ds.Tables[0];
            }
            return rtn;
        }


        /// <summary>
        /// 获得收货主表信息
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetSendInfo(string strWhere)
        {
            string strSql = @"SELECT send_main.send_id, send_main.franchiser_order_id,


franchiser_name=(select franchiser_info.franchiser_name from franchiser_info 
     			where franchiser_info.franchiser_code = 
			( select franchiser_order.franchiser_code 
			from franchiser_order where franchiser_order.franchiser_order_id=send_main.franchiser_order_id)),
send_main.send_time, 
state=( case send_main.send_state when '0' then '未收货' 
	 when '1' then '已收货' end),

   send_main.send_amount_weight, franchiser_info.franchiser_code
                            FROM franchiser_info INNER JOIN
                                  franchiser_order ON 
                                  franchiser_info.franchiser_code = franchiser_order.franchiser_code INNER JOIN
                                  send_main ON 
                                  franchiser_order.franchiser_order_id = send_main.franchiser_order_id
                            ";

            if (!string.IsNullOrEmpty(strWhere))
                strSql += " Where " + strWhere;
            string strSort = "order by send_id desc";
            return DbHelperSQL.Query(strSql.ToString()  + strSort);
        }


        #endregion
                		
        public send_main()
		{}
		
        #region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("send_id", "send_main"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int send_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from send_main");
			strSql.Append(" where send_id=@send_id ");
			SqlParameter[] parameters = {
					new SqlParameter("@send_id", SqlDbType.Int,4)};
			parameters[0].Value = send_id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(GoldTradeNaming.Model.send_main model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into send_main(");
			strSql.Append("franchiser_order_id,send_time,send_amount_weight,send_state,ins_user,ins_date,upd_user,upd_date,canceled_reason)");
			strSql.Append(" values (");
			strSql.Append("@franchiser_order_id,@send_time,@send_amount_weight,@send_state,@ins_user,@ins_date,@upd_user,@upd_date,@canceled_reason)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@franchiser_order_id", SqlDbType.Int,4),
					new SqlParameter("@send_time", SqlDbType.SmallDateTime),
					new SqlParameter("@send_amount_weight", SqlDbType.Int,4),
					new SqlParameter("@send_state", SqlDbType.NVarChar,50),
					new SqlParameter("@ins_user", SqlDbType.NVarChar,50),
					new SqlParameter("@ins_date", SqlDbType.SmallDateTime),
					new SqlParameter("@upd_user", SqlDbType.NVarChar,50),
					new SqlParameter("@upd_date", SqlDbType.SmallDateTime),
					new SqlParameter("@canceled_reason", SqlDbType.NVarChar,100)};
			parameters[0].Value = model.franchiser_order_id;
			parameters[1].Value = model.send_time;
			parameters[2].Value = model.send_amount_weight;
			parameters[3].Value = model.send_state;
			parameters[4].Value = model.ins_user;
			parameters[5].Value = model.ins_date;
			parameters[6].Value = model.upd_user;
			parameters[7].Value = model.upd_date;
			parameters[8].Value = model.canceled_reason;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
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
		public void Update(GoldTradeNaming.Model.send_main model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update send_main set ");
			strSql.Append("franchiser_order_id=@franchiser_order_id,");
			strSql.Append("send_time=@send_time,");
			strSql.Append("send_amount_weight=@send_amount_weight,");
			strSql.Append("send_state=@send_state,");
			strSql.Append("ins_user=@ins_user,");
			strSql.Append("ins_date=@ins_date,");
			strSql.Append("upd_user=@upd_user,");
			strSql.Append("upd_date=@upd_date,");
			strSql.Append("canceled_reason=@canceled_reason");
			strSql.Append(" where send_id=@send_id ");
			SqlParameter[] parameters = {
					new SqlParameter("@send_id", SqlDbType.Int,4),
					new SqlParameter("@franchiser_order_id", SqlDbType.Int,4),
					new SqlParameter("@send_time", SqlDbType.SmallDateTime),
					new SqlParameter("@send_amount_weight", SqlDbType.Int,4),
					new SqlParameter("@send_state", SqlDbType.NVarChar,50),
					new SqlParameter("@ins_user", SqlDbType.NVarChar,50),
					new SqlParameter("@ins_date", SqlDbType.SmallDateTime),
					new SqlParameter("@upd_user", SqlDbType.NVarChar,50),
					new SqlParameter("@upd_date", SqlDbType.SmallDateTime),
					new SqlParameter("@canceled_reason", SqlDbType.NVarChar,100)};
			parameters[0].Value = model.send_id;
			parameters[1].Value = model.franchiser_order_id;
			parameters[2].Value = model.send_time;
			parameters[3].Value = model.send_amount_weight;
			parameters[4].Value = model.send_state;
			parameters[5].Value = model.ins_user;
			parameters[6].Value = model.ins_date;
			parameters[7].Value = model.upd_user;
			parameters[8].Value = model.upd_date;
			parameters[9].Value = model.canceled_reason;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int send_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete send_main ");
			strSql.Append(" where send_id=@send_id ");
			SqlParameter[] parameters = {
					new SqlParameter("@send_id", SqlDbType.Int,4)};
			parameters[0].Value = send_id;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public GoldTradeNaming.Model.send_main GetModel(int send_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 send_id,franchiser_order_id,send_time,send_amount_weight,send_state,ins_user,ins_date,upd_user,upd_date,canceled_reason from send_main ");
			strSql.Append(" where send_id=@send_id ");
			SqlParameter[] parameters = {
					new SqlParameter("@send_id", SqlDbType.Int,4)};
			parameters[0].Value = send_id;

			GoldTradeNaming.Model.send_main model=new GoldTradeNaming.Model.send_main();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["send_id"].ToString()!="")
				{
					model.send_id=int.Parse(ds.Tables[0].Rows[0]["send_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["franchiser_order_id"].ToString()!="")
				{
					model.franchiser_order_id=int.Parse(ds.Tables[0].Rows[0]["franchiser_order_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["send_time"].ToString()!="")
				{
					model.send_time=DateTime.Parse(ds.Tables[0].Rows[0]["send_time"].ToString());
				}
				if(ds.Tables[0].Rows[0]["send_amount_weight"].ToString()!="")
				{
					model.send_amount_weight=int.Parse(ds.Tables[0].Rows[0]["send_amount_weight"].ToString());
				}
				model.send_state=ds.Tables[0].Rows[0]["send_state"].ToString();
				model.ins_user=ds.Tables[0].Rows[0]["ins_user"].ToString();
				if(ds.Tables[0].Rows[0]["ins_date"].ToString()!="")
				{
					model.ins_date=DateTime.Parse(ds.Tables[0].Rows[0]["ins_date"].ToString());
				}
				model.upd_user=ds.Tables[0].Rows[0]["upd_user"].ToString();
				if(ds.Tables[0].Rows[0]["upd_date"].ToString()!="")
				{
					model.upd_date=DateTime.Parse(ds.Tables[0].Rows[0]["upd_date"].ToString());
				}
				model.canceled_reason=ds.Tables[0].Rows[0]["canceled_reason"].ToString();
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select send_id,franchiser_order_id,send_time,send_amount_weight,send_state,ins_user,ins_date,upd_user,upd_date,canceled_reason ");
			strSql.Append(" FROM send_main ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

        /// <summary>
        /// 获得收货主表信息（未确认）
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetListByFranID(string strWhere)
        {
            string strSql = @"SELECT send_main.send_id, send_main.franchiser_order_id, send_main.send_time, 
                                  send_main.send_amount_weight, franchiser_info.franchiser_code
                            FROM franchiser_info INNER JOIN
                                  franchiser_order ON 
                                  franchiser_info.franchiser_code = franchiser_order.franchiser_code INNER JOIN
                                  send_main ON 
                                  franchiser_order.franchiser_order_id = send_main.franchiser_order_id
                            WHERE (send_main.send_state = '0') ";
            return DbHelperSQL.Query(strSql.ToString()+strWhere);
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
			parameters[0].Value = "send_main";
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

