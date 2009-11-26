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

namespace GoldTradeNaming.Web.franchiser_order
{
    public partial class Add : System.Web.UI.Page
    {
        private GoldTradeNaming.BLL.CommBaseBLL comm = new CommBaseBLL();
        private GoldTradeNaming.Model.franchiser_order mOrderMain;
        private List<GoldTradeNaming.Model.franchiser_order_desc> orderdescList;
        private string _fran_name;

        public string mFran_name
        {
            get { return _fran_name; }
            set { _fran_name = value; }
        }
        private string _trans_type;

        public string mTrans_type
        {
            get { return _trans_type; }
            set { _trans_type = value; }
        }
        private string _address;

        public string mAddress
        {
            get { return _address; }
            set { _address = value; }
        }
        private string _postcode;

        public string mPostcode
        {
            get { return _postcode; }
            set { _postcode = value; }
        }
        private string _handle_man;

        public string mHandle_man
        {
            get { return _handle_man; }
            set { _handle_man = value; }
        }
        private string _handle_tel;

        public string mHandle_tel
        {
            get { return _handle_tel; }
            set { _handle_tel = value; }
        }
        private string _handle_phone;

        public string mHandle_phone
        {
            get { return _handle_phone; }
            set { _handle_phone = value; }
        }
        private Decimal _price;

        public Decimal mPrice
        {
            get { return _price; }
            set { _price = value; }
        }
        private string _product_type;

        public string mProduct_type
        {
            get { return _product_type; }
            set { _product_type = value; }
        }

        private string _product_name;

        public string mProduct_name
        {
            get { return _product_name; }
            set { _product_name = value; }
        }

        private GoldTradeNaming.Model.franchiser_order mOrder;

        public GoldTradeNaming.Model.franchiser_order MOrder
        {
            get { return mOrder; }
            set { mOrder = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["fran"] == null || Session["fran"].ToString() == "")
            {
                Session.Clear();
                Response.Clear();
                LTP.Common.MessageBox.ShowAndRedirect(this, "蠟羶衄癹麼腎翹閉奀ㄐ\\n笭陔腎翹麼迵奪燴埜薊炵", "../User_Login/flogin.aspx");
                return;
            }

            if (!Page.IsPostBack)
            {
                if (Session["OrderMain"] == null || Session["OrderMain"].ToString() == "")
                {
                    loadProductInfo();
                }
                else
                {
                    loadinfo();
                }

            }
        }
        public void loadinfo()
        {

            this.mOrderMain = Session["OrderMain"] as GoldTradeNaming.Model.franchiser_order;

            this.lblFranName.Text = this.mOrderMain.Franchiser_name;
            if (this.mOrderMain.franchiser_order_trans_type.Trim() == "瑤諾") { this.transway.SelectedIndex = 0; }
            else if (this.mOrderMain.franchiser_order_trans_type.Trim() == "蚘敵") { this.transway.SelectedIndex = 1; }
            else if (this.mOrderMain.franchiser_order_trans_type.Trim() == "赻") { this.transway.SelectedIndex = 2; }
            else { this.transway.SelectedIndex = 3; }

           
            this.txtfranchiser_order_address.Text = this.mOrderMain.franchiser_order_address;
            this.txtfranchiser_order_postcode.Text = this.mOrderMain.franchiser_order_postcode;
            this.txtfranchiser_order_handle_man.Text = this.mOrderMain.franchiser_order_handle_man;
            this.txtfranchiser_order_handle_tel.Text = this.mOrderMain.franchiser_order_handle_tel;
            this.txtfranchiser_order_handle_phone.Text = this.mOrderMain.franchiser_order_handle_phone;
            this.lblPrice.Text = this.mOrderMain.franchiser_order_price.ToString();
            this.thisProductType.Value = this.mOrderMain.Product_type;
            this.lblProdType.Text = this.mOrderMain.Product_type_name;
        }



        private void loadProductInfo()
        {
            this.thisProductType.Value = Request.QueryString["prodtype"].ToString();
            this.lblProdType.Text = this.thisProductType.Value == "0" ? "汔阨" : "準汔阨";
            DataSet dsPrice = comm.getCurrentPrice();
            this.lblPrice.Text = dsPrice.Tables[0].Rows[0][0].ToString();
            this.lblFranName.Text = CommBaseBLL.GetFranName(Convert.ToInt32(Session["fran"]));
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CheckInput()) return;

                this.mTrans_type = this.transway.SelectedItem.Text;
                this.mAddress = this.txtfranchiser_order_address.Text.Trim();
                this.mFran_name = this.lblFranName.Text.Trim();
                this.mHandle_man = this.txtfranchiser_order_handle_man.Text.Trim();
                this.mHandle_phone = this.txtfranchiser_order_handle_phone.Text.Trim();
                this.mHandle_tel = this.txtfranchiser_order_handle_tel.Text.Trim();
                this.mPostcode = this.txtfranchiser_order_postcode.Text.Trim();
                this.mPrice = Convert.ToDecimal(this.lblPrice.Text.Trim());
                this.mProduct_type = this.thisProductType.Value;//換濬梗IDㄛ0ㄩ酴踢ㄛ1ㄩ啞窅
                this.mProduct_name = this.lblProdType.Text.Trim(); //換濬梗靡備ㄛ酴踢ㄛ啞窅

                this.mOrder = new GoldTradeNaming.Model.franchiser_order();
                this.mOrder.franchiser_code = Convert.ToInt32(Session["fran"]);
                this.mOrder.franchiser_order_price = this.mPrice;
                this.mOrder.franchiser_order_address = this.mAddress;
                this.mOrder.franchiser_order_handle_man = this.mHandle_man;
                this.mOrder.franchiser_order_handle_phone = this.mHandle_phone;
                this.mOrder.franchiser_order_handle_tel = this.mHandle_tel;
                this.mOrder.franchiser_order_postcode = this.mPostcode;
                this.mOrder.franchiser_order_state = "0";
                this.mOrder.franchiser_order_trans_type = this.mTrans_type;
                this.mOrder.Franchiser_name = this.mFran_name;
                this.mOrder.Product_type = this.mProduct_type;
                this.mOrder.Product_type_name = this.mProduct_name;

                this.mOrder.franchiser_order_time = DateTime.Now;
                this.mOrder.franchiser_order_id = 0; //赻雄瘍
                this.mOrder.franchiser_order_amount_money = 0; //婃峈0,怀莉陓洘綴ㄛ濛樓
                this.mOrder.franchiser_order_add_price = 0.00M; //拸砩砱
                this.mOrder.franchiser_order_appraise = 0.00M;//拸砩砱
                this.mOrder.ins_date = DateTime.Now;
                this.mOrder.ins_user = Session["fran"] as string;
                this.mOrder.upd_date = DateTime.Now;
                this.mOrder.upd_user = Session["fran"] as string;
                this.mOrder.canceled_reason = "";

                Session["OrderMain"] = this.mOrder;
                Response.Redirect("~/franchiser_order_desc/Add.aspx");
            }
            catch
            {
                MessageBox.Show(this, "隆億囮啖");
            }
            finally
            {
                //Server.Transfer("~/franchiser_order_desc/Add.aspx");
            }
        }

        public bool CheckInput()
        {
            string errstr = "";
            if (transway.SelectedIndex == -1)
            {
                errstr += "堍怀源宒帤恁寁<br>";
            }
            if (txtfranchiser_order_address.Text.Trim() == "")
            {
                errstr += "彶億華硊帤怀<br>";
            }
            if (txtfranchiser_order_postcode.Text.Trim() == "")
            {
                errstr += "蚘淉晤鎢帤怀怀怀<br>";
            }
            if (txtfranchiser_order_handle_man.Text.Trim() == "")
            {
                errstr += "彶億帤怀<br>";
            }
            if (txtfranchiser_order_handle_tel.Text.Trim() == "")
            {
                errstr += "彶億萇趕ㄗ釱儂ㄘ帤怀<br>";
            }
            if (txtfranchiser_order_handle_phone.Text.Trim() == "")
            {
                errstr += "彶億忒儂帤怀<br>";
            }

            if (errstr != "")
            {
                Label2.Text = errstr;
                return false;
            }
            return true;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            this.transway.SelectedIndex = -1;
            this.txtfranchiser_order_address.Text = "";
            this.txtfranchiser_order_handle_man.Text = "";
            this.txtfranchiser_order_handle_phone.Text = "";
            this.txtfranchiser_order_handle_tel.Text = "";
            this.txtfranchiser_order_postcode.Text = "";
        }




    }
}
