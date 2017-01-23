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

namespace AppAndroid
{
    public class SingletonClass
    {
        static SingletonClass()
        {

        }
        private static SingletonClass current;
        public static SingletonClass Current
        {
            get { return current; }
        }

        public void DoNothing()
        {

        }
        public int DoNothingInt { get; set; }
    }
}