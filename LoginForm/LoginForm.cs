using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginForm
{
    public partial class LoginForm : Form
    {

        Dictionary<string, string> users = new Dictionary<string, string>();


        public LoginForm()
        {
            InitializeComponent();
            users.Add("admin1", "12341");
            users.Add("admin2", "12342");

            

            

        }

        private void usernameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void signinButton_Click(object sender, EventArgs e)
        {
            // Check if password or username textbox is empty(null)

            if(String.IsNullOrEmpty(usernameTextBox.Text) || String.IsNullOrEmpty(passwordTextBox.Text)) 
            {
                MessageBox.Show("Wrong username or password!");
            }

            // Check the authentication
            string result;

            // Try to get the value of the given username
            if(users.TryGetValue(usernameTextBox.Text, out result))
            {
                if(passwordTextBox.Text == result)
                {
                    SuccessForm successfrm = new SuccessForm(usernameTextBox.Text, passwordTextBox.Text);
                    successfrm.Show();
                    this.Hide(); // Hide LogIn form
                }
                else
                {
                    MessageBox.Show("Failed to authenticate. Please try again!");
                    usernameTextBox.Clear();
                    passwordTextBox.Clear();
                }
            }


            //for(int i=0; i<users.Count; i++)
            //{
            //    if(users.ElementAt(i).Key == usernameTextBox.Text && users.ElementAt(i).Value == passwordTextBox.Text) 
            //    {
            //        SuccessForm successfrm = new SuccessForm(usernameTextBox.Text, passwordTextBox.Text);
            //        successfrm.Show();
            //        this.Hide(); // Hide LogIn form
            //        break; // Break the loop if found the right data
            //    }
            //    else
            //    {
            //        MessageBox.Show("failed to authenticate.");
            //        usernameTextBox.Clear();
            //        passwordTextBox.Clear();
                    
            //        i = 0;
            //        break;
                    
            //    }
                
            //}

        }
    }
}
