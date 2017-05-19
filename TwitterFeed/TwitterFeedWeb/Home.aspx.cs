using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Security.Cryptography;
using System.Net;
using System.IO;
using System.Web.Services;
using TwitterAPIManager;

public partial class _Home : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {

    }

     [WebMethod]
    public static string GetTwitterFeed()
    {
        ITwitterFeed obTF = new TwitterFeed();
        string value = obTF.GetTwitterFeed();
        return value;
    }

               //Alternatively below Search format can be used to search the data
           //TimelineUrl = "https://api.twitter.com/1.1/search/tweets.json?q=%40salesforce%20750%20employees&src=typd";
}