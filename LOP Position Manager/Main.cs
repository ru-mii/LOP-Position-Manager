using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static LOP_Position_Manager.InfoStruct;

namespace LOP_Position_Manager
{
    public partial class Main : Form
    {
        public Main() { InitializeComponent(); }

        // build version, adding new line because github adds it to their file
        // and the version is being compared with one written in github file in repo
        public static string softwareVersion = "1" + "\n";

        public static Process gameProcess = null;
        long processSession = 0;
        SoundPlayer clickSound = new SoundPlayer(Properties.Resources.click);

        IntPtr mainModule = IntPtr.Zero;
        IntPtr sizeMainModule = IntPtr.Zero;

        IntPtr playerPointer = IntPtr.Zero;
        IntPtr cameraPointer = IntPtr.Zero;
        IntPtr movementPointer = IntPtr.Zero;

        int hotkey_SavePosition = 0;
        int hotkey_LoadPosition = 0;

        public int[] keyboardTableReady = new int[999];

        private void Main_Load(object sender, EventArgs e)
        {
            // startup options
            CheckForIllegalCrossThreadCalls = false;
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
            CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.InvariantCulture;
            selector.Select();

            Text = "LOP PM v" + softwareVersion.ToString();

            // load settings
            if (Saves.Read("settings", "windowAlwaysOnTop") == "True")
            {
                checkBox_WindowAlwaysOnTop.Checked = true;
                TopMost = checkBox_WindowAlwaysOnTop.Checked;
            }

            if (Saves.Read("settings", "disableSounds") == "True")
            {
                checkBox_DisableSounds.Checked = true;
            }

            // load hotkeys
            int.TryParse(Saves.Read("settings", "keyValueSavePosition"), out hotkey_SavePosition);
            int.TryParse(Saves.Read("settings", "keyValueLoadPosition"), out hotkey_LoadPosition);
            textBox_SavePositionHotkey.Text = Saves.Read("settings", "keyCodeSavePosition");
            textBox_LoadPositionHotkey.Text = Saves.Read("settings", "keyCodeLoadPosition");
            if (textBox_SavePositionHotkey.Text == "") textBox_SavePositionHotkey.Text = "< click here to set hotkey >";
            if (textBox_LoadPositionHotkey.Text == "") textBox_LoadPositionHotkey.Text = "< click here to set hotkey >";

            // fill out keyboard table
            for (int i = 0; i < keyboardTableReady.Length; i++)
                keyboardTableReady[i] = 0;

            // run threads
            backgroundWorker_CheckProcess.RunWorkerAsync();
            backgroundWorker_Main.RunWorkerAsync();
            backgroundWorker_CheckUpdates.RunWorkerAsync();
        }

        private void backgroundWorker_CheckProcess_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                bool foundProcess = false;
                foreach (Process process in Process.GetProcesses())
                {
                    if (process.ProcessName == "LOP-Win64-Shipping" && process.MainWindowTitle == "Lies of P  ")
                    //if (process.ProcessName == "LOP-Win64-Shipping")
                    {
                        gameProcess = process;
                        foundProcess = true;
                    }
                }

                if (foundProcess && processSession != ((DateTimeOffset)gameProcess.StartTime).ToUnixTimeMilliseconds())
                {
                    processSession = ((DateTimeOffset)gameProcess.StartTime).ToUnixTimeMilliseconds();

                    foreach (ProcessModule module in gameProcess.Modules)
                    {
                        if (module.ModuleName.Equals("LOP-Win64-Shipping.exe", StringComparison.OrdinalIgnoreCase))
                        {
                            mainModule = module.BaseAddress;
                            sizeMainModule = (IntPtr)module.ModuleMemorySize;
                            break;
                        }
                    }

                    // patch player position
                    if (true)
                    {
                        IntPtr function = Toolkit.SignatureScan("F2 0F 11 45 E0 89 45 E8 48 8D 45 E0 F2 0F 10 00 8B 40 08 F2 0F 11 02 89",
                            gameProcess.Handle, -0x31, mainModule, (IntPtr)((long)mainModule + (long)sizeMainModule),
                            (int)AllocationProtectEnum.PAGE_EXECUTE_READ);

                        if (function != IntPtr.Zero)
                        {
                            IntPtr allocated = Toolkit.AllocateMemory();

                            byte[] s1 = { 0xFF, 0x25, 0x00, 0x00, 0x00, 0x00 };
                            byte[] s2 = BitConverter.GetBytes((ulong)allocated);
                            byte[] s3 = { 0x90 };
                            byte[] start = Toolkit.MergeByteArrays(s1, s2, s3);

                            byte[] e1 = { 0x48, 0x89, 0x0D, 0xF9, 0x00, 0x00, 0x00 };
                            byte[] e2 = { 0x0F, 0x10, 0x89, 0xC0, 0x01, 0x00, 0x00, 0x0F, 0x28, 0xC1, 0xF3, 0x0F, 0x11, 0x4D, 0xE0 };
                            byte[] e3 = { 0xFF, 0x25, 0x00, 0x00, 0x00, 0x00 };
                            byte[] e4 = BitConverter.GetBytes((ulong)function + 0xF);
                            byte[] exit = Toolkit.MergeByteArrays(e1, e2, e3, e4);

                            Toolkit.WriteMemory(allocated, exit);
                            Toolkit.WriteMemory(function, start);

                            playerPointer = allocated + 0x100;
                        }
                        else
                        {
                            Toolkit.ShowError("scan 53BU03 failed");
                            Environment.Exit(0);
                        }
                    }

                    // patch camera position
                    if (true)
                    {
                        IntPtr function = Toolkit.SignatureScan("0F 11 86 C0 02 00 00 89 46 40 89 4E 44 89 46 78 89 4E 7C 4C",
                            gameProcess.Handle, -0x36, mainModule, (IntPtr)((long)mainModule + (long)sizeMainModule),
                            (int)AllocationProtectEnum.PAGE_EXECUTE_READ);

                        if (function != IntPtr.Zero)
                        {
                            IntPtr allocated = Toolkit.AllocateMemory();

                            byte[] s1 = { 0xFF, 0x25, 0x00, 0x00, 0x00, 0x00 };
                            byte[] s2 = BitConverter.GetBytes((ulong)allocated);
                            byte[] start = Toolkit.MergeByteArrays(s1, s2);

                            byte[] e1 = { 0x48, 0xA3 };
                            byte[] e2 = BitConverter.GetBytes((ulong)allocated + 0x100);
                            byte[] e3 = { 0x4C, 0x8B, 0x08, 0x4C, 0x8D, 0x85, 0x98, 0x00, 0x00, 0x00, 0x48, 0x8D, 0x55, 0x68 };
                            byte[] e4 = { 0xFF, 0x25, 0x00, 0x00, 0x00, 0x00 };
                            byte[] e5 = BitConverter.GetBytes((ulong)function + 0xE);
                            byte[] exit = Toolkit.MergeByteArrays(e1, e2, e3, e4, e5);

                            Toolkit.WriteMemory(allocated, exit);
                            Toolkit.WriteMemory(function, start);

                            cameraPointer = allocated + 0x100;
                        }
                        else
                        {
                            Toolkit.ShowError("scan M2RW7Q failed");
                            Environment.Exit(0);
                        }
                    }

                    // patch position refresh
                    if (true)
                    {
                        IntPtr function = Toolkit.SignatureScan("F3 44 0F 59 C5 F3 0F 59 F5 48 8B 06 48 8B CE",
                            gameProcess.Handle, 0x1E, mainModule, (IntPtr)((long)mainModule + (long)sizeMainModule),
                            (int)AllocationProtectEnum.PAGE_EXECUTE_READ);

                        if (function != IntPtr.Zero)
                        {
                            IntPtr allocated = Toolkit.AllocateMemory();

                            byte[] s1 = { 0xFF, 0x25, 0x00, 0x00, 0x00, 0x00 };
                            byte[] s2 = BitConverter.GetBytes((ulong)allocated);
                            byte[] s3 = { 0x90 };
                            byte[] start = Toolkit.MergeByteArrays(s1, s2, s3);

                            byte[] e1 = { 0x48, 0x89, 0x35, 0xF9, 0x00, 0x00, 0x00 };
                            byte[] e2 = { 0xF3, 0x0F, 0x59, 0xF0, 0xF3, 0x0F, 0x11, 0x3F, 0xF3, 0x44, 0x0F, 0x11, 0x47, 0x04 };
                            byte[] e3 = { 0xFF, 0x25, 0x00, 0x00, 0x00, 0x00 };
                            byte[] e4 = BitConverter.GetBytes((ulong)function + 0xF);
                            byte[] exit = Toolkit.MergeByteArrays(e1, e2, e3, e4);

                            Toolkit.WriteMemory(allocated, exit);
                            Toolkit.WriteMemory(function, start);

                            movementPointer = allocated + 0x100;
                        }
                        else
                        {
                            Toolkit.ShowError("scan KLPDK5 failed");
                            Environment.Exit(0);
                        }
                    }
                }

                Thread.Sleep(100);
            }
        }


        private void button_SavePosition_Click(object sender, EventArgs e) { SavePosition(); selector.Select(); if (!checkBox_DisableSounds.Checked) clickSound.Play(); }
        private void button_LoadPosition_Click(object sender, EventArgs e) { LoadPosition(); selector.Select(); }

        void SavePosition()
        {
            if (gameProcess != null)
            {
                if (true)
                {
                    byte[] rawInsidePointer = Toolkit.ReadMemoryBytes(playerPointer, 8);
                    IntPtr aPointer = (IntPtr)BitConverter.ToInt64(rawInsidePointer, 0);

                    Vector3 data = new Vector3(
                    Toolkit.ReadMemoryFloat(aPointer + 0x1C0),
                    Toolkit.ReadMemoryFloat(aPointer + 0x1C0 + 0x4),
                    Toolkit.ReadMemoryFloat(aPointer + 0x1C0 + 0x8));

                    textBox_PlayerPositionX.Text = data.X.ToString("G9", CultureInfo.InvariantCulture);
                    textBox_PlayerPositionY.Text = data.Y.ToString("G9", CultureInfo.InvariantCulture);
                    textBox_PlayerPositionZ.Text = data.Z.ToString("G9", CultureInfo.InvariantCulture);
                }

                if (true)
                {
                    byte[] rawInsidePointer = Toolkit.ReadMemoryBytes(cameraPointer, 8);
                    IntPtr aPointer = (IntPtr)BitConverter.ToInt64(rawInsidePointer, 0);

                    Vector3 data = new Vector3(
                    Toolkit.ReadMemoryFloat(aPointer + 0x248),
                    Toolkit.ReadMemoryFloat(aPointer + 0x248 + 0x4),
                    Toolkit.ReadMemoryFloat(aPointer + 0x248 + 0x8));

                    textBox_Pitch.Text = data.X.ToString("G9", CultureInfo.InvariantCulture);
                    textBox_Yaw.Text = data.Y.ToString("G9", CultureInfo.InvariantCulture);
                }
            }
        }

        void LoadPosition()
        {
            if (gameProcess != null)
            {
                if (true)
                {
                    string posX = textBox_PlayerPositionX.Text.Replace(",", ".");
                    string posY = textBox_PlayerPositionY.Text.Replace(",", ".");
                    string posZ = textBox_PlayerPositionZ.Text.Replace(",", ".");

                    Vector3 data = new Vector3();

                    if (float.TryParse(posX, NumberStyles.Float, CultureInfo.InvariantCulture, out data.X) &&
                    float.TryParse(posY, NumberStyles.Float, CultureInfo.InvariantCulture, out data.Y) &&
                    float.TryParse(posZ, NumberStyles.Float, CultureInfo.InvariantCulture, out data.Z))
                    {
                        byte[] rawInsidePointer = Toolkit.ReadMemoryBytes(playerPointer, 8);
                        IntPtr aPointer = (IntPtr)BitConverter.ToInt64(rawInsidePointer, 0);

                        Toolkit.WriteMemory(aPointer + 0x1C0, BitConverter.GetBytes(data.X));
                        Toolkit.WriteMemory(aPointer + 0x1C0 + 0x4, BitConverter.GetBytes(data.Y));
                        Toolkit.WriteMemory(aPointer + 0x1C0 + 0x8, BitConverter.GetBytes(data.Z));
                    }
                    else Toolkit.ShowError("couldn't parse player position");
                }

                if (true)
                {
                    string pitch = textBox_Pitch.Text.Replace(",", ".");
                    string yaw = textBox_Yaw.Text.Replace(",", ".");

                    Vector3 data = new Vector3();

                    if (float.TryParse(pitch, NumberStyles.Float, CultureInfo.InvariantCulture, out data.X) &&
                    float.TryParse(yaw, NumberStyles.Float, CultureInfo.InvariantCulture, out data.Y))
                    {
                        byte[] rawInsidePointer = Toolkit.ReadMemoryBytes(cameraPointer, 8);
                        IntPtr aPointer = (IntPtr)BitConverter.ToInt64(rawInsidePointer, 0);

                        Toolkit.WriteMemory(aPointer + 0x248, BitConverter.GetBytes(data.X));
                        Toolkit.WriteMemory(aPointer + 0x248 + 0x4, BitConverter.GetBytes(data.Y));
                    }
                    else Toolkit.ShowError("couldn't parse camera view");
                }

                if (true)
                {
                    byte[] mode = { 3 };
                    byte[] rawInsidePointer = Toolkit.ReadMemoryBytes(movementPointer, 8);
                    IntPtr aPointer = (IntPtr)BitConverter.ToInt64(rawInsidePointer, 0);
                    Toolkit.WriteMemory(aPointer + 0x168, mode);
                }
            }
        }

        private void checkBox_WindowAlwaysOnTop_CheckedChanged(object sender, EventArgs e)
        {
            Saves.Save("settings", "windowAlwaysOnTop", checkBox_WindowAlwaysOnTop.Checked.ToString());
            TopMost = checkBox_WindowAlwaysOnTop.Checked;
        }

        private void button_LoadPositionFromFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            string savesPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                Saves.developer, Saves.software, "saves");

            if (!Directory.Exists(savesPath)) Directory.CreateDirectory(savesPath);

            fileDialog.Title = "Select a file";
            fileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            fileDialog.InitialDirectory = savesPath;

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(fileDialog.FileName))
                {
                    string[] allLines = File.ReadAllLines(fileDialog.FileName);

                    textBox_PlayerPositionX.Text = allLines[0];
                    textBox_PlayerPositionY.Text = allLines[1];
                    textBox_PlayerPositionZ.Text = allLines[2];
                    textBox_Pitch.Text = allLines[3];
                    textBox_Yaw.Text = allLines[4];

                    label_LoadedSaveName.Text = "loaded save file: " +
                        Path.GetFileNameWithoutExtension(fileDialog.FileName);
                }
            }

            selector.Select();
        }

        private void button_SavePositionToFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            string savesPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                Saves.developer, Saves.software, "saves");

            fileDialog.Title = "Select a file";
            fileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            fileDialog.InitialDirectory = savesPath;

            if (!Directory.Exists(savesPath)) Directory.CreateDirectory(savesPath);

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string final = textBox_PlayerPositionX.Text + Environment.NewLine +
                    textBox_PlayerPositionY.Text + Environment.NewLine +
                    textBox_PlayerPositionZ.Text + Environment.NewLine +
                    textBox_Pitch.Text + Environment.NewLine +
                    textBox_Yaw.Text;

                File.WriteAllText(fileDialog.FileName, final);
            }

            selector.Select();
        }

        private void backgroundWorker_Main_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                if (Toolkit.IsKeyPressed(hotkey_SavePosition))
                {
                    if (keyboardTableReady[hotkey_SavePosition] != 1)
                    {
                        button_SavePosition.PerformClick();
                        keyboardTableReady[hotkey_SavePosition] = 1;
                    }
                }
                else keyboardTableReady[hotkey_SavePosition] = 0;

                if (Toolkit.IsKeyPressed(hotkey_LoadPosition))
                {
                    if (keyboardTableReady[hotkey_LoadPosition] != 1)
                    {
                        button_LoadPosition.PerformClick();
                        keyboardTableReady[hotkey_LoadPosition] = 1;
                    }
                }
                else keyboardTableReady[hotkey_LoadPosition] = 0;

                Thread.Sleep(16);
            }
        }

        private void textBox_SavePositionHotkey_Enter(object sender, EventArgs e)
        {
            textBox_SavePositionHotkey.Text = "listening...";
        }

        private void textBox_SavePositionHotkey_Leave(object sender, EventArgs e)
        {
            if (textBox_SavePositionHotkey.Text == "listening...")
                textBox_SavePositionHotkey.Text = "< click here to set hotkey >";
        }

        private void textBox_SavePositionHotkey_KeyDown(object sender, KeyEventArgs e)
        {
            hotkey_SavePosition = e.KeyValue;
            Saves.Save("settings", "keyCodeSavePosition", e.KeyCode.ToString());
            Saves.Save("settings", "keyValueSavePosition", e.KeyValue.ToString());
            textBox_SavePositionHotkey.Text = e.KeyCode.ToString();
            selector.Select();
            keyboardTableReady[hotkey_SavePosition] = 1;
        }

        private void textBox_LoadPositionHotkey_Enter(object sender, EventArgs e)
        {
            textBox_LoadPositionHotkey.Text = "listening...";
        }

        private void textBox_LoadPositionHotkey_Leave(object sender, EventArgs e)
        {
            if (textBox_LoadPositionHotkey.Text == "listening...")
                textBox_LoadPositionHotkey.Text = "< click here to set hotkey >";
        }

        private void textBox_LoadPositionHotkey_KeyDown(object sender, KeyEventArgs e)
        {
            hotkey_LoadPosition = e.KeyValue;
            Saves.Save("settings", "keyCodeLoadPosition", e.KeyCode.ToString());
            Saves.Save("settings", "keyValueLoadPosition", e.KeyValue.ToString());
            textBox_LoadPositionHotkey.Text = e.KeyCode.ToString();
            selector.Select();
            keyboardTableReady[hotkey_LoadPosition] = 1;
        }

        private void Main_Click(object sender, EventArgs e)
        {
            selector.Select();
        }

        private void checkBox_DisableSounds_CheckedChanged(object sender, EventArgs e)
        {
            Saves.Save("settings", "disableSounds", checkBox_DisableSounds.Checked.ToString());
        }

        private void backgroundWorker_CheckUpdates_DoWork(object sender, DoWorkEventArgs e)
        {
            Updates.CheckForUpdates();
        }
    }
}
