using ESoftPlus.Common.Authentication;

namespace ESoftPlus.Api.Framework
{
    public class AdminAuth : JwtAuthAttribute
    {
        public AdminAuth() : base("admin")
        {
        }
    }
}