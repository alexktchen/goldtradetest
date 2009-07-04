using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using LTP.Common;
namespace GoldTradeNaming.Web.franchiser_trade
{
    public partial class Show : System.Web.UI.Page
    {
        GoldTradeNaming.BLL.franchiser_trade bll = new GoldTradeNaming.BLL.franchiser_trade();
        protected void Page_LoadComplete(object sender, EventArgs e)
        {
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["fran"] == null || Session["fran"].ToString() == "")
            {
                Session.Clear();
                Response.Clear();
                LTP.Common.MessageBox.ShowAndRedirect(this, "您没有权限或登录超时！\\n请重新登录或与管理员联系", "../User_Login/flogin.aspx");
                return;
            }
            if (!Page.IsPostBack)
            {
                bool bl = GetTradeList(true);
                if (bl)
                {
                    divTradeDesc.Style.Add("display", "none");
                    divSilverTradeDesc.Style.Add("display","none");
                    divTotalMsg.Style.Add("display", "none");
                    divTrade.Style.Add("display", "block");
                }
            }

        }
        protected void gvTrade_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int sTradeID =Convert.ToInt32(gvTrade.SelectedRow.Cells[0].Text.Trim());
                DataSet ds = bll.GetTradeDesc(sTradeID);
                //gvTradeDesc.DataSource = ds;
                //gvTradeDesc.DataBind();
                //Session["gvTradeDesc"] = ds;              
             
                lblTotalMoney.Text = gvTrade.SelectedRow.Cells[3].Text.Trim()+"元";
                lblTradeTime.Text = gvTrade.SelectedRow.Cells[1].Text.Trim();

                if (ds.Tables[0].Rows[0]["type"].ToString().Trim() == "1")
                {                    
                    gvSilverTradeDesc.DataSource = ds;
                    gvSilverTradeDesc.DataBind();
                    Session["gvSilverTradeDesc"] = ds;
                    Session["gvTradeDesc"] = null;
                    divSilverTradeDesc.Style.Add("display", "block");
                }
                else
                {
                    gvTradeDesc.DataSource = ds;
                    gvTradeDesc.DataBind();
                    Session["gvTradeDesc"] = ds;
                    Session["gvSilverTradeDesc"] = null;
                    divTradeDesc.Style.Add("display", "block");
                }
                divTotalMsg.Style.Add("display", "block");
                divTrade.Style.Add("display", "none");
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
                return;
            }            
                   
        }

        protected void gvTrade_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.gvTrade.PageIndex = e.NewPageIndex;
            this.gvTrade.DataSource = Session["gvTrade"] as DataSet;
            this.gvTrade.DataBind();
        }

        protected void gvTradeDesc_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.gvTradeDesc.PageIndex = e.NewPageIndex;
            this.gvTradeDesc.DataSource = Session["gvTradeDesc"] as DataSet;
            this.gvTradeDesc.DataBind();

        }
        protected void gvSilverTradeDesc_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.gvSilverTradeDesc.PageIndex = e.NewPageIndex;
            this.gvTradeDesc.DataSource = Session["gvSilverTradeDesc"] as DataSet;
            this.gvTradeDesc.DataBind();
        }

       
        /// <summary>
        /// 返回
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnReturn_Click(object sender, EventArgs e)
        {
            gvTradeDesc.DataSource = null;
            gvTradeDesc.DataBind();
            gvTrade.SelectedIndex = -1;

            divTradeDesc.Style.Add("display", "none");
            divSilverTradeDesc.Style.Add("display", "none");
            divTotalMsg.Style.Add("display", "none");
            divTrade.Style.Add("display", "block");
        }

        protected void btnReNew_Click(object sender, EventArgs e)
        {
            txtBeginDate.Text = "";
            txtEndDate.Text = "";
            // txtReason.Text = "";
            txttrade_id.Text = "";
            gvTrade.SelectedIndex = -1;
        }

        protected void btnQuery_Click(object sender, EventArgs e)
        {
            if (GetTradeList(false))
            {
                gvTrade.SelectedIndex = -1;
                divTradeDesc.Style.Add("display", "none");
                divSilverTradeDesc.Style.Add("display", "none");
                divTotalMsg.Style.Add("display", "none");
                divTrade.Style.Add("display", "block");
            }
        }

        private bool GetTradeList(bool isInit)
        {
            int franchiser_code = Convert.ToInt32(Session["fran"].ToString().Trim());       
            DateTime dtFrom = new DateTime(1900,1,1);
            DateTime dtTo = new DateTime(1900,1,1);
            int trade_id=-1;
       
            if (isInit)
            {
            }
            else
            {
                if(this.txttrade_id.Text.Trim() != "")
                {
                    try
                    {
                        trade_id = Convert.ToInt32(txttrade_id.Text.Trim());
                    }
                    catch
                    {
                        MessageBox.Show(this,"请输入正确的交易编号");
                        return false;
                    }
                }
                if (txtBeginDate.Text.Trim() != "")
                {
                    try
                    {
                        dtFrom = Convert.ToDateTime(txtBeginDate.Text.Trim());
                    }
                    catch
                    {
                        MessageBox.Show(this, "请输入正确的时间格式");
                        return false;
                    }
                }

                if (txtEndDate.Text.Trim() != "")
                {
                    try
                    {
                        dtTo = Convert.ToDateTime(txtEndDate.Text.Trim());
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
                DataSet ds = bll.GetAllTrade(franchiser_code,trade_id,dtFrom,dtTo,isInit);
                gvTrade.DataSource = ds;
                gvTrade.DataBind();
                Session["gvTrade"] = ds;             
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
                return false;
            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Clear();
            DownloadExcelFlag = true; 
            Response.Buffer = true;
            Response.Charset = "utf-8";
            Response.AppendHeader("Content-Disposition", "attachment;filename=" + DateTime.Today.ToString("yyyyMMdd") + ".xls");
            //Response.AppendHeader("Content-Disposition", "attachment;filename=FileName.xls");
            // 如果设置为 GetEncoding("GB2312");导出的文件将会出现乱码！！！
            Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312"); //System.Text.Encoding.UTF8;
            //Response.Write(" <meta http-equiv=Content-Type content=\"text/html; charset=GB2312\"> "); 

            this.EnableViewState = false; 
            Response.ContentType = "application/ms-excel";//设置输出文件类型为excel文件。 
            System.IO.StringWriter oStringWriter = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter oHtmlTextWriter = new System.Web.UI.HtmlTextWriter(oStringWriter);
            this.gvTrade.RenderControl(oHtmlTextWriter);
            Response.Output.Write(oStringWriter.ToString());
            Response.Flush();
            Response.End();
        }

        bool DownloadExcelFlag = false;

        public override void RenderControl(HtmlTextWriter writer)
        {
            if (DownloadExcelFlag)
                this.gvTrade.RenderControl(writer);  //仅仅输出GridView1 
            else
                base.RenderControl(writer);
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            if (!DownloadExcelFlag)
                base.VerifyRenderingInServerForm(control);
        } 

    }
}
