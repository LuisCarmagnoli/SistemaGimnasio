using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGimnasio
{
    public class DataAccessLayer
    {
        private SqlConnection connection = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SistemaGimnasio;Data Source=DESKTOP-PP0K0MS");

        public void InsertClase(Clase clase)
        {
            try
            {
                connection.Open();
                string query = @"
                                INSERT INTO Clases(Nombre_Clase, Instructor, Horario, Capacidad, Espacios_Disponibles)
                                VALUES (@NombreClase, @NombreInstructor, @Horario, @Capacidad, @EspaciosDisponibles)";

                SqlParameter nombreClase = new SqlParameter("@NombreClase", clase.NombreClase);
                SqlParameter nombreInstructor = new SqlParameter("@NombreInstructor", clase.NombreInstructor);
                SqlParameter horario = new SqlParameter("@Horario", clase.Horario);
                SqlParameter capacidad = new SqlParameter("@Capacidad", clase.Capacidad);
                SqlParameter espaciosDisponibles = new SqlParameter("@EspaciosDisponibles", clase.EspaciosDisponibles);

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.Add(nombreClase);
                command.Parameters.Add(nombreInstructor);
                command.Parameters.Add(horario);
                command.Parameters.Add(capacidad);
                command.Parameters.Add(espaciosDisponibles);

                command.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                connection.Close();
            }
        }

        public List<Clase> GetClases()
        {
            List<Clase> clases = new List<Clase>();
            try
            {
                connection.Open();
                string query = @"SELECT ID_Clase, Nombre_Clase, Instructor, Horario, Capacidad, Espacios_Disponibles
                                FROM Clases";

                SqlCommand command = new SqlCommand(query, connection);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    clases.Add(new Clase
                    {
                        IdClase = int.Parse(reader["ID_Clase"].ToString()),
                        NombreClase = reader["Nombre_Clase"].ToString(),
                        NombreInstructor = reader["Instructor"].ToString(),
                        Horario = reader["Horario"].ToString(),
                        Capacidad = int.Parse(reader["Capacidad"].ToString()),
                        EspaciosDisponibles = int.Parse(reader["Espacios_Disponibles"].ToString())
                    });
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                connection.Close();
            }

            return clases;
        }
    }
}
