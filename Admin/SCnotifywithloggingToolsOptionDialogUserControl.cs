using VideoOS.Platform.Admin;

namespace SCnotifywithlogging.Admin
{
    public partial class SCnotifywithloggingToolsOptionDialogUserControl : ToolsOptionsDialogUserControl
    {
        public SCnotifywithloggingToolsOptionDialogUserControl()
        {
            InitializeComponent();
        }

        public override void Init()
        {
        }

        public override void Close()
        {
        }

        public string MyPropValue
        {
            set { textBoxPropValue.Text = value ?? ""; }
            get { return textBoxPropValue.Text; }
        }

        private void textBoxPropValue_TextChanged(object sender, System.EventArgs e)
        {

        }
    }
}
