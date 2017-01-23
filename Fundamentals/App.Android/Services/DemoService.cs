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
using Android.Util;
using System.Threading;

namespace AppAndroid.Services
{
    [Service]
    class DemoService : Service
    {
        public override IBinder OnBind(Intent intent)
        {
            throw new NotImplementedException();
        }

        [return: GeneratedEnum]
        public override StartCommandResult OnStartCommand(Intent intent, [GeneratedEnum] StartCommandFlags flags, int startId)
        {
            Log.Debug("DemoService", "DemoService started");
            DoWork();
            return StartCommandResult.Sticky;
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
                StopSelf();
            });
            t.Start();
        }

        void SendNotification()
        {
            var nMgr = (NotificationManager)GetSystemService(NotificationService);
            var notification = new Notification(Resource.Drawable.Icon, "Message from demo service");
            var pendingIntent = PendingIntent.GetActivity(this, 0, new Intent(this, typeof(DemoActivity)), 0);
            notification.SetLatestEventInfo (this, "Demo Service Notification", "Message from demo service", pendingIntent);
            nMgr.Notify(0, notification);
        }

        public override void OnDestroy()
        {
            base.OnDestroy();
            Log.Debug("DemoService", "DemoService stopped");
        }
    }
}