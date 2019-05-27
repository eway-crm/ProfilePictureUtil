using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using eWayCRM.API;

namespace ProfilePictureUtil
{
    class Contact
    {
        public static void SaveProfilePictureSize(Connection connection)
        {
            JObject contacts = GetContacts(connection);
            foreach (JObject contact in contacts["Data"])
            {
                SaveContactPreview(connection, contact);
            }
        }

        private static JObject GetContacts(Connection connection)
        {
            return connection.CallMethod("GetContacts");
        }

        private static void SaveContactPreview(Connection connection, JObject contact)
        {
            string profilePicture = contact["ProfilePicture"]?.ToString();
            if (string.IsNullOrEmpty(profilePicture))
            {
                return;
            }
            int height = 0;
            int width = 0;

            GetPreviewSize(profilePicture, out height, out width);
            if (int.Parse(contact["ProfilePictureWidth"].ToString()) == width && int.Parse(contact["ProfilePictureHeight"].ToString()) == height)
            {
                return;
            }

            JObject contactProfile = new JObject();
            contactProfile.Add("ItemGUID", contact["ItemGUID"].ToString());
            contactProfile.Add("ProfilePictureWidth", width);
            contactProfile.Add("ProfilePictureHeight ", height);
          
            connection.CallMethod("SaveContact", JObject.FromObject(new
            {
                transmitObject = contactProfile
            }));
        }

        private static void GetPreviewSize(string profilePicture, out int height, out int width)
        {
            byte[] imageBytes = Convert.FromBase64String(profilePicture);
            using (Stream stream = new MemoryStream(imageBytes))
            {
                using (Image image = Bitmap.FromStream(stream))
                {
                    height = image.Height;
                    width = image.Width;
                }
            }
        }
    }
}
