namespace GoldTradeNaming.Web.goldtrade_db_admin
{
    using System;
    using System.CodeDom.Compiler;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Globalization;
    using System.Resources;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0"), DebuggerNonUserCode]
    internal class goldtrade_db_adminRes
    {
        private static CultureInfo resourceCulture;
        private static System.Resources.ResourceManager resourceMan;

        internal goldtrade_db_adminRes()
        {
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        internal static CultureInfo Culture
        {
            get
            {
                return resourceCulture;
            }
            set
            {
                resourceCulture = value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        internal static System.Resources.ResourceManager ResourceManager
        {
            get
            {
                if (object.ReferenceEquals(resourceMan, null))
                {
                    System.Resources.ResourceManager temp = new System.Resources.ResourceManager("GoldTradeNaming.Web.goldtrade_db_admin.goldtrade_db_adminRes", typeof(goldtrade_db_adminRes).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }

        internal static string strAddSuccess
        {
            get
            {
                return ResourceManager.GetString("strAddSuccess", resourceCulture);
            }
        }

        internal static string strConfirmColse
        {
            get
            {
                return ResourceManager.GetString("strConfirmColse", resourceCulture);
            }
        }

        internal static string strEditSuccess
        {
            get
            {
                return ResourceManager.GetString("strEditSuccess", resourceCulture);
            }
        }

        internal static string strhasExists
        {
            get
            {
                return ResourceManager.GetString("strhasExists", resourceCulture);
            }
        }

        internal static string strIA100GUID_Error
        {
            get
            {
                return ResourceManager.GetString("strIA100GUID_Error", resourceCulture);
            }
        }

        internal static string strIA100GUID_InUse
        {
            get
            {
                return ResourceManager.GetString("strIA100GUID_InUse", resourceCulture);
            }
        }

        internal static string strIA100NotReg
        {
            get
            {
                return ResourceManager.GetString("strIA100NotReg", resourceCulture);
            }
        }

        internal static string strLoginError
        {
            get
            {
                return ResourceManager.GetString("strLoginError", resourceCulture);
            }
        }

        internal static string strNoRigthIntoSystem
        {
            get
            {
                return ResourceManager.GetString("strNoRigthIntoSystem", resourceCulture);
            }
        }

        internal static string strSystemError
        {
            get
            {
                return ResourceManager.GetString("strSystemError", resourceCulture);
            }
        }
    }
}
