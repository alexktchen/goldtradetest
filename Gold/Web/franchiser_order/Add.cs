namespace GoldTradeNaming.Web.franchiser_order
{
    using GoldTradeNaming.BLL;
    using GoldTradeNaming.Model;
    using LTP.Common;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public class Add : Page
    {
        private string _address;
        private string _fran_name;
        private string _handle_man;
        private string _handle_phone;
        private string _handle_tel;
        private string _postcode;
        private decimal _price;
        private string _product_name;
        private string _product_type;
        private string _trans_type;
        protected Button btnAdd;
        protected Button btnCancel;
        private CommBaseBLL comm = new CommBaseBLL();
        protected Label Label2;
        protected Label lblFranName;
        protected Label lblPrice;
        protected Label lblProdType;
        private GoldTradeNaming.Model.franchiser_order mOrder;
        private GoldTradeNaming.Model.franchiser_order mOrderMain;
        private List<GoldTradeNaming.Model.franchiser_order_desc> orderdescList;
        protected Panel Panel1;
        protected HiddenField thisProductType;
        protected RadioButtonList transway;
        protected TextBox txtfranchiser_order_address;
        protected TextBox txtfranchiser_order_handle_man;
        protected TextBox txtfranchiser_order_handle_phone;
        protected TextBox txtfranchiser_order_handle_tel;
        protected TextBox txtfranchiser_order_postcode;

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    if (this.CheckInput())
                    {
                        this.mTrans_type = this.transway.SelectedItem.Text;
                        this.mAddress = this.txtfranchiser_order_address.Text.Trim();
                        this.mFran_name = this.lblFranName.Text.Trim();
                        this.mHandle_man = this.txtfranchiser_order_handle_man.Text.Trim();
                        this.mHandle_phone = this.txtfranchiser_order_handle_phone.Text.Trim();
                        this.mHandle_tel = this.txtfranchiser_order_handle_tel.Text.Trim();
                        this.mPostcode = this.txtfranchiser_order_postcode.Text.Trim();
                        this.mPrice = Convert.ToDecimal(this.lblPrice.Text.Trim());
                        this.mProduct_type = this.thisProductType.Value;
                        this.mProduct_name = this.lblProdType.Text.Trim();
                        this.mOrder = new GoldTradeNaming.Model.franchiser_order();
                        this.mOrder.franchiser_code = Convert.ToInt32(this.Session["fran"]);
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
                        this.mOrder.franchiser_order_id = 0;
                        this.mOrder.franchiser_order_amount_money = 0M;
                        this.mOrder.franchiser_order_add_price = 0.00M;
                        this.mOrder.franchiser_order_appraise = 0.00M;
                        this.mOrder.ins_date = DateTime.Now;
                        this.mOrder.ins_user = this.Session["fran"] as string;
                        this.mOrder.upd_date = DateTime.Now;
                        this.mOrder.upd_user = this.Session["fran"] as string;
                        this.mOrder.canceled_reason = "";
                        this.Session["OrderMain"] = this.mOrder;
                        base.Response.Redirect("~/franchiser_order_desc/Add.aspx");
                    }
                }
                catch
                {
                    MessageBox.Show(this, "订货失败");
                }
            }
            finally
            {
            }
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

        public bool CheckInput()
        {
            string errstr = "";
            if (this.transway.SelectedIndex == -1)
            {
                errstr = errstr + "运输方式未选择<br>";
            }
            if (this.txtfranchiser_order_address.Text.Trim() == "")
            {
                errstr = errstr + "收货地址未输入<br>";
            }
            if (this.txtfranchiser_order_postcode.Text.Trim() == "")
            {
                errstr = errstr + "邮政编码未输入输入输入<br>";
            }
            if (this.txtfranchiser_order_handle_man.Text.Trim() == "")
            {
                errstr = errstr + "收货人未输入<br>";
            }
            if (this.txtfranchiser_order_handle_tel.Text.Trim() == "")
            {
                errstr = errstr + "收货人电话（座机）未输入<br>";
            }
            if (this.txtfranchiser_order_handle_phone.Text.Trim() == "")
            {
                errstr = errstr + "收货人手机未输入<br>";
            }
            if (errstr != "")
            {
                this.Label2.Text = errstr;
                return false;
            }
            return true;
        }

        public void loadinfo()
        {
            this.mOrderMain = this.Session["OrderMain"] as GoldTradeNaming.Model.franchiser_order;
            this.lblFranName.Text = this.mOrderMain.Franchiser_name;
            if (this.mOrderMain.franchiser_order_trans_type.Trim() == "航空")
            {
                this.transway.SelectedIndex = 0;
            }
            else if (this.mOrderMain.franchiser_order_trans_type.Trim() == "邮寄")
            {
                this.transway.SelectedIndex = 1;
            }
            else if (this.mOrderMain.franchiser_order_trans_type.Trim() == "自取")
            {
                this.transway.SelectedIndex = 2;
            }
            else
            {
                this.transway.SelectedIndex = 3;
            }
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
            this.thisProductType.Value = base.Request.QueryString["prodtype"].ToString();
            this.lblProdType.Text = (this.thisProductType.Value == "0") ? "升水" : "非升水";
            DataSet dsPrice = this.comm.getCurrentPrice();
            this.lblPrice.Text = dsPrice.Tables[0].Rows[0][0].ToString();
            this.lblFranName.Text = CommBaseBLL.GetFranName(Convert.ToInt32(this.Session["fran"]));
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
                if ((this.Session["OrderMain"] == null) || (this.Session["OrderMain"].ToString() == ""))
                {
                    this.loadProductInfo();
                }
                else
                {
                    this.loadinfo();
                }
            }
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
        }

        public string mAddress
        {
            get
            {
                return this._address;
            }
            set
            {
                this._address = value;
            }
        }

        public string mFran_name
        {
            get
            {
                return this._fran_name;
            }
            set
            {
                this._fran_name = value;
            }
        }

        public string mHandle_man
        {
            get
            {
                return this._handle_man;
            }
            set
            {
                this._handle_man = value;
            }
        }

        public string mHandle_phone
        {
            get
            {
                return this._handle_phone;
            }
            set
            {
                this._handle_phone = value;
            }
        }

        public string mHandle_tel
        {
            get
            {
                return this._handle_tel;
            }
            set
            {
                this._handle_tel = value;
            }
        }

        public GoldTradeNaming.Model.franchiser_order MOrder
        {
            get
            {
                return this.mOrder;
            }
            set
            {
                this.mOrder = value;
            }
        }

        public string mPostcode
        {
            get
            {
                return this._postcode;
            }
            set
            {
                this._postcode = value;
            }
        }

        public decimal mPrice
        {
            get
            {
                return this._price;
            }
            set
            {
                this._price = value;
            }
        }

        public string mProduct_name
        {
            get
            {
                return this._product_name;
            }
            set
            {
                this._product_name = value;
            }
        }

        public string mProduct_type
        {
            get
            {
                return this._product_type;
            }
            set
            {
                this._product_type = value;
            }
        }

        public string mTrans_type
        {
            get
            {
                return this._trans_type;
            }
            set
            {
                this._trans_type = value;
            }
        }
    }
}
