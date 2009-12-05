namespace GoldTradeNaming.Web.goldtrade_db_admin
{
    using GoldTradeNaming.BLL;
    using GoldTradeNaming.Model;
    using LTP.Common;
    using System;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public class Add : Page
    {
        protected Button btnAdd;
        protected Button btnReset;
        protected HiddenField hdnAdminID;
        protected HiddenField hdnAdminNm;
        protected TextBox txtIA100GUID;
        protected TextBox txtsys_admin_cellphone;
        protected TextBox txtsys_admin_name;
        protected TextBox txtsys_admin_tel;

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string strErr = "";
            if (this.txtsys_admin_name.Text == "")
            {
                strErr = strErr + @"sys_admin_name不能为空！\n";
            }
            if (this.txtsys_admin_tel.Text == "")
            {
                strErr = strErr + @"sys_admin_tel不能为空！\n";
            }
            if (this.txtsys_admin_cellphone.Text == "")
            {
                strErr = strErr + @"sys_admin_cellphone不能为空！\n";
            }
            if (this.txtIA100GUID.Text == "")
            {
                strErr = strErr + @"IA100GUID不能为空！\n";
            }
            if (strErr != "")
            {
                MessageBox.Show(this, strErr);
            }
            else
            {
                string sys_admin_name = this.txtsys_admin_name.Text;
                string sys_admin_tel = this.txtsys_admin_tel.Text;
                string sys_admin_cellphone = this.txtsys_admin_cellphone.Text;
                string IA100GUID = this.txtIA100GUID.Text;
                DateTime ins_date = DateTime.Now;
                DateTime upd_date = DateTime.Now;
                GoldTradeNaming.Model.goldtrade_db_admin model = new GoldTradeNaming.Model.goldtrade_db_admin();
                model.sys_admin_name = sys_admin_name;
                model.sys_admin_tel = sys_admin_tel;
                model.sys_admin_cellphone = sys_admin_cellphone;
                try
                {
                    model.IA100GUID = new Guid(IA100GUID);
                }
                catch
                {
                    strErr = goldtrade_db_adminRes.strIA100GUID_Error;
                    MessageBox.Show(this, strErr);
                    return;
                }
                model.ins_user = this.Session["admin"].ToString();
                model.ins_date = ins_date;
                model.upd_user = "";
                model.upd_date = upd_date;
                GoldTradeNaming.BLL.goldtrade_db_admin bll = new GoldTradeNaming.BLL.goldtrade_db_admin();
                GoldTradeNaming.BLL.goldtrade_IA100 bll100 = new GoldTradeNaming.BLL.goldtrade_IA100();
                try
                {
                    if (bll.Exists(sys_admin_name))
                    {
                        strErr = goldtrade_db_adminRes.strhasExists;
                        MessageBox.Show(this, strErr);
                    }
                    else if (!bll100.Exists(model.IA100GUID))
                    {
                        strErr = goldtrade_db_adminRes.strIA100NotReg;
                        MessageBox.Show(this, strErr);
                    }
                    else if (bll.IA100InUsed(model.IA100GUID))
                    {
                        strErr = goldtrade_db_adminRes.strIA100GUID_InUse;
                        MessageBox.Show(this, strErr);
                    }
                    else if (bll.Add(model) != 1)
                    {
                        MessageBox.ShowAndRedirect(this, goldtrade_db_adminRes.strAddSuccess, "Show.aspx?admin_id=" + this.hdnAdminID.Value + "&admin_name=" + this.hdnAdminNm.Value);
                    }
                }
                catch
                {
                    MessageBox.Show(this, goldtrade_db_adminRes.strSystemError);
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("Show.aspx?admin_id=" + this.hdnAdminID.Value + "&admin_name=" + this.hdnAdminNm.Value);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((this.Session["admin"] == null) || (this.Session["admin"].ToString() == ""))
            {
                this.Session.Clear();
                base.Response.Clear();
                MessageBox.ShowAndRedirect(this, @"您没有权限或登录超时！\n请重新登录或与管理员联系", "../User_Login/AdminLogin.aspx");
            }
            else if (!(((this.Session["admin"] != null) && (this.Session["admin"].ToString() != "")) && CommBaseBLL.HasRight(Convert.ToInt32(this.Session["admin"]), Authority.AddAdmin.ToString())))
            {
                base.Response.Clear();
                base.Response.Write(@"<script defer>window.alert('您没有权限操作该功能！\n请重新登录或与管理员联系');history.back();</script>");
                base.Response.End();
            }
            else if (!base.IsPostBack)
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
            }
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            (base.Master.FindControl("lblTitle") as Label).Text = "添加管理员";
        }
    }
}
