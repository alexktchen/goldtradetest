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
    public partial class Manage : System.Web.UI.Page
    {

        private readonly GoldTradeNaming.BLL.franchiser_money bll = new GoldTradeNaming.BLL.franchiser_money();

        //属性设置
        private string _franchiser_code;
        private string _franchiser_added_money;
        private string _added_time_from;
        private string _added_time_to;
        private string _check;

        /// <summary>
        /// 标志该入账信息是否已经审核
        /// </summary>
        public string check
        {
            set { _check = value; }
            get { return _check; }

        }
        /// <summary>
        /// 经销商编号
        /// </summary>
        public string franchiser_code
        {
            set { _franchiser_code = value; }
            get { return _franchiser_code; }
        }
        /// <summary>
        /// 入帐金额
        /// </summary>
        public string franchiser_added_money
        {
            set { _franchiser_added_money = value; }
            get { return _franchiser_added_money; }
        }
        /// <summary>
        /// 入帐时间起
        /// </summary>
        public string added_time_from
        {
            set { _added_time_from = value; }
            get { return _added_time_from; }
        }

        /// <summary>
        /// 入帐时间止
        /// </summary>
        public string added_time_to
        {
            set { _added_time_to = value; }
            get { return _added_time_to; }
        }


        private DataSet _rs;
        public DataSet rs {
            set { _rs = value; }
            get { return _rs; }
        
        }
        /// <summary>
        /// 绑定showData
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void dataBind(int tag)
        {

            try
            {
                string[] p = (string[])Session["paramer"];
                DataSet ds = bll.queryAction(p[0], p[1], p[2], p[3], p[4],tag);
                //if (Session["page"] == null)
                //{
                //    Session["page"] = ds;
                //}
                //else {
                //    Session.Remove("page");
                //    Session["page"] = ds;
                
                //}


                if (ds == null || ds.Tables[0].Rows.Count == 0)
                {
                    Response.Write("<script type='text/javascript'>alert('查无数据，请确定查询条件是否正确');</script>");
                    showDate.Visible = false;
                }
                else
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        if (row["checked"].ToString().Trim() == "0")
                        {
                            row["checked"] = "已审核";
                        }
                        else
                        {
                            row["checked"] = "未审核";
                        }
                    }
                    showDate.PageIndex = 0;
                    showDate.DataSource = ds;
                    showDate.DataBind();
                    showDate.DataKeyNames = new string[] { "id" };
                    showDate.Visible = true;

                }



            }
            catch
            {
                MessageBox.Show(this, "绑定出错！");
            }
        
        

        }






        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            (Master.FindControl("lblTitle") as Label).Text = "审核入帐";
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["admin"] == null || Session["admin"].ToString() == ""
                    || !GoldTradeNaming.BLL.CommBaseBLL.HasRight(Convert.ToInt32(Session["admin"]), Model.Authority.CheckAddMoney.ToString()))
                {
                    Response.Clear();
                    Response.Write("<script defer>window.alert('" + "您没有权限登录本系统！\\n请重新登录或与管理员联系" + "');history.back();</script>");
                    Response.End();
                    return;
                }
                if (Session["paramer"] == null)
                {
                    string[] paramer = { "", "", "", "", "" };
                    Session["paramer"] = paramer;
                }
               

                this.dataBind(0);
            }

        }

        protected void query_Click(object sender, EventArgs e)
        {
            showDate.DataSource = null;
            showDate.Visible = false;
            
            string fran_id = txtfran_id.Text.Trim();
            string add_money = txtadd_money.Text.Trim();
            string time_from = txttime_from.Text.Trim();
            string time_to = txtTime_to.Text.Trim();
            string check = drpIsCheck.Text.Trim();
            string strErr = "";
            if (!PageValidate.IsNumber(fran_id) && fran_id != "")
            {
                strErr += "franchiser_code不是数字！\\n";
            }
            if (!PageValidate.IsDecimal(add_money) && add_money != "")
            {
                strErr += "franchiser_added_money不是数字！\\n";
            }
            if (!PageValidate.IsDateTime(time_from) && time_from != "")
            {
                strErr += "added_time起始时间不是时间格式！\\n";
            }
            if (!PageValidate.IsDateTime(time_to) && time_to != "")
            {
                strErr += "added_time终止时间不是时间格式！\\n";
            }


            if (strErr != "")
            {
                MessageBox.Show(this, strErr);
                showDate.Visible = false;
                return;
            }
            if (Session["paramer"] == null)
            {
                string[] paramer = { fran_id, add_money, time_from, time_to, check };
                Session["paramer"] = paramer;
            }
            else {
                Session.Remove("paramer");
                string[] paramer = { fran_id, add_money, time_from, time_to, check };
                Session["paramer"] = paramer;
            }
            
            //this.franchiser_code = fran_id;
            //this.franchiser_added_money = add_money;
            //this.added_time_from = time_from;
            //this.added_time_to = time_to;
            //this.check = check;
            dataBind(1);
          




        }

        protected void reset_Click(object sender, EventArgs e)
        {

            txttime_from.Text = "";
            txtTime_to.Text = "";
            txtadd_money.Text = "";
            showDate.Visible = false;
            showDate.DataSource = null;
            drpIsCheck.SelectedIndex = 0;
            Session.Remove("paramer");
        }



        protected void showDate_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            string[] p = (string[])Session["paramer"];
            DataSet ds = bll.queryAction(p[0], p[1], p[2], p[3], p[4],1);
            if (ds == null || ds.Tables[0].Rows.Count == 0)
            {
                Response.Write("<script type='text/javascript'>alert('查无数据，请确定查询条件是否正确');</script>");
                showDate.Visible = false;
            }
            else
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    if (row["checked"].ToString().Trim() == "0")
                    {
                        row["checked"] = "已审核";
                    }
                    else
                    {
                        row["checked"] = "未审核";
                    }
                }
            }

            showDate.PageIndex = e.NewPageIndex;
            showDate.Visible = true;
            showDate.DataSource = ds;
            showDate.DataBind();
        }

        protected void showDate_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                string id = showDate.DataKeys[e.RowIndex].Value.ToString();
                GoldTradeNaming.Model.franchiser_money money = bll.GetModel(Convert.ToInt32(id));
                if(money.check.Trim()=="0"){
                    MessageBox.Show(this, "记录已经审核，无法删除！");
                    return;
                }
                int tag = bll.Delete(Convert.ToInt32(id));
                if (tag > 0)
                {


                    MessageBox.Show(this, "删除成功");
                    showDate.Rows[e.RowIndex].Visible = false;

                    //当该记录的状态属于审核的时候同步更新franchiser_infor中余额，否则不去更新

                    if (money.check == "0")
                    {
                        bll.update_franchiser_info(money.franchiser_code, money.franchiser_added_money, -1);
                    }



                }
                else
                {
                    MessageBox.Show(this, "删除失败");
                }
            }
            catch
            {
                MessageBox.Show(this, "删除时发生错误！");
            }
        }



        protected void showDate_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                string id = showDate.DataKeys[e.NewEditIndex].Value.ToString();
                GoldTradeNaming.Model.franchiser_money money = bll.GetModel(Convert.ToInt32(id));

                if (money.check == "0")
                {
                    MessageBox.Show(this, "该入账记录已经审核");
                }
                else
                {
                    //更新该条记录状态 ，并且同步更新francher_info表中的余额
                    money.check = "0";
                    bll.Update(money);
                    if (money.franchiser_added_money > 0)
                    {
                        bll.update_franchiser_info(money.franchiser_code, money.franchiser_added_money, 0);
                    }
                    else {
                        bll.update_franchiser_info(money.franchiser_code, money.franchiser_added_money, -1);
                    }
                  
                    MessageBox.Show(this, "审核成功！");
                    dataBind(1);
                }


            }
            catch
            {
                MessageBox.Show(this, "审核过程发生错误");

            }


        }


    }
}
