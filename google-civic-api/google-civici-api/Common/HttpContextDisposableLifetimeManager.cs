using System;
using System.Threading;
using System.Web;
using Microsoft.Practices.Unity;

namespace google_civici_api.Common
{
    public class HttpContextDisposableLifetimeManager<T> : LifetimeManager, IDisposable
    {
        // Generate a key for the thread
        private string GetKey()
        {
            var threadId = Thread.CurrentThread.ManagedThreadId.ToString();
            return (typeof (T).AssemblyQualifiedName + threadId);
        }

        // Get the value by the key
        public override object GetValue()
        {
            var key = GetKey();
            return HttpContext.Current.Items[key];
        }

        // Remove value
        public override void RemoveValue()
        {
            HttpContext.Current.Items.Remove(GetKey());
        }

        // Set value
        public override void SetValue(object newValue)
        {
            HttpContext.Current.Items[GetKey()] = newValue;
        }

        // Dispose
        public void Dispose()
        {
            var obj = (IDisposable) GetValue();
            obj.Dispose();
        }
    }
}