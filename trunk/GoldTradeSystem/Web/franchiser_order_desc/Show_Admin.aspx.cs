﻿using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using System.Text;
using GoldTradeNaming.BLL;
namespace GoldTradeNaming.Web.franchiser_order_desc
{
    public partial class Show_Amdin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] == null || Session["admin"].ToString() == "")
            {
                Session.Clear();
                Response.Clear();
                LTP.Common.MessageBox.ShowAndRedirect(this, "您没有权限或登录超时！\\n请重新登录或与管理员联系", "../User_Login/AdminLogin.aspx");
                return;
            }

            if (Session["admin"] == null || Session["admin"].ToString() == ""
                    || !GoldTradeNaming.BLL.CommBaseBLL.HasRight(Convert.ToInt32(Session["admin"]), Model.Authority.ViewOrder.ToString()))
            {
                Response.Clear();
                Response.Write("<script defer>window.alert('" + "您没有权限操作该功能！\\n请重新登录或与管理员联系" + "');history.back();</script>");
                Response.End();
                return;
            }

            if (!Page.IsPostBack)
            {
                if (Request.QueryString["id"].ToString() != "")
                    ShowInfo(Request.QueryString["id"].ToString());
            }
        }

        private void ShowInfo(string id)
        {
            string orderid = id;
            StringBuilder strWhere = new StringBuilder();
            strWhere.Append(" franchiser_order_id = '");
            strWhere.Append(orderid + "'");
            GoldTradeNaming.BLL.send_main orderdscBll = new GoldTradeNaming.BLL.send_main();
            DataSet ds = orderdscBll.GetOrderedProductList(strWhere.ToString());
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                string prodType = CommBaseBLL.GetProductTypeById(ds.Tables[0].Rows[0]["product_id"].ToString().Trim());
                if (prodType == "1") GridView2.Columns[1].Visible = false;
            }
            GridView2.DataSource = ds;
            GridView2.DataBind();
        }
    }
}