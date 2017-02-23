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
    public partial class Patient : System.Web.UI.Page
    {
        DB db = new DB();
        protected void Page_Load(object sender, EventArgs e)
        {
            grid_patient();

        }

        protected void Button_submit_Click(object sender, EventArgs e)
        {


            string _query = @"INSERT INTO [dbo].[Patient]
           ([Patient_id]
           ,[Patient_name]
           ,[Patient_address])
     VALUES
           ('" + TextBox_id.Text + "', '" + TextBox_name.Text + "', '" + TextBox_address.Text + "')";
            db.ExecuteQuery(_query);
            grid_patient();
            //TextBox_id.Text = "";
            //TextBox_name.Text = "";
            //TextBox_address.Text = "";
            Response.Redirect("~/Patient.aspx");
        }  
    
        protected void grid_patient()
        {
            string _query = @"SELECT [Patient_id]
                                  ,[Patient_name]
                                  ,[Patient_address]
                              FROM [dbo].[Patient]";
            GridView_patient.DataSource = db.GetDataTable(_query);
            GridView_patient.DataBind();
        }
    }
}
