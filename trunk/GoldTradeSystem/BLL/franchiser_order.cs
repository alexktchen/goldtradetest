using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using GoldTradeNaming.Model;
namespace GoldTradeNaming.BLL
{
	/// <summary>
	/// ҵ���߼���franchiser_order ��ժҪ˵����
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
        /// ȷ�϶���
        /// </summary>
        public bool ConfirmOrder(int franchiser_order_id, string upduser)
        {
            return dal.UpdateOrderState(franchiser_order_id, upduser);
        }

        /// <summary>
        /// ���¶���order��Ϣ  by yuxiaowei 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateOrderInfo(GoldTradeNaming.Model.franchiser_order model)
        {
            return dal.UpdateOrderInfo(model);
        }
        /// <summary>
        /// ��ý������� by yuxiaowei       
        /// </summary>
        public DataSet GetOrderInfo(string strWhere)
        {
            return dal.GetOrderInfo(strWhere);
        }

        /// <summary>
        /// ��ûƽ��Ʒ�б�
        /// </summary>
        /// <returns></returns>
        public DataSet GetGoldProduct()
        {
            return dal.GetGoldProduct();
        }

        /// <summary>
        /// ��ð�����Ʒ�б�
        /// </summary>
        /// <returns></returns>
        public DataSet GetSilverProduct()
        {
            return dal.GetSilverProduct();
        }

        /// <summary>
        /// ���淢����Ϣ
        /// </summary>
        /// <param name="model"></param>
        /// <param name="orderlst"></param>
        /// <returns></returns>
        public bool SaveOrderInfo(GoldTradeNaming.Model.franchiser_order model, List<GoldTradeNaming.Model.franchiser_order_desc> orderlst)
        {
            return this.dal.SaveOrderInfo(model, orderlst);
        }
        #region �Զ����Ա����
       ///// <summary>
       ///// ����product_type�����б�
       ///// </summary>
       ///// <returns></returns>
       // public DataSet getproduct_type_id() {
       //     return dal.getproduct_type_id();
       // }

           /// <summary>
        /// ����product_name����product_spec_weight
        /// </summary>
        /// <param name="product_naem"></param>
        /// <returns></returns>
        public DataSet getproduct_spec(string product_name) {

            return dal.getproduct_spec(product_name);
        
        }


        /// <summary>
        /// ���ݾ����̺ŵõ������������
        /// </summary>
        /// <param name="franchiser_code"></param>
        /// <returns></returns>
        public GoldTradeNaming.Model.franchiser_info GetInfortModel(int franchiser_code)
        {
            return dal.GetInforModel(franchiser_code);
        }

        /// <summary>
        /// �����������
        /// </summary>
        /// <param name="model"></param>
        public void updateInfor(GoldTradeNaming.Model.franchiser_info model)
        {
            dal.updateInfor(model);


        }

        #endregion



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
		public bool Exists(int franchiser_order_id)
		{
			return dal.Exists(franchiser_order_id);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(GoldTradeNaming.Model.franchiser_order model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(GoldTradeNaming.Model.franchiser_order model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int franchiser_order_id)
		{
			
			dal.Delete(franchiser_order_id);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public GoldTradeNaming.Model.franchiser_order GetModel(int franchiser_order_id)
		{
			
			return dal.GetModel(franchiser_order_id);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
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
		/// ��������б�
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}

        /// <summary>
        /// ����������
        /// </summary>
        /// <param name="franID"></param>
        /// <returns></returns>
        public DataSet GetLatestList(int franID)
        {
            return dal.GetLatestList(franID);
        }

		/// <summary>
		/// ��������б�
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

