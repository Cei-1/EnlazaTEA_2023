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
    
    public partial class EnlazaTEA2023Entities1 : DbContext
    {
        public EnlazaTEA2023Entities1()
            : base("name=EnlazaTEA2023Entities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<Cita> Citas { get; set; }
        public virtual DbSet<DetallesCita> DetallesCitas { get; set; }
        public virtual DbSet<Especialista> Especialistas { get; set; }
        public virtual DbSet<Like> Likes { get; set; }
        public virtual DbSet<Multimedia> Multimedias { get; set; }
        public virtual DbSet<Paciente> Pacientes { get; set; }
        public virtual DbSet<Rol> Rols { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
    
        public virtual int ActualizarEstatusCita(Nullable<int> idCita, Nullable<int> estatus)
        {
            var idCitaParameter = idCita.HasValue ?
                new ObjectParameter("IdCita", idCita) :
                new ObjectParameter("IdCita", typeof(int));
    
            var estatusParameter = estatus.HasValue ?
                new ObjectParameter("Estatus", estatus) :
                new ObjectParameter("Estatus", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ActualizarEstatusCita", idCitaParameter, estatusParameter);
        }
    
        public virtual int ActualizarPerfilEspecialista(Nullable<int> idUsuario, string calle, string numeroExterno, string numeroInterno, string ciudad, string estado, string codigoPostal, string telefono, string colonia, string celular)
        {
            var idUsuarioParameter = idUsuario.HasValue ?
                new ObjectParameter("IdUsuario", idUsuario) :
                new ObjectParameter("IdUsuario", typeof(int));
    
            var calleParameter = calle != null ?
                new ObjectParameter("Calle", calle) :
                new ObjectParameter("Calle", typeof(string));
    
            var numeroExternoParameter = numeroExterno != null ?
                new ObjectParameter("NumeroExterno", numeroExterno) :
                new ObjectParameter("NumeroExterno", typeof(string));
    
            var numeroInternoParameter = numeroInterno != null ?
                new ObjectParameter("NumeroInterno", numeroInterno) :
                new ObjectParameter("NumeroInterno", typeof(string));
    
            var ciudadParameter = ciudad != null ?
                new ObjectParameter("Ciudad", ciudad) :
                new ObjectParameter("Ciudad", typeof(string));
    
            var estadoParameter = estado != null ?
                new ObjectParameter("Estado", estado) :
                new ObjectParameter("Estado", typeof(string));
    
            var codigoPostalParameter = codigoPostal != null ?
                new ObjectParameter("CodigoPostal", codigoPostal) :
                new ObjectParameter("CodigoPostal", typeof(string));
    
            var telefonoParameter = telefono != null ?
                new ObjectParameter("Telefono", telefono) :
                new ObjectParameter("Telefono", typeof(string));
    
            var coloniaParameter = colonia != null ?
                new ObjectParameter("Colonia", colonia) :
                new ObjectParameter("Colonia", typeof(string));
    
            var celularParameter = celular != null ?
                new ObjectParameter("Celular", celular) :
                new ObjectParameter("Celular", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ActualizarPerfilEspecialista", idUsuarioParameter, calleParameter, numeroExternoParameter, numeroInternoParameter, ciudadParameter, estadoParameter, codigoPostalParameter, telefonoParameter, coloniaParameter, celularParameter);
        }
    
        public virtual int AddEspecialista(string nombreCarrera, string noCedula, string especialidad, string calle, string numeroExterno, string numeroInterno, string colonia, string ciudad, string estado, string codigoPostal, string telefono, string celular, Nullable<bool> estatus, Nullable<int> idUsuario)
        {
            var nombreCarreraParameter = nombreCarrera != null ?
                new ObjectParameter("NombreCarrera", nombreCarrera) :
                new ObjectParameter("NombreCarrera", typeof(string));
    
            var noCedulaParameter = noCedula != null ?
                new ObjectParameter("NoCedula", noCedula) :
                new ObjectParameter("NoCedula", typeof(string));
    
            var especialidadParameter = especialidad != null ?
                new ObjectParameter("Especialidad", especialidad) :
                new ObjectParameter("Especialidad", typeof(string));
    
            var calleParameter = calle != null ?
                new ObjectParameter("Calle", calle) :
                new ObjectParameter("Calle", typeof(string));
    
            var numeroExternoParameter = numeroExterno != null ?
                new ObjectParameter("NumeroExterno", numeroExterno) :
                new ObjectParameter("NumeroExterno", typeof(string));
    
            var numeroInternoParameter = numeroInterno != null ?
                new ObjectParameter("NumeroInterno", numeroInterno) :
                new ObjectParameter("NumeroInterno", typeof(string));
    
            var coloniaParameter = colonia != null ?
                new ObjectParameter("Colonia", colonia) :
                new ObjectParameter("Colonia", typeof(string));
    
            var ciudadParameter = ciudad != null ?
                new ObjectParameter("Ciudad", ciudad) :
                new ObjectParameter("Ciudad", typeof(string));
    
            var estadoParameter = estado != null ?
                new ObjectParameter("Estado", estado) :
                new ObjectParameter("Estado", typeof(string));
    
            var codigoPostalParameter = codigoPostal != null ?
                new ObjectParameter("CodigoPostal", codigoPostal) :
                new ObjectParameter("CodigoPostal", typeof(string));
    
            var telefonoParameter = telefono != null ?
                new ObjectParameter("Telefono", telefono) :
                new ObjectParameter("Telefono", typeof(string));
    
            var celularParameter = celular != null ?
                new ObjectParameter("Celular", celular) :
                new ObjectParameter("Celular", typeof(string));
    
            var estatusParameter = estatus.HasValue ?
                new ObjectParameter("Estatus", estatus) :
                new ObjectParameter("Estatus", typeof(bool));
    
            var idUsuarioParameter = idUsuario.HasValue ?
                new ObjectParameter("IdUsuario", idUsuario) :
                new ObjectParameter("IdUsuario", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddEspecialista", nombreCarreraParameter, noCedulaParameter, especialidadParameter, calleParameter, numeroExternoParameter, numeroInternoParameter, coloniaParameter, ciudadParameter, estadoParameter, codigoPostalParameter, telefonoParameter, celularParameter, estatusParameter, idUsuarioParameter);
        }
    
        public virtual int AddUsuario(string nombre, string apellidoPaterno, string apellidoMaterno, Nullable<System.DateTime> fechaNacimiento, string email, string contraseña, Nullable<int> idRol)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var apellidoPaternoParameter = apellidoPaterno != null ?
                new ObjectParameter("ApellidoPaterno", apellidoPaterno) :
                new ObjectParameter("ApellidoPaterno", typeof(string));
    
            var apellidoMaternoParameter = apellidoMaterno != null ?
                new ObjectParameter("ApellidoMaterno", apellidoMaterno) :
                new ObjectParameter("ApellidoMaterno", typeof(string));
    
            var fechaNacimientoParameter = fechaNacimiento.HasValue ?
                new ObjectParameter("FechaNacimiento", fechaNacimiento) :
                new ObjectParameter("FechaNacimiento", typeof(System.DateTime));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var contraseñaParameter = contraseña != null ?
                new ObjectParameter("Contraseña", contraseña) :
                new ObjectParameter("Contraseña", typeof(string));
    
            var idRolParameter = idRol.HasValue ?
                new ObjectParameter("IdRol", idRol) :
                new ObjectParameter("IdRol", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddUsuario", nombreParameter, apellidoPaternoParameter, apellidoMaternoParameter, fechaNacimientoParameter, emailParameter, contraseñaParameter, idRolParameter);
        }
    
        public virtual int AgregarCita(Nullable<int> idUsuario, Nullable<int> idEspecialista, Nullable<System.DateTime> fecha, Nullable<System.TimeSpan> horario, Nullable<int> estatus)
        {
            var idUsuarioParameter = idUsuario.HasValue ?
                new ObjectParameter("IdUsuario", idUsuario) :
                new ObjectParameter("IdUsuario", typeof(int));
    
            var idEspecialistaParameter = idEspecialista.HasValue ?
                new ObjectParameter("IdEspecialista", idEspecialista) :
                new ObjectParameter("IdEspecialista", typeof(int));
    
            var fechaParameter = fecha.HasValue ?
                new ObjectParameter("Fecha", fecha) :
                new ObjectParameter("Fecha", typeof(System.DateTime));
    
            var horarioParameter = horario.HasValue ?
                new ObjectParameter("Horario", horario) :
                new ObjectParameter("Horario", typeof(System.TimeSpan));
    
            var estatusParameter = estatus.HasValue ?
                new ObjectParameter("Estatus", estatus) :
                new ObjectParameter("Estatus", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AgregarCita", idUsuarioParameter, idEspecialistaParameter, fechaParameter, horarioParameter, estatusParameter);
        }
    
        public virtual int AgregarPaciente(string nombre, string apellidoPaterno, string apellidoMaterno, string parentesco, Nullable<int> nivelTDA, Nullable<bool> sexo, Nullable<int> edad, string calle, string numeroExterior, string numeroInterior, string colonia, string municipio, string estado, string cP, string escolaridad, Nullable<int> idUsuario)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var apellidoPaternoParameter = apellidoPaterno != null ?
                new ObjectParameter("ApellidoPaterno", apellidoPaterno) :
                new ObjectParameter("ApellidoPaterno", typeof(string));
    
            var apellidoMaternoParameter = apellidoMaterno != null ?
                new ObjectParameter("ApellidoMaterno", apellidoMaterno) :
                new ObjectParameter("ApellidoMaterno", typeof(string));
    
            var parentescoParameter = parentesco != null ?
                new ObjectParameter("Parentesco", parentesco) :
                new ObjectParameter("Parentesco", typeof(string));
    
            var nivelTDAParameter = nivelTDA.HasValue ?
                new ObjectParameter("NivelTDA", nivelTDA) :
                new ObjectParameter("NivelTDA", typeof(int));
    
            var sexoParameter = sexo.HasValue ?
                new ObjectParameter("Sexo", sexo) :
                new ObjectParameter("Sexo", typeof(bool));
    
            var edadParameter = edad.HasValue ?
                new ObjectParameter("Edad", edad) :
                new ObjectParameter("Edad", typeof(int));
    
            var calleParameter = calle != null ?
                new ObjectParameter("Calle", calle) :
                new ObjectParameter("Calle", typeof(string));
    
            var numeroExteriorParameter = numeroExterior != null ?
                new ObjectParameter("NumeroExterior", numeroExterior) :
                new ObjectParameter("NumeroExterior", typeof(string));
    
            var numeroInteriorParameter = numeroInterior != null ?
                new ObjectParameter("NumeroInterior", numeroInterior) :
                new ObjectParameter("NumeroInterior", typeof(string));
    
            var coloniaParameter = colonia != null ?
                new ObjectParameter("Colonia", colonia) :
                new ObjectParameter("Colonia", typeof(string));
    
            var municipioParameter = municipio != null ?
                new ObjectParameter("Municipio", municipio) :
                new ObjectParameter("Municipio", typeof(string));
    
            var estadoParameter = estado != null ?
                new ObjectParameter("Estado", estado) :
                new ObjectParameter("Estado", typeof(string));
    
            var cPParameter = cP != null ?
                new ObjectParameter("CP", cP) :
                new ObjectParameter("CP", typeof(string));
    
            var escolaridadParameter = escolaridad != null ?
                new ObjectParameter("Escolaridad", escolaridad) :
                new ObjectParameter("Escolaridad", typeof(string));
    
            var idUsuarioParameter = idUsuario.HasValue ?
                new ObjectParameter("IdUsuario", idUsuario) :
                new ObjectParameter("IdUsuario", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AgregarPaciente", nombreParameter, apellidoPaternoParameter, apellidoMaternoParameter, parentescoParameter, nivelTDAParameter, sexoParameter, edadParameter, calleParameter, numeroExteriorParameter, numeroInteriorParameter, coloniaParameter, municipioParameter, estadoParameter, cPParameter, escolaridadParameter, idUsuarioParameter);
        }
    
        public virtual int BlogAdd(string titulo, string nombre, string descripcion, byte[] imagen)
        {
            var tituloParameter = titulo != null ?
                new ObjectParameter("Titulo", titulo) :
                new ObjectParameter("Titulo", typeof(string));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var descripcionParameter = descripcion != null ?
                new ObjectParameter("Descripcion", descripcion) :
                new ObjectParameter("Descripcion", typeof(string));
    
            var imagenParameter = imagen != null ?
                new ObjectParameter("Imagen", imagen) :
                new ObjectParameter("Imagen", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("BlogAdd", tituloParameter, nombreParameter, descripcionParameter, imagenParameter);
        }
    
        public virtual int BlogDelete(Nullable<int> idBlog)
        {
            var idBlogParameter = idBlog.HasValue ?
                new ObjectParameter("IdBlog", idBlog) :
                new ObjectParameter("IdBlog", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("BlogDelete", idBlogParameter);
        }
    
        public virtual ObjectResult<BlogGetAll_Result> BlogGetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<BlogGetAll_Result>("BlogGetAll");
        }
    
        public virtual ObjectResult<BlogGetById_Result> BlogGetById(Nullable<int> idBlog)
        {
            var idBlogParameter = idBlog.HasValue ?
                new ObjectParameter("IdBlog", idBlog) :
                new ObjectParameter("IdBlog", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<BlogGetById_Result>("BlogGetById", idBlogParameter);
        }
    
        public virtual ObjectResult<BlogGetByUser_Result> BlogGetByUser(Nullable<int> idUsuario)
        {
            var idUsuarioParameter = idUsuario.HasValue ?
                new ObjectParameter("IdUsuario", idUsuario) :
                new ObjectParameter("IdUsuario", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<BlogGetByUser_Result>("BlogGetByUser", idUsuarioParameter);
        }
    
        public virtual int BlogUpdate(Nullable<int> idBlog, string titulo, string nombre, string descripcion, byte[] imagen)
        {
            var idBlogParameter = idBlog.HasValue ?
                new ObjectParameter("IdBlog", idBlog) :
                new ObjectParameter("IdBlog", typeof(int));
    
            var tituloParameter = titulo != null ?
                new ObjectParameter("Titulo", titulo) :
                new ObjectParameter("Titulo", typeof(string));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var descripcionParameter = descripcion != null ?
                new ObjectParameter("Descripcion", descripcion) :
                new ObjectParameter("Descripcion", typeof(string));
    
            var imagenParameter = imagen != null ?
                new ObjectParameter("Imagen", imagen) :
                new ObjectParameter("Imagen", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("BlogUpdate", idBlogParameter, tituloParameter, nombreParameter, descripcionParameter, imagenParameter);
        }
    
        public virtual ObjectResult<BuscarCitasPorIdEspecialista_Result> BuscarCitasPorIdEspecialista(Nullable<int> idEspecialista)
        {
            var idEspecialistaParameter = idEspecialista.HasValue ?
                new ObjectParameter("IdEspecialista", idEspecialista) :
                new ObjectParameter("IdEspecialista", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<BuscarCitasPorIdEspecialista_Result>("BuscarCitasPorIdEspecialista", idEspecialistaParameter);
        }
    
        public virtual ObjectResult<BuscarCitasPorIdUsuario_Result> BuscarCitasPorIdUsuario(Nullable<int> idUsuario)
        {
            var idUsuarioParameter = idUsuario.HasValue ?
                new ObjectParameter("IdUsuario", idUsuario) :
                new ObjectParameter("IdUsuario", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<BuscarCitasPorIdUsuario_Result>("BuscarCitasPorIdUsuario", idUsuarioParameter);
        }
    
        public virtual ObjectResult<BuscarPacientePorIdUsuario_Result> BuscarPacientePorIdUsuario(Nullable<int> idUsuario)
        {
            var idUsuarioParameter = idUsuario.HasValue ?
                new ObjectParameter("IdUsuario", idUsuario) :
                new ObjectParameter("IdUsuario", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<BuscarPacientePorIdUsuario_Result>("BuscarPacientePorIdUsuario", idUsuarioParameter);
        }
    
        public virtual ObjectResult<BuscarSolicitudCitasPorIdEspecialista_Result> BuscarSolicitudCitasPorIdEspecialista(Nullable<int> idEspecialista)
        {
            var idEspecialistaParameter = idEspecialista.HasValue ?
                new ObjectParameter("IdEspecialista", idEspecialista) :
                new ObjectParameter("IdEspecialista", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<BuscarSolicitudCitasPorIdEspecialista_Result>("BuscarSolicitudCitasPorIdEspecialista", idEspecialistaParameter);
        }
    
        public virtual ObjectResult<ConsultarEspecialistasInactivos_Result> ConsultarEspecialistasInactivos()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ConsultarEspecialistasInactivos_Result>("ConsultarEspecialistasInactivos");
        }
    
        public virtual ObjectResult<GetAllEspecialistas_Result> GetAllEspecialistas()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetAllEspecialistas_Result>("GetAllEspecialistas");
        }
    
        public virtual ObjectResult<GetAllRol_Result> GetAllRol()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetAllRol_Result>("GetAllRol");
        }
    
        public virtual ObjectResult<GetPacienteByIdUsuario_Result> GetPacienteByIdUsuario(Nullable<int> idUsuario)
        {
            var idUsuarioParameter = idUsuario.HasValue ?
                new ObjectParameter("IdUsuario", idUsuario) :
                new ObjectParameter("IdUsuario", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetPacienteByIdUsuario_Result>("GetPacienteByIdUsuario", idUsuarioParameter);
        }
    
        public virtual ObjectResult<GetUserById_Result> GetUserById(Nullable<int> idUsuario)
        {
            var idUsuarioParameter = idUsuario.HasValue ?
                new ObjectParameter("IdUsuario", idUsuario) :
                new ObjectParameter("IdUsuario", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetUserById_Result>("GetUserById", idUsuarioParameter);
        }
    
        public virtual ObjectResult<GetUsuarioByEmail_Result> GetUsuarioByEmail(string email)
        {
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetUsuarioByEmail_Result>("GetUsuarioByEmail", emailParameter);
        }
    
        public virtual int MultimediaAdd(string titulo, string contenido, byte[] imagen, string tipo, string videoID, byte[] audio, Nullable<int> idUsuario)
        {
            var tituloParameter = titulo != null ?
                new ObjectParameter("Titulo", titulo) :
                new ObjectParameter("Titulo", typeof(string));
    
            var contenidoParameter = contenido != null ?
                new ObjectParameter("Contenido", contenido) :
                new ObjectParameter("Contenido", typeof(string));
    
            var imagenParameter = imagen != null ?
                new ObjectParameter("Imagen", imagen) :
                new ObjectParameter("Imagen", typeof(byte[]));
    
            var tipoParameter = tipo != null ?
                new ObjectParameter("Tipo", tipo) :
                new ObjectParameter("Tipo", typeof(string));
    
            var videoIDParameter = videoID != null ?
                new ObjectParameter("VideoID", videoID) :
                new ObjectParameter("VideoID", typeof(string));
    
            var audioParameter = audio != null ?
                new ObjectParameter("Audio", audio) :
                new ObjectParameter("Audio", typeof(byte[]));
    
            var idUsuarioParameter = idUsuario.HasValue ?
                new ObjectParameter("IdUsuario", idUsuario) :
                new ObjectParameter("IdUsuario", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MultimediaAdd", tituloParameter, contenidoParameter, imagenParameter, tipoParameter, videoIDParameter, audioParameter, idUsuarioParameter);
        }
    
        public virtual int MultimediaDelete(Nullable<int> idMultimedia)
        {
            var idMultimediaParameter = idMultimedia.HasValue ?
                new ObjectParameter("IdMultimedia", idMultimedia) :
                new ObjectParameter("IdMultimedia", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MultimediaDelete", idMultimediaParameter);
        }
    
        public virtual ObjectResult<MultimediaGetAll_Result> MultimediaGetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MultimediaGetAll_Result>("MultimediaGetAll");
        }
    
        public virtual ObjectResult<MultimediaGetById_Result> MultimediaGetById(Nullable<int> idMultimedia)
        {
            var idMultimediaParameter = idMultimedia.HasValue ?
                new ObjectParameter("IdMultimedia", idMultimedia) :
                new ObjectParameter("IdMultimedia", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MultimediaGetById_Result>("MultimediaGetById", idMultimediaParameter);
        }
    
        public virtual ObjectResult<MultimediaGetByUser_Result> MultimediaGetByUser(Nullable<int> idUsuario)
        {
            var idUsuarioParameter = idUsuario.HasValue ?
                new ObjectParameter("IdUsuario", idUsuario) :
                new ObjectParameter("IdUsuario", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MultimediaGetByUser_Result>("MultimediaGetByUser", idUsuarioParameter);
        }
    
        public virtual int MultimediaUpdate(Nullable<int> idMultimedia, string titulo, string contenido, byte[] imagen, string tipo, string videoID, byte[] audio)
        {
            var idMultimediaParameter = idMultimedia.HasValue ?
                new ObjectParameter("IdMultimedia", idMultimedia) :
                new ObjectParameter("IdMultimedia", typeof(int));
    
            var tituloParameter = titulo != null ?
                new ObjectParameter("Titulo", titulo) :
                new ObjectParameter("Titulo", typeof(string));
    
            var contenidoParameter = contenido != null ?
                new ObjectParameter("Contenido", contenido) :
                new ObjectParameter("Contenido", typeof(string));
    
            var imagenParameter = imagen != null ?
                new ObjectParameter("Imagen", imagen) :
                new ObjectParameter("Imagen", typeof(byte[]));
    
            var tipoParameter = tipo != null ?
                new ObjectParameter("Tipo", tipo) :
                new ObjectParameter("Tipo", typeof(string));
    
            var videoIDParameter = videoID != null ?
                new ObjectParameter("VideoID", videoID) :
                new ObjectParameter("VideoID", typeof(string));
    
            var audioParameter = audio != null ?
                new ObjectParameter("Audio", audio) :
                new ObjectParameter("Audio", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MultimediaUpdate", idMultimediaParameter, tituloParameter, contenidoParameter, imagenParameter, tipoParameter, videoIDParameter, audioParameter);
        }
    
        public virtual ObjectResult<sp_BuscarEspecialistaPorIdUsuario_Result> sp_BuscarEspecialistaPorIdUsuario(Nullable<int> idUsuario)
        {
            var idUsuarioParameter = idUsuario.HasValue ?
                new ObjectParameter("IdUsuario", idUsuario) :
                new ObjectParameter("IdUsuario", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_BuscarEspecialistaPorIdUsuario_Result>("sp_BuscarEspecialistaPorIdUsuario", idUsuarioParameter);
        }
    
        public virtual int UpdatePaciente(Nullable<int> idPaciente, string nombre, string apellidoPaterno, string apellidoMaterno, string parentesco, Nullable<int> nivelTDA, Nullable<bool> sexo, Nullable<int> edad, string calle, string numeroExterior, string numeroInterior, string colonia, string municipio, string estado, string cP, string escolaridad)
        {
            var idPacienteParameter = idPaciente.HasValue ?
                new ObjectParameter("IdPaciente", idPaciente) :
                new ObjectParameter("IdPaciente", typeof(int));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var apellidoPaternoParameter = apellidoPaterno != null ?
                new ObjectParameter("ApellidoPaterno", apellidoPaterno) :
                new ObjectParameter("ApellidoPaterno", typeof(string));
    
            var apellidoMaternoParameter = apellidoMaterno != null ?
                new ObjectParameter("ApellidoMaterno", apellidoMaterno) :
                new ObjectParameter("ApellidoMaterno", typeof(string));
    
            var parentescoParameter = parentesco != null ?
                new ObjectParameter("Parentesco", parentesco) :
                new ObjectParameter("Parentesco", typeof(string));
    
            var nivelTDAParameter = nivelTDA.HasValue ?
                new ObjectParameter("NivelTDA", nivelTDA) :
                new ObjectParameter("NivelTDA", typeof(int));
    
            var sexoParameter = sexo.HasValue ?
                new ObjectParameter("Sexo", sexo) :
                new ObjectParameter("Sexo", typeof(bool));
    
            var edadParameter = edad.HasValue ?
                new ObjectParameter("Edad", edad) :
                new ObjectParameter("Edad", typeof(int));
    
            var calleParameter = calle != null ?
                new ObjectParameter("Calle", calle) :
                new ObjectParameter("Calle", typeof(string));
    
            var numeroExteriorParameter = numeroExterior != null ?
                new ObjectParameter("NumeroExterior", numeroExterior) :
                new ObjectParameter("NumeroExterior", typeof(string));
    
            var numeroInteriorParameter = numeroInterior != null ?
                new ObjectParameter("NumeroInterior", numeroInterior) :
                new ObjectParameter("NumeroInterior", typeof(string));
    
            var coloniaParameter = colonia != null ?
                new ObjectParameter("Colonia", colonia) :
                new ObjectParameter("Colonia", typeof(string));
    
            var municipioParameter = municipio != null ?
                new ObjectParameter("Municipio", municipio) :
                new ObjectParameter("Municipio", typeof(string));
    
            var estadoParameter = estado != null ?
                new ObjectParameter("Estado", estado) :
                new ObjectParameter("Estado", typeof(string));
    
            var cPParameter = cP != null ?
                new ObjectParameter("CP", cP) :
                new ObjectParameter("CP", typeof(string));
    
            var escolaridadParameter = escolaridad != null ?
                new ObjectParameter("Escolaridad", escolaridad) :
                new ObjectParameter("Escolaridad", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdatePaciente", idPacienteParameter, nombreParameter, apellidoPaternoParameter, apellidoMaternoParameter, parentescoParameter, nivelTDAParameter, sexoParameter, edadParameter, calleParameter, numeroExteriorParameter, numeroInteriorParameter, coloniaParameter, municipioParameter, estadoParameter, cPParameter, escolaridadParameter);
        }
    
        public virtual int UpdateUser(Nullable<int> idUsuario, string nombre, string apellidoPaterno, string apellidoMaterno, Nullable<System.DateTime> fechaNacimiento, string email, string contraseña)
        {
            var idUsuarioParameter = idUsuario.HasValue ?
                new ObjectParameter("IdUsuario", idUsuario) :
                new ObjectParameter("IdUsuario", typeof(int));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var apellidoPaternoParameter = apellidoPaterno != null ?
                new ObjectParameter("ApellidoPaterno", apellidoPaterno) :
                new ObjectParameter("ApellidoPaterno", typeof(string));
    
            var apellidoMaternoParameter = apellidoMaterno != null ?
                new ObjectParameter("ApellidoMaterno", apellidoMaterno) :
                new ObjectParameter("ApellidoMaterno", typeof(string));
    
            var fechaNacimientoParameter = fechaNacimiento.HasValue ?
                new ObjectParameter("FechaNacimiento", fechaNacimiento) :
                new ObjectParameter("FechaNacimiento", typeof(System.DateTime));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var contraseñaParameter = contraseña != null ?
                new ObjectParameter("Contraseña", contraseña) :
                new ObjectParameter("Contraseña", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdateUser", idUsuarioParameter, nombreParameter, apellidoPaternoParameter, apellidoMaternoParameter, fechaNacimientoParameter, emailParameter, contraseñaParameter);
        }
    }
}
