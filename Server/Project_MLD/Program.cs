using Microsoft.EntityFrameworkCore;
using Project_MLD.Mapper;
using Project_MLD.Models;
using Project_MLD.Service.Interface;
using Project_MLD.Service.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MldDatabaseContext>(option =>
{
    option.UseSqlServer("MyCnn");
});

//Mapper
builder.Services.AddAutoMapper(typeof(MapperConfig));
//Dependacy Injection
builder.Services.AddScoped<IAccountRoleRepository, AccountRoleRepository>();
builder.Services.AddScoped<ICurriculumDistributionRepository, CurriculumDistributionRepository>();
builder.Services.AddScoped<IGradeRepository, GradeRepository>();
builder.Services.AddScoped<ILevelOfTrainningRepository, LevelOfTrainningRepository>();
builder.Services.AddScoped<IPhuLuc1Repository, PhuLuc1Repository>();
builder.Services.AddScoped<IProfessionalStandardRepository, ProfessionalStandardRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<ISelectedTopicsRepository, SelectedTopicRepository>();
builder.Services.AddScoped<ISpecialTeamRepository, SpecialTeamRepository>();
builder.Services.AddScoped<ISubjectRepository, SubjectRepository>();
builder.Services.AddScoped<ISubjectRoomRepository, SubjectRoomRepository>();
builder.Services.AddScoped<ITeachingEquipmentRepository, TeachingEquipmentRepository>();


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

app.UseAuthorization();

app.UseCors(builder =>
{
    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
});

app.MapControllers();

app.Run();
