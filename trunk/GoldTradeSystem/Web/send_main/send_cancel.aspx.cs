using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using System.Text;
using LTP.Common;
namespace GoldTradeNaming.Web.send_main
{
    public partial class send_cancel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["admin"] == null || Session["admin"].ToString() == "" || Session["SendM"] == null || Session["SendM"].ToString() == "")
                {
                    Response.Clear();
                    Response.Write("<script defer>window.alert('" + "您没有权限登录本系统！\\n请重新登录或与管理员联系" + "');history.back();</script>");
                    Response.End();
                    return;
                }
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
            strWhere.Append(" AND send_state ='" + DropDownList1.SelectedIndex.ToString() + "'");
            this.hdnSendState.Value = DropDownList1.SelectedIndex.ToString();
            try
            {
                GoldTradeNaming.BLL.send_main bll = new GoldTradeNaming.BLL.send_main();
                Session["grd_Data"] = bll.GetList(strWhere.ToString());
                this.GridView1.DataSource = Session["grd_Data"] as DataSet;
                this.GridView1.DataBind();
            }
            catch
            {
                
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "CancelSend")
            {
                GridViewRow drv = ((GridViewRow)(((Button)(e.CommandSource)).Parent.Parent));//CommandSource 引起事件的命令源
                int RowIndex = drv.RowIndex;
                
                string reason = ((TextBox)GridView1.Rows[RowIndex].FindControl("txtCnclRsn")).Text.Trim();

                if (this.hdnSendState.Value == "1")
                {
                    MessageBox.Show(this,"已收货，不可取消！");
                    return;
                }
                if (this.hdnSendState.Value == "2")
                {
                    MessageBox.Show(this,"已取消，不可重复操作！");
                }
                if (string.IsNullOrEmpty(reason))
                {
                    MessageBox.Show(this, "请输入取消原因！");
                    return;
                }
                
                GoldTradeNaming.Model.send_main mdl_sm = new GoldTradeNaming.Model.send_main();

                mdl_sm.send_id = Convert.ToInt32(((HyperLink)GridView1.Rows[RowIndex].Cells[0].Controls[0]).Text);
                mdl_sm.send_state = "2";
                mdl_sm.upd_user = Session["admin"] as string;
                mdl_sm.canceled_reason = reason;

                GoldTradeNaming.BLL.send_main bllsm = new GoldTradeNaming.BLL.send_main();
                int result = bllsm.CancelSend(mdl_sm);
                if (result > 0)
                {
                    //MessageBox.ShowConfirm(new TextBox(),"取消成功！");
                    MessageBox.Show(this,"取消成功！");
                    Query_Click(this, new EventArgs());
                }

            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridView1.PageIndex = e.NewPageIndex;
            this.GridView1.DataSource = Session["grd_Data"] as DataSet;
            this.GridView1.DataBind();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
           
        }
    }
}
