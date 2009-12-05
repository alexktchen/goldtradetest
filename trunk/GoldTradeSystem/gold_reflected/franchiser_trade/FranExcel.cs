namespace GoldTradeNaming.Web.franchiser_trade
{
    using GoldTradeNaming.BLL;
    using LTP.Common;
    using System;
    using System.IO;
    using System.Text;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class FranExcel : Page
    {
        private franchiser_trade bll = new franchiser_trade();
        protected Button btnQuery;
        protected Button Button2;
        protected HtmlGenericControl divSilverTradeDesc;
        protected HtmlGenericControl divTradeDesc;
        private bool DownloadExcelFlag = false;
        protected DropDownList drpType;
        protected GridView gvTradeDesc;
        private decimal totalMoney;
        private int totalNum;
        protected TextBox txtBeginDate;
        protected TextBox txtEndDate;
        protected TextBox txttrade_id;

        protected void btnQuery_Click(object sender, EventArgs e)
        {
            string tradeId = this.txttrade_id.Text.Trim();
            string timeS = this.txtBeginDate.Text.Trim();
            string timeE = this.txtEndDate.Text.Trim();
            string type = (this.drpType.SelectedValue.Trim() == "2") ? "" : this.drpType.SelectedValue.Trim();
            this.gvTradeDesc.DataSource = this.bll.GetTradeReportData(this.Session["fran"].ToString(), tradeId, timeS, timeE, type, "");
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
                this.totalNum += Convert.ToInt32(e.Row.Cells[5].Text.ToString());
                this.totalMoney += Convert.ToDecimal(e.Row.Cells[6].Text.ToString());
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[0].Text = "合计";
                e.Row.Cells[5].Text = this.totalNum.ToString();
                e.Row.Cells[6].Text = this.totalMoney.ToString();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((this.Session["fran"] == null) || (this.Session["fran"].ToString() == ""))
            {
                this.Session.Clear();
                base.Response.Clear();
                MessageBox.ShowAndRedirect(this, @"您没有权限或登录超时！\n请重新登录或与管理员联系", "../User_Login/flogin.aspx");
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
