namespace GoldTradeNaming.Web.franchiser_info
{
    using GoldTradeNaming.BLL;
    using GoldTradeNaming.Model;
    using LTP.Common;
    using System;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public class Add : Page
    {
        private GoldTradeNaming.BLL.franchiser_info bll = new GoldTradeNaming.BLL.franchiser_info();
        private GoldTradeNaming.BLL.goldtrade_IA100 bll100 = new GoldTradeNaming.BLL.goldtrade_IA100();
        protected Button btnAdd;
        protected Button btnCancel;
        protected Label lblMsg;
        protected TextBox txtfranchiser_address;
        protected TextBox txtfranchiser_asure_money;
        protected TextBox txtfranchiser_cellphone;
        protected TextBox txtfranchiser_name;
        protected TextBox txtfranchiser_tel;
        protected TextBox txtIA100GUID;

        private void AddInfo()
        {
            string franchiser_name = this.txtfranchiser_name.Text;
            decimal franchiser_asure_money = decimal.Parse(this.txtfranchiser_asure_money.Text);
            string franchiser_tel = this.txtfranchiser_tel.Text;
            string franchiser_cellphone = this.txtfranchiser_cellphone.Text;
            string franchiser_address = this.txtfranchiser_address.Text;
            string sIA100 = this.txtIA100GUID.Text.Replace("-", "").Replace(" ", "");
            try
            {
                GoldTradeNaming.Model.franchiser_info model = new GoldTradeNaming.Model.franchiser_info();
                model.franchiser_name = franchiser_name;
                model.franchiser_asure_money = franchiser_asure_money;
                model.franchiser_tel = franchiser_tel;
                model.franchiser_cellphone = franchiser_cellphone;
                model.franchiser_address = franchiser_address;
                model.IA100GUID = new Guid(sIA100);
                model.ins_user = this.Session["admin"].ToString();
                model.upd_user = "";
                this.bll.Add(model);
                MessageBox.ShowAndRedirect(this, "新增成功...", "../franchiser_info/Add.aspx");
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "新增失败：" + ex.ToString());
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (this.CheckTextValue())
            {
                this.AddInfo();
                this.InitCtrl();
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            this.InitCtrl();
        }

        private bool CheckTextValue()
        {
            string strErr = "";
            if (this.txtfranchiser_name.Text == "")
            {
                strErr = strErr + "供应商名字不能为空！";
            }
            else if (this.bll.Exists(this.txtfranchiser_name.Text.Trim()))
            {
                strErr = strErr + "供应商名字已存在！";
            }
            if (!PageValidate.IsDecimal(this.txtfranchiser_asure_money.Text))
            {
                strErr = strErr + "担保款不是数字！";
            }
            if (this.txtfranchiser_tel.Text == "")
            {
                strErr = strErr + "经销商座机不能为空！";
            }
            if (this.txtfranchiser_cellphone.Text == "")
            {
                strErr = strErr + "经销商手机不能为空！";
            }
            if (this.txtfranchiser_address.Text == "")
            {
                strErr = strErr + "经销商地址不能为空！";
            }
            Guid guid = new Guid();
            try
            {
                guid = new Guid(this.txtIA100GUID.Text);
                if (this.bll.Exists(guid))
                {
                    strErr = strErr + "该认证锁已被其他人占用！";
                }
            }
            catch
            {
                strErr = strErr + "认证锁ID输入错误！";
            }
            if (!this.bll100.Exists(guid))
            {
                strErr = strErr + "认证锁ID未注册！";
            }
            this.lblMsg.Text = strErr;
            return (strErr == "");
        }

        private void InitCtrl()
        {
            this.txtfranchiser_name.Text = "";
            this.txtfranchiser_asure_money.Text = "";
            this.txtfranchiser_tel.Text = "";
            this.txtfranchiser_cellphone.Text = "";
            this.txtfranchiser_address.Text = "";
            this.txtIA100GUID.Text = "";
            this.lblMsg.Text = "";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((this.Session["admin"] == null) || (this.Session["admin"].ToString() == ""))
            {
                this.Session.Clear();
                base.Response.Clear();
                MessageBox.ShowAndRedirect(this, @"您没有权限或登录超时！\n请重新登录或与管理员联系", "../User_Login/AdminLogin.aspx");
            }
            else if (!(((this.Session["admin"] != null) && (this.Session["admin"].ToString() != "")) && CommBaseBLL.HasRight(Convert.ToInt32(this.Session["admin"]), Authority.AddFran.ToString())))
            {
                base.Response.Clear();
                base.Response.Write(@"<script defer>window.alert('您没有权限操作该功能！\n请重新登录或与管理员联系');history.back();</script>");
                base.Response.End();
            }
            else if (!base.IsPostBack)
            {
                this.btnAdd.Attributes.Add("onclick", "return confirm('確定要提交?')");
                this.InitCtrl();
            }
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            (base.Master.FindControl("lblTitle") as Label).Text = "添加经销商";
        }
    }
}
