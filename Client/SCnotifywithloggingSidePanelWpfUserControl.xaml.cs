using System.Windows;
using VideoOS.Platform;
using VideoOS.Platform.Client;
using VideoOS.Platform.Messaging;

namespace SCnotifywithlogging.Client
{
    public partial class SCnotifywithloggingSidePanelWpfUserControl : SidePanelWpfUserControl
    {
        public SCnotifywithloggingSidePanelWpfUserControl()
        {
            InitializeComponent();
         
        }

        public override void Init()
        {
            //Window window = new Window
            //{
            //    Title = "My User Control Dialog",
            //    Content = new UserControl1(),
            //    SizeToContent = SizeToContent.WidthAndHeight,
            //    ResizeMode = ResizeMode.NoResize
            //};

            //window.ShowDialog();
            Notification notification = new Notification();
        
            notification.ShowDialog();
            
        }

        public override void Close()
        {
        }

        /// <summary>
        /// Sample code to show how to maximize the current view item to fill the entire layout area.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonMax_Click(object sender, RoutedEventArgs e)
        {

           
        }

        /// <summary>
        /// Sample code to show how to restore the view to normal mode, e.g. show all view items.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

    }
}
