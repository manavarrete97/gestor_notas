using gestor_notas.Manager.Interface;
using gestor_notas.Manager;
using gestor_notas.DAO.Interface;
using gestor_notas.DAO;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Dependency Injection
builder.Services.AddSingleton<gestor_notas.Common.Interface.IPostgresConnection, gestor_notas.Common.PostgresConnection>();
builder.Services.AddScoped<gestor_notas.DAO.Interface.IPostProfesorDAO, gestor_notas.DAO.PostProfesorDAO>();
builder.Services.AddScoped<gestor_notas.Manager.Interface.IPostProfesorManager, gestor_notas.Manager.PostProfesorManager>();
builder.Services.AddScoped<gestor_notas.DAO.Interface.IGetProfesorDAO, gestor_notas.DAO.GetProfesorDAO>();
builder.Services.AddScoped<gestor_notas.Manager.Interface.IGetProfesorManager, gestor_notas.Manager.GetProfesorManager>();
builder.Services.AddScoped<gestor_notas.DAO.Interface.IDeleteProfesorDAO, gestor_notas.DAO.DeleteProfesorDAO>();
builder.Services.AddScoped<gestor_notas.Manager.Interface.IDeleteProfesorManager, gestor_notas.Manager.DeleteProfesorManager>();
builder.Services.AddScoped<gestor_notas.DAO.Interface.IUpdateProfesorDAO, gestor_notas.DAO.UpdateProfesorDAO>();
builder.Services.AddScoped<gestor_notas.Manager.Interface.IUpdateProfesorManager, gestor_notas.Manager.UpdateProfesorManager>();
// Register Estudiante dependencies
builder.Services.AddScoped<gestor_notas.DAO.Interface.IGetEstudianteDAO, gestor_notas.DAO.GetEstudianteDAO>();
builder.Services.AddScoped<gestor_notas.Manager.Interface.IGetEstudianteManager, gestor_notas.Manager.GetEstudianteManager>();
builder.Services.AddScoped<gestor_notas.Manager.Interface.IPostEstudianteManager, gestor_notas.Manager.PostEstudianteManager>();
builder.Services.AddScoped<gestor_notas.Manager.Interface.IUpdateEstudianteManager, gestor_notas.Manager.UpdateEstudianteManager>();
builder.Services.AddScoped<gestor_notas.Manager.Interface.IDeleteEstudianteManager, gestor_notas.Manager.DeleteEstudianteManager>();
builder.Services.AddScoped<gestor_notas.DAO.Interface.IPostEstudianteDAO, gestor_notas.DAO.PostEstudianteDAO>();
builder.Services.AddScoped<gestor_notas.DAO.Interface.IUpdateEstudianteDAO, gestor_notas.DAO.UpdateEstudianteDAO>();
builder.Services.AddScoped<gestor_notas.DAO.Interface.IDeleteEstudianteDAO, gestor_notas.DAO.DeleteEstudianteDAO>();
// Register Materia dependencies
builder.Services.AddScoped<gestor_notas.DAO.Interface.IGetMateriaDAO, gestor_notas.DAO.GetMateriaDAO>();
builder.Services.AddScoped<gestor_notas.DAO.Interface.IPostMateriaDAO, gestor_notas.DAO.PostMateriaDAO>();
builder.Services.AddScoped<gestor_notas.DAO.Interface.IUpdateMateriaDAO, gestor_notas.DAO.UpdateMateriaDAO>();
builder.Services.AddScoped<gestor_notas.DAO.Interface.IDeleteMateriaDAO, gestor_notas.DAO.DeleteMateriaDAO>();
builder.Services.AddScoped<gestor_notas.Manager.Interface.IGetMateriaManager, gestor_notas.Manager.GetMateriaManager>();
builder.Services.AddScoped<gestor_notas.Manager.Interface.IPostMateriaManager, gestor_notas.Manager.PostMateriaManager>();
builder.Services.AddScoped<gestor_notas.Manager.Interface.IUpdateMateriaManager, gestor_notas.Manager.UpdateMateriaManager>();
builder.Services.AddScoped<gestor_notas.Manager.Interface.IDeleteMateriaManager, gestor_notas.Manager.DeleteMateriaManager>();
// Register Nota dependencies
builder.Services.AddScoped<gestor_notas.DAO.Interface.IGetNotaDAO, gestor_notas.DAO.GetNotaDAO>();
builder.Services.AddScoped<gestor_notas.DAO.Interface.IPostNotaDAO, gestor_notas.DAO.PostNotaDAO>();
builder.Services.AddScoped<gestor_notas.DAO.Interface.IUpdateNotaDAO, gestor_notas.DAO.UpdateNotaDAO>();
builder.Services.AddScoped<gestor_notas.DAO.Interface.IDeleteNotaDAO, gestor_notas.DAO.DeleteNotaDAO>();
builder.Services.AddScoped<gestor_notas.Manager.Interface.IGetNotaManager, gestor_notas.Manager.GetNotaManager>();
builder.Services.AddScoped<gestor_notas.Manager.Interface.IPostNotaManager, gestor_notas.Manager.PostNotaManager>();
builder.Services.AddScoped<gestor_notas.Manager.Interface.IUpdateNotaManager, gestor_notas.Manager.UpdateNotaManager>();
builder.Services.AddScoped<gestor_notas.Manager.Interface.IDeleteNotaManager, gestor_notas.Manager.DeleteNotaManager>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
