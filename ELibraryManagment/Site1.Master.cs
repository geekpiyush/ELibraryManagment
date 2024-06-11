using System;
using System.Web.UI;

namespace ELibraryManagment
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
               if (Session["role"] != null && Session["role"].Equals("user"))
                {
                    LinkButton1.Visible = false;   // userlogin button 
                    LinkButton2.Visible = false;  //  userSignup button
                    LinkButton3.Visible = true; //  logout button
                    LinkButton4.Visible = true;  //  view books button;
                    LinkButton7.Text = "Hello "+ Session["fullName"].ToString();  // hello user button;

                    LinkButton6.Visible = true;  // admin login button
                    LinkButton8.Visible = false;  // book inventory button
                    LinkButton9.Visible = false;  // book issue button
                    LinkButton10.Visible = false;  // member management button
                    LinkButton11.Visible = false;  // author management button
                    LinkButton12.Visible = false;  // publisher management button
                }
                else if (Session["role"] != null && Session["role"].Equals("admin"))
                {
                    LinkButton1.Visible = false;   // userlogin button 
                    LinkButton2.Visible = false;  //  userSignup button
                    LinkButton3.Visible = true; //  logout button
                    LinkButton4.Visible = true;  //  view books button;
                    LinkButton7.Text = "Hello " + "Admin";   // hello user button;

                    LinkButton6.Visible = false;  // admin login button
                    LinkButton8.Visible = true;  // book inventory button
                    LinkButton9.Visible = true;  // book issue button
                    LinkButton10.Visible = true;  // member management button
                    LinkButton11.Visible = true;  // author management button
                    LinkButton12.Visible = true;  // publisher management button
                }
               else
                {
                    LinkButton1.Visible = true;   // userlogin button 
                    LinkButton2.Visible = true;  //  userSignup button
                    LinkButton3.Visible = false; //  logout button
                    LinkButton4.Visible = true;  //  view books button;
                    LinkButton7.Visible = false; // hello user button;

                    LinkButton6.Visible = true;  // admin login button
                    LinkButton8.Visible = false;  // book inventory button
                    LinkButton9.Visible = false;  // book issue button
                    LinkButton10.Visible = false;  // member management button
                    LinkButton11.Visible = false;  // author management button
                    LinkButton12.Visible = false;  // publisher management button
                }

            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('"+ex.Message+"');</script>");
            }
        }
      
        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Response.Redirect("viewBooks.aspx");
        }

        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminlogin.aspx");
        }

        protected void LinkButton11_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminauthormanagement.aspx");
        }

        protected void LinkButton12_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminpublishermanagement.aspx");
        }

        protected void LinkButton8_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminbookinventory.aspx");
        }

        protected void LinkButton9_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminbookissuing.aspx");
        }

        protected void LinkButton10_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminmembermanagement.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("userlogin.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("signup.aspx");
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Session["username"] = "";
            Session["fullName"] = "";
            Session["role"] = "";
            Session["status"] = "";

            LinkButton1.Visible = true;   // userlogin button 
            LinkButton2.Visible = true;  //  userSignup button
            LinkButton3.Visible = false; //  logout button
            LinkButton4.Visible = true;  //  view books button;
            LinkButton7.Visible = false; // hello user button;

            LinkButton6.Visible = true;  // admin login button
            LinkButton8.Visible = false;  // book inventory button
            LinkButton9.Visible = false;  // book issue button
            LinkButton10.Visible = false;  // member management button
            LinkButton11.Visible = false;  // author management button
            LinkButton12.Visible = false;  // publisher management button

            Response.Redirect("homepage.aspx");
        }
    }
}
