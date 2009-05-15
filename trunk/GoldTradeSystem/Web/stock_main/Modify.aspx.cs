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
namespace GoldTradeNaming.Web.stock_main
{
    public partial class Modify : System.Web.UI.Page
    {

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            (Master.FindControl("lblTitle") as Label).Text = "信息修改";
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
                    || !GoldTradeNaming.BLL.CommBaseBLL.HasRight(Convert.ToInt32(Session["admin"]), Model.Authority.StockMgn.ToString()))
            {
                Response.Clear();
                Response.Write("<script defer>window.alert('" + "您没有权限操作该功能！\\n请重新登录或与管理员联系" + "');history.back();</script>");
                Response.End();
                return;
            }
            if (!Page.IsPostBack)
            {
                if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
                {
                    string id = Request.Params["id"];

                    ShowInformation(Convert.ToInt32(id));
                    ViewState["stock_total_temp"] = txtstock_total.Text;
                    ViewState["stock_left_temp"] = txtstock_left.Text;
                }
            }
        }

        private void ShowInformation(int id)
        {
            try
            {
                GoldTradeNaming.BLL.stock_main bll = new GoldTradeNaming.BLL.stock_main();
                GoldTradeNaming.Model.stock_main model = bll.GetModel(id);
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


        protected void btnAdd_Click(object sender, EventArgs e)
        {
            #region validate value

            string strErr = "";

            if (!PageValidate.IsNumber(txtstock_total.Text))
            {
                strErr += "stock_total不是数字！\\n";
            }
            if (!PageValidate.IsNumber(txtstock_left.Text))
            {
                strErr += "stock_left不是数字！\\n";
            }

            if (strErr != "")
            {
                MessageBox.Show(this, strErr);
                return;
            }
            #endregion

            #region assign
            string franchiser_code = this.txtfranchiser_code.Text;
            int product_id = int.Parse(this.txtproduct_id.Text);
           // int product_spec_id = int.Parse(this.txtproduct_spec_id.Text);
            decimal product_spec_id = Convert.ToDecimal(this.txtproduct_spec_id.Text);
            //int stock_left = int.Parse(this.txtstock_left.Text) * product_spec_id;
            decimal stock_left = Convert.ToDecimal(this.txtstock_left.Text) * product_spec_id;

            //修改量，一般为负数
            decimal temp = Convert.ToDecimal(this.txtstock_left.Text) - Convert.ToDecimal(ViewState["stock_left_temp"].ToString());
            
            decimal stock_total = Convert.ToDecimal(this.txtstock_total.Text);
            stock_total = (stock_total + temp) * product_spec_id;

            string ins_user = this.txtins_user.Text;
            DateTime ins_date = DateTime.Parse(this.txtins_date.Text);
            string upd_user = this.txtupd_user.Text;
            DateTime upd_date = DateTime.Parse(this.txtupd_date.Text);


            GoldTradeNaming.Model.stock_main model = new GoldTradeNaming.Model.stock_main();
            model.id = int.Parse(Request.Params["id"].ToString());
            model.franchiser_code = franchiser_code;
            model.product_id = product_id;
            model.product_spec_id = product_spec_id;
            model.stock_total = stock_total;
            model.stock_left = stock_left;
            model.changeMount = temp;
            model.ins_user = ins_user;
            model.ins_date = ins_date;
            model.upd_date = upd_date;
            model.upd_user = Session["admin"].ToString();
            #endregion
            try
            {

                GoldTradeNaming.BLL.stock_main bll = new GoldTradeNaming.BLL.stock_main();
                if (bll.updateStock1(model))
                {
                    MessageBox.ShowAndRedirect(this, "修改成功", String.Format("../stock_main/Show.aspx?id={0}", Request.Params["franchiser_code"].ToString()));
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

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(String.Format("../stock_main/Show.aspx?id={0}", Request.Params["franchiser_code"].ToString()));

            // Response.Redirect(String.Format("../stock_main/Show.aspx?id={0}",myid));
        }

        protected void txtstock_left_TextChanged(object sender, EventArgs e)
        {
        }

    }
}
