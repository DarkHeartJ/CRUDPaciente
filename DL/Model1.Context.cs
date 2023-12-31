﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class Model1Container : DbContext
    {
        public Model1Container()
            : base("name=Model1Container")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Paciente> Pacientes { get; set; }
        public virtual DbSet<TipoSangre> TipoSangres { get; set; }
    
        public virtual int PacienteAdd(string nombre, string aP, string aM, Nullable<System.DateTime> fechaNacimiento, Nullable<System.DateTime> fechaIngreso, Nullable<byte> idTipoSangre, string sexo, string sintomas)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var aPParameter = aP != null ?
                new ObjectParameter("AP", aP) :
                new ObjectParameter("AP", typeof(string));
    
            var aMParameter = aM != null ?
                new ObjectParameter("AM", aM) :
                new ObjectParameter("AM", typeof(string));
    
            var fechaNacimientoParameter = fechaNacimiento.HasValue ?
                new ObjectParameter("FechaNacimiento", fechaNacimiento) :
                new ObjectParameter("FechaNacimiento", typeof(System.DateTime));
    
            var fechaIngresoParameter = fechaIngreso.HasValue ?
                new ObjectParameter("FechaIngreso", fechaIngreso) :
                new ObjectParameter("FechaIngreso", typeof(System.DateTime));
    
            var idTipoSangreParameter = idTipoSangre.HasValue ?
                new ObjectParameter("IdTipoSangre", idTipoSangre) :
                new ObjectParameter("IdTipoSangre", typeof(byte));
    
            var sexoParameter = sexo != null ?
                new ObjectParameter("Sexo", sexo) :
                new ObjectParameter("Sexo", typeof(string));
    
            var sintomasParameter = sintomas != null ?
                new ObjectParameter("Sintomas", sintomas) :
                new ObjectParameter("Sintomas", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PacienteAdd", nombreParameter, aPParameter, aMParameter, fechaNacimientoParameter, fechaIngresoParameter, idTipoSangreParameter, sexoParameter, sintomasParameter);
        }
    
        public virtual int PacienteDelete(Nullable<int> idPaciente)
        {
            var idPacienteParameter = idPaciente.HasValue ?
                new ObjectParameter("IdPaciente", idPaciente) :
                new ObjectParameter("IdPaciente", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PacienteDelete", idPacienteParameter);
        }
    
        public virtual ObjectResult<PacienteGetAll_Result> PacienteGetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<PacienteGetAll_Result>("PacienteGetAll");
        }
    
        public virtual ObjectResult<PacienteGetById_Result> PacienteGetById(Nullable<int> idPaciente)
        {
            var idPacienteParameter = idPaciente.HasValue ?
                new ObjectParameter("IdPaciente", idPaciente) :
                new ObjectParameter("IdPaciente", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<PacienteGetById_Result>("PacienteGetById", idPacienteParameter);
        }
    
        public virtual int PacienteUpdate(Nullable<int> idPaciente, string nombre, string aP, string aM, Nullable<System.DateTime> fechaNacimiento, Nullable<System.DateTime> fechaIngreso, Nullable<byte> idTipoSangre, string sexo, string sintomas)
        {
            var idPacienteParameter = idPaciente.HasValue ?
                new ObjectParameter("IdPaciente", idPaciente) :
                new ObjectParameter("IdPaciente", typeof(int));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var aPParameter = aP != null ?
                new ObjectParameter("AP", aP) :
                new ObjectParameter("AP", typeof(string));
    
            var aMParameter = aM != null ?
                new ObjectParameter("AM", aM) :
                new ObjectParameter("AM", typeof(string));
    
            var fechaNacimientoParameter = fechaNacimiento.HasValue ?
                new ObjectParameter("FechaNacimiento", fechaNacimiento) :
                new ObjectParameter("FechaNacimiento", typeof(System.DateTime));
    
            var fechaIngresoParameter = fechaIngreso.HasValue ?
                new ObjectParameter("FechaIngreso", fechaIngreso) :
                new ObjectParameter("FechaIngreso", typeof(System.DateTime));
    
            var idTipoSangreParameter = idTipoSangre.HasValue ?
                new ObjectParameter("IdTipoSangre", idTipoSangre) :
                new ObjectParameter("IdTipoSangre", typeof(byte));
    
            var sexoParameter = sexo != null ?
                new ObjectParameter("Sexo", sexo) :
                new ObjectParameter("Sexo", typeof(string));
    
            var sintomasParameter = sintomas != null ?
                new ObjectParameter("Sintomas", sintomas) :
                new ObjectParameter("Sintomas", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PacienteUpdate", idPacienteParameter, nombreParameter, aPParameter, aMParameter, fechaNacimientoParameter, fechaIngresoParameter, idTipoSangreParameter, sexoParameter, sintomasParameter);
        }
    
        public virtual ObjectResult<TipoSangreGetAll_Result> TipoSangreGetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<TipoSangreGetAll_Result>("TipoSangreGetAll");
        }
    }
}
