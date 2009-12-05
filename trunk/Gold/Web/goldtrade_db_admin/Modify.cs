namespace GoldTradeNaming.Web.goldtrade_db_admin
{
    using GoldTradeNaming.BLL;
    using GoldTradeNaming.Model;
    using LTP.Common;
    using System;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public class Modify : Page
    {
        protected Button btnAdd;
        protected Button btnCancel;
        protected Label lblsys_admin_id;
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
                string ins_user = "";
                string upd_user = this.Session["Admin"].ToString();
                GoldTradeNaming.Model.goldtrade_db_admin model = new GoldTradeNaming.Model.goldtrade_db_admin();
                model.sys_admin_name = sys_admin_name;
                model.sys_admin_tel = sys_admin_tel;
                model.sys_admin_cellphone = sys_admin_cellphone;
                model.sys_admin_id = Convert.ToInt32(this.lblsys_admin_id.Text);
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
                model.ins_user = ins_user;
                model.ins_date = DateTime.Now;
                model.upd_user = upd_user;
                model.upd_date = DateTime.Now;
                GoldTradeNaming.BLL.goldtrade_db_admin bll = new GoldTradeNaming.BLL.goldtrade_db_admin();
                GoldTradeNaming.BLL.goldtrade_IA100 bll100 = new GoldTradeNaming.BLL.goldtrade_IA100();
                try
                {
                    if (bll.Exists(model.sys_admin_id, model.sys_admin_name))
                    {
                        strErr = goldtrade_db_adminRes.strhasExists;
                        MessageBox.Show(this, strErr);
                    }
                    else if (!bll100.Exists(model.IA100GUID))
                    {
                        strErr = goldtrade_db_adminRes.strIA100NotReg;
                        MessageBox.Show(this, strErr);
                    }
                    else if (bll.IA100InUsed(model.sys_admin_id, model.IA100GUID))
                    {
                        strErr = goldtrade_db_adminRes.strIA100GUID_InUse;
                        MessageBox.Show(this, strErr);
                    }
                    else
                    {
                        bll.Update(model);
                        MessageBox.ShowAndRedirect(this, goldtrade_db_adminRes.strEditSuccess, "Show.aspx");
                    }
                }
                catch
                {
                    MessageBox.Show(this, goldtrade_db_adminRes.strSystemError);
                }
            }
        }

        protected void btnAuthMagege_Click(object sender, EventArgs e)
        {
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
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
                this.txtsys_admin_name.Text = base.Request.QueryString["name"].ToString();
                this.lblsys_admin_id.Text = base.Request.QueryString["id"].ToString();
                this.txtIA100GUID.Text = base.Request.QueryString["ia"].ToString();
                this.txtsys_admin_tel.Text = base.Request.QueryString["tel"].ToString();
                this.txtsys_admin_cellphone.Text = base.Request.QueryString["phone"].ToString();
            }
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            (base.Master.FindControl("lblTitle") as Label).Text = "修改管理员";
        }

        private void ShowInfo(int sys_admin_id)
        {
            GoldTradeNaming.Model.goldtrade_db_admin model = new GoldTradeNaming.BLL.goldtrade_db_admin().GetModel(sys_admin_id);
            this.lblsys_admin_id.Text = model.sys_admin_id.ToString();
            this.txtsys_admin_name.Text = model.sys_admin_name;
            this.txtsys_admin_tel.Text = model.sys_admin_tel;
            this.txtsys_admin_cellphone.Text = model.sys_admin_cellphone;
            this.txtIA100GUID.Text = model.IA100GUID.ToString();
        }
    }
}
