namespace GoldTradeNaming.Web.product_type
{
    using GoldTradeNaming.BLL;
    using GoldTradeNaming.Model;
    using LTP.Common;
    using System;
    using System.Data;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Add : Page
    {
        private string _type;
        protected Button add_product_name;
        private GoldTradeNaming.BLL.product_type bll = new GoldTradeNaming.BLL.product_type();
        protected Button btnAdd;
        protected Button btnCancel;
        protected Button Button1;
        protected Button Button2;
        protected DropDownList drpproduct_type_name;
        protected HtmlGenericControl gold;
        protected TextBox new_name;
        protected Panel Panel1;
        protected HtmlGenericControl silver;
        protected TextBox txtorder_add_price;
        protected TextBox txtproduct_spec_weight;
        protected TextBox txtproduct_type_id;
        protected TextBox txtsilver;
        protected TextBox txtSilverName;
        protected TextBox txttrade_add_price;

        protected void add_product_name_Click(object sender, EventArgs e)
        {
            this.Panel1.Visible = true;
            this.new_name.Text = "";
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.checkValidate())
                {
                    GoldTradeNaming.Model.product_type model = new GoldTradeNaming.Model.product_type();
                    model.product_state = "0";
                    if (this.type == "0")
                    {
                        model.product_type_id = Convert.ToInt32(this.txtproduct_type_id.Text.Trim());
                        model.product_type_name = this.drpproduct_type_name.Text.Trim();
                        model.product_spec_weight = Convert.ToDecimal(this.txtproduct_spec_weight.Text.Trim());
                        model.order_add_price = decimal.Parse(this.txtorder_add_price.Text.Trim());
                        model.trade_add_price = decimal.Parse(this.txttrade_add_price.Text.Trim());
                        model.type = "0";
                    }
                    else if (this.type == "1")
                    {
                        model.product_type_id = this.bll.GetMaxId();
                        model.product_type_name = this.txtSilverName.Text;
                        model.product_spec_weight = 1M;
                        model.order_add_price = decimal.Parse(this.txtsilver.Text.Trim());
                        model.trade_add_price = decimal.Parse(this.txtsilver.Text.Trim());
                        model.type = "1";
                    }
                    model.ins_user = this.Session["admin"].ToString();
                    model.ins_date = DateTime.Now;
                    model.upd_user = this.Session["admin"].ToString();
                    model.upd_date = DateTime.Now;
                    if (this.bll.Add(model) > 0)
                    {
                        MessageBox.Show(this, "新增成功");
                    }
                    else
                    {
                        MessageBox.Show(this, "新增失败");
                    }
                }
            }
            catch
            {
                MessageBox.Show(this, "新增失败");
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if (this.type == "1")
            {
                this.txtSilverName.Text = "";
                this.txtsilver.Text = "";
            }
            else
            {
                this.txtproduct_type_id.Text = "";
                this.drpproduct_type_name.SelectedIndex = 0;
                this.txtproduct_spec_weight.Text = "";
                this.txtorder_add_price.Text = "";
                this.txttrade_add_price.Text = "";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string name = this.new_name.Text;
            if (name == "")
            {
                base.Response.Write("<script type='text/javascript'>alert('产品类别名称不能为空')</script>");
            }
            else
            {
                this.drpproduct_type_name.Items.Add(name);
                this.drpproduct_type_name.SelectedIndex = this.drpproduct_type_name.Items.Count - 1;
                this.name_change(sender, e);
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
        }

        public bool checkValidate()
        {
            try
            {
                string product_type_name;
                string strErr = "";
                if (this.type == "0")
                {
                    if (this.txtproduct_type_id.Text == "")
                    {
                        strErr = strErr + @"product_type_id不能为空！\n";
                    }
                    if (this.drpproduct_type_name.Text == "")
                    {
                        strErr = strErr + @"product_type_name不能为空！\n";
                    }
                    if (this.txtproduct_spec_weight.Text == "")
                    {
                        strErr = strErr + @"product_spec_weight不能为空！\n";
                    }
                    if (this.txtorder_add_price.Text == "")
                    {
                        strErr = strErr + @"order_add_price不能为空！\n";
                    }
                    if (this.txttrade_add_price.Text == "")
                    {
                        strErr = strErr + @"trade_add_price不能为空！\n";
                    }
                }
                else if (this.type == "1")
                {
                    if (this.txtSilverName.Text.Trim() == "")
                    {
                        strErr = strErr + @"产品名称不能为空！\n";
                    }
                    if (this.txtsilver.Text == "")
                    {
                        strErr = strErr + @"价格不能为空！\n";
                    }
                }
                if (strErr != "")
                {
                    MessageBox.Show(this, strErr);
                    return false;
                }
                if (this.type == "0")
                {
                    try
                    {
                        Convert.ToDecimal(this.txtproduct_spec_weight.Text.Trim());
                    }
                    catch
                    {
                        strErr = strErr + @"产品规格不是数字\n";
                    }
                    try
                    {
                        Convert.ToDecimal(this.txtorder_add_price.Text.Trim());
                    }
                    catch
                    {
                        strErr = strErr + @"订货加价不是数字\n";
                    }
                    try
                    {
                        Convert.ToDecimal(this.txttrade_add_price.Text.Trim());
                    }
                    catch
                    {
                        strErr = strErr + @"销售加价不是数字\n";
                    }
                }
                else if ((this.type == "1") && !PageValidate.IsDecimal(this.txtsilver.Text.Trim()))
                {
                    strErr = strErr + @"silver_price不是数字\n";
                }
                if (strErr != "")
                {
                    MessageBox.Show(this, strErr);
                    return false;
                }
                if (this.type == "0")
                {
                    string product_type_id = this.txtproduct_type_id.Text.Trim();
                    string product_spec_weight = this.txtproduct_spec_weight.Text.Trim();
                    product_type_name = this.drpproduct_type_name.Text.Trim();
                    if (this.bll.Exists(Convert.ToInt32(product_type_id), Convert.ToDecimal(product_spec_weight)))
                    {
                        MessageBox.Show(this, "产品已存在，请重新输入");
                        return false;
                    }
                }
                else
                {
                    product_type_name = this.txtSilverName.Text;
                    if (this.bll.check_name(product_type_name) != "")
                    {
                        MessageBox.Show(this, "产品已存在，请重新输入");
                        return false;
                    }
                }
            }
            catch
            {
                MessageBox.Show(this, "验证过程出错");
                return false;
            }
            return true;
        }

        protected void ID_check(object sender, EventArgs e)
        {
            string id = this.txtproduct_type_id.Text.Trim();
            if (id != "")
            {
                string name = this.bll.check_id(id);
                if (name == "")
                {
                    MessageBox.Show(this, "请添加新的产品类别名称");
                    this.drpproduct_type_name.SelectedIndex = 0;
                }
                else
                {
                    this.drpproduct_type_name.Text = name;
                }
            }
        }

        protected void name_change(object sender, EventArgs e)
        {
            string name = this.drpproduct_type_name.Text.Trim();
            if (name != "")
            {
                string id = this.bll.check_name(name);
                if (id == "")
                {
                    string new_procut_type_id = this.bll.GetMaxId().ToString();
                    this.txtproduct_type_id.Text = new_procut_type_id;
                    this.txtorder_add_price.Text = "";
                    this.txttrade_add_price.Text = "";
                }
                else
                {
                    this.txtproduct_type_id.Text = id;
                }
            }
            else
            {
                this.txtproduct_type_id.Text = "";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((this.Session["admin"] == null) || (this.Session["admin"].ToString() == ""))
            {
                this.Session.Clear();
                base.Response.Clear();
                MessageBox.ShowAndRedirect(this, @"您没有权限或登录超时！\n请重新登录或与管理员联系", "../User_Login/AdminLogin.aspx");
            }
            else if (!(((this.Session["admin"] != null) && (this.Session["admin"].ToString() != "")) && CommBaseBLL.HasRight(Convert.ToInt32(this.Session["admin"]), Authority.AddProduct.ToString())))
            {
                base.Response.Clear();
                base.Response.Write(@"<script defer>window.alert('您没有权限操作该功能！\n请重新登录或与管理员联系');history.back();</script>");
                base.Response.End();
            }
            else
            {
                this.Panel1.Visible = false;
                this.type = base.Request.QueryString["type"].ToString().Trim();
                if (!this.Page.IsPostBack)
                {
                    try
                    {
                        this.txtproduct_type_id.Visible = false;
                        this.gold.Visible = false;
                        this.silver.Visible = false;
                        if (this.type == "0")
                        {
                            this.gold.Visible = true;
                        }
                        else if (this.type == "1")
                        {
                            this.silver.Visible = true;
                        }
                        this.drpproduct_type_name.Items.Add("");
                        DataSet ds = this.bll.getAll(this.type);
                        if ((ds == null) || (ds.Tables[0].Rows.Count == 0))
                        {
                            this.drpproduct_type_name.DataSource = null;
                        }
                        else
                        {
                            foreach (DataRow row in ds.Tables[0].Rows)
                            {
                                this.drpproduct_type_name.Items.Add(row[0].ToString());
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show(this, "加载失败");
                    }
                }
            }
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            (base.Master.FindControl("lblTitle") as Label).Text = "添加产品";
        }

        public string type
        {
            get
            {
                return this._type;
            }
            set
            {
                this._type = value;
            }
        }
    }
}
