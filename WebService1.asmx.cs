using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OracleClient;
using System.Web.Services;
using Webservice;
using Newtonsoft.Json;

namespace WebService1
{
    /// <summary>
    /// Descripción breve de WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }

        [WebMethod]
        public int Add(int x, int y)
        {
            return x + y;
        }

        [WebMethod]
        public int Sub(int x, int y)
        {
            return x - y;
        }

        [WebMethod]
        public int Mul(int x, int y)
        {
            return x * y;
        }

        [WebMethod]
        public int Div(int x, int y)
        {
            return x / y;
        }

        [WebMethod(BufferResponse = true)]
        public string Cliente_Select_Full()
        {
            Conect_Oracle conn = new Conect_Oracle();
            conn.EstablecerConnection();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn.GetConexion();


            OracleParameter param_name = new OracleParameter();
            param_name.OracleType = OracleType.Cursor;

            cmd.CommandText = "list_customer";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("c_cursor", OracleType.Cursor).Direction = ParameterDirection.Output;
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.Fill(ds);
            return JsonConvert.SerializeObject(ds, Newtonsoft.Json.Formatting.Indented);
        }

        [WebMethod(BufferResponse = true)]
        public object UPDATE_oferta()
        {
            Conect_Oracle conect = new Conect_Oracle();
            conect.EstablecerConnection();

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conect.GetConexion();

            cmd.CommandText = "UPDATE_oferta";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();

            return "se logro";
        }

        [WebMethod(BufferResponse = true)]
        public object INSERT_CUSTOMER(int ic, string nombre, string apellido, string direc, int phone, string email, int edad)
        {
            Conect_Oracle conect = new Conect_Oracle();
            conect.EstablecerConnection();

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conect.GetConexion();

            OracleParameter param_ic = new OracleParameter();
            param_ic.OracleType = OracleType.Number;
            param_ic.Value = ic;

            OracleParameter param_nc = new OracleParameter();
            param_nc.OracleType = OracleType.VarChar;
            param_nc.Value = nombre;

            OracleParameter param_lc = new OracleParameter();
            param_lc.OracleType = OracleType.VarChar;
            param_lc.Value = apellido;

            OracleParameter param_ac = new OracleParameter();
            param_ac.OracleType = OracleType.VarChar;
            param_ac.Value = direc;

            OracleParameter param_pc = new OracleParameter();
            param_pc.OracleType = OracleType.Number;
            param_pc.Value = phone;

            OracleParameter param_ec = new OracleParameter();
            param_ec.OracleType = OracleType.VarChar;
            param_ec.Value = email;

            OracleParameter param_uc = new OracleParameter();
            param_uc.OracleType = OracleType.Number;
            param_uc.Value = edad;

            cmd.CommandText = "INSERT_CUSTOMER";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("ic", OracleType.Number).Value = param_ic.Value;
            cmd.Parameters.Add("nc", OracleType.VarChar).Value = param_nc.Value;
            cmd.Parameters.Add("lc", OracleType.VarChar).Value = param_lc.Value;
            cmd.Parameters.Add("ac", OracleType.VarChar).Value = param_ac.Value;
            cmd.Parameters.Add("pc", OracleType.Number).Value = param_pc.Value;
            cmd.Parameters.Add("ec", OracleType.VarChar).Value = param_ec.Value;
            cmd.Parameters.Add("uc", OracleType.Number).Value = param_uc.Value;
            cmd.ExecuteNonQuery();

            return "se logro";
        }

        [WebMethod(BufferResponse = true)]
        public object UPDATE_CUSTOMER(int ic, string nombre, string apellido, string direc, int phone, string email, int edad)
        {
            Conect_Oracle conect = new Conect_Oracle();
            conect.EstablecerConnection();

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conect.GetConexion();

            OracleParameter param_ic = new OracleParameter();
            param_ic.OracleType = OracleType.Number;
            param_ic.Value = ic;

            OracleParameter param_nc = new OracleParameter();
            param_nc.OracleType = OracleType.VarChar;
            param_nc.Value = nombre;

            OracleParameter param_lc = new OracleParameter();
            param_lc.OracleType = OracleType.VarChar;
            param_lc.Value = apellido;

            OracleParameter param_ac = new OracleParameter();
            param_ac.OracleType = OracleType.VarChar;
            param_ac.Value = direc;

            OracleParameter param_pc = new OracleParameter();
            param_pc.OracleType = OracleType.Number;
            param_pc.Value = phone;

            OracleParameter param_ec = new OracleParameter();
            param_ec.OracleType = OracleType.VarChar;
            param_ec.Value = email;

            OracleParameter param_uc = new OracleParameter();
            param_uc.OracleType = OracleType.Number;
            param_uc.Value = edad;

            cmd.CommandText = "UPDATE_CUSTOMER";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("ic", OracleType.Number).Value = param_ic.Value;
            cmd.Parameters.Add("nc", OracleType.VarChar).Value = param_nc.Value;
            cmd.Parameters.Add("lc", OracleType.VarChar).Value = param_lc.Value;
            cmd.Parameters.Add("ac", OracleType.VarChar).Value = param_ac.Value;
            cmd.Parameters.Add("pc", OracleType.Number).Value = param_pc.Value;
            cmd.Parameters.Add("ec", OracleType.VarChar).Value = param_ec.Value;
            cmd.Parameters.Add("uc", OracleType.Number).Value = param_uc.Value;
            cmd.ExecuteNonQuery();

            return "se logro";
        }


        [WebMethod(BufferResponse = true)]
        public object DELETE_CUSTOMER(int id)
        {
            Conect_Oracle conect = new Conect_Oracle();
            conect.EstablecerConnection();

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conect.GetConexion();

            OracleParameter param_id = new OracleParameter();
            param_id.OracleType = OracleType.Number;
            param_id.Value = id;

            cmd.CommandText = "DELETE_CUSTOMER";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("e_id", OracleType.Number).Value = param_id.Value;
            cmd.ExecuteNonQuery();

            return "se logro";
        }

        [WebMethod(BufferResponse = true)]
        public object INSERT_VIDEOGAME(int iv, string nombre, string precio, string portada, string fecha, int genero, int desarrollador)
        {
            Conect_Oracle conect = new Conect_Oracle();
            conect.EstablecerConnection();

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conect.GetConexion();

            OracleParameter param_iv = new OracleParameter();
            param_iv.OracleType = OracleType.Number;
            param_iv.Value = iv;

            OracleParameter param_nv = new OracleParameter();
            param_nv.OracleType = OracleType.VarChar;
            param_nv.Value = nombre;

            OracleParameter param_pv = new OracleParameter();
            param_pv.OracleType = OracleType.VarChar;
            param_pv.Value = precio;

            OracleParameter param_fv = new OracleParameter();
            param_fv.OracleType = OracleType.VarChar;
            param_fv.Value = portada;

            OracleParameter param_av = new OracleParameter();
            param_av.OracleType = OracleType.VarChar;
            param_av.Value = fecha;

            OracleParameter param_gv = new OracleParameter();
            param_gv.OracleType = OracleType.Number;
            param_gv.Value = genero;

            OracleParameter param_ev = new OracleParameter();
            param_ev.OracleType = OracleType.Number;
            param_ev.Value = desarrollador;

            cmd.CommandText = "INSERT_VIDEOGAME";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("iv", OracleType.Number).Value = param_iv.Value;
            cmd.Parameters.Add("nv", OracleType.VarChar).Value = param_nv.Value;
            cmd.Parameters.Add("pv", OracleType.VarChar).Value = param_pv.Value;
            cmd.Parameters.Add("fv", OracleType.VarChar).Value = param_fv.Value;
            cmd.Parameters.Add("av", OracleType.VarChar).Value = param_av.Value;
            cmd.Parameters.Add("gv", OracleType.Number).Value = param_gv.Value;
            cmd.Parameters.Add("ev", OracleType.Number).Value = param_ev.Value;
            cmd.ExecuteNonQuery();

            return "se logro";
        }

        [WebMethod(BufferResponse = true)]
        public object UPDATE_VIDEOGAME(int iv, string nombre, string precio, string portada, string fecha, int genero, int desarrollador)
        {
            Conect_Oracle conect = new Conect_Oracle();
            conect.EstablecerConnection();

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conect.GetConexion();

            OracleParameter param_iv = new OracleParameter();
            param_iv.OracleType = OracleType.Number;
            param_iv.Value = iv;

            OracleParameter param_nv = new OracleParameter();
            param_nv.OracleType = OracleType.VarChar;
            param_nv.Value = nombre;

            OracleParameter param_pv = new OracleParameter();
            param_pv.OracleType = OracleType.VarChar;
            param_pv.Value = precio;

            OracleParameter param_fv = new OracleParameter();
            param_fv.OracleType = OracleType.VarChar;
            param_fv.Value = portada;

            OracleParameter param_av = new OracleParameter();
            param_av.OracleType = OracleType.VarChar;
            param_av.Value = fecha;

            OracleParameter param_gv = new OracleParameter();
            param_gv.OracleType = OracleType.Number;
            param_gv.Value = genero;

            OracleParameter param_ev = new OracleParameter();
            param_ev.OracleType = OracleType.Number;
            param_ev.Value = desarrollador;

            cmd.CommandText = "UPDATE_VIDEOGAME";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("iv", OracleType.Number).Value = param_iv.Value;
            cmd.Parameters.Add("nv", OracleType.VarChar).Value = param_nv.Value;
            cmd.Parameters.Add("pv", OracleType.VarChar).Value = param_pv.Value;
            cmd.Parameters.Add("fv", OracleType.VarChar).Value = param_fv.Value;
            cmd.Parameters.Add("av", OracleType.VarChar).Value = param_av.Value;
            cmd.Parameters.Add("gv", OracleType.Number).Value = param_gv.Value;
            cmd.Parameters.Add("ev", OracleType.Number).Value = param_ev.Value;
            cmd.ExecuteNonQuery();

            return "se logro";
        }

        [WebMethod(BufferResponse = true)]
        public string Videogames_Select_Full()
        {
            Conect_Oracle conn = new Conect_Oracle();
            conn.EstablecerConnection();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn.GetConexion();


            OracleParameter param_name = new OracleParameter();
            param_name.OracleType = OracleType.Cursor;

            cmd.CommandText = "list_videogames";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("c_cursor", OracleType.Cursor).Direction = ParameterDirection.Output;
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.Fill(ds);
            return JsonConvert.SerializeObject(ds, Newtonsoft.Json.Formatting.Indented);
        }

        [WebMethod(BufferResponse = true)]
        public object DELETE_VIDEOGAMES(int id)
        {
            Conect_Oracle conect = new Conect_Oracle();
            conect.EstablecerConnection();

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conect.GetConexion();

            OracleParameter param_id = new OracleParameter();
            param_id.OracleType = OracleType.Number;
            param_id.Value = id;

            cmd.CommandText = "DELETE_videogame";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("e_id", OracleType.Number).Value = param_id.Value;
            cmd.ExecuteNonQuery();

            return "se logro";
        }

        [WebMethod(BufferResponse = true)]
        public string Videogames_price()
        {
            Conect_Oracle conn = new Conect_Oracle();
            conn.EstablecerConnection();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn.GetConexion();


            OracleParameter param_name = new OracleParameter();
            param_name.OracleType = OracleType.Cursor;

            cmd.CommandText = "list_videogamesprice";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("c_cursor", OracleType.Cursor).Direction = ParameterDirection.Output;
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.Fill(ds);
            return JsonConvert.SerializeObject(ds, Newtonsoft.Json.Formatting.Indented);
        }




        [WebMethod(BufferResponse = true)]
        public int Login(String usuario, String contra)
        {
            Conect_Oracle conn = new Conect_Oracle();
            conn.EstablecerConnection();

            OracleParameter param_usu = new OracleParameter();
            param_usu.OracleType = OracleType.VarChar;
            param_usu.Value = usuario;

            OracleParameter param_contra = new OracleParameter();
            param_contra.OracleType = OracleType.VarChar;
            param_contra.Value = contra;

            //OracleParameter param_val = new OracleParameter();
            //param_val.OracleType = OracleType.Number;
            //param_val.Value = 0;

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn.GetConexion();
            cmd.CommandText = "login_usu";

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("c_usuario", OracleType.VarChar).Value = param_usu.Value;
            cmd.Parameters.Add("c_contra", OracleType.VarChar).Value = param_contra.Value;
            cmd.Parameters.Add("n_resp", OracleType.Number).Direction = System.Data.ParameterDirection.Output;
            cmd.ExecuteNonQuery();

            /*string res;
            res = cmd.Parameters["n_resp"].Value.ToString();*/
            int res = int.Parse(cmd.Parameters["n_resp"].Value.ToString());

            return res;

        }

        [WebMethod(BufferResponse = true)]
        public string Reporte_ventas(String gen)
        {
            Conect_Oracle conn = new Conect_Oracle();
            conn.EstablecerConnection();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn.GetConexion();

            OracleParameter tgen = new OracleParameter();
            tgen.OracleType = OracleType.VarChar;
            tgen.Value = gen;

            OracleParameter param_name = new OracleParameter();
            param_name.OracleType = OracleType.Cursor;
            cmd.CommandText = "rep_ventasf";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("c_genero", OracleType.VarChar).Value = gen;
            cmd.Parameters.Add("c_cursor", OracleType.Cursor).Direction = ParameterDirection.Output;
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.Fill(ds);
            return JsonConvert.SerializeObject(ds, Newtonsoft.Json.Formatting.Indented);
        }

    }
}