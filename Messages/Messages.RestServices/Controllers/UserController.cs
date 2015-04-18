namespace Messages.RestServices.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using Messages.Data.Models;
    using Messages.RestServices.BindingModels;
    using Messages.RestServices.DataModels;
    using Microsoft.AspNet.Identity;


    [RoutePrefix("api/user/personal-messages")]
    public class UserController : BaseApiController
    {

        [HttpGet]
        [Authorize]
        public IHttpActionResult GetAllPersonalMessages()
        {
            var userId = this.User.Identity.GetUserId();
            var messages = this.Data.UserMessages
                .Where(x => x.SendToUserId == userId)
                .Select(UserMessageDataModel.DataModel);

            return this.Ok(messages);
        }

        [HttpPost]
        [AllowAnonymous]
        public IHttpActionResult PostPersonalMessage(UserMessageBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (model == null)
            {
                return this.BadRequest();
            }

            var sendToUser = this.Data.Users.FirstOrDefault(u => u.UserName == model.Recepient);

            if (sendToUser == null)
            {
                this.BadRequest("No such recepient found");
            }

            var userMessage = new UserMessage
            {
                SendToUserId = sendToUser.Id,
                Text = model.Text
            };

            if (this.User.Identity.IsAuthenticated)
            {
                userMessage.SendByUserId = this.User.Identity.GetUserId();
            }

            this.Data.UserMessages.Add(userMessage);
            this.Data.SaveChanges();

            return this.Ok(userMessage);
        }
    }
}
