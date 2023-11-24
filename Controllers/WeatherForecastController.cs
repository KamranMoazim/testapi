using Microsoft.AspNetCore.Mvc;

namespace testapi.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    // [HttpGet(Name = "GetWeatherForecast")]
    [HttpGet]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }

    [HttpGet("GetUserName")]
    public string GetUserName()
    {
        return "Kamran Moazim";
    }
}


// kamrannaseer7654321  -- DOCKERHUB_USERNAME
// -- DOCKERHUB_TOKEN --- dckr_pat_qkh_8w5GMXIzsAxSBI2Msa0PUuQ
// Kamran#500

/*
name: CI-build-push-update-ecs

on:
  workflow_dispatch:

jobs:
  docker:
    runs-on: ubuntu-latest
    steps:
      - name: Checkout
        uses: actions/checkout@v3

      - name: Set up QEMU
        uses: docker/setup-qemu-action@v1

      - name: Set up Docker Buildx
        uses: docker/setup-buildx-action@v1

      - name: Configure AWS Credentials
        uses: aws-actions/configure-aws-credentials@v1
        with:
          aws-access-key-id: ${{ secrets.AWS_ACCESS_KEY_ID }}
          aws-secret-access-key: ${{ secrets.AWS_SECRET_ACCESS_KEY }}
          aws-region: ${{ secrets.AWS_REGION }}

      - name: Log in to Amazon ECR
        id: login-ecr
        uses: aws-actions/amazon-ecr-login@v1
        with:
          registry: ${{ secrets.AWS_ECR_REGISTRY }}
          region: ${{ secrets.AWS_REGION }}
          mask-password: true
          registry-type: public
          skip-logout: false

      - name: Build and push
        uses: docker/build-push-action@v2
        with:
          context: .
          file: ./Dockerfile
          push: true
          tags: ${{ secrets.AWS_ECR_REGISTRY }}:latest, ${{ secrets.AWS_ECR_REGISTRY }}:${{ github.run_number }}

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