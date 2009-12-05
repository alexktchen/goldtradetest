namespace GoldTradeNaming.Web.franchiser_info
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

    public class franReport : Page
    {
        protected AutoCompleteExtender AutoCompleteExtender1;
        protected Button btnQuery;
        protected Button Button2;
        protected HtmlGenericControl divSilverTradeDesc;
        protected HtmlGenericControl divTradeDesc;
        private bool DownloadExcelFlag = false;
        protected GridView gvTradeDesc;
        protected Label k;
        protected Label Label1;
        protected Label Label2;
        protected Label lblfranchiser_code;
        protected ScriptManager ScriptManager1;
        private decimal totalBanlance;
        private decimal totalMoney;
        private decimal totalOrder;
        private decimal totalTrade;
        protected TextBox txtDateE;
        protected TextBox txtDateS;
        protected TextBox txtfranchiser_code;
        protected TextBox txtfranchiser_name;

        protected void btnQuery_Click(object sender, EventArgs e)
        {
            string franId = this.txtfranchiser_code.Text.Trim();
            string franName = this.txtfranchiser_name.Text.Trim();
            string dateS = this.txtDateS.Text.Trim();
            string dateE = this.txtDateE.Text.Trim();
            this.gvTradeDesc.DataSource = CommBaseBLL.GetReportData(franId, dateS, dateE, franName);
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
                this.totalBanlance += Convert.ToDecimal(e.Row.Cells[1].Text.Trim());
                this.totalMoney += Convert.ToDecimal((e.Row.Cells[2].Text.Trim() == "&nbsp;") ? "0" : e.Row.Cells[2].Text.Trim());
                this.totalOrder += Convert.ToDecimal((e.Row.Cells[3].Text.Trim() == "&nbsp;") ? "0" : e.Row.Cells[3].Text.Trim());
                this.totalTrade += Convert.ToDecimal((e.Row.Cells[4].Text.Trim() == "&nbsp;") ? "0" : e.Row.Cells[4].Text.Trim());
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[0].Text = "合计";
                e.Row.Cells[1].Text = this.totalBanlance.ToString();
                e.Row.Cells[2].Text = this.totalMoney.ToString();
                e.Row.Cells[3].Text = this.totalOrder.ToString();
                e.Row.Cells[4].Text = this.totalTrade.ToString();
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
            else if (!(((this.Session["admin"] != null) && (this.Session["admin"].ToString() != "")) && CommBaseBLL.HasRight(Convert.ToInt32(this.Session["admin"]), Authority.FranExcel.ToString())))
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
