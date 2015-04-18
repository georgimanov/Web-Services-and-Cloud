﻿namespace Messages.RestServices.Controllers
{
    using System.Web.Http;

    using Messages.Data;
    public abstract class BaseApiController : ApiController
    {
        private MessagesDbContext data;

        protected BaseApiController()
            :this(new MessagesDbContext())
        {
        }

        protected BaseApiController(MessagesDbContext data)
        {
            this.Data = data;
        }

        protected MessagesDbContext Data
        {
            get { return this.data; }
            private set { this.data = value; }
        }
    }
}
