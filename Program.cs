using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

using eWayCRM.API;

namespace ProfilePictureUtil
{
    class Program
    {
        private static Connection _ewayConnection;
        private static Connector.Configuration.ConnectorConfigSection _config = null;

        static void Main(string[] args)
        {
           if (args.Any())
           {
                if (args[0].Contains("FixDimensions"))
                {
                    LogIn();
                    Contact.SaveProfilePictureSize(_ewayConnection);
                }
           }
        }

        private static void LogIn()
        {
            _ewayConnection = new Connection(Program.Config.eWayCRMConnection.Url,
                                                         Program.Config.eWayCRMConnection.UserName,
                                                          Program.Config.eWayCRMConnection.Password,
                                                          Program.Config.eWayCRMConnection.AppIdentifier
                                                          );
        }

        internal static Connector.Configuration.ConnectorConfigSection Config
        {
            get
            {
                if (_config == null)
                {
                    _config = Connector.Configuration.ConnectorConfigSection.FromSection();
                }
                return _config;
            }
        }
    } 
}