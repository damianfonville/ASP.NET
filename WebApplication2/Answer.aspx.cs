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
    public partial class Answer : System.Web.UI.Page
    {
        public string connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["connectionstring"].ToString();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.PreviousPage !=null)
            {
                string questionid = PreviousPage.AnswerId;

                LinkButton1.Attributes.Add("questionid", questionid);
                setQuestion(questionid);
            }
            else if (IsPostBack)
            {
                Response.Write("callback");
            }
            else
            {
                Response.Redirect("~/questions.aspx");
            }
        }

        public void setQuestion(string questionid)
        {

            SqlConnection db = new SqlConnection(connectionstring);

            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader = null;

            cmd.CommandText = "SELECT * FROM questions WHERE questionid = '" + questionid + "'";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = db;

            db.Open();

            reader = cmd.ExecuteReader();

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
                    Label questiontext = new Label();

                    //css styling
                    mainpanel.CssClass = "panel panel-default";
                    headpanel.CssClass = "panel-heading clearfix";
                    btnpanel.CssClass = "pull-right";
                    bodypanel.CssClass = "panel-body";


                    //set text 
                    questiontext.Text = reader["question"].ToString();
                    bodypanel.Controls.Add(questiontext);
                    var h4 = new HtmlGenericControl("h4");
                    h4.Attributes.Add("class", "panel-title pull-left");
                    h4.Attributes.Add("style", "padding-top: 7.5px;");
                    h4.InnerHtml = reader["title"].ToString();
                    headpanel.Controls.Add(h4);



                    mainpanel.Controls.Add(headpanel);
                    mainpanel.Controls.Add(bodypanel);

                    Panel1.Controls.Add(mainpanel);

                }
            }
        }

        public void submitanswer(Object sender, EventArgs e)
        {
            LinkButton lbanswer = sender as LinkButton;

            MembershipUser user = Membership.GetUser(HttpContext.Current.User.Identity.Name);
            string userID = user.ProviderUserKey.ToString();
            string questionid = lbanswer.Attributes[("questionid")];
            string answer = TextBox1.Text;


            SqlConnection db = new SqlConnection(connectionstring);

            SqlCommand cmd = new SqlCommand();


            cmd.CommandText = "INSERT INTO answers (text, userid, questionid) VALUES ('"+answer+"', '"+ userID +"', '"+questionid+"')";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = db;

            db.Open();
            cmd.ExecuteNonQuery();
           
        }
    }
}