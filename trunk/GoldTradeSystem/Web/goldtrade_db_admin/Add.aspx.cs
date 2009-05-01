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
using System.Text;
using LTP.Common;
namespace GoldTradeNaming.Web.goldtrade_db_admin
{
    public partial class Add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
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

                if (Session["admin"] == null || Session["admin"].ToString() == ""
                     || !GoldTradeNaming.BLL.CommBaseBLL.HasRight(Convert.ToInt32(Session["admin"]), Model.Authority.AddAdmin.ToString())
                    )
                {
                    Response.Clear();
                    Response.Write("<script defer>window.alert('" + "您没有权限登录本系统！\\n请重新登录或与管理员联系" + "');history.back();</script>");
                    Response.End();
                    return;
                }
            }
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            (Master.FindControl("lblTitle") as Label).Text = "添加管理员";
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string strErr = "";
            if (this.txtsys_admin_name.Text == "")
            {
                strErr += "sys_admin_name不能为空！\\n";
            }
            if (this.txtsys_admin_tel.Text == "")
            {
                strErr += "sys_admin_tel不能为空！\\n";
            }
            if (this.txtsys_admin_cellphone.Text == "")
            {
                strErr += "sys_admin_cellphone不能为空！\\n";
            }
            if (this.txtIA100GUID.Text == "")
            {
                strErr += "IA100GUID不能为空！\\n";
            }

            if (strErr != "")
            {
                MessageBox.Show(this, strErr);
                return;
            }

            string sys_admin_name = this.txtsys_admin_name.Text;
            string sys_admin_tel = this.txtsys_admin_tel.Text;
            string sys_admin_cellphone = this.txtsys_admin_cellphone.Text;
            string IA100GUID = this.txtIA100GUID.Text;
            //string ins_user=this.txtins_user.Text;
            DateTime ins_date = DateTime.Now;// Parse(this.txtins_date.Text);
            //string upd_user=this.txtupd_user.Text;
            DateTime upd_date = DateTime.Now;// Parse(this.txtupd_date.Text);


            GoldTradeNaming.Model.goldtrade_db_admin model = new GoldTradeNaming.Model.goldtrade_db_admin();
            model.sys_admin_name = sys_admin_name;
            model.sys_admin_tel = sys_admin_tel;
            model.sys_admin_cellphone = sys_admin_cellphone;

            //where   guid=Convert(@guid_value,uniqueidentifier)
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

            model.ins_user = Session["admin"].ToString();
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
                    return;
                }
                if (!bll100.Exists(model.IA100GUID))
                {
                    strErr = goldtrade_db_adminRes.strIA100NotReg;
                    MessageBox.Show(this, strErr);
                    return;
                }

                if (bll.IA100InUsed(model.IA100GUID))
                {
                    strErr = goldtrade_db_adminRes.strIA100GUID_InUse;
                    MessageBox.Show(this, strErr);
                    return;
                }
                int result = bll.Add(model);
                if (result != 1)
                {
                    // MessageBox.Show(this, goldtrade_db_adminRes.strAddSuccess);
                    //Response.Write("<script language=\"javascript\"> alert('" + goldtrade_db_adminRes.strAddSuccess + "'); window.close();</script>");
                    MessageBox.ShowAndRedirect(this, goldtrade_db_adminRes.strAddSuccess, "Show.aspx?admin_id=" + this.hdnAdminID.Value + "&admin_name=" + this.hdnAdminNm.Value);
                    //Response.Redirect("Show.aspx");
                }
            }
            catch
            {
                MessageBox.Show(this, goldtrade_db_adminRes.strSystemError);
            }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Show.aspx?admin_id=" + this.hdnAdminID.Value + "&admin_name=" + this.hdnAdminNm.Value);
        }

        #region 自定义方法
        //private void bt
        #endregion

    }
}
