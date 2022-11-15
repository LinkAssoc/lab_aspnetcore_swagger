using WebApplication2.Models;

namespace WebApplication2.Services
{
    public interface IUrlService
    {
        public Task<UrlResponse> GetUrls(string url);
    }
}
