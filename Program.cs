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


      - name: Update ECS Task Definition
        run: |
          aws ecs register-task-definition --family ${{ secrets.ECS_FAMILY }} --container-definitions "$(cat ./container-definition.json)"

      - name: Update ECS Service
        run: |
          aws ecs update-service --cluster ${{ secrets.ECS_CLUSTER }} --service ${{ secrets.ECS_SERVICE }} --task-definition ${{ secrets.ECS_FAMILY }}:latest

      - name: Log out of Amazon ECR
        if: always()
        run: docker logout ${{ steps.login-ecr.outputs.registry }}

*/