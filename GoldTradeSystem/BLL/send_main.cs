using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using GoldTradeNaming.Model;
namespace GoldTradeNaming.BLL
{
	/// <summary>
	/// 业务逻辑类send_main 的摘要说明。
	/// </summary>
	public class send_main
	{
        #region add by tianjie

        public DataSet GetOrderInfo(string strWhere)
        {
            return dal.GetOrderInfo(strWhere);
        }

        public DataSet GetOrderedProductList(string strWhere)
        {
            return dal.GetOrderedProductList(strWhere);
        }

        public bool SaveSendInfo(GoldTradeNaming.Model.send_main sm, List<GoldTradeNaming.Model.send_desc> sdlst)
        {
            return dal.SaveSendInfo(sm, sdlst);
        }

        public int CancelSend(GoldTradeNaming.Model.send_main s)
        {
            return dal.CancelSend(s);
        }

        public bool ConfirmReceive(int franId,int OrderId,int SendId)
        {
            return dal.ConfirmReceive(franId, OrderId, SendId);
        }

        public DataSet GetSendInfo(string where)
        {
            return dal.GetSendInfo(where);
        }

        #endregion

		private readonly GoldTradeNaming.DAL.send_main dal=new GoldTradeNaming.DAL.send_main();
		public send_main()
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
		public bool Exists(int send_id)
		{
			return dal.Exists(send_id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(GoldTradeNaming.Model.send_main model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(GoldTradeNaming.Model.send_main model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int send_id)
		{
			
			dal.Delete(send_id);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public GoldTradeNaming.Model.send_main GetModel(int send_id)
		{
			
			return dal.GetModel(send_id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public GoldTradeNaming.Model.send_main GetModelByCache(int send_id)
		{
			
			string CacheKey = "send_mainModel-" + send_id;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(send_id);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (GoldTradeNaming.Model.send_main)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}

        /// <summary>
        /// 查出经销商的收货单
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetListByFranID(string strWhere)
        {
            return dal.GetListByFranID(strWhere);
        }
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<GoldTradeNaming.Model.send_main> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<GoldTradeNaming.Model.send_main> modelList = new List<GoldTradeNaming.Model.send_main>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				GoldTradeNaming.Model.send_main model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new GoldTradeNaming.Model.send_main();
					if(ds.Tables[0].Rows[n]["send_id"].ToString()!="")
					{
						model.send_id=int.Parse(ds.Tables[0].Rows[n]["send_id"].ToString());
					}
					if(ds.Tables[0].Rows[n]["franchiser_order_id"].ToString()!="")
					{
						model.franchiser_order_id=int.Parse(ds.Tables[0].Rows[n]["franchiser_order_id"].ToString());
					}
					if(ds.Tables[0].Rows[n]["send_time"].ToString()!="")
					{
						model.send_time=DateTime.Parse(ds.Tables[0].Rows[n]["send_time"].ToString());
					}
					if(ds.Tables[0].Rows[n]["send_amount_weight"].ToString()!="")
					{
						model.send_amount_weight=int.Parse(ds.Tables[0].Rows[n]["send_amount_weight"].ToString());
					}
					model.send_state=ds.Tables[0].Rows[n]["send_state"].ToString();
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
					model.canceled_reason=ds.Tables[0].Rows[n]["canceled_reason"].ToString();
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

