using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading;
using System.Text;
using System.Windows.Forms;
using System.Net;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using System.Timers;
using System.Security.Policy;

namespace Instalar_Programas
{
    public partial class main : Form
    {
        System.Windows.Forms.CheckBox[] checkboxes;

        public main()
        {
            InitializeComponent();
            checkboxes = new System.Windows.Forms.CheckBox[]
            {
                checkBoxVisualC, checkBoxNETFramework, checkBoxDirectX, checkBoxVulkan, checkBoxJava,

                checkBoxChrome, checkBoxBrave, checkBoxOperaGX, checkBoxMozilla,

                checkBoxDiscord, checkBoxSteam, checkBoxEpic, checkBoxBattle, checkBoxUbisoft,
                checkBoxSpotify, checkBoxTorrent, checkBoxOBS, checkBoxWhatsapp, checkBoxTelegram,

                checkBoxVSCode, checkBoxNotepad, checkBoxGit, checkBox7z,
                checkBoxNodeJS, checkBoxPyCharm, checkBoxIntelliJ, checkBoxPy, checkBoxVStudio, checkBoxSQL,

                checkBoxMSI, checkBoxGPUZ, checkBoxCPUZ, checkBoxHWMonitor,

                checkBoxMinecraft, checkBoxValorant, checkBoxLOL, checkBoxHydra, checkBoxCloneHero, checkBoxOsu
            };

            timerLabel = new System.Windows.Forms.Timer();
            timerLabel.Interval = 5000;
            timerLabel.Tick += timerLabel_Tick;

        }
        public bool IsWingetInstalled()
        {
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "winget",
                Arguments = "--version",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (Process process = Process.Start(startInfo))
            {
                process.WaitForExit();
                return process.ExitCode == 0;
            }
        }

        public void installProgramas(String variavel)
        {
            labelNowInstalling.Visible = true;
            labelInstalling.Visible = true;
            System.Diagnostics.Process process = new Process();

            process.StartInfo.FileName = "cmd";
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;

            switch (variavel)
            {
                case ".NET Framework":
                    process.StartInfo.Arguments = "/C winget install Microsoft.DotNet.Framework.DeveloperPack_4";
                    labelInstalling.Text = ".NET Framework";
                    break;
                case "DirectX":
                    process.StartInfo.Arguments = "/C winget install Microsoft.DirectX";
                    labelInstalling.Text = "DirectX";
                    break;
                case "Vulkan":
                    process.StartInfo.Arguments = "/C winget install KhronosGroup.VulkanRT";
                    labelInstalling.Text = "Vulkan";
                    break;
                case "Java":
                    process.StartInfo.Arguments = "/C winget install Oracle.JavaRuntimeEnvironment";
                    labelInstalling.Text = "Java";
                    break;
                case "Google Chrome":
                    process.StartInfo.Arguments = "/C winget install Google.Chrome";
                    labelInstalling.Text = "Google Chrome";
                    break;
                case "Brave":
                    process.StartInfo.Arguments = "/C winget install Brave.Brave";
                    labelInstalling.Text = "Brave";
                    break;
                case "OperaGX":
                    process.StartInfo.Arguments = "/C winget install Opera.OperaGX";
                    labelInstalling.Text = "OperaGX";
                    break;
                case "Mozilla Firefox":
                    process.StartInfo.Arguments = "/C winget install Mozilla.Firefox";
                    labelInstalling.Text = "Mozilla Firefox";
                    break;
                case "Discord":
                    process.StartInfo.Arguments = "/C winget install Discord.Discord";
                    labelInstalling.Text = "Discord";
                    break;
                case "Steam":
                    process.StartInfo.Arguments = "/C winget install Valve.Steam";
                    labelInstalling.Text = "Steam";
                    break;
                case "Epic Games":
                    process.StartInfo.Arguments = "/C winget install EpicGames.EpicGamesLauncher";
                    labelInstalling.Text = "Epic Games";
                    break;
                case "Battle.net":
                    process.StartInfo.Arguments = "/C winget install Blizzard.BattleNet";
                    labelInstalling.Text = "Battle.net";
                    break;
                case "Ubisoft Connect":
                    process.StartInfo.Arguments = "/C winget install Ubisoft.Uplay";
                    labelInstalling.Text = "Ubisoft Connect";
                    break;
                case "Spotify":
                    process.StartInfo.Arguments = "/C winget install Spotify.Spotify";
                    labelInstalling.Text = "Spotify";
                    break;
                case "Telegram":
                    process.StartInfo.Arguments = "/C winget install Telegram.Telegram";
                    labelInstalling.Text = "Telegram";
                    break;
                case "qBittorrent":
                    process.StartInfo.Arguments = "/C winget install qBittorrent.qBittorrent";
                    labelInstalling.Text = "qBittorrent";
                    break;
                case "Libre Office":
                    process.StartInfo.Arguments = "/C winget install LibreOffice.LibreOffice";
                    labelInstalling.Text = "Libre Office";
                    break;
                case "OBS Studio":
                    process.StartInfo.Arguments = "/C winget install OBSProject.OBSStudio";
                    labelInstalling.Text = "OBS Studio";
                    break;
                case "7zip":
                    process.StartInfo.Arguments = "/C winget install 7zip.7zip";
                    labelInstalling.Text = "7zip";
                    break;
                case "CPU-Z":
                    process.StartInfo.Arguments = "/C winget install CPUID.CPU-Z";
                    labelInstalling.Text = "CPU-Z";
                    break;
                case "GPU-Z":
                    process.StartInfo.Arguments = "/C winget install TechPowerUp.GPU-Z";
                    labelInstalling.Text = "GPU-Z";
                    break;
                case "MSI Afterburner":
                    process.StartInfo.Arguments = "/C winget install MSI.Afterburner";
                    labelInstalling.Text = "MSI Afterburner";
                    break;
                case "HW Monitor":
                    process.StartInfo.Arguments = "/C winget install CPUID.HWMonitor";
                    labelInstalling.Text = "HW Monitor";
                    break;
                case "VS Code":
                    process.StartInfo.Arguments = "/C winget install Microsoft.VisualStudioCode";
                    labelInstalling.Text = "VS Code";
                    break;
                case "Visual Studio":
                    process.StartInfo.Arguments = "/C winget install Microsoft.VisualStudio";
                    labelInstalling.Text = "Visual Studio";
                    break;
                case "Notepad++":
                    process.StartInfo.Arguments = "/C winget install Notepad++.Notepad++";
                    labelInstalling.Text = "Notepad++";
                    break;
                case "Git":
                    process.StartInfo.Arguments = "/C winget install Git.Git";
                    labelInstalling.Text = "Git";
                    break;
                case "Node.JS":
                    process.StartInfo.Arguments = "/C winget install OpenJS.NodeJS";
                    labelInstalling.Text = "Node.JS";
                    break;
                case "Python":
                    process.StartInfo.Arguments = "/C winget install Python";
                    labelInstalling.Text = "Python";
                    break;
                case "IntelliJ IDEA":
                    process.StartInfo.Arguments = "/C winget install JetBrains.IntelliJIDEA.Community";
                    labelInstalling.Text = "IntelliJ IDEA";
                    break;
                case "PyCharm":
                    process.StartInfo.Arguments = "/C winget install JetBrains.PyCharm.Community";
                    labelInstalling.Text = "PyCharm";
                    break;
                case "MySQL":
                    process.StartInfo.Arguments = "/C winget install Oracle.MySQL";
                    labelInstalling.Text = "MySQL";
                    break;
                case "League of Legends":
                    process.StartInfo.Arguments = "/C winget install RiotGames.LeagueOfLegends.BR";
                    labelInstalling.Text = "League of Legends";
                    break;
                case "Valorant":
                    process.StartInfo.Arguments = "/C winget install RiotGames.Valorant.BR";
                    labelInstalling.Text = "Valorant";
                    break;
                case "Minecraft":
                    process.StartInfo.Arguments = "/C winget install Mojang.MinecraftLauncher";
                    labelInstalling.Text = "Minecraft";
                    break;
                case "osu!":
                    process.StartInfo.Arguments = "/C winget install ppy.osu";
                    labelInstalling.Text = "osu!";
                    break;
                case "Clone Hero":
                    process.StartInfo.Arguments = "/C winget install CloneHeroTeam.CloneHero";
                    labelInstalling.Text = "Clone Hero";
                    break;
                case "Hydra Launcher":
                    process.StartInfo.Arguments = "/C winget install HydraLauncher.Hydra";
                    labelInstalling.Text = "Hydra Launcher";
                    break;
                default:
                    labelInstalling.Text = "Programa não reconhecido.";
                    break;
            }

            process.Start();
            process.WaitForExit();
            labelInstalling.Text = "Instalação concluída";
            timerLabel.Start();
        }

        public void installProgramasSemWinget(String variavel)
        {
            labelNowInstalling.Visible = true;
            labelInstalling.Visible = true;
            switch (variavel)
            {
                case "WhatsApp Desktop":
                    Process.Start("ms-windows-store://pdp?ocid=storeweb-pdp-open-cta&hl=pt-br&gl=us&referrer=storeforweb&source=https%3A%2F%2Fapps.microsoft.com%2Fdetail%2F9nksqgp7f2nh%3Focid%3Dpdpshare%26hl%3Den-us%26gl%3DUS&productid=9nksqgp7f2nh&webid=4298adc7-5188-4829-92da-a03aeb259df3&websessionid=cf3c89b3-f146-4818-ac31-cc2872ec15e3");
                    labelInstalling.Text = "WhatsApp Desktop";
                    break;
                case "Visual C++":
                    InstalarVisualCpp();
                    break;
                default:
                    labelInstalling.Text = "Programa não reconhecido.";
                    break;
            }
        }

        public void InstalarVisualCpp()
        {
            System.Diagnostics.Process process = new Process();
            process.StartInfo.FileName = "cmd";
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.Arguments = "/C winget install Microsoft.VCRedist.2005.x86";
            labelInstalling.Text = "Visual C++ 2005 x86";
            process.Start();
            process.WaitForExit();

            System.Diagnostics.Process process2 = new Process();
            process2.StartInfo.FileName = "cmd";
            process2.StartInfo.RedirectStandardOutput = true;
            process2.StartInfo.UseShellExecute = false;
            process2.StartInfo.CreateNoWindow = true;
            process2.StartInfo.Arguments = "/C winget install Microsoft.VCRedist.2005.x64";
            labelInstalling.Text = "Visual C++ 2005 x64";
            process2.Start();
            process2.WaitForExit();

            System.Diagnostics.Process process3 = new Process();
            process3.StartInfo.FileName = "cmd";
            process3.StartInfo.RedirectStandardOutput = true;
            process3.StartInfo.UseShellExecute = false;
            process3.StartInfo.CreateNoWindow = true;
            process3.StartInfo.Arguments = "/C winget install Microsoft.VCRedist.2008.x86";
            labelInstalling.Text = "Visual C++ 2008 x86";
            process3.Start();
            process3.WaitForExit();

            System.Diagnostics.Process process4 = new Process();
            process4.StartInfo.FileName = "cmd";
            process4.StartInfo.RedirectStandardOutput = true;
            process4.StartInfo.UseShellExecute = false;
            process4.StartInfo.CreateNoWindow = true;
            process4.StartInfo.Arguments = "/C winget install Microsoft.VCRedist.2008.x64";
            labelInstalling.Text = "Visual C++ 2008 x64";
            process4.Start();
            process4.WaitForExit();

            System.Diagnostics.Process process5 = new Process();
            process5.StartInfo.FileName = "cmd";
            process5.StartInfo.RedirectStandardOutput = true;
            process5.StartInfo.UseShellExecute = false;
            process5.StartInfo.CreateNoWindow = true;
            process5.StartInfo.Arguments = "/C winget install Microsoft.VCRedist.2010.x86";
            labelInstalling.Text = "Visual C++ 2010 x86";
            process5.Start();
            process5.WaitForExit();

            System.Diagnostics.Process process6 = new Process();
            process6.StartInfo.FileName = "cmd";
            process6.StartInfo.RedirectStandardOutput = true;
            process6.StartInfo.UseShellExecute = false;
            process6.StartInfo.CreateNoWindow = true;
            process6.StartInfo.Arguments = "/C winget install Microsoft.VCRedist.2010.x64";
            labelInstalling.Text = "Visual C++ 2010 x64";
            process6.Start();
            process6.WaitForExit();

            System.Diagnostics.Process process7 = new Process();
            process7.StartInfo.FileName = "cmd";
            process7.StartInfo.RedirectStandardOutput = true;
            process7.StartInfo.UseShellExecute = false;
            process7.StartInfo.CreateNoWindow = true;
            process7.StartInfo.Arguments = "/C winget install Microsoft.VCRedist.2012.x86";
            labelInstalling.Text = "Visual C++ 2012 x86";
            process7.Start();
            process7.WaitForExit();

            System.Diagnostics.Process process8 = new Process();
            process8.StartInfo.FileName = "cmd";
            process8.StartInfo.RedirectStandardOutput = true;
            process8.StartInfo.UseShellExecute = false;
            process8.StartInfo.CreateNoWindow = true;
            process8.StartInfo.Arguments = "/C winget install Microsoft.VCRedist.2012.x64";
            labelInstalling.Text = "Visual C++ 2012 x64";
            process8.Start();
            process8.WaitForExit();

            System.Diagnostics.Process process9 = new Process();
            process9.StartInfo.FileName = "cmd";
            process9.StartInfo.RedirectStandardOutput = true;
            process9.StartInfo.UseShellExecute = false;
            process9.StartInfo.CreateNoWindow = true;
            process9.StartInfo.Arguments = "/C winget install Microsoft.VCRedist.2013.x86";
            labelInstalling.Text = "Visual C++ 2013 x86";
            process9.Start();
            process9.WaitForExit();

            System.Diagnostics.Process process10 = new Process();
            process10.StartInfo.FileName = "cmd";
            process10.StartInfo.RedirectStandardOutput = true;
            process10.StartInfo.UseShellExecute = false;
            process10.StartInfo.CreateNoWindow = true;
            process10.StartInfo.Arguments = "/C winget install Microsoft.VCRedist.2013.x64";
            labelInstalling.Text = "Visual C++ 2013 x64";
            process10.Start();
            process10.WaitForExit();

            System.Diagnostics.Process process12 = new Process();
            process12.StartInfo.FileName = "cmd";
            process12.StartInfo.RedirectStandardOutput = true;
            process12.StartInfo.UseShellExecute = false;
            process12.StartInfo.CreateNoWindow = true;
            process12.StartInfo.Arguments = "/C winget install Microsoft.VCRedist.2015+.x86";
            labelInstalling.Text = "Visual C++ 2015 - 2022 x86";
            process12.Start();
            process12.WaitForExit();

            System.Diagnostics.Process process13 = new Process();
            process13.StartInfo.FileName = "cmd";
            process13.StartInfo.RedirectStandardOutput = true;
            process13.StartInfo.UseShellExecute = false;
            process13.StartInfo.CreateNoWindow = true;
            process13.StartInfo.Arguments = "/C winget install Microsoft.VCRedist.2015+.x64";
            labelInstalling.Text = "Visual C++ 2015 - 2022 x64";
            process13.Start();
            process13.WaitForExit();

            labelInstalling.Text = "Instalação concluída";
            timerLabel.Start();
        }

        public bool IsInternetAvailable()
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    using (client.OpenRead("http://www.google.com/"))
                    {
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        public void InstalarWinget()
        {
            string installerUrl = "https://aka.ms/getwinget";
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "powershell",
                Arguments = $"-Command \"Invoke-WebRequest -Uri '{installerUrl}' -OutFile 'AppInstaller.msix'\"",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (Process process = Process.Start(startInfo))
            {
                process.WaitForExit();
                MessageBox.Show("Winget instalado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            startInfo.Arguments = "Add-AppxPackage AppInstaller.msix";
            using (Process process = Process.Start(startInfo))
            {
                process.WaitForExit();
                MessageBox.Show("Instalador de Aplicativo instalado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            DialogResult result = MessageBox.Show(
                "Reinicie seu computador para aplicar as mudanças \n\nDeseja reiniciar a máquina?",
                "Aviso",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information
            );

            if (result == DialogResult.Yes)
            {
                Process.Start("shutdown", "/r /t 0");
            }
        }


        private void main_Load(object sender, EventArgs e)
        { 
            
            if (IsWingetInstalled())
            {
                labelStatusAppInstaller.Text = "OK";
                labelStatusAppInstaller.BackColor = System.Drawing.Color.Green;
                labelStatusAppInstaller.ForeColor = System.Drawing.Color.White;
            }
            else
            {
                labelStatusAppInstaller.Text = "Não instalado";
                labelStatusAppInstaller.BackColor = System.Drawing.Color.Red;
                labelStatusAppInstaller.ForeColor = System.Drawing.Color.White;
            }

            if (IsInternetAvailable())
            {
                labelStatusNet.Text = "OK";
                labelStatusNet.BackColor = System.Drawing.Color.Green;
                labelStatusNet.ForeColor = System.Drawing.Color.White;
            }
            else
            {
                labelStatusNet.Text = "Não conectado";
                labelStatusNet.BackColor = System.Drawing.Color.Red;
                labelStatusNet.ForeColor = System.Drawing.Color.White;
            }

            labelNowInstalling.Visible = false;
            labelInstalling.Visible = false;
        }

        private void timerLabel_Tick(object sender, EventArgs e)
        {
            labelInstalling.Visible = false;
            labelNowInstalling.Visible = false;
            timerLabel.Stop();
        }

        private void buttonInstall_Click(object sender, EventArgs e)
        {
            var actions = new Dictionary<string, Action>
            {
                { "Visual C++", () => InstalarVisualCpp() },
                { ".NET Framework", () => installProgramas(".NET Framework") },
                { "DirectX", () => installProgramas("DirectX") },
                { "Vulkan", () => installProgramas("Vulkan") },
                { "Java", () => installProgramas("Java") },

                { "Google Chrome", () => installProgramas("Google Chrome") },
                { "Brave", () => installProgramas("Brave") },
                { "OperaGX", () => installProgramas("OperaGX") },
                { "Mozilla Firefox", () => installProgramas("Mozilla Firefox") },

                { "Discord", () => installProgramas("Discord") },
                { "Steam", () => installProgramas("Steam") },
                { "Epic Games", () => installProgramas("Epic Games") },
                { "Battle.net", () => installProgramas("Battle.net") },
                { "Ubisoft Connect", () => installProgramas("Ubisoft Connect") },
                { "Spotify", () => installProgramas("Spotify") },
                { "WhatsApp Desktop", () => installProgramasSemWinget("WhatsApp Desktop") },
                { "Telegram", () => installProgramas("Telegram") },

                { "qBittorrent", () => installProgramas("qBittorrent") },
                { "Libre Office", () => installProgramas("Libre Office") },
                { "OBS Studio", () => installProgramas("OBS Studio") },
                { "7zip", () => installProgramas("7zip") },

                { "CPU-Z", () => installProgramas("CPU-Z") },
                { "GPU-Z", () => installProgramas("GPU-Z") },
                { "MSI Afterburner", () => installProgramas("MSI Afterburner") },
                { "HW Monitor", () => installProgramas("HW Monitor") },

                { "VS Code", () => installProgramas("VS Code") },
                { "Visual Studio", () => installProgramas("Visual Studio") },
                { "Notepad++", () => installProgramas("Notepad++") },
                { "Git", () => installProgramas("Git") },
                { "Node.JS", () => installProgramas("Node.JS") },
                { "Python", () => installProgramas("Python") },
                { "IntelliJ IDEA", () => installProgramas("IntelliJ IDEA") },
                { "PyCharm", () => installProgramas("PyCharm") },
                { "MySQL", () => installProgramas("MySQL") },

                { "League of Legends", () => installProgramas("League of Legends") },
                { "Valorant", () => installProgramas("Valorant") },
                { "Minecraft", () => installProgramas("Minecraft") },
                { "osu!", () => installProgramas("osu!") },
                { "Clone Hero", () => installProgramas("Clone Hero") },
                { "Hydra Launcher", () => installProgramas("Hydra Launcher") }
            };

            foreach (var checkbox in checkboxes)
            {
                if (checkbox.Checked && actions.ContainsKey(checkbox.Text))
                {
                    actions[checkbox.Text].Invoke();
                }
            }
        }
    }
}
