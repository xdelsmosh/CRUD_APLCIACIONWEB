using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.WebControls;

namespace CRUD_APLCIACIONWEB.Paginas
{
    public partial class CRUD : System.Web.UI.Page
    {
        readonly SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
        public static string sID = "-1";
        public static string sopc=" ";
        protected void Page_Load(object sender, EventArgs e)
        {
            //obtener id
            if(!Page.IsPostBack)
            {
                if (Request.QueryString["id"]!=null)
                {
                    sID = Request.QueryString["id"].ToString();
                    CargarDatos();
                    tbdate.TextMode=TextBoxMode.DateTime;
                }
                if (Request.QueryString["op"]!=null)
                {
                    sopc = Request.QueryString["op"].ToString();
                    switch (sopc) 
                    {
                        case "C":
                            this.lbtitulo.Text = "Ingresar nuevo usuario";
                            this.BtnCreate.Visible = true;
                            break;

                        case "R":
                            this.lbtitulo.Text = "Consulta de Usuario";
                            break;

                        case "U":
                            this.lbtitulo.Text = "Modificar Usuario";
                            this.BtnUpdate.Visible = true;
                            break;

                        case "D":
                            this.lbtitulo.Text = "Eliminar Usuario";
                            this.BtnDelete.Visible = true;
                            break;


                    }
                }
            }
        }
        void CargarDatos()
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("sp_read",con);
            da.SelectCommand.CommandType=CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@Id",SqlDbType.Int).Value=sID;
            DataSet ds = new DataSet();
            ds.Clear();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];
            DataRow row= dt.Rows[0];
            tbnombre.Text = row[1].ToString();
            tbedad.Text = row[2].ToString();
            tbemail.Text = row[3].ToString();
            DateTime d = (DateTime)row[4];
            tbdate.Text = d.ToString("dd/MM/yyyy");
            con.Close();
        }
        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("sp_create", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = tbnombre.Text; 
            cmd.Parameters.Add("@Edad", SqlDbType.Int).Value = tbedad.Text; 
            cmd.Parameters.Add("@Correo", SqlDbType.VarChar).Value = tbemail.Text; 
            cmd.Parameters.Add("@Fecha", SqlDbType.Date).Value = tbdate.Text; 
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("Index.aspx");
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {

            SqlCommand cmd = new SqlCommand("sp_delete", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = sID;
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("Index.aspx");
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("sp_update", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id",SqlDbType.Int).Value = sID;
            cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = tbnombre.Text; 
            cmd.Parameters.Add("@Edad", SqlDbType.Int).Value = tbedad.Text; 
            cmd.Parameters.Add("@Correo", SqlDbType.VarChar).Value = tbemail.Text; 
            cmd.Parameters.Add("@Fecha", SqlDbType.Date).Value = tbdate.Text; 
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("Index.aspx");
        }

        protected void BtnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
        }
    }
}