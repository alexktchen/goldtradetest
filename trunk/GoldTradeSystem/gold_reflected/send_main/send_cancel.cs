namespace GoldTradeNaming.Web.send_main
{
    using GoldTradeNaming.BLL;
    using GoldTradeNaming.Model;
    using LTP.Common;
    using System;
    using System.Data;
    using System.Text;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public class send_cancel : Page
    {
        protected DropDownList DropDownList1;
        protected GridView GridView1;
        protected HiddenField hdnSendState;
        protected Label Label1;
        protected Label Label2;
        protected Label Label4;
        protected Label Label5;
        protected Button Query;
        protected TextBox txtOrderId;
        protected TextBox txtSendId;

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridView1.PageIndex = e.NewPageIndex;
            this.GridView1.DataSource = this.Session["grd_Data"] as DataSet;
            this.GridView1.DataBind();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "CancelSend")
            {
                GridViewRow drv = (GridViewRow) ((Button) e.CommandSource).Parent.Parent;
                int RowIndex = drv.RowIndex;
                string reason = ((TextBox) this.GridView1.Rows[RowIndex].FindControl("txtCnclRsn")).Text.Trim();
                if (this.hdnSendState.Value == "1")
                {
                    MessageBox.Show(this, "已收货，不可取消！");
                }
                else
                {
                    if (this.hdnSendState.Value == "2")
                    {
                        MessageBox.Show(this, "已取消，不可重复操作！");
                    }
                    if (string.IsNullOrEmpty(reason))
                    {
                        MessageBox.Show(this, "请输入取消原因！");
                    }
                    else
                    {
                        GoldTradeNaming.Model.send_main mdl_sm = new GoldTradeNaming.Model.send_main();
                        mdl_sm.send_id = Convert.ToInt32(((HyperLink) this.GridView1.Rows[RowIndex].Cells[0].Controls[0]).Text);
                        mdl_sm.send_state = "2";
                        mdl_sm.upd_user = this.Session["admin"] as string;
                        mdl_sm.canceled_reason = reason;
                        GoldTradeNaming.BLL.send_main bllsm = new GoldTradeNaming.BLL.send_main();
                        if (bllsm.CancelSend(mdl_sm) > 0)
                        {
                            MessageBox.Show(this, "取消成功！");
                            this.Query_Click(this, new EventArgs());
                        }
                    }
                }
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack && ((((this.Session["admin"] == null) || (this.Session["admin"].ToString() == "")) || (this.Session["SendM"] == null)) || (this.Session["SendM"].ToString() == "")))
            {
                base.Response.Clear();
                base.Response.Write(@"<script defer>window.alert('您没有权限登录本系统！\n请重新登录或与管理员联系');history.back();</script>");
                base.Response.End();
            }
        }

        protected void Query_Click(object sender, EventArgs e)
        {
            StringBuilder strWhere = new StringBuilder();
            if (this.txtOrderId.Text.Trim() == "")
            {
                strWhere.Append(" 1=1");
            }
            else
            {
                strWhere.Append("send_id = '");
                strWhere.Append(this.txtOrderId.Text.Trim());
                strWhere.Append("'");
            }
            if (this.txtSendId.Text.Trim() == "")
            {
                strWhere.Append(" AND 1=1");
            }
            else
            {
                strWhere.Append(" AND franchiser_order_id  = '");
                strWhere.Append(this.txtSendId.Text.Trim());
                strWhere.Append("'");
            }
            strWhere.Append(" AND send_state ='" + this.DropDownList1.SelectedIndex.ToString() + "'");
            this.hdnSendState.Value = this.DropDownList1.SelectedIndex.ToString();
            try
            {
                this.Session["grd_Data"] = new GoldTradeNaming.BLL.send_main().GetList(strWhere.ToString());
                this.GridView1.DataSource = this.Session["grd_Data"] as DataSet;
                this.GridView1.DataBind();
            }
            catch
            {
            }
        }
    }
}
