using Microsoft.EntityFrameworkCore;
using parcial1_Ap1_BryanOvalle_Recuperacion.Components;
using parcial1_Ap1_BryanOvalle_Recuperacion.DAL;
using parcial1_Ap1_BryanOvalle_Recuperacion.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
	.AddInteractiveServerComponents();

var ConStr = builder.Configuration.GetConnectionString("ConStr");
builder.Services.AddDbContextFactory<Contexto>(options => options.UseSqlite(ConStr));
builder.Services.AddScoped<MetasServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error", createScopeForErrors: true);
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
	.AddInteractiveServerRenderMode();

app.Run();
