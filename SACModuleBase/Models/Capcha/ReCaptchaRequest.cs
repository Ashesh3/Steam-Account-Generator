using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SACModuleBase.Models.Capcha
{
    public class ReCaptchaRequest
    {
        /// <summary>
        /// ReCaptcha page URL
        /// </summary>
        public string Url { get; private set; }
        /// <summary>
        /// ReCaptcha site-key
        /// </summary>
        public string SiteKey { get; private set; }
    }
}
