namespace GoldTradeNaming.DAL
{
    using GoldTradeNaming.Model;
    using Maticsoft.DBUtility;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Text;

    public class franchiser_order_desc
    {
        public int Add(GoldTradeNaming.Model.franchiser_order_desc model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into franchiser_order_desc(");
            strSql.Append("franchiser_order_id,product_id,product_spec_id,order_product_amount,product_received,product_unreceived,ins_user,ins_date,upd_user,upd_date)");
            strSql.Append(" values (");
            strSql.Append("@franchiser_order_id,@product_id,@product_spec_id,@order_product_amount,@product_received,@product_unreceived,@ins_user,@ins_date,@upd_user,@upd_date)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@franchiser_order_id", SqlDbType.Int, 4), new SqlParameter("@product_id", SqlDbType.Int, 4), new SqlParameter("@product_spec_id", SqlDbType.Int, 4), new SqlParameter("@order_product_amount", SqlDbType.Int, 4), new SqlParameter("@product_received", SqlDbType.Int, 4), new SqlParameter("@product_unreceived", SqlDbType.Int, 4), new SqlParameter("@ins_user", SqlDbType.NVarChar, 50), new SqlParameter("@ins_date", SqlDbType.SmallDateTime), new SqlParameter("@upd_user", SqlDbType.NVarChar, 50), new SqlParameter("@upd_date", SqlDbType.SmallDateTime) };
            parameters[0].Value = model.franchiser_order_id;
            parameters[1].Value = model.product_id;
            parameters[2].Value = model.product_spec_id;
            parameters[3].Value = model.order_product_amount;
            parameters[4].Value = model.product_received;
            parameters[5].Value = model.product_unreceived;
            parameters[6].Value = model.ins_user;
            parameters[7].Value = model.ins_date;
            parameters[8].Value = model.upd_user;
            parameters[9].Value = model.upd_date;
            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 1;
            }
            return Convert.ToInt32(obj);
        }

        public void Delete(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete franchiser_order_desc ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@id", SqlDbType.Int, 4) };
            parameters[0].Value = id;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from franchiser_order_desc");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@id", SqlDbType.Int, 4) };
            parameters[0].Value = id;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,franchiser_order_id,product_id,product_spec_id,order_product_amount,product_received,product_unreceived,ins_user,ins_date,upd_user,upd_date ");
            strSql.Append(" FROM franchiser_order_desc ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("id", "franchiser_order_desc");
        }

        public GoldTradeNaming.Model.franchiser_order_desc GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,franchiser_order_id,product_id,product_spec_id,order_product_amount,product_received,product_unreceived,ins_user,ins_date,upd_user,upd_date from franchiser_order_desc ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@id", SqlDbType.Int, 4) };
            parameters[0].Value = id;
            GoldTradeNaming.Model.franchiser_order_desc model = new GoldTradeNaming.Model.franchiser_order_desc();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["franchiser_order_id"].ToString() != "")
                {
                    model.franchiser_order_id = int.Parse(ds.Tables[0].Rows[0]["franchiser_order_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["product_id"].ToString() != "")
                {
                    model.product_id = int.Parse(ds.Tables[0].Rows[0]["product_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["product_spec_id"].ToString() != "")
                {
                    model.product_spec_id = int.Parse(ds.Tables[0].Rows[0]["product_spec_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["order_product_amount"].ToString() != "")
                {
                    model.order_product_amount = int.Parse(ds.Tables[0].Rows[0]["order_product_amount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["product_received"].ToString() != "")
                {
                    model.product_received = int.Parse(ds.Tables[0].Rows[0]["product_received"].ToString());
                }
                if (ds.Tables[0].Rows[0]["product_unreceived"].ToString() != "")
                {
                    model.product_unreceived = int.Parse(ds.Tables[0].Rows[0]["product_unreceived"].ToString());
                }
                model.ins_user = ds.Tables[0].Rows[0]["ins_user"].ToString();
                if (ds.Tables[0].Rows[0]["ins_date"].ToString() != "")
                {
                    model.ins_date = DateTime.Parse(ds.Tables[0].Rows[0]["ins_date"].ToString());
                }
                model.upd_user = ds.Tables[0].Rows[0]["upd_user"].ToString();
                if (ds.Tables[0].Rows[0]["upd_date"].ToString() != "")
                {
                    model.upd_date = DateTime.Parse(ds.Tables[0].Rows[0]["upd_date"].ToString());
                }
                return model;
            }
            return null;
        }

        public void Update(GoldTradeNaming.Model.franchiser_order_desc model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update franchiser_order_desc set ");
            strSql.Append("franchiser_order_id=@franchiser_order_id,");
            strSql.Append("product_id=@product_id,");
            strSql.Append("product_spec_id=@product_spec_id,");
            strSql.Append("order_product_amount=@order_product_amount,");
            strSql.Append("product_received=@product_received,");
            strSql.Append("product_unreceived=@product_unreceived,");
            strSql.Append("ins_user=@ins_user,");
            strSql.Append("ins_date=@ins_date,");
            strSql.Append("upd_user=@upd_user,");
            strSql.Append("upd_date=@upd_date");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@id", SqlDbType.Int, 4), new SqlParameter("@franchiser_order_id", SqlDbType.Int, 4), new SqlParameter("@product_id", SqlDbType.Int, 4), new SqlParameter("@product_spec_id", SqlDbType.Int, 4), new SqlParameter("@order_product_amount", SqlDbType.Int, 4), new SqlParameter("@product_received", SqlDbType.Int, 4), new SqlParameter("@product_unreceived", SqlDbType.Int, 4), new SqlParameter("@ins_user", SqlDbType.NVarChar, 50), new SqlParameter("@ins_date", SqlDbType.SmallDateTime), new SqlParameter("@upd_user", SqlDbType.NVarChar, 50), new SqlParameter("@upd_date", SqlDbType.SmallDateTime) };
            parameters[0].Value = model.id;
            parameters[1].Value = model.franchiser_order_id;
            parameters[2].Value = model.product_id;
            parameters[3].Value = model.product_spec_id;
            parameters[4].Value = model.order_product_amount;
            parameters[5].Value = model.product_received;
            parameters[6].Value = model.product_unreceived;
            parameters[7].Value = model.ins_user;
            parameters[8].Value = model.ins_date;
            parameters[9].Value = model.upd_user;
            parameters[10].Value = model.upd_date;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
    }
}
