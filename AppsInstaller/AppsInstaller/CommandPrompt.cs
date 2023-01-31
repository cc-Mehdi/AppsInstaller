using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppsInstaller
{
    public class CommandPrompt
    {
        private static System.Diagnostics.Process cmd;

        //config cmd settings and ready cmd variable for run commands
        private void configCMD()
        {
            cmd = new System.Diagnostics.Process();
            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.UseShellExecute = false;
            cmd.Start();
        }

        //run commands in cmd
        private void run(string command)
        {
            configCMD();
            cmd.StandardInput.WriteLine(command);
            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();
            cmd.WaitForExit();
        }

        //find cpu architecture
        private int findCpuArchitecture()
        {
            //fill cmd variable for find cpu architecture
            run("wmic OS get OSArchitecture");

            char[] ch = cmd.StandardOutput.ReadToEnd().ToString().ToCharArray();
            for (int i = ch.Length - 1; i >= 0; i--)
            {
                if (ch[i] == '4' && ch[i - 1] == '6' && ch[i - 2] == '\n' && ch[i - 3] == '\r')
                    return 64;
                else if (ch[i] == '6' && ch[i - 1] == '8' && ch[i - 2] == '\n' && ch[i - 3] == '\r')
                    return 86;
            }
            return 0;
        }

        //find system username from user's pc
        private string findSystemUserName()
        {
            return System.Security.Principal.WindowsIdentity.GetCurrent().Name.Split('\\')[1];
        }

        //Start install process.
        public void install(string appName)
        {
            int cpuStructure = findCpuArchitecture();
            //set app address with cpu architecture
            string appAddress = Application.StartupPath + $"Prerequisites\\{cpuStructure}-bit";
            run($"cd {(appAddress)} && {appName}.exe /s");
            //loadingAnimation("C:/Users/xmehd/AppData/Local/Programs/Python");
        }

        //Check install process is finished or not.
        public bool isInstallComplete(string appName)
        {
            run($"tasklist /fi \"imagename eq {appName}.exe\"");
            char[] ch = cmd.StandardOutput.ReadToEnd().ToString().ToCharArray();

            //if result have 'INFO' word its mean install process is end.
            for (int i = 0; i <= ch.Length - 4; i++)
                if (ch[i] == 'I' && ch[i + 1] == 'N' && ch[i + 2] == 'F' && ch[i + 3] == 'O')
                    return true;

            return false;
        }

        //Create a shortcut of program after complete install.
        public void createShortcut(string appName, string appLocation)
        {
            string completeAppAddress = $"{appLocation}python\\Python311\\{appName}.exe";
            while (!System.IO.File.Exists(fixAddress(completeAppAddress)))
                Thread.Sleep(1000);
            run($"copy {completeAppAddress} C:\\Users\\{findSystemUserName()}\\OneDrive\\Desktop");
            string s = cmd.StandardOutput.ReadToEnd();
        }

        //Remove Double Qute from address
        private string fixAddress(string address)
        {
            string result = "";
            foreach (var item in address.Split('"'))
                result += item;
            return result;
        }

        //Move root program folder to custom location that user selected.
        public void changeFileLocation(string oldLocation, string newLocation)
        {
            run($"move {oldLocation} {newLocation}");
        }

        //Complete install process.
        public void installProcess(string appName, string installLocation, bool shortcut)
        {
            changeFileLocation($"C:/Users/\"{findSystemUserName()}\"/AppData/Local/Programs/\"{appName}\"", installLocation);
            if (shortcut)
                createShortcut(appName, installLocation);
        }
    }
}
