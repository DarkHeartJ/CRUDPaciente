using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class PacienteController : Controller
    {
        // GET: Paciente
        public ActionResult GetAll()
        {
            ML.Result result = BL.Paciente.GetAll();
            ML.Paciente paciente = new ML.Paciente();

            if (result.Correct)
            {
                paciente.Pacientes = result.Objects;
                return View(paciente);
            }
            else
            {
                ViewBag.Message = result.Message;
                return View(paciente);
            }
        }

        [HttpGet]
        public ActionResult Form(int? idPaciente)
        {
            ML.Result resultTipoSangre = BL.TipoSangre.GetAll();
            ML.Paciente paciente = new ML.Paciente();
            paciente.TipoSangre = new ML.TipoSangre();

            paciente.TipoSangre.TiposSangre = resultTipoSangre.Objects;

            if (idPaciente == null)
            {
                ViewBag.Titulo = "Nuevo Registro";
                ViewBag.Accion = "Agregar";

                return View(paciente);
            }
            else
            {
                ViewBag.Titulo = "Modificar Registro";
                ViewBag.Accion = "Actualizar";

                ML.Result result = BL.Paciente.GetById(idPaciente.Value);

                if (result.Object != null)
                {
                    paciente = (ML.Paciente)result.Object;
                    paciente.TipoSangre.TiposSangre = resultTipoSangre.Objects;

                    return View(paciente);
                }
                else
                {
                    ViewBag.Titulo = "Error";
                    ViewBag.Message = result.Message;
                    return View("Modal");
                }
            }
        }

        [HttpPost]
        public ActionResult Form(ML.Paciente paciente)
        {
            if (paciente.IdPaciente == 0)
            {
                var result = BL.Paciente.Add(paciente);

                if (result.Correct)
                {
                    ViewBag.Message = "El registro se inserto correctamente.";
                    return View("Modal");
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al insertar el registro.";
                    return View("Modal");
                }
            }
            else
            {
                var result = BL.Paciente.Update(paciente);

                if (result.Correct)
                {
                    ViewBag.Message = "El registro se actualizo correctamente.";
                    return View("Modal");
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al actualizar el registro.";
                    return View("Modal");
                }
            }
        }

        [HttpGet]
        public ActionResult Delete(int idPaciente)
        {
            ML.Paciente paciente = new ML.Paciente();
            paciente.IdPaciente = Convert.ToInt32(idPaciente);

            var result = BL.Paciente.Delete(paciente);

            if (result.Correct)
            {
                ViewBag.Message = "El registro se elimino correctamente.";
            }
            else
            {
                ViewBag.Message = "Ocurrio un error al eliminar el registro.";
            }

            return View("Modal");
        }
    }
}