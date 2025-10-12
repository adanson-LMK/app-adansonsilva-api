using app_adansonsilva_api.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("venta");
if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("Connection string 'venta' not found.");
}
var Configuracion = new Configuracion(connectionString);
builder.Services.AddSingleton(Configuracion);

builder.Services.AddScoped<IProducto, CRUDProducto>();
builder.Services.AddScoped<ICliente, CRUDCliente>();

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
