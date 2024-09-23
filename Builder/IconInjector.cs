using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Security;

namespace SimpleCrypter
{
    internal class IconInjector
    {
            public static void InjectIcon(string exeFileName, string iconFileName)
            {
                IconInjector.InjectIcon(exeFileName, iconFileName, 1U, 1U);
            }
            public static void InjectIcon(string exeFileName, string iconFileName, uint iconGroupID, uint iconBaseID)
            {
                IconInjector.IconFile iconFile = IconInjector.IconFile.FromFile(iconFileName);
                IntPtr hUpdate = IconInjector.NativeMethods.BeginUpdateResource(exeFileName, false);
                byte[] array = iconFile.CreateIconGroupData(iconBaseID);
                IconInjector.NativeMethods.UpdateResource(hUpdate, new IntPtr(14L), new IntPtr((long)((ulong)iconGroupID)), 0, array, array.Length);
                for (int i = 0; i <= iconFile.ImageCount - 1; i++)
                {
                    byte[] array2 = iconFile.ImageData(i);
                    IconInjector.NativeMethods.UpdateResource(hUpdate, new IntPtr(3L), new IntPtr((long)((ulong)iconBaseID + (ulong)((long)i))), 0, array2, array2.Length);
                }
                IconInjector.NativeMethods.EndUpdateResource(hUpdate, false);
            }

            [SuppressUnmanagedCodeSecurity]
            private class NativeMethods
            {
                [DllImport("kernel32")]
                public static extern IntPtr BeginUpdateResource(string fileName, [MarshalAs(UnmanagedType.Bool)] bool deleteExistingResources);

                [DllImport("kernel32")]
                [return: MarshalAs(UnmanagedType.Bool)]
                public static extern bool UpdateResource(IntPtr hUpdate, IntPtr type, IntPtr name, short language, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)] byte[] data, int dataSize);

                [DllImport("kernel32")]
                [return: MarshalAs(UnmanagedType.Bool)]
                public static extern bool EndUpdateResource(IntPtr hUpdate, [MarshalAs(UnmanagedType.Bool)] bool discard);
            }
            private struct ICONDIR
            {
                public ushort Reserved;
                public ushort Type;
                public ushort Count;
            }
            private struct ICONDIRENTRY
            {
                public byte Width;
                public byte Height;
                public byte ColorCount;
                public byte Reserved;
                public ushort Planes;
                public ushort BitCount;
                public int BytesInRes;
                public int ImageOffset;
            }
            private struct BITMAPINFOHEADER
            {
                public uint Size;
                public int Width;
                public int Height;
                public ushort Planes;
                public ushort BitCount;
                public uint Compression;
                public uint SizeImage;
                public int XPelsPerMeter;
                public int YPelsPerMeter;
                public uint ClrUsed;
                public uint ClrImportant;
            }
            [StructLayout(LayoutKind.Sequential, Pack = 2)]
            private struct GRPICONDIRENTRY
            {
                public byte Width;
                public byte Height;
                public byte ColorCount;
                public byte Reserved;
                public ushort Planes;
                public ushort BitCount;
                public int BytesInRes;
                public ushort ID;
            }
            private class IconFile
            {
                public int ImageCount
                {
                    get
                    {
                        return (int)this.iconDir.Count;
                    }
                }

                public byte[] ImageData(int index)
                {
                    return this.iconImage[index];
                }

                public static IconInjector.IconFile FromFile(string filename)
                {
                    IconInjector.IconFile iconFile = new IconInjector.IconFile();
                    byte[] array = File.ReadAllBytes(filename);
                    GCHandle gchandle = GCHandle.Alloc(array, GCHandleType.Pinned);
                    iconFile.iconDir = (IconInjector.ICONDIR)Marshal.PtrToStructure(gchandle.AddrOfPinnedObject(), typeof(IconInjector.ICONDIR));
                    iconFile.iconEntry = new IconInjector.ICONDIRENTRY[(int)iconFile.iconDir.Count];
                    iconFile.iconImage = new byte[(int)iconFile.iconDir.Count][];
                    int num = Marshal.SizeOf<IconInjector.ICONDIR>(iconFile.iconDir);
                    Type typeFromHandle = typeof(IconInjector.ICONDIRENTRY);
                    int num2 = Marshal.SizeOf(typeFromHandle);
                    for (int i = 0; i <= (int)(iconFile.iconDir.Count - 1); i++)
                    {
                        IconInjector.ICONDIRENTRY icondirentry = (IconInjector.ICONDIRENTRY)Marshal.PtrToStructure(new IntPtr(gchandle.AddrOfPinnedObject().ToInt64() + (long)num), typeFromHandle);
                        iconFile.iconEntry[i] = icondirentry;
                        iconFile.iconImage[i] = new byte[icondirentry.BytesInRes];
                        Buffer.BlockCopy(array, icondirentry.ImageOffset, iconFile.iconImage[i], 0, icondirentry.BytesInRes);
                        num += num2;
                    }
                    gchandle.Free();
                    return iconFile;
                }
                public byte[] CreateIconGroupData(uint iconBaseID)
                {
                    byte[] array = new byte[Marshal.SizeOf(typeof(IconInjector.ICONDIR)) + Marshal.SizeOf(typeof(IconInjector.GRPICONDIRENTRY)) * this.ImageCount];
                    GCHandle gchandle = GCHandle.Alloc(array, GCHandleType.Pinned);
                    Marshal.StructureToPtr<IconInjector.ICONDIR>(this.iconDir, gchandle.AddrOfPinnedObject(), false);
                    int num = Marshal.SizeOf<IconInjector.ICONDIR>(this.iconDir);
                    for (int i = 0; i <= this.ImageCount - 1; i++)
                    {
                        IconInjector.GRPICONDIRENTRY structure = default(IconInjector.GRPICONDIRENTRY);
                        IconInjector.BITMAPINFOHEADER bitmapinfoheader = default(IconInjector.BITMAPINFOHEADER);
                        GCHandle gchandle2 = GCHandle.Alloc(bitmapinfoheader, GCHandleType.Pinned);
                        Marshal.Copy(this.ImageData(i), 0, gchandle2.AddrOfPinnedObject(), Marshal.SizeOf(typeof(IconInjector.BITMAPINFOHEADER)));
                        gchandle2.Free();
                        structure.Width = this.iconEntry[i].Width;
                        structure.Height = this.iconEntry[i].Height;
                        structure.ColorCount = this.iconEntry[i].ColorCount;
                        structure.Reserved = this.iconEntry[i].Reserved;
                        structure.Planes = bitmapinfoheader.Planes;
                        structure.BitCount = bitmapinfoheader.BitCount;
                        structure.BytesInRes = this.iconEntry[i].BytesInRes;
                        structure.ID = Convert.ToUInt16((long)((ulong)iconBaseID + (ulong)((long)i)));
                        Marshal.StructureToPtr<IconInjector.GRPICONDIRENTRY>(structure, new IntPtr(gchandle.AddrOfPinnedObject().ToInt64() + (long)num), false);
                        num += Marshal.SizeOf(typeof(IconInjector.GRPICONDIRENTRY));
                    }
                    gchandle.Free();
                    return array;
                }

                private IconInjector.ICONDIR iconDir;
                private IconInjector.ICONDIRENTRY[] iconEntry;
                private byte[][] iconImage;
            }
        }
    }