using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Shared.AutoGenerator.Code;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Generator.Code
{
    public static class RoslynUtils
    {
        public static SemanticModel CreateSemanticModel(SyntaxTree tree)
        {
            var references = AppDomain.CurrentDomain.GetAssemblies()
                .Where(a => !a.IsDynamic && !string.IsNullOrWhiteSpace(a.Location))
                .Select(a => MetadataReference.CreateFromFile(a.Location))
                .Cast<MetadataReference>()
                .ToList();

            var compilation = CSharpCompilation.Create("TempCompilation")
                .AddReferences(references)
                .AddSyntaxTrees(tree);

            return compilation.GetSemanticModel(tree);
        }
    }
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
            

            //sb.AppendLine("// هذا الملف تم إنشاؤه تلقائيًا لتحليل الكود\n");
    
            
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
            //File.WriteAllText(outputDir, sb.ToString(), Encoding.UTF8);
            //Console.WriteLine("تم حفظ المعلومات في الملف بنجاح.");
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
        public static string GenerateInterface(ClassDeclarationSyntax classDeclaration, GenerationOptions generationOptions,List<Type>? interfaces)
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
                var generateCode = GenerateDeclarationMethod(method);
                sb.AppendLine(generateCode);
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
             
                var generateCode = GenerateMethod(method, generationOptions.MethodContentCode);
                sb.AppendLine(generateCode);
            }
            sb.AppendLine("}");
            sb.AppendLine();

            return sb.ToString();
        }
        public static string GenerateDeclarationMethod(MethodDeclarationSyntax method)
        {

            var sb = new StringBuilder();
            var returnType = method.ReturnType.ToString();
            var methodName = method.Identifier.Text;
            var parameters = string.Join(", ", method.ParameterList.Parameters
                .Select(p => $"{p.Type} {p.Identifier.Text}"));

            var modifiers = string.Join(" ", method.Modifiers.Select(m => m.Text));

            (returnType, modifiers) = CleanMethodSignature(method);

            sb.AppendLine($"    {modifiers} {returnType} {methodName}({parameters});");

            return CleanGeneratorCode(sb.ToString());
        }    
        public static string GenerateMethod(MethodDeclarationSyntax method,string implementationCode)
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
       
        
        //public static void ReadInfo(string folderPath,string outputPath)
        //{

        //        //var folderPath = @"C:\Path\To\Your\Code"; // عدّل المسار هنا
        //        //var outputPath = @"C:\Path\To\Output\ExtractedInfo.cs";

        //        var sb = new StringBuilder();
        //        sb.AppendLine("// هذا الملف تم إنشاؤه تلقائيًا لتحليل الكود\n");

        //        var csFiles = Directory.GetFiles(folderPath, "*.cs", SearchOption.AllDirectories);

        //        foreach (var file in csFiles)
        //        {
        //            var code = File.ReadAllText(file);
        //            var tree = CSharpSyntaxTree.ParseText(code);
        //            var root = tree.GetCompilationUnitRoot();

        //            var classDeclarations = root.DescendantNodes().OfType<ClassDeclarationSyntax>();

        //            foreach (var classDecl in classDeclarations)
        //            {
        //                bool implementsInterface = classDecl.BaseList?.Types
        //                    .Any(bt => bt.ToString() == "ITApiClient") ?? false;

        //                if (implementsInterface)
        //                {
        //                    var className = classDecl.Identifier.Text;
        //                    sb.AppendLine($"// Class: {className}");

        //                    var methods = classDecl.Members
        //                        .OfType<MethodDeclarationSyntax>()
        //                        .Where(m => m.Modifiers.Any(SyntaxKind.PublicKeyword));

        //                    foreach (var method in methods)
        //                    {
        //                        var methodName = method.Identifier.Text;
        //                        var returnType = method.ReturnType.ToString();
        //                        sb.AppendLine($"//   Method: {methodName}");
        //                        sb.AppendLine($"//     Return Type: {returnType}");

        //                        foreach (var param in method.ParameterList.Parameters)
        //                        {
        //                            sb.AppendLine($"//     Parameter: {param.Identifier.Text} ({param.Type})");
        //                        }
        //                    }

        //                    sb.AppendLine();
        //                }
        //            }
        //        }

        //        File.WriteAllText(outputPath, sb.ToString(), Encoding.UTF8);
        //        Console.WriteLine("تم حفظ المعلومات في الملف بنجاح.");
        //    }
    }
    
}
