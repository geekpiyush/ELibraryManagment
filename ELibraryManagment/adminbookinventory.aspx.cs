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

        static string globalFilePath;
        static int global_actual_stock, global_current_stock, global_issued_book;

        public SqlConnection SqlConnection { get; private set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            //Calling authorPublisherValues Method Whenever Page loaded author and publisher dropdown values comes from database
            if(!IsPostBack)
            {
                authorPublisherValues();
            }
            


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
            updateBook();
        }

        // Delete Button
        protected void Button3_Click(object sender, EventArgs e)
        {
            deleteBookByID();
        }

        // Go Button
        protected void Button11_Click(object sender, EventArgs e)
        {
            if(checkBookExist())
            {
                getBookDetails();
            }
            else
            {
                Response.Write("<script>alert('Invalid BookID');</script>");
            }
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

                if(dt.Rows.Count >= 1)
                {
                    TextBox4.Text = dt.Rows[0][1].ToString();
                    TextBox9.Text = dt.Rows[0][5].ToString();
                    TextBox7.Text = dt.Rows[0][7].ToString();
                    TextBox8.Text = dt.Rows[0][8].ToString();
                    TextBox10.Text = dt.Rows[0][9].ToString();
                    TextBox1.Text = dt.Rows[0][11].ToString();
                    TextBox2.Text = dt.Rows[0][12].ToString();
                    TextBox6.Text = dt.Rows[0][10].ToString();
                  
                    TextBox5.Text = "" + (Convert.ToInt32(dt.Rows[0]["actual_stock"].ToString().Trim()) -
                        Convert.ToInt32(dt.Rows[0]["current_stock"].ToString().Trim()));

                    DropDownList.SelectedValue = dt.Rows[0]["language"].ToString().Trim();
                    DropDownList1.SelectedValue = dt.Rows[0]["publisher_name"].ToString().Trim();
                    DropDownList2.SelectedValue = dt.Rows[0]["author_name"].ToString().Trim();
                    ListBox1.ClearSelection();

                    string[] genre = dt.Rows[0]["genre"].ToString().Trim().Split(',');
                    for (int i = 0; i < genre.Length; i++)
                    {
                        for(int j = 0; j < ListBox1.Items.Count; j++)
                        {
                            if(ListBox1.Items[j].ToString() == genre[i])
                            {
                                ListBox1.Items[j].Selected = true;
                            }
                            else
                            {
                                ListBox1.Items[j].Selected = false;
                            }
                        }
                    }

                    // declare global variable:
                    global_actual_stock = Convert.ToInt32(dt.Rows[0]["actual_stock"].ToString().Trim());
                    global_current_stock = Convert.ToInt32(dt.Rows[0]["current_stock"].ToString().Trim());
                    global_issued_book = global_actual_stock - global_current_stock;
                    globalFilePath = dt.Rows[0]["book_img_link"].ToString();



                }
                else
                {
                    Response.Write("<script>alert('Invalid Book ID');</script>");
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        // UpdateBookMethod

        void updateBook()
        {
            if (checkBookExist())
            {
                try
                {
                    int actual_stock = Convert.ToInt32(TextBox1.Text.Trim());
                    int current_stock = Convert.ToInt32(TextBox2.Text.Trim());

                    if (actual_stock != global_actual_stock)
                    {
                        if (actual_stock < global_issued_book)
                        {
                            Response.Write("<script>alert('<b>Actual Stock Value Cannot Be Less Than The Issued Book</b>')</script>");
                            return; // Exit the function early
                        }
                        else
                        {
                            current_stock = actual_stock - global_issued_book;
                            TextBox2.Text = current_stock.ToString();
                        }
                    }

                    // Generate string for collecting multiple selections 
                    string genres = "";

                    // Get all selected genres
                    foreach (int i in ListBox1.GetSelectedIndices())
                    {
                        genres += ListBox1.Items[i].ToString() + ",";
                    }

                    // Remove extra comma from genres
                    if (genres.Length > 0)
                    {
                        genres = genres.Remove(genres.Length - 1);
                    }

                    string filepath = "~/book_inventory/books1.png";
                    string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);

                    if (string.IsNullOrEmpty(filename))
                    {
                        filepath = globalFilePath;
                    }
                    else
                    {
                        FileUpload1.SaveAs(Server.MapPath("book_inventory/" + filename));
                        filepath = "~/book_inventory/" + filename;
                    }

                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    SqlCommand cmd = new SqlCommand("UPDATE book_master_tbl SET book_name = @book_name, language = @language, author_name = @author_name, publisher_name = @publisher_name, genre = @genre, publish_date = @publish_date, edition = @edition, book_cost = @book_cost, no_of_pages = @no_of_pages, actual_stock = @actual_stock, current_stock = @current_stock, book_description = @book_description, book_img_link = @book_img_link WHERE book_id = @book_id", con);

                    cmd.Parameters.AddWithValue("@book_id", TextBox3.Text.Trim());
                    cmd.Parameters.AddWithValue("@book_name", TextBox4.Text.Trim());
                    cmd.Parameters.AddWithValue("@language", DropDownList.SelectedItem.Value); // Use .Value or .Text
                    cmd.Parameters.AddWithValue("@publisher_name", DropDownList1.SelectedItem.Value); // Use .Value or .Text
                    cmd.Parameters.AddWithValue("@author_name", DropDownList2.SelectedItem.Value); // Use .Value or .Text
                    cmd.Parameters.AddWithValue("@genre", genres);
                    cmd.Parameters.AddWithValue("@publish_date", TextBox9.Text.Trim());
                    cmd.Parameters.AddWithValue("@edition", TextBox7.Text.Trim());
                    cmd.Parameters.AddWithValue("@book_cost", TextBox8.Text.Trim());
                    cmd.Parameters.AddWithValue("@no_of_pages", TextBox10.Text.Trim());
                    cmd.Parameters.AddWithValue("@actual_stock", actual_stock);
                    cmd.Parameters.AddWithValue("@current_stock", current_stock);
                    cmd.Parameters.AddWithValue("@book_description", TextBox6.Text.Trim());
                    cmd.Parameters.AddWithValue("@book_img_link", filepath);

                    cmd.ExecuteNonQuery();
                    con.Close();
                    GridView1.DataBind();

                    Response.Write("<script>alert('Book Updated')</script>");
                    clearInput();
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Invalid Book ID');</script>");
            }
        }
        // deleteBookByID Method
        void deleteBookByID()
        {
            if(checkBookExist())
            {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);

                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    SqlCommand cmd = new SqlCommand("DELETE from book_master_tbl Where book_id =@book_id", con);
                    cmd.Parameters.AddWithValue("@book_id", TextBox3.Text.Trim());

                    cmd.ExecuteNonQuery();
                    con.Close();
                    GridView1.DataBind();

                    Response.Write("<script>alert('Book was deleted');</script>");
                }
                catch(Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }   
            else
            {
                Response.Write("<script>alert('Invalid Book ID');</script>");
            }
            

        }


    }
}