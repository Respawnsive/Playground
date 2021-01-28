using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Apizr;
using Apizr.Caching;
using Apizr.Logging;
using Apizr.Policing;
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