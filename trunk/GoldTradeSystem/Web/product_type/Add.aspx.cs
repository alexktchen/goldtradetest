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
namespace GoldTradeNaming.Web.product_type
{
    public partial class Add : System.Web.UI.Page
    {
        private GoldTradeNaming.BLL.product_type bll = new GoldTradeNaming.BLL.product_type();
        private string _type;
        public string type
        {
            set { _type = value; }
            get { return _type; }

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Panel1.Visible = false;
            this.type = Request.QueryString["type"].ToString().Trim();
            if (!Page.IsPostBack)
            {
                try
                {
                    gold.Visible = false;
                    silver.Visible = false;



                    if (this.type == "0")
                    {
                        gold.Visible = true;

                    }
                    else if (this.type == "1")
                    {
                        silver.Visible = true;
                        DataSet ds_silver = bll.getSilver();
                        if (ds_silver == null || ds_silver.Tables[0].Rows.Count == 0)
                        {

                            txtsilver.ReadOnly = false;
                            txtsilver.Text = "";
                        }
                        else
                        {

                            //�������ݿ��а����ļ۸񣬲�������Ϊreadonly

                            txtsilver.ReadOnly = true;
                            txtsilver.BackColor = System.Drawing.Color.Silver;
                            txtsilver.Text = ds_silver.Tables[0].Rows[0][0].ToString();


                        }



                    }

                    if (Session["admin"] == null || Session["admin"].ToString() == ""
                        || !GoldTradeNaming.BLL.CommBaseBLL.HasRight(Convert.ToInt32(Session["admin"]), Model.Authority.AddProduct.ToString())
                    
                        )
                    {
                        Response.Clear();
                        Response.Write("<script defer>window.alert('" + "��û��Ȩ�޵�¼��ϵͳ��\\n�����µ�¼�������Ա��ϵ" + "');history.back();</script>");
                        Response.End();
                        return;
                    }
                    drpproduct_type_name.Items.Add("");

                    DataSet ds = bll.getAll(this.type);
                    if (ds == null || ds.Tables[0].Rows.Count == 0)
                    {
                        drpproduct_type_name.DataSource = null;

                    }
                    else
                    {
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {

                            drpproduct_type_name.Items.Add(row[0].ToString());


                        }
                    }
                }
                catch
                {

                    MessageBox.Show(this, "����ʧ��");
                }
            }





        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            (Master.FindControl("lblTitle") as Label).Text = "��Ӳ�Ʒ";
        }


        protected void btnAdd_Click(object sender, EventArgs e)
        {


            try
            {
                if (!checkValidate())
                {
                    return;
                }

                GoldTradeNaming.Model.product_type model = new GoldTradeNaming.Model.product_type();
                model.product_type_id = Convert.ToInt32(this.txtproduct_type_id.Text.Trim());
                model.product_type_name = this.drpproduct_type_name.Text.Trim(); ;
                model.product_spec_weight = Convert.ToInt32(this.txtproduct_spec_weight.Text.Trim());
                model.product_state = "0";


                if (this.type == "0")
                {
                    model.order_add_price = decimal.Parse(this.txtorder_add_price.Text.Trim());
                    model.trade_add_price = decimal.Parse(this.txttrade_add_price.Text.Trim());
                    model.type = "0";

                }
                else if (this.type == "1")
                {

                    model.order_add_price = decimal.Parse(this.txtsilver.Text.Trim());
                    model.trade_add_price = decimal.Parse(this.txtsilver.Text.Trim());
                    model.type = "1";
                }


                model.ins_user = Session["admin"].ToString();
                model.ins_date = DateTime.Now;
                model.upd_user = Session["admin"].ToString();
                model.upd_date = DateTime.Now;


                int tool = bll.Add(model);

                if (tool > 0)
                {
                   MessageBox.Show(this, "�����ɹ�");
                }
                else
                {
                    MessageBox.Show(this, "����ʧ��");

                }
            }
            catch
            {
                MessageBox.Show(this, "����ʧ��");

            }


        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            txtproduct_type_id.Text = "";
            drpproduct_type_name.SelectedIndex = 0;
            txtproduct_spec_weight.Text = "";
            //txtproduct_state.Text = "";
            //txtins_date.Text = DateTime.Now.ToString();
           


            if (this.type == "1")
            {
                silver.Visible = true;
                DataSet ds_silver = bll.getSilver();
                if (ds_silver == null || ds_silver.Tables[0].Rows.Count == 0)
                {

                    txtsilver.ReadOnly = false;
                    txtsilver.Text = "";
                }
                else
                {

                    //�������ݿ��а����ļ۸񣬲�������Ϊreadonly

                    txtsilver.ReadOnly = true;
                    txtsilver.BackColor = System.Drawing.Color.Silver;
                    txtsilver.Text = ds_silver.Tables[0].Rows[0][0].ToString();


                }



            }
            else {

                txtorder_add_price.Text = "";
                txttrade_add_price.Text = "";

                txtorder_add_price.ReadOnly = false;
                txttrade_add_price.ReadOnly = false;

                txtorder_add_price.BackColor = System.Drawing.Color.White;
                txttrade_add_price.BackColor = System.Drawing.Color.White;
            
            
            }



        }

        protected void add_product_name_Click(object sender, EventArgs e)
        {
            Panel1.Visible = true;
            new_name.Text = "";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string name = new_name.Text;
            if (name == "")
            {
                Response.Write("<script type='text/javascript'>alert('��Ʒ������Ʋ���Ϊ��')</script>");
                //MessageBox.Show(this,"��Ʒ������Ʋ���Ϊ��");
            }
            else
            {

                drpproduct_type_name.Items.Add(name);
                drpproduct_type_name.SelectedIndex = 0;
                //drpproduct_type_name.SelectedIndex = drpproduct_type_name.Items.Count - 1;
            }


        }

        protected void ID_check(object sender, EventArgs e)
        {

            string id = txtproduct_type_id.Text.Trim();
            if (id != "")
            {
                string name = bll.check_id(id);
                if (name == "")
                {

                    MessageBox.Show(this, "������µĲ�Ʒ�������");
                    drpproduct_type_name.SelectedIndex = 0;

                }
                else
                {
                    drpproduct_type_name.Text = name;

                }



            }




        }

        protected void name_change(object sender, EventArgs e)
        {
            string name = drpproduct_type_name.Text.Trim();
            if (name != "")
            {
                string id = bll.check_name(name);

                if (id == "")
                {

                    //MessageBox.Show(this, "�ò�Ʒ�������ڲ�Ʒ�����У���������ID������Ӹò�Ʒ���");
                    //�����µ�product_type_id������Ҳ��Ӧ����λ��
                    string new_procut_type_id = bll.GetMaxId().ToString();
                    txtproduct_type_id.Text = new_procut_type_id;
                    txtorder_add_price.Text = "";
                    txttrade_add_price.Text = "";
                    txtorder_add_price.ReadOnly = false;
                    txttrade_add_price.ReadOnly = false;
                    txtorder_add_price.BackColor = System.Drawing.Color.White;
                    txttrade_add_price.BackColor = System.Drawing.Color.White;


                }
                else
                {

                    txtproduct_type_id.Text = id;
                    //��������Ʒ�Ѿ����ڣ�����������Ӽۺ����ۼӼ�
                    try
                    {
                        DataSet ds = bll.queryAction(id, "", "", "", "", "", "");
                     
                            txtorder_add_price.Text = ds.Tables[0].Rows[0]["order_add_price"].ToString();
                            txttrade_add_price.Text = ds.Tables[0].Rows[0]["trade_add_price"].ToString();
                            txtorder_add_price.ReadOnly = true;
                            txttrade_add_price.ReadOnly = true;
                            txtorder_add_price.BackColor = System.Drawing.Color.Silver;
                            txttrade_add_price.BackColor = System.Drawing.Color.Silver;
                      
                    }
                    catch
                    {
                        MessageBox.Show(this, "�����Ӽۺ����ѼӼ۳���");

                    }



                }
            }
            else
            {
                txtproduct_type_id.Text = "";
            }




        }

        public bool checkValidate()
        {

            try
            {
                string strErr = "";
                if (this.txtproduct_type_id.Text == "")
                {
                    strErr += "product_type_id����Ϊ�գ�\\n";
                }

                if (this.drpproduct_type_name.Text == "")
                {
                    strErr += "product_type_name����Ϊ�գ�\\n";
                }
                if (this.txtproduct_spec_weight.Text == "")
                {
                    strErr += "product_spec_weight����Ϊ�գ�\\n";
                }



                if (this.type == "0")
                {
                    if (this.txtorder_add_price.Text == "")
                    {
                        strErr += "order_add_price����Ϊ�գ�\\n";
                    }
                    if (this.txttrade_add_price.Text == "")
                    {
                        strErr += "trade_add_price����Ϊ�գ�\\n";
                    }
                }
                else if (this.type == "1")
                {

                    if (this.txtsilver.Text == "")
                    {
                        strErr += "silver_price����Ϊ�գ�\\n";
                    }
                }


                if (strErr != "")
                {
                    MessageBox.Show(this, strErr);
                    return false;
                }


                if (!PageValidate.IsNumber(this.txtproduct_type_id.Text.Trim()))
                {
                    strErr += "product_type_id��������\\n";
                }
                if (!PageValidate.IsNumber(this.txtproduct_spec_weight.Text.Trim()))
                {
                    strErr += "product_spec_weight��������\\n";
                }

                if (this.type == "0")
                {

                    if (!PageValidate.IsDecimal(this.txtorder_add_price.Text.Trim()))
                    {
                        strErr += "order_add_price��������\\n";
                    }
                    if (!PageValidate.IsDecimal(this.txttrade_add_price.Text.Trim()))
                    {
                        strErr += "trade_add_price��������\\n";
                    }

                }
                else if (this.type == "1")
                {
                    if (!PageValidate.IsDecimal(this.txtsilver.Text.Trim()))
                    {
                        strErr += "silver_price��������\\n";
                    }
                }
                if (strErr != "")
                {
                    MessageBox.Show(this, strErr);
                    return false;
                }


                string product_type_id = this.txtproduct_type_id.Text.Trim();
                string product_type_name = this.drpproduct_type_name.Text.Trim();
                string product_spec_weight = this.txtproduct_spec_weight.Text.Trim();
                string product_state = "0";

                string order_add_price = this.txtorder_add_price.Text.Trim();
                string trade_add_price = this.txttrade_add_price.Text.Trim();
                string silver_price = this.txtsilver.Text.Trim();



                string ins_user = Session["admin"].ToString();
                //string ins_date = DateTime.Parse(DateTime.Now.ToString());
                string upd_user = " ";
                string check_name = bll.check_id(product_type_id);
                string check_id = bll.check_name(product_type_name);

                if (check_name == "" && check_id != "")//ID ���µģ�����name���������ݿ���
                {
                    MessageBox.Show(this, "��Ʒ��������Ѿ����������ݱ��У��������µĲ�Ʒ�������");
                    return false;

                }
                else if (check_id == "" && check_name != "")//name���µģ����ǲ�ƷID�Ѿ��������ݿ���
                {
                    MessageBox.Show(this, "��Ʒ���ID�Ѿ����������ݱ��У��������µĲ�Ʒ���ID");
                    return false;
                }
                else if (check_id != "" && check_name != "")
                {

                    if (product_type_id != check_id || product_type_name != check_name)
                    {
                        MessageBox.Show(this, "����Ĳ�Ʒ���ID�Ͳ�Ʒ������Ʋ�ƥ�䣬���������Ƿ���ȷ");
                        return false;
                    }


                }


                Boolean tag = bll.Exists(Convert.ToInt32(product_type_id), Convert.ToInt32(product_spec_weight));

                if (tag)
                {
                    MessageBox.Show(this, "������ļ�¼�Ѿ����ڣ��޷���������ȷ�������Ƿ���ȷ");
                    return false;
                }

            }
            catch
            {
                MessageBox.Show(this, "��֤ʧ��");
                return false;
            }

            return true;


        }

    }
}
