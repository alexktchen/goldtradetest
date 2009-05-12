using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
namespace GoldTradeNaming.Web.franchiser_order
{
    public partial class Show : System.Web.UI.Page
    {
        protected void Page_LoadComplete(object sender, EventArgs e)
        {
           // (Master.FindControl("lblOrderOrTrade") as Label).Text = "订货可用余额：";
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["fran"] == null || Session["fran"].ToString() == "")
                {
                    Response.Clear();
                    Response.Write("<script defer>window.alert('" + "您没有权限登录本系统！\\n请重新登录或与管理员联系" + "');history.back();</script>");
                    Response.End();
                    return;
                }
                LoadData();
            }
        }

        protected void query_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" franchiser_code='" + Convert.ToString(Session["fran"]) + "'");

            if (txtfranchiser_order_id.Text.Trim() == "")
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
            if (txtfranchiser_order_time_a.Text.Trim() != "")
            {
                DateTime dta = DateTime.MinValue;
                try
                {
                    dta = Convert.ToDateTime(txtfranchiser_order_time_a.Text.Trim());
                }
                catch
                {
                    dta = DateTime.Now.AddMonths(-1);
                }
                sb.Append(dta.ToString("yyyy/MM/dd") + "'");
            }
            else
            {
                DateTime dta = DateTime.Now.AddMonths(-1);
                sb.Append(dta.ToString("yyyy/MM/dd") + "'");
            }
            sb.Append(" and '");
            if (txtfranchiser_order_time_b.Text.Trim() != "")
            {
                DateTime dtb = DateTime.MinValue;
                try
                {
                    dtb = Convert.ToDateTime(txtfranchiser_order_time_b.Text.Trim());
                }
                catch
                {
                    dtb = DateTime.Now;
                }
                sb.Append(dtb.AddDays(1).ToString("yyyy/MM/dd") + "'");
            }
            else
            {
                DateTime dtb = DateTime.Now.AddDays(1);
                sb.Append(dtb.ToString("yyyy/MM/dd") + "'");
            }
            if (drpfranchiser_order_state.SelectedIndex != 3)
            {
                sb.Append("AND franchiser_order_state='" + drpfranchiser_order_state.SelectedIndex.ToString() + "'");

            }


            GoldTradeNaming.BLL.franchiser_order bll = new GoldTradeNaming.BLL.franchiser_order();
            DataSet ds = bll.GetList(sb.ToString());


            //if (drpfranchiser_order_state.SelectedIndex == 0)
            //{
            //    GridView1.Columns[11].Visible = true;
            //    GridView1.Columns[12].Visible = true;
            //    GridView1.Columns[13].Visible = false;
            //}
            //else if (drpfranchiser_order_state.SelectedIndex == 1 || drpfranchiser_order_state.SelectedIndex == 4)
            //{
            //    GridView1.Columns[11].Visible = false;
            //    GridView1.Columns[12].Visible = false;
            //    GridView1.Columns[13].Visible = true;
            //}
            //else
            //{
            //    GridView1.Columns[11].Visible = false;
            //    GridView1.Columns[12].Visible = false;
            //    GridView1.Columns[13].Visible = false;
            //}
            if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0) lblMsg.Text = "查无数据。";
           
                Session["datasrc"] = ds;
                this.GridView1.DataSource = Session["datasrc"] as DataSet;
                this.GridView1.DataBind();
            
        }

        private void LoadData()
        {
            GoldTradeNaming.BLL.franchiser_order bll = new GoldTradeNaming.BLL.franchiser_order();
            DataSet ds = bll.GetLatestList(Convert.ToInt32(Session["fran"]));
            if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0) lblMsg.Text = "暂无数据。";
            
                Session["datasrc"] = ds;
                this.GridView1.DataSource = Session["datasrc"] as DataSet;
                this.GridView1.DataBind();
            
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridView1.PageIndex = e.NewPageIndex;
            this.GridView1.DataSource = Session["datasrc"] as DataSet;
            this.GridView1.DataBind();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //int rowindex = e.Row.RowIndex;  
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int rowIndex = GridView1.SelectedIndex;
            string orderid = GridView1.Rows[rowIndex].Cells[0].Text;
            StringBuilder strWhere = new StringBuilder();
            strWhere.Append(" franchiser_order_id = '");
            strWhere.Append(orderid + "'");
            GoldTradeNaming.BLL.send_main orderdscBll = new GoldTradeNaming.BLL.send_main();
            DataSet ds = orderdscBll.GetOrderedProductList(strWhere.ToString());
            GridView1.DataSource = ds;
            GridView1.DataBind();
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
