using System;

//using System.Text;
namespace GoldTradeNaming.BLL
{
    /// <summary>
    /// CleanString 的摘要说明。
    /// </summary>
    public sealed class CleanString
    {

        public static string htmlInputText(string inputString)//HTML过滤输入字符串
        {
            if ((inputString != null) && (inputString != String.Empty))
            {
                //inputString = inputString.Trim();
                inputString = inputString.Replace("'", "&quot;");
                inputString = inputString.Replace("<", "&lt;");
                inputString = inputString.Replace(">", "&gt;");
                inputString = inputString.Replace(" ", "&nbsp;");
                inputString = inputString.Replace("\n", "<br>");
                return inputString.ToString();
            }
            return "";
        }

        public static string htmlOutputText(string inputString)//HTML还原字符串
        {
            if ((inputString != null) && (inputString != String.Empty))
            {
                //inputString = inputString.Trim();
                inputString = inputString.Replace("&quot;", "'");
                inputString = inputString.Replace("&lt;", "<");
                inputString = inputString.Replace("&gt;", ">");
                inputString = inputString.Replace("&nbsp;", " ");
                inputString = inputString.Replace("<br>", "\n");
                return inputString.ToString();
            }
            return "";
        }

    }
}
