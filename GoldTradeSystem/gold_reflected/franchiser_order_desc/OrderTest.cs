namespace GoldTradeNaming.Web.franchiser_order_desc
{
    using Anthem;
    using GoldTradeNaming.BLL;
    using GoldTradeNaming.Model;
    using LTP.Common;
    using System;
    using System.Data;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public class OrderTest : Page
    {
        protected Anthem.GridView GridView1;
        protected System.Web.UI.WebControls.ImageButton ImageButton1;
        protected System.Web.UI.WebControls.ImageButton ImageButton2;
        protected System.Web.UI.WebControls.Label Label1;
        protected System.Web.UI.WebControls.Label lblAmount;
        private GoldTradeNaming.Model.franchiser_order mOrderMain = new GoldTradeNaming.Model.franchiser_order();
        protected System.Web.UI.WebControls.Button Next;
        protected System.Web.UI.WebControls.Panel Panel1;
        private int row = 0;

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[0].Visible = false;
            e.Row.Cells[5].Visible = false;
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int rowindex = e.Row.RowIndex;
            if ((rowindex - 1) >= 0)
            {
                if (e.Row.Cells[0].Text == this.GridView1.Rows[rowindex - 1].Cells[0].Text)
                {
                    if (this.GridView1.Rows[this.row].Cells[1].RowSpan == 0)
                    {
                        TableCell cell1 = this.GridView1.Rows[this.row].Cells[1];
                        cell1.RowSpan++;
                    }
                    TableCell cell2 = this.GridView1.Rows[this.row].Cells[1];
                    cell2.RowSpan++;
                    e.Row.Cells[1].Visible = false;
                }
                else
                {
                    this.row = rowindex;
                }
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            this.LoadData("0");
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            this.LoadData("1");
        }

        private void LoadData(string type)
        {
            DataSet ds;
            GoldTradeNaming.BLL.franchiser_order orderbll = new GoldTradeNaming.BLL.franchiser_order();
            if (type == "0")
            {
                ds = orderbll.GetGoldProduct();
            }
            else
            {
                if (!(type == "1"))
                {
                    return;
                }
                ds = orderbll.GetSilverProduct();
            }
            this.GridView1.UpdateAfterCallBack = true;
            this.GridView1.DataSource = ds;
            this.GridView1.DataBind();
        }

        protected void Next_Click(object sender, EventArgs e)
        {
            try
            {
                this.mOrderMain = new GoldTradeNaming.Model.franchiser_order();
                foreach (GridViewRow gvr in this.GridView1.Rows)
                {
                    if ((((System.Web.UI.WebControls.TextBox) gvr.FindControl("txtProdNum")).Text.Trim() != "") && (((System.Web.UI.WebControls.Label) gvr.FindControl("lblProdWht")).Text.Trim() != ""))
                    {
                        GoldTradeNaming.Model.franchiser_order_desc odrDesc = new GoldTradeNaming.Model.franchiser_order_desc();
                        odrDesc.id = 0;
                        odrDesc.franchiser_order_id = 0;
                        odrDesc.order_product_amount = Convert.ToInt32(((System.Web.UI.WebControls.TextBox) gvr.FindControl("txtProdNum")).Text.Trim());
                        odrDesc.product_id = Convert.ToInt32(gvr.Cells[0].Text);
                        odrDesc.product_spec_id = Convert.ToDecimal(gvr.Cells[2].Text);
                        odrDesc.product_received = 0M;
                        odrDesc.product_unreceived = Convert.ToDecimal(((System.Web.UI.WebControls.Label) gvr.FindControl("lblProdWht")).Text.Trim());
                        odrDesc.realtime_base_price = CommBaseBLL.getRealTimePrice();
                        odrDesc.order_add_price = Convert.ToDecimal(gvr.Cells[5].Text);
                        odrDesc.order_appraise = Convert.ToDecimal(gvr.Cells[6].Text);
                        odrDesc.order_weight = Convert.ToDecimal(((System.Web.UI.WebControls.Label) gvr.FindControl("lblProdWht")).Text.Trim());
                        odrDesc.ins_date = DateTime.Now;
                        odrDesc.ins_user = this.Session["fran"] as string;
                        odrDesc.upd_date = DateTime.Now;
                        odrDesc.upd_user = this.Session["fran"] as string;
                        this.mOrderMain.franchiser_order_amount_money += decimal.Round(odrDesc.order_weight * odrDesc.order_appraise, 4);
                    }
                }
                this.lblAmount.Text = "预估总额为：" + this.mOrderMain.franchiser_order_amount_money.ToString() + "元";
            }
            catch
            {
                this.lblAmount.Text = "计算发生错误！";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((this.Session["fran"] == null) || (this.Session["fran"].ToString() == ""))
            {
                this.Session.Clear();
                base.Response.Clear();
                MessageBox.ShowAndRedirect(this, @"您没有权限或登录超时！\n请重新登录或与管理员联系", "../User_Login/flogin.aspx");
            }
            else if (!base.IsPostBack)
            {
            }
        }

        protected void ProdNumChge(object sender, EventArgs e)
        {
            System.Web.UI.WebControls.TextBox t = (System.Web.UI.WebControls.TextBox) sender;
            decimal ProdWht = 0M;
            decimal appriseMoney = 0M;
            GridViewRow drv = (GridViewRow) t.NamingContainer;
            int rowIndex = drv.RowIndex;
            try
            {
                decimal spec_weight = Convert.ToInt32(this.GridView1.Rows[drv.RowIndex].Cells[2].Text.ToString());
                decimal appraise = Convert.ToDecimal(this.GridView1.Rows[drv.RowIndex].Cells[6].Text.ToString());
                try
                {
                    ProdWht = Convert.ToInt32(t.Text.Trim()) * spec_weight;
                }
                catch
                {
                    ((System.Web.UI.WebControls.Label) this.GridView1.Rows[drv.RowIndex].FindControl("lblProdWht")).Text = "";
                    ((System.Web.UI.WebControls.Label) this.GridView1.Rows[drv.RowIndex].FindControl("lblAmountMoney")).Text = "";
                    return;
                }
                appriseMoney = ProdWht * appraise;
                ((System.Web.UI.WebControls.Label) this.GridView1.Rows[drv.RowIndex].FindControl("lblProdWht")).Text = ProdWht.ToString();
                ((System.Web.UI.WebControls.Label) this.GridView1.Rows[drv.RowIndex].FindControl("lblAmountMoney")).Text = appriseMoney.ToString();
                this.GridView1.UpdateAfterCallBack = true;
            }
            catch (Exception)
            {
                ((System.Web.UI.WebControls.Label) this.GridView1.Rows[drv.RowIndex].FindControl("lblProdWht")).Text = "";
                ((System.Web.UI.WebControls.Label) this.GridView1.Rows[drv.RowIndex].FindControl("lblAmountMoney")).Text = "";
            }
        }
    }
}
