using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using GoldTradeNaming.Model;
namespace GoldTradeNaming.BLL
{
    /// <summary>
    /// 业务逻辑类franchiser_info 的摘要说明。
    /// </summary>
    public class franchiser_info
    {
        private readonly GoldTradeNaming.DAL.franchiser_info dal = new GoldTradeNaming.DAL.franchiser_info();
        public franchiser_info()
        {
        }
        #region  成员方法

        /// <summary>
        /// 是否存在该供应商名字记录 新增时 add by yuxiaowei
        /// </summary>
        public bool Exists(string franchiser_name)
        {
            return dal.Exists(franchiser_name);
        }
        /// <summary>
        /// 是否存在该供应商名字记录(除该经销商编号)外 修改时 add by yuxiaowei
        /// </summary>
        /// <param name="franchiser_code"></param>
        /// <param name="franchiser_name"></param>
        /// <returns></returns>
        public bool Exists(int franchiser_code,string franchiser_name)
        {
            return dal.Exists(franchiser_code,franchiser_name);
        }

        /// <summary>
        /// 禁用原认证锁ID by yuxiaowei
        /// </summary>
        /// <param name="IA100GUID"></param>
        /// <param name="reason"></param>
        /// <returns></returns>
        public int DisableIA(Guid IA100GUID,string reason)
        {
            return dal.DisableIA(IA100GUID,reason);
        }

        /// <summary>
        /// 是否存在该IA100GUID记录 修改时 add by yuxiaowei
        /// </summary>
        public bool Exists(int franchiser_code,Guid guid)
        {
            return dal.Exists(franchiser_code,guid);
        }
        ///

        /// <summary>
        /// 是否存在该IA100GUID记录 add by yuxiaowei
        /// </summary>
        public bool Exists(Guid guid)
        {
            return dal.Exists(guid);
        }
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
        public bool Exists(int franchiser_code)
        {
            return dal.Exists(franchiser_code);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(GoldTradeNaming.Model.franchiser_info model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(GoldTradeNaming.Model.franchiser_info model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int franchiser_code)
        {

            dal.Delete(franchiser_code);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public GoldTradeNaming.Model.franchiser_info GetModel(int franchiser_code)
        {

            return dal.GetModel(franchiser_code);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中。
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
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得数据列表
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

