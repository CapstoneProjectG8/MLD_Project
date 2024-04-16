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
using Project_MLD.Utils.GmailSender;
using Amazon;
using Amazon.Extensions.NETCore.Setup;
using Amazon.Runtime;
using Amazon.S3;


var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional:false,reloadOnChange:true).Build();

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

//Configuage AWS S3 client
var awsSettings = configuration.GetSection("AWS");
var credential = new BasicAWSCredentials(awsSettings["AccessKeyId"], awsSettings["SecretAccessKey"]);

//Configuage AWS options
var awsOptions = configuration.GetAWSOptions();
awsOptions.Credentials = credential;
awsOptions.Region = RegionEndpoint.APSoutheast2;
builder.Services.AddDefaultAWSOptions(awsOptions);

//Add the AWS S3 Service
builder.Services.AddAWSService<IAmazonS3>();


//Admin
builder.Services.AddScoped<IAdminRepository, AdminRepository>();
//User-Account-Role
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ISpecializedDepartmentRepository, SpecializedDepartmentRepository>();
builder.Services.AddScoped<ISubjectRepository, SubjectRepository>();
builder.Services.AddScoped<IProfessionalStandardRepository, ProfessionalStandardRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<ILevelOfTrainningRepository, LevelOfTrainningRepository>();

builder.Services.AddScoped<IClassRepository, ClassRepository>();
//Document1
builder.Services.AddScoped<IDocument1Repository, Document1Repository>();
builder.Services.AddScoped<IDocument1CuriculumDistributionRepository, Document1CuriculumDistributionRepository>();
builder.Services.AddScoped<IDocument1PeriodicAssessmentRepository, Document1PeriodicAssessmentRepository>();
builder.Services.AddScoped<IDocument1SelectedTopicsRepository, Document1SelectedTopicsRepository>();
builder.Services.AddScoped<IDocument1TeachingEquipmentRepository, Document1TeachingEquipmentRepository>();
builder.Services.AddScoped<IDocument1SubjectRoomsRepository, Document1SubjectRoomsRepository>();

builder.Services.AddScoped<ISelectedTopicsRepository, SelectedTopicRepository>();
builder.Services.AddScoped<ISubjectRoomRepository, SubjectRoomRepository>();
builder.Services.AddScoped<ITeachingEquipmentRepository, TeachingEquipmentRepository>();
builder.Services.AddScoped<ICurriculumDistributionRepository, CurriculumDistributionRepository>();

//Document2
builder.Services.AddScoped<IDocument2Repository, Document2Repository>();
builder.Services.AddScoped<IDocument2GradeRepository, Document2GradeRepository>();
builder.Services.AddScoped<IGradeRepository, GradeRepository>();
//Document3
builder.Services.AddScoped<IDocument3Repository, Document3Repository>();
builder.Services.AddScoped<IDocument3CurriculumDistributionRepository, Document3CuriculumDistributionRepository>();
builder.Services.AddScoped<IDocument3SelectedTopicsRepository, Document3SelectedTopicsRepository>();
//Document4
builder.Services.AddScoped<IDocument4Repository, Document4Repository>();
builder.Services.AddScoped<ITeachingPlannerRepository, TeachingPlannerRepository>();

//Document5
builder.Services.AddScoped<IDocument5Repository, Document5Repository>();
//Document

//Utils
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
builder.Services.AddTransient<IEmailSender, EmailSender>();
builder.Services.AddTransient<IMailBody, MailBody>();


//ADD CORS
builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//app.UseSwagger();
//app.UseSwaggerUI(c =>
//{
//    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Project MLD API");
//    c.RoutePrefix = string.Empty;
//});
///swagger/v1/swagger.json

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseCors(builder =>
{
    builder.WithOrigins("http://localhost:3002")
           .AllowAnyMethod()
           .AllowAnyHeader()
           .AllowCredentials();
});

app.MapControllers();

app.Run();
