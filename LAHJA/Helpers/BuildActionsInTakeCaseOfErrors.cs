using Shared.Exceptions;

namespace LAHJA.Helpers
{



    public interface IBuildActionsInTakeCaseOfErrors
    {
        public void HandleException(Exception ex);
        public void HandleUnauthorizedError(UnauthorizedException ex);
        public void HandleServiceUnavailableError(ServiceUnavailableException ex);
    }


    public class BuildActionsInTakeCaseOfErrors : IBuildActionsInTakeCaseOfErrors
    {
        private readonly IExecutiveProceduresForProcessingErrors buildTriggered;
        public BuildActionsInTakeCaseOfErrors(IExecutiveProceduresForProcessingErrors buildTriggered)
        {
            this.buildTriggered = buildTriggered;
        }


        public void HandleException(Exception ex)
        {
            //throw new NotImplementedException();
        }

        public void HandleServiceUnavailableError(ServiceUnavailableException ex)
        {
            //buildTriggered.NavigationTo("error", null);
        }

        public void HandleUnauthorizedError(UnauthorizedException ex)
        {
            buildTriggered.Logout();
        }
    }
}
