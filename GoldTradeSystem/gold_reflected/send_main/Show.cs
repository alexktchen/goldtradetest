namespace GoldTradeNaming.Web.send_main
{
    using GoldTradeNaming.BLL;
    using GoldTradeNaming.Model;
    using LTP.Common;
    using System;
    using System.Data;
    using System.Text;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public class Show : Page
    {
        protected HiddenField franid;
        protected GridView GridView1;
        protected Label Label1;
        protected Label Label2;
        protected Label Label4;
        protected Label lblMsg;
        protected HiddenField orderid;
        protected Button Query;
        protected TextBox txtFranID;
        protected TextBox txtOrderID;

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridView1.PageIndex = e.NewPageIndex;
            this.GridView1.DataSource = this.Session["grd_Data"] as DataSet;
            this.GridView1.DataBind();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((this.Session["admin"] == null) || (this.Session["admin"].ToString() == ""))
            {
                this.Session.Clear();
                base.Response.Clear();
                MessageBox.ShowAndRedirect(this, @"您没有权限或登录超时！\n请重新登录或与管理员联系", "../User_Login/AdminLogin.aspx");
            }
            else if (!(((this.Session["admin"] != null) && (this.Session["admin"].ToString() != "")) && CommBaseBLL.HasRight(Convert.ToInt32(this.Session["admin"]), Authority.Send.ToString())))
            {
                base.Response.Clear();
                base.Response.Write(@"<script defer>window.alert('您没有权限操作该功能！\n请重新登录或与管理员联系');history.back();</script>");
                base.Response.End();
            }
            else if (!this.Page.IsPostBack)
            {
                this.ShowInfo();
            }
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            (base.Master.FindControl("lblTitle") as Label).Text = "在线发货";
        }

        protected void Query_Click(object sender, EventArgs e)
        {
            this.franid.Value = this.txtFranID.Text;
            this.orderid.Value = this.txtOrderID.Text;
            this.ShowInfo();
        }

        private void ShowInfo()
        {
            StringBuilder strWhere = new StringBuilder();
            if (this.franid.Value.Trim() == "")
            {
                strWhere.Append("AND 1=1");
            }
            else
            {
                strWhere.Append("AND franchiser_order.franchiser_code = '");
                strWhere.Append(this.franid.Value.Trim());
                strWhere.Append("'");
            }
            if (this.orderid.Value.Trim() == "")
            {
                strWhere.Append(" AND 1=1");
            }
            else
            {
                strWhere.Append(" AND franchiser_order.franchiser_order_id  = '");
                strWhere.Append(this.orderid.Value.Trim());
                strWhere.Append("'");
            }
            try
            {
                DataSet ds = new GoldTradeNaming.BLL.send_main().GetOrderInfo(strWhere.ToString());
                if (((ds == null) || (ds.Tables.Count == 0)) || (ds.Tables[0].Rows.Count == 0))
                {
                    this.lblMsg.Text = "查无数据。";
                }
                this.Session["grd_Data"] = ds;
                this.GridView1.DataSource = this.Session["grd_Data"] as DataSet;
                this.GridView1.DataBind();
            }
            catch
            {
                MessageBox.Show(this, "查询订单出错！");
            }
        }
    }
}
