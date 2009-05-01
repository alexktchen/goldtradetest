using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using GoldTradeNaming.Model;
namespace GoldTradeNaming.BLL
{
    /// <summary>
    /// ҵ���߼���product_type ��ժҪ˵����
    /// </summary>
    public class product_type
    {
        private readonly GoldTradeNaming.DAL.product_type dal = new GoldTradeNaming.DAL.product_type();




        public product_type()
        { }

        #region �Զ����Ա����


        ///<summary>
        ///���ݲ�Ʒ���ID����Ʒ������ƣ���Ʒ��񣬲�Ʒ״̬���в�ѯ
        ///</summary>
        ///<param>
        /// type_id:��Ʒ���ID
        /// type_name:��Ʒ���
        /// type_kind:��Ʒ���K��
        /// type_status:��Ʒ״̬
        /// </param>
        /// �ṩģ����ѯ
        /// 
        public DataSet queryAction(string type_id, string type_name, string type_kind, string type_status,string order_add_price,string trade_add_price,string type)
        {
            DataSet ds;
            try
            {
                ds = dal.queryAction(type_id, type_name, type_kind, type_status,order_add_price,trade_add_price,type);
            }
            catch
            {
                throw;
            }
            return ds;
        }


        ///<summary>
        /// �ж�product_type_id�Ƿ������product_type���У����ڷ��ض�Ӧ��name�����򷵻ؿ�
        /// </summary>
        public string check_id(string product_type_id) {

            return dal.check_id(product_type_id);
        
        }


        ///<summary>
        /// �ж�product_name�Ƿ������product_type���У����ڷ��ض�Ӧ��ID�����򷵻ؿ�
        /// </summary>
        /// 

        public string check_name(string product_type_name)
        {

            return dal.check_name(product_type_name);
        }



        ///<sumary>
        /// product_name������
        /// </sumary>

        public DataSet getAll(string type)
        {

            return dal.getAll(type);
        }

          /// <summary>
        /// �������ݿ��а����ļ�¼
        /// </summary>
        /// <returns></returns>
        public DataSet getSilver() {
            return dal.getSilver();
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
        public bool Exists(int product_type_id, int product_spec_weight)
        {
            return dal.Exists(product_type_id, product_spec_weight);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(GoldTradeNaming.Model.product_type model)
        {
           return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public void Update(GoldTradeNaming.Model.product_type model)
        {
           
            try
            {
                 dal.Update(model);
            }
            catch
            {
                throw;
            }
           
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public void Delete(int product_type_id, int product_spec_weight)
        {

            dal.Delete(product_type_id, product_spec_weight);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public GoldTradeNaming.Model.product_type GetModel(int product_type_id, int product_spec_weight)
        {

            return dal.GetModel(product_type_id, product_spec_weight);
        }

        /// <summary>
        /// �õ�һ������ʵ�壬�ӻ����С�
        /// </summary>
        public GoldTradeNaming.Model.product_type GetModelByCache(int product_type_id, int product_spec_weight)
        {

            string CacheKey = "product_typeModel-" + product_type_id + product_spec_weight;
            object objModel = LTP.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(product_type_id, product_spec_weight);
                    if (objModel != null)
                    {
                        int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
                        LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (GoldTradeNaming.Model.product_type)objModel;
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
        public List<GoldTradeNaming.Model.product_type> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            List<GoldTradeNaming.Model.product_type> modelList = new List<GoldTradeNaming.Model.product_type>();
            int rowsCount = ds.Tables[0].Rows.Count;
            if (rowsCount > 0)
            {
                GoldTradeNaming.Model.product_type model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new GoldTradeNaming.Model.product_type();
                    if (ds.Tables[0].Rows[n]["product_type_id"].ToString() != "")
                    {
                        model.product_type_id = int.Parse(ds.Tables[0].Rows[n]["product_type_id"].ToString());
                    }
                    model.product_type_name = ds.Tables[0].Rows[n]["product_type_name"].ToString();
                    if (ds.Tables[0].Rows[n]["product_spec_weight"].ToString() != "")
                    {
                        model.product_spec_weight = int.Parse(ds.Tables[0].Rows[n]["product_spec_weight"].ToString());
                    }
                    model.product_state = ds.Tables[0].Rows[n]["product_state"].ToString();
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

