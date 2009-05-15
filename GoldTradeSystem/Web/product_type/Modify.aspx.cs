using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using LTP.Common;
namespace GoldTradeNaming.Web.product_type
{
    public partial class Modify : System.Web.UI.Page
    {

        private string _type;
        public string type
        {

            set { _type = value; }
            get { return _type; }
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            (Master.FindControl("lblTitle") as Label).Text = "修改产品";

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] == null || Session["admin"].ToString() == "")
            {
                Session.Clear();
                Response.Clear();
                LTP.Common.MessageBox.ShowAndRedirect(this, "您没有权限或登录超时！\\n请重新登录或与管理员联系", "../User_Login/AdminLogin.aspx");
                return;
            }

            if (Session["admin"] == null || Session["admin"].ToString() == ""
                    || !GoldTradeNaming.BLL.CommBaseBLL.HasRight(Convert.ToInt32(Session["admin"]), Model.Authority.ChgProduct.ToString()))
            {
                Response.Clear();
                Response.Write("<script defer>window.alert('" + "您没有权限操作该功能！\\n请重新登录或与管理员联系" + "');history.back();</script>");
                Response.End();
                return;
            }
            GridViewRow row = (GridViewRow)Session["tmp_row"];
            if (row.Cells[6].Text.Trim().Equals("升水"))
            { this.type = "0"; }
            else { this.type = "1"; }
            if (!Page.IsPostBack)
            {
                try
                {
                    hid_id.Value = Request.QueryString["id"].ToString().Trim();
                }
                catch
                {
                    hid_id.Value = "";
                }

                try
                {
                    hid_name.Value = Request.QueryString["name"].ToString().Trim();
                }
                catch
                {
                    hid_name.Value = "";
                }
                try
                {
                    hid_weight.Value = Request.QueryString["kind"].ToString().Trim();
                }
                catch
                {
                    hid_weight.Value = "";
                }
                try
                {
                    hid_status.Value = Request.QueryString["status"].ToString().Trim();
                }
                catch
                {
                    hid_status.Value = "";
                }
                try
                {
                    hid_order.Value = Request.QueryString["order_add"].ToString().Trim();
                }
                catch
                {
                    hid_order.Value = "";
                }
                try
                {
                    hid_trade.Value = Request.QueryString["trade_add"].ToString().Trim();
                }
                catch
                {
                    hid_trade.Value = "";
                }
                try
                {
                    hid_type.Value = Request.QueryString["type"].ToString().Trim();
                }
                catch
                {
                    hid_type.Value = "";
                }

                //Modify_index page = (Modify_index)Context.Handler
                gold.Visible = false;
                silver.Visible = false;




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

                    gold.Visible = true;
                    this.txtorder_add_price.Text = row.Cells[4].Text.ToString().Trim();
                    this.txttrade_add_price.Text = row.Cells[5].Text.ToString().Trim();
                }
                else
                {

                    silver.Visible = true;
                    this.txtsilver.Text = row.Cells[4].Text.ToString().Trim();
                }




                if (row.Cells[6].Text.Trim().Equals("升水"))

                    this.drptype.SelectedIndex = 0;
                else
                {
                    this.drptype.SelectedIndex = 1;

                }
             

            }

        }

        private void ShowInfo(int product_type_id, int product_spec_weight)
        {
            GoldTradeNaming.BLL.product_type bll = new GoldTradeNaming.BLL.product_type();
            GoldTradeNaming.Model.product_type model = bll.GetModel(product_type_id, product_spec_weight);
            this.lblproduct_type_id.Text = model.product_type_id.ToString();
            this.txtproduct_type_name.Text = model.product_type_name;
            this.lblproduct_spec_weight.Text = model.product_spec_weight.ToString();
            //this.txtproduct_state.Text = model.product_state;
            //this.txtins_user.Text = model.ins_user;
            //this.txtins_date.Text=model.ins_date.ToString();
            //this.txtupd_user.Text=model.upd_user;
            //this.txtupd_date.Text=model.upd_date.ToString();

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {

            string strErr = "";
            if (this.txtproduct_type_name.Text.Trim() == "")
            {
                strErr += "product_type_name不能为空！\\n";
            }

            if (this.type == "0")
            {

                if (this.txtorder_add_price.Text.Trim() == "")
                {
                    strErr += "order_add_price不能为空！\\n";
                }
                if (this.txttrade_add_price.Text.Trim() == "")
                {
                    strErr += "trade_add_price不能为空！\\n";
                }
            }
            else {
                if (this.txtsilver.Text.Trim() == "")
                {
                    strErr += "silver_price不能为空！\\n";
                }
            
            }
            if (strErr != "")
            {
                MessageBox.Show(this, strErr);
                return;
            }

            if (this.type == "0")
            {

                if (!PageValidate.IsDecimal(txtorder_add_price.Text.Trim()))
                {
                    strErr += "order_add_price不是数字！\\n";
                }
                if (!PageValidate.IsDecimal(txttrade_add_price.Text.Trim()))
                {
                    strErr += "trade_add_price不是数字！\\n";
                }
            }
            else {
                if (!PageValidate.IsDecimal(this.txtsilver.Text.Trim()))
                {
                    strErr += "silver_price不是数字！\\n";
                }
            
            
            }
            if (strErr != "")
            {
                MessageBox.Show(this, strErr);
                return;
            }
            if (this.drptype.Text.Trim().Equals("非升水"))
            {
                if (!this.txtorder_add_price.Text.Trim().Equals(this.txttrade_add_price.Text.Trim()))
                {
                    MessageBox.Show(this, "订货加价和销售加价必须相等！");
                    return;
                }

            }


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
            else {

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
            model.upd_user = Session["admin"].ToString();
            model.upd_date = DateTime.Now;

            GoldTradeNaming.BLL.product_type bll = new GoldTradeNaming.BLL.product_type();

            try
            {
                bll.Update(model);
                MessageBox.ShowAndRedirect(this, "更新成功", "Modify_index.aspx?id=" + hid_id.Value + " &name=" + hid_name.Value + " &kind=" + hid_weight.Value + " &status=" + hid_status.Value + " &order_add=" + hid_order.Value + " &trade_add=" + hid_trade.Value + " &type=" + hid_type.Value);
            }
            catch
            {
                MessageBox.Show(this, "更新失败");
            }




        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Modify_index.aspx");
        }

        



      





    }
}
