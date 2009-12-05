namespace GoldTradeNaming.Web.goldtrade_IA100
{
    using GoldTradeNaming.BLL;
    using GoldTradeNaming.Model;
    using GoldTradeNaming.Web.goldtrade_db_admin;
    using LTP.Common;
    using System;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public class Add : Page
    {
        protected Button btnAdd;
        protected Button btnCancel;
        protected Label Label1;
        protected Label Label2;
        protected Label Label3;
        protected TextBox txtIA100GUID;
        protected TextBox txtIA100Key;
        protected TextBox txtIA100SuperPswd;

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
                string IA100Guid = this.txtIA100GUID.Text;
                string IA100Key = this.txtIA100Key.Text;
                string IA100SuperPswd = this.txtIA100SuperPswd.Text;
                string IA100State = "0";
                string StateChangeReason = "新增锁";
                GoldTradeNaming.Model.goldtrade_IA100 model = new GoldTradeNaming.Model.goldtrade_IA100();
                try
                {
                    model.IA100GUID = new Guid(IA100Guid);
                }
                catch
                {
                    MessageBox.Show(this, "IA100GUID不正确，请检查");
                    return;
                }
                model.IA100Key = IA100Key;
                model.IA100SuperPswd = IA100SuperPswd;
                model.IA100State = IA100State;
                model.StateChangeReason = StateChangeReason;
                try
                {
                    GoldTradeNaming.BLL.goldtrade_IA100 bll = new GoldTradeNaming.BLL.goldtrade_IA100();
                    if (bll.Exists(model.IA100GUID))
                    {
                        MessageBox.Show(this, "记录已存在！");
                    }
                    else
                    {
                        bll.Add(model);
                        MessageBox.ShowAndRedirect(this, goldtrade_db_adminRes.strAddSuccess, "Show.aspx");
                    }
                }
                catch
                {
                    MessageBox.Show(this, "添加时出错！");
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            this.txtIA100GUID.Text = "";
            this.txtIA100Key.Text = "";
            this.txtIA100SuperPswd.Text = "";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((this.Session["admin"] == null) || (this.Session["admin"].ToString() == ""))
            {
                this.Session.Clear();
                base.Response.Clear();
                MessageBox.ShowAndRedirect(this, @"您没有权限或登录超时！\n请重新登录或与管理员联系", "../User_Login/AdminLogin.aspx");
            }
            else if (!(((this.Session["admin"] != null) && (this.Session["admin"].ToString() != "")) && CommBaseBLL.HasRight(Convert.ToInt32(this.Session["admin"]), Authority.AddIA.ToString())))
            {
                base.Response.Clear();
                base.Response.Write(@"<script defer>window.alert('您没有权限操作该功能！\n请重新登录或与管理员联系');history.back();</script>");
                base.Response.End();
            }
            else if (!base.IsPostBack)
            {
            }
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            (base.Master.FindControl("lblTitle") as Label).Text = "添加认证锁";
        }
    }
}
