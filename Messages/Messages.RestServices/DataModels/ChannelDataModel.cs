namespace Messages.RestServices.DataModels
{
    using System;
    using System.Linq.Expressions;
    using System.Runtime.Serialization;
    using Messages.Data.Models;

    public class ChannelDataModel
    {
        public static Expression<Func<Channel, ChannelDataModel>> DataModel
        {
            get
            {
                return x => new ChannelDataModel()
                {
                    Id = x.Id,
                    Name =  x.Name
                };
            }
        }

        public int Id { get; set; }

        public string Name { get; set; }

    }
}