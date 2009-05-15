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
namespace GoldTradeNaming.Web.realtime_price
{
    public partial class Show:System.Web.UI.Page
    {
        private GoldTradeNaming.BLL.realtime_price bll = new GoldTradeNaming.BLL.realtime_price();
        protected void Page_LoadComplete(object sender,EventArgs e)
        {
            (Master.FindControl("lblTitle") as Label).Text = "������۹���";
        }
        protected void Page_Load(object sender,EventArgs e)
        {
            if (Session["admin"] == null || Session["admin"].ToString() == "")
            {
                Session.Clear();
                Response.Clear();
                LTP.Common.MessageBox.ShowAndRedirect(this, "��û��Ȩ�޻��¼��ʱ��\\n�����µ�¼�������Ա��ϵ", "../User_Login/AdminLogin.aspx");
                return;
            }

            if (Session["admin"] == null || Session["admin"].ToString() == ""
                    || !GoldTradeNaming.BLL.CommBaseBLL.HasRight(Convert.ToInt32(Session["admin"]), Model.Authority.ViewPrice.ToString()))
            {
                Response.Clear();
                Response.Write("<script defer>window.alert('" + "��û��Ȩ�޲����ù��ܣ�\\n�����µ�¼�������Ա��ϵ" + "');history.back();</script>");
                Response.End();
                return;
            }
            if(!Page.IsPostBack)
            {   
                DataSet ds = SearchPrice(DateTime.Now.AddMonths(-1),DateTime.Now);
                gvList.DataSource = ds;
                Session["gvList"] = ds;
                gvList.DataBind();
            }
        }

        protected void btnSearch_Click(object sender,EventArgs e)
        {
            DateTime dtFrom = Convert.ToDateTime("2000/01/01");
            DateTime dtTo = DateTime.Now;
            string errMsg = "";
            if(txtTimeFrom.Text.Trim() != "")
            {
                try
                {
                    dtFrom = Convert.ToDateTime(txtTimeFrom.Text.Trim());
                }
                catch
                {
                    errMsg += "��ʼ�����������";
                }
            }

            if(txtTimeTo.Text.Trim() != "")
            {
                try
                {
                    dtTo = Convert.ToDateTime(txtTimeTo.Text.Trim());
                }
                catch
                {
                    errMsg += "��ֹ�����������";
                }
            }

            if(errMsg != "")
            {
                MessageBox.Show(this,errMsg);
                return;
            }

            DataSet ds = SearchPrice(dtFrom,dtTo);
            if(ds != null && ds.Tables[0].Rows.Count > 0)
            {
                Session["gvList"] = ds;
                this.gvList.DataSource = ds;
                this.gvList.DataBind();             
            }
            else
                MessageBox.Show(this,"���޼�¼��");
        }
       
        protected void gvList_PageIndexChanging(object sender,GridViewPageEventArgs e)
        {
            this.gvList.PageIndex = e.NewPageIndex;

            if(Session["gvList"] != null)
            {
                this.gvList.DataSource = Session["gvList"] as DataSet;
                this.gvList.DataBind();
            }
            else
            {
                Session["gvList"] = SearchPrice(Convert.ToDateTime("2000/01/01"),DateTime.Now);
                this.gvList.DataSource = Session["gvList"] as DataSet;
                this.gvList.DataBind();
            }
        }

        private DataSet SearchPrice(DateTime dtFrom,DateTime dtTo)
        {
            DataSet ds;
            StringBuilder strWhere = new StringBuilder();
            strWhere.Append("a.realtime_time between'" + dtFrom.ToString("yyyy/MM/dd") + "' and '" + dtTo.ToString("yyyy/MM/dd 23:59:59") + "' order by a.realtime_time desc ");

            ds = bll.GetList(strWhere.ToString());
            return ds;
        }

    }
}
