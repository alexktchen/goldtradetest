using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using GoldTradeNaming.Model;
namespace GoldTradeNaming.BLL
{
	/// <summary>
	/// ҵ���߼���goldtrade_db_admin ��ժҪ˵����
	/// </summary>
	public class goldtrade_db_admin
	{
        #region �Զ��巽�� Add by tianjie

        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(string sAdminName)
        {
            return dal.Exists(sAdminName);
        }

        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int iAdminID,string sAdminName)
        {
            return dal.Exists(iAdminID,sAdminName);
        }

        public bool IA100InUsed(Guid sIA100GUID)
        {
            return dal.IA100InUsed(sIA100GUID);
        }

        public bool IA100InUsed(int iAdminID,Guid sIA100GUID)
        {
            return dal.IA100InUsed(iAdminID, sIA100GUID);
        }

        #endregion


		private readonly GoldTradeNaming.DAL.goldtrade_db_admin dal=new GoldTradeNaming.DAL.goldtrade_db_admin();
		public goldtrade_db_admin()
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
		public bool Exists(int sys_admin_id)
		{
			return dal.Exists(sys_admin_id);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(GoldTradeNaming.Model.goldtrade_db_admin model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(GoldTradeNaming.Model.goldtrade_db_admin model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int sys_admin_id)
		{
			
			dal.Delete(sys_admin_id);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public GoldTradeNaming.Model.goldtrade_db_admin GetModel(int sys_admin_id)
		{
			
			return dal.GetModel(sys_admin_id);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
		/// </summary>
		public GoldTradeNaming.Model.goldtrade_db_admin GetModelByCache(int sys_admin_id)
		{
			
			string CacheKey = "goldtrade_db_adminModel-" + sys_admin_id;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(sys_admin_id);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (GoldTradeNaming.Model.goldtrade_db_admin)objModel;
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
		public List<GoldTradeNaming.Model.goldtrade_db_admin> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<GoldTradeNaming.Model.goldtrade_db_admin> modelList = new List<GoldTradeNaming.Model.goldtrade_db_admin>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				GoldTradeNaming.Model.goldtrade_db_admin model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new GoldTradeNaming.Model.goldtrade_db_admin();
					if(ds.Tables[0].Rows[n]["sys_admin_id"].ToString()!="")
					{
						model.sys_admin_id=int.Parse(ds.Tables[0].Rows[n]["sys_admin_id"].ToString());
					}
					model.sys_admin_name=ds.Tables[0].Rows[n]["sys_admin_name"].ToString();
					model.sys_admin_tel=ds.Tables[0].Rows[n]["sys_admin_tel"].ToString();
					model.sys_admin_cellphone=ds.Tables[0].Rows[n]["sys_admin_cellphone"].ToString();
					if(ds.Tables[0].Rows[n]["IA100GUID"].ToString()!="")
					{
						model.IA100GUID=new Guid(ds.Tables[0].Rows[n]["IA100GUID"].ToString());
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

