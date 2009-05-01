using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using GoldTradeNaming.Model;
namespace GoldTradeNaming.BLL
{
	/// <summary>
	/// 业务逻辑类realtime_price 的摘要说明。
	/// </summary>
	public class realtime_price
	{
		private readonly GoldTradeNaming.DAL.realtime_price dal=new GoldTradeNaming.DAL.realtime_price();
		public realtime_price()
		{}
		#region  成员方法

        /// <summary>
        /// 获得最新金价价格 add by yuxiaowei
        /// </summary>
        public DataSet getCurrentPrice()
        {
            return dal.getCurrentPrice();
        }



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
		public bool Exists(int id)
		{
			return dal.Exists(id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(GoldTradeNaming.Model.realtime_price model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(GoldTradeNaming.Model.realtime_price model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			
			dal.Delete(id);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public GoldTradeNaming.Model.realtime_price GetModel(int id)
		{
			
			return dal.GetModel(id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public GoldTradeNaming.Model.realtime_price GetModelByCache(int id)
		{
			
			string CacheKey = "realtime_priceModel-" + id;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(id);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (GoldTradeNaming.Model.realtime_price)objModel;
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
		public List<GoldTradeNaming.Model.realtime_price> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<GoldTradeNaming.Model.realtime_price> modelList = new List<GoldTradeNaming.Model.realtime_price>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				GoldTradeNaming.Model.realtime_price model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new GoldTradeNaming.Model.realtime_price();
					if(ds.Tables[0].Rows[n]["id"].ToString()!="")
					{
						model.id=int.Parse(ds.Tables[0].Rows[n]["id"].ToString());
					}
					if(ds.Tables[0].Rows[n]["realtime_base_price"].ToString()!="")
					{
						model.realtime_base_price=decimal.Parse(ds.Tables[0].Rows[n]["realtime_base_price"].ToString());
					}
					if(ds.Tables[0].Rows[n]["order_add_price"].ToString()!="")
					{
						model.order_add_price=decimal.Parse(ds.Tables[0].Rows[n]["order_add_price"].ToString());
					}
					if(ds.Tables[0].Rows[n]["trade_add_price"].ToString()!="")
					{
						model.trade_add_price=decimal.Parse(ds.Tables[0].Rows[n]["trade_add_price"].ToString());
					}
					if(ds.Tables[0].Rows[n]["realtime_time"].ToString()!="")
					{
						model.realtime_time=DateTime.Parse(ds.Tables[0].Rows[n]["realtime_time"].ToString());
					}
					if(ds.Tables[0].Rows[n]["sys_admin_id"].ToString()!="")
					{
						model.sys_admin_id=int.Parse(ds.Tables[0].Rows[n]["sys_admin_id"].ToString());
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

