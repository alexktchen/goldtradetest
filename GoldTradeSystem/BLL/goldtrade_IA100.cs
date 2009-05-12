using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using GoldTradeNaming.Model;
namespace GoldTradeNaming.BLL
{
	/// <summary>
	/// 业务逻辑类goldtrade_IA100 的摘要说明。
	/// </summary>
	public class goldtrade_IA100
    {
        #region AddBy 田杰

        //public bool ()

        #endregion 


        private readonly GoldTradeNaming.DAL.goldtrade_IA100 dal=new GoldTradeNaming.DAL.goldtrade_IA100();
		public goldtrade_IA100()
		{}
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(Guid IA100GUID)
		{
			return dal.Exists(IA100GUID);
		}

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsAndNotInUse(Guid IA100GUID)
        {
            return dal.ExistsAndNotInUse(IA100GUID);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(GoldTradeNaming.Model.goldtrade_IA100 model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(GoldTradeNaming.Model.goldtrade_IA100 model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(Guid IA100GUID)
		{
			
			dal.Delete(IA100GUID);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public GoldTradeNaming.Model.goldtrade_IA100 GetModel(Guid IA100GUID)
		{
			
			return dal.GetModel(IA100GUID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public GoldTradeNaming.Model.goldtrade_IA100 GetModelByCache(Guid IA100GUID)
		{
			
			string CacheKey = "goldtrade_IA100Model-" + IA100GUID;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(IA100GUID);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (GoldTradeNaming.Model.goldtrade_IA100)objModel;
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
		public List<GoldTradeNaming.Model.goldtrade_IA100> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<GoldTradeNaming.Model.goldtrade_IA100> modelList = new List<GoldTradeNaming.Model.goldtrade_IA100>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				GoldTradeNaming.Model.goldtrade_IA100 model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new GoldTradeNaming.Model.goldtrade_IA100();
					if(ds.Tables[0].Rows[n]["IA100GUID"].ToString()!="")
					{
						model.IA100GUID=new Guid(ds.Tables[0].Rows[n]["IA100GUID"].ToString());
					}
					model.IA100Key=ds.Tables[0].Rows[n]["IA100Key"].ToString();
					model.IA100SuperPswd=ds.Tables[0].Rows[n]["IA100SuperPswd"].ToString();
					model.IA100State=ds.Tables[0].Rows[n]["IA100State"].ToString();
					model.StateChangeReason=ds.Tables[0].Rows[n]["StateChangeReason"].ToString();
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

