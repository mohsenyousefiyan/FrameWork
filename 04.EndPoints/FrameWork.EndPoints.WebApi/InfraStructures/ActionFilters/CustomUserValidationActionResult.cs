using FrameWork.Core.Domain.Enums;
using FrameWork.EndPoints.WebApi.ViewModels.BaseViewModels;
using FrameWork.Infra.Resources;
using FrameWork.Utilities.Helpers;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace FrameWork.EndPoints.WebApi.InfraStructures.ActionFilters
{
    public class CustomUserValidationActionResult : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var userId = StringHelper.Base64ToString(context.HttpContext.Request.Headers[IdentityClaimsResource.UserIdKeyName]);

            if (string.IsNullOrEmpty(userId) == false && string.IsNullOrWhiteSpace(userId) == false)
            {
                context.HttpContext.User = new ClaimsPrincipal(new ClaimsIdentity(GetUserClaims(context.HttpContext), CookieAuthenticationDefaults.AuthenticationScheme));
            }
            else
                context.Result = new OkObjectResult(new BaseApiResultModel(statuscode: EnuResultStatusCode.UnAuthorized));
        }

        private List<Claim> GetUserClaims(HttpContext httpContext)
        {
            List<Claim> claims = new List<Claim>();

            var userId = StringHelper.Base64ToString(httpContext.Request.Headers[IdentityClaimsResource.UserIdKeyName]);
            var userName = StringHelper.Base64ToString(httpContext.Request.Headers[IdentityClaimsResource.UserNameKeyName]);
            var firstName = StringHelper.Base64ToString(httpContext.Request.Headers[IdentityClaimsResource.UserFirstNameKeyName]);
            var lastName = StringHelper.Base64ToString(httpContext.Request.Headers[IdentityClaimsResource.UserLastNameKeyName]);
            var deviceId = StringHelper.Base64ToString(httpContext.Request.Headers[IdentityClaimsResource.DeviceUniqueIdKeyName]);

            claims.Add(new Claim(IdentityClaimsResource.UserIdKeyName, userId));

            if (string.IsNullOrEmpty(userName) == false && string.IsNullOrWhiteSpace(userName) == false)
                claims.Add(new Claim(IdentityClaimsResource.UserNameKeyName, userName));

            if (string.IsNullOrEmpty(firstName) == false && string.IsNullOrWhiteSpace(firstName) == false)
                claims.Add(new Claim(IdentityClaimsResource.UserFirstNameKeyName, firstName));

            if (string.IsNullOrEmpty(lastName) == false && string.IsNullOrWhiteSpace(lastName) == false)
                claims.Add(new Claim(IdentityClaimsResource.UserLastNameKeyName, lastName));

            if (string.IsNullOrEmpty(deviceId) == false && string.IsNullOrWhiteSpace(deviceId) == false)
                claims.Add(new Claim(IdentityClaimsResource.DeviceUniqueIdKeyName, deviceId));

            return claims;
        }
    }
}
