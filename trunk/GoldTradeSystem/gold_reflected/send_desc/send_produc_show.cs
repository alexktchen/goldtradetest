namespace GoldTradeNaming.Web.send_desc
{
    using GoldTradeNaming.BLL;
    using LTP.Common;
    using System;
    using System.Data;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public class send_produc_show : Page
    {
        private readonly send_desc bll = new send_desc();
        protected ScriptManager ScriptManager1;
        protected GridView showData;
        protected TextBox txtFranchiserName;
        protected TextBox txtSendId;
        protected TextBox txtTotalWeight;

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
                string fran_id = this.Session["fran"].ToString();
                if ((base.Request.Params["sendid"] != null) && (base.Request.Params["sendid"].Trim() != ""))
                {
                    string send_id = base.Request.Params["sendid"].ToString();
                    this.showInformation(send_id);
                    this.txtFranchiserName.Text = this.bll.getFranName(fran_id);
                    this.txtTotalWeight.Text = this.bll.getSendAmountWeight(send_id);
                    this.txtSendId.Text = send_id;
                }
            }
        }

        protected void showData_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
        }

        private void showInformation(string send_id)
        {
            try
            {
                DataSet ds = this.bll.getSendDesc(send_id);
                if ((ds == null) || (ds.Tables[0].Rows.Count == 0))
                {
                    this.showData.Visible = false;
                }
                else
                {
                    this.showData.PageIndex = 0;
                    this.showData.DataSource = ds;
                    this.showData.DataBind();
                    this.showData.DataKeyNames = new string[] { "id" };
                    this.showData.Visible = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
