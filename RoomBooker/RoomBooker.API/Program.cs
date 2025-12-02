using DotNetEnv;
using RoomBooker.API.Middlewares;
using RoomBooker.Infra.IoC;

Env.Load();

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddInfrastructureAPI(builder.Configuration);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
