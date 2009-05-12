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
using GoldTradeNaming.BLL;
namespace GoldTradeNaming.Web.franchiser_info
{
    public partial class Add:System.Web.UI.Page
    {
        private GoldTradeNaming.BLL.franchiser_info bll = new GoldTradeNaming.BLL.franchiser_info();
        private GoldTradeNaming.BLL.goldtrade_IA100 bll100 = new GoldTradeNaming.BLL.goldtrade_IA100();

        protected void Page_Load(object sender,EventArgs e)
        {
            if(!IsPostBack)
            {
                if (Session["admin"] == null || Session["admin"].ToString() == "" || !CommBaseBLL.HasRight(Convert.ToInt32(Session["admin"]), Model.Authority.AddFran.ToString()))
                {
                    Response.Clear();
                    Response.Write("<script defer>window.alert('" + "您没有权限登录本系统！\\n请重新登录或与管理员联系" + "');history.back();</script>");
                    Response.End();
                    return;
                }             


                //    lbSearch.Attributes.Add("onclick","location.href='Show.aspx';return false;");
                btnAdd.Attributes.Add("onclick","return confirm('" + "確定要提交?" + "')");
                InitCtrl();
            }
        }

        protected void Page_LoadComplete(object sender,EventArgs e)
        {
            (Master.FindControl("lblTitle") as Label).Text = "添加经销商";
        }



        protected void btnCancel_Click(object sender,EventArgs e)
        {
            InitCtrl();
        }

        protected void btnAdd_Click(object sender,EventArgs e)
        {
            if(!CheckTextValue())
                return;

            AddInfo();
            InitCtrl();
        }

        private void AddInfo()
        {
            string franchiser_name = this.txtfranchiser_name.Text;
            // decimal franchiser_balance_money = decimal.Parse(this.txtfranchiser_balance_money.Text);
            decimal franchiser_asure_money = decimal.Parse(this.txtfranchiser_asure_money.Text);
            string franchiser_tel = this.txtfranchiser_tel.Text;
            string franchiser_cellphone = this.txtfranchiser_cellphone.Text;
            string franchiser_address = this.txtfranchiser_address.Text;
            string sIA100 = this.txtIA100GUID.Text.Replace("-","").Replace(" ","");
            try
            {
                GoldTradeNaming.Model.franchiser_info model = new GoldTradeNaming.Model.franchiser_info();
                model.franchiser_name = franchiser_name;
                // model.franchiser_balance_money = franchiser_balance_money;
                model.franchiser_asure_money = franchiser_asure_money;
                model.franchiser_tel = franchiser_tel;
                model.franchiser_cellphone = franchiser_cellphone;
                model.franchiser_address = franchiser_address;
                model.IA100GUID = new Guid(sIA100);

                model.ins_user = Session["admin"].ToString();


                model.upd_user = "";
                bll.Add(model);
                MessageBox.ShowAndRedirect(this,"新增成功...","../franchiser_info/Add.aspx");
            }
            catch(Exception ex)
            {
                MessageBox.Show(this,"新增失败：" + ex.ToString());
            }
        }
        private bool CheckTextValue()
        {

            string strErr = "";
            if(this.txtfranchiser_name.Text == "")
            {
                strErr += "供应商名字不能为空！";
            }
            else
            {
                if(bll.Exists(txtfranchiser_name.Text.Trim()))
                {
                    strErr += "供应商名字已存在！";
                }

            }
            //if(!PageValidate.IsDecimal(txtfranchiser_balance_money.Text))
            //{
            //    strErr += "帐面余额不是数字！";
            //}
            if(!PageValidate.IsDecimal(txtfranchiser_asure_money.Text))
            {
                strErr += "担保款不是数字！";
            }
            if(this.txtfranchiser_tel.Text == "")
            {
                strErr += "经销商座机不能为空！";
            }
            if(this.txtfranchiser_cellphone.Text == "")
            {
                strErr += "经销商手机不能为空！";
            }
            if(this.txtfranchiser_address.Text == "")
            {
                strErr += "经销商地址不能为空！";
            }
            Guid guid = new Guid();
            try
            {
                guid = new Guid(this.txtIA100GUID.Text);
                if(bll.Exists(guid))
                {
                    strErr += "该认证锁已被其他人占用！";
                }

            }
            catch
            {
                strErr += "认证锁ID输入错误！";

            }
            if(!bll100.Exists(guid))
            {
                strErr += "认证锁ID未注册！";
            }

            lblMsg.Text = strErr;

            if(strErr == "")
                return true;
            else
                return false;
        }

        private void InitCtrl()
        {
            txtfranchiser_name.Text = "";
            // txtfranchiser_balance_money.Text = "";
            txtfranchiser_asure_money.Text = "";
            txtfranchiser_tel.Text = "";
            txtfranchiser_cellphone.Text = "";
            txtfranchiser_address.Text = "";
            txtIA100GUID.Text = "";
            lblMsg.Text = "";
        }
    }
}
