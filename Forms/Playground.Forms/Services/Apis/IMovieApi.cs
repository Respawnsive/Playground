using System.Threading.Tasks;
using Apizr;
using Apizr.Caching;
using Playground.Forms.Models;
using Refit;

namespace Playground.Forms.Services.Apis
{
    [WebApi(false)]
    [Headers("Authorization: Bearer")]
    public interface IMovieApi
    {
        [Get("/upcoming")]
        [CacheIt(CacheMode.GetAndFetch, "01:00:00")]
        Task<PeriodicPagedResult<Movie>> GetUpcomingMoviesAsync([CacheKey] int page = 1);
    }
}