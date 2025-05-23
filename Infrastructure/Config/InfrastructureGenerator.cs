using AutoGenerator.Code;
using Shared.Interfaces;
using Shared.Constants.ArchitecturalLayers;
using Shared.Helpers;


namespace Infrastructure.Config
{
    public  class InfrastructureGenerator
    {
        //private static string _assemblyPath = Assembly.GetExecutingAssembly().Location;
        private static string appRoot = ArchitecturalLayers.InfrastructureRoot;
        private static string sourceFilePath = $"{ArchitecturalLayers.InfrastructureRoot}\\DataSource\\ApiClientFactory\\Nswag\\WebClientApi.cs";
        public static void GeneratorCode()
        {

            InterfaceInjector.InjectInterface(sourceFilePath, "Shared.Interfaces.ITApiClient", "Client");
            InterfaceInjector.InjectInterface(sourceFilePath, "Shared.Interfaces.ITDto", "Dto");
            //GenerateApiClientTemplates();
            //GenerateRepositoryTemplates();

        }
        public static void GenerateApiClientTemplates()
        {

            GenerateAllApiClientTemplates(sourceFilePath);

        }
        public static void GenerateRepositoryTemplates()
        {

            var files=FileScanner.GetAllCsFilePaths($"{appRoot}\\DataSource\\ApiClient2");
            foreach(var file in files)
            {
                //if(file.Contains("BaseApiClient") || file.Contains("IBuildApiClient"))
                //    continue;

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
                    "Infrastructure.Share.Invoker",
                     "AutoMapper",
                     "Shared.Interfaces",
                     "Infrastructure.DataSource.ApiClientBase",
                     "Infrastructure.DataSource.ApiClientFactory",
                     "Infrastructure.Share.Invoker",
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
                    "Shared.Interfaces",
                     "Infrastructure.DataSource.ApiClientBase",
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

        
        
    }
}
