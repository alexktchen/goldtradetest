namespace GoldTradeNaming.Web.franchiser_info
{
    using GoldTradeNaming.BLL;
    using GoldTradeNaming.Model;
    using LTP.Common;
    using System;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public class BaseInfo : Page
    {
        private GoldTradeNaming.BLL.franchiser_info bll = new GoldTradeNaming.BLL.franchiser_info();
        private GoldTradeNaming.BLL.goldtrade_IA100 bll100 = new GoldTradeNaming.BLL.goldtrade_IA100();
        protected Button btnReturn;
        protected HiddenField keyFranId;
        protected HiddenField keyFranName;
        protected Panel plSource;
        protected TextBox txtBalance;
        protected TextBox txtfranchiser_address;
        protected TextBox txtfranchiser_asure_money;
        protected TextBox txtfranchiser_cellphone;
        protected TextBox txtfranchiser_name;
        protected TextBox txtfranchiser_tel;
        protected TextBox txtIA100GUID;

        private void BindInfo()
        {
            if (base.Request.Params.Count > 0)
            {
                GoldTradeNaming.Model.franchiser_info info = this.bll.GetModel(Convert.ToInt32(this.keyFranId.Value));
                if (info != null)
                {
                    this.txtBalance.Text = info.franchiser_balance_money.ToString();
                    this.txtfranchiser_address.Text = info.franchiser_address;
                    this.txtfranchiser_asure_money.Text = info.franchiser_asure_money.ToString();
                    this.txtfranchiser_cellphone.Text = info.franchiser_cellphone;
                    this.txtfranchiser_name.Text = info.franchiser_name;
                    this.txtfranchiser_tel.Text = info.franchiser_tel;
                    this.txtIA100GUID.Text = info.IA100GUID.ToString();
                }
            }
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("ShowNoEdit.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((this.Session["admin"] == null) || (this.Session["admin"].ToString() == ""))
            {
                this.Session.Clear();
                base.Response.Clear();
                MessageBox.ShowAndRedirect(this, @"您没有权限或登录超时！\n请重新登录或与管理员联系", "../User_Login/AdminLogin.aspx");
            }
            else if (!(((this.Session["admin"] != null) && (this.Session["admin"].ToString() != "")) && CommBaseBLL.HasRight(Convert.ToInt32(this.Session["admin"]), Authority.ViewFran.ToString())))
            {
                base.Response.Clear();
                base.Response.Write(@"<script defer>window.alert('您没有权限操作该功能！\n请重新登录或与管理员联系');history.back();</script>");
                base.Response.End();
            }
            else if (!this.Page.IsPostBack)
            {
                this.keyFranId.Value = base.Request.Params["id"].ToString();
                this.keyFranName.Value = base.Request.Params["name"].ToString();
                this.BindInfo();
            }
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            (base.Master.FindControl("lblTitle") as Label).Text = "经销商基本信息";
        }
    }
}
