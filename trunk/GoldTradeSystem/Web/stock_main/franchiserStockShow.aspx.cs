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

namespace GoldTradeNaming.Web.stock_main
{
    public partial class franchiserStockShow : System.Web.UI.Page
    {
        private GoldTradeNaming.BLL.stock_main bll = new GoldTradeNaming.BLL.stock_main();

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            //txtFran_ID.Text = Session["fran"].ToString();

        }

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
                
                    ShowInfo();
                

            }
        }

        private void ShowInfo()
        {
            string Fran_id = Session["fran"].ToString();
            DataSet ds = bll.getAllInfoAboutM(Fran_id);
            if (ds == null || ds.Tables[0].Rows.Count == 0)
            {
                Response.Write("<script type='text/javascript'>alert('您还没有库存');</script>");

            }
            else
            {
                Session["data"] = ds;
                showData.DataSource = ds;
                showData.DataBind();
                showData.Visible = true;
            }

        }

        protected void showData_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DataSet ds = (DataSet)Session["data"];
            showData.PageIndex = e.NewPageIndex;
            showData.Visible = true;
            showData.DataSource = ds;
            showData.DataBind();
        }

    }
}
