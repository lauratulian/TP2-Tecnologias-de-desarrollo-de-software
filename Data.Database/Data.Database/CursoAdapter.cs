using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class CursoAdapter : Adapter
    {
        #region Metodos
        public List<Curso> GetAll()
        {

            List<Curso> cursos = new List<Curso>();
            try
            {

                this.OpenConnection();

                SqlCommand cmdCursos = new SqlCommand("select * from cursos", sqlConn);


                SqlDataReader drCursos = cmdCursos.ExecuteReader();

                while (drCursos.Read())
                {
                    Curso cur = new Curso();

                    cur.ID = (int)drCursos["id_curso"];
                    cur.IDMateria = (int)drCursos["id_materia"];
                    cur.IDComision = (int)drCursos["id_comision"];
                    cur.AnioCalendario = (int)drCursos["anio_calendario"];
                    cur.Cupo = (int)drCursos["cupo"];
                    cur.Descripcion = (string)drCursos["descripcion"];

                    cursos.Add(cur);
                }

                drCursos.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de cursos", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }


            return cursos;
        }

        public void ActualizaCupo(int idCurso)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("update cursos set cupo = cupo -1 where id_curso=@id;", sqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = idCurso;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error el curso no tiene cupo", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public List<Curso> GetAllDisponibles()
        {

            List<Curso> cursos = new List<Curso>();
            try
            {

                this.OpenConnection();

                SqlCommand cmdCursos = new SqlCommand("select * from cursos where cupo>0", sqlConn);


                SqlDataReader drCursos = cmdCursos.ExecuteReader();

                while (drCursos.Read())
                {
                    Curso cur = new Curso();

                    cur.ID = (int)drCursos["id_curso"];
                    cur.IDMateria = (int)drCursos["id_materia"];
                    cur.IDComision = (int)drCursos["id_comision"];
                    cur.AnioCalendario = (int)drCursos["anio_calendario"];
                    cur.Cupo = (int)drCursos["cupo"];
                    cur.Descripcion = (string)drCursos["descripcion"];

                    cursos.Add(cur);
                }

                drCursos.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de cursos", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }


            return cursos;
        }

        public Curso GetOne(int ID)
        {
            Curso cur = new Curso();
            try
            {
                this.OpenConnection();
                SqlCommand cmdCursos = new SqlCommand("select * from cursos where id_curso=@id", sqlConn);
                cmdCursos.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drCursos = cmdCursos.ExecuteReader();
                if (drCursos.Read())
                {
                    cur.ID = (int)drCursos["id_curso"];
                    cur.IDMateria = (int)drCursos["id_materia"];
                    cur.IDComision = (int)drCursos["id_comision"];
                    cur.AnioCalendario = (int)drCursos["anio_calendario"];
                    cur.Cupo = (int)drCursos["cupo"];
                    cur.Descripcion = (string)drCursos["descripcion"];

                }
                drCursos.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return cur;
        }

        public List<Curso> GetCursosAlumnos(int id)
        {
            List<Curso> cursos = new List<Curso>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdCursos = new SqlCommand("select * from alumnos_inscripciones al inner join cursos cu on cu.id_curso=al.id_curso where al.id_curso=@id and cu.cupo>0;", sqlConn);
                cmdCursos.Parameters.Add("@id", SqlDbType.Int).Value = id;
                SqlDataReader drCursos = cmdCursos.ExecuteReader();
                while (drCursos.Read())
                {
                    Curso cur = new Curso();

                    cur.ID = (int)drCursos["id_curso"];
                    cur.IDMateria = (int)drCursos["id_materia"];
                    cur.IDComision = (int)drCursos["id_comision"];
                    cur.AnioCalendario = (int)drCursos["anio_calendario"];
                    cur.Descripcion = (string)drCursos["descripcion"];

                    cursos.Add(cur);
                }

                drCursos.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de cursos", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return cursos;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdDelete = new SqlCommand("Delete cursos where id_curso=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                
                Exception ExcepcionManejada = new Exception("Error al eliminar curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }


        protected void Insert(Curso cur)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("insert into cursos(id_materia, id_comision, anio_calendario, cupo, descripcion)" +
                    "values (@id_materia, @id_comision, @anio_calendario, @cupo, @descripcion)" +
                    "select @@identity", sqlConn);
                cmdSave.Parameters.Add("@id_materia", SqlDbType.Int).Value = cur.IDMateria;
                cmdSave.Parameters.Add("@id_comision", SqlDbType.Int).Value = cur.IDComision;
                cmdSave.Parameters.Add("@anio_calendario", SqlDbType.Int).Value = cur.AnioCalendario;
                cmdSave.Parameters.Add("@descripcion", SqlDbType.VarChar, 50).Value = cur.Descripcion;
                cmdSave.Parameters.Add("@cupo", SqlDbType.Int).Value = cur.Cupo;
                cur.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        protected void Update(Curso cur)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE cursos SET id_materia=@id_materia, id_comision=@id_comision, anio_calendario=@anio_calendario, cupo=@cupo " +
                    "WHERE id_curso=@id_curso", sqlConn);
                cmdSave.Parameters.Add("@id_curso", SqlDbType.Int).Value = cur.ID;
                cmdSave.Parameters.Add("@id_materia", SqlDbType.Int).Value = cur.IDMateria;
                cmdSave.Parameters.Add("@id_comision", SqlDbType.Int).Value = cur.IDComision;
                cmdSave.Parameters.Add("@anio_calendario", SqlDbType.Int).Value = cur.AnioCalendario;
                cmdSave.Parameters.Add("@cupo", SqlDbType.Int).Value = cur.Cupo;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos del curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Curso cur)
        {
            if (cur.State == BusinessEntity.States.Deleted)
            {
                this.Delete(cur.ID);

            }
            else if (cur.State == BusinessEntity.States.New)
            {
                this.Insert(cur);
            }
            else if (cur.State == BusinessEntity.States.Modified)
            {
                this.Update(cur);
            }
            cur.State = BusinessEntity.States.Unmodified;
        }

        public int nroCupo(int id)
        {
            Curso elCurso = new Curso();
            elCurso = this.GetOne(id);
            return elCurso.Cupo;
        }

        public void UpdateCupo(int id)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("update cursos set cupo = cupo -1 where id_curso=@id;", sqlConn);
                cmdSave.Parameters.Add("@id_curso", SqlDbType.Int).Value = id;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error el curso no tiene cupo", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }


        #endregion
    }
}