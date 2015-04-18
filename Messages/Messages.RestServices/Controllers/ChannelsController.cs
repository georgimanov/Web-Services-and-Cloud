namespace Messages.RestServices.Controllers
{
    using System;
    using System.Web.Http;
    using System.Linq;
    using System.Net;

    using Messages.Data.Models;
    using Messages.RestServices.BindingModels;
    using Messages.RestServices.DataModels;

    [RoutePrefix("api/channels")]
    public class ChannelsController : BaseApiController
    {
        [HttpGet]

        public IHttpActionResult Get()
        {
            var channels = this.Data.Channels
                .OrderBy(x => x.Name)
                .Select(ChannelDataModel.DataModel)
                .ToList();

            return this.Ok(channels);
        }

        [HttpGet]
        public IHttpActionResult GetChannelById(int id)
        {
            var channel = this.Data.Channels
                .Select(ChannelDataModel.DataModel)
                .FirstOrDefault(x => x.Id == id);

            if (channel == null)
            {
                return this.NotFound();
            }

            return this.Ok(channel);
        }

        [HttpPost]
        public IHttpActionResult PostChannel(ChannelBindingModel model)
        {
            if (model == null || !this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (this.Data.Channels.Any(x => x.Name == model.Name))
            {
                this.Conflict();
            }

            var channel = new Channel()
            {
                Name = model.Name
            };

            this.Data.Channels.Add(channel);
            this.Data.SaveChanges();

            return this.CreatedAtRoute("DefaultApi", new { id = channel.Id }, channel);
        }

        [HttpPut]
        public IHttpActionResult EditChannel(int id, ChannelBindingModel model)
        {
            if (model == null || !this.ModelState.IsValid)
            {
                this.BadRequest();
            }
            
            if (this.Data.Channels.Any(x => x.Name == model.Name))
            {
                return this.Conflict();
            }
            
            var channel = this.Data.Channels.FirstOrDefault(x => x.Id == id);
            if (channel == null)
            {
                return this.NotFound();
            }

            channel.Name = model.Name;
            this.Data.SaveChanges();

            return this.Ok(new {Message = string.Format("Channel #{0} editted succesfully", channel.Id)});
        }

        [HttpDelete]
        public IHttpActionResult DeleteChannel(int id)
        {
            var channel = this.Data.Channels.FirstOrDefault(x => x.Id == id);

            if (channel == null)
            {
                return this.NotFound();
            }

            if (channel.ChannelMessage.Any())
            {
                return this.Content(HttpStatusCode.Conflict,
                    new {Message = string.Format("Channel #{0} has message", channel.Id)});
            }
            
            this.Data.Channels.Remove(channel);
            this.Data.SaveChanges();
            
            return this.Ok(new { Message = string.Format("Channel #{0} deleted succesfully", channel.Id) });
        }
    }
}
