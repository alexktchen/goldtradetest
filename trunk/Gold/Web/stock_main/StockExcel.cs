namespace GoldTradeNaming.Web.stock_main
{
    using AjaxControlToolkit;
    using GoldTradeNaming.BLL;
    using GoldTradeNaming.Model;
    using LTP.Common;
    using System;
    using System.IO;
    using System.Text;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public class StockExcel : Page
    {
        protected AutoCompleteExtender AutoCompleteExtender1;
        protected Button btnQuery;
        protected Button Button2;
        private bool DownloadExcelFlag = false;
        protected GridView gvTradeDesc;
        protected Label k;
        protected Label Label1;
        protected Label Label2;
        protected Label lblfranchiser_code;
        protected ScriptManager ScriptManager1;
        private decimal totalOrder;
        private decimal totalStock;
        private decimal totalTrade;
        protected TextBox txtDateE;
        protected TextBox txtDateS;
        protected TextBox txtfranchiser_code;
        protected TextBox txtPrdName;

        protected void btnQuery_Click(object sender, EventArgs e)
        {
            string franName = this.txtfranchiser_code.Text.Trim();
            string prdName = this.txtPrdName.Text.Trim();
            string dateS = this.txtDateS.Text.Trim();
            string dateE = this.txtDateE.Text.Trim();
            this.gvTradeDesc.DataSource = CommBaseBLL.GetStockReportData(franName, prdName, dateS, dateE);
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
                this.totalOrder += Convert.ToDecimal((e.Row.Cells[3].Text.Trim() == "&nbsp;") ? "0" : e.Row.Cells[3].Text.Trim());
                this.totalTrade += Convert.ToDecimal((e.Row.Cells[4].Text.Trim() == "&nbsp;") ? "0" : e.Row.Cells[4].Text.Trim());
                this.totalStock += Convert.ToDecimal((e.Row.Cells[5].Text.Trim() == "&nbsp;") ? "0" : e.Row.Cells[5].Text.Trim());
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[0].Text = "合计";
                e.Row.Cells[3].Text = this.totalOrder.ToString();
                e.Row.Cells[4].Text = this.totalTrade.ToString();
                e.Row.Cells[5].Text = this.totalStock.ToString();
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
            else if (!(((this.Session["admin"] != null) && (this.Session["admin"].ToString() != "")) && CommBaseBLL.HasRight(Convert.ToInt32(this.Session["admin"]), Authority.StockExcel.ToString())))
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
