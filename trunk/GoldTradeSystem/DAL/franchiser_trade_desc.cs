using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//�����������
namespace GoldTradeNaming.DAL
{
	/// <summary>
	/// ���ݷ�����franchiser_trade_desc��
	/// </summary>
	public class franchiser_trade_desc
	{
		public franchiser_trade_desc()
		{}
		#region  ��Ա����

		/// <summary>
		/// �õ����ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "franchiser_trade_desc"); 
		}

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from franchiser_trade_desc");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// ����һ������
		/// </summary>
		public int Add(GoldTradeNaming.Model.franchiser_trade_desc model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into franchiser_trade_desc(");
			strSql.Append("trade_id,product_id,product_spec_id,trade_weight,ins_user,ins_date,upd_user,upd_date)");
			strSql.Append(" values (");
			strSql.Append("@trade_id,@product_id,@product_spec_id,@trade_weight,@ins_user,@ins_date,@upd_user,@upd_date)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@trade_id", SqlDbType.Int,4),
					new SqlParameter("@product_id", SqlDbType.Int,4),
					new SqlParameter("@product_spec_id", SqlDbType.Int,4),
					new SqlParameter("@trade_weight", SqlDbType.Int,4),
					new SqlParameter("@ins_user", SqlDbType.NVarChar,50),
					new SqlParameter("@ins_date", SqlDbType.SmallDateTime),
					new SqlParameter("@upd_user", SqlDbType.NVarChar,50),
					new SqlParameter("@upd_date", SqlDbType.SmallDateTime)};
			parameters[0].Value = model.trade_id;
			parameters[1].Value = model.product_id;
			parameters[2].Value = model.product_spec_id;
			parameters[3].Value = model.trade_weight;
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
		/// ����һ������
		/// </summary>
		public void Update(GoldTradeNaming.Model.franchiser_trade_desc model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update franchiser_trade_desc set ");
			strSql.Append("trade_id=@trade_id,");
			strSql.Append("product_id=@product_id,");
			strSql.Append("product_spec_id=@product_spec_id,");
			strSql.Append("trade_weight=@trade_weight,");
			strSql.Append("ins_user=@ins_user,");
			strSql.Append("ins_date=@ins_date,");
			strSql.Append("upd_user=@upd_user,");
			strSql.Append("upd_date=@upd_date");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@trade_id", SqlDbType.Int,4),
					new SqlParameter("@product_id", SqlDbType.Int,4),
					new SqlParameter("@product_spec_id", SqlDbType.Int,4),
					new SqlParameter("@trade_weight", SqlDbType.Int,4),
					new SqlParameter("@ins_user", SqlDbType.NVarChar,50),
					new SqlParameter("@ins_date", SqlDbType.SmallDateTime),
					new SqlParameter("@upd_user", SqlDbType.NVarChar,50),
					new SqlParameter("@upd_date", SqlDbType.SmallDateTime)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.trade_id;
			parameters[2].Value = model.product_id;
			parameters[3].Value = model.product_spec_id;
			parameters[4].Value = model.trade_weight;
			parameters[5].Value = model.ins_user;
			parameters[6].Value = model.ins_date;
			parameters[7].Value = model.upd_user;
			parameters[8].Value = model.upd_date;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete franchiser_trade_desc ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public GoldTradeNaming.Model.franchiser_trade_desc GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,trade_id,product_id,product_spec_id,trade_weight,ins_user,ins_date,upd_user,upd_date from franchiser_trade_desc ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			GoldTradeNaming.Model.franchiser_trade_desc model=new GoldTradeNaming.Model.franchiser_trade_desc();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["trade_id"].ToString()!="")
				{
					model.trade_id=int.Parse(ds.Tables[0].Rows[0]["trade_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["product_id"].ToString()!="")
				{
					model.product_id=int.Parse(ds.Tables[0].Rows[0]["product_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["product_spec_id"].ToString()!="")
				{
					model.product_spec_id=int.Parse(ds.Tables[0].Rows[0]["product_spec_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["trade_weight"].ToString()!="")
				{
					model.trade_weight=int.Parse(ds.Tables[0].Rows[0]["trade_weight"].ToString());
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
		/// ��������б�
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,trade_id,product_id,product_spec_id,trade_weight,ins_user,ins_date,upd_user,upd_date ");
			strSql.Append(" FROM franchiser_trade_desc ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// ��ҳ��ȡ�����б�
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
			parameters[0].Value = "franchiser_trade_desc";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  ��Ա����
	}
}

