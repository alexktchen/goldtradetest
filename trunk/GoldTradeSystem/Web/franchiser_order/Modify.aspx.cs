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
using LTP.Common;
namespace GoldTradeNaming.Web.franchiser_order
{
    public partial class Modify : System.Web.UI.Page
    {
        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            (Master.FindControl("lblTitle") as Label).Text = "订单管理";
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["admin"] == null || Session["admin"].ToString() == "" 
                    || Request.Params["type"] == null || Request.Params["type"].Trim() == ""
                    || !checkright()
                    )
                {
                    Response.Clear();
                    Response.Write("<script defer>window.alert('" + "您没有权限登录本系统！\\n请重新登录或与管理员联系" + "');history.back();</script>");
                    Response.End();
                    return;
                }
                else
                {
                    ViewState["oprType"] = Request.Params["type"].ToString();
                    ShowInfo();
                }

                GetRecentData();
            }
        }

        private void GetRecentData()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(@"franchiser_order_id in 
                        (select top 50 franchiser_order_id from franchiser_order order by franchiser_order_id desc)");
            if (drpfranchiser_order_state.SelectedIndex != 3)
            {
                sb.Append("AND franchiser_order_state='" + drpfranchiser_order_state.SelectedIndex.ToString() + "'");
            }

            GoldTradeNaming.BLL.franchiser_order bll = new GoldTradeNaming.BLL.franchiser_order();
            DataSet ds = bll.GetList(sb.ToString());

            if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0) lblMsg.Text = "暂无数据。";
            
                Session["datasrc"] = ds;
                this.GridView1.DataSource = Session["datasrc"] as DataSet;
                this.GridView1.DataBind();
            
        }

        private bool checkright()
        {
            bool rtn = false;
            string operatetype = Request.Params["type"].ToString().Trim();
            if(operatetype=="0")
            {
                rtn = GoldTradeNaming.BLL.CommBaseBLL.HasRight(Convert.ToInt32(Session["admin"]), Model.Authority.ViewOrder.ToString());
            }
            if(operatetype=="1")
            {
                rtn= GoldTradeNaming.BLL.CommBaseBLL.HasRight(Convert.ToInt32(Session["admin"]), Model.Authority.ConOrder.ToString());
            }
            //if(operatetype=="2")
            //{
            //    return GoldTradeNaming.BLL.CommBaseBLL.HasRight(Convert.ToInt32(Session["admin"]), Model.Authority.ChgOrder.ToString());
            //}
            return rtn;
        }
        
        private void ShowInfo()
        {
            if (ViewState["oprType"].ToString() == "0" )
            {
                this.GridView1.Columns[10].Visible = false;
                this.GridView1.Columns[11].Visible = false;
            }
            if (ViewState["oprType"].ToString() == "1")
            {
                this.drpfranchiser_order_state.SelectedIndex = 0;
                this.drpfranchiser_order_state.Enabled = false;
                this.GridView1.Columns[11].Visible = false;
            }
            if (ViewState["oprType"].ToString() == "2")
            {
                this.drpfranchiser_order_state.SelectedIndex = 0;
                this.drpfranchiser_order_state.Enabled = false;
                this.GridView1.Columns[10].Visible = false;
            }
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
            if (drpfranchiser_order_state.SelectedIndex != 3)
            {
                sb.Append("AND franchiser_order_state='" + drpfranchiser_order_state.SelectedIndex.ToString() + "'");
            }       
            
            GoldTradeNaming.BLL.franchiser_order bll = new GoldTradeNaming.BLL.franchiser_order();
            DataSet ds = bll.GetList(sb.ToString());
            if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0) lblMsg.Text = "查无数据。";
           
                Session["datasrc"] = ds;
                this.GridView1.DataSource = Session["datasrc"] as DataSet;
                this.GridView1.DataBind();
            
        }

        protected void reset_Click(object sender, EventArgs e)
        {
            this.txtfranchiser_order_id.Text = "";
            this.txtFranID.Text = "";
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridView1.PageIndex = e.NewPageIndex;
            this.GridView1.DataSource = Session["datasrc"] as DataSet;
            this.GridView1.DataBind();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ///确认订单
            if (e.CommandName == "cmdConfirm")
            {
                try
                {  
                    GridViewRow myRow = ((GridViewRow)(((Button)(e.CommandSource)).Parent.Parent));
                    int rowindex = myRow.RowIndex;
                    GoldTradeNaming.BLL.franchiser_order bll = new GoldTradeNaming.BLL.franchiser_order();
                    string orderid = "";
                    orderid = ((HyperLink)GridView1.Rows[rowindex].Cells[0].Controls[0]).Text;


                    if (bll.ConfirmOrder(Convert.ToInt32(orderid), Session["admin"] as string))
                    {
                        MessageBox.ShowAndRedirect(this, "确认成功！", "Modify.aspx?type=1");
                        //query_Click(sender, new EventArgs());
                    }
                }
                catch
                {
                }
            }
            ///修改订单
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

    }
}
