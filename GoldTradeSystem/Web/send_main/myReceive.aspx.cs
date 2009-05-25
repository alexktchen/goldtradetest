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
using LTP.Common;
namespace GoldTradeNaming.Web.send_main
{
    public partial class myReceive : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["fran"] == null || Session["fran"].ToString() == "")
            {
                Session.Clear();
                Response.Clear();
                LTP.Common.MessageBox.ShowAndRedirect(this, "您没有权限或登录超时！\\n请重新登录或与管理员联系", "../User_Login/flogin.aspx");
                return;
            }
            if (!Page.IsPostBack)
            {
                StringBuilder sb = new StringBuilder();

                sb.Append(@"send_id in 
                        (select top 50 send_id from send_main order by send_id desc)"); 
                
                sb.Append(" and franchiser_info.franchiser_code = '" + Convert.ToString(Session["fran"]) + "'");
            
                SetBind(sb.ToString());
            }
        }

        protected void query_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            if (this.txtfranchiser_order_id.Text.Trim() != "")
            {
                sb.Append(" send_main.franchiser_order_id = '" + this.txtfranchiser_order_id.Text.Trim() + "'");
            }
            else sb.Append(" 1=1 ");

            sb.Append(" and franchiser_info.franchiser_code = '" + Convert.ToString(Session["fran"]) + "'");
            
            
            if (this.txtsend_id.Text.Trim() != "")
            {
                sb.Append(" and send_main.send_id = '" + this.txtsend_id.Text.Trim() + "'");
            }
            else sb.Append(" and 1=1 ");

            if (this.drpfranchiser_order_state.SelectedValue != "2")
            {
                sb.Append(" and send_main.send_state = '" + this.drpfranchiser_order_state.SelectedValue + "'");
            }
            else sb.Append(" and 1=1 ");

            SetBind(sb.ToString());
        }

        protected void reset_Click(object sender, EventArgs e)
        {
            this.txtfranchiser_order_id.Text = "";
           
            this.txtsend_id.Text = "";
            this.drpfranchiser_order_state.SelectedValue = "2";
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridView1.PageIndex = e.NewPageIndex;
            this.GridView1.DataSource = Session["datasrc"] as DataSet;
            this.GridView1.DataBind();
        }
    

        private void SetBind(string where)
        {
            GoldTradeNaming.BLL.send_main bll = new GoldTradeNaming.BLL.send_main();
            DataSet ds = bll.GetSendInfo(where);
            this.GridView1.DataSource = ds;
            this.GridView1.DataBind();
            Session["datasrc"] = ds;

        }
    }
}
