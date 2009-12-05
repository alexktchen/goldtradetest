namespace GoldTradeNaming.Web.stock_main
{
    using GoldTradeNaming.BLL;
    using LTP.Common;
    using System;
    using System.Data;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public class franchiserStockShow : Page
    {
        private stock_main bll = new stock_main();
        protected Label Label8;
        protected GridView showData;

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((this.Session["fran"] == null) || (this.Session["fran"].ToString() == ""))
            {
                this.Session.Clear();
                base.Response.Clear();
                MessageBox.ShowAndRedirect(this, @"您没有权限或登录超时！\n请重新登录或与管理员联系", "../User_Login/flogin.aspx");
            }
            else if (!this.Page.IsPostBack)
            {
                this.ShowInfo();
            }
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
        }

        protected void showData_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DataSet ds = (DataSet) this.Session["data"];
            this.showData.PageIndex = e.NewPageIndex;
            this.showData.Visible = true;
            this.showData.DataSource = ds;
            this.showData.DataBind();
        }

        private void ShowInfo()
        {
            string Fran_id = this.Session["fran"].ToString();
            DataSet ds = this.bll.getAllInfoAboutM(Fran_id);
            if ((ds == null) || (ds.Tables[0].Rows.Count == 0))
            {
                base.Response.Write("<script type='text/javascript'>alert('您还没有库存');</script>");
            }
            else
            {
                this.Session["data"] = ds;
                this.showData.DataSource = ds;
                this.showData.DataBind();
                this.showData.Visible = true;
            }
        }
    }
}
