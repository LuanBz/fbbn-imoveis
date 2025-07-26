using Amazon.DynamoDBv2;
using Amazon.Extensions.NETCore.Setup;
using Amazon.Runtime;
using Amazon;
using Amazon.S3;
using fbbn.API.Services;
using fbbn.API.Repositories;
using Amazon.DynamoDBv2.DataModel;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<IImovelService, ImovelService>();
builder.Services.AddScoped<IImovelRepository, ImovelRepository>();
builder.Services.AddScoped<IS3Service, S3Service>();
builder.Services.AddScoped<ITokenService, TokenService>();

// Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Description = "Insira o token JWT"
    });

    c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
    });
});

// JWT Authentication
builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        var jwtSettings = builder.Configuration.GetSection("JwtSettings");
        var secretKey = jwtSettings["SecretKey"];

        if (string.IsNullOrEmpty(secretKey))
            throw new InvalidOperationException("JWT secret not configured");

        var key = Encoding.ASCII.GetBytes(secretKey);
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(key)
        };
    });
builder.Services.AddAuthorization();

// AWS
builder.Services.AddAWSService<IAmazonS3>();
builder.Services.AddAWSService<IAmazonDynamoDB>();
builder.Services.AddScoped<DynamoDBContext>();
builder.Services.AddDefaultAWSOptions(new AWSOptions
{
    Region = RegionEndpoint.SAEast1,
    Credentials = new BasicAWSCredentials(
        builder.Configuration["AWS:AccessKey"],
        builder.Configuration["AWS:SecretKey"]
    )
}
);

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowPublic",
        policy => policy.WithOrigins("https://fbbn.bzra.dev", "https://admin.fbbn.bzra.dev")
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "fbbn API V1");
        c.RoutePrefix = string.Empty; // Set Swagger UI at the app's root
    });
}

app.UseHttpsRedirection();

app.UseCors("AllowPublic");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
