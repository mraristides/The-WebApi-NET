using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Sample.Hypermedia.Abstract
{
    public interface IResponseEnricher
    {
         bool CanEnrich(ResultExecutingContext context);
         Task Enrich(ResultExecutingContext context);
    }
}