namespace GoldTradeNaming.Web.franchiser_trade
{
    using GoldTradeNaming.BLL;
    using LTP.Common;
    using System;
    using System.Data;
    using System.IO;
    using System.Text;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Show : Page
    {
        private franchiser_trade bll = new franchiser_trade();
        protected Button btnQuery;
        protected Button btnReNew;
        protected Button btnReturn;
        protected Button Button1;
        protected Button Button2;
        protected Button Button3;
        protected HtmlGenericControl divSilverTradeDesc;
        protected HtmlGenericControl divTotalMsg;
        protected HtmlGenericControl divTrade;
        protected HtmlGenericControl divTradeDesc;
        private bool DownloadExcelFlag = false;
        protected GridView gvSilverTradeDesc;
        protected GridView gvTrade;
        protected GridView gvTradeDesc;
        protected Label lblQueryMsg;
        protected Label lblTotalMoney;
        protected Label lblTradeTime;
        protected ScriptManager ScriptManager1;
        protected TextBox txtBeginDate;
        protected TextBox txtEndDate;
        protected TextBox txttrade_id;

        protected void btnQuery_Click(object sender, EventArgs e)
        {
            if (this.GetTradeList(false))
            {
                this.gvTrade.SelectedIndex = -1;
                this.divTradeDesc.Style.Add("display", "none");
                this.divSilverTradeDesc.Style.Add("display", "none");
                this.divTotalMsg.Style.Add("display", "none");
                this.divTrade.Style.Add("display", "block");
            }
        }

        protected void btnReNew_Click(object sender, EventArgs e)
        {
            this.txtBeginDate.Text = "";
            this.txtEndDate.Text = "";
            this.txttrade_id.Text = "";
            this.gvTrade.SelectedIndex = -1;
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            this.gvTradeDesc.DataSource = null;
            this.gvTradeDesc.DataBind();
            this.gvTrade.SelectedIndex = -1;
            this.divTradeDesc.Style.Add("display", "none");
            this.divSilverTradeDesc.Style.Add("display", "none");
            this.divTotalMsg.Style.Add("display", "none");
            this.divTrade.Style.Add("display", "block");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Clear();
            this.DownloadExcelFlag = true;
            base.Response.Buffer = true;
            base.Response.Charset = "utf-8";
            base.Response.AppendHeader("Content-Disposition", "attachment;filename=" + DateTime.Today.ToString("yyyyMMdd") + ".xls");
            base.Response.ContentEncoding = Encoding.GetEncoding("GB2312");
            this.EnableViewState = false;
            base.Response.ContentType = "application/ms-excel";
            StringWriter oStringWriter = new StringWriter();
            HtmlTextWriter oHtmlTextWriter = new HtmlTextWriter(oStringWriter);
            this.gvTrade.RenderControl(oHtmlTextWriter);
            base.Response.Output.Write(oStringWriter.ToString());
            base.Response.Flush();
            base.Response.End();
        }

        private bool GetTradeList(bool isInit)
        {
            int franchiser_code = Convert.ToInt32(this.Session["fran"].ToString().Trim());
            DateTime dtFrom = new DateTime(0x76c, 1, 1);
            DateTime dtTo = new DateTime(0x76c, 1, 1);
            int trade_id = -1;
            if (!isInit)
            {
                if (this.txttrade_id.Text.Trim() != "")
                {
                    try
                    {
                        trade_id = Convert.ToInt32(this.txttrade_id.Text.Trim());
                    }
                    catch
                    {
                        MessageBox.Show(this, "请输入正确的交易编号");
                        return false;
                    }
                }
                if (this.txtBeginDate.Text.Trim() != "")
                {
                    try
                    {
                        dtFrom = Convert.ToDateTime(this.txtBeginDate.Text.Trim());
                    }
                    catch
                    {
                        MessageBox.Show(this, "请输入正确的时间格式");
                        return false;
                    }
                }
                if (this.txtEndDate.Text.Trim() != "")
                {
                    try
                    {
                        dtTo = Convert.ToDateTime(this.txtEndDate.Text.Trim());
                    }
                    catch
                    {
                        MessageBox.Show(this, "请输入正确的时间格式");
                        return false;
                    }
                }
            }
            try
            {
                DataSet ds = this.bll.GetAllTrade(franchiser_code, trade_id, dtFrom, dtTo, isInit);
                this.gvTrade.DataSource = ds;
                this.gvTrade.DataBind();
                this.Session["gvTrade"] = ds;
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
                return false;
            }
        }

        protected void gvSilverTradeDesc_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.gvSilverTradeDesc.PageIndex = e.NewPageIndex;
            this.gvTradeDesc.DataSource = this.Session["gvSilverTradeDesc"] as DataSet;
            this.gvTradeDesc.DataBind();
        }

        protected void gvTrade_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.gvTrade.PageIndex = e.NewPageIndex;
            this.gvTrade.DataSource = this.Session["gvTrade"] as DataSet;
            this.gvTrade.DataBind();
        }

        protected void gvTrade_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int sTradeID = Convert.ToInt32(this.gvTrade.SelectedRow.Cells[0].Text.Trim());
                DataSet ds = this.bll.GetTradeDesc(sTradeID);
                this.lblTotalMoney.Text = this.gvTrade.SelectedRow.Cells[3].Text.Trim() + "元";
                this.lblTradeTime.Text = this.gvTrade.SelectedRow.Cells[1].Text.Trim();
                if (ds.Tables[0].Rows[0]["type"].ToString().Trim() == "1")
                {
                    this.gvSilverTradeDesc.DataSource = ds;
                    this.gvSilverTradeDesc.DataBind();
                    this.Session["gvSilverTradeDesc"] = ds;
                    this.Session["gvTradeDesc"] = null;
                    this.divSilverTradeDesc.Style.Add("display", "block");
                }
                else
                {
                    this.gvTradeDesc.DataSource = ds;
                    this.gvTradeDesc.DataBind();
                    this.Session["gvTradeDesc"] = ds;
                    this.Session["gvSilverTradeDesc"] = null;
                    this.divTradeDesc.Style.Add("display", "block");
                }
                this.divTotalMsg.Style.Add("display", "block");
                this.divTrade.Style.Add("display", "none");
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
            }
        }

        protected void gvTradeDesc_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.gvTradeDesc.PageIndex = e.NewPageIndex;
            this.gvTradeDesc.DataSource = this.Session["gvTradeDesc"] as DataSet;
            this.gvTradeDesc.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((this.Session["fran"] == null) || (this.Session["fran"].ToString() == ""))
            {
                this.Session.Clear();
                base.Response.Clear();
                MessageBox.ShowAndRedirect(this, @"您没有权限或登录超时！\n请重新登录或与管理员联系", "../User_Login/flogin.aspx");
            }
            else if (!this.Page.IsPostBack && this.GetTradeList(true))
            {
                this.divTradeDesc.Style.Add("display", "none");
                this.divSilverTradeDesc.Style.Add("display", "none");
                this.divTotalMsg.Style.Add("display", "none");
                this.divTrade.Style.Add("display", "block");
            }
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
        }

        public override void RenderControl(HtmlTextWriter writer)
        {
            if (this.DownloadExcelFlag)
            {
                this.gvTrade.RenderControl(writer);
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
