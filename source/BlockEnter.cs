using System;
using System.Windows.Forms;
using Gma.System.MouseKeyHook;

namespace LoLToxicitySelfHelp
{
    internal static class BlockEnter
    {
        private static IKeyboardMouseEvents m_GlobalHook;

        public static void Initialize()
        {
            m_GlobalHook = Hook.GlobalEvents();
            m_GlobalHook.KeyPress += BlockEnterKeyPress;
            m_GlobalHook.KeyDown += BlockEnterKeyDown;
            m_GlobalHook.KeyUp += BlockEnterKeyUp;
        }

        private static void BlockEnterKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Settings.BlockEnter)
                return;

            if (e.KeyChar == 13)
            {
                e.Handled = true;
            }
        }

        private static void BlockEnterKeyDown(object sender, KeyEventArgs e)
        {
            if (!Settings.BlockEnter)
                return;

            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                if (Settings.Beep)
                {
                    Console.Beep(500, 200);
                }
            }
        }

        private static void BlockEnterKeyUp(object sender, KeyEventArgs e)
        {
            if (!Settings.BlockEnter)
                return;

            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
            }
        }
    }
}
