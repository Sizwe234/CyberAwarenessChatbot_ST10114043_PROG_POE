using System;
using System.Windows.Forms;

namespace CyberAwarenessChatbot
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();      // Enables modern visual styles for controls
            Application.SetCompatibleTextRenderingDefault(false); // Uses GDI+ for text rendering
            Application.Run(new MainForm());       // Launches the GUI
        }
    }
}
