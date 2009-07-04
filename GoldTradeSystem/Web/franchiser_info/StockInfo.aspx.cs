using System;
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
namespace GoldTradeNaming.Web.franchiser_info
{
    public partial class StockInfo : System.Web.UI.Page
    {
        private GoldTradeNaming.BLL.stock_main bll = new GoldTradeNaming.BLL.stock_main();

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
                   || !GoldTradeNaming.BLL.CommBaseBLL.HasRight(Convert.ToInt32(Session["admin"]), Model.Authority.ViewFran.ToString()))
            {
                Response.Clear();
                Response.Write("<script defer>window.alert('" + "您没有权限操作该功能！\\n请重新登录或与管理员联系" + "');history.back();</script>");
                Response.End();
                return;
            }   
            BindInfo();            
        }

        private void BindInfo()
        {
            if (Request.Params.Count > 0)
            {
                this.txtFran_ID.Text = Request.Params["name"].ToString();
             

                DataSet ds = bll.getAllInfoAboutM(GoldTradeNaming.BLL.CleanString.htmlInputText(Request.Params["id"].ToString()));

                Session["datasrc"] = ds;
                this.showData.DataSource = Session["datasrc"] as DataSet;
                this.showData.DataBind();

            }
        }      

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("ShowNoEdit.aspx");
        }

        protected void showData_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DataSet ds = (DataSet)Session["datasrc"];
            showData.PageIndex = e.NewPageIndex;
            showData.Visible = true;
            showData.DataSource = ds;
            showData.DataBind();        
        }
    }
}
