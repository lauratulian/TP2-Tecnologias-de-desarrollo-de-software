using System;
using System.Collections.Generic;
using System.Text;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class AlumnoAdapter : Adapter
    {
        #region Metodos

        public List<AlumnoInscripciones> GetInscripciones(int id)
        {
            List<AlumnoInscripciones> alumnos = new List<AlumnoInscripciones>();
            try
            {

                this.OpenConnection();

                SqlCommand cmdAlumnos = new SqlCommand("select * from alumnos_inscripciones where id_alumno=@id", sqlConn);
                cmdAlumnos.Parameters.Add("@id", SqlDbType.Int).Value = id;
                SqlDataReader drAlumnos = cmdAlumnos.ExecuteReader();

                while (drAlumnos.Read())
                {
                    AlumnoInscripciones alum = new AlumnoInscripciones();
                    alum.ID = (int)drAlumnos["id_inscripcion"];
                    alum.Condicion = (string)drAlumnos["condicion"];
                    alum.Nota = (int)drAlumnos["nota"];
                    alum.IDCurso = (int)drAlumnos["id_curso"];

                    alumnos.Add(alum);
                }

                drAlumnos.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de alumnos", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }


            return alumnos;
        }

        public List<AlumnoInscripciones> GetAll()
        {

            List<AlumnoInscripciones> alumnos = new List<AlumnoInscripciones>();
            try
            {

                this.OpenConnection();

                SqlCommand cmdAlumnos = new SqlCommand("select * from alumnos_inscripciones", sqlConn);


                SqlDataReader drAlumnos = cmdAlumnos.ExecuteReader();

                while (drAlumnos.Read())
                {
                    AlumnoInscripciones alum = new AlumnoInscripciones();
                    alum.ID = (int)drAlumnos["id_inscripcion"];
                    alum.Condicion = (string)drAlumnos["condicion"];
                    alum.Nota = (int)drAlumnos["nota"];
                    alum.IDCurso = (int)drAlumnos["id_curso"];


                    alumnos.Add(alum);
                }

                drAlumnos.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de alumnos", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }


            return alumnos;
        }

        public Business.Entities.AlumnoInscripciones GetOne(int ID)
        {
            AlumnoInscripciones alum = new AlumnoInscripciones();
            try
            {
                this.OpenConnection();
                SqlCommand cmdAlumnos = new SqlCommand("select * from alumnos_inscripciones where id_inscripcion=@id", sqlConn);
                cmdAlumnos.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drAlumnos = cmdAlumnos.ExecuteReader();
                if (drAlumnos.Read())
                {
                    alum.ID = (int)drAlumnos["id_inscripcion"];
                    alum.IDAlumno = (int)drAlumnos["id_alumno"];
                    alum.Condicion = (string)drAlumnos["condicion"];
                    alum.Nota = (int)drAlumnos["nota"];
                    alum.IDCurso = (int)drAlumnos["id_curso"];
                }
                drAlumnos.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar alumno", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return alum;
        }

        public List<AlumnoInscripciones> GetAlumnosDocente(int idDoc)
        {
            List<AlumnoInscripciones> alumnos = new List<AlumnoInscripciones>();
            try
            {

                this.OpenConnection();

                SqlCommand cmdAlumnos = new SqlCommand("select ai.* from docentes_cursos dc inner join cursos cu on cu.id_curso=dc.id_curso inner join alumnos_inscripciones ai on ai.id_curso=cu.id_curso where dc.id_docente=@id;", sqlConn);
                cmdAlumnos.Parameters.Add("@id", SqlDbType.Int).Value = idDoc;

                SqlDataReader drAlumnos = cmdAlumnos.ExecuteReader();

                while (drAlumnos.Read())
                {
                    AlumnoInscripciones alum = new AlumnoInscripciones();

                    alum.ID = (int)drAlumnos["id_inscripcion"];
                    alum.IDCurso = (int)drAlumnos["id_curso"];
                    alum.Nota = (int)drAlumnos["nota"];
                    alum.Condicion = (string)drAlumnos["condicion"];

                    alumnos.Add(alum);
                }

                drAlumnos.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de alumnos", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }


            return alumnos;
        }
        public List<AlumnoInscripciones> GetAlumnosDelCurso(int idCurso)
        {

            List<AlumnoInscripciones> alumnos = new List<AlumnoInscripciones>();
            try
            {

                this.OpenConnection();

                SqlCommand cmdAlumnos = new SqlCommand("select * from alumnos_inscripciones ai where ai.id_curso=@id;", sqlConn);
                cmdAlumnos.Parameters.Add("@id", SqlDbType.Int).Value = idCurso;

                SqlDataReader drAlumnos = cmdAlumnos.ExecuteReader();

                while (drAlumnos.Read())
                {
                    AlumnoInscripciones alum = new AlumnoInscripciones();

                    alum.ID = (int)drAlumnos["id_inscripcion"];
                    alum.IDCurso = (int)drAlumnos["id_curso"];
                    alum.Nota = (int)drAlumnos["nota"];
                    alum.Condicion = (string)drAlumnos["condicion"];

                    alumnos.Add(alum);
                }

                drAlumnos.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de alumnos", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }


            return alumnos;
        }
        public List<Curso> GetCursoDocente(int id)
        {
            List<Curso> cursos = new List<Curso>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdCursos = new SqlCommand("select cu.id_curso, cu.id_materia, cu.id_comision, cu.anio_calendario, cu.descripcion from cursos cu inner join docentes_cursos dc on dc.id_curso=cu.id_curso and dc.id_docente=@id;", sqlConn);
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

                SqlCommand cmdDelete = new SqlCommand("Delete alumnos_inscripciones where id_inscripcion=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar alumno", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }


        protected void Insert(AlumnoInscripciones alumno)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("insert into alumnos_inscripciones(id_curso, condicion, id_alumno ,nota)" +
                    "values (@id_curso, @condicion, @id_alumno, @nota )" +
                    "select @@identity", sqlConn);
                cmdSave.Parameters.Add("@id_curso", SqlDbType.Int).Value = alumno.IDCurso;
                cmdSave.Parameters.Add("@condicion", SqlDbType.VarChar, 50).Value = alumno.Condicion;
                cmdSave.Parameters.Add("@id_alumno", SqlDbType.Int).Value = alumno.IDAlumno;
                cmdSave.Parameters.Add("@nota", SqlDbType.Int).Value = alumno.Nota;
                alumno.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear Alumno", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        protected void Update(AlumnoInscripciones alumno)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE alumnos_inscripciones SET id_curso=@id_curso, condicion=@condicion, nota=@nota WHERE id_inscripcion=@id", sqlConn);


                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = alumno.ID;
                cmdSave.Parameters.Add("id_alumno", SqlDbType.Int).Value = alumno.IDAlumno;
                cmdSave.Parameters.Add("@condicion", SqlDbType.VarChar, 50).Value = alumno.Condicion;
                cmdSave.Parameters.Add("@nota", SqlDbType.Int).Value = alumno.Nota;
                cmdSave.Parameters.Add("@id_curso", SqlDbType.Int).Value = alumno.IDCurso;

                cmdSave.ExecuteNonQuery();

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos del alumno", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void UpdateMark(AlumnoInscripciones alumno)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE alumnos_inscripciones SET  condicion=@condicion, nota=@nota WHERE id_inscripcion=@id", sqlConn);


                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = alumno.ID;
                cmdSave.Parameters.Add("id_alumno", SqlDbType.Int).Value = alumno.IDAlumno;
                cmdSave.Parameters.Add("@condicion", SqlDbType.VarChar, 50).Value = alumno.Condicion;
                cmdSave.Parameters.Add("@nota", SqlDbType.Int).Value = alumno.Nota;
                cmdSave.Parameters.Add("@id_curso", SqlDbType.Int).Value = alumno.IDCurso;


                cmdSave.ExecuteNonQuery();

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos del alumno", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(AlumnoInscripciones alumno)
        {
            if (alumno.State == BusinessEntity.States.Deleted)
            {
                this.Delete(alumno.ID);

            }
            else if (alumno.State == BusinessEntity.States.New)
            {
                this.Insert(alumno);
            }
            else if (alumno.State == BusinessEntity.States.Modified)
            {
                this.Update(alumno);
            }
            else if (alumno.State == BusinessEntity.States.ModifiedMark)
            {
                this.UpdateMark(alumno);
            }
            alumno.State = BusinessEntity.States.Unmodified;
        }
        public void ActualizaNota(int ID, int nota)
        {
            AlumnoInscripciones alu = new AlumnoInscripciones();
            alu = this.GetOne(ID);
            alu.Nota = nota;
            alu.State = BusinessEntity.States.Modified;
            this.Save(alu);
        }

        #endregion
    }
}

