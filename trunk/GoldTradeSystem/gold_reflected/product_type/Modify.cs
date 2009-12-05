namespace GoldTradeNaming.Web.product_type
{
    using GoldTradeNaming.BLL;
    using GoldTradeNaming.Model;
    using LTP.Common;
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Modify : Page
    {
        private string _type;
        protected Button btnAdd;
        protected Button btnCancel;
        protected DropDownList drptype;
        protected DropDownList drptype_Status;
        protected HtmlGenericControl gold;
        protected HiddenField hid_id;
        protected HiddenField hid_name;
        protected HiddenField hid_order;
        protected HiddenField hid_status;
        protected HiddenField hid_trade;
        protected HiddenField hid_type;
        protected HiddenField hid_weight;
        protected TextBox lblproduct_spec_weight;
        protected TextBox lblproduct_type_id;
        protected HtmlGenericControl silver;
        protected TextBox txtorder_add_price;
        protected TextBox txtproduct_type_name;
        protected TextBox txtsilver;
        protected TextBox txttrade_add_price;

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string strErr = "";
            if (this.txtproduct_type_name.Text.Trim() == "")
            {
                strErr = strErr + @"product_type_name不能为空！\n";
            }
            if (this.type == "0")
            {
                if (this.txtorder_add_price.Text.Trim() == "")
                {
                    strErr = strErr + @"order_add_price不能为空！\n";
                }
                if (this.txttrade_add_price.Text.Trim() == "")
                {
                    strErr = strErr + @"trade_add_price不能为空！\n";
                }
            }
            else if (this.txtsilver.Text.Trim() == "")
            {
                strErr = strErr + @"silver_price不能为空！\n";
            }
            if (strErr != "")
            {
                MessageBox.Show(this, strErr);
            }
            else
            {
                if (this.type == "0")
                {
                    if (!PageValidate.IsDecimal(this.txtorder_add_price.Text.Trim()))
                    {
                        strErr = strErr + @"order_add_price不是数字！\n";
                    }
                    if (!PageValidate.IsDecimal(this.txttrade_add_price.Text.Trim()))
                    {
                        strErr = strErr + @"trade_add_price不是数字！\n";
                    }
                }
                else if (!PageValidate.IsDecimal(this.txtsilver.Text.Trim()))
                {
                    strErr = strErr + @"silver_price不是数字！\n";
                }
                if (strErr != "")
                {
                    MessageBox.Show(this, strErr);
                }
                else if (this.drptype.Text.Trim().Equals("非升水") && !this.txtorder_add_price.Text.Trim().Equals(this.txttrade_add_price.Text.Trim()))
                {
                    MessageBox.Show(this, "订货加价和销售加价必须相等！");
                }
                else
                {
                    string product_type_id = this.lblproduct_type_id.Text.Trim();
                    string product_type_name = this.txtproduct_type_name.Text.Trim();
                    string product_spec_weight = this.lblproduct_spec_weight.Text.Trim();
                    string product_state = this.drptype_Status.Text.Trim();
                    string order_add_price = "";
                    string trade_add_price = "";
                    if (this.type == "0")
                    {
                        order_add_price = this.txtorder_add_price.Text.Trim();
                        trade_add_price = this.txttrade_add_price.Text.Trim();
                    }
                    else
                    {
                        order_add_price = this.txtsilver.Text.Trim();
                        trade_add_price = this.txtsilver.Text.Trim();
                    }
                    string type = this.drptype.Text.Trim();
                    GoldTradeNaming.Model.product_type model = new GoldTradeNaming.Model.product_type();
                    model.product_type_id = Convert.ToInt32(product_type_id);
                    model.product_type_name = product_type_name;
                    model.product_spec_weight = Convert.ToDecimal(product_spec_weight);
                    model.product_state = product_state;
                    model.order_add_price = decimal.Parse(order_add_price);
                    model.trade_add_price = decimal.Parse(trade_add_price);
                    model.type = type;
                    model.upd_user = this.Session["admin"].ToString();
                    model.upd_date = DateTime.Now;
                    GoldTradeNaming.BLL.product_type bll = new GoldTradeNaming.BLL.product_type();
                    try
                    {
                        bll.Update(model);
                        MessageBox.ShowAndRedirect(this, "更新成功", "Modify_index.aspx?id=" + this.hid_id.Value + " &name=" + this.hid_name.Value + " &kind=" + this.hid_weight.Value + " &status=" + this.hid_status.Value + " &order_add=" + this.hid_order.Value + " &trade_add=" + this.hid_trade.Value + " &type=" + this.hid_type.Value);
                    }
                    catch
                    {
                        MessageBox.Show(this, "更新失败");
                    }
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("Modify_index.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((this.Session["admin"] == null) || (this.Session["admin"].ToString() == ""))
            {
                this.Session.Clear();
                base.Response.Clear();
                MessageBox.ShowAndRedirect(this, @"您没有权限或登录超时！\n请重新登录或与管理员联系", "../User_Login/AdminLogin.aspx");
            }
            else if (!(((this.Session["admin"] != null) && (this.Session["admin"].ToString() != "")) && CommBaseBLL.HasRight(Convert.ToInt32(this.Session["admin"]), Authority.ChgProduct.ToString())))
            {
                base.Response.Clear();
                base.Response.Write(@"<script defer>window.alert('您没有权限操作该功能！\n请重新登录或与管理员联系');history.back();</script>");
                base.Response.End();
            }
            else
            {
                GridViewRow row = (GridViewRow) this.Session["tmp_row"];
                if (row.Cells[6].Text.Trim().Equals("升水"))
                {
                    this.type = "0";
                }
                else
                {
                    this.type = "1";
                }
                if (!this.Page.IsPostBack)
                {
                    try
                    {
                        this.hid_id.Value = base.Request.QueryString["id"].ToString().Trim();
                    }
                    catch
                    {
                        this.hid_id.Value = "";
                    }
                    try
                    {
                        this.hid_name.Value = base.Request.QueryString["name"].ToString().Trim();
                    }
                    catch
                    {
                        this.hid_name.Value = "";
                    }
                    try
                    {
                        this.hid_weight.Value = base.Request.QueryString["kind"].ToString().Trim();
                    }
                    catch
                    {
                        this.hid_weight.Value = "";
                    }
                    try
                    {
                        this.hid_status.Value = base.Request.QueryString["status"].ToString().Trim();
                    }
                    catch
                    {
                        this.hid_status.Value = "";
                    }
                    try
                    {
                        this.hid_order.Value = base.Request.QueryString["order_add"].ToString().Trim();
                    }
                    catch
                    {
                        this.hid_order.Value = "";
                    }
                    try
                    {
                        this.hid_trade.Value = base.Request.QueryString["trade_add"].ToString().Trim();
                    }
                    catch
                    {
                        this.hid_trade.Value = "";
                    }
                    try
                    {
                        this.hid_type.Value = base.Request.QueryString["type"].ToString().Trim();
                    }
                    catch
                    {
                        this.hid_type.Value = "";
                    }
                    this.gold.Visible = false;
                    this.silver.Visible = false;
                    this.lblproduct_type_id.Text = row.Cells[0].Text.ToString().Trim();
                    this.txtproduct_type_name.Text = row.Cells[1].Text.ToString().Trim();
                    this.lblproduct_spec_weight.Text = row.Cells[2].Text.ToString().Trim();
                    if (row.Cells[3].Text.Trim().Equals("启用"))
                    {
                        this.drptype_Status.SelectedIndex = 0;
                    }
                    else
                    {
                        this.drptype_Status.SelectedIndex = 1;
                    }
                    if (row.Cells[6].Text.Trim().Equals("升水"))
                    {
                        this.gold.Visible = true;
                        this.txtorder_add_price.Text = row.Cells[4].Text.ToString().Trim();
                        this.txttrade_add_price.Text = row.Cells[5].Text.ToString().Trim();
                    }
                    else
                    {
                        this.silver.Visible = true;
                        this.txtsilver.Text = row.Cells[4].Text.ToString().Trim();
                    }
                    if (row.Cells[6].Text.Trim().Equals("升水"))
                    {
                        this.drptype.SelectedIndex = 0;
                    }
                    else
                    {
                        this.drptype.SelectedIndex = 1;
                    }
                }
            }
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            (base.Master.FindControl("lblTitle") as Label).Text = "修改产品";
        }

        private void ShowInfo(int product_type_id, int product_spec_weight)
        {
            GoldTradeNaming.Model.product_type model = new GoldTradeNaming.BLL.product_type().GetModel(product_type_id, product_spec_weight);
            this.lblproduct_type_id.Text = model.product_type_id.ToString();
            this.txtproduct_type_name.Text = model.product_type_name;
            this.lblproduct_spec_weight.Text = model.product_spec_weight.ToString();
        }

        public string type
        {
            get
            {
                return this._type;
            }
            set
            {
                this._type = value;
            }
        }
    }
}
