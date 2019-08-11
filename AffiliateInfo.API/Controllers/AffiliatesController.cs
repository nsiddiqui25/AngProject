using DataRepository.Models.ELD.Prod;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace AffiliateInfo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AffiliatesController : ControllerBase
    {
        private readonly ELD_PRODUCTIONContext _ctx;

        public AffiliatesController(ELD_PRODUCTIONContext ctx)
        {
            _ctx = ctx;
        }

        //GET: api/Affiliates
        [HttpGet("{masterSheetId}")]
        public async Task<ActionResult<DataAccess.AffiliateInfo>> Get(int masterSheetId)
        {
            //var affiliates = await _ctx.Set<DataAccess.AffiliateInfo>()
            //    .Include(a => a.CorpOwners)
            //    .Include(a => a.AdditionalEntities)
            //        .ThenInclude(a => a.AdditionalEntityOwners)
            //    .SingleAsync(a => a.MasterSheetId == masterSheetId);

            var corpOwners = await _ctx.CorpOwner
                //.Set<CorpOwner>()
                .Where(c => c.MasterSheetId == masterSheetId)
                .ToListAsync();

            var additionalEnitities = await _ctx.AdditionalEntity
                .Where(a => a.MasterSheetId == masterSheetId)
                .Include(a => a.AdditionalEntityOwner)
                .ToListAsync();

            return new DataAccess.AffiliateInfo
            {
                CorpOwner = corpOwners,
                AdditionalEntity = additionalEnitities
            };
        }

        [HttpPut]
        public void Put(DataAccess.AffiliateInfo affiliateInfo)
        {
            _ctx.UpdateRange(affiliateInfo.CorpOwner);
            _ctx.UpdateRange(affiliateInfo.AdditionalEntity);
            foreach (var additionalEntity in affiliateInfo.AdditionalEntity)
            {
                foreach (var owner in additionalEntity.AdditionalEntityOwner)
                {
                    if (owner.OwnerName == null && owner.OwnerPercent == null)
                        _ctx.Remove(owner);
                }
            }
            _ctx.SaveChanges();
        }
    }

    ////GET: api/Affiliates/5
    //[HttpGet("{id}", Name = "Get")]
    //public string Get(int id)
    //{
    //    return "value";
    //}

    ////POST: api/Affiliates
    //[HttpPost]
    //public void Post([FromBody] string value)
    //{
    //}

    ////PUT: api/Affiliates/5

    ////DELETE: api/ApiWithActions/5
    //[HttpDelete("{id}")]
    //public void Delete(int id)
    //{
    //}
}
