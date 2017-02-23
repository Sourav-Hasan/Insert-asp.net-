using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Workshop
{
    public partial class Doctor : System.Web.UI.Page
    {
        DB db = new DB();
        protected void Page_Load(object sender, EventArgs e)
        {
            grid_doctor();
        }

        protected void Button_submit_Click(object sender, EventArgs e)
        {
            string _query = @"INSERT INTO [dbo].[Doctor]
           ([Doctor_id]
           ,[Doctor_name]
           ,[Doctor_address])
     VALUES
           ('" + TextBox_id.Text + "', '" + TextBox_name.Text + "', '" + TextBox_address.Text + "')";
            db.ExecuteQuery(_query);
            grid_doctor();
            //TextBox_id.Text = "";
            //TextBox_name.Text = "";
            //TextBox_address.Text = "";
            Response.Redirect("~/Doctor.aspx");


        }
        protected void grid_doctor()
        {
            string _query = @"SELECT [Doctor_id]
                                  ,[Doctor_name]
                                  ,[Doctor_address]
                              FROM [dbo].[Doctor]";
            GridView_doctor.DataSource = db.GetDataTable(_query);
            GridView_doctor.DataBind();
        }
    }
}