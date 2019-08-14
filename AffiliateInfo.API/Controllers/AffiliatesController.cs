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
                CorpOwners = corpOwners,
                AdditionalEntities = additionalEnitities
            };
        }

        [HttpPut]
        public void Put(DataAccess.AffiliateInfo affiliateInfo)
        {
            foreach (var corpOwner in affiliateInfo.CorpOwners)
            {
                if ((corpOwner.CorpOwnerName == null) && (corpOwner.CorpOwnerPercent == null))
                {
                    _ctx.Remove(corpOwner);
                }
            }
            foreach (var additionalEntity in affiliateInfo.AdditionalEntities)
            {
                if ((additionalEntity.LegalName == null) && (additionalEntity.Dbaname == null) && (additionalEntity.Zip == null))
                {
                    _ctx.Remove(additionalEntity);
                }
            }
            foreach (var additionalEntity in affiliateInfo.AdditionalEntities)
            {
                foreach (var entityOwner in additionalEntity.AdditionalEntityOwner)
                {
                    if ((entityOwner.OwnerName == null) && (entityOwner.OwnerPercent == null))
                    {
                        _ctx.Remove(entityOwner);
                    }
                }
            }

            _ctx.UpdateRange(affiliateInfo.CorpOwners);
            _ctx.UpdateRange(affiliateInfo.AdditionalEntities);
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