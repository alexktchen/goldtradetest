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

namespace GoldTradeNaming.Web.send_desc
{
    public partial class ShowAdmin : System.Web.UI.Page
    {
        private readonly GoldTradeNaming.BLL.send_desc bll = new GoldTradeNaming.BLL.send_desc();
       
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
                    || !GoldTradeNaming.BLL.CommBaseBLL.HasRight(Convert.ToInt32(Session["admin"]), Model.Authority.SendShow.ToString()))
            {
                Response.Clear();
                Response.Write("<script defer>window.alert('" + "您没有权限操作该功能！\\n请重新登录或与管理员联系" + "');history.back();</script>");
                Response.End();
                return;
            }

            if (!IsPostBack)
            {
                if (Request.Params["sendid"] != null && Request.Params["sendid"].Trim() != "")
                {
                    string send_id = Request.Params["sendid"].ToString();
                    showInformation(send_id);
                   
                }
            }
        }

        private void showInformation(string send_id)
        {
            try
            {
                DataSet ds = bll.getSendDesc(send_id);
                if (ds == null || ds.Tables[0].Rows.Count == 0)
                {
                    showData.Visible = false;
                }
                else
                {
                    showData.PageIndex = 0;
                    showData.DataSource = ds;
                    showData.DataBind();
                    showData.DataKeyNames = new string[] { "id" };
                    showData.Visible = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
