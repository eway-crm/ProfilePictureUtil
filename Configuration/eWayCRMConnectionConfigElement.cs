using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace Connector.Configuration
{
    class eWayCRMConnectionConfigElement : ConfigurationElement
    {
        [ConfigurationProperty("url", IsRequired = true)]
        internal string Url => (string)this["url"];

        [ConfigurationProperty("userName", IsRequired = true)]
        internal string UserName => (string)this["userName"];

        [ConfigurationProperty("password", IsRequired = true)]
        internal string Password => (string)this["password"];

        [ConfigurationProperty("appIdentifier", IsRequired = true)]
        internal string AppIdentifier => (string)this["appIdentifier"];
    }
}
