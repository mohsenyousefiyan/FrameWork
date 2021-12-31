using FrameWork.Utilities.Helpers;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Text;

namespace FrameWork.EndPoints.WebApi.InfraStructures.Extensions
{
    public static class HttpContextExtention
    {
        public static string GetRawRequestBodyString(this HttpContext httpContext, Encoding encoding)
        {
            try
            {
                var body = "";
                if (httpContext.Request.ContentLength == null || !(httpContext.Request.ContentLength > 0))
                    return body;

                httpContext.Request.EnableBuffering();
                httpContext.Request.Body.Seek(0, SeekOrigin.Begin);
                using (var reader = new StreamReader(httpContext.Request.Body, encoding, true, 1024, true))
                {
                    body = reader.ReadToEndAsync().Result;
                }
                httpContext.Request.Body.Position = 0;
                return body;
            }
            catch 
            {
                return "";
            }
        }

        public static T GetRequestBodyContent<T>(this HttpContext httpContext, Encoding encoding)
        {
            try
            {
                var body = "";
                if (httpContext.Request.ContentLength == null || !(httpContext.Request.ContentLength > 0))
                    return default;

                httpContext.Request.EnableBuffering();
                httpContext.Request.Body.Seek(0, SeekOrigin.Begin);
                using (var reader = new StreamReader(httpContext.Request.Body, encoding, true, 1024, true))
                {
                    body = reader.ReadToEndAsync().Result;
                }
                httpContext.Request.Body.Position = 0;
                return SerializerHelper.DeSerialize<T>(body);
            }
            catch (Exception ex)
            {
                return default;
            }
        }

    }
}
