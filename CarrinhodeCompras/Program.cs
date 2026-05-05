using CarrinhodeCompras.GerenciaArquivos;
using CarrinhodeCompras.Models;
using CarrinhodeCompras.Repository;
using CarrinhodeCompras.Repository.Contract;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpContextAccessor();

//Adicionar a interface como serviço
builder.Services.AddScoped<ILivroRepository, LivroRepository>();
builder.Services.AddScoped<IEmprestimoRepository, EmprestimoRepository>();
builder.Services.AddScoped<IItemRepository, ItemRepository>();

builder.Services.Configure<CookiePolicyOptions>(options =>
{

    options.CheckConsentNeeded = context => true;
    options.MinimumSameSitePolicy = SameSiteMode.None;
});

// Corrigir problema com TEMPDATA para aumentar o tempo de duração
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    // Set a short timeout for easy testing.
    options.IdleTimeout = TimeSpan.FromSeconds(900);
    options.Cookie.HttpOnly = true;
    // Deixar informado para o navegador que a sessão é essencial
    options.Cookie.IsEssential = true;
});
builder.Services.AddMvc().AddSessionStateTempDataProvider();

builder.Services.AddMemoryCache(); // Guardar os dados na memoria

//Add Gerenciador Arquivo como serviços
builder.Services.AddScoped<GerenciadorArquivo>();
builder.Services.AddScoped<CarrinhodeCompras.Cookie.Cookie>();
builder.Services.AddScoped<CarrinhodeCompras.CarrinhoCompra.CookieCarrinhoCompra>();

builder.Services.AddScoped<ILivroRepository, LivroRepository>();
builder.Services.AddScoped<IItemRepository, ItemRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
