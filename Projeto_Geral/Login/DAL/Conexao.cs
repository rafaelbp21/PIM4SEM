using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Login.DAL
{
    public class Conexao
    {
        NpgsqlConnection con = new NpgsqlConnection();
        public Conexao()
        {
            con.ConnectionString = @"Host = localhost; Database = banco; Username = postgres; Password =1234; Persist Security Info = True";
            //con.ConnectionString = @"Host=jppi.duckdns.org;Port=9001;Database=banco;Username=admin;Password=admin;Persist Security Info=True";
        }

        public NpgsqlConnection conectar()
        {
            if(con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            return con;
        }
        public void desconectar()
        {
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
        }
    }
}
