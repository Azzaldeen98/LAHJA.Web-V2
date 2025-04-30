using System.Reflection;

namespace Shared.AutoGenerator.Code;

public class GenerationOptions
{
    public string ClassName { get; set; }
    public string InterfaceName { get; set; }
    public string SourceBaseInterface { get; set; }
    public string BaseInterface { get; set; }

    public bool ImplementGenerateInterface { get; set; } = false;
    public bool ImplementOtherInterfacesInClass { get; set; } = false;
    public string SourceTemplateFilePath { get; set; }
    public string SourceCategoryName { get; set; }
    public string DestinationRoot { get; set; }
    public string DestinationDirectory { get; set; }
    public string DestinationCategoryName { get; set; }
    public Type SourceType { get; }
    public string NamespaceName { get; set; } = "GeneratedClasses";
    public string AdditionalCode { get; set; } = "";
    public string MethodContentCode { get; set; } = "";
    public List<Type> Interfaces { get; set; } = new List<Type>();

    public PropertyInfo[] Properties { get; set; }

    public GenerationOptions() { }

    public GenerationOptions(string className,Type sourceType,bool isProperties=true)
    {
        ClassName = className;
        SourceType = sourceType;
        if(isProperties)
             Properties = sourceType.GetProperties();

    }

    public GenerationOptions(string baseClass,
        string sourceTemplateFilePath,
        string destinationRoot,
        string sourceCategoryName,
        string destinationCategoryName)
    {
        SourceTemplateFilePath = sourceTemplateFilePath;
        BaseClass = baseClass;
        DestinationRoot = destinationRoot;
        DestinationCategoryName = destinationCategoryName;
        
    }

    public List<string> Usings { get; set; } = new List<string>();
    public string BaseClass { get; set; } = null;
    public string Template { get; set; } = @"
        public class {ClassName} {BaseClass} {Interfaces}
        {
            {Properties}
            {AdditionalCode}
        }
    ";
}
