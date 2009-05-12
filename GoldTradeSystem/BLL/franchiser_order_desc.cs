using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using GoldTradeNaming.Model;
namespace GoldTradeNaming.BLL
{
	/// <summary>
	/// ҵ���߼���franchiser_order_desc ��ժҪ˵����
	/// </summary>
	public class franchiser_order_desc
	{

		private readonly GoldTradeNaming.DAL.franchiser_order_desc dal=new GoldTradeNaming.DAL.franchiser_order_desc();
		public franchiser_order_desc()
		{}
		#region  ��Ա����

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
		public int  Add(GoldTradeNaming.Model.franchiser_order_desc model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(GoldTradeNaming.Model.franchiser_order_desc model)
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
		public GoldTradeNaming.Model.franchiser_order_desc GetModel(int id)
		{
			
			return dal.GetModel(id);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
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
		/// ��������б�
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// ��������б�
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

