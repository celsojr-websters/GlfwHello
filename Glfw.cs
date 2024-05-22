using System;
using System.Runtime.InteropServices;

namespace GlfwHello
{
    public static class Glfw
    {
        private const string GlfwLibrary = "glfw3";

        public const int GLFW_NO_API = 0;
        public const int GLFW_CLIENT_API = 0x00022001;

        public static void WindowHint(Hint hint, Hint value)
        {
            glfwWindowHint((int)hint, (int)value);
        }

        [DllImport(GlfwLibrary, CallingConvention = CallingConvention.Cdecl)]
        public static extern int glfwInit();

        [DllImport(GlfwLibrary, CallingConvention = CallingConvention.Cdecl)]
        public static extern void glfwTerminate();

        [DllImport(GlfwLibrary, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr glfwCreateWindow(int width, int height, string title, IntPtr monitor, IntPtr share);

        [DllImport(GlfwLibrary, CallingConvention = CallingConvention.Cdecl)]
        public static extern void glfwDestroyWindow(IntPtr window);

        [DllImport(GlfwLibrary, CallingConvention = CallingConvention.Cdecl)]
        public static extern void glfwPollEvents();

        [DllImport(GlfwLibrary, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool glfwWindowShouldClose(IntPtr window);

        [DllImport(GlfwLibrary, CallingConvention = CallingConvention.Cdecl)]
        private static extern void glfwWindowHint(int hint, int value);

        [DllImport(GlfwLibrary, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr glfwGetWin32Window(IntPtr window);

        [DllImport(GlfwLibrary, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr glfwGetCocoaWindow(IntPtr window);

        [DllImport(GlfwLibrary, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr glfwGetX11Window(IntPtr window);
    }

    public enum Hint : int
    {
        GlfwClientApi = Glfw.GLFW_CLIENT_API,
        GlfwNoApi = Glfw.GLFW_NO_API
    }
}
