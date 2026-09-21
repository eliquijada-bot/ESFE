using ESFE.RegistroAcademico.EntidadesDeNegocio;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.SqlClient;

namespace ESFE.RegistroAcademico.AccesoADatos
{
    public class EstadoDAL
    {
        public static int Guardar(Estado pEstado) //METODO PARA GUARDAR INFORMACION EN LA BASE DE DATOS
        {
            string consulta = "INSERT INTO Estado(Nombre) VALUES(@Nombre)";
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = consulta;
            comando.Parameters.AddWithValue("@Nombre", pEstado.Nombre);
            return ComunDB.EjecutarComando(comando);
        }
        public static int Modificar(Estado pEstado) //METODO PARA MODIFICAR INFORMACION EN LA BASE DE DATOS
        {
            string consulta = "UPDATE Estado SET Nombre = @Nombre WHERE Id=@Id";
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = consulta;
            comando.Parameters.AddWithValue("@Id", pEstado.Id);
            comando.Parameters.AddWithValue("@Nombre", pEstado.Nombre);
            return ComunDB.EjecutarComando(comando);
        }
        public static int Eliminar(Estado pEstado)//METODO PARA ELIMINAR INFORMACION EN LA BASE DE DATOS
        {
            string consulta = "DELETE FROM Estado WHERE Id=@Id";
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = consulta;
            comando.Parameters.AddWithValue("@Id", pEstado.Id);
            return ComunDB.EjecutarComando(comando);
        }
        public static List<Estado> ObtenerTodos() //METODO PARA TRAER IMFORMACION
        {
            string consulta = "SELECT TOP 500 e.Id, e.Nombre FROM Estado e";
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = consulta;
            SqlDataReader reader = ComunDB.EjecutarComandoReader(comando);
            List<Estado> listaEstados = new List<Estado>();
            while (reader.Read())
            {
                Estado estado = new Estado();
                estado.Id = reader.GetByte(0);
                estado.Nombre = reader.GetString(1);
                listaEstados.Add(estado);
            }
            return listaEstados;
        }
        public static Estado BuscarPorId(byte pId)//METADO PARA BUSCAR POR ID
        {
            string consulta = "SELECT e.Id, e.Nombre FROM Estado e WHERE Id = @Id";
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = consulta;
            comando.Parameters.AddWithValue("@Id", pId);
            SqlDataReader reader = ComunDB.EjecutarComandoReader(comando);
            Estado estado = new Estado();
            while (reader.Read())
            {
                estado.Id = reader.GetByte(0);
                estado.Nombre = reader.GetString(1);
            }
            return estado;
        }
    }
}
