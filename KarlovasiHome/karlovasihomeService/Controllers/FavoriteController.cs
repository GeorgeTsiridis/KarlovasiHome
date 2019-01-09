using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.Azure.Mobile.Server;
using KarlovasiHomeService.DataObjects;
using KarlovasiHomeService.Models;

namespace KarlovasiHomeService.Controllers
{
    public class FavoriteController : TableController<Favorite>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            KarlovasiHomeContext context = new KarlovasiHomeContext();
            DomainManager = new EntityDomainManager<Favorite>(context, Request);
        }

        // GET tables/Favorite
        public IQueryable<Favorite> GetAllFavorites()
        {
            return Query();
        }

        // GET tables/Favorite/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Favorite> GetFavorite(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Favorite/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Favorite> PatchFavorite(string id, Delta<Favorite> patch)
        {
            return UpdateAsync(id, patch);
        }

        // POST tables/Favorite
        public async Task<IHttpActionResult> PostFavorite(Favorite item)
        {
            Favorite current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Favorite/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteFavorite(string id)
        {
            return DeleteAsync(id);
        }
    }
}