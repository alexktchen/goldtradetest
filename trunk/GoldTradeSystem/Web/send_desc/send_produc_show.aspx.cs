using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using LTP.Common;


namespace GoldTradeNaming.Web.send_desc
{
    public partial class send_produc_show : System.Web.UI.Page
    {
        private readonly GoldTradeNaming.BLL.send_desc bll = new GoldTradeNaming.BLL.send_desc();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["fran"] == null || Session["fran"].ToString() == "")
                {
                    Response.Clear();
                    Response.Write("<script defer>window.alert('" + "您没有权限登录本系统！\\n请重新登录或与管理员联系" + "');history.back();</script>");
                    Response.End();
                    showData.Visible = false;
                    return;
                }
                else
                {
                    string fran_id = Session["fran"].ToString();
                    if (Request.Params["sendid"] != null && Request.Params["sendid"].Trim() != "")
                    {
                        string send_id = Request.Params["sendid"].ToString();
                        showInformation(send_id);
                        this.txtFranchiserName.Text = this.bll.getFranName(fran_id);
                        this.txtTotalWeight.Text = this.bll.getSendAmountWeight(send_id);
                        this.txtSendId.Text = send_id;
                    }
                }
            }
        }
        private void showInformation(string send_id)
        {
            try
            {
                //GoldTradeNaming.BLL.send_desc bll = new GoldTradeNaming.BLL.send_desc();
                DataSet ds = bll.getSendDesc(send_id);
                if (ds == null || ds.Tables[0].Rows.Count == 0)
                {
                    showData.Visible = false;
                }
                else
                {
                    showData.PageIndex = 0;
                    showData.DataSource = ds;
                    showData.DataBind();
                    showData.DataKeyNames = new string[] { "id" };
                    showData.Visible = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void showData_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }
    
    }
}
