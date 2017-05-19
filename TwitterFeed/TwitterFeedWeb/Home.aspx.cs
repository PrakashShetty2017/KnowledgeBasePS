using System;
using System.Collections.Generic;
using System.Web.Services;
using TwitterAPIManager;

public partial class _Home : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    /// <summary>
    /// Method gets the twitter feed details
    /// </summary>
    /// <returns></returns>
     [WebMethod]
    public static string GetTwitterFeed()
    {
        ITwitterFeed obTF = new TwitterFeed();
        string value = obTF.GetTwitterFeed();
        return value;
    }

}