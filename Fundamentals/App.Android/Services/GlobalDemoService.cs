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
using System.Threading;
using Android.Util;

namespace AppAndroid.Services
{
    [Service]
    [IntentFilter(new String[] { "com.alept.DemoService"})]
    class GlobalDemoService : Service
    {
        public override IBinder OnBind(Intent intent)
        {
            throw new NotImplementedException();
        }

        public override StartCommandResult OnStartCommand(Android.Content.Intent intent, StartCommandFlags flags, int startId)
        {
            Log.Debug("DemoService", "DemoService started");
            //this is for foreground service
            StartServiceInForeground();
            DoWork();
            return StartCommandResult.NotSticky;
        }

        public void DoWork()
        {
            Toast.MakeText(this, "Demo service starts!", ToastLength.Long).Show();
            var t = new Thread(() =>
            {
                SendNotification();
                Log.Debug("DemoService", "Doing Work");
                Thread.Sleep(1000);
                Log.Debug("DemoService", "Work Complete");
                Thread.Sleep(1000);
                StopForeground(true);
                StopSelf();
            });
            t.Start();
        }

        void StartServiceInForeground()
        {
            var ongoing = new Notification(Resource.Drawable.Icon, "DemoService in foreground");
            var pendingIntent = PendingIntent.GetActivity(this, 0, new Intent(this, typeof(DemoActivity)), 0);
            ongoing.SetLatestEventInfo(this, "DemoService", "DemoService is running in the foreground", pendingIntent);

            StartForeground((int)NotificationFlags.ForegroundService, ongoing);
        }

        void SendNotification()
        {
            var nMgr = (NotificationManager)GetSystemService(NotificationService);
            var notification = new Notification(Resource.Drawable.Icon, "Message from demo service");
            var pendingIntent = PendingIntent.GetActivity(this, 0, new Intent(this, typeof(DemoActivity)), 0);
            notification.SetLatestEventInfo(this, "Demo Service Notification", "Message from demo service", pendingIntent);
            nMgr.Notify(0, notification);
        }

        public override void OnDestroy()
        {
            base.OnDestroy();
            Log.Debug("DemoService", "DemoService stopped");
        }
    }

    //public class DemoServiceBinder : Binder
    //{
    //    DemoService service;

    //    public DemoServiceBinder(DemoService service)
    //    {
    //        this.service = service;
    //    }

    //    public DemoService GetDemoService()
    //    {
    //        return service;
    //    }
    //}
}