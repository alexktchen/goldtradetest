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

namespace GoldTradeNaming.Web
{
    public partial class franchiser_index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["fran"] == null || Session["fran"].ToString() == "")
                {
                    Response.Clear();
                    Response.Write("<script defer>window.alert('" + "您没有权限登录本系统！\\n请重新登录或与管理员联系" + "');history.back();</script>");
                    Response.End();
                    return;
                }
                loadData();
            }
        }

        private void loadData()
        {
            string strWhere = "AND (franchiser_info.franchiser_code = '" + Convert.ToString(Session["fran"]) + "')";
            GoldTradeNaming.BLL.send_main bll = new GoldTradeNaming.BLL.send_main();
            DataSet ds = bll.GetListByFranID(strWhere);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                this.lblSendInfo.Text = "(1) 您有" + ds.Tables[0].Rows.Count.ToString() + "张收货单待确认。";
            }
            else
            {
                this.lblSendInfo.Text = "";
            }
        }
    }
}
