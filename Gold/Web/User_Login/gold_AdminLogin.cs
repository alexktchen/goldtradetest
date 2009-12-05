namespace GoldTradeNaming.Web
{
    using System;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public class gold_AdminLogin : Page
    {
        protected TextBox TextBox1;

        protected void Page_Load(object sender, EventArgs e)
        {
            Random randomGenerator = new Random(DateTime.Now.Millisecond);
            string RndStr = "";
            for (int i = 0; i < 0x20; i++)
            {
                RndStr = RndStr + Convert.ToChar(randomGenerator.Next(0x61, 0x7a));
            }
            this.Session["Message"] = RndStr;
        }
    }
}
