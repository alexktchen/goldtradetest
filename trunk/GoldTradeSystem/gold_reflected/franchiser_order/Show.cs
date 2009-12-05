namespace GoldTradeNaming.Web.franchiser_order
{
    using AjaxControlToolkit;
    using GoldTradeNaming.BLL;
    using LTP.Common;
    using System;
    using System.Data;
    using System.Text;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public class Show : Page
    {
        protected CalendarExtender CalendarExtender1;
        protected DropDownList drpfranchiser_order_state;
        protected CalendarExtender dtTo_CalendarExtender;
        protected GridView GridView1;
        protected Label Label1;
        protected Label lblMsg;
        protected Button query;
        protected Button reset;
        protected ScriptManager ScriptManager1;
        protected TextBox txtfranchiser_order_id;
        protected TextBox txtfranchiser_order_time_a;
        protected TextBox txtfranchiser_order_time_b;

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridView1.PageIndex = e.NewPageIndex;
            this.GridView1.DataSource = this.Session["datasrc"] as DataSet;
            this.GridView1.DataBind();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int rowIndex = this.GridView1.SelectedIndex;
            string orderid = this.GridView1.Rows[rowIndex].Cells[0].Text;
            StringBuilder strWhere = new StringBuilder();
            strWhere.Append(" franchiser_order_id = '");
            strWhere.Append(orderid + "'");
            DataSet ds = new send_main().GetOrderedProductList(strWhere.ToString());
            this.GridView1.DataSource = ds;
            this.GridView1.DataBind();
        }

        private void LoadData()
        {
            DataSet ds = new franchiser_order().GetLatestList(Convert.ToInt32(this.Session["fran"]));
            if (((ds == null) || (ds.Tables.Count == 0)) || (ds.Tables[0].Rows.Count == 0))
            {
                this.lblMsg.Text = "暂无数据。";
            }
            this.Session["datasrc"] = ds;
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
                this.LoadData();
            }
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
        }

        protected void query_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" franchiser_code='" + Convert.ToString(this.Session["fran"]) + "'");
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
            sb.Append(" AND franchiser_order_time between '");
            if (this.txtfranchiser_order_time_a.Text.Trim() != "")
            {
                DateTime dta = DateTime.MinValue;
                try
                {
                    dta = Convert.ToDateTime(this.txtfranchiser_order_time_a.Text.Trim());
                }
                catch
                {
                    dta = DateTime.Now.AddMonths(-1);
                }
                sb.Append(dta.ToString("yyyy/MM/dd") + "'");
            }
            else
            {
                sb.Append(DateTime.Now.AddMonths(-1).ToString("yyyy/MM/dd") + "'");
            }
            sb.Append(" and '");
            if (this.txtfranchiser_order_time_b.Text.Trim() != "")
            {
                DateTime dtb = DateTime.MinValue;
                try
                {
                    dtb = Convert.ToDateTime(this.txtfranchiser_order_time_b.Text.Trim());
                }
                catch
                {
                    dtb = DateTime.Now;
                }
                sb.Append(dtb.AddDays(1.0).ToString("yyyy/MM/dd") + "'");
            }
            else
            {
                sb.Append(DateTime.Now.AddDays(1.0).ToString("yyyy/MM/dd") + "'");
            }
            if (this.drpfranchiser_order_state.SelectedIndex != 3)
            {
                sb.Append("AND franchiser_order_state='" + this.drpfranchiser_order_state.SelectedIndex.ToString() + "'");
            }
            DataSet ds = new franchiser_order().GetList(sb.ToString());
            if (((ds == null) || (ds.Tables.Count == 0)) || (ds.Tables[0].Rows.Count == 0))
            {
                this.lblMsg.Text = "查无数据。";
            }
            this.Session["datasrc"] = ds;
            this.GridView1.DataSource = this.Session["datasrc"] as DataSet;
            this.GridView1.DataBind();
        }

        protected void reset_Click(object sender, EventArgs e)
        {
            this.txtfranchiser_order_id.Text = "";
            this.txtfranchiser_order_time_a.Text = "";
            this.txtfranchiser_order_time_b.Text = "";
            this.drpfranchiser_order_state.SelectedIndex = 0;
        }
    }
}
