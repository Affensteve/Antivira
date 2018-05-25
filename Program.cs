using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Threading;

namespace Antivira
{
    public class SysTrayApp : Form
    {
        private NotifyIcon trayIcon;
        private ContextMenu trayMenu;

        [STAThread]
        public static void Main()
        {
            Application.Run(new SysTrayApp());
        }
        public SysTrayApp()
        {
            // Create a simple tray menu with only one item.
            trayMenu = new ContextMenu();
            trayMenu.MenuItems.Add("Viren scannen", OnScan);
            trayMenu.MenuItems.Add("White- Blacklist bearbeiten");
            trayMenu.MenuItems.Add("Windows Firewall deaktivieren");
            trayMenu.MenuItems.Add("Exit", OnExit);

            // Create a tray icon. In this example we use a
            // standard system icon for simplicity, but you
            // can of course use your own custom icon too.
            trayIcon = new NotifyIcon();
            trayIcon.Text = "Antivira";
            Bitmap bmp = Antivira.Properties.Resources.icon;
            trayIcon.Icon = new Icon(Icon.FromHandle(bmp.GetHicon()), 40, 40);

            // Add menu to tray icon and show it.
            trayIcon.ContextMenu = trayMenu;
            trayIcon.Visible = true;
         }

        protected override void OnLoad(EventArgs e)
        {
            Visible = false; // Hide form window.
            ShowInTaskbar = false; // Remove from taskbar.

            base.OnLoad(e);
        }

        private void OnScan(object sender, EventArgs e)
        {
            var myForm = new AntiviraUI();

            DialogResult dr = myForm.showWithData();
            if (dr == DialogResult.OK)
            {
                myForm.Close();
            }
        }
        
        private void OnExit(object sender, EventArgs e)
        {
            Application.Exit();
        }
        protected override void Dispose(bool isDisposing)
        {
            if (isDisposing)
            {
                // Release the icon resource.
                trayIcon.Dispose();
            }

            base.Dispose(isDisposing);
        }
    }
}