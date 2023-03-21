using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace PDFGenerator
{
    public static class PDFGeneratorServiceRegistration
    {
        public static IServiceCollection AddPDFGeneratorServices(this IServiceCollection services)
        {
            services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));

            return services;
        }
    }
}
