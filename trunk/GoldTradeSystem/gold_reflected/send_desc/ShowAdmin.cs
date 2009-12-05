namespace GoldTradeNaming.Web.send_desc
{
    using GoldTradeNaming.BLL;
    using GoldTradeNaming.Model;
    using LTP.Common;
    using System;
    using System.Data;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public class ShowAdmin : Page
    {
        private readonly GoldTradeNaming.BLL.send_desc bll = new GoldTradeNaming.BLL.send_desc();
        protected ScriptManager ScriptManager1;
        protected GridView showData;

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((this.Session["admin"] == null) || (this.Session["admin"].ToString() == ""))
            {
                this.Session.Clear();
                base.Response.Clear();
                MessageBox.ShowAndRedirect(this, @"您没有权限或登录超时！\n请重新登录或与管理员联系", "../User_Login/AdminLogin.aspx");
            }
            else if (!(((this.Session["admin"] != null) && (this.Session["admin"].ToString() != "")) && CommBaseBLL.HasRight(Convert.ToInt32(this.Session["admin"]), Authority.SendShow.ToString())))
            {
                base.Response.Clear();
                base.Response.Write(@"<script defer>window.alert('您没有权限操作该功能！\n请重新登录或与管理员联系');history.back();</script>");
                base.Response.End();
            }
            else if (!base.IsPostBack && ((base.Request.Params["sendid"] != null) && (base.Request.Params["sendid"].Trim() != "")))
            {
                string send_id = base.Request.Params["sendid"].ToString();
                this.showInformation(send_id);
            }
        }

        private void showInformation(string send_id)
        {
            try
            {
                DataSet ds = this.bll.getSendDesc(send_id);
                if ((ds == null) || (ds.Tables[0].Rows.Count == 0))
                {
                    this.showData.Visible = false;
                }
                else
                {
                    this.showData.PageIndex = 0;
                    this.showData.DataSource = ds;
                    this.showData.DataBind();
                    this.showData.DataKeyNames = new string[] { "id" };
                    this.showData.Visible = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
