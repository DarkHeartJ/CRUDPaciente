using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Paciente
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using(DL.Model1Container context = new DL.Model1Container())
                {
                    var query = context.PacienteGetAll().ToList();

                    if (query.Count > 0)
                    {
                        result.Objects = new List<object>();

                        foreach(var resultPaciente in query)
                        {
                            ML.Paciente paciente = new ML.Paciente();
                            paciente.IdPaciente = resultPaciente.IdPaciente;
                            paciente.Nombre = resultPaciente.Nombre;
                            paciente.AP = resultPaciente.AP;
                            paciente.AM = resultPaciente.AM;
                            paciente.FechaNacimiento = resultPaciente.FechaNacimiento.Value;
                            paciente.FechaIngreso = resultPaciente.FechaIngreso.Value;
                            paciente.TipoSangre = new ML.TipoSangre();
                            paciente.TipoSangre.IdTipoSangre = resultPaciente.IdTipoSangre.Value;
                            paciente.TipoSangre.Nombre = resultPaciente.NombreTipoSangre;
                            paciente.Sexo = resultPaciente.Sexo;
                            paciente.Sintomas = resultPaciente.Sintomas;

                            result.Objects.Add(paciente);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al mostrar los registros." + result.Ex;
            }

            return result;
        }

        public static ML.Result GetById(int idPaciente)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.Model1Container context = new DL.Model1Container())
                {
                    var query = context.PacienteGetById(idPaciente).First();

                    if(query != null)
                    {
                        ML.Paciente paciente = new ML.Paciente();
                        paciente.IdPaciente = query.IdPaciente; 
                        paciente.Nombre = query.Nombre; 
                        paciente.AP = query.AP; 
                        paciente.AM = query.AM;
                        paciente.FechaNacimiento = query.FechaNacimiento.Value; 
                        paciente.FechaIngreso = query.FechaIngreso.Value; 
                        paciente.TipoSangre = new ML.TipoSangre();
                        paciente.TipoSangre.IdTipoSangre = query.IdTipoSangre.Value;
                        paciente.Sexo = query.Sexo;
                        paciente.Sintomas = query.Sintomas;

                        result.Object = paciente;
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al mostrar los registros." + result.Ex;
            }

            return result;
        }

        public static ML.Result Add(ML.Paciente paciente)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.Model1Container context = new DL.Model1Container())
                {
                    var query = context.PacienteAdd(paciente.Nombre, paciente.AP, paciente.AM, paciente.FechaNacimiento,
                        paciente.FechaIngreso, paciente.TipoSangre.IdTipoSangre, paciente.Sexo, paciente.Sintomas);

                    if(query > 0)
                    {
                        result.Correct = true;
                        result.Message = "El registro se inserto correctamente.";
                    }
                }
            }catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al insertar el registro." + result.Ex;
            }

            return result;
        }

        public static ML.Result Update(ML.Paciente paciente)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.Model1Container context = new DL.Model1Container())
                {
                    var query = context.PacienteUpdate(paciente.IdPaciente, paciente.Nombre, paciente.AP, paciente.AM, 
                        paciente.FechaNacimiento,paciente.FechaIngreso, paciente.TipoSangre.IdTipoSangre, paciente.Sexo, 
                        paciente.Sintomas);

                    if(query > 0)
                    {
                        result.Correct = true;
                        result.Message = "El registro se actualizo correctamente.";
                    }
                }
            }catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al actualizar el registro." + result.Ex;
            }

            return result;
        }

        public static ML.Result Delete(ML.Paciente paciente)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.Model1Container context = new DL.Model1Container())
                {
                    var query = context.PacienteDelete(paciente.IdPaciente);

                    if(query > 0)
                    {
                        result.Correct = true;
                        result.Message = "El resgistro se elimino correctamente.";
                    }
                }
            }catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al eliminar el registro." + result.Ex;
            }

            return result;
        }
    }
}
