namespace GoldTradeNaming.Web.franchiser_order_desc
{
    using GoldTradeNaming.BLL;
    using GoldTradeNaming.Model;
    using LTP.Common;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public class Add_submit : Page
    {
        private GoldTradeNaming.BLL.product_type bll_product = new GoldTradeNaming.BLL.product_type();
        protected Button Button1;
        protected Button Button2;
        protected Button Button3;
        protected GridView GridView1;
        protected HiddenField keyType;
        protected Label Label1;
        protected Label lblFranName;
        protected Label lblPrice;
        protected Label lblProdType;
        protected Label lblsun;
        private GoldTradeNaming.Model.franchiser_order mOrderMain;
        private List<GoldTradeNaming.Model.franchiser_order_desc> orderdescList;
        protected Label transway;
        protected Label txtfranchiser_order_address;
        protected Label txtfranchiser_order_handle_man;
        protected Label txtfranchiser_order_handle_phone;
        protected Label txtfranchiser_order_handle_tel;
        protected Label txtfranchiser_order_postcode;

        protected void Button1_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("~/franchiser_order_desc/Add.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                this.mOrderMain = this.Session["OrderMain"] as GoldTradeNaming.Model.franchiser_order;
                this.orderdescList = this.Session["orderdesclist"] as List<GoldTradeNaming.Model.franchiser_order_desc>;
                GoldTradeNaming.BLL.franchiser_order order = new GoldTradeNaming.BLL.franchiser_order();
                if (order.SaveOrderInfo(this.mOrderMain, this.orderdescList))
                {
                    this.Session.Remove("OrderMain");
                    this.Session.Remove("orderdesclist");
                    MessageBox.ShowAndRedirect(this, "订货成功！请等待发货...", "../franchiser_order/Show.aspx");
                }
                else
                {
                    MessageBox.Show(this, "订货过程发生错误，请联系管理员！");
                }
            }
            catch
            {
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            this.Session.Remove("OrderMain");
            this.Session.Remove("orderdesclist");
            base.Response.Redirect("../franchiser_order/Show.aspx");
        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (this.keyType.Value == "1")
            {
                e.Row.Cells[2].Visible = false;
                e.Row.Cells[4].Visible = false;
            }
        }

        private void LoadData()
        {
            this.mOrderMain = this.Session["OrderMain"] as GoldTradeNaming.Model.franchiser_order;
            this.orderdescList = this.Session["orderdesclist"] as List<GoldTradeNaming.Model.franchiser_order_desc>;
            this.lblFranName.Text = this.mOrderMain.Franchiser_name;
            this.transway.Text = this.mOrderMain.franchiser_order_trans_type;
            this.txtfranchiser_order_address.Text = this.mOrderMain.franchiser_order_address;
            this.txtfranchiser_order_postcode.Text = this.mOrderMain.franchiser_order_postcode;
            this.txtfranchiser_order_handle_man.Text = this.mOrderMain.franchiser_order_handle_man;
            this.txtfranchiser_order_handle_tel.Text = this.mOrderMain.franchiser_order_handle_tel;
            this.txtfranchiser_order_handle_phone.Text = this.mOrderMain.franchiser_order_handle_phone;
            this.lblPrice.Text = this.mOrderMain.franchiser_order_price.ToString();
            this.lblProdType.Text = this.mOrderMain.Product_type_name;
            this.keyType.Value = this.mOrderMain.Product_type;
            DataTable dt = new DataTable();
            dt.Columns.Add("id");
            dt.Columns.Add("franchiser_order_id");
            dt.Columns.Add("order_product_amount");
            dt.Columns.Add("product_type_id");
            dt.Columns.Add("product_type_name");
            dt.Columns.Add("product_spec_id");
            dt.Columns.Add("product_received");
            dt.Columns.Add("product_unreceived");
            dt.Columns.Add("realtime_base_price");
            dt.Columns.Add("order_add_price");
            dt.Columns.Add("order_appraise");
            dt.Columns.Add("order_weight");
            dt.Columns.Add("ins_date");
            dt.Columns.Add("ins_user");
            dt.Columns.Add("upd_date");
            dt.Columns.Add("upd_user");
            dt.Columns.Add("AmountMoney");
            decimal sum = 0M;
            for (int i = 0; i < this.orderdescList.Count; i++)
            {
                DataRow row = dt.NewRow();
                row["id"] = this.orderdescList[i].id;
                row["franchiser_order_id"] = this.orderdescList[i].franchiser_order_id;
                row["order_product_amount"] = this.orderdescList[i].order_product_amount;
                row["product_type_id"] = this.orderdescList[i].product_id;
                row["product_type_name"] = this.bll_product.check_id(this.orderdescList[i].product_id.ToString());
                row["product_spec_id"] = this.orderdescList[i].product_spec_id;
                row["product_received"] = this.orderdescList[i].product_received;
                row["product_unreceived"] = this.orderdescList[i].product_unreceived;
                row["realtime_base_price"] = this.orderdescList[i].realtime_base_price;
                row["order_add_price"] = this.orderdescList[i].order_add_price;
                row["order_appraise"] = this.orderdescList[i].order_appraise;
                row["order_weight"] = this.orderdescList[i].order_weight;
                row["ins_date"] = this.orderdescList[i].ins_date;
                row["ins_user"] = this.orderdescList[i].ins_user;
                row["upd_date"] = this.orderdescList[i].upd_date;
                row["upd_user"] = this.orderdescList[i].upd_user;
                row["AmountMoney"] = decimal.Round((this.orderdescList[i].product_spec_id * this.orderdescList[i].order_product_amount) * this.orderdescList[i].order_appraise, 4);
                dt.Rows.Add(row);
                sum += Convert.ToDecimal(row["AmountMoney"]);
            }
            this.lblsun.Text = sum.ToString();
            this.GridView1.DataSource = dt;
            this.GridView1.DataBind();
        }

        private void LoadOrderInfo()
        {
            this.mOrderMain = this.Session["OrderMain"] as GoldTradeNaming.Model.franchiser_order;
            this.orderdescList = this.Session["orderdesclist"] as List<GoldTradeNaming.Model.franchiser_order_desc>;
            this.LoadData();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((this.Session["fran"] == null) || (this.Session["fran"].ToString() == ""))
            {
                this.Session.Clear();
                base.Response.Clear();
                MessageBox.ShowAndRedirect(this, @"您没有权限或登录超时！\n请重新登录或与管理员联系", "../User_Login/flogin.aspx");
            }
            else if (!this.Page.IsPostBack)
            {
                this.LoadOrderInfo();
            }
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
        }
    }
}
