namespace GoldTradeNaming.Web.franchiser_order
{
    using GoldTradeNaming.BLL;
    using GoldTradeNaming.Model;
    using LTP.Common;
    using System;
    using System.Data;
    using System.Text;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public class Modify : Page
    {
        protected DropDownList drpfranchiser_order_state;
        protected GridView GridView1;
        protected Label lblMsg;
        protected Button query;
        protected Button reset;
        protected TextBox txtfranchiser_order_id;
        protected TextBox txtFranID;

        private bool checkright()
        {
            bool rtn = false;
            switch (base.Request.Params["type"].ToString().Trim())
            {
                case "0":
                    rtn = CommBaseBLL.HasRight(Convert.ToInt32(this.Session["admin"]), Authority.ViewOrder.ToString());
                    break;

                case "1":
                    rtn = CommBaseBLL.HasRight(Convert.ToInt32(this.Session["admin"]), Authority.ConOrder.ToString());
                    break;
            }
            return rtn;
        }

        private void GetRecentData()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("franchiser_order_id in \r\n                        (select top 50 franchiser_order_id from franchiser_order order by franchiser_order_id desc)");
            if (this.drpfranchiser_order_state.SelectedIndex != 3)
            {
                sb.Append("AND franchiser_order_state='" + this.drpfranchiser_order_state.SelectedIndex.ToString() + "'");
            }
            DataSet ds = new GoldTradeNaming.BLL.franchiser_order().GetList(sb.ToString());
            if (((ds == null) || (ds.Tables.Count == 0)) || (ds.Tables[0].Rows.Count == 0))
            {
                this.lblMsg.Text = "暂无数据。";
            }
            else
            {
                this.lblMsg.Text = "";
            }
            this.Session["datasrc"] = ds;
            this.GridView1.DataSource = this.Session["datasrc"] as DataSet;
            this.GridView1.DataBind();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridView1.PageIndex = e.NewPageIndex;
            this.GridView1.DataSource = this.Session["datasrc"] as DataSet;
            this.GridView1.DataBind();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "cmdConfirm")
            {
                try
                {
                    GridViewRow myRow = (GridViewRow) ((Button) e.CommandSource).Parent.Parent;
                    int rowindex = myRow.RowIndex;
                    GoldTradeNaming.BLL.franchiser_order bll = new GoldTradeNaming.BLL.franchiser_order();
                    string orderid = "";
                    orderid = ((HyperLink) this.GridView1.Rows[rowindex].Cells[0].Controls[0]).Text;
                    if (bll.ConfirmOrder(Convert.ToInt32(orderid), this.Session["admin"] as string))
                    {
                        MessageBox.ShowAndRedirect(this, "确认成功！", "Modify.aspx?type=1");
                    }
                }
                catch
                {
                }
            }
            if (e.CommandName == "cmdModify")
            {
                try
                {
                }
                catch
                {
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((this.Session["admin"] == null) || (this.Session["admin"].ToString() == ""))
            {
                this.Session.Clear();
                base.Response.Clear();
                MessageBox.ShowAndRedirect(this, @"您没有权限或登录超时！\n请重新登录或与管理员联系", "../User_Login/AdminLogin.aspx");
            }
            else if (!(((this.Session["admin"] != null) && (this.Session["admin"].ToString() != "")) && this.checkright()))
            {
                base.Response.Clear();
                base.Response.Write(@"<script defer>window.alert('您没有权限操作该功能！\n请重新登录或与管理员联系');history.back();</script>");
                base.Response.End();
            }
            else if (!this.Page.IsPostBack)
            {
                this.ViewState["oprType"] = base.Request.Params["type"].ToString();
                this.ShowInfo();
                this.GetRecentData();
            }
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            (base.Master.FindControl("lblTitle") as Label).Text = "订单管理";
        }

        protected void query_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            if (this.txtFranID.Text.Trim() == "")
            {
                sb.Append(" 1=1 ");
            }
            else
            {
                sb.Append(" franchiser_code='" + Convert.ToString(this.txtFranID.Text.Trim()) + "'");
            }
            if (this.txtfranchiser_order_id.Text.Trim() == "")
            {
                sb.Append(" AND 1=1 ");
            }
            else
            {
                sb.Append(" AND franchiser_order_id = '");
                sb.Append(this.txtfranchiser_order_id.Text.Trim());
                sb.Append("'");
            }
            if (this.drpfranchiser_order_state.SelectedIndex != 3)
            {
                sb.Append("AND franchiser_order_state='" + this.drpfranchiser_order_state.SelectedIndex.ToString() + "'");
            }
            DataSet ds = new GoldTradeNaming.BLL.franchiser_order().GetList(sb.ToString());
            if (((ds == null) || (ds.Tables.Count == 0)) || (ds.Tables[0].Rows.Count == 0))
            {
                this.lblMsg.Text = "查无数据。";
            }
            else
            {
                this.lblMsg.Text = "";
            }
            this.Session["datasrc"] = ds;
            this.GridView1.DataSource = this.Session["datasrc"] as DataSet;
            this.GridView1.DataBind();
        }

        protected void reset_Click(object sender, EventArgs e)
        {
            this.txtfranchiser_order_id.Text = "";
            this.txtFranID.Text = "";
        }

        private void ShowInfo()
        {
            if (this.ViewState["oprType"].ToString() == "0")
            {
                this.GridView1.Columns[11].Visible = false;
                this.GridView1.Columns[12].Visible = false;
            }
            if (this.ViewState["oprType"].ToString() == "1")
            {
                this.drpfranchiser_order_state.SelectedIndex = 0;
                this.drpfranchiser_order_state.Enabled = false;
                this.GridView1.Columns[12].Visible = false;
            }
            if (this.ViewState["oprType"].ToString() == "2")
            {
                this.drpfranchiser_order_state.SelectedIndex = 0;
                this.drpfranchiser_order_state.Enabled = false;
                this.GridView1.Columns[11].Visible = false;
            }
        }
    }
}
