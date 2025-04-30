using Infrastructure.DataSource.ApiClient2.Base;
using Microsoft.Extensions.DependencyInjection;
using Shared.AutoGenerator.Code;
using Shared.AutoGenerator.Interfaces;
using Shared.Constants.ArchitecturalLayers;
using Shared.Generator.Code;
using Shared.Helpers;
using System.Reflection;

namespace Infrastructure.Config
{
    public  class InfrastructureGenerator
    {
        //private static string _assemblyPath = Assembly.GetExecutingAssembly().Location;
        private static string appRoot = ArchitecturalLayers.InfrastructureRoot;
        public static void GenerateApiClientTemplates()
        {

            GenerateAllApiClientTemplates($"{appRoot}\\DataSource\\ApiClientFactory\\Nswag\\WebClientApi.cs");

        }
        public static void GenerateRepositoryTemplates()
        {

            var files=FileScanner.GetAllCsFilePaths($"{appRoot}\\DataSource\\ApiClient2");
            foreach(var file in files)
            {
                if(file.Contains("BaseApiClient") || file.Contains("IBuildApiClient"))
                    continue;

                GenerateAllRepositoryTemplates(file);
            }
            //if(files!=null && files.Any())
            //    GenerateAllRepositoryTemplates(files[0]);
        }

        public static void GenerateAllApiClientTemplates(string sourceTemplateFilePath)
        {
            DynamicClassTemplateGenerator.GenerateAllClassTemplate(new GenerationOptions
            {

                SourceTemplateFilePath = sourceTemplateFilePath,
                DestinationRoot = $"{appRoot}",
                DestinationDirectory = "DataSource\\ApiClient2\\",
                BaseClass = "BuildApiClient<T>",
                SourceBaseInterface = "ITApiClient",
                SourceCategoryName = "Client",
                ImplementGenerateInterface = true,
                //ImplementInterfaces = true,
                DestinationCategoryName = "ApiClient",
                NamespaceName = "Infrastructure.DataSource.ApiClient2",
                Interfaces = new List<Type>
                {
                    typeof(ITBaseApiClient)
                },
                Usings = new List<string>
                {
                    "System.Net.Http",
                    "System.Threading.Tasks",
                    "Infrastructure.Nswag",
                    "Infrastructure.Shared.ApiInvoker",
                     "AutoMapper",
                     "Shared.AutoGenerator.Interfaces",
                     "Infrastructure.DataSource.ApiClient2.Base",
                     "Infrastructure.DataSource.ApiClientFactory",
                     "Infrastructure.Shared.ApiInvoker",
                     "Microsoft.Extensions.Configuration",
                 },
                AdditionalCode = @"
  
    public {ClassName}(ClientFactory clientFactory, IMapper mapper, IConfiguration config, 
    IApiInvoker apiInvoker) : base(clientFactory, mapper, config, apiInvoker){

    }
                ",
                MethodContentCode = @"
                
    [RETERN] await apiInvoker.InvokeAsync(async () =>
    {
        var client = await GetApiClient();
        [RETERN]  await client.{InvokeMethodCallback};

    });
                ",

            });
        }

        public static void GenerateAllRepositoryTemplates(string sourceTemplateFilePath)
        {
            DynamicClassTemplateGenerator.GenerateAllClassTemplate(new GenerationOptions
            {
                SourceTemplateFilePath = $"{sourceTemplateFilePath}",
                DestinationRoot = appRoot,
                DestinationDirectory = "Repositories",
                SourceBaseInterface = "ITBaseApiClient",
                SourceCategoryName = "ApiClient",
                ImplementGenerateInterface = true,
                //ImplementOtherInterfacesInClass = true,
                DestinationCategoryName = "Repository",
                NamespaceName = "Infrastructure.Repositories",
                Interfaces = new List<Type>
                {
                    typeof(ITBaseRepository),
                    typeof(ITScope),
                },
                Usings = new List<string>
                {
                    "System.Net.Http",
                    "System.Threading.Tasks",
                    "Infrastructure.Nswag",
                    "Shared.AutoGenerator.Interfaces",
                     "Infrastructure.DataSource.ApiClient2.Base",
                     "Infrastructure.DataSource.ApiClient2",
                     "Microsoft.Extensions.Configuration",
        },
                AdditionalCode = @"
    private readonly {IPropertyType} _apiClient;
    public {ClassName}({IPropertyType} apiClient){
        _apiClient=apiClient;
    }
                ",
                MethodContentCode = @"
                
    [RETERN]  await _apiClient.{InvokeMethodCallback};
                ",

            });
        }

        public  void ReadAllFiles(string rootDirectory, Func<Task> action)
        {
            string[] csFiles = Directory.GetFiles(rootDirectory, "*.cs", SearchOption.AllDirectories);

            // طباعة كل رابط (مسار كامل) للملفات
            foreach (string file in csFiles)
            {
                Console.WriteLine(file);
            }
        }
    }
}
