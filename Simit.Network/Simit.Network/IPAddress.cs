namespace Simit.Network
{
    #region Using Directives
    using System;
    #endregion

    /// <summary>
    /// 
    /// </summary>
    public sealed class IPAddress
    {
        #region Public Static Methods
        /// <summary>
        /// Gets the internet protocol address.
        /// </summary>
        /// <returns></returns>
        public static string GetInternetProtocolAddress()
        {
            System.Web.HttpContext context = System.Web.HttpContext.Current;

            if (context == null) throw new InvalidOperationException("this methods run only under internet applications.");

            string address = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (string.IsNullOrEmpty(address))
            {
                return context.Request.ServerVariables["REMOTE_ADDR"];
            }
            else
            {
                string[] array = address.Split(new Char[] { ',' });
                return array[0];
            }
        }
        #endregion
    }
}
