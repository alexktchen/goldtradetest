using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using GoldTradeNaming.Model;
namespace GoldTradeNaming.BLL
{
	/// <summary>
	/// 业务逻辑类franchiser_order 的摘要说明。
	/// </summary>
	public class franchiser_order
	{
		private readonly GoldTradeNaming.DAL.franchiser_order dal=new GoldTradeNaming.DAL.franchiser_order();
		public franchiser_order()
		{ }

        public DataSet GetProductList()
        {
            return dal.GetProductList();
        }

        /// <summary>
        /// 确认订单
        /// </summary>
        public bool ConfirmOrder(int franchiser_order_id, string upduser)
        {
            return dal.UpdateOrderState(franchiser_order_id, upduser);
        }

        /// <summary>
        /// 更新订单order信息  by yuxiaowei 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateOrderInfo(GoldTradeNaming.Model.franchiser_order model)
        {
            return dal.UpdateOrderInfo(model);
        }
        /// <summary>
        /// 获得交易主表 by yuxiaowei       
        /// </summary>
        public DataSet GetOrderInfo(string strWhere)
        {
            return dal.GetOrderInfo(strWhere);
        }

        /// <summary>
        /// 获得黄金产品列表
        /// </summary>
        /// <returns></returns>
        public DataSet GetGoldProduct()
        {
            return dal.GetGoldProduct();
        }

        /// <summary>
        /// 获得白银产品列表
        /// </summary>
        /// <returns></returns>
        public DataSet GetSilverProduct()
        {
            return dal.GetSilverProduct();
        }

        /// <summary>
        /// 保存发货信息
        /// </summary>
        /// <param name="model"></param>
        /// <param name="orderlst"></param>
        /// <returns></returns>
        public bool SaveOrderInfo(GoldTradeNaming.Model.franchiser_order model, List<GoldTradeNaming.Model.franchiser_order_desc> orderlst)
        {
            return this.dal.SaveOrderInfo(model, orderlst);
        }
        #region 自定义成员方法
       ///// <summary>
       ///// 带出product_type下来列表
       ///// </summary>
       ///// <returns></returns>
       // public DataSet getproduct_type_id() {
       //     return dal.getproduct_type_id();
       // }

           /// <summary>
        /// 根据product_name带出product_spec_weight
        /// </summary>
        /// <param name="product_naem"></param>
        /// <returns></returns>
        public DataSet getproduct_spec(string product_name) {

            return dal.getproduct_spec(product_name);
        
        }


        /// <summary>
        /// 根据经销商号得到他的账面余额
        /// </summary>
        /// <param name="franchiser_code"></param>
        /// <returns></returns>
        public GoldTradeNaming.Model.franchiser_info GetInfortModel(int franchiser_code)
        {
            return dal.GetInforModel(franchiser_code);
        }

        /// <summary>
        /// 更新账面余额
        /// </summary>
        /// <param name="model"></param>
        public void updateInfor(GoldTradeNaming.Model.franchiser_info model)
        {
            dal.updateInfor(model);


        }

        #endregion



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
		public bool Exists(int franchiser_order_id)
		{
			return dal.Exists(franchiser_order_id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(GoldTradeNaming.Model.franchiser_order model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(GoldTradeNaming.Model.franchiser_order model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int franchiser_order_id)
		{
			
			dal.Delete(franchiser_order_id);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public GoldTradeNaming.Model.franchiser_order GetModel(int franchiser_order_id)
		{
			
			return dal.GetModel(franchiser_order_id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public GoldTradeNaming.Model.franchiser_order GetModelByCache(int franchiser_order_id)
		{
			
			string CacheKey = "franchiser_orderModel-" + franchiser_order_id;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(franchiser_order_id);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (GoldTradeNaming.Model.franchiser_order)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}

        /// <summary>
        /// 获得最近订单
        /// </summary>
        /// <param name="franID"></param>
        /// <returns></returns>
        public DataSet GetLatestList(int franID)
        {
            return dal.GetLatestList(franID);
        }

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<GoldTradeNaming.Model.franchiser_order> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<GoldTradeNaming.Model.franchiser_order> modelList = new List<GoldTradeNaming.Model.franchiser_order>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				GoldTradeNaming.Model.franchiser_order model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new GoldTradeNaming.Model.franchiser_order();
					if(ds.Tables[0].Rows[n]["franchiser_order_id"].ToString()!="")
					{
						model.franchiser_order_id=int.Parse(ds.Tables[0].Rows[n]["franchiser_order_id"].ToString());
					}
					if(ds.Tables[0].Rows[n]["franchiser_code"].ToString()!="")
					{
						model.franchiser_code=int.Parse(ds.Tables[0].Rows[n]["franchiser_code"].ToString());
					}
					model.franchiser_order_trans_type=ds.Tables[0].Rows[n]["franchiser_order_trans_type"].ToString();
					model.franchiser_order_address=ds.Tables[0].Rows[n]["franchiser_order_address"].ToString();
					model.franchiser_order_postcode=ds.Tables[0].Rows[n]["franchiser_order_postcode"].ToString();
					model.franchiser_order_handle_man=ds.Tables[0].Rows[n]["franchiser_order_handle_man"].ToString();
					model.franchiser_order_handle_tel=ds.Tables[0].Rows[n]["franchiser_order_handle_tel"].ToString();
					model.franchiser_order_handle_phone=ds.Tables[0].Rows[n]["franchiser_order_handle_phone"].ToString();
					if(ds.Tables[0].Rows[n]["franchiser_order_price"].ToString()!="")
					{
						model.franchiser_order_price=decimal.Parse(ds.Tables[0].Rows[n]["franchiser_order_price"].ToString());
					}
					if(ds.Tables[0].Rows[n]["franchiser_order_add_price"].ToString()!="")
					{
						model.franchiser_order_add_price=decimal.Parse(ds.Tables[0].Rows[n]["franchiser_order_add_price"].ToString());
					}
					if(ds.Tables[0].Rows[n]["franchiser_order_appraise"].ToString()!="")
					{
						model.franchiser_order_appraise=decimal.Parse(ds.Tables[0].Rows[n]["franchiser_order_appraise"].ToString());
					}
					if(ds.Tables[0].Rows[n]["franchiser_order_time"].ToString()!="")
					{
						model.franchiser_order_time=DateTime.Parse(ds.Tables[0].Rows[n]["franchiser_order_time"].ToString());
					}
					model.franchiser_order_state=ds.Tables[0].Rows[n]["franchiser_order_state"].ToString();
					if(ds.Tables[0].Rows[n]["franchiser_order_amount_money"].ToString()!="")
					{
						model.franchiser_order_amount_money=decimal.Parse(ds.Tables[0].Rows[n]["franchiser_order_amount_money"].ToString());
					}
					model.canceled_reason=ds.Tables[0].Rows[n]["canceled_reason"].ToString();
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

