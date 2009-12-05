namespace GoldTradeNaming.Web.sys_login_info
{
    using GoldTradeNaming.BLL;
    using GoldTradeNaming.Model;
    using System;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public class Show : Page
    {
        protected Label lblID;
        protected Label lblIP;
        protected Label lbllogin_ID;
        protected Label lbllogin_time;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                if ((base.Request.Params["id"] != null) && (base.Request.Params["id"].Trim() != ""))
                {
                    string id = base.Request.Params["id"];
                }
                if ((this.Session["admin"] == null) || (this.Session["admin"].ToString() == ""))
                {
                    base.Response.Clear();
                    base.Response.Write(@"<script defer>window.alert('您没有权限登录本系统！\n请重新登录或与管理员联系');history.back();</script>");
                    base.Response.End();
                }
                else
                {
                    this.SaveLoginInfo();
                }
            }
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            (base.Master.FindControl("lblTitle") as Label).Text = "详细信息";
        }

        private bool SaveLoginInfo()
        {
            string login_ID = "1001";
            if ((this.Session["admin"] != null) && (this.Session["admin"].ToString().Trim() != ""))
            {
                login_ID = this.Session["admin"].ToString().Trim();
            }
            string IP = base.Request.UserHostAddress;
            GoldTradeNaming.Model.sys_login_info model = new GoldTradeNaming.Model.sys_login_info();
            model.IP = IP;
            model.login_ID = login_ID;
            GoldTradeNaming.BLL.sys_login_info bll = new GoldTradeNaming.BLL.sys_login_info();
            return (bll.Add(model) > 0);
        }

        private void ShowInfo(int ID)
        {
            GoldTradeNaming.Model.sys_login_info model = new GoldTradeNaming.BLL.sys_login_info().GetModel(ID);
            this.lblIP.Text = model.IP.ToString();
            this.lbllogin_time.Text = model.login_time.ToString();
            this.lbllogin_ID.Text = model.login_ID;
        }
    }
}
