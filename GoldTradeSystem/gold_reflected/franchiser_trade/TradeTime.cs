namespace GoldTradeNaming.Web.franchiser_trade
{
    using GoldTradeNaming.BLL;
    using GoldTradeNaming.Model;
    using LTP.Common;
    using System;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public class TradeTime : Page
    {
        protected Button btnSubmit;
        protected Label lblFrom;
        protected TextBox txtdtFrom;
        protected TextBox txtdtTo;

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            DateTime dtFrom = DateTime.Now;
            DateTime dtTo = DateTime.Now;
            try
            {
                dtFrom = Convert.ToDateTime("2000/01/01 " + this.txtdtFrom.Text.Trim());
            }
            catch
            {
                MessageBox.Show(this, "请输入正确的时间格式");
                return;
            }
            try
            {
                dtTo = Convert.ToDateTime("2999/01/01 " + this.txtdtTo.Text.Trim());
            }
            catch
            {
                MessageBox.Show(this, "请输入正确的时间格式");
                return;
            }
            GoldTradeNaming.BLL.franchiser_trade bll = new GoldTradeNaming.BLL.franchiser_trade();
            if (bll.SetTradeTime(dtFrom, dtTo, this.Session["admin"].ToString().Trim()) > 0)
            {
                MessageBox.ShowAndRedirect(this, "提交成功...", "../franchiser_trade/TradeTime.aspx");
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
            else if (!(((this.Session["admin"] != null) && (this.Session["admin"].ToString() != "")) && CommBaseBLL.HasRight(Convert.ToInt32(this.Session["admin"]), Authority.TradeLock.ToString())))
            {
                base.Response.Clear();
                base.Response.Write(@"<script defer>window.alert('您没有权限操作该功能！\n请重新登录或与管理员联系');history.back();</script>");
                base.Response.End();
            }
            else if (!this.Page.IsPostBack)
            {
            }
        }
    }
}
