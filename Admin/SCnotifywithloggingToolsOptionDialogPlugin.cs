using System;
using System.Xml;
using VideoOS.Platform.Admin;

namespace SCnotifywithlogging.Admin
{
    public class SCnotifywithloggingToolsOptionDialogPlugin : ToolsOptionsDialogPlugin
    {
        private SCnotifywithloggingToolsOptionDialogUserControl _myUserControl;
        private Guid _myPropertyId = new Guid("D8979A59-D40D-4CEC-5678-3BD06EE17B05");

        public override void Init()
        {

        }

        public override void Close()
        {
            //Note: Do not try to save option settings here!
        }

        /// <summary>
        /// Saving the changes
        /// </summary>
        /// <returns></returns>
        public override bool SaveChanges()
        {
            if (_myUserControl == null) return true;
            VideoOS.Platform.Configuration.Instance.SaveOptionsConfiguration(_myPropertyId, false, ToXml("URL", _myUserControl.MyPropValue));
            return true;
        }

        public override string Name
        {
            get { return "Smart Client Logon Notification"; }
        }

        public override Guid Id
        {
            get { return SCnotifywithloggingDefinition.SCnotifywithloggingToolsOptionDialogPluginId; }
        }


        public override ToolsOptionsDialogUserControl GenerateUserControl()
        {
            _myUserControl = new SCnotifywithloggingToolsOptionDialogUserControl();
            System.Xml.XmlNode result = VideoOS.Platform.Configuration.Instance.GetOptionsConfiguration(_myPropertyId, false);
            _myUserControl.MyPropValue = GetInnerText(result, "URL");
            return _myUserControl;
        }

        #region Helper methods

        internal static XmlElement ToXml(string key, string value)
        {
            XmlDocument doc = new XmlDocument();
            XmlElement root = doc.CreateElement("root");
            doc.AppendChild(root);
            XmlElement child = doc.CreateElement(key);
            child.InnerText = value;
            root.AppendChild(child);
            return root;
        }

        internal static String GetInnerText(XmlNode xmlNode, String defaultValue)
        {
            if (xmlNode != null)
            {
                return xmlNode.InnerText;
            }
            return defaultValue;
        }

        #endregion
    }


}
