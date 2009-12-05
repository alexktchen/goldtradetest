namespace GoldTradeNaming.Web.stock_main
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
        protected Label lblid;
        protected TextBox txtfranchiser_code;
        protected TextBox txtFranchiser_name;
        protected TextBox txtins_date;
        protected TextBox txtins_user;
        protected TextBox txtproduct_id;
        protected TextBox txtproduct_name;
        protected TextBox txtproduct_spec_id;
        protected TextBox txtstock_left;
        protected TextBox txtstock_total;
        protected TextBox txtupd_date;
        protected TextBox txtupd_user;

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string strErr = "";
            if (!PageValidate.IsNumber(this.txtstock_total.Text))
            {
                strErr = strErr + @"stock_total不是数字！\n";
            }
            if (!PageValidate.IsNumber(this.txtstock_left.Text))
            {
                strErr = strErr + @"stock_left不是数字！\n";
            }
            if (strErr != "")
            {
                MessageBox.Show(this, strErr);
            }
            else
            {
                string franchiser_code = this.txtfranchiser_code.Text;
                int product_id = int.Parse(this.txtproduct_id.Text);
                decimal product_spec_id = Convert.ToDecimal(this.txtproduct_spec_id.Text);
                decimal stock_left = Convert.ToDecimal(this.txtstock_left.Text) * product_spec_id;
                decimal temp = Convert.ToDecimal(this.txtstock_left.Text) - Convert.ToDecimal(this.ViewState["stock_left_temp"].ToString());
                decimal stock_total = (Convert.ToDecimal(this.txtstock_total.Text) + temp) * product_spec_id;
                string ins_user = this.txtins_user.Text;
                DateTime ins_date = DateTime.Parse(this.txtins_date.Text);
                string upd_user = this.txtupd_user.Text;
                DateTime upd_date = DateTime.Parse(this.txtupd_date.Text);
                GoldTradeNaming.Model.stock_main model = new GoldTradeNaming.Model.stock_main();
                model.id = int.Parse(base.Request.Params["id"].ToString());
                model.franchiser_code = franchiser_code;
                model.product_id = product_id;
                model.product_spec_id = product_spec_id;
                model.stock_total = stock_total;
                model.stock_left = stock_left;
                model.changeMount = temp;
                model.ins_user = ins_user;
                model.ins_date = ins_date;
                model.upd_date = upd_date;
                model.upd_user = this.Session["admin"].ToString();
                try
                {
                    GoldTradeNaming.BLL.stock_main bll = new GoldTradeNaming.BLL.stock_main();
                    if (bll.updateStock1(model))
                    {
                        MessageBox.ShowAndRedirect(this, "修改成功", string.Format("../stock_main/Show.aspx?id={0}", base.Request.Params["franchiser_code"].ToString()));
                    }
                    else
                    {
                        MessageBox.Show(this, "修改库存失败");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.ToString());
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            base.Response.Redirect(string.Format("../stock_main/Show.aspx?id={0}", base.Request.Params["franchiser_code"].ToString()));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((this.Session["admin"] == null) || (this.Session["admin"].ToString() == ""))
            {
                this.Session.Clear();
                base.Response.Clear();
                MessageBox.ShowAndRedirect(this, @"您没有权限或登录超时！\n请重新登录或与管理员联系", "../User_Login/AdminLogin.aspx");
            }
            else if (!(((this.Session["admin"] != null) && (this.Session["admin"].ToString() != "")) && CommBaseBLL.HasRight(Convert.ToInt32(this.Session["admin"]), Authority.StockMgn.ToString())))
            {
                base.Response.Clear();
                base.Response.Write(@"<script defer>window.alert('您没有权限操作该功能！\n请重新登录或与管理员联系');history.back();</script>");
                base.Response.End();
            }
            else if (!this.Page.IsPostBack && ((base.Request.Params["id"] != null) && (base.Request.Params["id"].Trim() != "")))
            {
                string id = base.Request.Params["id"];
                this.ShowInformation(Convert.ToInt32(id));
                this.ViewState["stock_total_temp"] = this.txtstock_total.Text;
                this.ViewState["stock_left_temp"] = this.txtstock_left.Text;
            }
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            (base.Master.FindControl("lblTitle") as Label).Text = "信息修改";
        }

        private void ShowInformation(int id)
        {
            try
            {
                GoldTradeNaming.Model.stock_main model = new GoldTradeNaming.BLL.stock_main().GetModel(id);
                this.lblid.Text = model.id.ToString();
                this.txtFranchiser_name.Text = model.franchiser_name.ToString();
                this.txtfranchiser_code.Text = model.franchiser_code;
                this.txtproduct_id.Text = model.product_id.ToString();
                this.txtproduct_spec_id.Text = model.product_spec_id.ToString();
                this.txtstock_total.Text = (model.stock_total / model.product_spec_id).ToString();
                this.txtstock_left.Text = (model.stock_left / model.product_spec_id).ToString();
                this.txtins_user.Text = model.ins_user.ToString();
                this.txtins_date.Text = model.ins_date.ToString();
                this.txtupd_user.Text = model.upd_user.ToString();
                this.txtupd_date.Text = model.upd_date.ToString();
                this.txtproduct_name.Text = model.product_name.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.ToString());
            }
        }

        protected void txtstock_left_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
