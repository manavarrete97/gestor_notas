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
