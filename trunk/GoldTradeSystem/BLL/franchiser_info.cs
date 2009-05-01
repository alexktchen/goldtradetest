using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using GoldTradeNaming.Model;
namespace GoldTradeNaming.BLL
{
    /// <summary>
    /// ҵ���߼���franchiser_info ��ժҪ˵����
    /// </summary>
    public class franchiser_info
    {
        private readonly GoldTradeNaming.DAL.franchiser_info dal = new GoldTradeNaming.DAL.franchiser_info();
        public franchiser_info()
        {
        }
        #region  ��Ա����

        /// <summary>
        /// �Ƿ���ڸù�Ӧ�����ּ�¼ ����ʱ add by yuxiaowei
        /// </summary>
        public bool Exists(string franchiser_name)
        {
            return dal.Exists(franchiser_name);
        }
        /// <summary>
        /// �Ƿ���ڸù�Ӧ�����ּ�¼(���þ����̱��)�� �޸�ʱ add by yuxiaowei
        /// </summary>
        /// <param name="franchiser_code"></param>
        /// <param name="franchiser_name"></param>
        /// <returns></returns>
        public bool Exists(int franchiser_code,string franchiser_name)
        {
            return dal.Exists(franchiser_code,franchiser_name);
        }

        /// <summary>
        /// ����ԭ��֤��ID by yuxiaowei
        /// </summary>
        /// <param name="IA100GUID"></param>
        /// <param name="reason"></param>
        /// <returns></returns>
        public int DisableIA(Guid IA100GUID,string reason)
        {
            return dal.DisableIA(IA100GUID,reason);
        }

        /// <summary>
        /// �Ƿ���ڸ�IA100GUID��¼ �޸�ʱ add by yuxiaowei
        /// </summary>
        public bool Exists(int franchiser_code,Guid guid)
        {
            return dal.Exists(franchiser_code,guid);
        }
        ///

        /// <summary>
        /// �Ƿ���ڸ�IA100GUID��¼ add by yuxiaowei
        /// </summary>
        public bool Exists(Guid guid)
        {
            return dal.Exists(guid);
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
        public bool Exists(int franchiser_code)
        {
            return dal.Exists(franchiser_code);
        }


        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(GoldTradeNaming.Model.franchiser_info model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public void Update(GoldTradeNaming.Model.franchiser_info model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public void Delete(int franchiser_code)
        {

            dal.Delete(franchiser_code);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public GoldTradeNaming.Model.franchiser_info GetModel(int franchiser_code)
        {

            return dal.GetModel(franchiser_code);
        }

        /// <summary>
        /// �õ�һ������ʵ�壬�ӻ����С�
        /// </summary>
        public GoldTradeNaming.Model.franchiser_info GetModelByCache(int franchiser_code)
        {

            string CacheKey = "franchiser_infoModel-" + franchiser_code;
            object objModel = LTP.Common.DataCache.GetCache(CacheKey);
            if(objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(franchiser_code);
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
            return (GoldTradeNaming.Model.franchiser_info)objModel;
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
        public List<GoldTradeNaming.Model.franchiser_info> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            List<GoldTradeNaming.Model.franchiser_info> modelList = new List<GoldTradeNaming.Model.franchiser_info>();
            int rowsCount = ds.Tables[0].Rows.Count;
            if(rowsCount > 0)
            {
                GoldTradeNaming.Model.franchiser_info model;
                for(int n = 0;n < rowsCount;n++)
                {
                    model = new GoldTradeNaming.Model.franchiser_info();
                    if(ds.Tables[0].Rows[n]["franchiser_code"].ToString() != "")
                    {
                        model.franchiser_code = int.Parse(ds.Tables[0].Rows[n]["franchiser_code"].ToString());
                    }
                    model.franchiser_name = ds.Tables[0].Rows[n]["franchiser_name"].ToString();
                    if(ds.Tables[0].Rows[n]["franchiser_balance_money"].ToString() != "")
                    {
                        model.franchiser_balance_money = decimal.Parse(ds.Tables[0].Rows[n]["franchiser_balance_money"].ToString());
                    }
                    if(ds.Tables[0].Rows[n]["franchiser_asure_money"].ToString() != "")
                    {
                        model.franchiser_asure_money = decimal.Parse(ds.Tables[0].Rows[n]["franchiser_asure_money"].ToString());
                    }
                    model.franchiser_tel = ds.Tables[0].Rows[n]["franchiser_tel"].ToString();
                    model.franchiser_cellphone = ds.Tables[0].Rows[n]["franchiser_cellphone"].ToString();
                    model.franchiser_address = ds.Tables[0].Rows[n]["franchiser_address"].ToString();
                    model.ins_user = ds.Tables[0].Rows[n]["ins_user"].ToString();
                    if(ds.Tables[0].Rows[n]["ins_date"].ToString() != "")
                    {
                        model.ins_date = DateTime.Parse(ds.Tables[0].Rows[n]["ins_date"].ToString());
                    }
                    model.upd_user = ds.Tables[0].Rows[n]["upd_user"].ToString();
                    if(ds.Tables[0].Rows[n]["upd_date"].ToString() != "")
                    {
                        model.upd_date = DateTime.Parse(ds.Tables[0].Rows[n]["upd_date"].ToString());
                    }
                    if(ds.Tables[0].Rows[n]["IA100GUID"].ToString() != "")
                    {
                        model.IA100GUID = new Guid(ds.Tables[0].Rows[n]["IA100GUID"].ToString());
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

