using reports_app_backend.DAL;
using reports_app_backend.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ReportsDBContext>();
builder.Services.AddScoped<TemplateService, TemplateService>();
builder.Services.AddScoped<ReportService, ReportService>();

var app = builder.Build();

var scope = app.Services.CreateScope();
var templateService = scope.ServiceProvider.GetService<TemplateService>();
//templateService.CreateBugReportTemplate();

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
