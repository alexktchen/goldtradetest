using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using GoldTradeNaming.Model;
namespace GoldTradeNaming.BLL
{
	/// <summary>
	/// 业务逻辑类stock_main 的摘要说明。
	/// </summary>
	public class stock_main
	{
		private readonly GoldTradeNaming.DAL.stock_main dal=new GoldTradeNaming.DAL.stock_main();
		public stock_main()
		{ }

        #region  自定义成员方法
        /// <summary>
        /// 返回库存修改记录
        /// </summary>
        /// <returns></returns>
        public DataSet getStockModifyLog()
        {
            return dal.getStockModifyLog();
        }
        /// <summary>
        /// 显示经销商的库存信息
        /// </summary>
        /// <param name="Fran_ID">经销ID</param>
        /// <returns></returns>
        public DataSet getAllInfoAboutM(string Fran_ID)
        {
            DataSet ds;
            try
            {
                ds = dal.getAllInfoAboutM(Fran_ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }
        /// <summary>
        /// 经销总余额
        /// </summary>
        /// <returns></returns>
        public String getLeftMoney()
        {
            return dal.getLeftMoney();
        }
        /// <summary>
        /// 经销商总交易额
        /// </summary>
        /// <returns></returns>
        public String getTotalTrade()
        {
            return dal.getSumTrade();
        }
        /// <summary>
        /// 经销商入帐总额
        /// </summary>
        /// <returns></returns>
        public String getAdMoeney()
        {
            return dal.getAddMoney();
        }
        /// <summary>
        /// 获得销售报表
        /// </summary>
        /// <returns></returns>
        public DataSet getSalesReprot(string time_from, string time_to)
        {
            return dal.getSalesReport(time_from, time_to);
        }

         ///<summary>
        ///库存信息修改
        /// </summary>
        ///<param name="fran_id">经销商ID</param> 
        ///<param name="product_type_id">产品类别ID</param>
        ///<param name="product_kind_id">产品规格ID</param>
        ///<param name="tag">变更标记， 0-增加，1-减少</param>
        ///<param name="mount">库存变更量</param>
        ///<returns name="tmp_tag">true:执行成功，false:执行失败</returns>
        ///modify date:20090511
        ///modifier:yiyong
        ///modify content:int product_kind_id----->decimal product_kind_id
        public bool stock_chang(string fran_id, int product_type_id, decimal product_kind_id, int tag, int mount)
        {
            return dal.stock_chang(fran_id, product_type_id, product_kind_id, tag, mount);
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
		public bool Exists(int id)
		{
			return dal.Exists(id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(GoldTradeNaming.Model.stock_main model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(GoldTradeNaming.Model.stock_main model)
		{
			dal.Update(model);
		}
        public int updateStock(GoldTradeNaming.Model.stock_main model) 
        {
            int returnValue = int.MinValue;
            try
            {
                returnValue = dal.updateStock(model);
            }
            catch (Exception ex) 
            {
                throw ex;
            }
            return returnValue;
        }
        public bool updateStock1(GoldTradeNaming.Model.stock_main model)
        {
            return dal.updateStock1(model);
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
		public GoldTradeNaming.Model.stock_main GetModel(int id)
		{
            GoldTradeNaming.Model.stock_main temp;
            try
            {
                temp = dal.GetModel(id);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return temp;
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public GoldTradeNaming.Model.stock_main GetModelByCache(int id)
		{
			
			string CacheKey = "stock_mainModel-" + id;
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
			return (GoldTradeNaming.Model.stock_main)objModel;
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
		public List<GoldTradeNaming.Model.stock_main> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<GoldTradeNaming.Model.stock_main> modelList = new List<GoldTradeNaming.Model.stock_main>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				GoldTradeNaming.Model.stock_main model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new GoldTradeNaming.Model.stock_main();
					if(ds.Tables[0].Rows[n]["id"].ToString()!="")
					{
						model.id=int.Parse(ds.Tables[0].Rows[n]["id"].ToString());
					}
					model.franchiser_code=ds.Tables[0].Rows[n]["franchiser_code"].ToString();
					if(ds.Tables[0].Rows[n]["product_id"].ToString()!="")
					{
						model.product_id=int.Parse(ds.Tables[0].Rows[n]["product_id"].ToString());
					}
					if(ds.Tables[0].Rows[n]["product_spec_id"].ToString()!="")
					{
						model.product_spec_id=int.Parse(ds.Tables[0].Rows[n]["product_spec_id"].ToString());
					}
					if(ds.Tables[0].Rows[n]["stock_total"].ToString()!="")
					{
						model.stock_total=int.Parse(ds.Tables[0].Rows[n]["stock_total"].ToString());
					}
					if(ds.Tables[0].Rows[n]["stock_left"].ToString()!="")
					{
						model.stock_left=int.Parse(ds.Tables[0].Rows[n]["stock_left"].ToString());
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

