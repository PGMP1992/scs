using System.Security.Claims;

namespace SCS.Utility
{
    public static class UserAccessor
    {
        public static string GetUserId(this ClaimsPrincipal user)
        {
            var claim = user.FindFirst(ClaimTypes.NameIdentifier);
            return claim != null ? claim.Value : string.Empty;
        }

        public static string GetUserName(this ClaimsPrincipal user)
        {
            var claim = user.FindFirst(ClaimTypes.Name);
            return claim != null ? claim.Value : string.Empty;
        }
    }
}
