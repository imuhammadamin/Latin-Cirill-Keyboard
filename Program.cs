using System;
using System.Runtime.InteropServices;
class Program
{
    #region DLLs
    [DllImport("user32.dll")]
    private static extern bool PostMessage(int hhwnd, uint msg, IntPtr wparam, IntPtr lparam);

    [DllImport("user32.dll")]
    private static extern IntPtr LoadKeyboardLayout(string pwszKLID, uint Flags);
    #endregion

    #region Variables
    private static uint WM_INPUTLANGCHANGEREQUEST = 0x0050;
    private static int HWND_BROADCAST = 0xffff;
    private static string ru_RU = "00020419";
    private static string en_US = "00000409";
    private static uint KLF_ACTIVATE = 1;
    #endregion
    
    [STAThread]
    static void Main(string[] args)
    {
        ChangeLanguage(ru_RU);

        Console.ReadLine();

        ChangeLanguage(en_US);
    }
    
    #region Changer
    private static void ChangeLanguage(string lang)
    {
        PostMessage(HWND_BROADCAST, WM_INPUTLANGCHANGEREQUEST, IntPtr.Zero, LoadKeyboardLayout(lang, KLF_ACTIVATE));
    }
    #endregion
}