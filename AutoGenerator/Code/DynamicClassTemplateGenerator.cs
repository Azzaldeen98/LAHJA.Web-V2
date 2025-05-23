using AutoGenerator.Attributes;
using AutoMapper;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AutoGenerator.Code
{
    public class AutoGenerateUITemplateGenerator
    {

        public static string GenerateTemplateBuilder(
            GenerationOptions generationOptions, 
            ClassDeclarationSyntax classDecl, 
            string service_name,
            string builderType)
        {
            var sb = new StringBuilder();
            var generateCode = "";
            if (generationOptions.ImplementGenerateInterface)
            {

                generationOptions.InterfaceName = $"IBuilder{service_name}{builderType}<T>";
                generationOptions.BaseInterface = $"IBuilder{builderType}<T>";

                generateCode = DynamicClassTemplateGenerator.GenerateInterface(classDecl, generationOptions, null, false);
                sb.AppendLine(generateCode);
                sb.AppendLine();
                //SaveToFile($"{output_directory}\\{generationOptions.InterfaceName}.cs", generateCode);
     
                generationOptions.BaseInterface = $"IBuilder{service_name}{builderType}<E>";
            }


            //newGenerationOptions.AdditionalCode = @"";
            //newGenerationOptions.MethodContentCode = "";
            generationOptions.ClassName = $"Builder{service_name}{builderType}<T,E>";
            generateCode = DynamicClassTemplateGenerator.GenerateClass(classDecl, generationOptions, sourceClassName: "", false, "abstract", "abstract");
            sb.AppendLine(generateCode);
            sb.AppendLine();

            return sb.ToString();
        }
        public static string GenerateTemplateBuilderComponents(
            GenerationOptions generationOptions,
            ClassDeclarationSyntax classDecl,
            string service_name,
            string nameStartWith= "Builder",
            string typeClass= "interface",
            string baseClass= "IBuilderComponents<T>",
            string genericType= "<T>")
        {
            var sb = new StringBuilder();
      

            var methods = classDecl.Members
                           .OfType<MethodDeclarationSyntax>()
                           .Where(m => m.Modifiers.Any(SyntaxKind.PublicKeyword));


            
            sb.AppendLine();
            sb.Append($"public {typeClass} {nameStartWith}{service_name}Components{genericType} : {baseClass}");
            sb.AppendLine("{");

         
          
   
            foreach (var method in methods)
            {
                var generateCode = GenerateDeclarationDelegate(method.Identifier.Text, "public", "Func<T, Task>", "Submit");
                sb.AppendLine(generateCode);
            }

            sb.AppendLine("}");
 
            sb.AppendLine();


               
         

            return sb.ToString();
        }

        public static string GenerateDeclarationDelegate(
            string methodName,
              string typeModifier = "public",
            string returnType = "Func<T, Task>", 
            string nameStartWith = "")
        {

            methodName =  methodName.Replace("Async","");
            methodName= methodName.First().ToString().ToUpper() + methodName.Substring(1);


            return $"  {typeModifier} {returnType} {nameStartWith}{methodName}{{get;set;}}";

   
        }



      
        public static string TemplateShareClassCode(string service_name, string baseClass = "TemplateBase<T,E>")
        {


          return @$"public class Template{service_name}Share<T,E> : {baseClass}
            {{
                public IBuilder{service_name}Components<E> BuilderComponents {{ get => builderComponents; }}
                protected IBuilder{service_name}Api<E> builderApi;

                protected readonly IShareTemplateProvider shareProvider;
                protected readonly CustomAuthenticationStateProvider AuthStateProvider;

                private readonly IBuilder{service_name}Components<E> builderComponents;

                public Template{service_name}Share(
                        CustomAuthenticationStateProvider authStateProvider,
                        LAHJA.Helpers.Services.AuthService authService,
                        T client,
                        IBuilder{service_name}Components<E> builderComponents,
                        IShareTemplateProvider shareProvider) : base(shareProvider.Mapper, authService, client)
                {{



                    builderComponents = new Builder{service_name}Components<E>();
                    this.builderComponents = builderComponents;
                    AuthStateProvider = authStateProvider;
                    this.shareProvider = shareProvider;
                }}

        }}";


   
        }

        public static string GenerateBuilderApiClientClass(
       GenerationOptions generationOptions,
       ClassDeclarationSyntax classDecl,
       string serviceName,
         SemanticModel semanticModel)
        {
            var sb = new StringBuilder();

            // Header and constructor
            sb.AppendLine($@"
public class Builder{serviceName}ApiClient : Builder{serviceName}Api<Application.Services.{serviceName}Service, DataBuild{serviceName}Base>, 
      IBuilder{serviceName}Api<DataBuild{serviceName}Base>
{{
    public Builder{serviceName}ApiClient(IMapper mapper, Application.Services.{serviceName}Service service) 
        : base(mapper, service)
    {{
    }}
");

            var methods = classDecl.Members
                .OfType<MethodDeclarationSyntax>()
                .Where(m => m.Modifiers.Any(SyntaxKind.PublicKeyword));

            foreach (var method in methods)
            {
                var methodName = method.Identifier.Text;
                var returnType = method.ReturnType.ToString();
                var parameters = method.ParameterList.Parameters;

                var parameters_text = string.Join(", ", method.ParameterList.Parameters.Select(p => $"{p.Type} {p.Identifier.Text}"));
                var variables = string.Join(", ", method.ParameterList.Parameters.Select(p => p.Identifier.Text));

                var mappedTypeName = methodName;// GetMappedTypeName(methodName); // <-- تحتاج لتحديد قاعدة التسمية
               


                sb.AppendLine($@"
    public override  async {returnType} {methodName}(DataBuild{serviceName}Base data,CancellationToken cancellationToken)
    {{ ");


                var simpleTypes = new[] { "string", "bool", "int", "float", "string?", "bool?", "int?", "float?" };

                if (parameters != null && parameters.Any())
                {
                    var parametersExcludingLast = parameters.Take(parameters.Count - 1);
                    foreach (var param in parametersExcludingLast) 
                    {
                        var methodBody = "";


                        //var typeInfo = semanticModel.GetTypeInfo(param.Type);
                        //var typeSymbol = typeInfo.Type;

                        if (!simpleTypes.Contains(param.Type.ToString()))
                        {

                            methodBody = @$"        var {param.Identifier.Text}= Mapper.Map<{param.Type}>(data);";

                        }
                        else
                        {
                            var name = param.Identifier.Text;
                            if (!string.IsNullOrEmpty(name))
                            {
                                var capitalized = char.ToUpper(name[0]) + name.Substring(1);
                                methodBody = $"         var {param.Identifier.Text} = data.{capitalized};";
                            }
                           
                        }
                        sb.AppendLine(methodBody);
                    }
                    
        
                }
     
                var call = returnType.Contains("Task<") ? " return  " : "";
    
                sb.AppendLine($"        {call} await Service.{methodName}({variables}); ");
                sb.AppendLine();
                sb.AppendLine("    }");
            }

            sb.AppendLine("}"); // close class

            return sb.ToString();
        }

        public static void GenerateAllUITemplatesClass(GenerationOptions generationOptions)
        {


            if (!DynamicClassTemplateGenerator.CheckImportantInfo(generationOptions))
                return;

            var sb = new StringBuilder();


            var code = File.ReadAllText(generationOptions.SourceTemplateFilePath);
            var tree = CSharpSyntaxTree.ParseText(code);
            var root = tree.GetCompilationUnitRoot();
            var classDeclarations = root.DescendantNodes().OfType<ClassDeclarationSyntax>();

            // توليد compilation يدويًا
            var compilation = CSharpCompilation.Create(
                "GeneratedCode",
                new[] { tree },
                new[] {
                        MetadataReference.CreateFromFile(typeof(object).Assembly.Location),
                        MetadataReference.CreateFromFile(typeof(Console).Assembly.Location),
                        MetadataReference.CreateFromFile(typeof(Enumerable).Assembly.Location),
                        MetadataReference.CreateFromFile(typeof(IMapper).Assembly.Location), // لو كنت تستخدم AutoMapper
                        MetadataReference.CreateFromFile(typeof(Task).Assembly.Location)
                },
                new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary)
            );

            // استخدم semanticModel
            var semanticModel = compilation.GetSemanticModel(tree);

            List<Type> interfaces = new List<Type>();
            if (generationOptions.Interfaces.Any())
                interfaces.AddRange(generationOptions.Interfaces);

            foreach (var classDecl in classDeclarations)
            {
                bool isImplementsInterface = DynamicClassTemplateGenerator.IsImplementsOrInheritsBase(classDecl,
                                            RoslynUtils.CreateSemanticModel(tree),
                                            generationOptions.SourceBaseInterface);


                if (isImplementsInterface)
                {
                    var sourceClassName = classDecl.Identifier.Text;
                    if (!string.IsNullOrWhiteSpace(sourceClassName))
                    {
                        var service_name = sourceClassName.Replace(generationOptions.SourceCategoryName, "");

                        //generationOptions.BaseIClassName = baseClassName;
                        //var output_directory = "";

                        if (!string.IsNullOrWhiteSpace(service_name))
                        {

                            generationOptions.NamespaceName = generationOptions.NamespaceName.Replace("{ServiceName}", service_name);
                            sb.Append(DynamicClassTemplateGenerator.GenerateUsingsNamespaces(generationOptions));
                            sb.AppendLine();


                            generationOptions.ClassName = $"{generationOptions.DestinationCategoryName}{service_name}";
                            var output_file = $"{generationOptions.DestinationRoot}\\{generationOptions.DestinationDirectory}\\{service_name}\\{generationOptions.ClassName}.cs";

                  
                            var newGenerationOptions = generationOptions.Clone();
                            generationOptions.BaseClass = "BuilderApi<T,E>";
                            var generateCode = GenerateTemplateBuilder(generationOptions, classDecl, service_name,"Api");
                            sb.AppendLine(generateCode);
                            sb.AppendLine();
                         

                            generateCode=GenerateTemplateBuilderComponents(generationOptions,
                                classDecl,
                                service_name,
                                "IBuilder",
                                "interface", 
                                "IBuilderComponents<T>", 
                                "<T>");

                            sb.AppendLine(generateCode);
                            sb.AppendLine();

                            generateCode = GenerateTemplateBuilderComponents(generationOptions, 
                                classDecl, 
                                service_name,
                                "Builder",
                                "class", 
                                $"IBuilder{service_name}Components<T>", 
                                "<T>");

                            sb.AppendLine(generateCode);
                            sb.AppendLine();           
                            
                            generateCode = TemplateShareClassCode(service_name);

                            sb.AppendLine(generateCode);
                            sb.AppendLine();             
                            
                            generateCode = GenerateBuilderApiClientClass(generationOptions, classDecl, service_name, semanticModel);

                            sb.AppendLine(generateCode);
                            sb.AppendLine();

                            DynamicClassTemplateGenerator.SaveToFile(output_file, sb.ToString());

                        }


                    }
                }
            }

        }
    }
    public class DynamicClassTemplateGenerator
    {


        public static bool CheckImportantInfo(GenerationOptions generationOptions)
        {

            if (string.IsNullOrWhiteSpace(generationOptions.SourceBaseInterface)
                || string.IsNullOrWhiteSpace(generationOptions.SourceCategoryName)
                || string.IsNullOrWhiteSpace(generationOptions.DestinationCategoryName))
            {
                Console.WriteLine("يجب تضمين اسم الفئة او الواجهة الاب ");
                return false;
            }




            if (!File.Exists(generationOptions.SourceTemplateFilePath))
            {
                Console.WriteLine("الملف المصدر غير موجود.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(generationOptions.DestinationRoot))//  || Path.GetExtension(generationOptions.DestinationRoot) == string.Empty
            {
                Console.WriteLine("مسار الملف الوجهة غير صالح.");
                return false;
            }

            return true;
        }
        public static bool IsImplementsOrInheritsBase(ClassDeclarationSyntax classDecl, SemanticModel model, string baseTypeOrInterfaceName)
        {

            var symbol = model.GetDeclaredSymbol(classDecl) as INamedTypeSymbol;

            if (symbol == null)
                return false;

            // التحقق من الوراثة
            var current = symbol;
            while (current != null && current.Name != "Object")
            {
                if (current.Name == baseTypeOrInterfaceName)
                    return true;

                current = current.BaseType;
            }

            // التحقق من تنفيذ الواجهة (في الكلاس الحالي فقط)
            if (symbol.AllInterfaces.Any(i => i.Name == baseTypeOrInterfaceName))
                return true;

            return false;
        }
        public static void GenerateAllClassTemplate(GenerationOptions generationOptions)
        {


            if (!CheckImportantInfo(generationOptions))
                return;

            var sb = new StringBuilder();
         

            var code = File.ReadAllText(generationOptions.SourceTemplateFilePath);
            var tree = CSharpSyntaxTree.ParseText(code);
            var root = tree.GetCompilationUnitRoot();

            var classDeclarations = root.DescendantNodes().OfType<ClassDeclarationSyntax>();

            List<Type> interfaces = new List<Type>();
            if (generationOptions.Interfaces.Any())
                interfaces.AddRange(generationOptions.Interfaces);

            foreach (var classDecl in classDeclarations)
            {
                bool isImplementsInterface = IsImplementsOrInheritsBase(classDecl, 
                                            RoslynUtils.CreateSemanticModel(tree),
                                            generationOptions.SourceBaseInterface);
                //bool implementsInterface = classDecl.BaseList?.Types
                //    .Any(bt => bt.Type.ToString().EndsWith(generationOptions.SourceBaseInterface)) ?? false;

                if (isImplementsInterface)
                {
                    var sourceClassName = classDecl.Identifier.Text;
                    if (!string.IsNullOrWhiteSpace(sourceClassName))
                    {
                      var  className = sourceClassName.Replace(generationOptions.SourceCategoryName, "");
                        
                        //generationOptions.BaseIClassName = baseClassName;
                        var output_directory = "";
                        if (!string.IsNullOrWhiteSpace(className))
                        {
                            generationOptions.ClassName = $"{className}{generationOptions.DestinationCategoryName}";
                            output_directory = $"{generationOptions.DestinationRoot}\\{generationOptions.DestinationDirectory}\\{className}";
                            // Directory.CreateDirectory().FullName;
                            //generationOptions.DestinationDirection = output_directory;
                            var generateCode = "";
                            if (generationOptions.ImplementGenerateInterface)
                            {
                                generationOptions.InterfaceName = $"I{generationOptions.ClassName}";
                                generateCode = GenerateInterface(classDecl, generationOptions,interfaces);
                                SaveToFile($"{output_directory}\\{generationOptions.InterfaceName}.cs", generateCode);
                                generationOptions.BaseInterface = generationOptions.InterfaceName;
                            }


                            generateCode = GenerateClass(classDecl, generationOptions, sourceClassName);
                            SaveToFile($"{output_directory}\\{generationOptions.ClassName}.cs", generateCode);
                            
                        }


                    }
                }
            }

        }
       
        public static string RemoveLastSymbol(string symbolToRemove,string text)
        {
            text = text.TrimEnd();
            if (text.EndsWith(symbolToRemove.ToString()))
            {
                return text.Substring(0, text.Length - 1);
            }
            return text;
            //return Regex.Replace(text, $@"{symbolToRemove}\s*$", "", RegexOptions.Multiline);
        }

        public static void GenerateAllMethodClassTemplate(GenerationOptions generationOptions)
        {


            if (!CheckImportantInfo(generationOptions))
                return;

            var code = File.ReadAllText(generationOptions.SourceTemplateFilePath);
            var tree = CSharpSyntaxTree.ParseText(code);
            var root = tree.GetCompilationUnitRoot();

            var classDeclarations = root.DescendantNodes().OfType<ClassDeclarationSyntax>();

            List<Type> interfaces = new List<Type>();
            if (generationOptions.Interfaces.Any())
                interfaces.AddRange(generationOptions.Interfaces);

            foreach (var classDecl in classDeclarations)
            {
                bool isImplementsInterface = IsImplementsOrInheritsBase(classDecl, 
                                            RoslynUtils.CreateSemanticModel(tree),
                                            generationOptions.SourceBaseInterface);
                //bool implementsInterface = classDecl.BaseList?.Types
                //    .Any(bt => bt.Type.ToString().EndsWith(generationOptions.SourceBaseInterface)) ?? false;

                if (isImplementsInterface)
                {
                    var sourceClassName = classDecl.Identifier.Text;
                    if (!string.IsNullOrWhiteSpace(sourceClassName))
                    {
                      var  srcClassName = sourceClassName.Replace(generationOptions.SourceCategoryName, "");
              
                        var output_directory = "";
                        if (!string.IsNullOrWhiteSpace(srcClassName))
                        {
                            generationOptions.ClassName = $"{srcClassName}{generationOptions.DestinationCategoryName}";
                            output_directory = $"{generationOptions.DestinationRoot}\\{generationOptions.DestinationDirectory}\\{srcClassName}";

                            var generateCode = "";
                            //if (generationOptions.ImplementGenerateInterface)
                            //{
                            //    generationOptions.InterfaceName = $"I{generationOptions.ClassName}";
                            //    generateCode = GenerateInterface(classDecl, generationOptions, interfaces);
                            //    SaveToFile($"{output_directory}\\{generationOptions.InterfaceName}.cs", generateCode);
                            //    generationOptions.BaseInterface = generationOptions.InterfaceName;
                            //}
                          var methods = classDecl.Members.OfType<MethodDeclarationSyntax>()
                         .Where(m => m.Modifiers.Any(SyntaxKind.PublicKeyword));

                            foreach(var method in methods)
                            {
                                var m_name = method.Identifier.Text.Replace("Async", "");
                                m_name = $"{char.ToUpper(m_name[0])}{m_name.Substring(1)}";

                                var sb = new StringBuilder();
                                sb.AppendLine();
                                sb.Append(GenerateUsingsNamespaces(generationOptions));
                                sb.AppendLine();

                                string singular = srcClassName.EndsWith("s") && srcClassName.Length > 1 ? srcClassName.Substring(0, srcClassName.Length - 1) : srcClassName;

                                var new_class_name = $"{m_name}{( !m_name.Contains(singular) ? srcClassName : "")}{generationOptions.DestinationCategoryName}";

                                sb.Append($"public class {new_class_name}");

                                if (!string.IsNullOrWhiteSpace(generationOptions.BaseInterface))
                                {
                                    sb.Append($" : {generationOptions.BaseInterface} ");
                                }

                                sb.AppendLine("{");
                                var codeA=generationOptions.AdditionalCode.Replace("{ClassName}", new_class_name)
                                    .Replace("{IPropertyType}",$"I{sourceClassName}");
                                sb.AppendLine(codeA);
                                var generateCodeMethod = GenerateMethod(method, generationOptions.MethodContentCode, generationOptions.UnifiedNameForFunctions);

                                sb.AppendLine(generateCodeMethod);
                                sb.AppendLine("}");
                                SaveToFile($"{output_directory}\\{new_class_name}.cs", sb.ToString());
                            }


                            
                        }


                    }
                }
            }

        } 
        public static void GenerateAllServicesFromUseCaseTemplate(GenerationOptions generationOptions)
        {

            if (!CheckImportantInfo(generationOptions))
                return;


            List<Type> interfaces = new List<Type>();
            if (generationOptions.Interfaces.Any())
                interfaces.AddRange(generationOptions.Interfaces);


            string[] subfolders = Directory.GetDirectories(generationOptions.SourceDirectory);

            foreach (var folder in subfolders)
            {
                string folderName = new DirectoryInfo(folder).Name;
                Console.WriteLine($"📁 Folder: {folderName}");

        
                var output_directory =  $"{generationOptions.DestinationRoot}\\{generationOptions.DestinationDirectory}\\{folderName}";
      
                string[] files = Directory.GetFiles(folder);
                if (!files.Any())
                    continue;

                var new_class_name = $"{folderName}{generationOptions.DestinationCategoryName}";
                var new_interface_name = $"I{new_class_name}";

                var fildsPropertyCode = new StringBuilder().AppendLine();
                var parametersCode = new StringBuilder().AppendLine();
                var initializeFieldsCode = new StringBuilder().AppendLine();
                var methodsCode = new StringBuilder().AppendLine();
                var interfaceMethodsCode = new StringBuilder().AppendLine();
               
                foreach (var file in files)
                {

                    var code = File.ReadAllText(file);
                    var tree = CSharpSyntaxTree.ParseText(code);
                    var root = tree.GetCompilationUnitRoot();

                    var classDeclarations = root.DescendantNodes().OfType<ClassDeclarationSyntax>();

                    foreach (var classDecl in classDeclarations)
                    {
                        bool isImplementsInterface = IsImplementsOrInheritsBase(classDecl,
                                                    RoslynUtils.CreateSemanticModel(tree),
                                                    generationOptions.SourceBaseInterface);
              
                        if (isImplementsInterface)
                        {
                            var sourceClassName = classDecl.Identifier.Text;
                            if (!string.IsNullOrWhiteSpace(sourceClassName))
                            {
                                var variableName = $"{char.ToLower(sourceClassName[0])}{sourceClassName.Substring(1)}";
                                var fieldName = $"_{variableName}";
                                fildsPropertyCode.AppendLine($"     private readonly {sourceClassName} {fieldName};");
                                parametersCode.AppendLine($"            {sourceClassName} {variableName},");
                                initializeFieldsCode.AppendLine($"          {fieldName}={variableName};");

                                var newMethodName = sourceClassName.Replace(generationOptions.SourceCategoryName, "");
                                newMethodName = $"{char.ToLower(newMethodName[0])}{newMethodName.Substring(1)}Async";

                                var methods = classDecl.Members.OfType<MethodDeclarationSyntax>()
                                    .Where(m => m.Modifiers.Any(SyntaxKind.PublicKeyword));

                                foreach (var method in methods)
                                    {
                                  
           
                                        if (generationOptions.ImplementGenerateInterface)
                                        {
                                            var interfaceMethodCode = GenerateDeclarationMethod(method, newMethodName);
                                            if (!string.IsNullOrWhiteSpace(interfaceMethodCode))
                                            {
                                                interfaceMethodsCode.AppendLine(interfaceMethodCode);
                                                interfaceMethodsCode.AppendLine();
                                            }
                                               
                                        }
                                         
                                        var generateCodeMethod = GenerateMethodForService(method, generationOptions.MethodContentCode
                                            .Replace("{PropertyFieldName}", fieldName), newMethodName);
                                        if (!string.IsNullOrWhiteSpace(generateCodeMethod))
                                    {
                                        methodsCode.AppendLine(generateCodeMethod);
                                        methodsCode.AppendLine();
                                    }
                                           
                                    
                                }

                            }
                        }
                    }
                }

                fildsPropertyCode.AppendLine();
                initializeFieldsCode.AppendLine();


                //// Generate the interface code

                var generateInterfaceCode = GenerateInterface(new_interface_name, 
                                                              generationOptions,
                                                              interfaces, 
                                                              interfaceMethodsCode.ToString());
                parametersCode = parametersCode.Remove(parametersCode.Length - 1, 1);
                SaveToFile($"{output_directory}\\{new_interface_name}.cs", generateInterfaceCode);



            
                //// Generate the class code
                var generateClassCode=GenerateClass(new_class_name,
                                                    new_interface_name,
                                                    generationOptions,
                                                    fildsPropertyCode.ToString(),
                                                    parametersCode.ToString(),
                                                    initializeFieldsCode.ToString(),
                                                    methodsCode.ToString());

                SaveToFile($"{output_directory}\\{new_class_name}.cs", generateClassCode);
            }
        }
        public static void ImplementationInterfaces(ref StringBuilder sb, List<Type> interfaces)
        {
       
            if (interfaces.Any() && interfaces.Count() > 0)
            {
                if (!sb.ToString().Contains(":"))
                    sb.Append($" : ");
                else
                    sb.Append($" , ");

                foreach (var inter in interfaces)
                {
                    var interfaceName = inter.Name;
                    sb.Append($" {interfaceName} , ");
                }
                sb.Remove(sb.Length - 2, 1); // Remove the last comma
                sb.AppendLine();
            }

           
        }
        public static string GenerateUsingsNamespaces(GenerationOptions generationOptions)
        {
            var sb = new StringBuilder();
            sb.AppendLine();
            sb.AppendLine($"using  System;");
            if (generationOptions.Usings.Any())
            {
                foreach (var library in generationOptions.Usings)
                {
                    sb.AppendLine($"using {library};");
                }
            }


            sb.AppendLine($"namespace {generationOptions.NamespaceName};");

            sb.AppendLine();

            return sb.ToString();
        }
        public static string GenerateInterface(ClassDeclarationSyntax classDeclaration, 
            GenerationOptions generationOptions,
            List<Type>? interfaces,bool includeNamespaces=true)
        {
            var sb = new StringBuilder();

    
            if (string.IsNullOrWhiteSpace(generationOptions.InterfaceName))
            {
                return " ";
            }

            if(includeNamespaces)
                sb.Append(GenerateUsingsNamespaces(generationOptions));

            sb.AppendLine();
            sb.Append($"public interface {generationOptions.InterfaceName}");



            if(interfaces!=null && interfaces.Any())
                ImplementationInterfaces(ref sb, interfaces);

            else if (!string.IsNullOrWhiteSpace(generationOptions.BaseInterface))
                sb.Append($" : {generationOptions.BaseInterface} ");

            var methods = classDeclaration.Members
                                .OfType<MethodDeclarationSyntax>()
                                .Where(m => m.Modifiers.Any(SyntaxKind.PublicKeyword)
                                 && m.ParameterList.Parameters.Any(p => p.Type?.ToString().EndsWith("CancellationToken") == true));


            sb.AppendLine("{");
            foreach (var method in methods)
            {
                var generateCode = GenerateDeclarationMethod(method, generationOptions.UnifiedNameForFunctions);
                sb.AppendLine(generateCode);
            }
            sb.AppendLine("}");
            sb.AppendLine();

            return sb.ToString();
        }     
        public static string GenerateBuilderComponentsProperties(
            ClassDeclarationSyntax classDeclaration,  
            GenerationOptions generationOptions,
            string typeClass= "interface",
            List<Type>? interfaces=null)
        {
            var sb = new StringBuilder();

            if (string.IsNullOrWhiteSpace(generationOptions.ClassName))
            {
                return " ";
            }


            sb.AppendLine();
            sb.Append($"public {typeClass} {generationOptions.ClassName}");

            if (interfaces != null && interfaces.Any())
                ImplementationInterfaces(ref sb, interfaces);

            else if (!string.IsNullOrWhiteSpace(generationOptions.BaseInterface))
                sb.Append($" : {generationOptions.BaseInterface} ");

            var methods = classDeclaration.Members
                                .OfType<MethodDeclarationSyntax>()
                                .Where(m => m.Modifiers.Any(SyntaxKind.PublicKeyword));


            sb.AppendLine("{");
            foreach (var method in methods)
            {
                var generateCode = GenerateDeclarationMethod(method, generationOptions.UnifiedNameForFunctions);
                sb.AppendLine(generateCode);
            }
            sb.AppendLine("}");
            sb.AppendLine();

            return sb.ToString();
        }
        public static string GenerateClass(

            string className,
            string baseInterface,
            GenerationOptions generationOptions,
            string fildsPropertyCode,
            string parametersCode,
            string initializeFieldsCode,
            string contentsCode)
        {
            var sb = new StringBuilder();
            sb.Append(GenerateUsingsNamespaces(generationOptions));
            sb.AppendLine();

            sb.Append($"public class {className}");

            if (!string.IsNullOrWhiteSpace(baseInterface))
            {
                sb.Append($" : {baseInterface} ");
            }

            sb.AppendLine("{");
            sb.AppendLine();

            var additional_class_Code = generationOptions.AdditionalCode
                .Replace("{PropertyFields}", fildsPropertyCode)
                .Replace("{ClassName}", className)
                .Replace("{Parameters}", RemoveLastSymbol(",", parametersCode))
                .Replace("{InitializeFields}", initializeFieldsCode);

            sb.AppendLine(additional_class_Code);

            sb.AppendLine(contentsCode);

            sb.AppendLine();

            sb.AppendLine("}");
            return sb.ToString();
        }
            
            
    public static string GenerateInterface(
    string interfaceName,
    GenerationOptions generationOptions,
    List<Type>? interfaces,
    string contentsCode,
    bool includeNamespaces = true)
        {
            var sb = new StringBuilder();



            if (includeNamespaces)
                sb.Append(GenerateUsingsNamespaces(generationOptions));


            sb.AppendLine();
            sb.Append($"public interface {interfaceName}");


            if (interfaces != null && interfaces.Any())
                ImplementationInterfaces(ref sb, interfaces);

            //else if (!string.IsNullOrWhiteSpace(generationOptions.BaseInterface))
            //    sb.Append($" : {generationOptions.BaseInterface} ");
            

            sb.AppendLine("{");

            if (!string.IsNullOrWhiteSpace(contentsCode))
            {
                sb.AppendLine(contentsCode);
                sb.AppendLine();
            }

                sb.AppendLine("}");
            sb.AppendLine();

            return sb.ToString();
        }

    public static string GenerateClass(
        ClassDeclarationSyntax classDeclaration, 
        GenerationOptions generationOptions,
        string sourceClassName = "", 
        bool includeNamespaces = true,
        string typeModifierClass = "", 
        string typeModifierMethods = "")
        {
            var sb = new StringBuilder();
            
            if (string.IsNullOrWhiteSpace(generationOptions.ClassName))
            {
                return " ";
            }

            if(includeNamespaces)
                sb.Append(GenerateUsingsNamespaces(generationOptions));
            sb.AppendLine();


            sb.Append($" public {typeModifierClass} class {generationOptions.ClassName}");

            if (!string.IsNullOrWhiteSpace(generationOptions.BaseClass))
            {
                var baseClass = generationOptions.BaseClass;
                if (!string.IsNullOrWhiteSpace(sourceClassName))
                {
                    baseClass = baseClass.Replace("<T>", $"<{sourceClassName}>");
                    //var tclass = generationOptions.ClassName.Replace(generationOptions.DestinationCategoryName, generationOptions.SourceCategoryName);
                     
                }
            
                sb.Append($" : {baseClass} ");
            } 
            
            if (generationOptions.ImplementGenerateInterface && !string.IsNullOrWhiteSpace(generationOptions.BaseInterface))
            {
               var symbole=sb.ToString().Contains(":")? " , ": " : ";
         
                sb.Append($"{symbole}{generationOptions.BaseInterface} ");
            }


            if(generationOptions.ImplementOtherInterfacesInClass)
                ImplementationInterfaces(ref sb, generationOptions.Interfaces);


            var methods = classDeclaration.Members
                            .OfType<MethodDeclarationSyntax>()
                            .Where(m => m.Modifiers.Any(SyntaxKind.PublicKeyword)
                            && m.ParameterList.Parameters.Any(p => p.Type?.ToString().EndsWith("CancellationToken") == true));


            sb.AppendLine("{");

            if (!string.IsNullOrWhiteSpace(generationOptions.AdditionalCode))
            {
                var code = generationOptions.AdditionalCode.Replace("{ClassName}", Regex.Replace(generationOptions.ClassName, @"<[^<>]*>", ""));
                if(code.Contains("{BaseClass"))
                    code = code.Replace("{BaseClass}", generationOptions.BaseClass);
                if (code.Contains("{IPropertyType"))
                    code = code.Replace("{IPropertyType}", $"I{sourceClassName}");

                sb.AppendLine(code);
                sb.AppendLine();
            }
         

            foreach (var method in methods)
            {

                var generateCode = "";

                if (!string.IsNullOrWhiteSpace(typeModifierMethods))
                {
                    generateCode = GenerateDeclarationMethod(method, generationOptions.UnifiedNameForFunctions);
                    generateCode= generateCode.Replace("public", $" public {typeModifierMethods} ");
                }
                else
                    generateCode = GenerateMethod(method, generationOptions.MethodContentCode, generationOptions.UnifiedNameForFunctions);

                sb.AppendLine(generateCode);
            }
            sb.AppendLine("}");
            sb.AppendLine();

            return sb.ToString();
        }    
     
    public static string GenerateDeclarationMethod(MethodDeclarationSyntax method,string unifiedNameForFunctions="",string typeModifierMethode="")
    {

        var sb = new StringBuilder();
        var returnType = method.ReturnType.ToString();
        var methodName = (string.IsNullOrWhiteSpace(unifiedNameForFunctions)) ? method.Identifier.Text : unifiedNameForFunctions;
        var parameters = string.Join(", ", method.ParameterList.Parameters
            .Select(p => $"{p.Type} {p.Identifier.Text}"));

        var modifiers = string.Join(" ", method.Modifiers.Select(m => m.Text));

        (returnType, modifiers) = CleanMethodSignature(method);

        sb.AppendLine($"    {modifiers} {returnType} {methodName}({parameters});");

        return CleanGeneratorCode(sb.ToString());
    }    
    public static string GenerateMethod(MethodDeclarationSyntax method,
        string implementationCode,string unifiedNameForFunctions="")
    {
        var sb = new StringBuilder();
        var returnType = method.ReturnType.ToString();
        var methodName = method.Identifier.Text;
        var parameters = string.Join(", ", method.ParameterList.Parameters
            .Select(p => $"{p.Type} {p.Identifier.Text}"));
        var variables = string.Join(", ", method.ParameterList.Parameters
            .Select(p => p.Identifier.Text));

        var modifiers = string.Join(" ", method.Modifiers.Select(m => m.Text));



        (returnType,modifiers) = CleanMethodSignature(method, " async ");

        implementationCode = implementationCode.Replace("{InvokeMethodCallback}",$"{methodName}({variables})" );
        implementationCode = implementationCode.Replace("[RETERN]", returnType.Contains("Task<")?" return  ":"");

            if(!string.IsNullOrWhiteSpace(unifiedNameForFunctions))
            methodName =  unifiedNameForFunctions;

        // كتابة توقيع الدالة + جسم فارغ
        sb.AppendLine($"    {modifiers} {returnType} {methodName}({parameters})");
        sb.AppendLine("   {");
        sb.AppendLine();
        sb.AppendLine($"    {implementationCode}");
        sb.AppendLine();
        sb.AppendLine("   }");
        sb.AppendLine();

        return CleanGeneratorCode(sb.ToString());
    }
    public static string GenerateMethodForService(MethodDeclarationSyntax method,string implementationCode, string newMethodName)
    {
        var sb = new StringBuilder();
        var returnType = method.ReturnType.ToString();
        var methodName = method.Identifier.Text;
        var parameters = string.Join(", ", method.ParameterList.Parameters
            .Select(p => $"{p.Type} {p.Identifier.Text}"));
        var variables = string.Join(", ", method.ParameterList.Parameters
            .Select(p => p.Identifier.Text));

        var modifiers = string.Join(" ", method.Modifiers.Select(m => m.Text));



        //(returnType, modifiers) = CleanMethodSignature(method, " async ");

       

        implementationCode = implementationCode.Replace("{InvokeMethodCallback}", $"{methodName}({variables})");
        implementationCode = implementationCode.Replace("[RETERN]", returnType.Contains("Task<") ? " return  " : "");


        if (string.IsNullOrWhiteSpace(newMethodName))
            return "";

        // كتابة توقيع الدالة + جسم فارغ
        sb.AppendLine($"    {modifiers} {returnType} {newMethodName}({parameters})");
        sb.AppendLine("   {");
        sb.AppendLine();
        sb.AppendLine($"    {implementationCode}");
        sb.AppendLine();
        sb.AppendLine("   }");
        sb.AppendLine();

        return CleanGeneratorCode(sb.ToString());
    }

    public static string CleanGeneratorCode(string code)
    {
        return code.Replace("System.Threading.Tasks.", "")
                    .Replace("System.Threading.", "")
                    .Replace("System.Collections.Generic.", "");
       
    }
    public static (string ReturnType, string Modifiers) CleanMethodSignature(MethodDeclarationSyntax method,string newText="")
    {
        // استخراج نوع الإرجاع كـ string
        var returnType = method.ReturnType.ToString();

        // إزالة المسار الكامل لنوع Task لتبسيطه
        returnType = returnType.Replace("System.Threading.Tasks.", " ");
        returnType = returnType.Replace("System.Threading.", " ");

        // استخراج المعدّلات (modifiers) كـ string
        var modifiers = string.Join(" ", method.Modifiers.Select(m => m.Text));

        // استبدال virtual بـ async إن كانت الدالة تُعيد Task<> ولم تكن async بالفعل
        if ((returnType.Contains("Task<") || returnType.Contains(" Task ")) && !modifiers.Contains("async"))
        {
            modifiers = modifiers.Replace("virtual", newText);
        }
        else
        {
            if(modifiers.Contains("async") && string.IsNullOrWhiteSpace(newText))
                modifiers = modifiers.Replace("async", " ");

            modifiers = modifiers.Replace("virtual", " ").Trim();
        }

        return (returnType.Trim(), modifiers.Trim());
    }
    public static void SaveToFile(string filePath, string content)
    {
        try
        {

            var directory = Path.GetDirectoryName(filePath);
            if (!string.IsNullOrEmpty(directory))
            {
                Directory.CreateDirectory(directory);
            }
            File.WriteAllText(filePath, content, Encoding.UTF8);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"حدث خطأ أثناء حفظ الملف: {ex.Message}");
        }
    }
       
    }
    
}
