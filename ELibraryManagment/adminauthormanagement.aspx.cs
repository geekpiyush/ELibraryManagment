using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ELibraryManagment
{
    public partial class adminauthormanagement : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

      // Add Button
        protected void Button1_Click(object sender, EventArgs e)
        {
            if(checkAuthorExits())
            {
                Response.Write("<script>alert('Author ID Already Exist..!');</script>");
            }
            else
            {
                AddNewAuthor();
            }
        }

       // Update Button
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (checkAuthorExits())
            {
              
                updateAuthor();
                
            }
            else
            {
                Response.Write("<script>alert('Author dose not Exist..!');</script>");
            }
        }

        // Delete Button
        protected void Button3_Click(object sender, EventArgs e)
        {
            if(checkAuthorExits())
            {
                deleteAuthor();
            }
            else
            {
                Response.Write("<script>alert('Author dose not Exist');</script>");
            }
        }

       // Go Button
        protected void Button11_Click(object sender, EventArgs e)
        {
            getAuthor();
        }

        //user defiend method
        bool checkAuthorExits()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("select * from author_master_tbl where author_id='"+TextBox3.Text.Trim()+"';", con);
 
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false; // return false if there's an exception
            }
        }
              void AddNewAuthor()
            {
            try
            {
                SqlConnection con = new SqlConnection(strcon);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("insert into author_master_tbl(author_id, author_name)values(@author_id,@author_name)", con);

                cmd.Parameters.AddWithValue("@author_id", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@author_name", TextBox4.Text.Trim());
                

                cmd.ExecuteNonQuery();

                con.Close();

                Response.Write("<script>alert('Author added successfully..');</script>");

                clearForm();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        // update author method
        void updateAuthor()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("UPDATE author_master_tbl SET author_name = @author_name where author_id = @author_id", con);

                cmd.Parameters.AddWithValue("@author_name", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@author_id", TextBox3.Text.Trim());


                cmd.ExecuteNonQuery();

                con.Close();

                Response.Write("<script>alert('Author Updated successfully..');</script>");

                clearForm();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        // Delete Author Method
        void deleteAuthor()
        {
            try
            {

                    SqlConnection con = new SqlConnection(strcon);

                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    SqlCommand cmd = new SqlCommand("delete from author_master_tbl where author_id = @author_id;", con);

                    cmd.Parameters.AddWithValue("@author_id", TextBox3.Text.Trim());

                    cmd.ExecuteNonQuery();

                    con.Close();

                    Response.Write("<script>alert('Author Deleted');</script>");

                clearForm();
                GridView1.DataBind();
            }  
               catch(Exception ex)
                 {
                     Response.Write("<script>alert('" + ex.Message + "');");
                }
        }
        // clear input field
        void clearForm()
        {
            TextBox3.Text = "";
            TextBox4.Text = "";
        }
        // get author by ID
        void getAuthor()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("select * from author_master_tbl where author_id='" + TextBox3.Text.Trim() + "';", con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    TextBox4.Text = dt.Rows[0][1].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Invalid Author ID');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                
            }
        }
    }
}