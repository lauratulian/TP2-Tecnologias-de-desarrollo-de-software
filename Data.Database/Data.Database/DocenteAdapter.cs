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
    public class DocenteAdapter : Adapter
    {
        #region Metodos
        public List<DocenteCurso> GetAll()
        {

            List<DocenteCurso> docentes = new List<DocenteCurso>();
            try
            {

                this.OpenConnection();

                SqlCommand cmdDocente = new SqlCommand("select * from docentes_cursos", sqlConn);


                SqlDataReader drDocentes = cmdDocente.ExecuteReader();

                while (drDocentes.Read())
                {
                    DocenteCurso doc = new DocenteCurso();

                    doc.ID = (int)drDocentes["id_dictado"];
                    doc.IDCurso = (int)drDocentes["id_curso"];
                    doc.IDDocente = (int)drDocentes["id_docente"];
                    doc.Cargo = (int)drDocentes["cargo"];

                    docentes.Add(doc);
                }

                drDocentes.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de docentes", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }


            return docentes;
        }

        public Business.Entities.DocenteCurso GetOne(int ID)
        {
            DocenteCurso doc = new DocenteCurso();
            try
            {
                this.OpenConnection();
                SqlCommand cmdDocentes = new SqlCommand("select * from docentes_cursos where id_dictado=@id", sqlConn);
                cmdDocentes.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drDocentes = cmdDocentes.ExecuteReader();
                if (drDocentes.Read())
                {

                    doc.ID = (int)drDocentes["id_dictado"];
                    doc.IDCurso = (int)drDocentes["id_curso"];
                    doc.IDDocente = (int)drDocentes["id_docente"];
                    doc.Cargo = (int)drDocentes["cargo"];
                }
                drDocentes.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar docente", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return doc;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdDelete = new SqlCommand("Delete docentes_cursos where id_dictado=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar docente", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }


        protected void Insert(DocenteCurso doc)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("insert into docentes_cursos(id_curso, id_docente, cargo)" +
                    "values (@id_curso, @id_docente, @cargo)" +
                    "select @@identity", sqlConn);
                cmdSave.Parameters.Add("@id_curso", SqlDbType.Int).Value = doc.IDCurso;
                cmdSave.Parameters.Add("@id_docente", SqlDbType.VarChar, 50).Value = doc.IDDocente;
                cmdSave.Parameters.Add("@cargo", SqlDbType.Int).Value = doc.Cargo;
                doc.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear Docente", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        protected void Update(DocenteCurso doc)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE docentes_cursos SET id_curso=@id_curso, id_docente=@id_docente" +
                    "cargo=@cargo" +
                    "WHERE id_dictado=@id_dictado", sqlConn);
                cmdSave.Parameters.Add("@id_curso", SqlDbType.Int).Value = doc.IDCurso;
                cmdSave.Parameters.Add("@id_docente", SqlDbType.VarChar, 50).Value = doc.IDDocente;
                cmdSave.Parameters.Add("@cargo", SqlDbType.Int).Value = doc.Cargo;
                cmdSave.Parameters.Add("@id_dictado", SqlDbType.Int).Value = doc.ID;
                cmdSave.ExecuteNonQuery();

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos del docente", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(DocenteCurso doc)
        {
            if (doc.State == BusinessEntity.States.Deleted)
            {
                this.Delete(doc.ID);

            }
            else if (doc.State == BusinessEntity.States.New)
            {
                this.Insert(doc);
            }
            else if (doc.State == BusinessEntity.States.Modified)
            {
                this.Update(doc);
            }
            doc.State = BusinessEntity.States.Unmodified;
        }

        #endregion
    }
}