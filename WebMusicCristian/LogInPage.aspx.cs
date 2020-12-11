using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace WebMusicCristian
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if((TextBox1.Text == "" && TextBox3.Text == "") || TextBox4.Text == "")
            {
                Label1.Text = ("Please fill either Email or Username, along with the password of the account");
                return;
            }
            SqlConnection musicDB = new SqlConnection("Server=tcp:cristian-music-server.database.windows.net,1433;Initial Catalog=CristianMusicDB;Persist Security Info=False;User ID=Nijacool;Password=Ahirunosora200;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            {
                
                SqlCommand Check_User = new SqlCommand();
                Check_User.Connection = musicDB;

                SqlCommand checkerDB = new SqlCommand();
                checkerDB.Connection = musicDB;
                

                int situation = 0;

                if(TextBox1.Text == ""){situation = 1;} //only email
                if(TextBox3.Text == ""){ situation = 2; } // only username

                switch (situation)
                {
                    case (1)://only email
                        checkerDB.CommandText = ("SELECT COUNT(*) FROM UserProfile WHERE (Email = @email)");
                        Check_User.CommandText = ("SELECT User_Id, Pwd, Subscription From UserProfile WHERE (Email = @email)");
                        checkerDB.Parameters.AddWithValue("@email", TextBox3.Text);
                        Check_User.Parameters.AddWithValue("@email", TextBox3.Text);
                        break;
                    case (2): //only username
                        checkerDB.CommandText = ("SELECT COUNT(*) FROM UserProfile WHERE (User_Name = @user)");
                        Check_User.CommandText = ("SELECT User_Id, Pwd, Subscription From UserProfile WHERE (User_Name = @user)");
                        checkerDB.Parameters.AddWithValue("@user", TextBox1.Text);
                        Check_User.Parameters.AddWithValue("@user", TextBox1.Text);
                        break;
                    case (0):
                        checkerDB.CommandText = ("SELECT COUNT(*) FROM UserProfile WHERE (Email = @email AND User_Name = @user)");
                        Check_User.CommandText = ("SELECT User_Id, Pwd, Subscription From UserProfile WHERE (Email = @email AND User_Name = @user)");
                        checkerDB.Parameters.AddWithValue("@email", TextBox3.Text);
                        checkerDB.Parameters.AddWithValue("@user", TextBox1.Text);
                        Check_User.Parameters.AddWithValue("@email", TextBox3.Text);
                        Check_User.Parameters.AddWithValue("@user", TextBox1.Text);
                        break;
                }

                musicDB.Open();
                int tester = (int)checkerDB.ExecuteScalar();
                if(tester <= 0)
                {
                    Label1.Text = "Invalid Username/Email: "+ situation;
                }
                else
                {
                    SqlDataReader rm = Check_User.ExecuteReader();
                    int userId = 0;
                    int userS = 0;
                    String userPsw = "";
                    if (rm.HasRows)
                    {
                        while (rm.Read())
                        {
                            // rm[0] is id rm[1] is psw
                            userId = (int)rm[0];
                            userPsw = (String)rm[1];
                            userS = (int)rm[2];
                            break;
                        }
                    }
                    rm.Close();

                    if (userPsw.Equals(TextBox4.Text))
                    {
                        Label1.Text = "Welcome";
                        musicDB.Close();
                        string url = "WebForm3.aspx?name=" + TextBox1.Text + "&id=" + userId + "&s=" + userS;
                        Response.Redirect(url);
                    }
                    else
                    {
                        Label1.Text = "Incorrect Password";
                    }
                }
                musicDB.Close();
                TextBox1.Text = "";
                TextBox3.Text = "";
                TextBox4.Text = "";

            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebForm1.aspx");
        }

        
    }
}