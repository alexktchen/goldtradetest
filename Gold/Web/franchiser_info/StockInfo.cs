namespace GoldTradeNaming.Web.franchiser_info
{
    using GoldTradeNaming.BLL;
    using GoldTradeNaming.Model;
    using LTP.Common;
    using System;
    using System.Data;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public class StockInfo : Page
    {
        private GoldTradeNaming.BLL.stock_main bll = new GoldTradeNaming.BLL.stock_main();
        protected Button Button1;
        protected GridView showData;
        protected TextBox txtFran_ID;

        private void BindInfo()
        {
            if (base.Request.Params.Count > 0)
            {
                this.txtFran_ID.Text = base.Request.Params["name"].ToString();
                DataSet ds = this.bll.getAllInfoAboutM(CleanString.htmlInputText(base.Request.Params["id"].ToString()));
                this.Session["datasrc"] = ds;
                this.showData.DataSource = this.Session["datasrc"] as DataSet;
                this.showData.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
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
            else
            {
                this.BindInfo();
            }
        }

        protected void showData_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DataSet ds = (DataSet) this.Session["datasrc"];
            this.showData.PageIndex = e.NewPageIndex;
            this.showData.Visible = true;
            this.showData.DataSource = ds;
            this.showData.DataBind();
        }
    }
}
