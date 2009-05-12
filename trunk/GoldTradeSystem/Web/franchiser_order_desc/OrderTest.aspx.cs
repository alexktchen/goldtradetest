using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using GoldTradeNaming.BLL;
namespace GoldTradeNaming.Web.franchiser_order_desc
{
    public partial class OrderTest : System.Web.UI.Page
    {
        private GoldTradeNaming.Model.franchiser_order mOrderMain = new GoldTradeNaming.Model.franchiser_order();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["fran"] == null || Session["fran"].ToString() == "" )
                {
                    Response.Clear();
                    Response.Write("<script defer>window.alert('" + "您没有权限登录本系统！\\n请重新登录或与管理员联系" + "');history.back();</script>");
                    Response.End();
                    return;
                }
               // LoadData();
            }
        }

        private void LoadData(string type)
        {
            GoldTradeNaming.BLL.franchiser_order orderbll = new GoldTradeNaming.BLL.franchiser_order();

            DataSet ds;

            if (type == "0")
            {
                ds = orderbll.GetGoldProduct();
            }
            else if (type == "1")
            {
                ds = orderbll.GetSilverProduct();
            }
            else return;
            GridView1.UpdateAfterCallBack = true;
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            LoadData("0");
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            LoadData("1");
        }    

        protected void ProdNumChge(object sender, EventArgs e)
        {
            TextBox t = (TextBox)sender;
            int mount = 0;//数量
            decimal ProdWht = 0; //重量小计
            decimal appriseMoney = 0;//预估金额

            GridViewRow drv = (GridViewRow)t.NamingContainer;
            int rowIndex = drv.RowIndex;
            try
            {
                //规格重量
                decimal spec_weight = Convert.ToInt32(GridView1.Rows[drv.RowIndex].Cells[2].Text.ToString());
                //预估单价
                decimal appraise = Convert.ToDecimal(GridView1.Rows[drv.RowIndex].Cells[6].Text.ToString());

                try
                {
                    mount = Convert.ToInt32(t.Text.Trim());
                    ProdWht = mount * spec_weight;
                }
                catch
                {                   
                    ((Label)GridView1.Rows[drv.RowIndex].FindControl("lblProdWht")).Text = "";
                    ((Label)GridView1.Rows[drv.RowIndex].FindControl("lblAmountMoney")).Text = "";
                    //t.Focus();
                    return;
                }

                appriseMoney = ProdWht * appraise;
                ((Label)GridView1.Rows[drv.RowIndex].FindControl("lblProdWht")).Text = ProdWht.ToString();

                ((Label)GridView1.Rows[drv.RowIndex].FindControl("lblAmountMoney")).Text = appriseMoney.ToString();

                GridView1.UpdateAfterCallBack = true;
            }
            catch (Exception ex)
            {
                ((Label)GridView1.Rows[drv.RowIndex].FindControl("lblProdWht")).Text = "";
                ((Label)GridView1.Rows[drv.RowIndex].FindControl("lblAmountMoney")).Text = "";
               
            }
        }

        protected void Next_Click(object sender, EventArgs e)
        {
            try
            {
                this.mOrderMain = new GoldTradeNaming.Model.franchiser_order();
               
                foreach (GridViewRow gvr in GridView1.Rows)
                {
                    if (((TextBox)gvr.FindControl("txtProdNum")).Text.Trim() == "") continue;
                    if (((Label)gvr.FindControl("lblProdWht")).Text.Trim() == "") continue;

                    GoldTradeNaming.Model.franchiser_order_desc odrDesc = new GoldTradeNaming.Model.franchiser_order_desc();
                    odrDesc.id = 0;
                    odrDesc.franchiser_order_id = 0;
                    odrDesc.order_product_amount = Convert.ToInt32(((TextBox)gvr.FindControl("txtProdNum")).Text.Trim());
                    odrDesc.product_id = Convert.ToInt32(gvr.Cells[0].Text);
                    odrDesc.product_spec_id = Convert.ToDecimal(gvr.Cells[2].Text);
                    odrDesc.product_received = 0;
                    odrDesc.product_unreceived = Convert.ToDecimal(((Label)gvr.FindControl("lblProdWht")).Text.Trim());//初始为重量小计
                    odrDesc.realtime_base_price = CommBaseBLL.getRealTimePrice();
                    odrDesc.order_add_price = Convert.ToDecimal(gvr.Cells[5].Text);
                    odrDesc.order_appraise = Convert.ToDecimal(gvr.Cells[6].Text);
                    odrDesc.order_weight = Convert.ToDecimal(((Label)gvr.FindControl("lblProdWht")).Text.Trim());
                    odrDesc.ins_date = DateTime.Now;
                    odrDesc.ins_user = Session["fran"] as String;
                    odrDesc.upd_date = DateTime.Now;
                    odrDesc.upd_user = Session["fran"] as string;
                    this.mOrderMain.franchiser_order_amount_money += decimal.Round(odrDesc.order_weight * odrDesc.order_appraise, 4);
                   
                }
                this.lblAmount.Text = "预估总额为："+ this.mOrderMain.franchiser_order_amount_money.ToString()+"元";
            }
            catch
            {
                this.lblAmount.Text = "计算发生错误！";
            }
        }

        /// <summary>
        /// GridView 合并单元格
        /// </summary>
        int row = 0;
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int rowindex = e.Row.RowIndex;
            //是否为第一行
            if (rowindex - 1 < 0) return;

            //是否与上一行产品类别相同，相同继续这轮循环
            if (e.Row.Cells[0].Text == GridView1.Rows[rowindex - 1].Cells[0].Text)
            {
                //是否为此轮第一次开始合并，因为span=1没有意义，必定从2开始
                if (GridView1.Rows[row].Cells[1].RowSpan == 0) GridView1.Rows[row].Cells[1].RowSpan++;
                GridView1.Rows[row].Cells[1].RowSpan++;

                e.Row.Cells[1].Visible = false;
            }
            //开始下轮合并
            else
            {
                row = rowindex;
            }
        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[0].Visible = false;
            e.Row.Cells[5].Visible = false;
        }

    }


}
