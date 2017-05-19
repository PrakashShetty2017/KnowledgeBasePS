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
using System.Web;
using System.Web.Services;
using Newtonsoft.Json.Linq;
using OAuthTwitterWrapper;

public partial class _Default1 : System.Web.UI.Page
{


    //public string query = "prakashashetty"; //umerpasha
    ////    public string url = "https://api.twitter.com/1.1/users/search.json" ;
    //public string url = "https://api.twitter.com/1.1/statuses/user_timeline.json";


    protected void Page_Load(object sender, EventArgs e)
    {
       // findUserTwitter(url, query);
        TwitterFeed obTF = new TwitterFeed();
        string value= obTF.GetMyTimeline();
    }

     [WebMethod]
    public static string GetTwitterFeed()
    {
        TwitterFeed obTF = new TwitterFeed();
        string value = obTF.GetMyTimeline();
        return value;
    }

    //public void findUserTwitter(string resource_url, string q)
    //{

    //    // oauth application keys
    //    var oauth_token = "	864555479254663168-P7LWtaCzNU3fshRCMHJjDlnJ0WyFWCK"; //"insert here...";
    //    var oauth_token_secret = "iMfgLpAP4K1JrUmjLZqEDKyVgVf4sQL3CA446bGzHEven"; //"insert here...";
    //    var oauth_consumer_key = "yEkVQqHKfqeLDiPBnGk6xtOHJ";// = "insert here...";
    //    var oauth_consumer_secret = "ASrjZGIQCFsBewxYYlnkKM45FHkniu0Uk8saKhZ0kloXO6d2Fy";// = "insert here...";

    //    // oauth implementation details
    //    var oauth_version = "1.0";
    //    var oauth_signature_method = "HMAC-SHA1";

    //    // unique request details
    //    var oauth_nonce = Convert.ToBase64String(new ASCIIEncoding().GetBytes(DateTime.Now.Ticks.ToString()));
    //    var timeSpan = DateTime.UtcNow
    //        - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
    //    var oauth_timestamp = Convert.ToInt64(timeSpan.TotalSeconds).ToString();


    //    // create oauth signature
    //    var baseFormat = "oauth_consumer_key={0}&oauth_nonce={1}&oauth_signature_method={2}" +
    //                    "&oauth_timestamp={3}&oauth_token={4}&oauth_version={5}&q={6}";

    //    var baseString = string.Format(baseFormat,
    //                                oauth_consumer_key,
    //                                oauth_nonce,
    //                                oauth_signature_method,
    //                                oauth_timestamp,
    //                                oauth_token,
    //                                oauth_version,
    //                                Uri.EscapeDataString(q)
    //                                );

    //    baseString = string.Concat("GET&", Uri.EscapeDataString(resource_url), "&", Uri.EscapeDataString(baseString));

    //    var compositeKey = string.Concat(Uri.EscapeDataString(oauth_consumer_secret),
    //                            "&", Uri.EscapeDataString(oauth_token_secret));

    //    string oauth_signature;
    //    using (HMACSHA1 hasher = new HMACSHA1(ASCIIEncoding.ASCII.GetBytes(compositeKey)))
    //    {
    //        oauth_signature = Convert.ToBase64String(
    //            hasher.ComputeHash(ASCIIEncoding.ASCII.GetBytes(baseString)));
    //    }

    //    // create the request header
    //    var headerFormat = "OAuth oauth_nonce=\"{0}\", oauth_signature_method=\"{1}\", " +
    //                       "oauth_timestamp=\"{2}\", oauth_consumer_key=\"{3}\", " +
    //                       "oauth_token=\"{4}\", oauth_signature=\"{5}\", " +
    //                       "oauth_version=\"{6}\"";

    //    var authHeader = string.Format(headerFormat,
    //                            Uri.EscapeDataString(oauth_nonce),
    //                            Uri.EscapeDataString(oauth_signature_method),
    //                            Uri.EscapeDataString(oauth_timestamp),
    //                            Uri.EscapeDataString(oauth_consumer_key),
    //                            Uri.EscapeDataString(oauth_token),
    //                            Uri.EscapeDataString(oauth_signature),
    //                            Uri.EscapeDataString(oauth_version)
    //                    );



    //    ServicePointManager.Expect100Continue = false;

    //    // make the request
    //    var postBody = "q=" + Uri.EscapeDataString(q);//
    //    resource_url += "?" + postBody;
    //    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(resource_url);
    //    request.Headers.Add("Authorization", authHeader);
    //    request.Method = "GET";
    //    request.ContentType = "application/x-www-form-urlencoded";
    //    var response = (HttpWebResponse)request.GetResponse();
    //    var reader = new StreamReader(response.GetResponseStream());
    //    var objText = reader.ReadToEnd();
    //    myDiv.InnerHtml = objText;/**/
    //    string html = "";
    //    try
    //    {
    //        JArray jsonDat = JArray.Parse(objText);
    //        for (int x = 0; x < jsonDat.Count(); x++)
    //        {
    //            //html += jsonDat[x]["id"].ToString() + "<br/>";
    //            html += jsonDat[x]["text"].ToString() + "<br/>";
    //            // html += jsonDat[x]["name"].ToString() + "<br/>";
    //            html += jsonDat[x]["created_at"].ToString() + "<br/>";

    //        }
    //        myDiv.InnerHtml = html;
    //    }
    //    catch (Exception twit_error)
    //    {
    //        myDiv.InnerHtml = html + twit_error.ToString();
    //    }
    //}
}