namespace GoldTradeNaming.Web.realtime_price
{
    using AjaxControlToolkit;
    using GoldTradeNaming.BLL;
    using GoldTradeNaming.Model;
    using LTP.Common;
    using System;
    using System.Data;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public class Show : Page
    {
        private GoldTradeNaming.BLL.realtime_price bll = new GoldTradeNaming.BLL.realtime_price();
        protected Button btnSearch;
        protected CalendarExtender calendarButtonExtender;
        protected CalendarExtender CalendarExtender1;
        protected GridView gvList;
        protected ImageButton Image1;
        protected ImageButton ImageButton1;
        protected Label lblFrom;
        protected Label lblTo;
        protected ScriptManager ScriptManager1;
        protected TextBox txtTimeFrom;
        protected TextBox txtTimeTo;

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            DateTime dtFrom = new DateTime(0x76c, 1, 1);
            DateTime dtTo = DateTime.Now;
            string errMsg = "";
            if (this.txtTimeFrom.Text.Trim() != "")
            {
                try
                {
                    dtFrom = Convert.ToDateTime(this.txtTimeFrom.Text.Trim());
                }
                catch
                {
                    errMsg = errMsg + "起始日期输入错误！";
                }
            }
            if (this.txtTimeTo.Text.Trim() != "")
            {
                try
                {
                    dtTo = Convert.ToDateTime(this.txtTimeTo.Text.Trim());
                }
                catch
                {
                    errMsg = errMsg + "终止日期输入错误！";
                }
            }
            if (errMsg != "")
            {
                MessageBox.Show(this, errMsg);
            }
            else
            {
                DataSet ds = this.SearchPrice(dtFrom, dtTo);
                if ((ds != null) && (ds.Tables[0].Rows.Count > 0))
                {
                    this.Session["gvList"] = ds;
                    this.gvList.DataSource = ds;
                    this.gvList.DataBind();
                }
                else
                {
                    this.gvList.DataSource = null;
                    this.gvList.DataBind();
                    MessageBox.Show(this, "查无记录！");
                }
            }
        }

        protected void gvList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.gvList.PageIndex = e.NewPageIndex;
            if (this.Session["gvList"] != null)
            {
                this.gvList.DataSource = this.Session["gvList"] as DataSet;
                this.gvList.DataBind();
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
            else if (!(((this.Session["admin"] != null) && (this.Session["admin"].ToString() != "")) && CommBaseBLL.HasRight(Convert.ToInt32(this.Session["admin"]), Authority.ViewPrice.ToString())))
            {
                base.Response.Clear();
                base.Response.Write(@"<script defer>window.alert('您没有权限操作该功能！\n请重新登录或与管理员联系');history.back();</script>");
                base.Response.End();
            }
            else if (!this.Page.IsPostBack)
            {
                DataSet ds = this.SearchPrice(DateTime.Now.AddMonths(-1), DateTime.Now);
                this.gvList.DataSource = ds;
                this.Session["gvList"] = ds;
                this.gvList.DataBind();
            }
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            (base.Master.FindControl("lblTitle") as Label).Text = "基础金价管理";
        }

        private DataSet SearchPrice(DateTime dtFrom, DateTime dtTo)
        {
            return this.bll.GetList(dtFrom, dtTo);
        }
    }
}
