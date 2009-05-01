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

namespace GoldTradeNaming.Web.send_main
{
    public partial class Show : System.Web.UI.Page
    {
        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            (Master.FindControl("lblTitle") as Label).Text = "在线发货";
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["admin"] == null || Session["admin"].ToString() == ""
                    || !GoldTradeNaming.BLL.CommBaseBLL.HasRight(Convert.ToInt32(Session["admin"]), Model.Authority.Send.ToString())
                    )
                {
                    Response.Clear();
                    Response.Write("<script defer>window.alert('" + "您没有权限登录本系统！\\n请重新登录或与管理员联系" + "');history.back();</script>");
                    Response.End();
                    return;
                }

                //if (Request.QueryString.Count == 2)
                //{
                //    this.franid.Value = Request.QueryString["fid"].ToString();
                //    this.orderid.Value = Request.QueryString["id"].ToString();                   
                //}
                this.ShowInfo();
            }
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
                GoldTradeNaming.BLL.send_main bll = new GoldTradeNaming.BLL.send_main();
                Session["grd_Data"] = bll.GetOrderInfo(strWhere.ToString());
                this.GridView1.DataSource = Session["grd_Data"] as DataSet;
                this.GridView1.DataBind();
            }
            catch
            {
                MessageBox.Show(this, "查询订单出错！");
            }

        }

        protected void Query_Click(object sender, EventArgs e)
        {
            this.franid.Value = this.txtFranID.Text;
            this.orderid.Value = this.txtOrderID.Text;
            this.ShowInfo();
        }


        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridView1.PageIndex = e.NewPageIndex;
            this.GridView1.DataSource = Session["grd_Data"] as DataSet;
            this.GridView1.DataBind();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

    }
}
