using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using GoldTradeNaming.Model;
namespace GoldTradeNaming.BLL
{
	/// <summary>
	/// ҵ���߼���send_desc ��ժҪ˵����
	/// </summary>
	public class send_desc
	{
        #region add by ���

        /// <summary>
        /// ȡ�ò�Ʒ�б�typeID��SpecID��ϵ��
        /// </summary>
        /// <returns></returns>
        public DataSet GetProdcut()
        {
           return this.dal.GetProdcut();
        }
        /// <summary>
        /// ����send_id�����ϸ�б�
        /// </summary>
        /// <param name="send_id"></param>
        /// <returns></returns>
        public DataSet getSendDesc(string send_id)
        {
            return this.dal.getSendDesc(send_id);
        }
        /// <summary>
        /// ��ȡ����������
        /// </summary>
        /// <param name="fran_id"></param>
        /// <returns></returns>
        public string getFranName(string fran_id)
        {
            return this.dal.getFranName(fran_id);
        }
        /// <summary>
        /// ��ȡ��������
        /// </summary>
        /// <param name="send_id"></param>
        /// <returns></returns>
        public string getSendAmountWeight(string send_id)
        {
            return this.dal.getSendAmountWeight(send_id);
        }
        #endregion

		private readonly GoldTradeNaming.DAL.send_desc dal=new GoldTradeNaming.DAL.send_desc();
		public send_desc()
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
		public int  Add(GoldTradeNaming.Model.send_desc model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(GoldTradeNaming.Model.send_desc model)
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
		public GoldTradeNaming.Model.send_desc GetModel(int id)
		{
			
			return dal.GetModel(id);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
		/// </summary>
		public GoldTradeNaming.Model.send_desc GetModelByCache(int id)
		{
			
			string CacheKey = "send_descModel-" + id;
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
			return (GoldTradeNaming.Model.send_desc)objModel;
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
		public List<GoldTradeNaming.Model.send_desc> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<GoldTradeNaming.Model.send_desc> modelList = new List<GoldTradeNaming.Model.send_desc>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				GoldTradeNaming.Model.send_desc model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new GoldTradeNaming.Model.send_desc();
					if(ds.Tables[0].Rows[n]["id"].ToString()!="")
					{
						model.id=int.Parse(ds.Tables[0].Rows[n]["id"].ToString());
					}
					if(ds.Tables[0].Rows[n]["send_id"].ToString()!="")
					{
						model.send_id=int.Parse(ds.Tables[0].Rows[n]["send_id"].ToString());
					}
					if(ds.Tables[0].Rows[n]["product_id"].ToString()!="")
					{
						model.product_id=int.Parse(ds.Tables[0].Rows[n]["product_id"].ToString());
					}
					if(ds.Tables[0].Rows[n]["product_spec_id"].ToString()!="")
					{
						model.product_spec_id=int.Parse(ds.Tables[0].Rows[n]["product_spec_id"].ToString());
					}
					if(ds.Tables[0].Rows[n]["send_amount_weight"].ToString()!="")
					{
						model.send_amount_weight=int.Parse(ds.Tables[0].Rows[n]["send_amount_weight"].ToString());
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

