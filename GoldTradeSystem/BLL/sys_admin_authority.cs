using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using GoldTradeNaming.Model;
using System.Collections;
namespace GoldTradeNaming.BLL
{
    /// <summary>
    /// ҵ���߼���sys_admin_authority ��ժҪ˵����
    /// </summary>
    public class sys_admin_authority
    {
        #region Addby TianJie
        public DataTable GetRightSet(int adminid)
        {
            return dal.GetRightSet(adminid);
        }

        #endregion

        private readonly GoldTradeNaming.DAL.sys_admin_authority dal = new GoldTradeNaming.DAL.sys_admin_authority();
        public sys_admin_authority()
        {
        }
        #region  ��Ա����

        /// <summary>
        /// ���¹���ԱȨ�� by yuxiaowei
        /// </summary>
        /// <param name="sys_admin_id"></param>
        /// <param name="sModule"></param>
        public void Update(int sys_admin_id,ArrayList sModule)
        {
             dal.Update(sys_admin_id,sModule);
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
        public bool Exists(int sys_admin_id,string sys_module)
        {
            return dal.Exists(sys_admin_id,sys_module);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public void Add(GoldTradeNaming.Model.sys_admin_authority model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public void Update(GoldTradeNaming.Model.sys_admin_authority model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public void Delete(int sys_admin_id,string sys_module)
        {

            dal.Delete(sys_admin_id,sys_module);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public GoldTradeNaming.Model.sys_admin_authority GetModel(int sys_admin_id,string sys_module)
        {

            return dal.GetModel(sys_admin_id,sys_module);
        }

        /// <summary>
        /// �õ�һ������ʵ�壬�ӻ����С�
        /// </summary>
        public GoldTradeNaming.Model.sys_admin_authority GetModelByCache(int sys_admin_id,string sys_module)
        {

            string CacheKey = "sys_admin_authorityModel-" + sys_admin_id + sys_module;
            object objModel = LTP.Common.DataCache.GetCache(CacheKey);
            if(objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(sys_admin_id,sys_module);
                    if(objModel != null)
                    {
                        int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
                        LTP.Common.DataCache.SetCache(CacheKey,objModel,DateTime.Now.AddMinutes(ModelCache),TimeSpan.Zero);
                    }
                }
                catch
                {
                }
            }
            return (GoldTradeNaming.Model.sys_admin_authority)objModel;
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
        public List<GoldTradeNaming.Model.sys_admin_authority> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            List<GoldTradeNaming.Model.sys_admin_authority> modelList = new List<GoldTradeNaming.Model.sys_admin_authority>();
            int rowsCount = ds.Tables[0].Rows.Count;
            if(rowsCount > 0)
            {
                GoldTradeNaming.Model.sys_admin_authority model;
                for(int n = 0;n < rowsCount;n++)
                {
                    model = new GoldTradeNaming.Model.sys_admin_authority();
                    if(ds.Tables[0].Rows[n]["sys_admin_id"].ToString() != "")
                    {
                        model.sys_admin_id = int.Parse(ds.Tables[0].Rows[n]["sys_admin_id"].ToString());
                    }
                    model.sys_module = ds.Tables[0].Rows[n]["sys_module"].ToString();
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

