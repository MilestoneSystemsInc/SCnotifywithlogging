using System;
using System.Collections.Generic;
using System.Globalization;
using VideoOS.Platform;
using VideoOS.Platform.Log;

namespace SCnotifywithlogging
{

    internal class LogResourceHandler
    {
        private const String _myApplication = "Logon Acceptance";
        private const String _myComponent = "Logon Acceptance Component";

        private const String _id1 = "AcceptedLogonForm";
        private const String _id2 = "DeclinedLogonForm";

        internal static void RegisterMyMessages()
        {


            LogMessageDictionary lmd1 = new LogMessageDictionary("en-US", "6.9", _myApplication, _myComponent, BuildDictionary("en-US"), "Logon Message");

            VideoOS.Platform.Log.LogClient.Instance.RegisterDictionary(lmd1);
        }

        private static Dictionary<String, LogMessage> BuildDictionary(String culture)
        {
            Dictionary<String, LogMessage> messages = new Dictionary<string, LogMessage>();
            VideoOS.Platform.Properties.Strings.Culture = new CultureInfo(culture);

            messages.Add(_id1, new LogMessage() { Id = _id1, Category = "ExternalComponents", Message = "{username} logged on {client} and Accepted the message", Group = Group.Audit, Severity = Severity.Info, Status = Status.StatusQuo, RelatedObjectKind = Kind.User });
            messages.Add(_id2, new LogMessage() { Id = _id2, Category = "ExternalComponents", Message = "{username} logged on {client} and Declined the message", Group = Group.Audit, Severity = Severity.Info, Status = Status.StatusQuo, RelatedObjectKind = Kind.User });

            return messages;
        }


        internal static void MessageAccepted(bool granted)
        {
            Dictionary<String, String> parms = new Dictionary<string, string>();
            parms["client"] = System.Environment.MachineName;
            if (granted) { parms["feedback"] = "accepted"; }
            else { parms["feedback"] = "Declined"; }
            parms["username"] = Environment.UserName;
            Item item = new Item(EnvironmentManager.Instance.MasterSite, Environment.UserName);

            VideoOS.Platform.Log.LogClient.Instance.AuditEntry(_myApplication, _myComponent, granted ? _id1 : _id2, item, parms, granted ? PermissionState.Granted : PermissionState.Denied);
        }
    }
}
