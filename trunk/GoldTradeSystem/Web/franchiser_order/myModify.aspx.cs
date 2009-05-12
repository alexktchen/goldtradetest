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

namespace GoldTradeNaming.Web.franchiser_order
{
    public partial class myModify:System.Web.UI.Page
    {

        GoldTradeNaming.BLL.franchiser_order bll = new GoldTradeNaming.BLL.franchiser_order();
        protected void Page_Load(object sender,EventArgs e)
        {
            if(!IsPostBack)
            {
                if(Session["admin"] == null || Session["admin"].ToString() == "" || Session["OrderM"] == null || Session["OrderM"].ToString() == "")
                {
                    Response.Clear();
                    Response.Write("<script defer>window.alert('" + "您没有权限登录本系统！\\n请重新登录或与管理员联系" + "');history.back();</script>");
                    Response.End();
                    return;
                }
                drpfranchiser_order_state.SelectedValue = "0";
                drpfranchiser_order_state.Enabled = false;
                plModify.Style.Add("display","none");
                plSearch.Style.Add("display","block");

            }
        }

        protected void query_Click(object sender,EventArgs e)
        {
            SearchInfo();

        }

        private void SearchInfo()
        {
            StringBuilder sb = new StringBuilder();


            if(this.txtFranID.Text.Trim() == "")
            {
                sb.Append(" 1=1 ");
            }
            else
            {
                sb.Append(" franchiser_code='" + Convert.ToString(this.txtFranID.Text.Trim()) + "'");
            }

            if(txtfranchiser_order_id.Text.Trim() == "")
            {
                sb.Append(" AND 1=1 ");
            }
            else
            {
                sb.Append(" AND franchiser_order_id = '");
                sb.Append(this.txtfranchiser_order_id.Text.Trim());
                sb.Append("'");
            }

            sb.Append("AND franchiser_order_state='" + drpfranchiser_order_state.SelectedValue.ToString().Trim() + "'");

            DataSet ds = bll.GetOrderInfo(sb.ToString());
            Session["datasrc"] = ds;
            this.GridView1.DataSource = Session["datasrc"] as DataSet;
            this.GridView1.DataBind();
        }

        protected void GridView1_PageIndexChanging(object sender,GridViewPageEventArgs e)
        {
            this.GridView1.PageIndex = e.NewPageIndex;
            this.GridView1.DataSource = Session["datasrc"] as DataSet;
            this.GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender,EventArgs e)
        {
            plModify.Style.Add("display","block");
            plSearch.Style.Add("display","none");


            GridViewRow gvw = this.GridView1.SelectedRow;
            this.lblOrderNum.Text = GridView1.DataKeys[GridView1.SelectedIndex].Value.ToString().Trim();
            this.lblPrice.Text = gvw.Cells[9].Text.Trim();
            this.lblTotalMoney.Text = gvw.Cells[2].Text.Trim();

            switch(gvw.Cells[3].Text.Trim())
            {
                case "航空":
                    this.transway.SelectedValue = "0";
                    break;
                case "邮寄":
                    this.transway.SelectedValue = "1";
                    break;
                case "自取":
                    this.transway.SelectedValue = "2";
                    break;
                default:
                    this.transway.SelectedValue = "3";
                    break;

            }

            this.txtfranchiser_order_address.Text = gvw.Cells[4].Text.Trim();
            this.txtfranchiser_order_postcode.Text = gvw.Cells[5].Text.Trim();
            this.txtfranchiser_order_handle_man.Text = gvw.Cells[6].Text.Trim();
            this.txtfranchiser_order_handle_tel.Text = gvw.Cells[7].Text.Trim();
            this.txtfranchiser_order_handle_phone.Text = gvw.Cells[8].Text.Trim();
        }

        protected void reset_Click(object sender,EventArgs e)
        {
            this.txtfranchiser_order_id.Text = "";
            this.txtFranID.Text = "";
        }

        protected void btnCancel_Click(object sender,EventArgs e)
        {
            plModify.Style.Add("display","none");
            plSearch.Style.Add("display","block");
        }

        protected void btnSave_Click(object sender,EventArgs e)
        {
            //string sTransway = 
            // string sFranchiser_order_address = txtfranchiser_order_address.Text.Trim();
            //string Franchiser_order_postcode = txtfranchiser_order_postcode.Text.Trim();
            // string sFranchiser_order_handle_man = txtfranchiser_order_handle_man.Text.Trim();
            //  string sFranchiser_order_handle_tel = txtfranchiser_order_handle_tel.Text.Trim();
            //string sFranchiser_order_handle_phone = txtfranchiser_order_handle_phone.Text.Trim();


            Model.franchiser_order orderInfo = new GoldTradeNaming.Model.franchiser_order();
            orderInfo.franchiser_order_id = Convert.ToInt32(lblOrderNum.Text.Trim());
            orderInfo.franchiser_order_trans_type = transway.SelectedValue.Trim();
            orderInfo.franchiser_order_address = txtfranchiser_order_address.Text.Trim();
            orderInfo.franchiser_order_postcode = txtfranchiser_order_postcode.Text.Trim();
            orderInfo.franchiser_order_handle_man = txtfranchiser_order_handle_man.Text.Trim();
            orderInfo.franchiser_order_handle_tel = txtfranchiser_order_handle_tel.Text.Trim();
            orderInfo.franchiser_order_handle_phone = txtfranchiser_order_handle_phone.Text.Trim();
            orderInfo.upd_user = Session["admin"].ToString().Trim();

            if(bll.UpdateOrderInfo(orderInfo) == 1)
            {
                MessageBox.Show(this,"保存成功！");
                SearchInfo();
                plModify.Style.Add("display","none");
                plSearch.Style.Add("display","block");
            }
        }
    }
}
