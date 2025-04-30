//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Shared.Interfaces.AutoGenerator
//{



//    public interface ITBase { }
//    public interface ITModel : ITBase { }
//    public interface ITDso : ITBase { }
//    public interface ITException : ITBase { }

//    public interface ITApiClient : ITBase { }
//    public interface ITBaseApiClient : ITApiClient, ITScope { }
//    public interface ITBuildApiClient : ITApiClient { }
//    public interface ITBaseShareApiClient : ITApiClient,ITScope { }

//    public interface ITDto : ITBase { }

//    public interface ITShareDto : ITDto { }

//    public interface ITBuildDto : ITDto { }

//    public interface ITVM : ITBase { }

//    public interface ITTransient : ITBase { }
//    public interface ITSingleton : ITBase { }
//    public interface ITInterceptor : ITBase { }

//    public interface ITScope : ITBase { }
//    public interface ITRepository : ITBase { }
//    public interface ITBaseRepository : ITRepository { }
//    public interface ITBuildRepository : ITRepository { }
//    public interface ITBaseShareRepository : ITRepository, ITScope { }
//    public interface ITService : ITBase, ITScope { }

//    public interface ITBaseService : ITService { }



//    public interface ITranslationDat
//    {
//        Dictionary<string, string>? Value { get; set; }


//        string? ToFilter(string? lg);
//    }

//    public interface ITUser { }


//    public interface ITRole { }


//    public interface ITClaimsHelper { }
    


//}
