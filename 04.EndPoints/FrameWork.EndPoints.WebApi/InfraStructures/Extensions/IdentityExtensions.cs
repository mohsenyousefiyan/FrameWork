using FrameWork.EndPoints.WebApi.InfraStructures.Extensions;
using FrameWork.Infra.Resources;
using System;
using System.Security.Claims;
using System.Security.Principal;

namespace FrameWork.EndPoints.WebApi.InfraStructures.Extensions
{
    public static class IdentityExtensions
    {
        public static string FindFirstValue(this ClaimsIdentity identity, string claimType)
        {
            return identity?.FindFirst(claimType)?.Value;
        }

        public static string FindFirstValue(this IIdentity identity, string claimType)
        {
            var claimsIdentity = identity as ClaimsIdentity;
            return claimsIdentity?.FindFirstValue(claimType);
        }

        public static int GetUserId(this IIdentity identity)
        {
            if (identity != null)
            {
                //var id = identity.FindFirstValue(ClaimTypes.NameIdentifier);
                var id = identity.FindFirstValue(IdentityClaimsResource.UserIdKeyName);
                try
                {
                    return Convert.ToInt32(id);
                }
                catch
                {

                }
            }
            return -1;
        }



        public static string GetUserDeviceId(this IIdentity identity)
        {
            if (identity != null)
            {
                var id = identity.FindFirstValue(IdentityClaimsResource.DeviceUniqueIdKeyName);
                if (!string.IsNullOrEmpty(id))
                    return id;
            }
            return null;
        }

        public static string GetUserName(this IIdentity identity)
        {
            return identity?.FindFirstValue(IdentityClaimsResource.UserNameKeyName);
        }

        public static string GetUserFirstName(this IIdentity identity)
        {
            return identity?.FindFirstValue(IdentityClaimsResource.UserFirstNameKeyName);
        }

        public static string GetUserLastName(this IIdentity identity)
        {
            return identity?.FindFirstValue(IdentityClaimsResource.UserLastNameKeyName);
        }
                      
    }
}
