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
    public partial class Modify : System.Web.UI.Page
    {

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            (Master.FindControl("lblTitle") as Label).Text = "修改管理员";
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
                this.txtsys_admin_name.Text = Request.QueryString["name"].ToString();
                this.lblsys_admin_id.Text = Request.QueryString["id"].ToString();
                this.txtIA100GUID.Text = Request.QueryString["ia"].ToString();
                this.txtsys_admin_tel.Text = Request.QueryString["tel"].ToString();
                this.txtsys_admin_cellphone.Text = Request.QueryString["phone"].ToString();
                //Show queryPage = (Show)Context.Handler;
                ////Response.Write("StaDate：");
                ////Response.Write(queryPage.);
                ////Response.Write("<br/>EndDate：");
                ////Response.Write(queryPage.EndDate);

                ////object obj = Request.Params["row"];
                ////GridViewRow gvr = (GridViewRow)obj;
                //GridViewRow gvr = queryPage.Editrow;
                //this.txtsys_admin_name.Text = gvr.Cells[1].Text;

                //this.lblsys_admin_id.Text = gvr.Cells[0].Text;
                //this.txtIA100GUID.Text = gvr.Cells[4].Text.Replace("-","");
                //this.txtsys_admin_tel.Text = gvr.Cells[2].Text;
                //this.txtsys_admin_cellphone.Text = gvr.Cells[3].Text;


                //if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
                //{
                //    string id = Request.Params["id"];
                //    //ShowInfo(sys_admin_id);
                //}
            }
        }

        private void ShowInfo(int sys_admin_id)
        {
            GoldTradeNaming.BLL.goldtrade_db_admin bll = new GoldTradeNaming.BLL.goldtrade_db_admin();
            GoldTradeNaming.Model.goldtrade_db_admin model = bll.GetModel(sys_admin_id);
            this.lblsys_admin_id.Text = model.sys_admin_id.ToString();
            this.txtsys_admin_name.Text = model.sys_admin_name;
            this.txtsys_admin_tel.Text = model.sys_admin_tel;
            this.txtsys_admin_cellphone.Text = model.sys_admin_cellphone;
            this.txtIA100GUID.Text = model.IA100GUID.ToString();
            //this.txtins_user.Text=model.ins_user;
            ////this.txtins_date.Text=model.ins_date.ToString();
            //this.txtupd_user.Text=Session["Admin"].ToString();
            //this.txtupd_date.Text=model.upd_date.ToString();

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
            //if(this.txtins_user.Text =="")
            //{
            //    strErr+="ins_user不能为空！\\n";	
            //}
            //if(!PageValidate.IsDateTime(txtins_date.Text))
            //{
            //    strErr+="ins_date不是时间格式！\\n";	
            //}
            //if(this.txtupd_user.Text =="")
            //{
            //    strErr+="upd_user不能为空！\\n";	
            //}
            //if(!PageValidate.IsDateTime(txtupd_date.Text))
            //{
            //    strErr+="upd_date不是时间格式！\\n";	
            //}

            if (strErr != "")
            {
                MessageBox.Show(this, strErr);
                return;
            }
            string sys_admin_name = this.txtsys_admin_name.Text;
            string sys_admin_tel = this.txtsys_admin_tel.Text;
            string sys_admin_cellphone = this.txtsys_admin_cellphone.Text;
            string IA100GUID = this.txtIA100GUID.Text;
            string ins_user = "";//this.txtins_user.Text;
            //DateTime ins_date=DateTime.Parse(this.txtins_date.Text);
            string upd_user = Session["Admin"].ToString();//this.txtupd_user.Text;
            //DateTime upd_date=DateTime.Parse(this.txtupd_date.Text);


            GoldTradeNaming.Model.goldtrade_db_admin model = new GoldTradeNaming.Model.goldtrade_db_admin();
            model.sys_admin_name = sys_admin_name;
            model.sys_admin_tel = sys_admin_tel;
            model.sys_admin_cellphone = sys_admin_cellphone;
            model.sys_admin_id = Convert.ToInt32(this.lblsys_admin_id.Text);
            //model.IA100GUID = this.txtIA100GUID.Text.Trim();
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
            model.upd_date = DateTime.Now;//upd_date;

            GoldTradeNaming.BLL.goldtrade_db_admin bll = new GoldTradeNaming.BLL.goldtrade_db_admin();
            GoldTradeNaming.BLL.goldtrade_IA100 bll100 = new GoldTradeNaming.BLL.goldtrade_IA100(); 

            try
            {
                if (bll.Exists(model.sys_admin_id,model.sys_admin_name))
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
                if (bll.IA100InUsed(model.sys_admin_id,model.IA100GUID))
                {
                    strErr = goldtrade_db_adminRes.strIA100GUID_InUse;
                    MessageBox.Show(this, strErr);
                    return;
                }

                bll.Update(model);
                MessageBox.ShowAndRedirect(this, goldtrade_db_adminRes.strEditSuccess,"Show.aspx");
                
            }
            catch
            {
                MessageBox.Show(this, goldtrade_db_adminRes.strSystemError);
            }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

        }

        protected void btnAuthMagege_Click(object sender, EventArgs e)
        {

        }

    }
}
