using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using GoldTradeNaming.Model;
namespace GoldTradeNaming.BLL
{
    /// <summary>
    /// ҵ���߼���franchiser_money ��ժҪ˵����
    /// </summary>
    public class franchiser_money
    {
        private readonly GoldTradeNaming.DAL.franchiser_money dal = new GoldTradeNaming.DAL.franchiser_money();
        public franchiser_money()
        { }

        #region �Զ����Ա����

        /// <summary>
        /// ��ѯ����
        /// </summary>
        /// <param name="fran_id"></param>
        /// <param name="add_money"></param>
        /// <param name="time_from"></param>
        /// <param name="time_to"></param>
        /// <returns></returns>
        public DataSet queryAction(string fran_id, string add_money, string time_from, string time_to,string check)
        {

            return dal.queryAction(fran_id, add_money, time_from, time_to,check);
        }

        /// <summary>
        /// ��ѯ����
        /// </summary>
        /// <param name="fran_id"></param>
        /// <param name="add_money"></param>
        /// <param name="time_from"></param>
        /// <param name="time_to"></param>
        /// <returns></returns>
        public DataSet queryAction(string fran_id, string add_money, string time_from, string time_to)
        {

            return dal.queryAction(fran_id, add_money, time_from, time_to);
        }

        /// <summary>
        /// �������ݿ��иþ����̱���Ƿ����
        /// </summary>
        /// <param name="fran_id"></param>
        /// <returns></returns>
        public bool fran_id_exists(int fran_id)
        {
            return dal.fran_id_exists(fran_id);
        }




         /// <summary>
        /// ����ͬ������franchiser_info��
        /// </summary>
        /// <param name="franchiser_code"></param>
        /// <param name="franchiser_balance_money"></param>
        /// <param name="tag">0����������м������˽��   -1����������м�ȥ���˽��</param>
        /// <returns></returns>

        public int update_franchiser_info(int franchiser_code, decimal franchiser_balance_money, int tag)
        {
            return dal.update_franchiser_info(franchiser_code, franchiser_balance_money, tag);
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
        public bool Exists(int id)
        {
            return dal.Exists(id);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(GoldTradeNaming.Model.franchiser_money model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Update(GoldTradeNaming.Model.franchiser_money model)
        {
          return  dal.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public int  Delete(int id)
        {

          return  dal.Delete(id);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public GoldTradeNaming.Model.franchiser_money GetModel(int id)
        {

            return dal.GetModel(id);
        }

        /// <summary>
        /// �õ�һ������ʵ�壬�ӻ����С�
        /// </summary>
        public GoldTradeNaming.Model.franchiser_money GetModelByCache(int id)
        {

            string CacheKey = "franchiser_moneyModel-" + id;
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
                catch { }
            }
            return (GoldTradeNaming.Model.franchiser_money)objModel;
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
        public List<GoldTradeNaming.Model.franchiser_money> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            List<GoldTradeNaming.Model.franchiser_money> modelList = new List<GoldTradeNaming.Model.franchiser_money>();
            int rowsCount = ds.Tables[0].Rows.Count;
            if (rowsCount > 0)
            {
                GoldTradeNaming.Model.franchiser_money model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new GoldTradeNaming.Model.franchiser_money();
                    if (ds.Tables[0].Rows[n]["id"].ToString() != "")
                    {
                        model.id = int.Parse(ds.Tables[0].Rows[n]["id"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["franchiser_code"].ToString() != "")
                    {
                        model.franchiser_code = int.Parse(ds.Tables[0].Rows[n]["franchiser_code"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["franchiser_added_money"].ToString() != "")
                    {
                        model.franchiser_added_money = decimal.Parse(ds.Tables[0].Rows[n]["franchiser_added_money"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["added_time"].ToString() != "")
                    {
                        model.added_time = DateTime.Parse(ds.Tables[0].Rows[n]["added_time"].ToString());
                    }
                    model.ins_user = ds.Tables[0].Rows[n]["ins_user"].ToString();
                    if (ds.Tables[0].Rows[n]["ins_date"].ToString() != "")
                    {
                        model.ins_date = DateTime.Parse(ds.Tables[0].Rows[n]["ins_date"].ToString());
                    }
                    model.upd_user = ds.Tables[0].Rows[n]["upd_user"].ToString();
                    if (ds.Tables[0].Rows[n]["upd_date"].ToString() != "")
                    {
                        model.upd_date = DateTime.Parse(ds.Tables[0].Rows[n]["upd_date"].ToString());
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

