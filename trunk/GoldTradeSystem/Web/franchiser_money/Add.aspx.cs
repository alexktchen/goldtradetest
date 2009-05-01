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
namespace GoldTradeNaming.Web.franchiser_money
{
    public partial class Add : System.Web.UI.Page
    {


        GoldTradeNaming.BLL.franchiser_money bll = new GoldTradeNaming.BLL.franchiser_money();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] == null || Session["admin"].ToString() == "" 
                || !GoldTradeNaming.BLL.CommBaseBLL.HasRight(Convert.ToInt32(Session["admin"]), Model.Authority.AddMoney.ToString())
                )
            {
                Response.Clear();
                Response.Write("<script defer>window.alert('" + "您没有权限登录本系统！\\n请重新登录或与管理员联系" + "');history.back();</script>");
                Response.End();
                return;
            } 
            txtadded_time.Text = DateTime.Now.ToString();
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            (Master.FindControl("lblTitle") as Label).Text = "添加入账";
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string strErr = "";

                if (txtfranchiser_code.Text.Trim() == "")
                {
                    MessageBox.Show(this, "经销商编号不能为空");
                    return;
                }
                if (txtfranchiser_added_money.Text.Trim() == "")
                {
                    MessageBox.Show(this, "入账金额不能为空");
                    return;
                }
                if (!PageValidate.IsNumber(txtfranchiser_code.Text))
                {
                    strErr += "franchiser_code不是数字！\\n";
                }
                if (!PageValidate.IsDecimal(txtfranchiser_added_money.Text))
                {
                    strErr += "franchiser_added_money不是数字！\\n";
                }
                if (!PageValidate.IsDateTime(txtadded_time.Text))
                {
                    strErr += "added_time不是时间格式！\\n";
                }

                if (strErr != "")
                {
                    MessageBox.Show(this, strErr);
                    return;
                }
                int franchiser_code = Convert.ToInt32(this.txtfranchiser_code.Text);
                decimal franchiser_added_money = decimal.Parse(this.txtfranchiser_added_money.Text);
                DateTime added_time = DateTime.Parse(this.txtadded_time.Text);
                string ins_user = Session["admin"].ToString();
                DateTime ins_date = DateTime.Now;
                string upd_user = Session["admin"].ToString();
                DateTime upd_date = DateTime.Now;

                //判断该经销商编号是否存在
                if (!bll.fran_id_exists(franchiser_code))
                {
                    MessageBox.Show(this, "您输入的经销商号不存于经销商信息表中，请检验输入时候有误");
                    return;
                }

                GoldTradeNaming.Model.franchiser_money model = new GoldTradeNaming.Model.franchiser_money();
                model.franchiser_code = franchiser_code;
                model.franchiser_added_money = franchiser_added_money;
                model.added_time = added_time;
                model.ins_user = ins_user;
                model.ins_date = ins_date;
                model.upd_user = upd_user;
                model.upd_date = upd_date;
                model.check = "1";

                int tag = bll.Add(model);

                if (tag == -1)
                {
                    MessageBox.Show(this, "新增失败");
                }
                else
                {
                    MessageBox.ShowAndRedirect(this, "新增成功", "Show.aspx");
                    txtfranchiser_code.Text = "";
                    txtfranchiser_added_money.Text = "";
                    txtadded_time.Text = DateTime.Now.ToString();
                }
            }
            catch
            {
                MessageBox.Show(this, "新增时发生错误！");
            }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            txtfranchiser_code.Text = "";
            txtfranchiser_added_money.Text = "";
            txtadded_time.Text = DateTime.Now.ToString();
        }

    }
}
