using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using GoldTradeNaming.Model;
namespace GoldTradeNaming.BLL
{
	/// <summary>
	/// 业务逻辑类franchiser_order_desc 的摘要说明。
	/// </summary>
	public class franchiser_order_desc
	{

		private readonly GoldTradeNaming.DAL.franchiser_order_desc dal=new GoldTradeNaming.DAL.franchiser_order_desc();
		public franchiser_order_desc()
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
		public bool Exists(int id)
		{
			return dal.Exists(id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(GoldTradeNaming.Model.franchiser_order_desc model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(GoldTradeNaming.Model.franchiser_order_desc model)
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
		public GoldTradeNaming.Model.franchiser_order_desc GetModel(int id)
		{
			
			return dal.GetModel(id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public GoldTradeNaming.Model.franchiser_order_desc GetModelByCache(int id)
		{
			
			string CacheKey = "franchiser_order_descModel-" + id;
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
			return (GoldTradeNaming.Model.franchiser_order_desc)objModel;
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
		public List<GoldTradeNaming.Model.franchiser_order_desc> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<GoldTradeNaming.Model.franchiser_order_desc> modelList = new List<GoldTradeNaming.Model.franchiser_order_desc>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				GoldTradeNaming.Model.franchiser_order_desc model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new GoldTradeNaming.Model.franchiser_order_desc();
					if(ds.Tables[0].Rows[n]["id"].ToString()!="")
					{
						model.id=int.Parse(ds.Tables[0].Rows[n]["id"].ToString());
					}
					if(ds.Tables[0].Rows[n]["franchiser_order_id"].ToString()!="")
					{
						model.franchiser_order_id=int.Parse(ds.Tables[0].Rows[n]["franchiser_order_id"].ToString());
					}
					if(ds.Tables[0].Rows[n]["product_id"].ToString()!="")
					{
						model.product_id=int.Parse(ds.Tables[0].Rows[n]["product_id"].ToString());
					}
					if(ds.Tables[0].Rows[n]["product_spec_id"].ToString()!="")
					{
						model.product_spec_id=int.Parse(ds.Tables[0].Rows[n]["product_spec_id"].ToString());
					}
					if(ds.Tables[0].Rows[n]["order_product_amount"].ToString()!="")
					{
						model.order_product_amount=int.Parse(ds.Tables[0].Rows[n]["order_product_amount"].ToString());
					}
					if(ds.Tables[0].Rows[n]["product_received"].ToString()!="")
					{
						model.product_received=int.Parse(ds.Tables[0].Rows[n]["product_received"].ToString());
					}
					if(ds.Tables[0].Rows[n]["product_unreceived"].ToString()!="")
					{
						model.product_unreceived=int.Parse(ds.Tables[0].Rows[n]["product_unreceived"].ToString());
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

