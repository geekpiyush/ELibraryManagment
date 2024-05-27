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
    public partial class adminpublishermanagement : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // add button 
        protected void Button1_Click(object sender, EventArgs e)
        {
            if(checkPublisherExist())
            {
                Response.Write("<script>alert('Publisher Already Exist');</script>");
            }
            else
            {
                addNewPublisher();
            }
        }

        // update button
        protected void Button2_Click(object sender, EventArgs e)
        {
            if(checkPublisherExist())
            {
                updatePublisher();
            }
            else
            {
                Response.Write("<script>alert('Publisher dose not exist');</script>");
            }
        }

        // delete button

        protected void Button3_Click(object sender, EventArgs e)
        {
            if(checkPublisherExist())
            {
                deletePublihser();
            }
            else
            {
                Response.Write("<script>alert('Publisher dose not exist');</script>");
            }
        }

        // Go Button
        protected void Button11_Click(object sender, EventArgs e)
        {
            GetPublisherByID();
        }

        // check if Publisher is exist or not
        bool checkPublisherExist()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("select * from publisher_master_tbl where publisher_id='" + TextBox3.Text.Trim() + "';", con);

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
            catch(Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');");
                return false;
            }
        }

        // add publisher method
        void addNewPublisher()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);

                if(con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("insert into publisher_master_tbl (publisher_id,publisher_name) values (@publisher_id,@publisher_name);", con);

                cmd.Parameters.AddWithValue("@publisher_id", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@publisher_name", TextBox4.Text.Trim());

                cmd.ExecuteNonQuery();

                con.Close();

                Response.Write("<script>alert('Publisher Added Successful');</script>");
                clearInput();
                GridVie12.DataBind();
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('"+ex.Message+"');</script>");
            }
        }

        // update publisher method
        void updatePublisher()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("UPDATE publisher_master_tbl SET publisher_name = @publisher_name where publisher_id = @publisher_id ", con);

                cmd.Parameters.AddWithValue("@publisher_id", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@publisher_name", TextBox4.Text.Trim());

                cmd.ExecuteNonQuery();

                con.Close();

                Response.Write("<script>alert('Publisher Updated Successful');</script>");
                clearInput();
                GridVie12.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        // delete publisher method
        void deletePublihser()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);

                if(con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("DELETE from publisher_master_tbl WHERE publisher_id = @publisher_id", con);

                cmd.Parameters.AddWithValue("@publisher_id",TextBox3.Text.Trim());
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Publisher Deleted');</script>");
                clearInput();
                GridVie12.DataBind();
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }

        // clear input field method
        void clearInput()
        {
            TextBox3.Text = "";
            TextBox4.Text = "";
        }

        void GetPublisherByID()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("select * from publisher_master_tbl where publisher_id='" + TextBox3.Text.Trim() + "';", con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    TextBox4.Text = dt.Rows[0][1].ToString();
                }
                else
                {
                    Response.Write("<script>alert('invalid publisher ID');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');");
               
            }
        }
    }
}