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
namespace GoldTradeNaming.Web.send_desc
{
    public partial class Show : System.Web.UI.Page
    {       
        //private static bool isInputNumRight = true;
    
        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            (Master.FindControl("lblTitle") as Label).Text = "��������";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] == null || Session["admin"].ToString() == "")
            {
                Session.Clear();
                Response.Clear();
                LTP.Common.MessageBox.ShowAndRedirect(this, "��û��Ȩ�޻��¼��ʱ��\\n�����µ�¼�������Ա��ϵ", "../User_Login/AdminLogin.aspx");
                return;
            }

            if (Session["admin"] == null || Session["admin"].ToString() == ""
                    || !GoldTradeNaming.BLL.CommBaseBLL.HasRight(Convert.ToInt32(Session["admin"]), Model.Authority.Send.ToString()))
            {
                Response.Clear();
                Response.Write("<script defer>window.alert('" + "��û��Ȩ�޲����ù��ܣ�\\n�����µ�¼�������Ա��ϵ" + "');history.back();</script>");
                Response.End();
                return;
            }
            if (!Page.IsPostBack)
            {
              
                SetBind();
            }
        }

        private void SetBind()
        {
            try
            {
                #region ����������Ϣ��

                this.txtfranchiser_code.Text = Request.QueryString["fnm"].ToString();
               // this.mFranID = Convert.ToInt32(Request.QueryString["fid"].ToString());
               // this.mOrderID = Convert.ToInt32(Request.QueryString["id"].ToString());
                this.franid.Value =Request.QueryString["fid"].ToString();
                this.orderid.Value = Request.QueryString["id"].ToString();
                StringBuilder strWhere = new StringBuilder();

                strWhere.Append(" AND franchiser_order.franchiser_order_id = '");
                strWhere.Append(this.orderid.Value);
                strWhere.Append("'");

                GoldTradeNaming.BLL.send_main bll = new GoldTradeNaming.BLL.send_main();
                DataSet dsOrder = bll.GetOrderInfo(strWhere.ToString());

                if (dsOrder.Tables.Count > 0 && dsOrder.Tables[0].Rows.Count > 0)
                {
                    DataRow drOrder = dsOrder.Tables[0].Rows[0];
                    //this.transway.SelectedIndex = Convert.ToInt32(drOrder["franchiser_order_trans_type"].ToString());
                    this.lbltrans.Text = drOrder["franchiser_order_trans_type"].ToString();
                    this.txtfranchiser_order_address.Text = drOrder["franchiser_order_address"].ToString();
                    this.txtfranchiser_order_postcode.Text = drOrder["franchiser_order_postcode"].ToString();
                    this.txtfranchiser_order_handle_man.Text = drOrder["franchiser_order_handle_man"].ToString();
                    this.txtfranchiser_order_handle_tel.Text = drOrder["franchiser_order_handle_tel"].ToString();
                    this.txtfranchiser_order_handle_phone.Text = drOrder["franchiser_order_handle_phone"].ToString();
                    this.txtfranchiser_order_price.Text = drOrder["franchiser_order_price"].ToString();
                    this.txtOrderTime.Text = drOrder["franchiser_order_time"].ToString();
                   // this.txtfranchiser_order_add_price.Text = drOrder["franchiser_order_add_price"].ToString();
                   // this.txtfranchiser_order_appraise.Text = drOrder["franchiser_order_appraise"].ToString();
                    this.txtfranchiser_order_amount_money.Text = drOrder["franchiser_order_amount_money"].ToString();
                }
                #endregion

                #region ������Ʒ��Ϣ��

                strWhere = new StringBuilder();
                strWhere.Append(" franchiser_order_id = '");
                strWhere.Append(this.orderid.Value + "'");
                GoldTradeNaming.BLL.send_main orderdscBll = new GoldTradeNaming.BLL.send_main();
                DataSet ds = orderdscBll.GetOrderedProductList(strWhere.ToString());
                GridView1.DataSource = ds;
                GridView1.DataBind();

                #endregion
            }
            catch
            {
                MessageBox.Show(this, "��Ϣ��ȡ����");
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ChkInput()) return;
                GoldTradeNaming.Model.send_main sendmain = new GoldTradeNaming.Model.send_main();
                sendmain.canceled_reason = "";
                sendmain.franchiser_order_id = Convert.ToInt32(this.orderid.Value);
                sendmain.send_time = DateTime.Now;
                sendmain.send_state = "0";
                sendmain.send_id = 0;  //�浵ʱȡ��һ��ID
                sendmain.send_amount_weight = 0;//����Ϊ0��������Grid��ȡֵ                
                sendmain.ins_user = Session["admin"].ToString();
                sendmain.upd_user = Session["admin"].ToString();
                sendmain.upd_date = DateTime.Now;
                sendmain.ins_date = DateTime.Now;
                //�ж�
                List<GoldTradeNaming.Model.send_desc> senddescList = new List<GoldTradeNaming.Model.send_desc>();
                GoldTradeNaming.Model.send_desc sdone;
                foreach (GridViewRow gvr in this.GridView1.Rows)
                {
                    //û�����򲻼���
                    if (((TextBox)gvr.FindControl("txtProdNum")).Text.Trim() == "") continue;

                    sdone = new GoldTradeNaming.Model.send_desc();
                    sdone.id = 0;
                    sdone.ins_date = DateTime.Now;
                    sdone.ins_user = Session["admin"].ToString();
                    sdone.product_id = Convert.ToInt32(gvr.Cells[7].Text);
                    sdone.product_spec_id = Convert.ToDecimal(gvr.Cells[1].Text);
                    sdone.send_amount_weight = sdone.product_spec_id * Convert.ToInt32(((TextBox)gvr.FindControl("txtProdNum")).Text.ToString().Trim());
                    sendmain.send_amount_weight += sdone.send_amount_weight;//�������������
                    sdone.send_id = 0;//Convert.ToInt32(this.franid.Value);
                    sdone.upd_date = DateTime.Now;
                    sdone.upd_user = Session["admin"] as string;

                    senddescList.Add(sdone);
                }
                if (sendmain.send_amount_weight <= 0) MessageBox.Show(this, "����������Ϊ0��");
                else
                {
                    GoldTradeNaming.BLL.send_main bll = new GoldTradeNaming.BLL.send_main();
                    if (bll.SaveSendInfo(sendmain, senddescList))
                    {
                        MessageBox.ShowAndRedirect(this, "�����ɹ�����ȴ�������ȷ��...", "../send_main/Show.aspx");
                    }
                    else
                    {
                        MessageBox.Show(this, "����ʧ�ܣ������²�����");
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(this, "����ʱ��������:"+ex.Message);
            }
        }

        private bool ChkInput()
        {
            try
            {
                foreach (GridViewRow dgv in GridView1.Rows)
                {
                    if (((TextBox)dgv.FindControl("txtProdNum")).Text.Trim() == "") continue;
                    int unreceived_num = Convert.ToInt32(dgv.Cells[4].Text.ToString());
                    int num_input;
                    try
                    {
                        num_input = Convert.ToInt32(((TextBox)dgv.FindControl("txtProdNum")).Text.ToString().Trim());
                    }
                    catch
                    {
                        this.Label2.Text = "��������Ϊ���֣�";
                        return false;
                    }

                    if (num_input > unreceived_num)
                    {
                        this.Label2.Text = "�������ܴ��ڴ���������";
                        return false;
                    }
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        protected void ProdNumChg(object sender, EventArgs e)
        {
            TextBox t = (TextBox)sender;
            int mount = 0;//����
            decimal ProdWht = 0; //����С��

            GridViewRow drv = (GridViewRow)t.NamingContainer;
            int rowIndex = drv.RowIndex;
            try
            {
                decimal spec_weight = Convert.ToDecimal(GridView1.Rows[drv.RowIndex].Cells[1].Text.ToString());
                decimal unreceived_weight = Convert.ToDecimal(GridView1.Rows[drv.RowIndex].Cells[4].Text.ToString());
                
                try
                {
                    mount = Convert.ToInt32(t.Text.Trim());
                    ProdWht = mount * spec_weight;
                }
                catch
                {
                    this.Label2.Text = "��������Ϊ���֣�";
                    ((Label)GridView1.Rows[drv.RowIndex].FindControl("lblProdWht")).Text = "";
                    ((TextBox)GridView1.Rows[drv.RowIndex].FindControl("txtProdNum")).Focus();
                    //t.Focus();
                    return;
                }
                if (spec_weight * mount > unreceived_weight)
                {
                    this.Label2.Text = "�������ܴ��ڴ���������";
                    ((Label)GridView1.Rows[drv.RowIndex].FindControl("lblProdWht")).Text = "";
                    ((TextBox)GridView1.Rows[drv.RowIndex].FindControl("txtProdNum")).Focus();
                    //t.Focus();
                }
                else
                {
                    this.Label2.Text = "";
                    ((Label)GridView1.Rows[drv.RowIndex].FindControl("lblProdWht")).Text = (mount * spec_weight).ToString();
                }               
            }
            catch (ArgumentException ex)
            {
                ((Label)GridView1.Rows[drv.RowIndex].FindControl("lblProdWht")).Text = "";
                Label2.Text = ex.Message;
                t.Focus();
            }
            catch
            {
                MessageBox.Show(this, "����δ֪�����������Ա��ϵ��");
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
                if (GridView1.Rows[row].Cells[0].RowSpan == 0) GridView1.Rows[row].Cells[0].RowSpan++;
                GridView1.Rows[row].Cells[0].RowSpan++;

                e.Row.Cells[0].Visible = false;
            }
            //��ʼ���ֺϲ�
            else
            {
                row = rowindex;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(String.Format("../send_main/Show.aspx?fid={0}&id={1}",this.franid.Value,this.orderid.Value));
        }
    }
}
