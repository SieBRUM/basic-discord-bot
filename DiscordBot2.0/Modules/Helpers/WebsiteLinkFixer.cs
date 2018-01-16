using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordBot2._0.Modules.Helpers
{
    static class WebsiteLinkFixer
    { 
        public static string ImgurFixUrl(string url)
        {

            if (url.Contains("imgur") && !url.Contains(".jpg") && !url.Contains("/a/"))
            {
                url += ".jpg";
            }

            return url;
        }
    }
}
