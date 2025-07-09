![eWay-CRM Logo](https://www.eway-crm.com/wp-content/themes/eway/img/email/logo_grey.png)

# ProfilePictureUtil
ProfilePictureUtil is a utility used to update profile picture width and height of eWay-CRM contacts. It may come hande when you import data
from other system using SQL database where the source database does not provide profile picture dimensions.

## Running the application
First of all you have to update connection to the eWay-CRM API in the app.config.

```xml
<eWayCRMConnection url="https://free.eway-crm.com/31994" userName="api" password="470AE7216203E23E1983EF1851E72947==" appIdentifier="ProfilePictureUtil-v1.0" />
```

After you build the application, run it with following parameter:

```
ProfilePictureUtil.exe /FixDimensions 
```