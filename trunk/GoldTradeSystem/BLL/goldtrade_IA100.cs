using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using GoldTradeNaming.Model;
namespace GoldTradeNaming.BLL
{
	/// <summary>
	/// ҵ���߼���goldtrade_IA100 ��ժҪ˵����
	/// </summary>
	public class goldtrade_IA100
    {
        #region AddBy ���

        //public bool ()

        #endregion 


        private readonly GoldTradeNaming.DAL.goldtrade_IA100 dal=new GoldTradeNaming.DAL.goldtrade_IA100();
		public goldtrade_IA100()
		{}
		#region  ��Ա����
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(Guid IA100GUID)
		{
			return dal.Exists(IA100GUID);
		}

        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool ExistsAndNotInUse(Guid IA100GUID)
        {
            return dal.ExistsAndNotInUse(IA100GUID);
        }

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Add(GoldTradeNaming.Model.goldtrade_IA100 model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(GoldTradeNaming.Model.goldtrade_IA100 model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(Guid IA100GUID)
		{
			
			dal.Delete(IA100GUID);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public GoldTradeNaming.Model.goldtrade_IA100 GetModel(Guid IA100GUID)
		{
			
			return dal.GetModel(IA100GUID);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
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
		/// ��������б�
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// ��������б�
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

