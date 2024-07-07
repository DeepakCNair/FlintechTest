using FlintechTest.Server.Models;

namespace FlintechTest.Server.Interface
{
    public interface IRestRequest<T>
    {
        Task<IEnumerable<T>> Get(RequestParam requestParam);
    }
}
