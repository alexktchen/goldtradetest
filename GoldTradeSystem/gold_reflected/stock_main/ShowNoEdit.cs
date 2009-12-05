namespace GoldTradeNaming.Web.stock_main
{
    using GoldTradeNaming.BLL;
    using GoldTradeNaming.Model;
    using LTP.Common;
    using System;
    using System.Data;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public class ShowNoEdit : Page
    {
        private GoldTradeNaming.BLL.stock_main bll = new GoldTradeNaming.BLL.stock_main();
        protected Button query;
        protected Button reset;
        protected GridView showData;
        protected TextBox txtFran_ID;

        protected void add_new_Click(object sender, EventArgs e)
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((this.Session["admin"] == null) || (this.Session["admin"].ToString() == ""))
            {
                this.Session.Clear();
                base.Response.Clear();
                MessageBox.ShowAndRedirect(this, @"您没有权限或登录超时！\n请重新登录或与管理员联系", "../User_Login/AdminLogin.aspx");
            }
            else if (!(((this.Session["admin"] != null) && (this.Session["admin"].ToString() != "")) && CommBaseBLL.HasRight(Convert.ToInt32(this.Session["admin"]), Authority.StockView.ToString())))
            {
                base.Response.Clear();
                base.Response.Write(@"<script defer>window.alert('您没有权限操作该功能！\n请重新登录或与管理员联系');history.back();</script>");
                base.Response.End();
            }
            else if (!this.Page.IsPostBack)
            {
                this.showData.Visible = false;
                string franchiser_code = base.Request.Params["id"];
                DataSet ds = this.bll.getAllInfoAboutM("");
                if ((ds == null) || (ds.Tables[0].Rows.Count == 0))
                {
                    this.showData.Visible = false;
                }
                else
                {
                    this.Session["data"] = ds;
                    this.showData.DataSource = ds;
                    this.showData.DataBind();
                    this.showData.Visible = true;
                    this.txtFran_ID.Text = franchiser_code;
                }
            }
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            (base.Master.FindControl("lblTitle") as Label).Text = "库存查询";
        }

        protected void query_Click(object sender, EventArgs e)
        {
            try
            {
                string Fran_id = this.txtFran_ID.Text.Trim();
                int temp = -2147483648;
                switch (Fran_id)
                {
                    case "":
                    case null:
                        MessageBox.Show(this, "请先输入经销商编号");
                        this.txtFran_ID.Focus();
                        return;
                }
                if (!int.TryParse(Fran_id, out temp))
                {
                    MessageBox.Show(this, "经销商编号应为数字");
                }
                else
                {
                    DataSet ds = this.bll.getAllInfoAboutM(Fran_id);
                    if ((ds == null) || (ds.Tables[0].Rows.Count == 0))
                    {
                        base.Response.Write("<script type='text/javascript'>alert('没有该经销商的库存信息');</script>");
                        this.showData.Visible = false;
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
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.ToString());
            }
        }

        protected void reset_Click(object sender, EventArgs e)
        {
            this.showData.Visible = false;
            this.txtFran_ID.Text = string.Empty;
        }

        protected void showData_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DataSet ds = (DataSet) this.Session["data"];
            this.showData.PageIndex = e.NewPageIndex;
            this.showData.Visible = true;
            this.showData.DataSource = ds;
            this.showData.DataBind();
        }
    }
}
