using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace WebApplication2.admin
{
    public partial class Role : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Panel1.Visible = true;

            GridViewRow row = GridView1.SelectedRow;
            string user = row.Cells[0].Text;

            string[] role = Roles.GetRolesForUser(user);

            Label1.Text = user;

            string[] roles = Roles.GetAllRoles();

            DropDownList1.DataSource = roles;
            DropDownList1.DataBind();


            DropDownList1.SelectedIndex = DropDownList1.Items.IndexOf(DropDownList1.Items.FindByText(role[0]));

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string user = Label1.Text;
            string role = DropDownList1.SelectedValue;
            string[] roles = Roles.GetRolesForUser(user);

            Roles.RemoveUserFromRoles(user, roles);
            Roles.AddUserToRole(user, role);
            GridView1.DataBind();
        }
    }
}