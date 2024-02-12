using Microsoft.EntityFrameworkCore;
using P1_Ap1_LuisManuelDuarte.Components;
using P1_Ap1_LuisManuelDuarte.DAL;
using P1_Ap1_LuisManuelDuarte.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
	.AddInteractiveServerComponents();

var ConStr = builder.Configuration.GetConnectionString("ConStr");

builder.Services.AddDbContext<Contexto>(Options => Options.UseSqlite(ConStr));
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
