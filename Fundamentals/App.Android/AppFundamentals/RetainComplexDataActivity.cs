using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Net;
using System.Json;
using Java.Lang;

namespace AppAndroid.AppFundamentals
{
    [Activity(Label = "RetainComplexDataActivity")]
    class TweetListWrapper : Java.Lang.Object
    {
        public string[] Tweets { get; set; }
    }
    public class RetainComplexDataActivity : ListActivity
    {
        TweetListWrapper _savedInstance;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            var tweetsWrapper = LastNonConfigurationInstance as TweetListWrapper;

            if (tweetsWrapper != null)
            {
                PopulateTweetList(tweetsWrapper.Tweets);
            }
            else
            {
                SearchTwitter("xamarin");
            }
        }

        public void SearchTwitter(string text)
        {
            string searchUrl = System.String.Format("http://search.twitter.com/search.json?" + "q={0}&rpp=10&include_entities=false&" + "result_type=mixed", text);

            var httpReq = (HttpWebRequest)HttpWebRequest.Create(new Uri(searchUrl));
            httpReq.BeginGetResponse(new AsyncCallback(ResponseCallback), httpReq);
        }

        void ResponseCallback(IAsyncResult ar)
        {
            var httpReq = (HttpWebRequest)ar.AsyncState;

            using (var httpRes = (HttpWebResponse)httpReq.EndGetResponse(ar))
            {
                ParseResults(httpRes);
            }
        }

        void ParseResults(HttpWebResponse httpRes)
        {
            var s = httpRes.GetResponseStream();
            var j = (JsonObject)JsonObject.Load(s);

            var results = (from result in (JsonArray)j["results"] let jResult = result as JsonObject select jResult["text"].ToString()).ToArray();

            RunOnUiThread(() => {
                PopulateTweetList(results);
            });
        }

        void PopulateTweetList(string[] results)
        {
            ListAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, results);
        }

        [Obsolete]
        public override Java.Lang.Object OnRetainNonConfigurationInstance()
        {
            base.OnRetainNonConfigurationInstance();
            return _savedInstance;
        }

    }
}