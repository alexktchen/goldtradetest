using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//请先添加引用
namespace GoldTradeNaming.DAL
{
    /// <summary>
    /// 数据访问类franchiser_info。
    /// </summary>
    public class franchiser_info
    {
        public franchiser_info()
        {
        }
        #region  成员方法

        /// <summary>
        /// 是否存在该供应商名字记录 新增时 add by yuxiaowei
        /// </summary>
        public bool Exists(string franchiser_name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from franchiser_info");
            strSql.Append(" where franchiser_name=@franchiser_name ");
            SqlParameter[] parameters = {
					new SqlParameter("@franchiser_name", SqlDbType.NVarChar,50)};
            parameters[0].Value = franchiser_name;

            return DbHelperSQL.Exists(strSql.ToString(),parameters);
        }
        /// <summary>
        /// 是否存在该供应商名字记录 修改时 add by yuxiaowei
        /// </summary>
        public bool Exists(int franchiser_code,string franchiser_name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from franchiser_info");
            strSql.Append(" where franchiser_code!=@franchiser_code ");
            strSql.Append(" and  franchiser_name=@franchiser_name ");
            SqlParameter[] parameters = {
					new SqlParameter("@franchiser_code", SqlDbType.SmallInt),
                    new SqlParameter("@franchiser_name", SqlDbType.NVarChar,50)};
            parameters[0].Value = franchiser_code;
            parameters[1].Value = franchiser_name;
            return DbHelperSQL.Exists(strSql.ToString(),parameters);
        }

        /// <summary>
        /// 是否存在该IA100GUID记录 add by yuxiaowei
        /// </summary>
        public bool Exists(Guid guid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from franchiser_info");
            strSql.Append(" where IA100GUID=@IA100GUID ");
            SqlParameter[] parameters = {
					new SqlParameter("@IA100GUID", SqlDbType.UniqueIdentifier)};
            parameters[0].Value = guid;

            return DbHelperSQL.Exists(strSql.ToString(),parameters);
        }

        /// <summary>
        /// 是否存在该IA100GUID记录 修改时 add by yuxiaowei
        /// </summary>
        public bool Exists(int franchiser_code,Guid guid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from franchiser_info");
            strSql.Append(" where IA100GUID=@IA100GUID ");
            strSql.Append(" and franchiser_code!=@franchiser_code ");
            SqlParameter[] parameters = {
					new SqlParameter("@IA100GUID", SqlDbType.UniqueIdentifier),
                   new SqlParameter("@franchiser_code", SqlDbType.SmallInt)};
            parameters[0].Value = guid;
            parameters[1].Value = franchiser_code;
            return DbHelperSQL.Exists(strSql.ToString(),parameters);
        }
        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("franchiser_code","franchiser_info");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int franchiser_code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from franchiser_info");
            strSql.Append(" where franchiser_code=@franchiser_code ");
            SqlParameter[] parameters = {
					new SqlParameter("@franchiser_code", SqlDbType.SmallInt)};
            parameters[0].Value = franchiser_code;

            return DbHelperSQL.Exists(strSql.ToString(),parameters);
        }

        /// <summary>
        /// 禁用原认证锁ID by yuxiaowei
        /// </summary>
        /// <param name="IA100GUID"></param>
        /// <returns></returns>
        public int DisableIA(Guid IA100GUID,string reason)
        {
            string strSql = string.Format(@"update goldtrade_IA100 set IA100State='1',StateChangeReason='{1}' where IA100GUID='{0}'",IA100GUID,reason);
            return DbHelperSQL.ExecuteSql(strSql);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(GoldTradeNaming.Model.franchiser_info model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into franchiser_info(");
            strSql.Append("franchiser_name,franchiser_balance_money,franchiser_asure_money,franchiser_tel,franchiser_cellphone,franchiser_address,ins_user,upd_user,IA100GUID)");
            strSql.Append(" values (");
            strSql.Append("@franchiser_name,@franchiser_balance_money,@franchiser_asure_money,@franchiser_tel,@franchiser_cellphone,@franchiser_address,@ins_user,@upd_user,@IA100GUID)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@franchiser_name", SqlDbType.NVarChar,50),
					new SqlParameter("@franchiser_balance_money", SqlDbType.Money,8),
					new SqlParameter("@franchiser_asure_money", SqlDbType.Money,8),
					new SqlParameter("@franchiser_tel", SqlDbType.NVarChar,50),
					new SqlParameter("@franchiser_cellphone", SqlDbType.NVarChar,50),
					new SqlParameter("@franchiser_address", SqlDbType.NVarChar,50),
					new SqlParameter("@ins_user", SqlDbType.NVarChar,50),
					//new SqlParameter("@ins_date", SqlDbType.SmallDateTime),
					new SqlParameter("@upd_user", SqlDbType.NVarChar,50),
					//new SqlParameter("@upd_date", SqlDbType.SmallDateTime),
					new SqlParameter("@IA100GUID", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = model.franchiser_name;
            parameters[1].Value = model.franchiser_asure_money;  //新增 账面余额等于担保款
            parameters[2].Value = model.franchiser_asure_money;
            parameters[3].Value = model.franchiser_tel;
            parameters[4].Value = model.franchiser_cellphone;
            parameters[5].Value = model.franchiser_address;
            parameters[6].Value = model.ins_user;
            //parameters[7].Value = model.ins_date;
            parameters[7].Value = model.upd_user;
            //parameters[9].Value = model.upd_date;
            parameters[8].Value = model.IA100GUID;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
            if(obj == null)
            {
                return 1;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(GoldTradeNaming.Model.franchiser_info model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update franchiser_info set ");
            strSql.Append("franchiser_name=@franchiser_name,");
            strSql.Append("franchiser_balance_money=franchiser_balance_money+@franchiser_asure_money-franchiser_asure_money,");
            strSql.Append("franchiser_asure_money=@franchiser_asure_money,");
            strSql.Append("franchiser_tel=@franchiser_tel,");
            strSql.Append("franchiser_cellphone=@franchiser_cellphone,");
            strSql.Append("franchiser_address=@franchiser_address,");
            //strSql.Append("ins_user=@ins_user,");
            //strSql.Append("ins_date=@ins_date,");
            strSql.Append("upd_user=@upd_user,");
            strSql.Append("upd_date=getdate(),");
            strSql.Append("IA100GUID=@IA100GUID");
            strSql.Append(" where franchiser_code=@franchiser_code ");
            SqlParameter[] parameters = {
					new SqlParameter("@franchiser_code", SqlDbType.SmallInt,2),
					new SqlParameter("@franchiser_name", SqlDbType.NVarChar,50),
					new SqlParameter("@franchiser_balance_money", SqlDbType.Money,8),
					new SqlParameter("@franchiser_asure_money", SqlDbType.Money,8),
					new SqlParameter("@franchiser_tel", SqlDbType.NVarChar,50),
					new SqlParameter("@franchiser_cellphone", SqlDbType.NVarChar,50),
					new SqlParameter("@franchiser_address", SqlDbType.NVarChar,50),
					//new SqlParameter("@ins_user", SqlDbType.NVarChar,50),
					//new SqlParameter("@ins_date", SqlDbType.SmallDateTime),
					new SqlParameter("@upd_user", SqlDbType.NVarChar,50),
					//new SqlParameter("@upd_date", SqlDbType.SmallDateTime),
					new SqlParameter("@IA100GUID", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = model.franchiser_code;
            parameters[1].Value = model.franchiser_name;
            // parameters[2].Value = model.franchiser_balance_money;//franchiser_balance_money=franchiser_balance_money+400-franchiser_asure_money
            parameters[3].Value = model.franchiser_asure_money;
            parameters[4].Value = model.franchiser_tel;
            parameters[5].Value = model.franchiser_cellphone;
            parameters[6].Value = model.franchiser_address;
            //parameters[7].Value = model.ins_user;
            //parameters[8].Value = model.ins_date;
            parameters[7].Value = model.upd_user;
            //parameters[10].Value = model.upd_date;
            parameters[8].Value = model.IA100GUID;

            DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int franchiser_code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete franchiser_info ");
            strSql.Append(" where franchiser_code=@franchiser_code ");
            SqlParameter[] parameters = {
					new SqlParameter("@franchiser_code", SqlDbType.SmallInt)};
            parameters[0].Value = franchiser_code;

            DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public GoldTradeNaming.Model.franchiser_info GetModel(int franchiser_code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 franchiser_code,franchiser_name,franchiser_balance_money,franchiser_asure_money,franchiser_tel,franchiser_cellphone,franchiser_address,ins_user,ins_date,upd_user,upd_date,IA100GUID from franchiser_info ");
            strSql.Append(" where franchiser_code=@franchiser_code ");
            SqlParameter[] parameters = {
					new SqlParameter("@franchiser_code", SqlDbType.SmallInt)};
            parameters[0].Value = franchiser_code;

            GoldTradeNaming.Model.franchiser_info model = new GoldTradeNaming.Model.franchiser_info();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(),parameters);
            if(ds.Tables[0].Rows.Count > 0)
            {
                if(ds.Tables[0].Rows[0]["franchiser_code"].ToString() != "")
                {
                    model.franchiser_code = int.Parse(ds.Tables[0].Rows[0]["franchiser_code"].ToString());
                }
                model.franchiser_name = ds.Tables[0].Rows[0]["franchiser_name"].ToString();
                if(ds.Tables[0].Rows[0]["franchiser_balance_money"].ToString() != "")
                {
                    model.franchiser_balance_money = decimal.Parse(ds.Tables[0].Rows[0]["franchiser_balance_money"].ToString());
                }
                if(ds.Tables[0].Rows[0]["franchiser_asure_money"].ToString() != "")
                {
                    model.franchiser_asure_money = decimal.Parse(ds.Tables[0].Rows[0]["franchiser_asure_money"].ToString());
                }
                model.franchiser_tel = ds.Tables[0].Rows[0]["franchiser_tel"].ToString();
                model.franchiser_cellphone = ds.Tables[0].Rows[0]["franchiser_cellphone"].ToString();
                model.franchiser_address = ds.Tables[0].Rows[0]["franchiser_address"].ToString();
                model.ins_user = ds.Tables[0].Rows[0]["ins_user"].ToString();
                if(ds.Tables[0].Rows[0]["ins_date"].ToString() != "")
                {
                    model.ins_date = DateTime.Parse(ds.Tables[0].Rows[0]["ins_date"].ToString());
                }
                model.upd_user = ds.Tables[0].Rows[0]["upd_user"].ToString();
                if(ds.Tables[0].Rows[0]["upd_date"].ToString() != "")
                {
                    model.upd_date = DateTime.Parse(ds.Tables[0].Rows[0]["upd_date"].ToString());
                }
                if(ds.Tables[0].Rows[0]["IA100GUID"].ToString() != "")
                {
                    model.IA100GUID = new Guid(ds.Tables[0].Rows[0]["IA100GUID"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  franchiser_code,franchiser_name,franchiser_balance_money,franchiser_asure_money,franchiser_tel,franchiser_cellphone,franchiser_address,ins_user,ins_date,upd_user,upd_date,IA100GUID ");
            strSql.Append(" FROM franchiser_info ");
            if(strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 查出经销商信息（包含交易，订单，库存等）
        /// </summary>
        /// <returns></returns>
        public DataSet GetFranAllInfo(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select  franchiser_code,franchiser_name,franchiser_balance_money,
                        franchiser_asure_money,franchiser_tel,franchiser_cellphone,franchiser_address,
                        ins_user,ins_date,upd_user,upd_date,IA100GUID
                        ,
                         TotalMoney = (SELECT SUM(franchiser_added_money)  FROM franchiser_money
                         where franchiser_money.franchiser_code=franchiser_info.franchiser_code )
                        ,
                        OrderMoney = (select SUM(franchiser_order.franchiser_order_amount_money)FROM franchiser_order 
                        where franchiser_order.franchiser_code=franchiser_info.franchiser_code )
                        ,          
                        TradeMoney = (select SUM(trade_total_money) from franchiser_trade 
                        where franchiser_trade.franchiser_code=franchiser_info.franchiser_code 
                        )
                        FROM franchiser_info");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }

            return DbHelperSQL.Query(strSql.ToString());
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "franchiser_info";
            parameters[1].Value = "ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  成员方法
    }
}

