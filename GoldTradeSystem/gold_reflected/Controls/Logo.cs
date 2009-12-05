namespace GoldTradeNaming.Web.Controls
{
    using GoldTradeNaming.BLL;
    using System;
    using System.Data;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public class Logo : UserControl
    {
        protected Label lbl;
        protected Label lblDateNow;
        protected Label lblPrice;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                try
                {
                    DataSet dsPrice = new CommBaseBLL().getCurrentPrice();
                    this.lblPrice.Text = dsPrice.Tables[0].Rows[0][0].ToString();
                    this.lblDateNow.Text = DateTime.Now.Year.ToString() + "年" + DateTime.Now.Month.ToString() + "月" + DateTime.Now.Day.ToString() + "日";
                }
                catch
                {
                    this.lblPrice.Text = "0.00";
                    this.lblDateNow.Text = DateTime.Now.Year.ToString() + "年" + DateTime.Now.Month.ToString() + "月" + DateTime.Now.Day.ToString() + "日";
                }
            }
        }
    }
}
