using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.Profile;

namespace WebApplication2
{
    public partial class Questions : System.Web.UI.Page
    {
        public string connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["connectionstring"].ToString();
        public string[] tags;
        public string answerid;
        protected void Page_Load(object sender, EventArgs e)
        {
            var roles = new List<string> { "Admin", "Expert" };
            var userRoles = Roles.GetRolesForUser(HttpContext.Current.User.Identity.Name);

            if (!userRoles.Any(u => roles.Contains(u)))
                Response.Redirect("Login.aspx");

            this.getTags();

            if (Request.QueryString["tag"] != null)
            {
                this.showQuestions();
            }
        }

        public String AnswerId
        {

            get { return answerid; }

            set { answerid = value; }

        } 

        protected SqlDataReader getQuestions()
        {
            string tag = Request.QueryString["tag"];
            SqlDataReader reader = null;
            if (Regex.IsMatch(tag, @"^[a-zA-Z]+$"))
            {

                SqlConnection db = new SqlConnection(connectionstring);

                SqlCommand cmd = new SqlCommand();
                

                cmd.CommandText = "SELECT * FROM questions INNER JOIN tags ON questions.tagid=tags.tagid WHERE tags.name = '"+tag+"'";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = db;

                db.Open();

                reader = cmd.ExecuteReader();
            }
            return reader;
        }

        private void getTags()
        {



            SqlConnection db = new SqlConnection(connectionstring);

            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "SELECT * FROM tags";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = db;

            db.Open();

            reader = cmd.ExecuteReader();

           tags = new string[reader.FieldCount + 1];
            
           while (reader.Read())
           {
               int id = Int32.Parse(reader["tagid"].ToString());
               tags[(id - 1)] = reader["name"].ToString();
           }
            
            db.Close();
        }

        public void deleteQuestion(Object sender, EventArgs e)
        {
            LinkButton link = (LinkButton)sender;

            string id = link.Attributes[("questionid")];

            SqlConnection db = new SqlConnection(connectionstring);

            SqlCommand cmd = new SqlCommand();


            cmd.CommandText = "DELETE FROM questions WHERE questionid = '" + id + "'";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = db;

            db.Open();
            cmd.ExecuteNonQuery();

            SqlCommand cmd2 = new SqlCommand();


            cmd2.CommandText = "DELETE FROM answers WHERE questionid = '" + id + "'";
            cmd2.CommandType = CommandType.Text;
            cmd2.Connection = db;

            cmd2.ExecuteNonQuery();

            Panel1.Controls.Clear();
            Page_Load(this, new EventArgs());
        }

       protected void answer_Click(Object sender, EventArgs e)
        {
            LinkButton link = sender as LinkButton;

            AnswerId = link.Attributes[("questionid")];

            Server.Transfer("answer.aspx");
        }

       public string GetFullNameByUserID(string UserID)
       {
           string fullName = "";
           //TO DO:get username by userID  
           Guid guid = Guid.Parse(UserID);
           MembershipUser user = Membership.GetUser(guid);
           if (user != null)
           {
               string name = user.UserName;

               return name;
               
           }

           return fullName;
       }

       private void showQuestions()
       {
           SqlDataReader reader = getQuestions();

           if (reader != null)
           {
               while (reader.Read())
               {

                   string stringid = reader["questionid"].ToString();
                   int intid = Int32.Parse(stringid);


                   Panel mainpanel = new Panel();
                   Panel headpanel = new Panel();
                   Panel btnpanel = new Panel();
                   Panel bodypanel = new Panel();
                   LinkButton btnanswer = new LinkButton();
                   Label questiontext = new Label();

                   //css styling
                   mainpanel.CssClass = "panel panel-default";
                   headpanel.CssClass = "panel-heading clearfix";
                   btnpanel.CssClass = "pull-right";
                   bodypanel.CssClass = "panel-body";
                   btnanswer.CssClass = "btn btn-success btn-sm";
                   

                   //set text 
                   questiontext.Text = reader["question"].ToString();
                   bodypanel.Controls.Add(questiontext);
                   var h4 = new HtmlGenericControl("h4");
                   h4.Attributes.Add("class", "panel-title pull-left");
                   h4.Attributes.Add("style", "padding-top: 7.5px;");
                   h4.InnerHtml = reader["title"].ToString();
                   headpanel.Controls.Add(h4);
                   btnanswer.Text = "Answer";

                   btnanswer.ID = "qustion" + stringid;
                  // btnanswer.PostBackUrl = "~/answer.aspx";
                   btnanswer.Click += new EventHandler(this.answer_Click);
                   btnanswer.Attributes.Add("questionid", stringid);

                   
                   btnpanel.Controls.Add(btnanswer);
                   if (User.IsInRole("Admin"))
                   {
                       LinkButton btndelete = new LinkButton();

                       btndelete.CssClass = "btn btn-danger btn-sm";

                       btndelete.ID = "question" + stringid;
                       btndelete.Text = "Delete";
                       btndelete.Click += new EventHandler(this.deleteQuestion);
                       btndelete.Attributes.Add("questionid", stringid);

                       btnpanel.Controls.Add(btndelete);

                   }
                   headpanel.Controls.Add(btnpanel);
                   mainpanel.Controls.Add(headpanel);
                   mainpanel.Controls.Add(bodypanel);

                   Panel1.Controls.Add(mainpanel);

               }
           }
       }

    }



}