using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class TipoSangre
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.Model1Container context = new DL.Model1Container())
                {
                    var query = context.TipoSangreGetAll().ToList();

                    if (query.Count > 0)
                    {
                        result.Objects = new List<object>();

                        foreach (var resultTipoSangre in query)
                        {
                            ML.TipoSangre tipoSangre = new ML.TipoSangre();
                            tipoSangre.IdTipoSangre = resultTipoSangre.IdTipoSangre;
                            tipoSangre.Nombre = resultTipoSangre.Nombre;

                            result.Objects.Add(tipoSangre);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al mostrar los registros." + result.Ex;
            }

            return result;
        }
    }
}
