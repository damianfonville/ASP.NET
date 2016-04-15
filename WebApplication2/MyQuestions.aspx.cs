using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;

namespace WebApplication2
{
    public partial class MyQuestions : System.Web.UI.Page
    {
        public string connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["connectionstring"].ToString();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("Login.aspx");
            }

            

            SqlDataReader reader = getQuestions();

            if (reader != null)
            {
                while (reader.Read())
                {

                    string stringid = reader["questionid"].ToString();
                    int intid = Int32.Parse(stringid);

                    Panel mainpanel = new Panel();
                    Panel headpanel = new Panel();
                    Panel btnpanel =  new Panel();
                    Panel bodypanel = new Panel();
                    Panel answerpanel = addAnswers(stringid);
                    LinkButton btndelete = new LinkButton();
                    Label questiontext = new Label();

                    //css styling
                    mainpanel.CssClass = "panel panel-default";
                    headpanel.CssClass = "panel-heading clearfix";
                    btnpanel.CssClass = "pull-right";
                    bodypanel.CssClass = "panel-body";
                    btndelete.CssClass = "btn btn-danger btn-sm";
                    answerpanel.Style["margin"] = "20px";

                    //set text 
                    questiontext.Text = reader["question"].ToString();
                    bodypanel.Controls.Add(questiontext);
                    var h4 = new HtmlGenericControl("h4");
                    h4.Attributes.Add("class", "panel-title pull-left");
                    h4.Attributes.Add("style", "padding-top: 7.5px;");
                    h4.InnerHtml = reader["title"].ToString();
                    headpanel.Controls.Add(h4);

                    btndelete.ID = "question" + stringid;
                    btndelete.Text = "Delete";
                    btndelete.Click += new EventHandler(this.deleteQuestion);
                    btndelete.Attributes.Add("questionid", stringid);

                    btnpanel.Controls.Add(btndelete);
                    headpanel.Controls.Add(btnpanel);
                    mainpanel.Controls.Add(headpanel);
                    mainpanel.Controls.Add(bodypanel);
                    mainpanel.Controls.Add(answerpanel);
                    Panel1.Controls.Add(mainpanel);

                }
            }
        }

        public SqlDataReader getQuestions()
        {

            System.Web.Security.MembershipUser user = System.Web.Security.Membership.GetUser(HttpContext.Current.User.Identity.Name);
            string userID = user.ProviderUserKey.ToString();

            SqlDataReader reader = null;


                SqlConnection db = new SqlConnection(connectionstring);

                SqlCommand cmd = new SqlCommand();


                cmd.CommandText = "SELECT * FROM questions INNER JOIN tags ON questions.tagid=tags.tagid WHERE questions.userid = '" + userID + "'";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = db;

                db.Open();

                reader = cmd.ExecuteReader();
            
            return reader;
        }

        public void deleteQuestion(Object sender, EventArgs e)
        {
            System.Web.Security.MembershipUser user = System.Web.Security.Membership.GetUser(HttpContext.Current.User.Identity.Name);
            string userID = user.ProviderUserKey.ToString();

           LinkButton link = (LinkButton)sender;

           string id = link.Attributes[("questionid")];

           SqlConnection db = new SqlConnection(connectionstring);

           SqlCommand cmd = new SqlCommand();


           cmd.CommandText = "DELETE FROM questions WHERE userid = '" + userID + "' AND questionid = '"+id+"'";
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

        public Panel addAnswers(string questionid)
        {
            Panel answers = new Panel();

            SqlDataReader reader = null;


            SqlConnection db = new SqlConnection(connectionstring);

            SqlCommand cmd = new SqlCommand();


            cmd.CommandText = "SELECT * FROM answers WHERE questionid = '" + questionid + "'";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = db;

            db.Open();

            reader = cmd.ExecuteReader();

           while(reader.Read())
            {
                Panel mainpanel = new Panel();
                Panel headpanel = new Panel();
                Panel bodypanel = new Panel();
                Label questiontext = new Label();

                //css styling
                mainpanel.CssClass = "panel panel-default";
                headpanel.CssClass = "panel-heading clearfix";
                bodypanel.CssClass = "panel-body";

                //set text 
                questiontext.Text = reader["text"].ToString();
                bodypanel.Controls.Add(questiontext);
                var h4 = new HtmlGenericControl("h4");
                h4.Attributes.Add("class", "panel-title pull-left");
                h4.Attributes.Add("style", "padding-top: 7.5px;");
                h4.InnerHtml = "test"+reader["answerid"];
                headpanel.Controls.Add(h4);

                //mainpanel.Controls.Add(headpanel);
                mainpanel.Controls.Add(bodypanel);
                answers.Controls.Add(mainpanel);
            }
            return answers;
        }
        
    }
}