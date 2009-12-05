namespace GoldTradeNaming.Web.franchiser_money
{
    using AjaxControlToolkit;
    using GoldTradeNaming.BLL;
    using GoldTradeNaming.Model;
    using LTP.Common;
    using System;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public class Add : Page
    {
        private GoldTradeNaming.BLL.franchiser_money bll = new GoldTradeNaming.BLL.franchiser_money();
        protected Button btnAdd;
        protected Button btnCancel;
        protected CalendarExtender dtTo_CalendarExtender;
        protected ScriptManager ScriptManager1;
        protected TextBox txtadded_time;
        protected TextBox txtfranchiser_added_money;
        protected TextBox txtfranchiser_code;

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string strErr = "";
                if (this.txtfranchiser_code.Text.Trim() == "")
                {
                    MessageBox.Show(this, "经销商编号不能为空");
                }
                else if (this.txtfranchiser_added_money.Text.Trim() == "")
                {
                    MessageBox.Show(this, "入账金额不能为空");
                }
                else
                {
                    if (!PageValidate.IsNumber(this.txtfranchiser_code.Text))
                    {
                        strErr = strErr + @"franchiser_code不是数字！\n";
                    }
                    if (!PageValidate.IsDecimalSign(this.txtfranchiser_added_money.Text.Replace("-", "")))
                    {
                        strErr = strErr + @"franchiser_added_money不是数字！\n";
                    }
                    if (!PageValidate.IsDateTime(this.txtadded_time.Text))
                    {
                        strErr = strErr + @"added_time不是时间格式！\n";
                    }
                    if (strErr != "")
                    {
                        MessageBox.Show(this, strErr);
                    }
                    else
                    {
                        int franchiser_code = Convert.ToInt32(this.txtfranchiser_code.Text);
                        decimal franchiser_added_money = decimal.Parse(this.txtfranchiser_added_money.Text);
                        DateTime added_time = DateTime.Parse(this.txtadded_time.Text);
                        string ins_user = this.Session["admin"].ToString();
                        DateTime ins_date = DateTime.Now;
                        string upd_user = this.Session["admin"].ToString();
                        DateTime upd_date = DateTime.Now;
                        if (!this.bll.fran_id_exists(franchiser_code))
                        {
                            MessageBox.Show(this, "您输入的经销商号不存于经销商信息表中，请检验输入时候有误");
                        }
                        else
                        {
                            GoldTradeNaming.Model.franchiser_money model = new GoldTradeNaming.Model.franchiser_money();
                            model.franchiser_code = franchiser_code;
                            model.franchiser_added_money = franchiser_added_money;
                            model.added_time = added_time;
                            model.ins_user = ins_user;
                            model.ins_date = ins_date;
                            model.upd_user = upd_user;
                            model.upd_date = upd_date;
                            model.check = "1";
                            if (this.bll.Add(model) == -1)
                            {
                                MessageBox.Show(this, "新增失败");
                            }
                            else
                            {
                                MessageBox.ShowAndRedirect(this, "新增成功", "Show.aspx");
                                this.txtfranchiser_code.Text = "";
                                this.txtfranchiser_added_money.Text = "";
                                this.txtadded_time.Text = DateTime.Now.ToString();
                            }
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show(this, "新增时发生错误！");
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            this.txtfranchiser_code.Text = "";
            this.txtfranchiser_added_money.Text = "";
            this.txtadded_time.Text = DateTime.Now.ToString();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((this.Session["admin"] == null) || (this.Session["admin"].ToString() == ""))
            {
                this.Session.Clear();
                base.Response.Clear();
                MessageBox.ShowAndRedirect(this, @"您没有权限或登录超时！\n请重新登录或与管理员联系", "../User_Login/AdminLogin.aspx");
            }
            else if (!(((this.Session["admin"] != null) && (this.Session["admin"].ToString() != "")) && CommBaseBLL.HasRight(Convert.ToInt32(this.Session["admin"]), Authority.AddMoney.ToString())))
            {
                base.Response.Clear();
                base.Response.Write(@"<script defer>window.alert('您没有权限操作该功能！\n请重新登录或与管理员联系');history.back();</script>");
                base.Response.End();
            }
            else
            {
                this.txtadded_time.Text = DateTime.Now.ToString();
            }
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            (base.Master.FindControl("lblTitle") as Label).Text = "添加入账";
        }
    }
}
