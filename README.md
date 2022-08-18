# SCnotifywithlogging

Words from the author

Author : Justin Butterworth - jub@milestone.dk

This plugin is provided as is and with minimal documentation and testing. The plugin is designed to be installed in the management client and Smart Client. 
The plugin is built to show a dialog box with a HTML element for the user to accept of decline, both actions are logged in the audit log, declining close the Smart Client, accepting will log the acceptance and allow the Logon to continue.

Installation (installed on the management Client and Smart Client)

Create a new directory under C:\Program Files\Milestone\MIPPlugins for example SCNotification

Paste the plugin.def and the SCnotifywithlogging.dll into that folder. 

It will now be loaded with either of the clients.

Uninstall

Incase of issues delete rename the plugin.def to plugin.def.disabled to stop the plugin from being loaded.

Instructions
A URL is configured in the Management Client (Tools -> Options -> Smart Client Logon Notification tab). When installed on the Smart Client the URL is looked up and then a logon form is displayed with the URL content and an accept or Decline option. 
Declining will close the Smart Client and log the decision in the Audit log within the Management Client. 
Accepting will allow use of the Smart Client and log the decition in the Audit log within the Management Client.

I advise placing the webpage for the EULA or logon message in on the mangement server, as this inherently is accessible by all clients.
The web rending is very basic and won't support javascript or anything too complicated. The HTML is just used to allow ease of formatting.

Troubleshooting

You may find the the dlls are blocked by windows, in this case, right click on the dll, select properties and uncheck the "blocked" check box.
