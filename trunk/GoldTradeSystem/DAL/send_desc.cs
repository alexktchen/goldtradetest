using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//请先添加引用
namespace GoldTradeNaming.DAL
{
	/// <summary>
	/// 数据访问类send_desc。
	/// </summary>
	public class send_desc
    {
        #region add by 田杰

        /// <summary>
        /// 取得产品列表，typeID与SpecID关系表
        /// </summary>
        /// <returns></returns>
        public DataSet GetProdcut()
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("SELECT distinct (product_type_id) ,product_type_name FROM product_type where product_state='0';");

                strSql.Append("SELECT * FROM product_type where product_state='0'");

                DataSet ds = DbHelperSQL.Query(strSql.ToString());

                ds.Relations.Add("ProductId_SpecID", ds.Tables[0].Columns["product_type_id"], ds.Tables[1].Columns["product_type_id"]);
                return ds;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region getSendDesc
        /// <summary>
        /// 根据send_id获得详细列表
        /// writer:alex
        /// date:20090421
        /// </summary>
        /// <param name="send_id"></param>
        /// <returns></returns>
        public DataSet getSendDesc(string send_id)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select product_name=");
                strSql.Append("(select top 1 product_type_name from product_type where send_desc.product_id=product_type.product_type_id),");
                strSql.Append("send_desc.product_spec_id,send_amount = convert(int,send_amount_weight/product_spec_id),ins_date");
                strSql.Append(" from send_desc");
                strSql.Append(" where send_id=@send_id");
                SqlParameter[] parameters = {new SqlParameter("@send_id",SqlDbType.NChar,50) };
                parameters[0].Value = send_id;
                DataSet ds = DbHelperSQL.Query(strSql.ToString(),parameters);
                return ds;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        /// <summary>
        /// 获取经销商名称
        /// </summary>
        /// <param name="fran_id"></param>
        /// <returns></returns>
        public string getFranName(string fran_id)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                string returnValue = string.Empty;
                strSql.Append("select top 1 franchiser_name from franchiser_info");
                strSql.Append(" where franchiser_code=@fran_id");
                SqlParameter[] parameters = { new SqlParameter("@fran_id", SqlDbType.NChar, 10) };
                parameters[0].Value = fran_id;
                DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["franchiser_name"].ToString() != "")
                    {
                        returnValue = ds.Tables[0].Rows[0]["franchiser_name"].ToString();
                    }
                }
                return returnValue;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 获取发货总量
        /// </summary>
        /// <param name="send_id"></param>
        /// <returns></returns>
        public string getSendAmountWeight(string send_id)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                string returnValue = string.Empty;
                strSql.Append("select top 1 send_amount_weight from send_main");
                strSql.Append(" where send_id=@send_id");
                SqlParameter[] parameters = { new SqlParameter("@send_id", SqlDbType.NChar, 10) };
                parameters[0].Value = send_id;
                DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["send_amount_weight"].ToString() != "")
                    {
                        returnValue = ds.Tables[0].Rows[0]["send_amount_weight"].ToString();
                    }
                }
                return returnValue;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public send_desc()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "send_desc"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from send_desc");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(GoldTradeNaming.Model.send_desc model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into send_desc(");
			strSql.Append("send_id,product_id,product_spec_id,send_amount_weight,ins_user,ins_date,upd_user,upd_date)");
			strSql.Append(" values (");
			strSql.Append("@send_id,@product_id,@product_spec_id,@send_amount_weight,@ins_user,@ins_date,@upd_user,@upd_date)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@send_id", SqlDbType.Int,4),
					new SqlParameter("@product_id", SqlDbType.Int,4),
					new SqlParameter("@product_spec_id", SqlDbType.Int,4),
					new SqlParameter("@send_amount_weight", SqlDbType.Int,4),
					new SqlParameter("@ins_user", SqlDbType.NVarChar,50),
					new SqlParameter("@ins_date", SqlDbType.SmallDateTime),
					new SqlParameter("@upd_user", SqlDbType.NVarChar,50),
					new SqlParameter("@upd_date", SqlDbType.SmallDateTime)};
			parameters[0].Value = model.send_id;
			parameters[1].Value = model.product_id;
			parameters[2].Value = model.product_spec_id;
			parameters[3].Value = model.send_amount_weight;
			parameters[4].Value = model.ins_user;
			parameters[5].Value = model.ins_date;
			parameters[6].Value = model.upd_user;
			parameters[7].Value = model.upd_date;

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
		public void Update(GoldTradeNaming.Model.send_desc model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update send_desc set ");
			strSql.Append("send_id=@send_id,");
			strSql.Append("product_id=@product_id,");
			strSql.Append("product_spec_id=@product_spec_id,");
			strSql.Append("send_amount_weight=@send_amount_weight,");
			strSql.Append("ins_user=@ins_user,");
			strSql.Append("ins_date=@ins_date,");
			strSql.Append("upd_user=@upd_user,");
			strSql.Append("upd_date=@upd_date");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@send_id", SqlDbType.Int,4),
					new SqlParameter("@product_id", SqlDbType.Int,4),
					new SqlParameter("@product_spec_id", SqlDbType.Int,4),
					new SqlParameter("@send_amount_weight", SqlDbType.Int,4),
					new SqlParameter("@ins_user", SqlDbType.NVarChar,50),
					new SqlParameter("@ins_date", SqlDbType.SmallDateTime),
					new SqlParameter("@upd_user", SqlDbType.NVarChar,50),
					new SqlParameter("@upd_date", SqlDbType.SmallDateTime)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.send_id;
			parameters[2].Value = model.product_id;
			parameters[3].Value = model.product_spec_id;
			parameters[4].Value = model.send_amount_weight;
			parameters[5].Value = model.ins_user;
			parameters[6].Value = model.ins_date;
			parameters[7].Value = model.upd_user;
			parameters[8].Value = model.upd_date;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete send_desc ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public GoldTradeNaming.Model.send_desc GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,send_id,product_id,product_spec_id,send_amount_weight,ins_user,ins_date,upd_user,upd_date from send_desc ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			GoldTradeNaming.Model.send_desc model=new GoldTradeNaming.Model.send_desc();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["send_id"].ToString()!="")
				{
					model.send_id=int.Parse(ds.Tables[0].Rows[0]["send_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["product_id"].ToString()!="")
				{
					model.product_id=int.Parse(ds.Tables[0].Rows[0]["product_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["product_spec_id"].ToString()!="")
				{
					model.product_spec_id=int.Parse(ds.Tables[0].Rows[0]["product_spec_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["send_amount_weight"].ToString()!="")
				{
					model.send_amount_weight=int.Parse(ds.Tables[0].Rows[0]["send_amount_weight"].ToString());
				}
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
			strSql.Append("select id,send_id,product_id,product_spec_id,send_amount_weight,ins_user,ins_date,upd_user,upd_date ");
			strSql.Append(" FROM send_desc ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
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
			parameters[0].Value = "send_desc";
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

