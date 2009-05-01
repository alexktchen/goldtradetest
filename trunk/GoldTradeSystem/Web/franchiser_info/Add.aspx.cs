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
                    Response.Write("<script defer>window.alert('" + "��û��Ȩ�޵�¼��ϵͳ��\\n�����µ�¼�������Ա��ϵ" + "');history.back();</script>");
                    Response.End();
                    return;
                }             


                //    lbSearch.Attributes.Add("onclick","location.href='Show.aspx';return false;");
                btnAdd.Attributes.Add("onclick","return confirm('" + "�_��Ҫ�ύ?" + "')");
                InitCtrl();
            }
        }

        protected void Page_LoadComplete(object sender,EventArgs e)
        {
            (Master.FindControl("lblTitle") as Label).Text = "��Ӿ�����";
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
                MessageBox.ShowAndRedirect(this,"�����ɹ�...","../franchiser_info/Add.aspx");
            }
            catch(Exception ex)
            {
                MessageBox.Show(this,"����ʧ�ܣ�" + ex.ToString());
            }
        }
        private bool CheckTextValue()
        {

            string strErr = "";
            if(this.txtfranchiser_name.Text == "")
            {
                strErr += "��Ӧ�����ֲ���Ϊ�գ�";
            }
            else
            {
                if(bll.Exists(txtfranchiser_name.Text.Trim()))
                {
                    strErr += "��Ӧ�������Ѵ��ڣ�";
                }

            }
            //if(!PageValidate.IsDecimal(txtfranchiser_balance_money.Text))
            //{
            //    strErr += "�����������֣�";
            //}
            if(!PageValidate.IsDecimal(txtfranchiser_asure_money.Text))
            {
                strErr += "����������֣�";
            }
            if(this.txtfranchiser_tel.Text == "")
            {
                strErr += "��������������Ϊ�գ�";
            }
            if(this.txtfranchiser_cellphone.Text == "")
            {
                strErr += "�������ֻ�����Ϊ�գ�";
            }
            if(this.txtfranchiser_address.Text == "")
            {
                strErr += "�����̵�ַ����Ϊ�գ�";
            }
            Guid guid = new Guid();
            try
            {
                guid = new Guid(this.txtIA100GUID.Text);
                if(bll.Exists(guid))
                {
                    strErr += "����֤���ѱ�������ռ�ã�";
                }

            }
            catch
            {
                strErr += "��֤��ID�������";

            }
            if(!bll100.Exists(guid))
            {
                strErr += "��֤��IDδע�ᣡ";
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
