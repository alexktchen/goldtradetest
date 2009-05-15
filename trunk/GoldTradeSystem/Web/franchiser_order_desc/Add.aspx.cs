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
    public partial class Add : System.Web.UI.Page
    {
        private GoldTradeNaming.Model.franchiser_order mOrderMain;
        private List<GoldTradeNaming.Model.franchiser_order_desc> orderdescList;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["fran"] == null || Session["fran"].ToString() == "")
            {
                Session.Clear();
                Response.Clear();
                LTP.Common.MessageBox.ShowAndRedirect(this, "��û��Ȩ�޻��¼��ʱ��\\n�����µ�¼�������Ա��ϵ", "../User_Login/flogin.aspx");
                return;
            }
            if (!Page.IsPostBack)
            {
                if (!(Session["orderdesclist"] == null || Session["orderdesclist"].ToString() == ""))
                {
                    LoadProduct();
                }
                else
                {
                    LoadOrderInfo();
                }
            }

        }
        public void LoadProduct()
        {
            LoadData();
            this.orderdescList = Session["orderdesclist"] as List<GoldTradeNaming.Model.franchiser_order_desc>;
            this.mOrderMain = Session["OrderMain"] as GoldTradeNaming.Model.franchiser_order;

            //���list��һ����¼��product_type_id��prduct_spec_id��GridView1�е���ͬ�����GridView1�еĸ��и�ֵ
            foreach (GridViewRow gvr in GridView1.Rows)
            {
                for (int i = 0; i < this.orderdescList.Count; i++)
                {
                    if (gvr.Cells[0].Text.Trim() == this.orderdescList[i].product_id.ToString().Trim() && gvr.Cells[2].Text.Trim() == this.orderdescList[i].product_spec_id.ToString().Trim())
                    {
                        ((TextBox)gvr.FindControl("txtProdNum")).Text = this.orderdescList[i].order_product_amount.ToString().Trim();
                        ((Label)gvr.FindControl("lblProdWht")).Text = this.orderdescList[i].order_weight.ToString().Trim();

                        ((Label)gvr.FindControl("lblAmountMoney")).Text = (this.orderdescList[i].product_spec_id * this.orderdescList[i].order_product_amount * this.orderdescList[i].order_appraise).ToString().Trim();
                        break;
                    }
                }
            }
        }

        private void LoadOrderInfo()
        {
            this.mOrderMain = Session["OrderMain"] as GoldTradeNaming.Model.franchiser_order;
            //Session.Remove("OrderMain");
            //ViewState["orderm"] = this.mOrderMain;
            LoadData();
        }

        private void LoadData()
        {
            GoldTradeNaming.BLL.franchiser_order orderbll = new GoldTradeNaming.BLL.franchiser_order();

            DataSet ds;
            this.mOrderMain = Session["OrderMain"] as GoldTradeNaming.Model.franchiser_order;
            if (this.mOrderMain.Product_type == "0")
                ds = orderbll.GetGoldProduct();
            else if (this.mOrderMain.Product_type == "1")
                ds = orderbll.GetSilverProduct();
            else return;
            GridView1.UpdateAfterCallBack = true;
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            //(Master.FindControl("lblTitle") as Label).Text = "���߶���";
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                CommBaseBLL bll = new CommBaseBLL();
                DataSet dsPrice = bll.getCurrentPrice();
                int franid = Convert.ToInt32(Session["fran"]);

                GoldTradeNaming.BLL.franchiser_info bllfrn = new GoldTradeNaming.BLL.franchiser_info();
                GoldTradeNaming.Model.franchiser_info frninfo = bllfrn.GetModel(franid);

                this.mOrderMain = Session["OrderMain"] as GoldTradeNaming.Model.franchiser_order;

                List<GoldTradeNaming.Model.franchiser_order_desc> orderdescList = new List<GoldTradeNaming.Model.franchiser_order_desc>();

                foreach (GridViewRow gvr in GridView1.Rows)
                {
                    //û�����򲻴浵
                    if (((TextBox)gvr.FindControl("txtProdNum")).Text.Trim() == "") continue;
                    if (((Label)gvr.FindControl("lblProdWht")).Text.Trim() == "") continue;

                    GoldTradeNaming.Model.franchiser_order_desc odrDesc = new GoldTradeNaming.Model.franchiser_order_desc();
                    odrDesc.id = 0;
                    odrDesc.franchiser_order_id = 0;
                    odrDesc.order_product_amount = Convert.ToInt32(((TextBox)gvr.FindControl("txtProdNum")).Text.Trim());
                    odrDesc.product_id = Convert.ToInt32(gvr.Cells[0].Text);
                    odrDesc.product_spec_id = Convert.ToDecimal(gvr.Cells[2].Text);
                    odrDesc.product_received = 0;
                    odrDesc.product_unreceived = Convert.ToDecimal(((Label)gvr.FindControl("lblProdWht")).Text.Trim());//��ʼΪ����С��
                    odrDesc.realtime_base_price = CommBaseBLL.getRealTimePrice();
                    odrDesc.order_add_price = Convert.ToDecimal(gvr.Cells[5].Text);
                    odrDesc.order_appraise = Convert.ToDecimal(gvr.Cells[6].Text);
                    odrDesc.order_weight = Convert.ToDecimal(((Label)gvr.FindControl("lblProdWht")).Text.Trim());
                    odrDesc.ins_date = DateTime.Now;
                    odrDesc.ins_user = Session["fran"] as string;
                    odrDesc.upd_date = DateTime.Now;
                    odrDesc.upd_user = Session["fran"] as string;
                    this.mOrderMain.franchiser_order_amount_money += decimal.Round(odrDesc.order_weight * odrDesc.order_appraise,4);
                    orderdescList.Add(odrDesc);
                }
                if (this.mOrderMain.franchiser_order_amount_money <= 0.00M)
                {
                    MessageBox.Show(this, "�����붩����Ʒ��");
                }
                else if (this.mOrderMain.franchiser_order_amount_money > CommBaseBLL.GetBalance(this.mOrderMain.franchiser_code))
                {
                    this.mOrderMain.franchiser_order_amount_money = 0.00M;
                    MessageBox.Show(this, "���㣡");
                }
                else
                {
                    GoldTradeNaming.BLL.franchiser_order order = new GoldTradeNaming.BLL.franchiser_order();

                    if (order.SaveOrderInfo(this.mOrderMain, orderdescList))
                    {
                        MessageBox.ShowAndRedirect(this, "�����ɹ�����ȴ�����...", "../franchiser_order/Show.aspx");
                        //MessageBox.Show(this, "�����ɹ�����ȴ�����...");
                    }
                    else
                    {
                        MessageBox.Show(this, "����ʧ�ܣ������²�����");
                    }
                }
            }
            catch
            {
                MessageBox.Show(this, "�������̷�����������ϵ����Ա��");
            }
        }

        public bool CheckInput()
        {
            return true;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow gvr in GridView1.Rows)
            {

                ((TextBox)gvr.FindControl("txtProdNum")).Text = "";
                ((Label)gvr.FindControl("lblProdWht")).Text = "";

                ((Label)gvr.FindControl("lblAmountMoney")).Text = "";


            }
        }

        /// <summary>
        /// GridView �ϲ���Ԫ��
        /// </summary>
        int row = 0;
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int rowindex = e.Row.RowIndex;
            //�Ƿ�Ϊ��һ��
            if (rowindex - 1 < 0) return;

            //�Ƿ�����һ�в�Ʒ�����ͬ����ͬ��������ѭ��
            if (e.Row.Cells[0].Text == GridView1.Rows[rowindex - 1].Cells[0].Text)
            {
                //�Ƿ�Ϊ���ֵ�һ�ο�ʼ�ϲ�����Ϊspan=1û�����壬�ض���2��ʼ
                if (GridView1.Rows[row].Cells[1].RowSpan == 0) GridView1.Rows[row].Cells[1].RowSpan++;
                GridView1.Rows[row].Cells[1].RowSpan++;

                e.Row.Cells[1].Visible = false;
            }
            //��ʼ���ֺϲ�
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




        protected void ProdNumChge(object sender, EventArgs e)
        {
            TextBox t = (TextBox)sender;
            int mount = 0;//����
            decimal ProdWht = 0; //����С��
            decimal appriseMoney = 0;//Ԥ�����

            GridViewRow drv = (GridViewRow)t.NamingContainer;
            int rowIndex = drv.RowIndex;
            try
            {
                //�������
                decimal spec_weight = Convert.ToDecimal(GridView1.Rows[drv.RowIndex].Cells[2].Text.ToString());
                //Ԥ������
                decimal appraise = Convert.ToDecimal(GridView1.Rows[drv.RowIndex].Cells[6].Text.ToString());

                try
                {
                    mount = Convert.ToInt32(t.Text.Trim());
                    ProdWht = mount * spec_weight;
                }
                catch
                {
                    this.Label2.Text = "��������Ϊ���֣�";
                    ((Label)GridView1.Rows[drv.RowIndex].FindControl("lblProdWht")).Text = "";
                    ((Label)GridView1.Rows[drv.RowIndex].FindControl("lblAmountMoney")).Text = "";
                    //t.Focus();
                    return;
                }

                appriseMoney = decimal.Round(ProdWht * appraise,4);
                ((Label)GridView1.Rows[drv.RowIndex].FindControl("lblProdWht")).Text = ProdWht.ToString();

                ((Label)GridView1.Rows[drv.RowIndex].FindControl("lblAmountMoney")).Text = appriseMoney.ToString();

                GridView1.UpdateAfterCallBack = true;
            }
            catch (Exception ex)
            {
                ((Label)GridView1.Rows[drv.RowIndex].FindControl("lblProdWht")).Text = "";
                ((Label)GridView1.Rows[drv.RowIndex].FindControl("lblAmountMoney")).Text = "";
                Label2.Text = ex.Message;
                t.Focus();
            }



        }

        protected void Next_Click(object sender, EventArgs e)
        {
            try
            {
                CommBaseBLL bll = new CommBaseBLL();
                DataSet dsPrice = bll.getCurrentPrice();
                int franid = Convert.ToInt32(Session["fran"]);

                GoldTradeNaming.BLL.franchiser_info bllfrn = new GoldTradeNaming.BLL.franchiser_info();
                GoldTradeNaming.Model.franchiser_info frninfo = bllfrn.GetModel(franid);

                this.mOrderMain = Session["OrderMain"] as GoldTradeNaming.Model.franchiser_order;

                List<GoldTradeNaming.Model.franchiser_order_desc> orderdescList = new List<GoldTradeNaming.Model.franchiser_order_desc>();

                foreach (GridViewRow gvr in GridView1.Rows)
                {
                    //û�����򲻴浵
                    if (((TextBox)gvr.FindControl("txtProdNum")).Text.Trim() == "") continue;
                    if (((Label)gvr.FindControl("lblProdWht")).Text.Trim() == "") continue;

                    GoldTradeNaming.Model.franchiser_order_desc odrDesc = new GoldTradeNaming.Model.franchiser_order_desc();
                    odrDesc.id = 0;
                    odrDesc.franchiser_order_id = 0;
                    odrDesc.order_product_amount = Convert.ToInt32(((TextBox)gvr.FindControl("txtProdNum")).Text.Trim());
                    odrDesc.product_id = Convert.ToInt32(gvr.Cells[0].Text);
                    odrDesc.product_spec_id = Convert.ToDecimal(gvr.Cells[2].Text);
                    odrDesc.product_received = 0;
                    odrDesc.product_unreceived = Convert.ToDecimal(((Label)gvr.FindControl("lblProdWht")).Text.Trim());//��ʼΪ����С��
                    odrDesc.realtime_base_price = CommBaseBLL.getRealTimePrice();
                    odrDesc.order_add_price = Convert.ToDecimal(gvr.Cells[5].Text);
                    odrDesc.order_appraise = Convert.ToDecimal(gvr.Cells[6].Text);
                    odrDesc.order_weight = Convert.ToDecimal(((Label)gvr.FindControl("lblProdWht")).Text.Trim());
                    odrDesc.ins_date = DateTime.Now;
                    odrDesc.ins_user = Session["fran"] as String;
                    odrDesc.upd_date = DateTime.Now;
                    odrDesc.upd_user = Session["fran"] as string;
                    this.mOrderMain.franchiser_order_amount_money += decimal.Round(odrDesc.order_weight * odrDesc.order_appraise,4);
                    orderdescList.Add(odrDesc);
                }
                if (this.mOrderMain.franchiser_order_amount_money <= 0.00M)
                {
                    MessageBox.Show(this, "�����붩����Ʒ��");
                }
                else if (this.mOrderMain.franchiser_order_amount_money > CommBaseBLL.GetBalance(this.mOrderMain.franchiser_code))
                {
                    this.mOrderMain.franchiser_order_amount_money = 0.00M;
                    MessageBox.Show(this, "���㣡");
                }
                else
                {
                    Session["orderdesclist"] = orderdescList;

                    Response.Redirect("~/franchiser_order_desc/Add_submit.aspx");
                }


            }
            catch
            {
                MessageBox.Show(this, "�������̷�����������ϵ����Ա��");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("../franchiser_order/Add.aspx?prodtype=" + ((GoldTradeNaming.Model.franchiser_order)Session["OrderMain"]).Product_type);
        }


    }
}
