namespace GoldTradeNaming.Web.franchiser_order
{
    using GoldTradeNaming.BLL;
    using GoldTradeNaming.Model;
    using LTP.Common;
    using System;
    using System.Data;
    using System.Text;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public class myModify : Page
    {
        private GoldTradeNaming.BLL.franchiser_order bll = new GoldTradeNaming.BLL.franchiser_order();
        protected Button btnCancel;
        protected Button btnSave;
        protected DropDownList drpfranchiser_order_state;
        protected GridView GridView1;
        protected Label lblMsg;
        protected Label lblOrderNum;
        protected Label lblPrice;
        protected Label lblTotalMoney;
        protected Panel plModify;
        protected Panel plSearch;
        protected Button query;
        protected Button reset;
        protected RadioButtonList transway;
        protected TextBox txtfranchiser_order_address;
        protected TextBox txtfranchiser_order_handle_man;
        protected TextBox txtfranchiser_order_handle_phone;
        protected TextBox txtfranchiser_order_handle_tel;
        protected TextBox txtfranchiser_order_id;
        protected TextBox txtfranchiser_order_postcode;
        protected TextBox txtFranID;

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            this.plModify.Style.Add("display", "none");
            this.plSearch.Style.Add("display", "block");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            GoldTradeNaming.Model.franchiser_order orderInfo = new GoldTradeNaming.Model.franchiser_order();
            orderInfo.franchiser_order_id = Convert.ToInt32(this.lblOrderNum.Text.Trim());
            orderInfo.franchiser_order_trans_type = this.transway.SelectedValue.Trim();
            orderInfo.franchiser_order_address = this.txtfranchiser_order_address.Text.Trim();
            orderInfo.franchiser_order_postcode = this.txtfranchiser_order_postcode.Text.Trim();
            orderInfo.franchiser_order_handle_man = this.txtfranchiser_order_handle_man.Text.Trim();
            orderInfo.franchiser_order_handle_tel = this.txtfranchiser_order_handle_tel.Text.Trim();
            orderInfo.franchiser_order_handle_phone = this.txtfranchiser_order_handle_phone.Text.Trim();
            orderInfo.upd_user = this.Session["admin"].ToString().Trim();
            if (this.bll.UpdateOrderInfo(orderInfo) == 1)
            {
                MessageBox.Show(this, "保存成功！");
                this.SearchInfo();
                this.plModify.Style.Add("display", "none");
                this.plSearch.Style.Add("display", "block");
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridView1.PageIndex = e.NewPageIndex;
            this.GridView1.DataSource = this.Session["datasrc"] as DataSet;
            this.GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.plModify.Style.Add("display", "block");
            this.plSearch.Style.Add("display", "none");
            GridViewRow gvw = this.GridView1.SelectedRow;
            this.lblOrderNum.Text = this.GridView1.DataKeys[this.GridView1.SelectedIndex].Value.ToString().Trim();
            this.lblPrice.Text = gvw.Cells[9].Text.Trim();
            this.lblTotalMoney.Text = gvw.Cells[2].Text.Trim();
            string CS40000 = gvw.Cells[3].Text.Trim();
            if (CS40000 != null)
            {
                if (!(CS40000 == "航空"))
                {
                    if (CS40000 == "邮寄")
                    {
                        this.transway.SelectedValue = "1";
                        goto Label_014D;
                    }
                    if (CS40000 == "自取")
                    {
                        this.transway.SelectedValue = "2";
                        goto Label_014D;
                    }
                }
                else
                {
                    this.transway.SelectedValue = "0";
                    goto Label_014D;
                }
            }
            this.transway.SelectedValue = "3";
        Label_014D:
            this.txtfranchiser_order_address.Text = gvw.Cells[4].Text.Trim();
            this.txtfranchiser_order_postcode.Text = gvw.Cells[5].Text.Trim();
            this.txtfranchiser_order_handle_man.Text = gvw.Cells[6].Text.Trim();
            this.txtfranchiser_order_handle_tel.Text = gvw.Cells[7].Text.Trim();
            this.txtfranchiser_order_handle_phone.Text = gvw.Cells[8].Text.Trim();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((this.Session["admin"] == null) || (this.Session["admin"].ToString() == ""))
            {
                this.Session.Clear();
                base.Response.Clear();
                MessageBox.ShowAndRedirect(this, @"您没有权限或登录超时！\n请重新登录或与管理员联系", "../User_Login/AdminLogin.aspx");
            }
            else if (!(((this.Session["admin"] != null) && (this.Session["admin"].ToString() != "")) && CommBaseBLL.HasRight(Convert.ToInt32(this.Session["admin"]), Authority.ViewOrder.ToString())))
            {
                base.Response.Clear();
                base.Response.Write(@"<script defer>window.alert('您没有权限操作该功能！\n请重新登录或与管理员联系');history.back();</script>");
                base.Response.End();
            }
            else if (!base.IsPostBack)
            {
                this.drpfranchiser_order_state.SelectedValue = "0";
                this.drpfranchiser_order_state.Enabled = false;
                this.plModify.Style.Add("display", "none");
                this.plSearch.Style.Add("display", "block");
            }
        }

        protected void query_Click(object sender, EventArgs e)
        {
            this.SearchInfo();
        }

        protected void reset_Click(object sender, EventArgs e)
        {
            this.txtfranchiser_order_id.Text = "";
            this.txtFranID.Text = "";
        }

        private void SearchInfo()
        {
            StringBuilder sb = new StringBuilder();
            if (this.txtFranID.Text.Trim() == "")
            {
                sb.Append(" 1=1 ");
            }
            else
            {
                sb.Append(" franchiser_code='" + Convert.ToString(this.txtFranID.Text.Trim()) + "'");
            }
            if (this.txtfranchiser_order_id.Text.Trim() == "")
            {
                sb.Append(" AND 1=1 ");
            }
            else
            {
                sb.Append(" AND franchiser_order_id = '");
                sb.Append(this.txtfranchiser_order_id.Text.Trim());
                sb.Append("'");
            }
            sb.Append("AND franchiser_order_state='" + this.drpfranchiser_order_state.SelectedValue.ToString().Trim() + "'");
            DataSet ds = this.bll.GetOrderInfo(sb.ToString());
            this.Session["datasrc"] = ds;
            this.GridView1.DataSource = this.Session["datasrc"] as DataSet;
            this.GridView1.DataBind();
        }
    }
}
