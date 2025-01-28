using SignalRChat.Hubs;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSignalR();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// builder.Services.AddCors(options =>
// {
//     options.AddPolicy("AllowAll", builder =>
//     {
//         builder
//             .AllowAnyHeader()
//             .AllowAnyOrigin()
//             // .AllowCredentials()
//             .AllowAnyMethod();
//     });

// });
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy( builder =>
    {
        builder.WithOrigins("http://localhost:5173")
            .AllowAnyHeader()
            // .AllowAnyOrigin()
            .AllowCredentials()
            .AllowAnyMethod();
    });

});

builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseCors("AllowAll");
app.UseCors();

app.UseAuthorization();

app.MapControllers();
app.MapHub<ChatHub>("/chatHub");

app.Run();
