namespace Messages.RestServices.Controllers
{
    using System;
    using System.Web.Http;
    using System.Linq;
    using System.Net;
    using Microsoft.AspNet.Identity;

    using Messages.Data.Models;
    using Messages.RestServices.BindingModels;
    using Messages.RestServices.DataModels;


    [RoutePrefix("api/channel-messages")]
    public class ChannelMessagesController : BaseApiController
    {
        [Route("{channelName}")]
        public IHttpActionResult GetAllChannelMessages(string channelName, int? limit = null)
        {
            if (!this.Data.Channels.Any(x => x.Name == channelName))
            {
                return this.BadRequest(string.Format("No such channel {0} in id", channelName));
            }

            var channelMessages = this.Data.ChannelMessages
                .Where(x => x.Channel.Name == channelName)
                .Select(ChannelMessageDataModel.DataModel);

            if (limit.HasValue)
            {
                channelMessages = channelMessages.Take(limit.Value);
            }

            return this.Ok(channelMessages);
        }

        [Route(Name = "GetById")]
        public IHttpActionResult GetById(int id)
        {
            var channelMessage = this.Data.ChannelMessages
                .Where(x => x.Id == id)
                .Select(ChannelMessageDataModel.DataModel)
                .FirstOrDefault();

            return this.Ok(channelMessage);
        }


        //TODO: Fix response
        [HttpPost]
        [Route("{channelName}")]
        public IHttpActionResult PostMessage(string channelName, ChannelMessageBindingModel model)
        {
            if (model == null)
            {
                return this.BadRequest();
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var channel = this.Data.Channels
                .FirstOrDefault(x => x.Name == channelName);

            if (channel == null)
            {
                return this.BadRequest("No existing channel");
            }

            var channelMessage = new ChannelMessage
            {
                Text = model.Text,
                ChannelId = channel.Id
            };

            if (this.User.Identity.IsAuthenticated)
            {
                channelMessage.UserId = this.User.Identity.GetUserId();
            }

            this.Data.ChannelMessages.Add(channelMessage);
            this.Data.SaveChanges();

            //return this.Ok("message created");
            return this.CreatedAtRoute("GetById", new { id = channelMessage.Id },  
                this.Data.ChannelMessages
                .Where(x => x.Id == channelMessage.Id)
                .Select(ChannelMessageDataModel.DataModel)
                .FirstOrDefault());
        }
    }
}
