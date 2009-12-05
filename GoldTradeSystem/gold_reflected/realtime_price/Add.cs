namespace GoldTradeNaming.Web.realtime_price
{
    using GoldTradeNaming.BLL;
    using GoldTradeNaming.Model;
    using LTP.Common;
    using System;
    using System.Data;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public class Add : Page
    {
        private GoldTradeNaming.BLL.realtime_price bll = new GoldTradeNaming.BLL.realtime_price();
        protected Button btnAdd;
        protected TextBox txtrealtime_base_price;

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string strErr = "";
                if (!PageValidate.IsDecimal(this.txtrealtime_base_price.Text))
                {
                    strErr = strErr + @"实时价格不是数字！\n";
                }
                if (!((this.Session["admin"] != null) && PageValidate.IsNumber(this.Session["admin"].ToString().Trim())))
                {
                    strErr = strErr + @"管理员帐号异常！\n";
                }
                if (strErr != "")
                {
                    MessageBox.Show(this, strErr);
                }
                else
                {
                    decimal realtime_base_price = decimal.Parse(this.txtrealtime_base_price.Text);
                    int sys_admin_id = int.Parse(this.Session["admin"].ToString().Trim());
                    string ins_user = this.Session["admin"].ToString().Trim();
                    string upd_user = "";
                    GoldTradeNaming.Model.realtime_price model = new GoldTradeNaming.Model.realtime_price();
                    model.realtime_base_price = realtime_base_price;
                    model.sys_admin_id = sys_admin_id;
                    model.ins_user = ins_user;
                    model.upd_user = upd_user;
                    new GoldTradeNaming.BLL.realtime_price().Add(model);
                    MessageBox.ShowAndRedirect(this, "修改成功...", "../realtime_price/Show.aspx");
                }
            }
            catch
            {
                MessageBox.Show(this, "修改过程出错！");
            }
        }

        private void getPrice()
        {
            try
            {
                DataSet ds = this.bll.getCurrentPrice();
                if ((ds.Tables.Count > 0) && (ds.Tables[0].Rows.Count > 0))
                {
                    this.txtrealtime_base_price.Text = ds.Tables[0].Rows[0]["realtime_base_price"].ToString().Trim();
                }
            }
            catch
            {
                MessageBox.Show(this, "读取最新价格错误");
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
            else if (!(((this.Session["admin"] != null) && (this.Session["admin"].ToString() != "")) && CommBaseBLL.HasRight(Convert.ToInt32(this.Session["admin"]), Authority.ChgPrice.ToString())))
            {
                base.Response.Clear();
                base.Response.Write(@"<script defer>window.alert('您没有权限操作该功能！\n请重新登录或与管理员联系');history.back();</script>");
                base.Response.End();
            }
            else if (!this.Page.IsPostBack)
            {
                this.getPrice();
            }
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            (base.Master.FindControl("lblTitle") as Label).Text = "更改实时金价";
        }
    }
}
