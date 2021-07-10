using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using Oracle.DataAccess.Client;
using System.Web.Services;
//using Oracle.DataAccess.Types;
using System.Data;
using System.Data.OracleClient;
//using Newtonsoft.Json;

namespace Webservice
{
    public class Conect_Oracle
    {
        OracleConnection oc;
        string oradb = "DATA SOURCE=xe ;USER ID=SYSTEM; PASSWORD=123456789"; // establece conexion con el servidor
        public Conect_Oracle()
        {
        }

        public void EstablecerConnection()
        {
            oc = new OracleConnection(oradb);
            oc.Open();

        }

        public OracleConnection GetConexion()
        {
            return oc;
        }
    }
}