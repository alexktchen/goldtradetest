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

namespace GoldTradeNaming.Web.franchiser_info
{
    public partial class BaseInfo : System.Web.UI.Page
    {
        private GoldTradeNaming.BLL.franchiser_info bll = new GoldTradeNaming.BLL.franchiser_info();
        private GoldTradeNaming.BLL.goldtrade_IA100 bll100 = new GoldTradeNaming.BLL.goldtrade_IA100();

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            (Master.FindControl("lblTitle") as Label).Text = "经销商基本信息";
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
                   || !GoldTradeNaming.BLL.CommBaseBLL.HasRight(Convert.ToInt32(Session["admin"]), Model.Authority.ViewFran.ToString()))
            {
                Response.Clear();
                Response.Write("<script defer>window.alert('" + "您没有权限操作该功能！\\n请重新登录或与管理员联系" + "');history.back();</script>");
                Response.End();
                return;
            }
            if (!Page.IsPostBack)
            {               
                keyFranId.Value = Request.Params["id"].ToString();
                keyFranName.Value = Request.Params["name"].ToString();
                BindInfo();
         
            }
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        private void BindInfo()
        {
            if (Request.Params.Count > 0)
            {
                GoldTradeNaming.Model.franchiser_info info = bll.GetModel(Convert.ToInt32(this.keyFranId.Value));
                if (info!=null)
                {
                    this.txtBalance.Text = info.franchiser_balance_money.ToString();
                    this.txtfranchiser_address.Text = info.franchiser_address;
                    this.txtfranchiser_asure_money.Text = info.franchiser_asure_money.ToString() ;
                    this.txtfranchiser_cellphone.Text = info.franchiser_cellphone;
                    this.txtfranchiser_name.Text = info.franchiser_name;
                    this.txtfranchiser_tel.Text = info.franchiser_tel;
                    this.txtIA100GUID.Text = info.IA100GUID.ToString();
                }
            }
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("ShowNoEdit.aspx");
        }
    }
}
