namespace GoldTradeNaming.Web.send_desc
{
    using Anthem;
    using GoldTradeNaming.BLL;
    using GoldTradeNaming.Model;
    using LTP.Common;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Text;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public class Show : Page
    {
        protected System.Web.UI.WebControls.Button btnCancel;
        protected System.Web.UI.WebControls.Button btnSave;
        protected System.Web.UI.WebControls.HiddenField franid;
        protected Anthem.GridView GridView1;
        protected System.Web.UI.WebControls.Label Label1;
        protected System.Web.UI.WebControls.Label Label2;
        protected System.Web.UI.WebControls.Label lbltrans;
        protected System.Web.UI.WebControls.HiddenField orderid;
        private int row = 0;
        protected System.Web.UI.WebControls.TextBox txtfranchiser_code;
        protected System.Web.UI.WebControls.TextBox txtfranchiser_order_address;
        protected System.Web.UI.WebControls.TextBox txtfranchiser_order_amount_money;
        protected System.Web.UI.WebControls.TextBox txtfranchiser_order_handle_man;
        protected System.Web.UI.WebControls.TextBox txtfranchiser_order_handle_phone;
        protected System.Web.UI.WebControls.TextBox txtfranchiser_order_handle_tel;
        protected System.Web.UI.WebControls.TextBox txtfranchiser_order_postcode;
        protected System.Web.UI.WebControls.TextBox txtfranchiser_order_price;
        protected System.Web.UI.WebControls.TextBox txtOrderTime;

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            base.Response.Redirect(string.Format("../send_main/Show.aspx?fid={0}&id={1}", this.franid.Value, this.orderid.Value));
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ChkInput())
                {
                    GoldTradeNaming.Model.send_main sendmain = new GoldTradeNaming.Model.send_main();
                    sendmain.canceled_reason = "";
                    sendmain.franchiser_order_id = Convert.ToInt32(this.orderid.Value);
                    sendmain.send_time = DateTime.Now;
                    sendmain.send_state = "0";
                    sendmain.send_id = 0;
                    sendmain.send_amount_weight = 0M;
                    sendmain.ins_user = this.Session["admin"].ToString();
                    sendmain.upd_user = this.Session["admin"].ToString();
                    sendmain.upd_date = DateTime.Now;
                    sendmain.ins_date = DateTime.Now;
                    List<GoldTradeNaming.Model.send_desc> senddescList = new List<GoldTradeNaming.Model.send_desc>();
                    foreach (GridViewRow gvr in this.GridView1.Rows)
                    {
                        if (((System.Web.UI.WebControls.TextBox) gvr.FindControl("txtProdNum")).Text.Trim() != "")
                        {
                            GoldTradeNaming.Model.send_desc sdone = new GoldTradeNaming.Model.send_desc();
                            sdone.id = 0;
                            sdone.ins_date = DateTime.Now;
                            sdone.ins_user = this.Session["admin"].ToString();
                            sdone.product_id = Convert.ToInt32(gvr.Cells[7].Text);
                            sdone.product_spec_id = Convert.ToDecimal(gvr.Cells[1].Text);
                            sdone.send_amount_weight = sdone.product_spec_id * Convert.ToInt32(((System.Web.UI.WebControls.TextBox) gvr.FindControl("txtProdNum")).Text.ToString().Trim());
                            sendmain.send_amount_weight += sdone.send_amount_weight;
                            sdone.send_id = 0;
                            sdone.upd_date = DateTime.Now;
                            sdone.upd_user = this.Session["admin"] as string;
                            senddescList.Add(sdone);
                        }
                    }
                    if (sendmain.send_amount_weight <= 0M)
                    {
                        MessageBox.Show(this, "发货总重量为0！");
                    }
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "保存时发生错误:" + ex.Message);
            }
        }

        private bool ChkInput()
        {
            try
            {
                foreach (GridViewRow dgv in this.GridView1.Rows)
                {
                    if (((System.Web.UI.WebControls.TextBox) dgv.FindControl("txtProdNum")).Text.Trim() != "")
                    {
                        int num_input;
                        int unreceived_num = Convert.ToInt32(dgv.Cells[4].Text.ToString());
                        try
                        {
                            num_input = Convert.ToInt32(((System.Web.UI.WebControls.TextBox) dgv.FindControl("txtProdNum")).Text.ToString().Trim());
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
            }
            catch
            {
                return false;
            }
            return true;
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int rowindex = e.Row.RowIndex;
            if ((rowindex - 1) >= 0)
            {
                if (e.Row.Cells[0].Text == this.GridView1.Rows[rowindex - 1].Cells[0].Text)
                {
                    if (this.GridView1.Rows[this.row].Cells[0].RowSpan == 0)
                    {
                        TableCell cell1 = this.GridView1.Rows[this.row].Cells[0];
                        cell1.RowSpan++;
                    }
                    TableCell cell2 = this.GridView1.Rows[this.row].Cells[0];
                    cell2.RowSpan++;
                    e.Row.Cells[0].Visible = false;
                }
                else
                {
                    this.row = rowindex;
                }
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
            else if (!(((this.Session["admin"] != null) && (this.Session["admin"].ToString() != "")) && CommBaseBLL.HasRight(Convert.ToInt32(this.Session["admin"]), Authority.Send.ToString())))
            {
                base.Response.Clear();
                base.Response.Write(@"<script defer>window.alert('您没有权限操作该功能！\n请重新登录或与管理员联系');history.back();</script>");
                base.Response.End();
            }
            else if (!this.Page.IsPostBack)
            {
                this.SetBind();
            }
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            (base.Master.FindControl("lblTitle") as System.Web.UI.WebControls.Label).Text = "发货管理";
        }

        protected void ProdNumChg(object sender, EventArgs e)
        {
            System.Web.UI.WebControls.TextBox t = (System.Web.UI.WebControls.TextBox) sender;
            int mount = 0;
            decimal ProdWht = 0M;
            GridViewRow drv = (GridViewRow) t.NamingContainer;
            int rowIndex = drv.RowIndex;
            try
            {
                decimal spec_weight = Convert.ToDecimal(this.GridView1.Rows[drv.RowIndex].Cells[1].Text.ToString());
                decimal unreceived_weight = Convert.ToDecimal(this.GridView1.Rows[drv.RowIndex].Cells[4].Text.ToString());
                try
                {
                    mount = Convert.ToInt32(t.Text.Trim());
                    ProdWht = mount * spec_weight;
                }
                catch
                {
                    this.Label2.Text = "数量必须为数字！";
                    ((System.Web.UI.WebControls.Label) this.GridView1.Rows[drv.RowIndex].FindControl("lblProdWht")).Text = "";
                    ((System.Web.UI.WebControls.TextBox) this.GridView1.Rows[drv.RowIndex].FindControl("txtProdNum")).Focus();
                    return;
                }
                if ((spec_weight * mount) > unreceived_weight)
                {
                    this.Label2.Text = "重量不能大于待发重量！";
                    ((System.Web.UI.WebControls.Label) this.GridView1.Rows[drv.RowIndex].FindControl("lblProdWht")).Text = "";
                    ((System.Web.UI.WebControls.TextBox) this.GridView1.Rows[drv.RowIndex].FindControl("txtProdNum")).Focus();
                }
                else
                {
                    this.Label2.Text = "";
                    ((System.Web.UI.WebControls.Label) this.GridView1.Rows[drv.RowIndex].FindControl("lblProdWht")).Text = (mount * spec_weight).ToString();
                }
            }
            catch (ArgumentException ex)
            {
                ((System.Web.UI.WebControls.Label) this.GridView1.Rows[drv.RowIndex].FindControl("lblProdWht")).Text = "";
                this.Label2.Text = ex.Message;
                t.Focus();
            }
            catch
            {
                MessageBox.Show(this, "发生未知错误，请与管理员联系！");
            }
        }

        private void SetBind()
        {
            try
            {
                this.txtfranchiser_code.Text = base.Request.QueryString["fnm"].ToString();
                this.franid.Value = base.Request.QueryString["fid"].ToString();
                this.orderid.Value = base.Request.QueryString["id"].ToString();
                StringBuilder strWhere = new StringBuilder();
                strWhere.Append(" AND franchiser_order.franchiser_order_id = '");
                strWhere.Append(this.orderid.Value);
                strWhere.Append("'");
                DataSet dsOrder = new GoldTradeNaming.BLL.send_main().GetOrderInfo(strWhere.ToString());
                if ((dsOrder.Tables.Count > 0) && (dsOrder.Tables[0].Rows.Count > 0))
                {
                    DataRow drOrder = dsOrder.Tables[0].Rows[0];
                    this.lbltrans.Text = drOrder["franchiser_order_trans_type"].ToString();
                    this.txtfranchiser_order_address.Text = drOrder["franchiser_order_address"].ToString();
                    this.txtfranchiser_order_postcode.Text = drOrder["franchiser_order_postcode"].ToString();
                    this.txtfranchiser_order_handle_man.Text = drOrder["franchiser_order_handle_man"].ToString();
                    this.txtfranchiser_order_handle_tel.Text = drOrder["franchiser_order_handle_tel"].ToString();
                    this.txtfranchiser_order_handle_phone.Text = drOrder["franchiser_order_handle_phone"].ToString();
                    this.txtfranchiser_order_price.Text = drOrder["franchiser_order_price"].ToString();
                    this.txtOrderTime.Text = drOrder["franchiser_order_time"].ToString();
                    this.txtfranchiser_order_amount_money.Text = drOrder["franchiser_order_amount_money"].ToString();
                }
                strWhere = new StringBuilder();
                strWhere.Append(" franchiser_order_id = '");
                strWhere.Append(this.orderid.Value + "'");
                DataSet ds = new GoldTradeNaming.BLL.send_main().GetOrderedProductList(strWhere.ToString());
                this.GridView1.DataSource = ds;
                this.GridView1.DataBind();
            }
            catch
            {
                MessageBox.Show(this, "信息读取有误！");
            }
        }
    }
}
