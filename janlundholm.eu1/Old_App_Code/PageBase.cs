using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

//namespace JanLundholm.Eu
//{
    /// <summary>
    /// Summary description for PageBase
    /// </summary>
    public class PageBase : Page
    {
        private string _currentIpAddress = null;


        #region Properties
        public string CurrentIpAddress
        {
            get
            {
                //Lazy loading
                if (_currentIpAddress == null)
                {
                    _currentIpAddress = Request.ServerVariables["REMOTE_ADDR"];
                }
                return _currentIpAddress;
            }
        } 
        #endregion


        #region Constructor
        public PageBase()
        {
            this.PreInit += new EventHandler(PageBase_PreInit);
            this.Load += new EventHandler(PageBase_Load);
        }

         
        #endregion


        #region Events
        void PageBase_PreInit(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void PageBase_Load(object sender, EventArgs e)
        {
            this.CheckAuthenticationStatus();
        } 
        #endregion


        #region Methods
        /// <summary>
        /// Kontrollerar status för authentifikation. Om användaren vill logga in/ut eller 
        /// är inloggad redan.
        /// </summary>
        private void CheckAuthenticationStatus()
        {
            if (Request.QueryString["status"] == "signIn" || Request.Form["ctl00$Content$LinkButton1"] != null)
            {
                string username = Request.Form["ctl00$Content$tbxUsername"];
                string password = Request.Form["ctl00$Content$tbxPassword"];
                BusinessLayer.User.SignIn(username, password);
                //HttpContext.Current.Response.Redirect("Login.aspx"); //Tar bort querystring
            }
            else if (Request.QueryString["status"] == "signOut")
            {
                BusinessLayer.User.SignOut();
            }
            else
            {   //Lägger eventuellt authentifierad användare i Context.User
                FormsAuthenticationTicket ticket = BusinessLayer.User.GetAuthenticationTicket();
                if (ticket != null)
                {
                    Context.User = BusinessLayer.User.GetPrincipal(ticket);
                }
            }
        }

    
    	/// <summary>
        /// Anropar den privata metoden AddHeaderJavascript. Lägger till en JavaScript fill i HEAD-taggen.
        /// Om URL:en redan finns i HEAD-taggen skapas ingen dublett.
        /// </summary>
        /// <param name="url">JavaScriptets src-attribut</param>
        public void AddHeaderJavascriptFile(string url)
        {
	        //Kontrollerar om URL:en redan finns.
	        //if (url == null || javaScriptUrls.Contains(url))
            if (url == null)
	        {
		        return;
	        }
	        //javaScriptUrls.Add(url);

	        this.AddHeaderJavascript(url, null);
        }

        /// <summary>
        /// Anropar den privata metoden AddHeaderJavascript. Lägger till en JavaScript fill i head-taggen.
        /// </summary>
        /// <param name="methodCall">Metodanrop. Text/html mellan öppnings- och avslutningstaggen.</param>
        public void AddHeaderJavascriptMethod(string methodCall)
        {
	        if (methodCall == null)
	        {
		        return;
	        }

	        this.AddHeaderJavascript(null, methodCall);
        }

        /// <summary>
        /// Metod för att lägga till JavaScript i sidans head-tag
        /// </summary>
        /// <param name="src">JavaScriptets src-attribut</param>
        /// <param name="innerHtml">Text/html mellan öppnings- och avslutningstaggen. Detta kan till exempel vara ett metodanrop.</param>
        private void AddHeaderJavascript(string src, string innerHtml)
        {
            //TODO: Fråga Olof - Är detta ett bra sätt att lägga till script-taggar i headern på?
            //I VS 2008 finns en egen contentplaceholder om jag minns rätt, men skapar jag en 
            //sådan i head så blir den röd-markerad. Dock kan det vara så att den fungerar ändå.

            //Eller såhär nått?...
            //this.ClientScript.RegisterClientScriptInclude();
            //this.ClientScript.RegisterClientScriptResource();

            //this.ClientScript.RegisterClientScriptInclude(jsSrcAttr, "jannesJava.js");
            //if (!Page.ClientScript.IsStartupScriptRegistered("showlogin"))
            //{
            //string jScript = string.Format("swfobject.embedSWF(\"{0}{1}{2}\", \"ctl00_RightAds_{3}\", \"{4}\", \"{5}\", \"{6}\")",
            //        Toolbox.FilePath.AnnonserOnDevelopment, ad.FlashFileName, ad.FlashClicktagUrl, masterPlacement.ID, 
            //        ad.Width, ad.Height, ad.FlashVersion);
            //}

            //Lägger till JavaScript-fil i HEAD-tagen.
            HtmlGenericControl genControl = new HtmlGenericControl("script");
            genControl.Attributes.Add("type", "text/javascript");
            genControl.Attributes.Add("src", src);
            genControl.InnerHtml = innerHtml;

            Page.Header.Controls.Add(genControl);
        }
        #endregion
    }
    
//}