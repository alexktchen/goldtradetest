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
namespace GoldTradeNaming.Web.sys_login_info
{
    public partial class Show:System.Web.UI.Page
    {
        protected void Page_LoadComplete(object sender,EventArgs e)
        {
            (Master.FindControl("lblTitle") as Label).Text = "详细信息";
        }
        protected void Page_Load(object sender,EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                if(Request.Params["id"] != null && Request.Params["id"].Trim() != "")
                {
                    string id = Request.Params["id"];
                    //ShowInfo(ID);
                }
                //Session["admin"] = "yuxiaowei";  //测试
                if(Session["admin"] == null || Session["admin"].ToString() == "")
                {
                    Response.Clear();
                    Response.Write("<script defer>window.alert('" + "您没有权限登录本系统！\\n请重新登录或与管理员联系" + "');history.back();</script>");
                    Response.End();
                    return;
                }
                SaveLoginInfo();
            }
        }

        private void ShowInfo(int ID)
        {
            GoldTradeNaming.BLL.sys_login_info bll = new GoldTradeNaming.BLL.sys_login_info();
            GoldTradeNaming.Model.sys_login_info model = bll.GetModel(ID);
            this.lblIP.Text = model.IP.ToString();
            this.lbllogin_time.Text = model.login_time.ToString();
            this.lbllogin_ID.Text = model.login_ID;

        }

        private bool SaveLoginInfo()
        {
            string login_ID = "1001"; //测试数据
            if(Session["admin"] != null && Session["admin"].ToString().Trim() != "")
            {
                login_ID = Session["admin"].ToString().Trim();
            }
            string IP = Request.UserHostAddress;

            GoldTradeNaming.Model.sys_login_info model = new GoldTradeNaming.Model.sys_login_info();
            model.IP = IP;
            model.login_ID = login_ID;

            GoldTradeNaming.BLL.sys_login_info bll = new GoldTradeNaming.BLL.sys_login_info();
            if(bll.Add(model) > 0)
            {
                return true;
            }
            else
                return false;


        }



    }
}
