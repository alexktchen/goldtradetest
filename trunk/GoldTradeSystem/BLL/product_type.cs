using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using GoldTradeNaming.Model;
namespace GoldTradeNaming.BLL
{
    /// <summary>
    /// 业务逻辑类product_type 的摘要说明。
    /// </summary>
    public class product_type
    {
        private readonly GoldTradeNaming.DAL.product_type dal = new GoldTradeNaming.DAL.product_type();




        public product_type()
        { }

        #region 自定义成员方法


        ///<summary>
        ///根据产品类别ID，产品类别名称，产品规格，产品状态进行查询
        ///</summary>
        ///<param>
        /// type_id:产品类别ID
        /// type_name:产品类别
        /// type_kind:产品类别K数
        /// type_status:产品状态
        /// </param>
        /// 提供模糊查询
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
        /// 判断product_type_id是否存在于product_type表中，存在返回对应的name，否则返回空
        /// </summary>
        public string check_id(string product_type_id) {

            return dal.check_id(product_type_id);
        
        }


        ///<summary>
        /// 判断product_name是否存在誉product_type表中，存在返回对应的ID，否则返回空
        /// </summary>
        /// 

        public string check_name(string product_type_name)
        {

            return dal.check_name(product_type_name);
        }



        ///<sumary>
        /// product_name下拉框
        /// </sumary>

        public DataSet getAll(string type)
        {

            return dal.getAll(type);
        }

          /// <summary>
        /// 返回数据库中白银的记录
        /// </summary>
        /// <returns></returns>
        public DataSet getSilver() {
            return dal.getSilver();
        }


        #endregion




        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return dal.GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int product_type_id, int product_spec_weight)
        {
            return dal.Exists(product_type_id, product_spec_weight);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(GoldTradeNaming.Model.product_type model)
        {
           return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
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
        /// 删除一条数据
        /// </summary>
        public void Delete(int product_type_id, int product_spec_weight)
        {

            dal.Delete(product_type_id, product_spec_weight);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public GoldTradeNaming.Model.product_type GetModel(int product_type_id, int product_spec_weight)
        {

            return dal.GetModel(product_type_id, product_spec_weight);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中。
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
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得数据列表
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
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  成员方法
    }
}

