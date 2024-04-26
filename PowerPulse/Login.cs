using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Application = System.Windows.Forms.Application;
using MessageBox = System.Windows.Forms.MessageBox;

namespace PowerPulse
{
    public partial class Login : Form
    {
        private readonly GitHubAutoUpdater _updater;

        //connection string
        private readonly string con = ConfigurationManager.ConnectionStrings["PowerPulse"].ConnectionString;

        public Login()
        {
            InitializeComponent();

            // Initialize GitHubAutoUpdater with your credentials
            string accessToken = "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";
            string owner = "STSatans";
            string repoName = "PowerPulse";

            _updater = new GitHubAutoUpdater(accessToken, owner, repoName);
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
        private async Task CheckAndUpdate()
        {
            string currentVersion = "1.0"; // Replace with actual current version
            bool hasUpdates = await _updater.CheckForUpdates(currentVersion);

            if (hasUpdates)
            {
                // Inform the user about available updates
                var result = MessageBox.Show("An update is available. Do you want to download and install it?", "Update Available", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    // Download update
                    string downloadPath = Path.Combine(Path.GetTempPath(), "update.zip");
                    string releaseTag = "latest"; // Replace with the release tag of the update
                    bool downloadSuccess = await _updater.DownloadUpdate(releaseTag, downloadPath);

                    if (downloadSuccess)
                    {
                        // Extract and apply the update
                        _updater.ExtractUpdate(downloadPath, Application.StartupPath);

                        // Inform the user about successful update
                        MessageBox.Show("Update installed successfully. Please restart the application.", "Update Installed", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Close the application to apply the update
                        Application.Exit();
                    }
                    else
                    {
                        MessageBox.Show("Failed to download the update. Please try again later.", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("No updates available.", "No Updates", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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

        private async void Form1_Load(object sender, EventArgs e)
        {
            // Check for updates when the form loads
            await CheckAndUpdate();
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