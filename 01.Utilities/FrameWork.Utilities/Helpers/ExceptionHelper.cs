using System;

namespace FrameWork.Utilities.Helpers
{
    public static class ExceptionHelper
    {
        public static string GetErrorMessage(this Exception exception)
        {
            if (exception != null && exception.InnerException != null)
                return exception.InnerException.GetErrorMessage();

            return exception.Message;
        }


    }
}
