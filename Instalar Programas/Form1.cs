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

namespace Instalar_Programas
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
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

        public bool IsInternetAvailable()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("https://winstall.app"))
                {
                    return true;
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
        }
    }
}
