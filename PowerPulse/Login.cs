using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Reflection;
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

        private void CheckForUpdates()
        {
            try
            {
                // GitHub repository information
                string owner = "STSatans";
                string repo = "PowerPulse";

                // Fetch the latest release from GitHub
                string apiUrl = $"https://api.github.com/repos/{owner}/{repo}/releases/latest";
                string json;

                // Download release information from GitHub
                using (WebClient client = new WebClient())
                {
                    client.Headers.Add("User-Agent", "request");
                    json = client.DownloadString(apiUrl);
                }

                // Get the directory of PowerPulse.exe
                string powerPulseDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

                // Navigate to the "Updater" folder relative to PowerPulse.exe
                string updaterDirectory = Path.Combine(powerPulseDirectory, "Updater");
                string updaterPath = Path.Combine(updaterDirectory, "PowerPulseUpdater.exe");

                // Deserialize the JSON response from GitHub
                dynamic release = JsonConvert.DeserializeObject(json);
                string latestVersion = release.tag_name;

                // Compare versions
                Version currentVersion = new Version(Application.ProductVersion);
                Version latest = new Version(latestVersion);

                if (latest > currentVersion)
                {
                    // Prompt user to update
                    DialogResult result = MessageBox.Show("An update is available. Do you want to update now?", "Update Available", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (result == DialogResult.Yes)
                    {
                        // Close the current application
                        Close();

                        // Run the updater
                        Process.Start(updaterPath);
                    }
                }
                else
                {
                    // No updates available
                    MessageBox.Show("No updates available.", "No Updates", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (WebException ex)
            {
                MessageBox.Show($"Error accessing GitHub API: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (JsonException ex)
            {
                MessageBox.Show($"Error parsing JSON response: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            CheckForUpdates();
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