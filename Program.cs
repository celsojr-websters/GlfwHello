using System;
using System.Runtime.InteropServices;

namespace GlfwHello
{
    internal class Program
    {
        const int WIDTH = 640;
        const int HEIGHT = 320;
        const string TITLE = "Hello GLFW";

        static void Main(string[] args)
        {
            if (Glfw.glfwInit() == 0)
            {
                Console.WriteLine("Failed to initialize GLFW.");
                return;
            }

            Glfw.WindowHint(Hint.GlfwClientApi, Hint.GlfwNoApi);

            IntPtr window = Glfw.glfwCreateWindow(WIDTH, HEIGHT, TITLE, IntPtr.Zero, IntPtr.Zero);
            if (window == IntPtr.Zero)
            {
                Console.WriteLine("Failed to create GLFW window.");
                Glfw.glfwTerminate();
                return;
            }

            IntPtr nativeHandle = IntPtr.Zero;
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                nativeHandle = Glfw.glfwGetWin32Window(window);
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                nativeHandle = Glfw.glfwGetX11Window(window);
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                nativeHandle = Glfw.glfwGetCocoaWindow(window);
            }

            if (nativeHandle != IntPtr.Zero)
            {
                Console.WriteLine($"Native Window Handle: {nativeHandle}");
            }

            do
            {
                Glfw.glfwPollEvents();
            }
            while (!Glfw.glfwWindowShouldClose(window));

            Glfw.glfwDestroyWindow(window);
            Glfw.glfwTerminate();
        }
    }
}
