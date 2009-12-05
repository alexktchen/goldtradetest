namespace GoldTradeNaming.Web.franchiser_trade
{
    using AjaxControlToolkit;
    using GoldTradeNaming.BLL;
    using GoldTradeNaming.Model;
    using LTP.Common;
    using System;
    using System.IO;
    using System.Text;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class AdminExcel : Page
    {
        protected AutoCompleteExtender AutoCompleteExtender1;
        private GoldTradeNaming.BLL.franchiser_trade bll = new GoldTradeNaming.BLL.franchiser_trade();
        protected Button btnQuery;
        protected Button Button2;
        protected HtmlGenericControl divSilverTradeDesc;
        protected HtmlGenericControl divTradeDesc;
        private bool DownloadExcelFlag = false;
        protected DropDownList drpType;
        protected GridView gvTradeDesc;
        protected Label Label1;
        protected Label lblfranchiser_code;
        protected ScriptManager ScriptManager1;
        private decimal totalMoney;
        private int totalNum;
        protected TextBox txtBeginDate;
        protected TextBox txtEndDate;
        protected TextBox txtfranchiser_code;
        protected TextBox txtfranchiser_name;
        protected TextBox txttrade_id;

        protected void btnQuery_Click(object sender, EventArgs e)
        {
            string tradeId = this.txttrade_id.Text.Trim();
            string franId = this.txtfranchiser_code.Text.Trim();
            string timeS = this.txtBeginDate.Text.Trim();
            string timeE = this.txtEndDate.Text.Trim();
            string type = (this.drpType.SelectedValue.Trim() == "2") ? "" : this.drpType.SelectedValue.Trim();
            string franName = this.txtfranchiser_name.Text.Trim();
            this.gvTradeDesc.DataSource = this.bll.GetTradeReportData(franId, tradeId, timeS, timeE, type, franName);
            this.gvTradeDesc.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Clear();
            this.DownloadExcelFlag = true;
            base.Response.Buffer = true;
            base.Response.Charset = "utf-8";
            base.Response.AppendHeader("Content-Disposition", "attachment;filename=" + DateTime.Today.ToString("yyyyMMdd") + ".xls");
            base.Response.ContentEncoding = Encoding.GetEncoding("utf-8");
            this.EnableViewState = false;
            base.Response.ContentType = "application/ms-excel";
            StringWriter oStringWriter = new StringWriter();
            HtmlTextWriter oHtmlTextWriter = new HtmlTextWriter(oStringWriter);
            this.gvTradeDesc.RenderControl(oHtmlTextWriter);
            base.Response.Output.Write(oStringWriter.ToString());
            base.Response.Flush();
            base.Response.End();
        }

        protected void gvTradeDesc_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                this.totalNum += Convert.ToInt32(e.Row.Cells[6].Text.ToString());
                this.totalMoney += Convert.ToDecimal(e.Row.Cells[7].Text.ToString());
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[0].Text = "合计";
                e.Row.Cells[6].Text = this.totalNum.ToString();
                e.Row.Cells[7].Text = this.totalMoney.ToString();
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
            else if (!(((this.Session["admin"] != null) && (this.Session["admin"].ToString() != "")) && CommBaseBLL.HasRight(Convert.ToInt32(this.Session["admin"]), Authority.TradeExcel.ToString())))
            {
                base.Response.Clear();
                base.Response.Write(@"<script defer>window.alert('您没有权限操作该功能！\n请重新登录或与管理员联系');history.back();</script>");
                base.Response.End();
            }
        }

        public override void RenderControl(HtmlTextWriter writer)
        {
            if (this.DownloadExcelFlag)
            {
                this.gvTradeDesc.RenderControl(writer);
            }
            else
            {
                base.RenderControl(writer);
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            if (!this.DownloadExcelFlag)
            {
                base.VerifyRenderingInServerForm(control);
            }
        }
    }
}
