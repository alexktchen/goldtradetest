using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using GoldTradeNaming.Model;
namespace GoldTradeNaming.BLL
{
	/// <summary>
	/// ҵ���߼���realtime_price ��ժҪ˵����
	/// </summary>
	public class realtime_price
	{
		private readonly GoldTradeNaming.DAL.realtime_price dal=new GoldTradeNaming.DAL.realtime_price();
		public realtime_price()
		{}
		#region  ��Ա����

        /// <summary>
        /// ������½�ۼ۸� add by yuxiaowei
        /// </summary>
        public DataSet getCurrentPrice()
        {
            return dal.getCurrentPrice();
        }



		/// <summary>
		/// �õ����ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int id)
		{
			return dal.Exists(id);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(GoldTradeNaming.Model.realtime_price model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(GoldTradeNaming.Model.realtime_price model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int id)
		{
			
			dal.Delete(id);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public GoldTradeNaming.Model.realtime_price GetModel(int id)
		{
			
			return dal.GetModel(id);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
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
		/// ��������б�
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// ��������б�
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
		/// ��������б�
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  ��Ա����
	}
}

