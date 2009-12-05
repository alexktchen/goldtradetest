namespace GoldTradeNaming.BLL
{
    using System;

    public sealed class CleanString
    {
        public static string htmlInputText(string inputString)
        {
            if ((inputString != null) && (inputString != string.Empty))
            {
                inputString = inputString.Replace("'", "&quot;");
                inputString = inputString.Replace("<", "&lt;");
                inputString = inputString.Replace(">", "&gt;");
                inputString = inputString.Replace(" ", "&nbsp;");
                inputString = inputString.Replace("\n", "<br>");
                return inputString.ToString();
            }
            return "";
        }

        public static string htmlOutputText(string inputString)
        {
            if ((inputString != null) && (inputString != string.Empty))
            {
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
