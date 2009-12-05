namespace GoldTradeNaming.Web.franchiser_info
{
    using AjaxControlToolkit;
    using GoldTradeNaming.BLL;
    using GoldTradeNaming.Model;
    using LTP.Common;
    using System;
    using System.Data;
    using System.Text;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public class Show : Page
    {
        protected AutoCompleteExtender AutoCompleteExtender1;
        private GoldTradeNaming.BLL.franchiser_info bll = new GoldTradeNaming.BLL.franchiser_info();
        private GoldTradeNaming.BLL.goldtrade_IA100 bll100 = new GoldTradeNaming.BLL.goldtrade_IA100();
        protected Button btnCancel;
        protected Button btnQuery;
        protected Button btnReNew;
        protected Button btnSave;
        protected Button btSave;
        protected TextBox franchiser_address;
        protected TextBox franchiser_asure_money;
        protected TextBox franchiser_cellphone;
        protected TextBox franchiser_code;
        protected TextBox franchiser_name;
        protected TextBox franchiser_tel;
        protected GridView gvList;
        protected TextBox IA100;
        protected Label lblfranchiser_code;
        protected Label lblfranchiser_name;
        protected Label lblMsg;
        protected Label lblQueryMsg;
        protected Panel plShow;
        protected Panel plSource;
        protected ScriptManager ScriptManager1;
        protected TextBox txtfranchiser_code;
        protected TextBox txtfranchiser_name;
        protected TextBox txtIA100;

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            this.gvList.SelectedIndex = -1;
            this.plShow.Style.Add("display", "none");
            this.plSource.Style.Add("display", "block");
        }

        protected void btnQuery_Click(object sender, EventArgs e)
        {
            DataSet ds = this.SearchFranchiserInfo();
            if ((ds != null) && (ds.Tables[0].Rows.Count > 0))
            {
                this.lblQueryMsg.Text = "查询成功";
            }
            else
            {
                this.lblQueryMsg.Text = "查无记录";
            }
            this.Session["gvList"] = ds;
            this.gvList.DataSource = ds;
            this.gvList.DataBind();
        }

        protected void btnReNew_Click(object sender, EventArgs e)
        {
            this.txtfranchiser_code.Text = "";
            this.txtfranchiser_name.Text = "";
            this.gvList.SelectedIndex = -1;
            this.lblQueryMsg.Text = "";
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (this.CheckTextValue())
            {
                if (this.UpdateInfo())
                {
                    MessageBox.ShowAndRedirect(this, "保存成功...", "../franchiser_info/show.aspx");
                }
                else
                {
                    MessageBox.Show(this, "保存失败");
                }
            }
        }

        private bool CheckTextValue()
        {
            int iFranchiser_code;
            string strErr = "";
            try
            {
                iFranchiser_code = Convert.ToInt32(this.franchiser_code.Text.Trim());
            }
            catch
            {
                iFranchiser_code = -1;
                strErr = strErr + "经销商编码错误！";
            }
            if (this.franchiser_name.Text == "")
            {
                strErr = strErr + "经销商名字不能为空！";
            }
            else if (this.bll.Exists(iFranchiser_code, this.franchiser_name.Text.Trim()))
            {
                strErr = strErr + "经销商名字已存在！";
            }
            if (!PageValidate.IsDecimal(this.franchiser_asure_money.Text))
            {
                strErr = strErr + "担保款不是数字！";
            }
            if (this.franchiser_tel.Text == "")
            {
                strErr = strErr + "经销商座机不能为空！";
            }
            if (this.franchiser_cellphone.Text == "")
            {
                strErr = strErr + "经销商手机不能为空！";
            }
            if (this.franchiser_address.Text == "")
            {
                strErr = strErr + "经销商地址不能为空！";
            }
            Guid guid = new Guid();
            try
            {
                guid = new Guid(this.IA100.Text);
                if (this.bll.Exists(iFranchiser_code, guid))
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

        protected void gvList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.gvList.PageIndex = e.NewPageIndex;
            if (this.Session["gvList"] != null)
            {
                this.gvList.DataSource = this.Session["gvList"] as DataSet;
                this.gvList.DataBind();
            }
            else
            {
                this.Session["gvList"] = this.SearchFranchiserInfo();
                this.gvList.DataSource = this.Session["gvList"] as DataSet;
                this.gvList.DataBind();
            }
            this.gvList.SelectedIndex = -1;
        }

        protected void gvList_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.plShow.Style.Add("display", "block");
            this.plSource.Style.Add("display", "none");
            this.franchiser_code.Enabled = false;
            GridViewRow gvw = this.gvList.SelectedRow;
            this.franchiser_code.Text = gvw.Cells[0].Text.Trim();
            this.IA100.Text = gvw.Cells[1].Text.Replace("-", "").Trim();
            this.txtIA100.Text = gvw.Cells[1].Text.Replace("-", "").Trim();
            this.franchiser_name.Text = gvw.Cells[2].Text.Trim();
            this.franchiser_asure_money.Text = gvw.Cells[4].Text.Trim();
            this.franchiser_tel.Text = gvw.Cells[5].Text.Trim();
            this.franchiser_cellphone.Text = gvw.Cells[6].Text.Trim();
            this.franchiser_address.Text = gvw.Cells[7].Text.Trim();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((this.Session["admin"] == null) || (this.Session["admin"].ToString() == ""))
            {
                this.Session.Clear();
                base.Response.Clear();
                MessageBox.ShowAndRedirect(this, @"您没有权限或登录超时！\n请重新登录或与管理员联系", "../User_Login/AdminLogin.aspx");
            }
            else if (!(((this.Session["admin"] != null) && (this.Session["admin"].ToString() != "")) && CommBaseBLL.HasRight(Convert.ToInt32(this.Session["admin"]), Authority.ChgFran.ToString())))
            {
                base.Response.Clear();
                base.Response.Write(@"<script defer>window.alert('您没有权限操作该功能！\n请重新登录或与管理员联系');history.back();</script>");
                base.Response.End();
            }
            else if (!this.Page.IsPostBack)
            {
                DataSet ds = this.SearchFranchiserInfo();
                if (ds != null)
                {
                    this.gvList.DataSource = ds;
                    this.gvList.DataBind();
                    this.Session["gvList"] = ds;
                }
                this.plShow.Style.Add("display", "none");
                this.plSource.Style.Add("display", "block");
                this.btnSave.Style.Add("display", "none");
                this.btSave.Attributes.Add("onclick", "if(typeof(SaveCase)=='function') SaveCase();return false;");
            }
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            (base.Master.FindControl("lblTitle") as Label).Text = "修改经销商";
        }

        private DataSet SearchFranchiserInfo()
        {
            StringBuilder strWhere = new StringBuilder();
            if (this.txtfranchiser_code.Text.Trim() == "")
            {
                strWhere.Append("1=1");
            }
            else
            {
                strWhere.Append("franchiser_code like N'%");
                strWhere.Append(CleanString.htmlInputText(this.txtfranchiser_code.Text.Trim()));
                strWhere.Append("%'");
            }
            if (this.txtfranchiser_name.Text.Trim() == "")
            {
                strWhere.Append(" AND 1=1");
            }
            else
            {
                strWhere.Append(" AND franchiser_name like N'%");
                strWhere.Append(CleanString.htmlInputText(this.txtfranchiser_name.Text.Trim()));
                strWhere.Append("%'");
            }
            return this.bll.GetList(strWhere.ToString());
        }

        private bool UpdateInfo()
        {
            try
            {
                int franchiser_code = Convert.ToInt32(this.franchiser_code.Text);
                string franchiser_name = this.franchiser_name.Text;
                decimal franchiser_asure_money = decimal.Parse(this.franchiser_asure_money.Text);
                string franchiser_tel = this.franchiser_tel.Text;
                string franchiser_cellphone = this.franchiser_cellphone.Text;
                string franchiser_address = this.franchiser_address.Text;
                string IA100GUID = this.IA100.Text;
                GoldTradeNaming.Model.franchiser_info model = new GoldTradeNaming.Model.franchiser_info();
                model.franchiser_code = franchiser_code;
                model.franchiser_name = franchiser_name;
                model.franchiser_asure_money = franchiser_asure_money;
                model.franchiser_tel = franchiser_tel;
                model.franchiser_cellphone = franchiser_cellphone;
                model.franchiser_address = franchiser_address;
                model.IA100GUID = new Guid(IA100GUID);
                model.upd_user = this.Session["admin"].ToString();
                this.bll.Update(model);
                if (this.IA100.Text.ToLower().Trim() != this.txtIA100.Text.ToLower().Trim())
                {
                    Guid oldID = new Guid(this.txtIA100.Text.ToLower().Trim());
                    string reason = string.Concat(new object[] { "用户：", franchiser_name, ",用户ID：", franchiser_code, "更改认证锁" });
                    this.bll.DisableIA(oldID, reason);
                    this.txtIA100.Text = this.IA100.Text.Trim();
                }
                DataSet ds = this.SearchFranchiserInfo();
                this.Session["gvList"] = ds;
                this.gvList.DataSource = ds;
                this.gvList.DataBind();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.ToString());
                return false;
            }
        }
    }
}
