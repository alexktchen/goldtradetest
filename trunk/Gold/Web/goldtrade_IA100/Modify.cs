namespace GoldTradeNaming.Web.goldtrade_IA100
{
    using GoldTradeNaming.BLL;
    using GoldTradeNaming.Model;
    using LTP.Common;
    using System;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public class Modify : Page
    {
        protected Button btnAdd;
        protected Button btnCancel;
        protected Label lblIA100GUID;
        protected ListBox lstIA100_State;
        protected TextBox txtIA100Key;
        protected TextBox txtIA100SuperPswd;
        protected TextBox txtStateChangeReason;

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string strErr = "";
            if (this.txtIA100Key.Text == "")
            {
                strErr = strErr + @"IA100Key不能为空！\n";
            }
            if (this.txtIA100SuperPswd.Text == "")
            {
                strErr = strErr + @"IA100SuperPswd不能为空！\n";
            }
            if (this.txtStateChangeReason.Text == "")
            {
                strErr = strErr + @"StateChangeReason不能为空！\n";
            }
            if (this.txtIA100Key.Text.Length != 0x20)
            {
                strErr = strErr + @"认证锁密钥不正确！\n";
            }
            if (this.txtIA100SuperPswd.Text.Length != 0x20)
            {
                strErr = strErr + @"认证锁超级密码不正确！！！\n";
            }
            if (strErr != "")
            {
                MessageBox.Show(this, strErr);
            }
            else
            {
                string IA100Key = this.txtIA100Key.Text;
                string IA100SuperPswd = this.txtIA100SuperPswd.Text;
                string IA100State = this.lstIA100_State.SelectedValue;
                string StateChangeReason = this.txtStateChangeReason.Text;
                try
                {
                    GoldTradeNaming.Model.goldtrade_IA100 model = new GoldTradeNaming.Model.goldtrade_IA100();
                    model.IA100GUID = new Guid(this.lblIA100GUID.Text.Trim());
                    model.IA100Key = IA100Key;
                    model.IA100SuperPswd = IA100SuperPswd;
                    model.IA100State = IA100State;
                    model.StateChangeReason = StateChangeReason;
                    new GoldTradeNaming.BLL.goldtrade_IA100().Update(model);
                    MessageBox.ShowAndRedirect(this, "修改成功！", "Show.aspx");
                }
                catch
                {
                    MessageBox.Show(this, "修改过程出错！");
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("Show.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((this.Session["admin"] == null) || (this.Session["admin"].ToString() == ""))
            {
                this.Session.Clear();
                base.Response.Clear();
                MessageBox.ShowAndRedirect(this, @"您没有权限或登录超时！\n请重新登录或与管理员联系", "../User_Login/AdminLogin.aspx");
            }
            else if (!(((this.Session["admin"] != null) && (this.Session["admin"].ToString() != "")) && CommBaseBLL.HasRight(Convert.ToInt32(this.Session["admin"]), Authority.SearchIA.ToString())))
            {
                base.Response.Clear();
                base.Response.Write(@"<script defer>window.alert('您没有权限操作该功能！\n请重新登录或与管理员联系');history.back();</script>");
                base.Response.End();
            }
            else if (!this.Page.IsPostBack)
            {
                this.btnAdd.Attributes.Add("onclick", "return confirm('確定要提交?')");
                this.lblIA100GUID.Text = base.Request.QueryString["guid"].ToString();
                this.txtIA100Key.Text = base.Request.QueryString["key"].ToString();
                this.txtIA100SuperPswd.Text = base.Request.QueryString["spwsd"].ToString();
                this.txtStateChangeReason.Text = base.Request.QueryString["rsn"].ToString();
            }
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            (base.Master.FindControl("lblTitle") as Label).Text = "修改认证锁";
        }

        private void ShowInfo(Guid IA100GUID)
        {
            GoldTradeNaming.Model.goldtrade_IA100 model = new GoldTradeNaming.BLL.goldtrade_IA100().GetModel(IA100GUID);
            this.lblIA100GUID.Text = model.IA100GUID.ToString();
            this.txtIA100Key.Text = model.IA100Key;
            this.txtIA100SuperPswd.Text = model.IA100SuperPswd;
            this.txtStateChangeReason.Text = model.StateChangeReason;
        }
    }
}
