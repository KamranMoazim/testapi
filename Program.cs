var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

// app.Listen("http://0.0.0.0:9090");  // Set the desired port

app.MapGet("/", () => "Hello World!");

// app.Run();
app.Run("http://0.0.0.0:9090");


// AWS_REGISTRY_URL
// AWS_ACCESS_KEY_ID
// AWS_SECRET_ACCESS_KEY


/*


  push:
    branches:
      - master
  pull_request:
    branches:
      - master



  # Triggers the workflow on push or pull request events but only for the main branch
  push:
    branches: [ master ]
    paths-ignore:
      - README.md
      - .vscode/**
      - .gitignore
  pull_request:
    branches: [ master ]
    paths-ignore:
      - README.md
      - .vscode/**
      - .gitignore
      

*/