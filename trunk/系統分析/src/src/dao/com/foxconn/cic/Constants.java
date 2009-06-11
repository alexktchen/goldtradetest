package com.foxconn.cic;


/**
 * Constant values used throughout the application.
 *
 * <p>
 * <a href="Constants.java.html"><i>View Source</i></a>
 * </p>
 *
 * @author <a href="mailto:matt@raibledesigns.com">Matt Raible</a>
 */
public class Constants {
    //~ Static fields/initializers =============================================
   
    /** The name of the ResourceBundle used in this application */
    public static final String BUNDLE_KEY = "ApplicationResources";

    /** The encryption algorithm key to be used for passwords */
    public static final String ENC_ALGORITHM = "algorithm";

    /** A flag to indicate if passwords should be encrypted */
    public static final String ENCRYPT_PASSWORD = "encryptPassword";

    /** File separator from System properties */
    public static final String FILE_SEP = System.getProperty("file.separator");

    /** User home from System properties */
    public static final String USER_HOME = System.getProperty("user.home") + FILE_SEP;

    /** The name of the configuration hashmap stored in application scope. */
    public static final String CONFIG = "appConfig";

    /** 
     * Session scope attribute that holds the locale set by the user. By setting this key
     * to the same one that Struts uses, we get synchronization in Struts w/o having
     * to do extra work or have two session-level variables.
     */ 
    public static final String PREFERRED_LOCALE_KEY = "org.apache.struts.action.LOCALE";
    
    /**
     * The request scope attribute under which an editable user form is stored
     */
    public static final String USER_KEY = "userForm";

    /**
     * The request scope attribute that holds the user list
     */
    public static final String USER_LIST = "userList";

    /**
     * The request scope attribute for indicating a newly-registered user
     */
    public static final String REGISTERED = "registered";

    /**
     * The name of the Administrator role, as specified in web.xml
     */
    public static final String ADMIN_ROLE = "admin";

    /**
     * The name of the User role, as specified in web.xml
     */
    public static final String USER_ROLE = "user";

    /**
     * The name of the user's role list, a request-scoped attribute
     * when adding/editing a user.
     */
    public static final String USER_ROLES = "userRoles";

    /**
     * The name of the available roles list, a request-scoped attribute
     * when adding/editing a user.
     */
    public static final String AVAILABLE_ROLES = "availableRoles";

    /**
     * The name of the CSS Theme setting.
     */
    public static final String CSS_THEME = "csstheme";



//Keyword-START
    /**
     * The request scope attribute that holds the keyword form.
     */
    public static final String KEYWORD_KEY = "keywordForm";

    /**
     * The request scope attribute that holds the keyword list
     */
    public static final String KEYWORD_LIST = "keywordList";
//Keyword-END







//CatalogType-START
    /**
     * The request scope attribute that holds the catalogType form.
     */
    public static final String CATALOGTYPE_KEY = "catalogTypeForm";

    /**
     * The request scope attribute that holds the catalogType list
     */
    public static final String CATALOGTYPE_LIST = "catalogTypeList";
//CatalogType-END

//Catalog-START
    /**
     * The request scope attribute that holds the catalog form.
     */
    public static final String CATALOG_KEY = "catalogForm";

    /**
     * The request scope attribute that holds the catalog list
     */
    public static final String CATALOG_LIST = "catalogList";
//Catalog-END



//News-START
    /**
     * The request scope attribute that holds the news form.
     */
    public static final String NEWS_KEY = "newsForm";

    /**
     * The request scope attribute that holds the news list
     */
    public static final String NEWS_LIST = "newsList";
//News-END

//Website-START
    /**
     * The request scope attribute that holds the website form.
     */
    public static final String WEBSITE_KEY = "websiteForm";

    /**
     * The request scope attribute that holds the website list
     */
    public static final String WEBSITE_LIST = "websiteList";
//Website-END





//NewsImage-START
    /**
     * The request scope attribute that holds the newsImage form.
     */
    public static final String NEWSIMAGE_KEY = "newsImageForm";

    /**
     * The request scope attribute that holds the newsImage list
     */
    public static final String NEWSIMAGE_LIST = "newsImageList";
//NewsImage-END



//Material-START
    /**
     * The request scope attribute that holds the material form.
     */
    public static final String MATERIAL_KEY = "materialForm";

    /**
     * The request scope attribute that holds the material list
     */
    public static final String MATERIAL_LIST = "materialList";
//Material-END

//Price-START
    /**
     * The request scope attribute that holds the price form.
     */
    public static final String PRICE_KEY = "priceForm";

    /**
     * The request scope attribute that holds the price list
     */
    public static final String PRICE_LIST = "priceList";
//Price-END



//ExchangeRate-START
    /**
     * The request scope attribute that holds the exchangeRate form.
     */
    public static final String EXCHANGERATE_KEY = "exchangeRateForm";

    /**
     * The request scope attribute that holds the exchangeRate list
     */
    public static final String EXCHANGERATE_LIST = "exchangeRateList";
//ExchangeRate-END

//InterestRate-START
    /**
     * The request scope attribute that holds the interestRate form.
     */
    public static final String INTERESTRATE_KEY = "interestRateForm";

    /**
     * The request scope attribute that holds the interestRate list
     */
    public static final String INTERESTRATE_LIST = "interestRateList";
//InterestRate-END

//UserActivityLog-START
    /**
     * The request scope attribute that holds the userActivityLog form.
     */
    public static final String USERACTIVITYLOG_KEY = "userActivityLogForm";

    /**
     * The request scope attribute that holds the userActivityLog list
     */
    public static final String USERACTIVITYLOG_LIST = "userActivityLogList";
//UserActivityLog-END

//Quoter-START
    /**
     * The request scope attribute that holds the quoter form.
     */
    public static final String QUOTER_KEY = "quoterForm";

    /**
     * The request scope attribute that holds the quoter list
     */
    public static final String QUOTER_LIST = "quoterList";
//Quoter-END

}
