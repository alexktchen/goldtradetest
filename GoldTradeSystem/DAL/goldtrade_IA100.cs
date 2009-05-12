using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//请先添加引用
namespace GoldTradeNaming.DAL
{
	/// <summary>
	/// 数据访问类goldtrade_IA100。
	/// </summary>
	public class goldtrade_IA100
	{
		public goldtrade_IA100()
		{}
		#region  成员方法

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(Guid IA100GUID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from goldtrade_IA100");
			strSql.Append(" where IA100GUID=@IA100GUID ");
			SqlParameter[] parameters = {
					new SqlParameter("@IA100GUID", SqlDbType.UniqueIdentifier)};
			parameters[0].Value = IA100GUID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsAndNotInUse(Guid IA100GUID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from goldtrade_IA100");
            strSql.Append(" where IA100GUID=@IA100GUID AND IA100State='0'");
            SqlParameter[] parameters = {
					new SqlParameter("@IA100GUID", SqlDbType.UniqueIdentifier)};
            parameters[0].Value = IA100GUID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(GoldTradeNaming.Model.goldtrade_IA100 model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into goldtrade_IA100(");
			strSql.Append("IA100GUID,IA100Key,IA100SuperPswd,IA100State,StateChangeReason)");
			strSql.Append(" values (");
			strSql.Append("@IA100GUID,@IA100Key,@IA100SuperPswd,@IA100State,@StateChangeReason)");
			SqlParameter[] parameters = {
					new SqlParameter("@IA100GUID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@IA100Key", SqlDbType.VarChar,32),
					new SqlParameter("@IA100SuperPswd", SqlDbType.VarChar,32),
					new SqlParameter("@IA100State", SqlDbType.VarChar,50),
					new SqlParameter("@StateChangeReason", SqlDbType.NVarChar,100)};
			parameters[0].Value = model.IA100GUID;
			parameters[1].Value = model.IA100Key;
			parameters[2].Value = model.IA100SuperPswd;
			parameters[3].Value = model.IA100State;
			parameters[4].Value = model.StateChangeReason;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(GoldTradeNaming.Model.goldtrade_IA100 model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update goldtrade_IA100 set ");
			strSql.Append("IA100Key=@IA100Key,");
			strSql.Append("IA100SuperPswd=@IA100SuperPswd,");
			strSql.Append("IA100State=@IA100State,");
			strSql.Append("StateChangeReason=@StateChangeReason");
			strSql.Append(" where IA100GUID=@IA100GUID ");
			SqlParameter[] parameters = {
					new SqlParameter("@IA100GUID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@IA100Key", SqlDbType.VarChar,32),
					new SqlParameter("@IA100SuperPswd", SqlDbType.VarChar,32),
					new SqlParameter("@IA100State", SqlDbType.VarChar,50),
					new SqlParameter("@StateChangeReason", SqlDbType.NVarChar,100)};
			parameters[0].Value = model.IA100GUID;
			parameters[1].Value = model.IA100Key;
			parameters[2].Value = model.IA100SuperPswd;
			parameters[3].Value = model.IA100State;
			parameters[4].Value = model.StateChangeReason;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(Guid IA100GUID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete goldtrade_IA100 ");
			strSql.Append(" where IA100GUID=@IA100GUID ");
			SqlParameter[] parameters = {
					new SqlParameter("@IA100GUID", SqlDbType.UniqueIdentifier)};
			parameters[0].Value = IA100GUID;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public GoldTradeNaming.Model.goldtrade_IA100 GetModel(Guid IA100GUID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 IA100GUID,IA100Key,IA100SuperPswd,IA100State,StateChangeReason from goldtrade_IA100 ");
			strSql.Append(" where IA100GUID=@IA100GUID ");
			SqlParameter[] parameters = {
					new SqlParameter("@IA100GUID", SqlDbType.UniqueIdentifier)};
			parameters[0].Value = IA100GUID;

			GoldTradeNaming.Model.goldtrade_IA100 model=new GoldTradeNaming.Model.goldtrade_IA100();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["IA100GUID"].ToString()!="")
				{
					model.IA100GUID=new Guid(ds.Tables[0].Rows[0]["IA100GUID"].ToString());
				}
				model.IA100Key=ds.Tables[0].Rows[0]["IA100Key"].ToString();
				model.IA100SuperPswd=ds.Tables[0].Rows[0]["IA100SuperPswd"].ToString();
				model.IA100State=ds.Tables[0].Rows[0]["IA100State"].ToString();
				model.StateChangeReason=ds.Tables[0].Rows[0]["StateChangeReason"].ToString();
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
			strSql.Append("select IA100GUID,IA100Key,IA100SuperPswd,IA100State,StateChangeReason ");
			strSql.Append(" FROM goldtrade_IA100 ");
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
			parameters[0].Value = "goldtrade_IA100";
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

