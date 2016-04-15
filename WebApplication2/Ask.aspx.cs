using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data.SqlClient;
using System.Data;

namespace WebApplication2
{
    public partial class Ask : System.Web.UI.Page
    {
        public string connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["connectionstring"].ToString();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("Login.aspx");
            }
            Panel3.Visible = false;
            Panel1.Visible = false;

            setTags();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            MembershipUser user = Membership.GetUser(HttpContext.Current.User.Identity.Name);
            string userID = user.ProviderUserKey.ToString();

            string tb_title = tbTitle.Text.Trim();
            if (tb_title == String.Empty || tb_title == null)
            {
                Panel1.Visible = true;
                return;
            }

            string tb_question = tbQuestion.Text.Trim();
            if (tb_question == String.Empty || tb_question == null)
            {
                Panel1.Visible = true;
                return;
            }
            

            SqlConnection db = new SqlConnection(connectionstring);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "INSERT INTO questions (title, question, tagid, userid) VALUES ('"+ tb_title +"', '"+tb_question+"', "+DropDownList1.SelectedValue+", '"+ userID +"' )";
            cmd.Connection = db;

            db.Open();
            cmd.ExecuteNonQuery();
            db.Close();

            Panel3.Visible = true;
            Panel2.Visible = false;

        }

        public void setTags()
        {
            SqlConnection db = new SqlConnection(connectionstring);

            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "SELECT * FROM tags";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = db;

            db.Open();

            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                DropDownList1.Items.Add(new ListItem(reader["name"].ToString(), reader["tagid"].ToString()));
            }

            db.Close();

        }
    }
}