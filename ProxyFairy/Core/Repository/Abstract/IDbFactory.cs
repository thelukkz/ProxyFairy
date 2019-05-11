using ProxyFairy.Core.Model;

namespace ProxyFairy.Core.Repository.Abstract
{
    public interface IDbFactory
    {
        AppIdentityDbContext GetDataContext { get; }
    }
}
