using System;
using System.Drawing;
using WpfScreenHelper;
using System.Runtime.InteropServices;
using VacancyFinder.Contracts;

namespace VacancyFinder.Service
{
    /// <summary>
    /// Служба для работы с Windows API (GDI)
    /// </summary>
    public class DisplayService : IService
    {
        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        private static extern int GetDeviceCaps(IntPtr hDC, int nIndex);

        private enum DeviceCap
        {
            VERTRES = 10,
            DESKTOPVERTRES = 117
        }

        private double GetWindowsScreenScalingFactor(bool percentage = true)
        {
            //Create Graphics object from the current windows handle
            Graphics GraphicsObject = Graphics.FromHwnd(IntPtr.Zero);
            //Get Handle to the device context associated with this Graphics object
            IntPtr DeviceContextHandle = GraphicsObject.GetHdc();
            //Call GetDeviceCaps with the Handle to retrieve the Screen Height
            int LogicalScreenHeight = GetDeviceCaps(DeviceContextHandle, (int)DeviceCap.VERTRES);
            int PhysicalScreenHeight = GetDeviceCaps(DeviceContextHandle, (int)DeviceCap.DESKTOPVERTRES);
            //Divide the Screen Heights to get the scaling factor and round it to two decimals
            double ScreenScalingFactor = Math.Round(PhysicalScreenHeight / (double)LogicalScreenHeight, 2);
            //If requested as percentage - convert it
            if (percentage)
            {
                ScreenScalingFactor *= 100.0;
            }
            //Release the Handle and Dispose of the GraphicsObject object
            GraphicsObject.ReleaseHdc(DeviceContextHandle);
            GraphicsObject.Dispose();
            //Return the Scaling Factor
            return ScreenScalingFactor;
        }

        /// <summary>
        /// Метод получения текущего разрешения экрана
        /// </summary>
        /// <returns></returns>
        public Size GetDisplayResolution()
        {
            var sf = GetWindowsScreenScalingFactor(false);
            var screenWidth = Screen.PrimaryScreen.Bounds.Width * sf;
            var screenHeight = Screen.PrimaryScreen.Bounds.Height * sf;
            return new Size((int)screenWidth, (int)screenHeight);
        }
    }
}
