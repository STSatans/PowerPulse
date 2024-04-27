using SharpCompress.Archives;
using SharpCompress.Common;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;
using Application = System.Windows.Forms.Application;
using MessageBox = System.Windows.Forms.MessageBox;

namespace PowerPulse
{
    public partial class Login : Form
    {
        //connection string
        private readonly string con = ConfigurationManager.ConnectionStrings["PowerPulse"].ConnectionString;

        public Login()
        {
            InitializeComponent();
        }

        //enumerador para definir os estados de Login
        private enum LoginResult
        {
            Success,
            InvalidUserID,
            InvalidPassword
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                int userID = Convert.ToInt32(txtUser.Text);

                string password = txtPass.Text;

                LoginResult loginResult = CheckLogin(userID, password);

                //switch case para verificar o resultado do login
                switch (loginResult)
                {
                    case LoginResult.Success:
                        Main main = new Main
                        {
                            User = userID
                        };
                        main.Show();
                        this.Hide();

                        break;

                    case LoginResult.InvalidUserID:

                        panel7.Visible = true;
                        break;

                    case LoginResult.InvalidPassword:

                        panel9.Visible = true;
                        break;
                }
            }
            catch (Exception ex)
            {
                //Mensagen de Excessao
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLogin_MouseEnter(object sender, EventArgs e)
        {
            btnLogin.ForeColor = Color.Black;
        }

        private void btnLogin_MouseLeave(object sender, EventArgs e)
        {
            btnLogin.ForeColor = Color.Lime;
        }

        private void btnMax_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Maximized;
            else
                WindowState = FormWindowState.Normal;
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Minimized;
            else
                WindowState = FormWindowState.Normal;
        }

        //funcao para verificar os dados de Login
        private LoginResult CheckLogin(int userID, string password)
        {
            using (SqlConnection connection = new SqlConnection(con))
            {
                string query = "SELECT Password FROM Login WHERE ID = @UserID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserID", userID);

                    connection.Open();
                    object result = command.ExecuteScalar();
                    connection.Close();

                    if (result != null)
                    {
                        string dbPassword = result.ToString();
                        if (dbPassword == password)
                        {
                            return LoginResult.Success;
                        }
                        else
                        {
                            return LoginResult.InvalidPassword;
                        }
                    }
                    else
                    {
                        return LoginResult.InvalidUserID;
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //string owner = "STSatans";
            //string repoName = "PowerPulse";
            //string latestReleaseUrl = $"https://api.github.com/repos/{owner}/{repoName}/releases/latest";

            //string appDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
            //string updateDirectory = Path.Combine(appDirectory, "Release");

            //using (var client = new WebClient())
            //{
            //    client.Headers.Add("User-Agent", "request");

            //    // Get the latest release information
            //    string json = client.DownloadString(latestReleaseUrl);
            //    dynamic latestRelease = Newtonsoft.Json.JsonConvert.DeserializeObject(json);

            //    // Get the latest version
            //    string latestVersion = latestRelease.tag_name;

            //    // Check if the latest version is different from the current version
            //    string currentVersion = Properties.Settings.Default.version;
            //    if (latestVersion != currentVersion)
            //    {
            //        MessageBox.Show($"New version available: {latestVersion}", "Update Available", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //        // Download the release RAR file
            //        string downloadUrl = latestRelease.assets[0].browser_download_url;
            //        string rarFile = Path.Combine(appDirectory, "Release.rar");
            //        client.DownloadFile(downloadUrl, rarFile);

            //        using (var archive = ArchiveFactory.Open(rarFile))
            //        {
            //            foreach (var entry in archive.Entries)
            //            {
            //                if (!entry.IsDirectory)
            //                {
            //                    entry.WriteToDirectory(updateDirectory, new ExtractionOptions()
            //                    {
            //                        ExtractFullPath = true,
            //                        Overwrite = true
            //                    });
            //                }
            //            }
            //        }

            //        // Restart the application
            //        MessageBox.Show("Restarting the application...", "Restarting", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        Properties.Settings.Default.version = "1.2";
            //        Properties.Settings.Default.Save(); // Save changes
            //        Application.Restart();
            //    }
            //    else
            //    {
            //        MessageBox.Show("Application is up to date.", "Up to Date", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //}
        }


        private void panel2_Paint(object sender, PaintEventArgs e)
        {
        }

        private void txtpass_Click(object sender, EventArgs e)
        {
            txtPass.SelectAll();
        }

        private void txtpass_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtPass.ForeColor = Color.White;
                if (txtPass.Text == "")
                {
                    txtPass.Text = "Password";
                    return;
                }
            }
            catch
            { }
        }

        private void txtUser_Click(object sender, EventArgs e)
        {
            txtUser.SelectAll();
        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtUser.ForeColor = Color.White;
                if (txtUser.Text == "")
                {
                    txtUser.Text = "Enter Username";
                    return;
                }
            }
            catch
            { }
        }
    }
}