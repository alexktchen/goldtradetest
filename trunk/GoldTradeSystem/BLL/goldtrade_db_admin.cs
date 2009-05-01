using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using GoldTradeNaming.Model;
namespace GoldTradeNaming.BLL
{
	/// <summary>
	/// 业务逻辑类goldtrade_db_admin 的摘要说明。
	/// </summary>
	public class goldtrade_db_admin
	{
        #region 自定义方法 Add by tianjie

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string sAdminName)
        {
            return dal.Exists(sAdminName);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int iAdminID,string sAdminName)
        {
            return dal.Exists(iAdminID,sAdminName);
        }

        public bool IA100InUsed(Guid sIA100GUID)
        {
            return dal.IA100InUsed(sIA100GUID);
        }

        public bool IA100InUsed(int iAdminID,Guid sIA100GUID)
        {
            return dal.IA100InUsed(iAdminID, sIA100GUID);
        }

        #endregion


		private readonly GoldTradeNaming.DAL.goldtrade_db_admin dal=new GoldTradeNaming.DAL.goldtrade_db_admin();
		public goldtrade_db_admin()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int sys_admin_id)
		{
			return dal.Exists(sys_admin_id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(GoldTradeNaming.Model.goldtrade_db_admin model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(GoldTradeNaming.Model.goldtrade_db_admin model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int sys_admin_id)
		{
			
			dal.Delete(sys_admin_id);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public GoldTradeNaming.Model.goldtrade_db_admin GetModel(int sys_admin_id)
		{
			
			return dal.GetModel(sys_admin_id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public GoldTradeNaming.Model.goldtrade_db_admin GetModelByCache(int sys_admin_id)
		{
			
			string CacheKey = "goldtrade_db_adminModel-" + sys_admin_id;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(sys_admin_id);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (GoldTradeNaming.Model.goldtrade_db_admin)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<GoldTradeNaming.Model.goldtrade_db_admin> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<GoldTradeNaming.Model.goldtrade_db_admin> modelList = new List<GoldTradeNaming.Model.goldtrade_db_admin>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				GoldTradeNaming.Model.goldtrade_db_admin model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new GoldTradeNaming.Model.goldtrade_db_admin();
					if(ds.Tables[0].Rows[n]["sys_admin_id"].ToString()!="")
					{
						model.sys_admin_id=int.Parse(ds.Tables[0].Rows[n]["sys_admin_id"].ToString());
					}
					model.sys_admin_name=ds.Tables[0].Rows[n]["sys_admin_name"].ToString();
					model.sys_admin_tel=ds.Tables[0].Rows[n]["sys_admin_tel"].ToString();
					model.sys_admin_cellphone=ds.Tables[0].Rows[n]["sys_admin_cellphone"].ToString();
					if(ds.Tables[0].Rows[n]["IA100GUID"].ToString()!="")
					{
						model.IA100GUID=new Guid(ds.Tables[0].Rows[n]["IA100GUID"].ToString());
					}
					model.ins_user=ds.Tables[0].Rows[n]["ins_user"].ToString();
					if(ds.Tables[0].Rows[n]["ins_date"].ToString()!="")
					{
						model.ins_date=DateTime.Parse(ds.Tables[0].Rows[n]["ins_date"].ToString());
					}
					model.upd_user=ds.Tables[0].Rows[n]["upd_user"].ToString();
					if(ds.Tables[0].Rows[n]["upd_date"].ToString()!="")
					{
						model.upd_date=DateTime.Parse(ds.Tables[0].Rows[n]["upd_date"].ToString());
					}
					modelList.Add(model);
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  成员方法
	}
}

