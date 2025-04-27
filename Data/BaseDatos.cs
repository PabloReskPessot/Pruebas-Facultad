using Microsoft.Data.SqlClient;
using Veterinaria.Models;

namespace Veterinaria.Data
{
    public class BaseDatos
    {
        public string conexionString = "Server=(localdb)\\mssqllocaldb;Database=Veterinaria;Trusted_Connection=True;MultipleActiveResultSets=True";

        public List<Mascota> ListadoMascotas ()
        {
            List<Mascota> mascotas = new List<Mascota> ();
            List<Raza> razas = ListadoRazas();
            List<Dueño> dueños = ListadoDueños();

            using (SqlConnection con = new SqlConnection(conexionString))
            {
                string query = "select * from Mascotas";
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                Raza raza = new Raza ();
                Dueño dueño = new Dueño ();

                while (reader.Read())
                {
                    for (int i = 0; i < razas.LongCount(); i++)
                    {
                        if (razas[i].id == (int)reader["Razaid"])
                            raza = razas[i];
                    }
                    for (int i = 0; i < dueños.LongCount(); i++)
                    {
                        if (dueños[i].id == (int)reader["Dueñoid"])
                            dueño = dueños[i];
                    }
                    mascotas.Add(new Mascota
                    {
                        id = (int)reader["id"],
                        nombre = reader["nombre"].ToString(),
                        edad = (int)reader["edad"],
                        id_raza = (int)reader["Razaid"],
                        id_dueño= (int)reader["Dueñoid"],
                        Raza = raza,
                        Dueño = dueño,

                    });
                
                }

                

                return mascotas;
            }
        }

        public List<Raza> ListadoRazas()
        {
            List<Raza> razas = new List<Raza> ();

            using (SqlConnection con = new SqlConnection(conexionString))
            {
                string query = "select * from Razas";
                con.Open();
                SqlCommand sqlCommand = new SqlCommand(query,con);
                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    razas.Add(new Raza
                    {
                        id= (int)reader["id"],
                        raza = reader["raza"].ToString()
                    });
                        
                }

            }


            return razas;
        }

        public List<Dueño> ListadoDueños()
        {
            List<Dueño> dueños = new List<Dueño>();

            using (SqlConnection con = new SqlConnection(conexionString))
            {
                string query = "select * from Dueños";
                con.Open();
                SqlCommand sqlCommand = new SqlCommand(query, con);
                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    dueños.Add(new Dueño
                    {
                        id = (int)reader["id"],
                        nombre = reader["nombre"].ToString()
                    });
                }
            }

            return dueños;
        }

        public string CrearMascota (Mascota mascota)
        {
            string query = $"insert into Mascotas(nombre,edad,Razaid,Dueñoid) values ('{mascota.nombre}',{mascota.edad},{mascota.id_raza},{mascota.id_dueño})";

            using (SqlConnection con = new SqlConnection(conexionString))
            {
                con.Open();
                SqlCommand sqlCommand = new SqlCommand(query, con);
                sqlCommand.ExecuteNonQuery();
            }


                return "";
        }
    }

    
}
