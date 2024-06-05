using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ELibraryManagment
{
    public partial class adminbookinventory : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Calling authorPublisherValues Method Whenever Page loaded author and publisher dropdown values comes from database

            authorPublisherValues();


            GridView1.DataBind();
        }

        // Add Button 
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (checkBookExist())
            {
                Response.Write("<script>alert('Book ID or Name Already Exist');</script>");
            }
            else
            {
                addNewBook();
            }
        }

        // Update Button
        protected void Button2_Click(object sender, EventArgs e)
        {

        }

        // Delete Button
        protected void Button3_Click(object sender, EventArgs e)
        {

        }

        // Go Button
        protected void Button11_Click(object sender, EventArgs e)
        {

        }


        //  user defined functions
        void authorPublisherValues()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if(con.State== ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT author_name from author_master_tbl", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DropDownList2.DataSource = dt;
                DropDownList2.DataValueField = "author_name";
                DropDownList2.DataBind();


                cmd = new SqlCommand("SELECT publisher_name from publisher_master_tbl", con);
                 da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                DropDownList1.DataSource = dt;
                DropDownList1.DataValueField = "publisher_name";
                DropDownList1.DataBind();
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        // checkBookExist Method

        bool checkBookExist()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("Select * from book_master_tbl where book_id= @book_id", con);
                cmd.Parameters.AddWithValue("@book_id", TextBox3.Text.Trim());

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
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
          
        }


        // add book method
        void addNewBook()
        {
            try
            {
                // gener string for collecting multiple slection 
                string genres = "";

                // get all selected gener 
                foreach (int i in ListBox1.GetSelectedIndices())
                {
                    genres = genres + ListBox1.Items[i] + ",";
                }

                // remove extra comma from geners
                genres = genres.Remove(genres.Length - 1);


                // book image file upload
                string filepath = "~/book_inventory/books1.png";
                string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);

                // SaveAs function save file
                FileUpload1.SaveAs(Server.MapPath("book_inventory/" + filename));

                filepath = "~/book_inventory/" + filename;



                SqlConnection con = new SqlConnection(strcon);

                if(con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT into book_master_tbl (book_id,book_name,genre,author_name,publisher_name,publish_date,language,edition,book_cost,no_of_pages,book_description,actual_stock,current_stock,book_img_link) VALUES (@book_id,@book_name,@genre,@author_name,@publisher_name,@publish_date,@language,@edition,@book_cost,@no_of_pages,@book_description,@actual_stock,@current_stock,@book_img_link)", con);

                cmd.Parameters.AddWithValue("@book_id", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@book_name", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@genre",genres);
                cmd.Parameters.AddWithValue("@language", DropDownList.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@publisher_name", DropDownList1.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@author_name", DropDownList2.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@publish_date", TextBox9.Text.Trim());
                cmd.Parameters.AddWithValue("@edition", TextBox7.Text.Trim());
                cmd.Parameters.AddWithValue("@book_cost", TextBox8.Text.Trim());
                cmd.Parameters.AddWithValue("@no_of_pages", TextBox10.Text.Trim());
                cmd.Parameters.AddWithValue("@actual_stock", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@current_stock", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@book_description", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@book_img_link",filepath);

                cmd.ExecuteNonQuery();
                con.Close();

                Response.Write("<script>alert('Book Added Succeessfully')</script>");

                clearInput();
                GridView1.DataBind();
                

            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        // clear input fileds
        void clearInput()
        {
            TextBox1.Text = "";
            TextBox10.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            TextBox5.Text = "";
            TextBox6.Text = "";
            TextBox7.Text = "";
            TextBox8.Text = "";
            TextBox9.Text = "";
        }

        //get details using bookID

        void getBookDetails()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if(con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * From book_master_tbl where book_id = @book_id", con);

                cmd.Parameters.AddWithValue("@book_id", TextBox3.Text.Trim());

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                da.Fill(dt);

                if(dt.Rows.Count>1)
                {

                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

    }
}