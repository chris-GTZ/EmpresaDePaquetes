using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DL {
  public class DL_BaseDatos {
    SqlConnection ConexionDB = new SqlConnection("Data Source=DESKTOP-A6BV1GP;Initial Catalog=Supermercado;User ID=sa;Password=K25.zBxQ");

    private void ConectarDB() {
      if (ConexionDB.State == ConnectionState.Closed) ConexionDB.Open();
    }

    private void DesconectarDB() {
      if (ConexionDB.State == ConnectionState.Open) ConexionDB.Close();
    }

    DataSet TempDB = new DataSet();
    SqlDataAdapter AdministradorConexionDB;

    private void CargarTabla(string nombreTabla) {
      ConectarDB();
      SqlCommand query = new SqlCommand($"SELECT * FROM {nombreTabla}", ConexionDB);
      query.CommandType = CommandType.Text;
      AdministradorConexionDB = new SqlDataAdapter(query);
      AdministradorConexionDB.FillSchema(TempDB, SchemaType.Source, nombreTabla);
      AdministradorConexionDB.Fill(TempDB, nombreTabla);
      DesconectarDB();
    }

    public DataTable DevolverTabla(string nombreTabla) {
      CargarTabla(nombreTabla);
      DataTable dt = TempDB.Tables[nombreTabla];
      bool coso= dt.Rows.Find(1)[2] == "asd";
      return dt;
    }

    public void ActualizarTabla(string nombreTabla) {
      if(TempDB.HasChanges()) {
        AdministradorConexionDB.Update(TempDB);
        TempDB.AcceptChanges();
      }
    }
  }
}
