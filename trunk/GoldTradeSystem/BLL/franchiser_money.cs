using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using GoldTradeNaming.Model;
namespace GoldTradeNaming.BLL
{
    /// <summary>
    /// 业务逻辑类franchiser_money 的摘要说明。
    /// </summary>
    public class franchiser_money
    {
        private readonly GoldTradeNaming.DAL.franchiser_money dal = new GoldTradeNaming.DAL.franchiser_money();
        public franchiser_money()
        { }

        #region 自定义成员方法

        /// <summary>
        /// 查询数据
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
        /// 查询数据
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
        /// 查找数据库中该经销商编号是否存在
        /// </summary>
        /// <param name="fran_id"></param>
        /// <returns></returns>
        public bool fran_id_exists(int fran_id)
        {
            return dal.fran_id_exists(fran_id);
        }




         /// <summary>
        /// 用来同步更新franchiser_info表
        /// </summary>
        /// <param name="franchiser_code"></param>
        /// <param name="franchiser_balance_money"></param>
        /// <param name="tag">0：从总余额中加上入账金额   -1：从总余额中减去入账金额</param>
        /// <returns></returns>

        public int update_franchiser_info(int franchiser_code, decimal franchiser_balance_money, int tag)
        {
            return dal.update_franchiser_info(franchiser_code, franchiser_balance_money, tag);
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
        public bool Exists(int id)
        {
            return dal.Exists(id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(GoldTradeNaming.Model.franchiser_money model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(GoldTradeNaming.Model.franchiser_money model)
        {
          return  dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int  Delete(int id)
        {

          return  dal.Delete(id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public GoldTradeNaming.Model.franchiser_money GetModel(int id)
        {

            return dal.GetModel(id);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中。
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
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得数据列表
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

