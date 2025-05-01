using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AutoGenerator.Code
{
    public class DynamicClassTemplateGenerator
    {
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


            if (string.IsNullOrWhiteSpace(generationOptions.SourceBaseInterface) 
                || string.IsNullOrWhiteSpace(generationOptions.SourceCategoryName)
                || string.IsNullOrWhiteSpace(generationOptions.DestinationCategoryName))
            {
                Console.WriteLine("يجب تضمين اسم الفئة او الواجهة الاب ");
                return;
            }
            

    
            
            if (!File.Exists(generationOptions.SourceTemplateFilePath))
            {
                Console.WriteLine("الملف المصدر غير موجود.");
                return;
            }

            if (string.IsNullOrWhiteSpace(generationOptions.DestinationRoot))//  || Path.GetExtension(generationOptions.DestinationRoot) == string.Empty
            {
                Console.WriteLine("مسار الملف الوجهة غير صالح.");
                return;
            }

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

            if (string.IsNullOrWhiteSpace(generationOptions.SourceBaseInterface) 
                || string.IsNullOrWhiteSpace(generationOptions.SourceCategoryName)
                || string.IsNullOrWhiteSpace(generationOptions.DestinationCategoryName))
            {
                Console.WriteLine("يجب تضمين اسم الفئة او الواجهة الاب ");
                return;
            }
            
            
            if (!File.Exists(generationOptions.SourceTemplateFilePath))
            {
                Console.WriteLine("الملف المصدر غير موجود.");
                return;
            }

            if (string.IsNullOrWhiteSpace(generationOptions.DestinationRoot))
            {
                Console.WriteLine("مسار الملف الوجهة غير صالح.");
                return;
            }

       

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

            if (string.IsNullOrWhiteSpace(generationOptions.SourceBaseInterface) 
                || string.IsNullOrWhiteSpace(generationOptions.SourceCategoryName)
                || string.IsNullOrWhiteSpace(generationOptions.DestinationCategoryName))
            {
                Console.WriteLine("يجب تضمين اسم الفئة او الواجهة الاب ");
                return;
            }
            

            if (string.IsNullOrWhiteSpace(generationOptions.SourceDirectory))
            {
                Console.WriteLine("مسار  المصدر غير صالح.");
                return;
            }       
            
            if (string.IsNullOrWhiteSpace(generationOptions.DestinationRoot))
            {
                Console.WriteLine("مسار  الوجهة غير صالح.");
                return;
            }

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
                                fildsPropertyCode.AppendLine($" private readonly {sourceClassName} {fieldName};");
                                parametersCode.AppendLine($"{sourceClassName} {variableName},");
                                initializeFieldsCode.AppendLine($"      {fieldName}={variableName};");

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
            List<Type>? interfaces)
        {
            var sb = new StringBuilder();

    
            if (string.IsNullOrWhiteSpace(generationOptions.InterfaceName))
            {
                return " ";
            }

            sb.Append(GenerateUsingsNamespaces(generationOptions));
            sb.AppendLine();
            sb.Append($"public interface {generationOptions.InterfaceName}");

            //if (!string.IsNullOrWhiteSpace(generationOptions.BaseInterface) && )
            //{
            //    sb.Append($" : {generationOptions.BaseInterface} ");

            //}

            if(interfaces!=null && interfaces.Any())
                ImplementationInterfaces(ref sb, interfaces);


            //if (generationOptions.Interfaces.Any()&& generationOptions.Interfaces.Count()>0)
            //{
            //    sb.Append($" : ");
            //    foreach (var inter in generationOptions.Interfaces)
            //    {
            //        var interfaceName = inter.Name;
            //        sb.Append($" {interfaceName} , ");
            //    }
            //    sb.Remove(sb.Length - 2, 1); // Remove the last comma

            //}
       

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
    string contentsCode)
        {
            var sb = new StringBuilder();



            sb.Append(GenerateUsingsNamespaces(generationOptions));
            sb.AppendLine();
            sb.Append($"public interface {interfaceName}");


            if (interfaces != null && interfaces.Any())
                ImplementationInterfaces(ref sb, interfaces);

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

        public static string GenerateClass(ClassDeclarationSyntax classDeclaration, 
            GenerationOptions generationOptions,string sourceClassName = "")
        {
            var sb = new StringBuilder();
            
            if (string.IsNullOrWhiteSpace(generationOptions.ClassName))
            {
                return " ";
            }


            sb.Append(GenerateUsingsNamespaces(generationOptions));
            sb.AppendLine();


            sb.Append($"public class {generationOptions.ClassName}");

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
                var code = generationOptions.AdditionalCode.Replace("{ClassName}", generationOptions.ClassName);
                if(code.Contains("{BaseClass"))
                    code = code.Replace("{BaseClass}", generationOptions.BaseClass);
                if (code.Contains("{IPropertyType"))
                    code = code.Replace("{IPropertyType}", $"I{sourceClassName}");

                sb.AppendLine(code);
                sb.AppendLine();
            }
         

            foreach (var method in methods)
            {
             
                var generateCode = GenerateMethod(method, generationOptions.MethodContentCode, generationOptions.UnifiedNameForFunctions);
                sb.AppendLine(generateCode);
            }
            sb.AppendLine("}");
            sb.AppendLine();

            return sb.ToString();
        }
        public static string GenerateDeclarationMethod(MethodDeclarationSyntax method,string unifiedNameForFunctions="")
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
