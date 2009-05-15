using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace GoldTradeNaming.Web.product_type
{
    public partial class product_type_index : System.Web.UI.Page
    {


        private readonly GoldTradeNaming.BLL.product_type bll = new GoldTradeNaming.BLL.product_type();
        public GridViewRow row = null;
        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            (Master.FindControl("lblTitle") as Label).Text = "查看产品";
        }

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
                    || !GoldTradeNaming.BLL.CommBaseBLL.HasRight(Convert.ToInt32(Session["admin"]), Model.Authority.ViewProduct.ToString()))
            {
                Response.Clear();
                Response.Write("<script defer>window.alert('" + "您没有权限操作该功能！\\n请重新登录或与管理员联系" + "');history.back();</script>");
                Response.End();
                return;
            }
            if (!Page.IsPostBack)
            {
                databind();
            }
        }

        protected void query_Click(object sender, EventArgs e)
        {

            databind();

        }


        public void databind() {

            try
            {
                string id = type_ID.Text.Trim();
                string name = type_Name.Text.Trim();
                string kind = type_Kind.Text.Trim();
                string status = drptype_Status.Text.Trim();
                string order_add = txtorder_add_price.Text.Trim();
                string trade_add = txttrade_add_price.Text.Trim();
                string type = drptype.Text.Trim();
                DataSet ds = bll.queryAction(id, name, kind, status, order_add, trade_add, type);
                if (ds == null || ds.Tables[0].Rows.Count == 0)
                {
                    //message.Text = "查无数据，请确定查询条件是否正确";
                    showData.DataSource = null;
                    showData.Visible = false;
                    Response.Write("<script type='text/javascript'>alert('查无数据，请确定查询条件是否正确');</script>");
                }
                else
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        if (row["product_state"].ToString().Trim() == "0")
                        {
                            row["product_state"] = "启用";
                        }
                        else
                        {
                            row["product_state"] = "禁用";
                        }



                        if (row["type"].ToString().Trim() == "0")
                        {
                            row["type"] = "升水";

                        }
                        else { row["type"] = "非升水"; }


                    }


                    Session["data"] = ds;
                    showData.Visible = true;
                    showData.DataSource = ds;
                    showData.DataBind();
                }
            }
            catch
            {
                Response.Write("<script type='text/javascript'>alert('查询失败');</script>");

            }
        }


        protected void showData_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                DataSet ds = (DataSet)Session["data"];
                showData.PageIndex = e.NewPageIndex;
                showData.Visible = true;
                showData.DataSource = ds;
                showData.DataBind();
            }
            catch
            {

                Response.Write("<script type='text/javascript'>alert('翻页失败');</script>");
            }

        }

        
        protected void cancel_Click(object sender, EventArgs e)
        {
            type_ID.Text = "";
            type_Kind.Text = "";
            drptype_Status.SelectedIndex = 0;
            type_Name.Text = "";
            txtorder_add_price.Text = "";
            txttrade_add_price.Text = "";
            drptype.SelectedIndex = 0;
            showData.DataSource = null;
            showData.Visible = false;


        }


       
       






    }
}
