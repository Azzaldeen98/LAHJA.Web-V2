


using Shared.AutoGenerator.Interfaces;

namespace Shared.AutoGenerator.Code;


public interface ITGenerator: ITBase
{
    string Generate(GenerationOptions options);
    void SaveToFile(string filePath);
}
