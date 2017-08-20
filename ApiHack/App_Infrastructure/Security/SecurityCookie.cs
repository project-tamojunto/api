using System;
using System.Linq;
using System.Web;

namespace WEB {

	public class SecurityCookie {

		public static string userId {
			get { return GetValue("suixass"); }
			set { SetValue("suixass", value, DateTime.Now.AddHours(12)); }
		}

		public static string idPerfil {
			get { return GetValue("suipass"); }
			set { SetValue("suipass", value, DateTime.Now.AddHours(12)); }
		}

		public static string userName {
			get { return GetValue("sunxass"); }
			set { SetValue("sunxass", value, DateTime.Now.AddHours(12)); }
		}

		public static string userEmail {
			get { return GetValue("sumxass"); }
			set { SetValue("sumxass", value, DateTime.Now.AddHours(12)); }
		}

        private static string GetValue(string key) {

            if (HttpContext.Current.Request.Cookies.AllKeys.Contains(key)) {

                HttpCookie cookie = HttpContext.Current.Request.Cookies.Get(key);

				return cookie?.Value;
			}

			return null;
		}

		private static void SetValue(string key, string value, DateTime expires) {

			var httpCookie = HttpContext.Current.Response.Cookies[key];

            if (httpCookie != null) httpCookie.Value = value;

			var cookie = HttpContext.Current.Response.Cookies[key];

			if (cookie != null) cookie.Expires = expires;
		}
	}
}