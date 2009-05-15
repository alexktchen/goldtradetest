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


using LTP.Common;

namespace GoldTradeNaming.Web.franchiser_trade
{
    public partial class TradeTime : System.Web.UI.Page
    {
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
                    || !GoldTradeNaming.BLL.CommBaseBLL.HasRight(Convert.ToInt32(Session["admin"]), Model.Authority.TradeLock.ToString()))
            {
                Response.Clear();
                Response.Write("<script defer>window.alert('" + "您没有权限操作该功能！\\n请重新登录或与管理员联系" + "');history.back();</script>");
                Response.End();
                return;
            }
            if (!Page.IsPostBack)
            {
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            DateTime dtFrom = DateTime.Now;
            DateTime dtTo = DateTime.Now;
            try
            {
                dtFrom = Convert.ToDateTime("2000/01/01 " + txtdtFrom.Text.Trim());
            }
            catch
            {
                MessageBox.Show(this, "请输入正确的时间格式");
                return;
            }
            try
            {
                dtTo = Convert.ToDateTime("2999/01/01 " + txtdtTo.Text.Trim());
            }
            catch
            {
                MessageBox.Show(this, "请输入正确的时间格式");
                return;
            }


            GoldTradeNaming.BLL.franchiser_trade bll = new GoldTradeNaming.BLL.franchiser_trade();

            if (bll.SetTradeTime(dtFrom, dtTo, Session["admin"].ToString().Trim()) > 0)
            {
                MessageBox.ShowAndRedirect(this, "提交成功...", "../franchiser_trade/TradeTime.aspx");
            }

        }
    }
}
