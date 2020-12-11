using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.Script.Services;

namespace WebMusicCristian
{

    public partial class WebForm3 : System.Web.UI.Page
    {
        
        String table = "";
        String table2 = "";
        static class Information
        {
            public static String finalTable = "";
            public static String currentTable = "";
            public static List<ListItem> globalDropdown = new List<ListItem>(); 
            //public static Dictionary<String, String> finalTable = new Dictionary<String, String>();
            public static List<String> ArtistCollection = new List<String>();
            public static List<String> SongCollection = new List<String>();
            public static List<int> SongIDCollection = new List<int>();
            public static String globalCheck = "";
            public static String SubscriptionAccount = "";
        }

        //private String songInPlaylist;

        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = Request.QueryString["name"];
            Information.SubscriptionAccount = Request.QueryString["s"];
            if(Information.SubscriptionAccount == "2")
            {
                Label10.Text = "Premium Account";
            }
            if (!Page.IsPostBack)
            {
                TextBox1.Style.Add("display", "none");
                Button4.Visible = false;
                Button4.Enabled = false;

                if (Information.SubscriptionAccount == "2")
                {
                    //Button8.Enabled = false;
                    Button8.Text = "Cancel Premium Subscription";
                }
                else
                {
                    Button8.Text = "Upgrade to Premium";
                }

                StringBuilder temp = new StringBuilder();
                temp.Append("<table border = '1'>");
                temp.Append("<tr><th> Songs </th><th> Artists </th><th>ID</th>");
                temp.Append("</tr>");

                StringBuilder SongTable = new StringBuilder();
                SongTable.Append("<table border = '1'>");
                SongTable.Append("<tr><th> Songs </th><th> Artist </th><th>ID</th>");
                SongTable.Append("</tr>");


                SqlConnection musicDB = new SqlConnection("Server=tcp:cristian-music-server.database.windows.net,1433;Initial Catalog=CristianMusicDB;Persist Security Info=False;User ID=Nijacool;Password=Ahirunosora200;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
                musicDB.Open();

                SqlCommand cmd = new SqlCommand();
                //cmd.CommandText = "SELECT Playlist_Name, Playlist_Id FROM PlaylistTbl WHERE (Created_By = " + Request.QueryString["id"]+")";
                cmd.CommandText = "SELECT DISTINCT Playlist_Name FROM PlaylistTbl WHERE (Created_By = " + Request.QueryString["id"] + ")";
                cmd.Connection = musicDB;
                SqlDataReader rd = cmd.ExecuteReader();
                SqlCommand displaySongsId = new SqlCommand();


                List<String> songNames = new List<string>();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        songNames.Add((String)rd[0]);
                    }
                }
                rd.Close();
                List<int> songIdVariable = new List<int>();


                SqlCommand cmd2 = new SqlCommand();
                cmd2.Connection = musicDB;
                cmd2.CommandText = "SELECT DISTINCT Playlist_Id FROM PlaylistTbl WHERE (Created_By = " + Request.QueryString["id"] + ")";
                SqlDataReader rd2 = cmd2.ExecuteReader();
                if (rd2.HasRows)
                {
                    while (rd2.Read())
                    {
                        songIdVariable.Add((int)rd2[0]);
                    }
                }
                rd2.Close();
                displaySongsId.Connection = musicDB;
                DropDownList2.Items.Add("");
                DropDownList1.Items.Add("");
                DropDownList2.Items.Add("New Playlist");
                int counterDrop = 0;
                for(int i = 0; i < songIdVariable.Count; i++)
                {
                    //DropDownList1.Items.Add((String)rd[0]);
                    //DropDownList2.Items.Add((String)rd[0]);
                    String Key = songNames[i];
                    int Value = songIdVariable[i];
                    ListItem first = new ListItem(Key, Value.ToString());
                    //DropDownList1.Items.Insert(counterDrop, first);

                    DropDownList1.Items.Add(first);

                    DropDownList2.Items.Add(first);
                    Information.globalDropdown.Add(first);
                    counterDrop += 1;
                }

                SqlCommand AllSongs2 = new SqlCommand();
                AllSongs2.Connection = musicDB;
                AllSongs2.CommandText = "SELECT Artist_Name, Artist_Id FROM ProfileArtist";
                SqlDataReader all2 = AllSongs2.ExecuteReader();
                Dictionary<int, String> ArtistList = new Dictionary<int, String>();
                if (all2.HasRows)
                {
                    while (all2.Read())
                    {
                        ArtistList.Add((int)all2[1], (String)all2[0]);
                    }
                }
                all2.Close();

                SqlCommand AllSongs = new SqlCommand();
                AllSongs.Connection = musicDB;
                AllSongs.CommandText = "SELECT Song_Name, Artist_Id, Song_Id FROM Song";
                SqlDataReader all = AllSongs.ExecuteReader();
                if (all.HasRows)
                {
                    while (all.Read())
                    {
                        SongTable.Append("<td>" + all[0] + "</td>");
                        SongTable.Append("<td>" + ArtistList[(int)all[1]] + "</td>");
                        SongTable.Append("<td>" + all[2] + "</td>");
                        Information.ArtistCollection.Add((String)ArtistList[(int)all[1]]);
                        Information.SongCollection.Add((String)all[0]);
                        Information.SongIDCollection.Add((int)all[2]);
                        SongTable.Append("</tr>");
                    }
                }
                SongTable.Append("</table>");

                table2 = SongTable.ToString();

                PlaceHolder2.Controls.Add(new Literal { Text = table2 });
                Information.finalTable = table2;
                all.Close();
                musicDB.Close();

            }
        }
        
        [WebMethod(EnableSession = true)]
        public static void Done(string ids)
        {
            //String a = ids;
            Information.globalCheck = ids;


            // Do whatever processing you want
        }

        [WebMethod()]
        [ScriptMethod()]
        protected void Button1_Click(object sender, EventArgs e)
        {

            SqlConnection musicDB = new SqlConnection("Server=tcp:cristian-music-server.database.windows.net,1433;Initial Catalog=CristianMusicDB;Persist Security Info=False;User ID=Nijacool;Password=Ahirunosora200;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            musicDB.Open();

            String variable = hdnfldVariable.Value;

            StringBuilder brand = new StringBuilder();
            brand.Append("<table border = '1'>");
            brand.Append("<tr><th> Songs</th><th>Artist</th><th>ID</th>");
            brand.Append("</tr>");
            for (int i = 0; i < Information.ArtistCollection.Count; i++)
            {
                brand.Append("<tr>");
                brand.Append("<td>" + Information.SongCollection[i] + "</td>");
                brand.Append("<td>" + Information.ArtistCollection[i] + "</td>");
                brand.Append("<td>" + Information.SongIDCollection[i] + "</td>");
                brand.Append("</tr>");
            }
            brand.Append("</table>");
            //PlaceHolder2.Controls.Add(new Literal { Text = brand.ToString() });
            String input = TextBox5.Text;
            //ADD PROFANITY LIST OF BAN
            if (input == "" || input.Length > 20)
            {
                Label7.Text = ("Playlist Name can not be empty, and it can not contain more than 20 characters");
                PlaceHolder2.Controls.Add(new Literal { Text = Information.finalTable });
                PlaceHolder3.Controls.Add(new Literal { Text = Information.currentTable });
                musicDB.Close();
                return;
            }
            else
            {

            }
            String Current = "Inside is: " + TextBox1.Text;
            Label7.Text = Current;

            String content = TextBox5.Text;
            SqlCommand songPlaylist = new SqlCommand("EXEC dbo.AddInPlaylist @PlaylistID, @Song_Id, @Playlist_Name, @Created_By", musicDB);

            SqlCommand playlist_Id = new SqlCommand();
            SqlCommand Creeated = new SqlCommand();
            
            String boxText = "";
            int number1 = 0;
            bool canConvert = int.TryParse(TextBox5.Text, out number1);
            if (canConvert)
            {
                boxText = TextBox5.Text;
            }
            else
            {
                Label9.Text = ("You have to real numbers");
                TextBox5.Text = ("");
                PlaceHolder2.Controls.Add(new Literal { Text = Information.finalTable });
                PlaceHolder3.Controls.Add(new Literal { Text = Information.currentTable });
                musicDB.Close();
                return;
            }

            
            SqlCommand SongExist = new SqlCommand("SELECT COUNT(1) FROM Song WHERE Song_Id = " + boxText , musicDB);
            playlist_Id.Connection = musicDB;
            Creeated.Connection = musicDB;
            playlist_Id.CommandText = ("SELECT DISTINCT Playlist_Id FROM PlaylistTbl WHERE (Playlist_Name = '" + DropDownList2.SelectedItem.Text + "')");
            Creeated.CommandText = ("SELECT DISTINCT Created_By FROM PlaylistTbl WHERE (Playlist_Name = '" + DropDownList2.SelectedItem.Text + "')");


            int playlistSelected = 0;
            int User_Selected = 0;
            int songEx = 0;
            try
            {
                playlistSelected = (int)playlist_Id.ExecuteScalar();
                User_Selected = (int)Creeated.ExecuteScalar();
                songEx = (int)SongExist.ExecuteScalar();
            }
            catch (NullReferenceException)
            {
                brand.Append("<tr>");
                brand.Append("<td>Not Found</td>");
                brand.Append("<td>Not Found</td>");
                brand.Append("<td>Not Found</td>");
                brand.Append("</tr>");
                PlaceHolder2.Controls.Add(new Literal { Text = Information.finalTable });
                PlaceHolder3.Controls.Add(new Literal { Text = Information.currentTable });
                musicDB.Close();
                return;
            }

            String value = boxText;
            SqlCommand compare = new SqlCommand("SELECT COUNT(1) FROM PlaylistTbl WHERE (Playlist_Id = " + playlistSelected + " AND Song_Id = " + value + ")", musicDB); ;
            int repeated = 0;
            try
            {
                repeated = (int)compare.ExecuteScalar();
            }
            catch (NullReferenceException)
            {
                repeated = 1;
            }
            int trouble = 0;
            if (songEx <= 0) { trouble = 1; }
            if (repeated != 0) { trouble = 2; }

            switch (trouble)
            {
                case 1:
                    Label9.Text = ("Song does not exist in the database");

                    break;
                case 2:
                    Label9.Text = ("Song already exists in the playlist");
                    break;
                default:
                    songPlaylist.Parameters.AddWithValue("@PlaylistId", playlistSelected);
                    songPlaylist.Parameters.AddWithValue("@Song_Id", boxText);
                    songPlaylist.Parameters.AddWithValue("@Playlist_Name", DropDownList2.SelectedItem.Text);
                    songPlaylist.Parameters.AddWithValue("@Created_By", User_Selected);
                    int status = songPlaylist.ExecuteNonQuery();

                    if (status == 0)
                    {
                        Response.Write("<script>alert('Song Failed to be added on Playlist, check your inputs');</script>");
                    }
                    else
                    {
                        Label9.Text = ("Successfully added to your playlist");

                    }
                    break;
            }            
            //On Error, throw exception that triggers Text Input
            TextBox5.Text = ("");
            PlaceHolder2.Controls.Add(new Literal { Text = Information.finalTable });
            PlaceHolder3.Controls.Add(new Literal { Text = Information.currentTable });
            musicDB.Close();

        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            SqlConnection musicDB = new SqlConnection("Server=tcp:cristian-music-server.database.windows.net,1433;Initial Catalog=CristianMusicDB;Persist Security Info=False;User ID=Nijacool;Password=Ahirunosora200;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            musicDB.Open();
            //PlaceHolder2.Controls.Add(new Literal { Text = Information.finalTable });
            if(DropDownList2.SelectedItem.Text == "")
            {
                Label9.Text = ("No Playlist was Selected");
                PlaceHolder2.Controls.Add(new Literal { Text = Information.finalTable });
                PlaceHolder3.Controls.Add(new Literal { Text = Information.currentTable });
                musicDB.Close();
                return;
            }
            if(TextBox5.Text == "")
            {
                Label9.Text = ("No Song was selected");
                PlaceHolder2.Controls.Add(new Literal { Text = Information.finalTable });
                PlaceHolder3.Controls.Add(new Literal { Text = Information.currentTable });
                musicDB.Close();
                return;
            }

            StringBuilder brand = new StringBuilder();
            brand.Append("<table border = '1'>");
            brand.Append("<tr><th> Songs</th><th>Artist</th><th>ID</th>");
            brand.Append("</tr>");
            for (int i = 0; i < Information.ArtistCollection.Count; i++)
            {
                brand.Append("<tr>");
                brand.Append("<td>" + Information.SongCollection[i] + "</td>");
                brand.Append("<td>" + Information.ArtistCollection[i] + "</td>");
                brand.Append("<td>" + Information.SongIDCollection[i] + "</td>");
                brand.Append("</tr>");
            }
            brand.Append("</table>");
            //PlaceHolder2.Controls.Add(new Literal { Text = brand.ToString() });
            
            String Current = "Inside is: " + TextBox1.Text;
            Label7.Text = Current;

            
            String boxText = "";
            int number1 = 0;
            bool canConvert = int.TryParse(TextBox5.Text, out number1);
            if (canConvert)
            {
                boxText = TextBox5.Text;
            }
            else
            {
                Label9.Text = ("You have to real numbers");
                TextBox5.Text = ("");
                musicDB.Close();
                PlaceHolder2.Controls.Add(new Literal { Text = Information.finalTable });
                PlaceHolder3.Controls.Add(new Literal { Text = Information.currentTable });
                musicDB.Close();
                return;
            }



            SqlCommand playlist_Id = new SqlCommand();
            SqlCommand Creeated = new SqlCommand();
            SqlCommand SongExist = new SqlCommand("SELECT COUNT(1) FROM Song WHERE Song_Id = " + boxText, musicDB);
            SqlCommand playNumber = new SqlCommand("SELECT COUNT(*) FROM Song WHERE Song_Id = " + boxText, musicDB);
            int songLeft = (int)playNumber.ExecuteScalar();
            playlist_Id.Connection = musicDB;
            Creeated.Connection = musicDB;
            playlist_Id.CommandText = ("SELECT DISTINCT Playlist_Id FROM PlaylistTbl WHERE (Playlist_Name = '" + DropDownList2.SelectedItem.Text + "')");
            Creeated.CommandText = ("SELECT DISTINCT Created_By FROM PlaylistTbl WHERE (Playlist_Name = '" + DropDownList2.SelectedItem.Text + "')");


            int playlistSelected = 0;
            int User_Selected = 0;
            int songEx = 0;
            try
            {
                playlistSelected = (int)playlist_Id.ExecuteScalar();
                User_Selected = (int)Creeated.ExecuteScalar();
                songEx = (int)SongExist.ExecuteScalar();
            }
            catch (NullReferenceException)
            {
                brand.Append("<tr>");
                brand.Append("<td>Not Found</td>");
                brand.Append("<td>Not Found</td>");
                brand.Append("<td>Not Found</td>");
                brand.Append("</tr>");
                PlaceHolder2.Controls.Add(new Literal { Text = Information.finalTable });
                PlaceHolder3.Controls.Add(new Literal { Text = Information.currentTable });
                musicDB.Close();
                return;
            }

            String value = boxText;
            SqlCommand compare = new SqlCommand("SELECT COUNT(1) FROM PlaylistTbl WHERE (Playlist_Id = " + playlistSelected + " AND Song_Id = " + value + ")", musicDB); ;
            int repeated = 0;
            try
            {
                repeated = (int)compare.ExecuteScalar();
            }
            catch (NullReferenceException)
            {
                repeated = 1;
            }
            int trouble = 0;
            if (songEx <= 0) { trouble = 1; }
            switch (trouble)
            {
                case 1:
                    Label9.Text = ("Song does not exist in the database");
                    break;
                default:
                    SqlCommand deleteSong = new SqlCommand("DELETE FROM PlaylistTbl WHERE (Playlist_Id = " + playlistSelected + " AND Song_id = " + boxText + ")", musicDB);
                    int status = deleteSong.ExecuteNonQuery();

                    if (status == 0)
                    {
                        //Response.Write("<script>alert('Song Failed to be deleted from Playlist, check your inputs');</script>");
                        Label9.Text = ("Song is not in the playlist");
                    }
                    else
                    {
                        Label9.Text = ("Successfully deleted song from your playlist");
                        if(songLeft == 1)
                        {
                            DropDownList1.Items.Remove(DropDownList2.SelectedItem);
                            DropDownList2.Items.Remove(DropDownList2.SelectedItem);
                        }

                    }

                    break;
            }
            TextBox5.Text = ("");
            musicDB.Close();
            PlaceHolder2.Controls.Add(new Literal { Text = Information.finalTable });
            PlaceHolder3.Controls.Add(new Literal { Text = Information.currentTable });
        }
        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection musicDB = new SqlConnection("Server=tcp:cristian-music-server.database.windows.net,1433;Initial Catalog=CristianMusicDB;Persist Security Info=False;User ID=Nijacool;Password=Ahirunosora200;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            musicDB.Open();
            PlaceHolder2.Controls.Add(new Literal { Text = Information.finalTable });
            PlaceHolder3.Controls.Add(new Literal { Text = Information.currentTable });
            StringBuilder brand = new StringBuilder();
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "CreateCheckBoxList()", true);
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "textFunction", "CreateCheckBoxList()", true);
            brand.Append("<table border = '1'>");
            brand.Append("<tr><th> Songs</th><th>Artist</th><th>ID</th>");
            brand.Append("</tr>");

            for (int i = 0; i < Information.ArtistCollection.Count; i++)
            {
                brand.Append("<tr>");
                brand.Append("<td>" + Information.SongCollection[i] + "</td>");
                brand.Append("<td>" + Information.ArtistCollection[i] + "</td>");
                brand.Append("<td>"+ Information.SongIDCollection[i] +"</td>");
                //brand.Append("<td><input type = 'checkbox' id = '"+ Information.SongCollection[i] + "' class = 'check' value = " + Information.ArtistCollection[i] + " AutoPostBack = 'true' OnClick = 'CheckClick()' ></td>");
                //brand.Append("<td><input type = 'checkbox' id = string" + i + " class = 'check' value = 'GetSelected' onclick = 'GetSelected()' class='btn btn-primary'' ></td>");
                //brand.Append("<td>"++"</td>");
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "Confirm();", true);

                brand.Append("</tr>");
            }
            brand.Append("</table>");
            //PlaceHolder6.Controls.Add(new Literal { Text = brand.ToString() });

            String CurrentlySelected = DropDownList2.SelectedItem.Text;
            Label6.Text = ("Write the Song Id of the song you want to enter in the playlist");
            
            if (CurrentlySelected == "New Playlist")
            {
                TextBox2.Style.Add("display", "100%");
                Button4.Style.Add("display", "100%");
                Button5.Style.Add("display", "none");
                Button4.Visible = true;
                Button4.Enabled = true;  
            }

            else
            {
                TextBox2.Style.Add("display", "none");
                Button4.Style.Add("display", "none");
                Button5.Style.Add("display", "100%");
            }
            musicDB.Close();

            

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            SqlConnection musicDB = new SqlConnection("Server=tcp:cristian-music-server.database.windows.net,1433;Initial Catalog=CristianMusicDB;Persist Security Info=False;User ID=Nijacool;Password=Ahirunosora200;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            musicDB.Open();
            PlaceHolder2.Controls.Add(new Literal { Text = Information.finalTable });
            PlaceHolder3.Controls.Add(new Literal { Text = Information.currentTable });

            StringBuilder brand2 = new StringBuilder();
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "CreateCheckBoxList()", true);
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "textFunction", "CreateCheckBoxList()", true);
            brand2.Append("<table border = '1'>");
            brand2.Append("<tr><th> Songs</th><th>Artist</th><th>ID</th>");
            brand2.Append("</tr>");

            for (int i = 0; i < Information.ArtistCollection.Count; i++)
            {
                brand2.Append("<tr>");
                brand2.Append("<td>" + Information.SongCollection[i] + "</td>");
                brand2.Append("<td>" + Information.ArtistCollection[i] + "</td>");
                brand2.Append("<td>" + Information.SongIDCollection[i] + "</td>");
                //brand.Append("<td><input type = 'checkbox' id = '"+ Information.SongCollection[i] + "' class = 'check' value = " + Information.ArtistCollection[i] + " AutoPostBack = 'true' OnClick = 'CheckClick()' ></td>");
                //brand.Append("<td><input type = 'checkbox' id = string" + i + " class = 'check' value = 'GetSelected' onclick = 'GetSelected()' class='btn btn-primary'' ></td>");
                //brand.Append("<td>"++"</td>");
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "Confirm();", true);

                brand2.Append("</tr>");
            }
            brand2.Append("</table>");
            //PlaceHolder6.Controls.Add(new Literal { Text = brand2.ToString() });

            String song_Name = TextBox3.Text;
            String song_artist = TextBox4.Text;

            SqlCommand entries = new SqlCommand();
            SqlCommand entries2 = new SqlCommand();
            SqlCommand entries3 = new SqlCommand();
            entries.Connection = musicDB;
            entries2.Connection = musicDB;
            entries3.Connection = musicDB;
            Dictionary<String, String> book2 = new Dictionary<String, String>();
            int state = 0;
            if (song_Name != "") { state = 1; }
            if(song_artist != "") { state = 2; }
            if (song_artist != "" && song_Name != "") { state = 3; }
            StringBuilder brand = new StringBuilder();
            brand.Append("<table border = '1'>");
            brand.Append("<tr><th> Songs</th><th>Artist</th><th>ID</th>");
            brand.Append("</tr>");
            switch (state)
            {
                case 1:
                    Dictionary<String, int> book = new Dictionary<String, int>();
                    List<int> tempID = new List<int>();
                    entries.CommandText = "SELECT * FROM Song WHERE (Song_Name = '" + song_Name + "')";
                    SqlDataReader rd = entries.ExecuteReader();
                    List<int> sng = new List<int>();
                    if (rd.HasRows)
                    {
                        while (rd.Read())
                        {
                            book.Add((String)rd[1], (int)rd[3]);
                            tempID.Add((int)rd[0]);
                        }
                    }
                    rd.Close();
                    for (int i = 0; i < book.Count; i++)
                    {
                        entries2.CommandText = "SELECT Artist_Name FROM ProfileArtist WHERE(Artist_Id = " + book.ElementAt(i).Value + ")";
                        SqlDataReader rd2 = entries2.ExecuteReader();
                        if (rd2.HasRows)
                        {
                            while (rd2.Read())
                            {
                                book2.Add(book.ElementAt(i).Key, (String)rd2[0]);
                                brand.Append("<tr>");
                                brand.Append("<td>" + book.ElementAt(i).Key + "</td>");
                                brand.Append("<td>" + (String)rd2[0] + "</td>");
                                brand.Append("<td>"+ tempID.ElementAt(i)+"</td>");
                                brand.Append("</tr>");

                            }
                        }
                        else
                        {
                            brand.Append("<tr>");
                            brand.Append("<td>Not Found</td>");
                            brand.Append("<td>Not Found</td>");
                            brand.Append("<td>Not Found</td>");
                            brand.Append("</tr>");
                        }
                        rd2.Close();
                    }

                    break;
                case 2:
                    SqlCommand entries4 = new SqlCommand();
                    entries4.Connection = musicDB;
                    entries4.CommandText = "SELECT Artist_Id FROM ProfileArtist WHERE (Artist_Name = '" + song_artist + "')";
                    List<int> IdList = new List<int>();
                    SqlDataReader rd3 = entries4.ExecuteReader();
                    if (rd3.HasRows)
                    {
                        while (rd3.Read())
                        {
                            IdList.Add((int)rd3[0]);
                        }
                    }
                    
                    rd3.Close();
                    for (int i = 0; i < IdList.Count; i++)
                    {
                        entries2.CommandText = "SELECT Song_Name, Song_Id FROM Song WHERE (Artist_Id = " + IdList[i] + ")";
                        SqlDataReader rd4 = entries2.ExecuteReader();
                        if (rd4.HasRows)
                        {
                            while (rd4.Read())
                            {
                                book2.Add((String)rd4[0], song_artist);
                                brand.Append("<tr>");
                                brand.Append("<td>" + (String)rd4[0] + "</td>");
                                brand.Append("<td>" + song_artist + "</td>");
                                brand.Append("<td>" + rd4[1] + "</td>");
                                brand.Append("</tr>");
                            }
                        }
                        else
                        {
                            brand.Append("<tr>");
                            brand.Append("<td>Not Found</td>");
                            brand.Append("<td>Not Found</td>");
                            brand.Append("<td>Not Found</td>");
                            brand.Append("</tr>");
                        }
                        rd4.Close();
                    }


                    break;
                case 3:
                    SqlCommand entries6 = new SqlCommand();
                    entries6.Connection = musicDB;
                    entries6.CommandText = "SELECT Artist_Id FROM ProfileArtist WHERE (Artist_Name = '" + song_artist + "')";
                    int Id = 0;
                    bool commandEmpty = false;
                    try
                    {
                        Id = (int)entries6.ExecuteScalar();
                    }
                    catch (NullReferenceException)
                    {
                        commandEmpty = true;
                        brand.Append("<tr>");
                        brand.Append("<td>Not Found</td>");
                        brand.Append("<td>Not Found</td>");
                        brand.Append("<td>Not Found</td>");
                        brand.Append("</tr>");
                    }
                    if (commandEmpty) { break; }
                    SqlCommand entries5 = new SqlCommand();
                    entries5.CommandText = "SELECT * FROM Song WHERE (Song_Name = '" + song_Name + "')";
                    entries5.Connection = musicDB;
                    SqlDataReader rd5 = entries5.ExecuteReader();
                    if (rd5.HasRows)
                    {
                        while (rd5.Read())
                        {
                            if ((int)rd5[3] == Id)
                            {
                                book2.Add((String)rd5[1], song_artist);
                                brand.Append("<tr>");
                                brand.Append("<td>" + (String)rd5[1] + "</td>");
                                brand.Append("<td>" + song_artist + "</td>");
                                brand.Append("<td>" + rd5[0] + "</td>");
                                brand.Append("</tr>");
                            }
                        }
                    }
                    rd5.Close();

                    break;

                default:
                    Label8.Text = ("You have yet to put entries for the search");
                    musicDB.Close();
                    return;
            }
            TextBox3.Text = ("");
            TextBox4.Text = ("");
            PlaceHolder7.Controls.Add(new Literal { Text = brand.ToString() });
            musicDB.Close();



        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            SqlConnection musicDB = new SqlConnection("Server=tcp:cristian-music-server.database.windows.net,1433;Initial Catalog=CristianMusicDB;Persist Security Info=False;User ID=Nijacool;Password=Ahirunosora200;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            musicDB.Open();
            PlaceHolder2.Controls.Add(new Literal { Text = Information.finalTable });
            PlaceHolder3.Controls.Add(new Literal { Text = Information.currentTable });
            //find how many playlists the user has, then add it with the playlist id being that number +1
            String userId = Request.QueryString["id"];
            String input = TextBox2.Text;
            String Songinput = TextBox5.Text;
            //ADD PROFANITY LIST OF BAN
            if (input == "" || input.Length > 20)
            {
                Label7.Text = ("Playlist Name can not be empty, and it can not contain more than 20 characters");
                musicDB.Close();
                return;
            }
            if(TextBox5.Text == "")
            {
                Label7.Text = ("Playlist needs to have a song in to be created, please add one using the Id");
                musicDB.Close();
                return;
            }
            else
            {
                int playlistNumber = 0;
                int repeated = 0;
                int songInside = 0;
                //song Id has input, input is not id
                SqlCommand compare = new SqlCommand("SELECT Playlist_Name FROM PlaylistTbl WHERE (Created_By = " + userId + ")", musicDB);
                SqlDataReader compReader = compare.ExecuteReader();
                List<String> pNames = new List<String>();
                if (compReader.HasRows)
                {
                    while (compReader.Read())
                    {
                        pNames.Add((String)compReader[0]);
                    }
                }
                compReader.Close();
                List<String> Pdistinct = pNames.Distinct().ToList();
                playlistNumber = Pdistinct.Count + 1;
                //need to make playlistId count distinct playlists
                SqlCommand repetition = new SqlCommand("SELECT COUNT(1) FROM PlaylistTbl WHERE (Playlist_Name = '" + input + "')", musicDB);
                SqlCommand songValid = new SqlCommand("SELECT COUNT(1) FROM PlaylistTbl WHERE (Song_Id = '" + Songinput + "')", musicDB);
                try
                {
                    repeated = (int)repetition.ExecuteScalar();
                    songInside = (int)songValid.ExecuteScalar();


                }
                catch (NullReferenceException)
                {
                    Label7.Text = ("Internal Error has Happen, please try again later");
                    musicDB.Close();
                    return;
                }


                int newPlaylistId = playlistNumber + 1;
                String songId = TextBox5.Text;

                int input2 = 0;
                int userId2 = 0;
                String name = TextBox2.Text;
                try
                {
                    input2 = Int32.Parse(songId);
                    userId2 = Int32.Parse(userId);

                }
                catch (FormatException)
                {
                    Label7.Text = ("Please use real numbers for SongId");
                    musicDB.Close();
                    //Label7.Text = ("PlaylistID("+newPlaylistId.GetType().FullName+" = "+ newPlaylistId + ") Song_ID("+ input.GetType().FullName + "="+input+") Playlist_Name("+ name.GetType().FullName + "="+name+") Created_By("+ userId.GetType().FullName + "="+userId+")");
                    return;
                }
                int failure = 0;
                if(repeated == 0) { failure = 1; }
                if(songInside <= 0) { failure = 2; }
                switch (failure)
                {
                    case 1:
                        
                        SqlCommand newPlay = new SqlCommand("EXEC dbo.CreatePlaylist @PlaylistId, @Song_Id, @Playlist_Name, @Created_By", musicDB);
                        newPlay.Parameters.AddWithValue("@PlaylistId", newPlaylistId);
                        newPlay.Parameters.AddWithValue("@Song_Id", input2);
                        newPlay.Parameters.AddWithValue("@Playlist_Name", name);
                        newPlay.Parameters.AddWithValue("@Created_By", userId2);
                        //need to make song Id valid again
                        int status = newPlay.ExecuteNonQuery();

                        if(status == 0)
                        {
                            Label7.Text = ("Playlist was not created, please revise your inputs");
                            break;
                        }
                        else
                        {

                            Label7.Text = ("Successfully Created Playlist");
                            ListItem first = new ListItem(name, newPlaylistId.ToString());
                            DropDownList1.Items.Add(first);
                            DropDownList2.Items.Add(first);
                            Information.globalDropdown.Add(first);
                            input2 = 0;
                            userId2 = 0;
                        }

                        break;

                    case 2:
                        Label7.Text = ("The Song you selected does not exist");
                        break;

                    case 0: 
                        Label7.Text = ("This Playlist Already Exists");
                        break;
                }


                //Creation of playlist goes here
                
            }            
            musicDB.Close();

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection musicDB = new SqlConnection("Server=tcp:cristian-music-server.database.windows.net,1433;Initial Catalog=CristianMusicDB;Persist Security Info=False;User ID=Nijacool;Password=Ahirunosora200;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            musicDB.Open();
            PlaceHolder2.Controls.Add(new Literal { Text = Information.finalTable});
            if (DropDownList1.SelectedValue == "")
            {

            }
            if(DropDownList1.SelectedItem.Text.Length >= 15)
            {
                Label7.Text = "Playlist Name is too long";
            }
            else
            {
                StringBuilder temp = new StringBuilder();
                temp.Append("<table border = '1'>");
                temp.Append("<tr><th> Songs </th><th> Artists </th><th>ID</th>");
                temp.Append("</tr>");

                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "SELECT * FROM PlaylistTbl WHERE (Playlist_Name = '" + DropDownList1.SelectedItem.Text + "' AND Created_By = "+ Request.QueryString["id"] + ")";
                cmd.Connection = musicDB;
                SqlDataReader rd = cmd.ExecuteReader();
                SqlCommand displaySongsId = new SqlCommand();
                displaySongsId.Connection = musicDB;

                displaySongsId.Connection = musicDB;
                List<int> songIDs = new List<int>();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        songIDs.Add((int)rd[2]);
                    }
                }
                rd.Close();
                List<String> songName = new List<string>();
                List<int> songI = new List<int>();
                List<int> Arts = new List<int>();
                for (int i = 0; i < songIDs.Count; i++)
                {
                    displaySongsId.CommandText = "SELECT * FROM Song WHERE (Song_Id = " + songIDs[i] + ")";
                    SqlDataReader rd2 = displaySongsId.ExecuteReader();
                    if (rd2.HasRows)
                    {
                        while (rd2.Read())
                        {
                            songName.Add((String)rd2[1]);
                            songI.Add((int)rd2[0]);
                            Arts.Add((int)rd2[3]);
                            //songBook.Add((String)rd2[1], (int)rd2[3]);
                        }
                    }
                    rd2.Close();
                }
                SqlCommand ArtistFinder = new SqlCommand();
                ArtistFinder.Connection = musicDB;

                for (int i = 0; i < songI.Count; i++)
                {
                    //ArtistFinder.CommandText = "SELECT Artist_Name FROM ProfileArtist WHERE (Artist_Id = "+ songBook.ElementAt(i).Value +")";
                    ArtistFinder.CommandText = "SELECT Artist_Name FROM ProfileArtist WHERE (Artist_Id = " + Arts[i] + ")";
                    SqlDataReader rd3 = ArtistFinder.ExecuteReader();
                    if (rd3.HasRows)
                    {
                        while (rd3.Read())
                        {//song artist id
                            temp.Append("<tr>");
                            //temp.Append("<td>" + songBook.ElementAt(i).Key + "</td>");
                            temp.Append("<td>" + songName[i] + "</td>");
                            temp.Append("<td>" + (String)rd3[0] + "</td>");
                            //temp.Append("<td>" + songBook.ElementAt(i).Value + "</td>");
                            temp.Append("<td>" + songI[i] + "</td>");
                            temp.Append("</tr>");
                        }
                    }
                    rd3.Close();
                }
                temp.Append("</table>");
                table = temp.ToString();
                Label3.Text = ("Here are the Songs in your playlist '" + DropDownList1.SelectedItem.Text + "'");
                PlaceHolder3.Controls.Add(new Literal { Text = table });
                Information.currentTable = table;
            }
            musicDB.Close();

        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            SqlConnection musicDB = new SqlConnection("Server=tcp:cristian-music-server.database.windows.net,1433;Initial Catalog=CristianMusicDB;Persist Security Info=False;User ID=Nijacool;Password=Ahirunosora200;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            musicDB.Open();
            PlaceHolder2.Controls.Add(new Literal { Text = Information.finalTable });
            String CurrentlySelected = DropDownList2.SelectedItem.Text;

            if (CurrentlySelected == "" || CurrentlySelected == "New Playlist")
            {
                Label7.Text = ("Please Select an existing Playlilst");
            }
            else
            {
                SqlCommand DeletePlaylist = new SqlCommand("DELETE FROM PlaylistTbl WHERE (Playlist_Id = " + DropDownList2.SelectedValue + ")", musicDB);
                DeletePlaylist.ExecuteNonQuery();
                DropDownList1.Items.Remove(DropDownList2.SelectedItem);
                DropDownList2.Items.Remove(DropDownList2.SelectedItem);

            }
            musicDB.Close();


        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            Response.Redirect("LogInPage.aspx");
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebForm1.aspx");
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            SqlConnection musicDB = new SqlConnection("Server=tcp:cristian-music-server.database.windows.net,1433;Initial Catalog=CristianMusicDB;Persist Security Info=False;User ID=Nijacool;Password=Ahirunosora200;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            musicDB.Open();
            PlaceHolder2.Controls.Add(new Literal { Text = Information.finalTable });
            String CurrentlySelected = DropDownList2.SelectedItem.Text;

            if (Information.SubscriptionAccount != "2")
            {
                SqlCommand Upgrade = new SqlCommand("UPDATE UserProfile SET Subscription = 2 WHERE (User_Id = " + Request.QueryString["id"] + ")", musicDB);
                Upgrade.ExecuteNonQuery();
                musicDB.Close();
                Response.Redirect("LogInPage.aspx");
                //Information.SubscriptionAccount = "2";
                //Label10.Text = "Premium Account";
                //Button8.Text = "Cancel Premium Subscription";
            }

            if (Request.QueryString["s"] == "2")
            {
                //Button8.Enabled = false;
                SqlCommand Upgrade = new SqlCommand("UPDATE UserProfile SET Subscription = 1 WHERE (User_Id = " + Request.QueryString["id"] + ")", musicDB);
                Upgrade.ExecuteNonQuery();
                musicDB.Close();
                Response.Redirect("LogInPage.aspx");
                //Information.SubscriptionAccount = "1";
                //Button8.Text = "Upgrade to Premium";
                //Label10.Text = "";
            }



        }

    }
}