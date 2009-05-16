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

namespace GoldTradeNaming.Web.franchiser_order
{
    public partial class Add_Type : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["fran"] == null || Session["fran"].ToString() == "")
            {
                Session.Clear();
                Response.Clear();
                LTP.Common.MessageBox.ShowAndRedirect(this, "您没有权限或登录超时！\\n请重新登录或与管理员联系", "../User_Login/flogin.aspx");
                return;
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Session.Remove("OrderMain");
            Session.Remove("orderdesclist");
            Response.Redirect("~/franchiser_order/Add.aspx?prodtype=0");
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            Session.Remove("OrderMain");
            Session.Remove("orderdesclist");
            Response.Redirect("~/franchiser_order/Add.aspx?prodtype=1");
        }
    }
}
