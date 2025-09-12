using System.Runtime.InteropServices;

internal class Program
{
    [DllImport("user32.dll")]
    public static extern bool MessageBeep(uint uTipe);
    [DllImport("user32.dll", CharSet = CharSet.Unicode)]
    public static extern int MessageBox(IntPtr hWnd, string lpText, string lpCaption, uint uType);

    public static void CustomMessageWithSound(IntPtr hWnd, string lpText, string lpCaption, uint uType)
    {
        MessageBeep(uType);
        MessageBox(hWnd, lpText, lpCaption, 0x00000000);
    }

    private static void Main(string[] args)
    {
        MessageBox(IntPtr.Zero, "MB_OK", "Заголовок MB_OK", 0x00000000);
        MessageBox(IntPtr.Zero, "MB_OKCANCEL", "Заголовок MB_OKCANCEL", 0x00000001);
        MessageBox(IntPtr.Zero, "MB_ICONINFORMATION", "Заголовок MB_ICONINFORMATION", 0x00000010);
        MessageBox(IntPtr.Zero, "MB_ICONWARNING", "Заголовок MB_ICONWARNING", 0x00000020);
        MessageBox(IntPtr.Zero, "MB_ICONERROR", "Заголовок MB_ICONERROR", 0x00000030);
        MessageBox(IntPtr.Zero, "MB_ICONQUESTION", "Заголовок MB_ICONQUESTION", 0x00000040);

        CustomMessageWithSound(IntPtr.Zero, "Со звуком MB_ICONINFORMATION", "Заголовок MB_OK", 0x00000010);
        CustomMessageWithSound(IntPtr.Zero, "Со звуком MB_ICONERROR", "Заголовок MB_OK", 0x00000030);
        CustomMessageWithSound(IntPtr.Zero, "Со звуком MB_ICONQUESTION", "Заголовок MB_OK", 0x00000040);
    }
}