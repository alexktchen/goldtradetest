namespace GoldTradeNaming.Web.goldtrade_db_admin
{
    using GoldTradeNaming.BLL;
    using GoldTradeNaming.Model;
    using LTP.Common;
    using System;
    using System.Data;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public class Show : Page
    {
        protected Button btnQry;
        private GridViewRow editrow = null;
        protected GridView grd_AdminInfo;
        protected HiddenField hdnAdminID;
        protected HiddenField hdnAdminNm;
        protected Label Label1;
        protected Label Label2;
        protected Button Reset1;
        protected TextBox txt_sysadmin_id;
        protected TextBox txtsys_admin_name;

        protected void btnQry_Click(object sender, EventArgs e)
        {
            this.hdnAdminID.Value = this.txt_sysadmin_id.Text.Trim();
            this.hdnAdminNm.Value = this.txtsys_admin_name.Text.Trim();
            this.LoadData(false);
        }

        protected void grd_AdminInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.grd_AdminInfo.PageIndex = e.NewPageIndex;
            this.grd_AdminInfo.DataSource = this.Session["grd_Data"] as DataSet;
            this.grd_AdminInfo.DataBind();
        }

        protected void lnkbtnAdd_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("~/goldtrade_db_admin/Add2.aspx?admin_id=" + this.hdnAdminID.Value + "&admin_name=" + this.hdnAdminNm.Value);
        }

        private void LoadData(bool isInit)
        {
            int adminID = -1;
            string adminName = string.Empty;
            if (!isInit)
            {
                if (this.hdnAdminID.Value != string.Empty)
                {
                    try
                    {
                        adminID = Convert.ToInt32(this.hdnAdminID.Value);
                    }
                    catch
                    {
                        MessageBox.Show(this, "请输入正确的管理员编号");
                        return;
                    }
                }
                adminName = this.hdnAdminNm.Value;
            }
            try
            {
                DataSet ds = new GoldTradeNaming.BLL.goldtrade_db_admin().GetList(adminID, adminName, isInit);
                this.Session["grd_Data"] = ds;
                this.grd_AdminInfo.DataSource = ds;
                this.grd_AdminInfo.DataBind();
            }
            catch
            {
                MessageBox.Show(this, "查询出错！");
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
            else if (!(((this.Session["admin"] != null) && (this.Session["admin"].ToString() != "")) && CommBaseBLL.HasRight(Convert.ToInt32(this.Session["admin"]), Authority.ViewAdmin.ToString())))
            {
                base.Response.Clear();
                base.Response.Write(@"<script defer>window.alert('您没有权限操作该功能！\n请重新登录或与管理员联系');history.back();</script>");
                base.Response.End();
            }
            else if (!this.Page.IsPostBack)
            {
                try
                {
                    this.hdnAdminID.Value = base.Request.QueryString["admin_id"].ToString();
                }
                catch
                {
                    this.hdnAdminID.Value = "";
                }
                try
                {
                    this.hdnAdminNm.Value = base.Request.QueryString["admin_name"].ToString();
                }
                catch
                {
                    this.hdnAdminNm.Value = "";
                }
                this.txt_sysadmin_id.Attributes.Add("onkeypress", "this.value   =   this.value.replace(/[^0-9]/,'')");
                this.LoadData(true);
            }
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            (base.Master.FindControl("lblTitle") as Label).Text = "查看管理员";
        }

        protected void Reset1_Click1(object sender, EventArgs e)
        {
            this.txt_sysadmin_id.Text = "";
            this.txtsys_admin_name.Text = "";
        }

        public GridViewRow Editrow
        {
            get
            {
                return this.editrow;
            }
            set
            {
                this.editrow = value;
            }
        }
    }
}
