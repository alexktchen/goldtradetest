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
namespace GoldTradeNaming.Web.goldtrade_db_admin
{
    public partial class Show : System.Web.UI.Page
    {
        private GridViewRow editrow = null;

        public GridViewRow Editrow
        {
            get { return editrow; }
            set { editrow = value; }
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            (Master.FindControl("lblTitle") as Label).Text = "查看管理员";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] == null || Session["admin"].ToString() == "")
            {
                Session.Clear();
                Response.Clear();
                LTP.Common.MessageBox.ShowAndRedirect(this, "您没有权限或登录超时！\\n请重新登录或与管理员联系", "../User_Login/AdminLogin.aspx");
                return;
            }

            if (Session["admin"] == null || Session["admin"].ToString() == ""
                    || !GoldTradeNaming.BLL.CommBaseBLL.HasRight(Convert.ToInt32(Session["admin"]), Model.Authority.ViewAdmin.ToString()))
            {
                Response.Clear();
                Response.Write("<script defer>window.alert('" + "您没有权限操作该功能！\\n请重新登录或与管理员联系" + "');history.back();</script>");
                Response.End();
                return;
            }
            if (!Page.IsPostBack)
            {
                //这里试图取得保存的状态，如果为刚进入页面，则置为“”
                try
                {
                    this.hdnAdminID.Value = Request.QueryString["admin_id"].ToString();
                }
                catch
                {
                    this.hdnAdminID.Value = "";
                }
                try
                {
                    this.hdnAdminNm.Value = Request.QueryString["admin_name"].ToString();
                }
                catch
                {
                    this.hdnAdminNm.Value = "";
                }
                this.txt_sysadmin_id.Attributes.Add("onkeypress", "this.value   =   this.value.replace(/[^0-9]/,'')");

                LoadData(true);
            }
        }

        private void LoadData(bool isInit)
        {
            int adminID = -1;
            string adminName = String.Empty;
            if (isInit)
            {
            }
            else
            {
                if (hdnAdminID.Value != String.Empty)
                {
                    try
                    {
                        adminID = Convert.ToInt32(hdnAdminID.Value);                      
                    }
                    catch
                    {
                        MessageBox.Show(this, "请输入正确的管理员编号");
                        return;
                    }
                }
                adminName = hdnAdminNm.Value;

            }
            try
            {
                GoldTradeNaming.BLL.goldtrade_db_admin bll = new GoldTradeNaming.BLL.goldtrade_db_admin();
                DataSet ds = bll.GetList(adminID,adminName,isInit);
                Session["grd_Data"] = ds;
                this.grd_AdminInfo.DataSource = ds;
                this.grd_AdminInfo.DataBind();
            }
            catch
            {
                MessageBox.Show(this, "查询出错！");
            }
        }

        protected void btnQry_Click(object sender, EventArgs e)
        {
            //保存查询条件
            this.hdnAdminID.Value = this.txt_sysadmin_id.Text.Trim();
            this.hdnAdminNm.Value = this.txtsys_admin_name.Text.Trim();
            LoadData(false);
        }

        protected void grd_AdminInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.grd_AdminInfo.PageIndex = e.NewPageIndex;
            this.grd_AdminInfo.DataSource = Session["grd_Data"] as DataSet ;
            this.grd_AdminInfo.DataBind();
        }

        protected void Reset1_Click1(object sender, EventArgs e)
        {
            this.txt_sysadmin_id.Text = "";
            this.txtsys_admin_name.Text = "";
        }

        //进入其他操作时，把查询条件传过去
        protected void lnkbtnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/goldtrade_db_admin/Add2.aspx?admin_id=" + this.hdnAdminID.Value +"&admin_name="+this.hdnAdminNm.Value);
        }
    }
}
