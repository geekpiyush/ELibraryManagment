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
    public partial class adminmembermanagement : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }

        // Go Button 
        protected void Button11_Click(object sender, EventArgs e)
        {
            if(checkMemberExist())
            {
                GetMemberByID();
            }
            else
            {
                Response.Write("<script>alert('Invalid Member ID');</script>");
            }
        }

        // Delete Button
        protected void Button1_Click(object sender, EventArgs e)
        {
            if(checkMemberExist())
            {
                deleteMember();
            }
            else
            {
                Response.Write("<script>alert('Invalid Member ID');</script>");
            }
        }

        // check either member exist or not
        bool checkMemberExist()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from member_master_tbl where member_id = @member_id", con);
                cmd.Parameters.AddWithValue("@member_id", TextBox3.Text.Trim());
                
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    //Response.Write("<script>alert('Invalid Member ID');</script>");
                    return false;
                }
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }


        // GetMemberByID
        void GetMemberByID()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from member_master_tbl where member_id= @member_id", con);
                cmd.Parameters.AddWithValue("@member_id", TextBox3.Text.Trim());

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    //full name
                    TextBox4.Text = dt.Rows[0][0].ToString();

                    // DOB
                    TextBox8.Text = dt.Rows[0][1].ToString();

                    // Contact 
                    TextBox9.Text = dt.Rows[0][2].ToString();

                    //emailID
                    TextBox10.Text = dt.Rows[0][3].ToString();

                    //State
                    TextBox1.Text = dt.Rows[0][4].ToString();

                    //City
                    TextBox2.Text = dt.Rows[0][5].ToString();

                    //Pincode
                    TextBox5.Text = dt.Rows[0][6].ToString();

                    //Full Address
                    TextBox6.Text = dt.Rows[0][7].ToString();

                    //Account Status
                    TextBox7.Text = dt.Rows[0][10].ToString();
                }
               
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        void deleteMember()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if(con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("DELETE from member_master_tbl where member_id=@member_id", con);
                cmd.Parameters.AddWithValue("@member_id", TextBox3.Text.Trim());

                cmd.ExecuteNonQuery();

                con.Close();

                Response.Write("<script>alert('Member was deleted');</script>");
                GridView1.DataBind();

                ClearInputData();


            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        void ClearInputData()
        {
            // member ID
            TextBox3.Text = "";
            
            //full name
            TextBox4.Text = "";

            // DOB
            TextBox8.Text = "";

            // Contact 
            TextBox9.Text = "";

            //emailID
            TextBox10.Text = "";

            //State
            TextBox1.Text = "";

            //City
            TextBox2.Text = "";

            //Pincode
            TextBox5.Text = "";

            //Full Address
            TextBox6.Text = "";

            //Account Status
            TextBox7.Text = "";
        }

    // Status Active Button
        protected void LinkButton12_Click(object sender, EventArgs e)
        {
            UpdateMemberStatus("Active");
        }

    // Status Pending Button
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            UpdateMemberStatus("Pending");
        }

      //Status Deactivate Button
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            UpdateMemberStatus("Deactivate");
        }

        // Update Member Status Using ID
        void UpdateMemberStatus(string status)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if(con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("UPDATE member_master_tbl SET account_status='"+status+"' where member_id= @member_id", con);

                cmd.Parameters.AddWithValue("@member_id",TextBox3.Text.Trim());

                cmd.ExecuteNonQuery();

                con.Close();

                Response.Write("<script>alert('Member Status Updated');</script>");

                GridView1.DataBind();
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}