namespace GoldTradeNaming.Web.send_main
{
    using GoldTradeNaming.BLL;
    using LTP.Common;
    using System;
    using System.Data;
    using System.Text;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public class myReceive : Page
    {
        protected DropDownList drpfranchiser_order_state;
        protected GridView GridView1;
        protected Label lblMsg;
        protected Button query;
        protected Button reset;
        protected TextBox txtfranchiser_order_id;
        protected TextBox txtsend_id;

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridView1.PageIndex = e.NewPageIndex;
            this.GridView1.DataSource = this.Session["datasrc"] as DataSet;
            this.GridView1.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((this.Session["fran"] == null) || (this.Session["fran"].ToString() == ""))
            {
                this.Session.Clear();
                base.Response.Clear();
                MessageBox.ShowAndRedirect(this, @"您没有权限或登录超时！\n请重新登录或与管理员联系", "../User_Login/flogin.aspx");
            }
            else if (!this.Page.IsPostBack)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("send_id in \r\n                        (select top 50 send_id from send_main order by send_id desc)");
                sb.Append(" and franchiser_info.franchiser_code = '" + Convert.ToString(this.Session["fran"]) + "'");
                this.SetBind(sb.ToString());
            }
        }

        protected void query_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            if (this.txtfranchiser_order_id.Text.Trim() != "")
            {
                sb.Append(" send_main.franchiser_order_id = '" + this.txtfranchiser_order_id.Text.Trim() + "'");
            }
            else
            {
                sb.Append(" 1=1 ");
            }
            sb.Append(" and franchiser_info.franchiser_code = '" + Convert.ToString(this.Session["fran"]) + "'");
            if (this.txtsend_id.Text.Trim() != "")
            {
                sb.Append(" and send_main.send_id = '" + this.txtsend_id.Text.Trim() + "'");
            }
            else
            {
                sb.Append(" and 1=1 ");
            }
            if (this.drpfranchiser_order_state.SelectedValue != "2")
            {
                sb.Append(" and send_main.send_state = '" + this.drpfranchiser_order_state.SelectedValue + "'");
            }
            else
            {
                sb.Append(" and 1=1 ");
            }
            this.SetBind(sb.ToString());
        }

        protected void reset_Click(object sender, EventArgs e)
        {
            this.txtfranchiser_order_id.Text = "";
            this.txtsend_id.Text = "";
            this.drpfranchiser_order_state.SelectedValue = "2";
        }

        private void SetBind(string where)
        {
            DataSet ds = new send_main().GetSendInfo(where);
            this.GridView1.DataSource = ds;
            this.GridView1.DataBind();
            this.Session["datasrc"] = ds;
        }
    }
}
