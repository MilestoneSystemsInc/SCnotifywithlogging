using System;
using System.Windows;
using System.Collections.Generic;
using VideoOS.Platform;
using VideoOS.Platform.Client;

namespace SCnotifywithlogging.Client
{
    /// <summary>
    /// The SidePanelPlugin defines a plugin that resides in the live or playback side panel in the Smart Client.
    /// Is it only created once during startup/login and never disposed.
    /// This class can be instantiated directly without making your own inherited class
    /// </summary>
    public class SCnotifywithloggingSidePanelPlugin : SidePanelPlugin
    {
        /// <summary>
        /// This method is called when the Environment is up and configuration is loaded.
        /// This method is called once every time the user logins in.
        /// </summary>
        public override void Init()
        {
    
        }

        /// <summary>
        /// Flush any configuration or dynamic resources.
        /// </summary>
        public override void Close()
        {
        }

        ///// <summary>
        ///// Only use this method if support for Smart Client prior to 2017 R3 is required.
        ///// For all newer versions GenerateWpfUserControl() below should be used.
        /////
        ///// Creates a new UserControl to be placed on the specified panel place.
        ///// Size of this panel is limited and can not be wider than 188 pixels.
        ///// </summary>
        ///// <returns></returns>
        //public override SidePanelUserControl GenerateUserControl()
        //{
        //	return new SCnotifywithloggingSidePanelUserControl();
        //}

        /// <summary>
        /// Creates a new UserControl to be placed on the specified panel place.
        /// Size of this panel is limited and can not be wider than 188 pixels.
        /// </summary>
        /// <returns></returns>
        public override SidePanelWpfUserControl GenerateWpfUserControl()
        {
            return new SCnotifywithloggingSidePanelWpfUserControl();
        }

        /// <summary>
        /// Identification of this SidePanel
        /// </summary>
        public override Guid Id
        {
            get { return SCnotifywithloggingDefinition.SCnotifywithloggingSidePanel; }
        }


        /// <summary>
        /// Name of panel - displayed on top of user control
        /// </summary>
        public override string Name
        {
            get { return "Smart Client Logon Notification Side panel"; }
        }

        /// <summary>
        /// Where to place this panel.
        /// </summary>
        public override List<SidePanelPlaceDefinition> SidePanelPlaceDefinitions
        {
            get
            {
                return new List<SidePanelPlaceDefinition>() {
                    new SidePanelPlaceDefinition() {
                        WorkSpaceId = VideoOS.Platform.ClientControl.LiveBuildInWorkSpaceId,
                        WorkSpaceStates = new List<WorkSpaceState>() { VideoOS.Platform.WorkSpaceState.Normal }
                    }
                };
            }
        }

    }
}
