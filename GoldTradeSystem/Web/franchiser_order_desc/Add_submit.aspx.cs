using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using LTP.Common;
using GoldTradeNaming.BLL;

namespace GoldTradeNaming.Web.franchiser_order_desc
{
    public partial class Add_submit : System.Web.UI.Page
    {
        private GoldTradeNaming.Model.franchiser_order mOrderMain;
        private List<GoldTradeNaming.Model.franchiser_order_desc> orderdescList;
        private GoldTradeNaming.BLL.product_type bll_product = new GoldTradeNaming.BLL.product_type();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["fran"] == null || Session["fran"].ToString() == "")
            {
                Session.Clear();
                Response.Clear();
                LTP.Common.MessageBox.ShowAndRedirect(this, "您没有权限或登录超时！\\n请重新登录或与管理员联系", "../User_Login/flogin.aspx");
                return;
            }
            if (!Page.IsPostBack)
            {
                LoadOrderInfo();
            }
           
        }
        private void LoadOrderInfo()
        {
            this.mOrderMain = Session["OrderMain"] as GoldTradeNaming.Model.franchiser_order;
            this.orderdescList = Session["orderdesclist"] as List<GoldTradeNaming.Model.franchiser_order_desc>;
        

            LoadData();
        }

        private void LoadData()
        {
            this.mOrderMain = Session["OrderMain"] as GoldTradeNaming.Model.franchiser_order;
            this.orderdescList = Session["orderdesclist"] as List<GoldTradeNaming.Model.franchiser_order_desc>;

            this.lblFranName.Text = this.mOrderMain.Franchiser_name;
            this.transway.Text = this.mOrderMain.franchiser_order_trans_type;
            this.txtfranchiser_order_address.Text = this.mOrderMain.franchiser_order_address;
            this.txtfranchiser_order_postcode.Text = this.mOrderMain.franchiser_order_postcode;
            this.txtfranchiser_order_handle_man.Text = this.mOrderMain.franchiser_order_handle_man;
            this.txtfranchiser_order_handle_tel.Text = this.mOrderMain.franchiser_order_handle_tel;
            this.txtfranchiser_order_handle_phone.Text = this.mOrderMain.franchiser_order_handle_phone;
            this.lblPrice.Text = this.mOrderMain.franchiser_order_price.ToString();
            this.lblProdType.Text = this.mOrderMain.Product_type_name;

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
            decimal sum = 0;
            for (int i = 0; i < this.orderdescList.Count;i++ ) {

                DataRow row = dt.NewRow();
                row["id"] = this.orderdescList[i].id;
                row["franchiser_order_id"] = this.orderdescList[i].franchiser_order_id;
                row["order_product_amount"] = this.orderdescList[i].order_product_amount;
                row["product_type_id"] = this.orderdescList[i].product_id;
                row["product_type_name"] =this.bll_product.check_id(this.orderdescList[i].product_id.ToString());
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
                row["AmountMoney"] = decimal.Round(this.orderdescList[i].product_spec_id * this.orderdescList[i].order_product_amount * this.orderdescList[i].order_appraise,4);
                dt.Rows.Add(row); 
                sum += Convert.ToDecimal(row["AmountMoney"]);
          }
        //foreach(DataRow row in dt.Rows){
            
        //}
        this.lblsun.Text = sum.ToString();

            
            this.GridView1.DataSource = dt;
            this.GridView1.DataBind();

            //GoldTradeNaming.BLL.franchiser_order orderbll = new GoldTradeNaming.BLL.franchiser_order();

            //DataSet ds;
            //this.mOrderMain = ViewState["orderm"] as GoldTradeNaming.Model.franchiser_order;
            //if (this.mOrderMain.Product_type == "0")
            //    ds = orderbll.GetGoldProduct();
            //else if (this.mOrderMain.Product_type == "1")
            //    ds = orderbll.GetSilverProduct();
            //else return;
            //GridView1.UpdateAfterCallBack = true;
            //GridView1.DataSource = ds;
            //GridView1.DataBind();
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
           // (Master.FindControl("lblTitle") as Label).Text = "在线订货";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try {
                this.mOrderMain = Session["OrderMain"] as GoldTradeNaming.Model.franchiser_order;
                this.orderdescList = Session["orderdesclist"] as List<GoldTradeNaming.Model.franchiser_order_desc>;

                GoldTradeNaming.BLL.franchiser_order order = new GoldTradeNaming.BLL.franchiser_order();

                if (order.SaveOrderInfo(this.mOrderMain, this.orderdescList))
                {

                    Session.Remove("OrderMain");
                    Session.Remove("orderdesclist");
                     MessageBox.ShowAndRedirect(this, "订货成功！请等待发货...", "../franchiser_order/Show.aspx");
                    //MessageBox.Show(this, "订货成功！请等待发货...");
                }
                else
                {
                    MessageBox.Show(this, "订货过程发生错误，请联系管理员！");
                }
            }
            catch {
             
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/franchiser_order_desc/Add.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Session.Remove("OrderMain");
            Session.Remove("orderdesclist");
            Response.Redirect("../franchiser_order/Show.aspx");
           
        }

      

    }
}
