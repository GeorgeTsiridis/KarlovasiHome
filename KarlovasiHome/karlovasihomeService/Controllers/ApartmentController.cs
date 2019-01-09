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
    public class ApartmentController : TableController<Apartment>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            KarlovasiHomeContext context = new KarlovasiHomeContext();
            DomainManager = new EntityDomainManager<Apartment>(context, Request);
        }

        // GET tables/Apartment
        public IQueryable<Apartment> GetAllApartments()
        {
            return Query();
        }

        // GET tables/Apartment/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Apartment> GetApartment(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Apartment/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Apartment> PatchApartment(string id, Delta<Apartment> patch)
        {
            return UpdateAsync(id, patch);
        }

        // POST tables/Apartment
        public async Task<IHttpActionResult> PostApartment(Apartment item)
        {
            Apartment current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Apartment/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteApartment(string id)
        {
            return DeleteAsync(id);
        }
    }
}