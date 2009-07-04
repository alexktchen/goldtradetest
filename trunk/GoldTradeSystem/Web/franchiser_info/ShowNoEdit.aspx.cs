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


namespace GoldTradeNaming.Web.franchiser_info
{
    public partial class ShowNoEdit:System.Web.UI.Page
    {
        private GoldTradeNaming.BLL.franchiser_info bll = new GoldTradeNaming.BLL.franchiser_info();
        private GoldTradeNaming.BLL.goldtrade_IA100 bll100 = new GoldTradeNaming.BLL.goldtrade_IA100();

        protected void Page_LoadComplete(object sender,EventArgs e)
        {
            (Master.FindControl("lblTitle") as Label).Text = "查看经销商";
        }
        protected void Page_Load(object sender,EventArgs e)
        {
            if (Session["admin"] == null || Session["admin"].ToString() == "")
            {
                Session.Clear();
                Response.Clear();
                LTP.Common.MessageBox.ShowAndRedirect(this, "您没有权限或登录超时！\\n请重新登录或与管理员联系", "../User_Login/AdminLogin.aspx");
                return;
            }

            if (Session["admin"] == null || Session["admin"].ToString() == ""
                   || !GoldTradeNaming.BLL.CommBaseBLL.HasRight(Convert.ToInt32(Session["admin"]), Model.Authority.ViewFran.ToString()))
            {
                Response.Clear();
                Response.Write("<script defer>window.alert('" + "您没有权限操作该功能！\\n请重新登录或与管理员联系" + "');history.back();</script>");
                Response.End();
                return;
            } 
            if(!Page.IsPostBack)
            {                
                DataSet ds = SearchFranchiserInfo();
                if(ds != null)
                {
                    gvList.DataSource = ds;
                    gvList.DataBind();
                    Session["gvList"] = ds;
                }
                plSource.Style.Add("display","block");
            }
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
                Session["gvList"] = SearchFranchiserInfo();
                this.gvList.DataSource = Session["gvList"] as DataSet;
                this.gvList.DataBind();
            }
            gvList.SelectedIndex = -1;
        }



        protected void btnReNew_Click(object sender,EventArgs e)
        {
            txtfranchiser_code.Text = "";
            txtfranchiser_name.Text = "";
            gvList.SelectedIndex = -1;
            lblQueryMsg.Text = "";
            // plShow.Style.Add("display","none");
        }

        protected void btnQuery_Click(object sender,EventArgs e)
        {
            DataSet ds = SearchFranchiserInfo();

            if(ds != null && ds.Tables[0].Rows.Count > 0)
            {
                lblQueryMsg.Text = "查询成功";
                Session["gvList"] = ds;
                //   MessageBox.Show(this,"查询成功");
            }
            else
                lblQueryMsg.Text = "查无记录";
            //  MessageBox.Show(this,"查无记录");


            this.gvList.DataSource = ds;
            this.gvList.DataBind();
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        private DataSet SearchFranchiserInfo()
        {

            StringBuilder strWhere = new StringBuilder();

            if(this.txtfranchiser_code.Text.Trim() == "")
            {
                strWhere.Append("1=1");
            }
            else
            {
                strWhere.Append("franchiser_code like N'%");
                strWhere.Append(GoldTradeNaming.BLL.CleanString.htmlInputText(this.txtfranchiser_code.Text.Trim()));
                strWhere.Append("%'");
            }
            if(this.txtfranchiser_name.Text.Trim() == "")
            {
                strWhere.Append(" AND 1=1");
            }
            else
            {
                strWhere.Append(" AND franchiser_name like N'%");
                strWhere.Append(GoldTradeNaming.BLL.CleanString.htmlInputText(this.txtfranchiser_name.Text.Trim()));
                strWhere.Append("%'");
            }
            return bll.GetFranAllInfo(strWhere.ToString());
        }
    }
}
