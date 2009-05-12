using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using GoldTradeNaming.Model;
using System.Collections;
namespace GoldTradeNaming.BLL
{
    /// <summary>
    /// 业务逻辑类sys_admin_authority 的摘要说明。
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
        #region  成员方法

        /// <summary>
        /// 更新管理员权限 by yuxiaowei
        /// </summary>
        /// <param name="sys_admin_id"></param>
        /// <param name="sModule"></param>
        public void Update(int sys_admin_id,ArrayList sModule)
        {
             dal.Update(sys_admin_id,sModule);
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
        public bool Exists(int sys_admin_id,string sys_module)
        {
            return dal.Exists(sys_admin_id,sys_module);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(GoldTradeNaming.Model.sys_admin_authority model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(GoldTradeNaming.Model.sys_admin_authority model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int sys_admin_id,string sys_module)
        {

            dal.Delete(sys_admin_id,sys_module);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public GoldTradeNaming.Model.sys_admin_authority GetModel(int sys_admin_id,string sys_module)
        {

            return dal.GetModel(sys_admin_id,sys_module);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中。
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
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得数据列表
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

