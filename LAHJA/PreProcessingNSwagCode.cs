using ApexCharts;
using Blazorise;
using Microsoft.Extensions.FileSystemGlobbing.Internal;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using Match = System.Text.RegularExpressions.Match;

namespace LAHJA
{
    public class PreProcessingNSwagCode
    {


        public static List<string> classNames = new List<string>(); // قائمة لحفظ أسماء الكلاسات
        public static List<string> classNamesEdinty = new List<string>(); // قائمة لحفظ أسماء الكلاسات المعدلة
        static string pattern = "\\b(class\\s+|new\\s+|\\breturn\\s+|\\btypeof\\s*\\(\\s*|\\bas\\s+|\\bis\\s+|\\bpublic\\s+|\\bprivate\\s+|\\bprotected\\s+|\\binternal\\s+|\\bstatic\\s+|\\breadonly\\s+|\\bvar\\s+|\\bthis\\s+|List<|Dictionary<|HashSet<|\\bTask<|\\bIEnumerable<|\\bFunc<|\\bAction<|\\bTuple<|\\bNullable<)([A-Z][a-zA-Z0-9_<>]*)\\b\r\n";
        public static void ExtractDtoClasses(string filePath = "NSwageCodePrism.txt")
        {
            var symbole = ": Prism.Mvvm.BindableBase"; // رمز البحث عن الكلاسات التي ترث Prism.Mvvm.BindableBase

            // قراءة جميع الأسطر من الملف
            var lines = File.ReadAllLines(filePath);
            //foreach (Match match in Regex.IsMatch(code, pattern))
            //{
            //    classNames.Add(match.Groups[2].Value);
            //}

            foreach (var ln in lines)
            {
                var line = ln.Trim();
                if (line.Contains(symbole) && line.Contains(" class ") && Regex.IsMatch(line, pattern))
                {
                    // إزالة ": Prism.Mvvm.BindableBase"
                    var modifiedLine = line.Replace(symbole, "").Trim();

                    if (modifiedLine.Length > 0)
                    {
                        // إزالة أي جزء بعد `{` إذا وجد
                        if (modifiedLine.Contains("{"))
                        {
                            modifiedLine = modifiedLine.Split('{')[0].Trim();
                        }

                        if (!classNames.Contains(modifiedLine))
                        {
                            classNamesEdinty.Add(modifiedLine);
                        }
                           

                        // تقسيم السطر للحصول على اسم الكلاس
                        var parts = modifiedLine.Split(" ");
                        if (parts.Length > 0)
                        {
                            var cname = parts.Last().Trim(); // آخر عنصر في المصفوفة هو اسم الكلاس

                            if (!classNames.Contains(cname))
                            {
                                classNames.Add(cname);
                            }
                        }
                    }
                }
            }
        }


    public static void Run(string filePath= "NSwageCode.txt",string outputFilePath= "..\\Infrastructure\\DataSource\\ApiClientFactory\\Nswag\\WebClientApi2.cs")
        {
            ExtractDtoClasses();

            if(classNames.Any() && classNamesEdinty.Any())
            {

                //var text = File.ReadAllText(filePath);

                //foreach (var item in classNames)
                //{
                //    text= text.Replace(item.Trim(), $"{item.Trim()}Dso");
                //}

                //foreach (var item in classNamesEdinty)
                //{
                //    text=text.Replace(item.Trim(), $"{item.Trim()}Dso : ITDso");
                //}


                //File.WriteAllLines("NSwageCode2.txt", classNamesEdinty);
                //File.WriteAllText(outputFilePath, text);

                ProcessFile(filePath, outputFilePath);
            }
        }

        public static void ProcessFile(string filePath = "NSwageCode.txt",
       string outputFilePath = "..\\Infrastructure\\DataSource\\ApiClientFactory\\Nswag\\WebClientApi2.cs")
        {
            //var symbole = "_ITDso";
            // قراءة جميع الأسطر من الملف
            var lines = File.ReadAllLines(filePath);

            // إنشاء قائمة جديدة لتخزين الأسطر المعدلة
            var modifiedLines = new List<string>();
            //var classNames = new List<string>();

            foreach (var ln in lines)
            {
                var line = ln.Trim();

                if (Regex.IsMatch(line, pattern)) 
                {
                    if (line.Contains("class"))
                    {

                        foreach (var symbole in classNamesEdinty)
                        {

                            if (line.Contains(symbole) && !line.EndsWith("Dso") && !line.Contains(':'))
                            {

                                line += "Dso : ITDso";

                                break;
                            }

                        }

                    }
                    else
                    {
                        foreach (var symbole in classNames)
                        {
                            if (line.Contains(symbole) && !line.EndsWith("Dso"))
                            {
                                line = line.Replace(symbole, $"{symbole}Dso");
                                break;
                            }

                        }
                    }
                }

                modifiedLines.Add(line);
            }


            //var newLines = AddDsoIfNotPresent(classNames, modifiedLines);

            //newLines.AddRange(classNames);
            //if (File.Exists(outputFilePath))
            //    File.Delete(outputFilePath);

            File.WriteAllLines(outputFilePath, modifiedLines);

            Console.WriteLine("تم تعديل الملف بنجاح.");
        }

        public static void ProcessFile1(string filePath = "NSwageCode.txt",
           string outputFilePath = "..\\Infrastructure\\DataSource\\ApiClientFactory\\Nswag\\WebClientApi2.cs")
        {
            var symbole = "_ITDso";
            // قراءة جميع الأسطر من الملف
            var lines = File.ReadAllLines(filePath);

            // إنشاء قائمة جديدة لتخزين الأسطر المعدلة
            var modifiedLines = new List<string>();
            var classNames = new List<string>();

            foreach (var ln in lines)
            {
                var line = ln.Trim();
                if (line.Contains(symbole) && !line.Contains(':'))
                {
                    var parts = line.Split(" ");
                    var modifiedLine = line.Replace(symbole, "");
                   
                    if (parts.Length > 0) {
                        var cname = parts[parts.Length - 1].Trim();
                        if(!classNames.Contains(cname))
                            classNames.Add(cname);
                    }
                    // إضافة ":ITDso" إلى نهاية السطر المعدل
                    modifiedLine += "Dso : ITDso";

                    // إضافة السطر المعدل إلى القائمة
                    modifiedLines.Add(modifiedLine);
                }
                else
                {
                    // إذا لم يحتوي السطر على "{ITDso}"، إضافة السطر كما هو
                    modifiedLines.Add(line);
                }
            }


            var newLines = AddDsoIfNotPresent(classNames, modifiedLines);

            //newLines.AddRange(classNames);
            //if (File.Exists(outputFilePath))
            //    File.Delete(outputFilePath);

            File.WriteAllLines(outputFilePath, newLines);

            Console.WriteLine("تم تعديل الملف بنجاح.");
        }
    

    static List<string> AddDsoIfNotPresent(List<string> classNames, List<string> modifiedLines)
        {
            var newLines = new List<string>();
            foreach (var line in modifiedLines)
            {
                foreach (var cname in classNames)
                {
                    if (line.Contains(cname))
                    {
                        line.Replace(cname,$"{cname}Dso");
                    }
                }
                newLines.Add(line);
            }
           


                return newLines;
        }
     }


    }
