using System;
using System.Drawing;
using System.Windows.Forms;

namespace LoLToxicitySelfHelp
{
    internal sealed class ProcessTray : IDisposable
    {
        private readonly NotifyIcon m_NotifyIcon;
        private readonly MenuItem m_BlockEnterMenuItem;
        private readonly MenuItem m_BeepMenuitem;

        public ProcessTray()
        {
            m_BlockEnterMenuItem = new MenuItem("Block enter key", (s, e) => ToggleBlocking())
            {
                Checked = true
            };

            m_BeepMenuitem = new MenuItem("Beep on block", (s, e) => ToggleBeep())
            {
                Checked = true
            };


            m_NotifyIcon = new NotifyIcon
            {
                Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath),
                ContextMenu = new ContextMenu(new[]
                {
                    m_BlockEnterMenuItem,
                    m_BeepMenuitem,
                    new MenuItem("Exit", (s, e) => Application.Exit())
                }),
                Visible = true
            };
        }

        private void ToggleBlocking()
        {
            Settings.BlockEnter = !Settings.BlockEnter;
            m_BlockEnterMenuItem.Checked = !m_BlockEnterMenuItem.Checked;
        }

        private void ToggleBeep()
        {
            Settings.Beep = !Settings.Beep;
            m_BeepMenuitem.Checked = !m_BeepMenuitem.Checked;
        }

        public void Dispose()
        {
            m_NotifyIcon.Visible = false;
        }
    }
}
