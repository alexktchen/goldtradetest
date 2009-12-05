namespace GoldTradeNaming.Web.product_type
{
    using GoldTradeNaming.BLL;
    using GoldTradeNaming.Model;
    using LTP.Common;
    using System;
    using System.Data;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public class product_type_index : Page
    {
        private readonly GoldTradeNaming.BLL.product_type bll = new GoldTradeNaming.BLL.product_type();
        protected Button cancel;
        protected DropDownList drptype;
        protected DropDownList drptype_Status;
        protected Button query;
        public GridViewRow row = null;
        public GridView showData;
        protected TextBox txtorder_add_price;
        protected TextBox txttrade_add_price;
        protected TextBox type_ID;
        protected TextBox type_Kind;
        protected TextBox type_Name;

        protected void cancel_Click(object sender, EventArgs e)
        {
            this.type_ID.Text = "";
            this.type_Kind.Text = "";
            this.drptype_Status.SelectedIndex = 0;
            this.type_Name.Text = "";
            this.txtorder_add_price.Text = "";
            this.txttrade_add_price.Text = "";
            this.drptype.SelectedIndex = 0;
            this.showData.DataSource = null;
            this.showData.Visible = false;
        }

        public void databind()
        {
            try
            {
                string id = this.type_ID.Text.Trim();
                string name = this.type_Name.Text.Trim();
                string kind = this.type_Kind.Text.Trim();
                string status = this.drptype_Status.Text.Trim();
                string order_add = this.txtorder_add_price.Text.Trim();
                string trade_add = this.txttrade_add_price.Text.Trim();
                string type = this.drptype.Text.Trim();
                DataSet ds = this.bll.queryAction(id, name, kind, status, order_add, trade_add, type);
                if ((ds == null) || (ds.Tables[0].Rows.Count == 0))
                {
                    this.showData.DataSource = null;
                    this.showData.Visible = false;
                    base.Response.Write("<script type='text/javascript'>alert('查无数据，请确定查询条件是否正确');</script>");
                }
                else
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        if (row["product_state"].ToString().Trim() == "0")
                        {
                            row["product_state"] = "启用";
                        }
                        else
                        {
                            row["product_state"] = "禁用";
                        }
                        if (row["type"].ToString().Trim() == "0")
                        {
                            row["type"] = "升水";
                        }
                        else
                        {
                            row["type"] = "非升水";
                        }
                    }
                    this.Session["data"] = ds;
                    this.showData.Visible = true;
                    this.showData.DataSource = ds;
                    this.showData.DataBind();
                }
            }
            catch
            {
                base.Response.Write("<script type='text/javascript'>alert('查询失败');</script>");
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
            else if (!(((this.Session["admin"] != null) && (this.Session["admin"].ToString() != "")) && CommBaseBLL.HasRight(Convert.ToInt32(this.Session["admin"]), Authority.ViewProduct.ToString())))
            {
                base.Response.Clear();
                base.Response.Write(@"<script defer>window.alert('您没有权限操作该功能！\n请重新登录或与管理员联系');history.back();</script>");
                base.Response.End();
            }
            else if (!this.Page.IsPostBack)
            {
                this.databind();
            }
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            (base.Master.FindControl("lblTitle") as Label).Text = "查看产品";
        }

        protected void query_Click(object sender, EventArgs e)
        {
            this.databind();
        }

        protected void showData_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                DataSet ds = (DataSet) this.Session["data"];
                this.showData.PageIndex = e.NewPageIndex;
                this.showData.Visible = true;
                this.showData.DataSource = ds;
                this.showData.DataBind();
            }
            catch
            {
                base.Response.Write("<script type='text/javascript'>alert('翻页失败');</script>");
            }
        }
    }
}
