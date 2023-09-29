using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;
using Service;

namespace FrotaWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();


            builder.Services.AddTransient<IPessoaService, PessoaService>();
            builder.Services.AddTransient<IFrotaService, FrotaService>();
            builder.Services.AddTransient<IMarcaPecaInsumoService, MarcaPecaInsumoService>();
            builder.Services.AddTransient<IModeloVeiculoService, ModeloVeiculoService>();
            builder.Services.AddTransient<IPecaInsumoService, PecaInsumoService>();
            builder.Services.AddTransient<IVeiculoService, VeiculoService>();
            builder.Services.AddTransient<IAbastecimentoService, AbastecimentoService>();
            builder.Services.AddTransient<IFornecedorService, FornecedorService>();
            builder.Services.AddTransient<ISolicitacaomanutencaoService, SolicitacaomanutencaoService>();

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            builder.Services.AddDbContext<FrotaContext>(
                options => options.UseMySQL(builder.Configuration.GetConnectionString("FrotaDatabase")));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Abastecimento}/{action=Index}/{id?}");

            app.Run();
        }
    }
}

