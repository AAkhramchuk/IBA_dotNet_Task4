using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IUriService
    {
        public Uri GetPageUri(PagingFilter filter, string route);
    }
}