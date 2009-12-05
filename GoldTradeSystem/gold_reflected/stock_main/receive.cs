namespace GoldTradeNaming.Web.stock_main
{
    using GoldTradeNaming.BLL;
    using LTP.Common;
    using System;
    using System.Data;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public class receive : Page
    {
        protected GridView GridView1;
        protected Label Label1;
        protected Label Label2;

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ConfirmRecv")
            {
                GridViewRow drv = (GridViewRow) ((Button) e.CommandSource).Parent.Parent;
                int RowIndex = drv.RowIndex;
                int frnId = Convert.ToInt32(this.Session["fran"]);
                int sndId = Convert.ToInt32(((HyperLink) this.GridView1.Rows[RowIndex].Cells[0].Controls[0]).Text);
                int odrId = Convert.ToInt32(this.GridView1.Rows[RowIndex].Cells[5].Text);
                send_main sendbll = new send_main();
                if (sendbll.ConfirmReceive(frnId, odrId, sndId))
                {
                    MessageBox.ShowAndRedirect(this, "确认成功！", "receive.aspx");
                }
            }
        }

        private void loadData()
        {
            string strWhere = "AND (franchiser_info.franchiser_code = '" + Convert.ToString(this.Session["fran"]) + "')";
            DataSet ds = new send_main().GetListByFranID(strWhere);
            if ((ds.Tables.Count > 0) && (ds.Tables[0].Rows.Count > 0))
            {
                this.Label2.Text = "您有" + ds.Tables[0].Rows.Count.ToString() + "张收货单待确认。";
                this.GridView1.DataSource = ds.Tables[0];
                this.GridView1.DataBind();
            }
            else
            {
                this.Label2.Text = "您目前没有收货单！";
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
            else if (!this.Page.IsPostBack)
            {
                this.loadData();
            }
        }
    }
}
