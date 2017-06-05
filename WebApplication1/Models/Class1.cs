using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace WebApplication1.Models
{
    public class Class1
    {
        public string GetData(int value)
        {
            string data = string.Empty;

            try
            {
                using (WebClient web = new WebClient())
                {
                    data = web.DownloadString("https://api.github.com/users/tomkaczmarek/repos");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return data;
        }
    }
}