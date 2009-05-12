using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//请先添加引用
namespace GoldTradeNaming.DAL
{
	/// <summary>
	/// 数据访问类franchiser_order_desc。
	/// </summary>
	public class franchiser_order_desc
	{
		public franchiser_order_desc()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "franchiser_order_desc"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from franchiser_order_desc");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(GoldTradeNaming.Model.franchiser_order_desc model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into franchiser_order_desc(");
			strSql.Append("franchiser_order_id,product_id,product_spec_id,order_product_amount,product_received,product_unreceived,ins_user,ins_date,upd_user,upd_date)");
			strSql.Append(" values (");
			strSql.Append("@franchiser_order_id,@product_id,@product_spec_id,@order_product_amount,@product_received,@product_unreceived,@ins_user,@ins_date,@upd_user,@upd_date)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@franchiser_order_id", SqlDbType.Int,4),
					new SqlParameter("@product_id", SqlDbType.Int,4),
					new SqlParameter("@product_spec_id", SqlDbType.Int,4),
					new SqlParameter("@order_product_amount", SqlDbType.Int,4),
					new SqlParameter("@product_received", SqlDbType.Int,4),
					new SqlParameter("@product_unreceived", SqlDbType.Int,4),
					new SqlParameter("@ins_user", SqlDbType.NVarChar,50),
					new SqlParameter("@ins_date", SqlDbType.SmallDateTime),
					new SqlParameter("@upd_user", SqlDbType.NVarChar,50),
					new SqlParameter("@upd_date", SqlDbType.SmallDateTime)};
			parameters[0].Value = model.franchiser_order_id;
			parameters[1].Value = model.product_id;
			parameters[2].Value = model.product_spec_id;
			parameters[3].Value = model.order_product_amount;
			parameters[4].Value = model.product_received;
			parameters[5].Value = model.product_unreceived;
			parameters[6].Value = model.ins_user;
			parameters[7].Value = model.ins_date;
			parameters[8].Value = model.upd_user;
			parameters[9].Value = model.upd_date;

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
		public void Update(GoldTradeNaming.Model.franchiser_order_desc model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update franchiser_order_desc set ");
			strSql.Append("franchiser_order_id=@franchiser_order_id,");
			strSql.Append("product_id=@product_id,");
			strSql.Append("product_spec_id=@product_spec_id,");
			strSql.Append("order_product_amount=@order_product_amount,");
			strSql.Append("product_received=@product_received,");
			strSql.Append("product_unreceived=@product_unreceived,");
			strSql.Append("ins_user=@ins_user,");
			strSql.Append("ins_date=@ins_date,");
			strSql.Append("upd_user=@upd_user,");
			strSql.Append("upd_date=@upd_date");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@franchiser_order_id", SqlDbType.Int,4),
					new SqlParameter("@product_id", SqlDbType.Int,4),
					new SqlParameter("@product_spec_id", SqlDbType.Int,4),
					new SqlParameter("@order_product_amount", SqlDbType.Int,4),
					new SqlParameter("@product_received", SqlDbType.Int,4),
					new SqlParameter("@product_unreceived", SqlDbType.Int,4),
					new SqlParameter("@ins_user", SqlDbType.NVarChar,50),
					new SqlParameter("@ins_date", SqlDbType.SmallDateTime),
					new SqlParameter("@upd_user", SqlDbType.NVarChar,50),
					new SqlParameter("@upd_date", SqlDbType.SmallDateTime)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.franchiser_order_id;
			parameters[2].Value = model.product_id;
			parameters[3].Value = model.product_spec_id;
			parameters[4].Value = model.order_product_amount;
			parameters[5].Value = model.product_received;
			parameters[6].Value = model.product_unreceived;
			parameters[7].Value = model.ins_user;
			parameters[8].Value = model.ins_date;
			parameters[9].Value = model.upd_user;
			parameters[10].Value = model.upd_date;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete franchiser_order_desc ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public GoldTradeNaming.Model.franchiser_order_desc GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,franchiser_order_id,product_id,product_spec_id,order_product_amount,product_received,product_unreceived,ins_user,ins_date,upd_user,upd_date from franchiser_order_desc ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			GoldTradeNaming.Model.franchiser_order_desc model=new GoldTradeNaming.Model.franchiser_order_desc();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["franchiser_order_id"].ToString()!="")
				{
					model.franchiser_order_id=int.Parse(ds.Tables[0].Rows[0]["franchiser_order_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["product_id"].ToString()!="")
				{
					model.product_id=int.Parse(ds.Tables[0].Rows[0]["product_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["product_spec_id"].ToString()!="")
				{
					model.product_spec_id=int.Parse(ds.Tables[0].Rows[0]["product_spec_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["order_product_amount"].ToString()!="")
				{
					model.order_product_amount=int.Parse(ds.Tables[0].Rows[0]["order_product_amount"].ToString());
				}
				if(ds.Tables[0].Rows[0]["product_received"].ToString()!="")
				{
					model.product_received=int.Parse(ds.Tables[0].Rows[0]["product_received"].ToString());
				}
				if(ds.Tables[0].Rows[0]["product_unreceived"].ToString()!="")
				{
					model.product_unreceived=int.Parse(ds.Tables[0].Rows[0]["product_unreceived"].ToString());
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
			strSql.Append("select id,franchiser_order_id,product_id,product_spec_id,order_product_amount,product_received,product_unreceived,ins_user,ins_date,upd_user,upd_date ");
			strSql.Append(" FROM franchiser_order_desc ");
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
			parameters[0].Value = "franchiser_order_desc";
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

