using ArticoliWebService.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

builder.Services.AddScoped<IArticoliRepository, ArticoliRepository>();

builder.Services.AddCors(options =>
    options.AddPolicy("AllowAngular", policy =>{
        policy.WithOrigins("http://localhost:4200")
        .WithMethods("POST", "GET", "PUT", "DELETE")
        .AllowAnyHeader();
    })
);

var app = builder.Build();

app.UseCors("AllowAngular");

app.MapControllers();

app.Run();
