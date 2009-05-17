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
            (Master.FindControl("lblTitle") as Label).Text = "发货管理";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] == null || Session["admin"].ToString() == "")
            {
                Session.Clear();
                Response.Clear();
                LTP.Common.MessageBox.ShowAndRedirect(this, "您没有权限或登录超时！\\n请重新登录或与管理员联系", "../User_Login/AdminLogin.aspx");
                return;
            }

            if (Session["admin"] == null || Session["admin"].ToString() == ""
                    || !GoldTradeNaming.BLL.CommBaseBLL.HasRight(Convert.ToInt32(Session["admin"]), Model.Authority.Send.ToString()))
            {
                Response.Clear();
                Response.Write("<script defer>window.alert('" + "您没有权限操作该功能！\\n请重新登录或与管理员联系" + "');history.back();</script>");
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
                #region 订单主表信息绑定

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

                #region 订单产品信息绑定

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
                MessageBox.Show(this, "信息读取有误！");
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
                sendmain.send_id = 0;  //存档时取下一个ID
                sendmain.send_amount_weight = 0;//暂设为0，待遍历Grid后取值                
                sendmain.ins_user = Session["admin"].ToString();
                sendmain.upd_user = Session["admin"].ToString();
                sendmain.upd_date = DateTime.Now;
                sendmain.ins_date = DateTime.Now;
                //判断
                List<GoldTradeNaming.Model.send_desc> senddescList = new List<GoldTradeNaming.Model.send_desc>();
                GoldTradeNaming.Model.send_desc sdone;
                foreach (GridViewRow gvr in this.GridView1.Rows)
                {
                    //没输入则不计算
                    if (((TextBox)gvr.FindControl("txtProdNum")).Text.Trim() == "") continue;

                    sdone = new GoldTradeNaming.Model.send_desc();
                    sdone.id = 0;
                    sdone.ins_date = DateTime.Now;
                    sdone.ins_user = Session["admin"].ToString();
                    sdone.product_id = Convert.ToInt32(gvr.Cells[7].Text);
                    sdone.product_spec_id = Convert.ToDecimal(gvr.Cells[1].Text);
                    sdone.send_amount_weight = sdone.product_spec_id * Convert.ToInt32(((TextBox)gvr.FindControl("txtProdNum")).Text.ToString().Trim());
                    sendmain.send_amount_weight += sdone.send_amount_weight;//计算出发货总量
                    sdone.send_id = 0;//Convert.ToInt32(this.franid.Value);
                    sdone.upd_date = DateTime.Now;
                    sdone.upd_user = Session["admin"] as string;

                    senddescList.Add(sdone);
                }
                if (sendmain.send_amount_weight <= 0) MessageBox.Show(this, "发货总重量为0！");
                else
                {
                    GoldTradeNaming.BLL.send_main bll = new GoldTradeNaming.BLL.send_main();
                    if (bll.SaveSendInfo(sendmain, senddescList))
                    {
                        MessageBox.ShowAndRedirect(this, "发货成功！请等待经销商确认...", "../send_main/Show.aspx");
                    }
                    else
                    {
                        MessageBox.Show(this, "发货失败，请重新操作！");
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(this, "保存时发生错误:"+ex.Message);
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
                        this.Label2.Text = "数量必须为数字！";
                        return false;
                    }

                    if (num_input > unreceived_num)
                    {
                        this.Label2.Text = "数量不能大于待发数量！";
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
            int mount = 0;//数量
            decimal ProdWht = 0; //重量小计

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
                    this.Label2.Text = "数量必须为数字！";
                    ((Label)GridView1.Rows[drv.RowIndex].FindControl("lblProdWht")).Text = "";
                    ((TextBox)GridView1.Rows[drv.RowIndex].FindControl("txtProdNum")).Focus();
                    //t.Focus();
                    return;
                }
                if (spec_weight * mount > unreceived_weight)
                {
                    this.Label2.Text = "重量不能大于待发重量！";
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
                MessageBox.Show(this, "发生未知错误，请与管理员联系！");
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
                if (GridView1.Rows[row].Cells[0].RowSpan == 0) GridView1.Rows[row].Cells[0].RowSpan++;
                GridView1.Rows[row].Cells[0].RowSpan++;

                e.Row.Cells[0].Visible = false;
            }
            //开始下轮合并
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
