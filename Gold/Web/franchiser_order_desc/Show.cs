namespace GoldTradeNaming.Web.franchiser_order_desc
{
    using Anthem;
    using GoldTradeNaming.BLL;
    using LTP.Common;
    using System;
    using System.Data;
    using System.Text;
    using System.Web.UI;

    public class Show : Page
    {
        protected GridView GridView2;

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((this.Session["fran"] == null) || (this.Session["fran"].ToString() == ""))
            {
                this.Session.Clear();
                base.Response.Clear();
                MessageBox.ShowAndRedirect(this, @"您没有权限或登录超时！\n请重新登录或与管理员联系", "../User_Login/flogin.aspx");
            }
            else if (!this.Page.IsPostBack && (base.Request.QueryString["id"].ToString() != ""))
            {
                this.ShowInfo(base.Request.QueryString["id"].ToString());
            }
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
        }

        private void ShowInfo(string id)
        {
            string orderid = id;
            StringBuilder strWhere = new StringBuilder();
            strWhere.Append(" franchiser_order_id = '");
            strWhere.Append(orderid + "'");
            DataSet ds = new send_main().GetOrderedProductList(strWhere.ToString());
            if ((((ds != null) && (ds.Tables.Count > 0)) && (ds.Tables[0].Rows.Count > 0)) && (CommBaseBLL.GetProductTypeById(ds.Tables[0].Rows[0]["product_id"].ToString().Trim()) == "1"))
            {
                this.GridView2.Columns[1].Visible = false;
            }
            this.GridView2.DataSource = ds;
            this.GridView2.DataBind();
        }
    }
}
