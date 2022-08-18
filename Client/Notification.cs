using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using VideoOS.Platform;
using VideoOS.Platform.Messaging;

namespace SCnotifywithlogging.Client
{
    public partial class Notification : Form
    {
        private Guid _myPropertyId = new Guid("D8979A59-D40D-4CEC-5678-3BD06EE17B05");
        private string _sURI = "";
        public Notification()
        {
            InitializeComponent();
            LogResourceHandler.RegisterMyMessages();
            System.Xml.XmlNode result = VideoOS.Platform.Configuration.Instance.GetOptionsConfiguration(_myPropertyId, false);
            _sURI = GetInnerText(result, "URL");
            Uri uriMessageURI = new Uri(_sURI);
            webBrowser1.Url = uriMessageURI;
        }

        private void Accept_Click(object sender, EventArgs e)
        {
            LogResourceHandler.MessageAccepted(true);
            this.Close();
        }
        internal static String GetInnerText(XmlNode xmlNode, String defaultValue)
        {
            if (xmlNode != null)
            {
                return xmlNode.InnerText;
            }
            return defaultValue;
        }

        private void decline_Click(object sender, EventArgs e)
        {
            LogResourceHandler.MessageAccepted(false);
            this.Close();

            EnvironmentManager.Instance.SendMessage(
                            new VideoOS.Platform.Messaging.Message(MessageId.SmartClient.ApplicationControlCommand, "Close"),
                            null,
                            null);
        }

        private void Notification_Load(object sender, EventArgs e)
        {

        }
    }
}
