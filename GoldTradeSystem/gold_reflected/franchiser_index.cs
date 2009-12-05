namespace GoldTradeNaming.Web
{
    using GoldTradeNaming.BLL;
    using System;
    using System.Data;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public class franchiser_index : Page
    {
        protected HyperLink lblSendInfo;

        private void loadData()
        {
            bool hasNewMsg = false;
            string strWhere = "AND (franchiser_info.franchiser_code = '" + Convert.ToString(this.Session["fran"]) + "')";
            DataSet ds = new GoldTradeNaming.BLL.send_main().GetListByFranID(strWhere);
            if ((ds.Tables.Count > 0) && (ds.Tables[0].Rows.Count > 0))
            {
                hasNewMsg = true;
                this.lblSendInfo.Text = "(1) 您有" + ds.Tables[0].Rows.Count.ToString() + "张收货单待确认。";
            }
            else
            {
                this.lblSendInfo.Text = "";
            }
            if (!hasNewMsg)
            {
                this.lblSendInfo.NavigateUrl = "";
                this.lblSendInfo.Text = "现在没有最新消息。";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                if ((this.Session["fran"] == null) || (this.Session["fran"].ToString() == ""))
                {
                    base.Response.Clear();
                    base.Response.Write(@"<script defer>window.alert('您没有权限登录本系统！\n请重新登录或与管理员联系');history.back();</script>");
                    base.Response.End();
                }
                else
                {
                    this.loadData();
                }
            }
        }
    }
}
