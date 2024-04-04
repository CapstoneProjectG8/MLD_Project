using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Project_MLD.Mapper;
using Project_MLD.Models;
using Project_MLD.Service.Interface;
using Project_MLD.Service.Repository;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Project_MLD.DTO;
using Project_MLD.Utils.PasswordHash;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

//DbContext
builder.Services.AddDbContext<MldDatabaseContext>(option =>
{
    option.UseSqlServer("MyCnn");
});

//Mapper
builder.Services.AddAutoMapper(typeof(MapperConfig));

//Dependacy Injection
builder.Services.AddScoped<ICurriculumDistributionRepository, CurriculumDistributionRepository>();
builder.Services.AddScoped<IGradeRepository, GradeRepository>();
builder.Services.AddScoped<ILevelOfTrainningRepository, LevelOfTrainningRepository>();
builder.Services.AddScoped<IDocument1Repository, Document1Repository>();
builder.Services.AddScoped<IProfessionalStandardRepository, ProfessionalStandardRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<ISelectedTopicsRepository, SelectedTopicRepository>();
builder.Services.AddScoped<ISpecializedDepartmentRepository, SpecializedDepartmentRepository>();
builder.Services.AddScoped<ISubjectRepository, SubjectRepository>();
builder.Services.AddScoped<ISubjectRoomRepository, SubjectRoomRepository>();
builder.Services.AddScoped<ITeachingEquipmentRepository, TeachingEquipmentRepository>();
builder.Services.AddScoped<IDocRepository, DocRepository>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();

//ADD CORS
builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseCors(builder =>
{
    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
});

app.MapControllers();

app.Run();
