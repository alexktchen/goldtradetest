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
using LTP.Common;

namespace GoldTradeNaming.Web.stock_main
{
    public partial class receive : System.Web.UI.Page
    {
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
                this.Label2.Text = "您有"+ ds.Tables[0].Rows.Count.ToString()+"张收货单待确认。";
                this.GridView1.DataSource = ds.Tables[0];
                this.GridView1.DataBind();
            }
            else
            {
                this.Label2.Text = "您目前没有收货单！";
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ConfirmRecv")
            {
                GridViewRow drv = ((GridViewRow)(((Button)(e.CommandSource)).Parent.Parent));
                int RowIndex = drv.RowIndex;

                int frnId = Convert.ToInt32(Session["fran"]);
                int sndId = Convert.ToInt32(((HyperLink)GridView1.Rows[RowIndex].Cells[0].Controls[0]).Text);
                int odrId = Convert.ToInt32(GridView1.Rows[RowIndex].Cells[5].Text);

                //ConfirmReceive
                GoldTradeNaming.BLL.send_main sendbll = new GoldTradeNaming.BLL.send_main();
                if (sendbll.ConfirmReceive(frnId, odrId, sndId))
                {
                    MessageBox.ShowAndRedirect(this,"确认成功！","receive.aspx");
                    //loadData();
                }
            }
        }
    }
}
