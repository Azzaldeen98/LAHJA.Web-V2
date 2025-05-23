using Application.Config;
using Infrastructure.Config;
using LAHJA.Generator;

namespace LAHJA
{
    public static class BuildGeneratorApp
    {
        public static void BuildAllLayers()
        {

            //InfrastructureGenerator.GeneratorCode();
            //ApplicationGenerator.GeneratorCode();
            //WebAppGenerator.GeneratorCode();
            WebAppGenerator.InjectorCode();


        }
    }
}
