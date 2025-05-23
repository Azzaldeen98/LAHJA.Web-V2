﻿using AutoGenerator.Code;
using Shared.Interfaces;
using Shared.Constants.ArchitecturalLayers;
using Shared.Helpers;


namespace Application.Config
{
    public  class ApplicationGenerator
    {
       
        private static string appRoot = ArchitecturalLayers.ApplicationRoot;
        public static void GeneratorCode()
        {
            GenerateUseCaseTemplates();
            GenerateServicesTemplates();
        }

        public static void GenerateUseCaseTemplates()
        {

            var files=FileScanner.GetAllCsFilePaths($"{ArchitecturalLayers.InfrastructureRoot}\\Repositories");
            foreach (var file in files)
            {
                if (!file.StartsWith("I"))
                    GenerateAllUseCaseTemplates(file);
            }
            //if (files != null && files.Any())
            //    GenerateAllUseCaseTemplates(files[0]);
        }

        public static void GenerateServicesTemplates()
        {

            var files = FileScanner.GetAllCsFilePaths($"{appRoot}\\UseCases");
      
            if (files != null && files.Any())
            {
                 foreach (var file in files)
                {
                    string directoryPath = Path.GetDirectoryName(file); // المسار الكامل للمجلد الذي يحتوي على الملف
                    string lastFolderName = new DirectoryInfo(directoryPath).Name;
                    GenerateAllServicesTemplates(file, lastFolderName);
                }
             
            }
            
        }

        public static void GenerateAllUseCaseTemplates(string sourceTemplateFilePath)
        {
            DynamicClassTemplateGenerator.GenerateAllMethodClassTemplate(new GenerationOptions
            {
                SourceTemplateFilePath = $"{sourceTemplateFilePath}",
                DestinationRoot = appRoot,
                DestinationDirectory = "UseCases",
                SourceBaseInterface = "ITBaseRepository",
                SourceCategoryName = "Repository",
                ImplementGenerateInterface = true,
                UnifiedNameForFunctions = "ExecuteAsync",
                BaseInterface = "ITBaseUseCase",
                //ImplementOtherInterfacesInClass = true,
                DestinationCategoryName = "UseCase",
                NamespaceName = "Application.UseCases",
                Interfaces = new List<Type>
                {
                    typeof(ITBaseUseCase),
                    typeof(ITScope),
                },
                Usings = new List<string>
                {
                    "System.Threading.Tasks",
                    "Infrastructure.Nswag",
                    "Shared.Interfaces",
                     "Microsoft.Extensions.Configuration",
                     "Infrastructure.Repositories"
        },
                AdditionalCode = @"
    private readonly {IPropertyType} _repository;
    public {ClassName}({IPropertyType} repository){
        _repository=repository;
    }

                ",
        MethodContentCode = @"
        [RETERN]  await _repository.{InvokeMethodCallback};
        ",

            });
        }
        public static void GenerateAllServicesTemplates(string sourceTemplateFilePath,string serviceRoot)
        {
            DynamicClassTemplateGenerator.GenerateAllServicesFromUseCaseTemplate(new GenerationOptions
            {
                SourceTemplateFilePath = $"{sourceTemplateFilePath}",
                DestinationRoot = appRoot,
                DestinationDirectory = "GenerateServices",
                SourceBaseInterface = "ITBaseUseCase",
                SourceCategoryName = "UseCase",
                SourceDirectory = $"{appRoot}\\UseCases",
                DestinationCategoryName = "Service",
                ImplementGenerateInterface = true,
                BaseInterface = "ITBaseShareService",
                NamespaceName = "Application.Services",
                Interfaces = new List<Type>
                {
                    typeof(ITBaseShareService),
                },
                Usings = new List<string>
                {
                    "System.Threading.Tasks",
                    "Infrastructure.Nswag",
                    "Shared.Interfaces",
                     "Microsoft.Extensions.Configuration",
                     "Application.UseCases"
        },
        AdditionalCode = @"
        {PropertyFields}
    public {ClassName}(   {Parameters})
    {
                        {InitializeFields}
    }

                ",
    MethodContentCode = @"

        [RETERN] await {PropertyFieldName}.{InvokeMethodCallback};
        ",

            });
        }
    }
}
