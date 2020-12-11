using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Web.Services;

namespace CristianMusicDB
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == true) { Label1.Text = ("Insertion Process: Sucessful"); }
        }

        //[WebMethod]
        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection musicDB = new SqlConnection("Server=tcp:cristian-music-server.database.windows.net,1433;Initial Catalog=CristianMusicDB;Persist Security Info=False;User ID=Nijacool;Password=Ahirunosora200;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            {

                SqlCommand CreateUser = new SqlCommand("EXEC dbo.CreateUser @Username, @Email, @Country, @Subscription, @Password", musicDB);

                String pattern = @"[a-zA-Z0-9!@#$%&]";
                RegexOptions options = RegexOptions.Multiline;
                bool status = Regex.IsMatch(TextBox1.Text, pattern, options);

                SqlCommand check_User_Name = new SqlCommand("SELECT COUNT(*) FROM UserProfile WHERE (User_Name = @user)", musicDB);
                SqlCommand check_User_Email = new SqlCommand("SELECT COUNT(*) FROM UserProfile WHERE (Email = @email)", musicDB);
                check_User_Name.Parameters.AddWithValue("@user", TextBox1.Text);
                check_User_Email.Parameters.AddWithValue("@email", TextBox2.Text);
                CreateUser.Parameters.AddWithValue("@UserName", TextBox1.Text);
                CreateUser.Parameters.AddWithValue("@Email", TextBox2.Text);
                CreateUser.Parameters.AddWithValue("@Password", TextBox3.Text);
                CreateUser.Parameters.AddWithValue("@Country", DropDownList1.SelectedValue);
                if (DropDownList2.SelectedValue == "Premium")
                {
                    CreateUser.Parameters.AddWithValue("@Subscription", 2);
                }
                else
                {
                    CreateUser.Parameters.AddWithValue("@Subscription", 1);
                }
                musicDB.Open();
                int switchCase = 0;
                int UserExist = (int)check_User_Name.ExecuteScalar();
                int UserExist2 = (int)check_User_Email.ExecuteScalar();
                if(UserExist > 0) { switchCase = 1; }
                if(UserExist2 > 0) { switchCase = 2; }
                switch (switchCase){
                    case 1:
                        //Username exist
                        Label2.Text = "The User Name is Already Taken";
                        break;
                    case 2:
                        //Email Exist
                        Label2.Text = "This Email is already link with an Account, Please Log in or use a different Email";
                        break;
                    default:
                        Label2.Text = "";
                        CreateUser.ExecuteNonQuery();
                        break;
                }              
                musicDB.Close();
                if (IsPostBack)
                {
                    //CheckBox1.Checked = false;
                    TextBox1.Text = "";
                    TextBox2.Text = "";
                    TextBox3.Text = "";
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("LogInPage.aspx");
        }
    }
}