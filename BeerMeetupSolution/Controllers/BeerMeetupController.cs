using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using BeerMeetupSolution.Models;

namespace BeerMeetupSolution.Controllers
{
    [RoutePrefix("api/BeerMeetup")]
    public class BeerMeetupController : ApiController
    {

        [HttpGet]
        public async Task<IEnumerable<Models.BeerMeetup>> GetAsync()
        {

            IEnumerable<Models.BeerMeetup> value = await DocumentDBRepository<Models.BeerMeetup>.GetItemsAsync();
            return value;
        }

        [HttpPost]
        public async Task<Models.BeerMeetup> CreateAsync([FromBody] Models.BeerMeetup objbm)
        {
            if (ModelState.IsValid)
            {
                await DocumentDBRepository<Models.BeerMeetup>.CreateItemAsync(objbm);
                return objbm;
            }
            return null;
        }
        public async Task<string> Delete(string uid)
        {
            try
            {
                Models.BeerMeetup item = await DocumentDBRepository<Models.BeerMeetup>.GetSingleItemAsync(d => d.UId == uid);
                if (item == null)
                {
                    return "Failed";
                }
                await DocumentDBRepository<Models.BeerMeetup>.DeleteItemAsync(item.Id);
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        public async Task<Models.BeerMeetup> Put(string uid, [FromBody] Models.BeerMeetup o)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Models.BeerMeetup item = await DocumentDBRepository<Models.BeerMeetup>.GetSingleItemAsync(d => d.UId == uid);
                    if (item == null)
                    {
                        return null;
                    }
                    o.Id = item.Id;
                    await DocumentDBRepository<Models.BeerMeetup>.UpdateItemAsync(item.Id, o);
                    return o;
                }
                return null; ;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
    }
}
