using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace Connector.Configuration
{
    class ConnectorConfigSection : ConfigurationSection
    {
        internal static ConnectorConfigSection FromSection(string sectionName = null)
        {
            if (string.IsNullOrEmpty(sectionName))
            {
                sectionName = "Connector";
            }
            return (ConnectorConfigSection)ConfigurationManager.GetSection(sectionName);
        }

        [ConfigurationProperty("eWayCRMConnection", IsRequired = true)]
        internal eWayCRMConnectionConfigElement eWayCRMConnection => (eWayCRMConnectionConfigElement)this["eWayCRMConnection"];

    }
}
