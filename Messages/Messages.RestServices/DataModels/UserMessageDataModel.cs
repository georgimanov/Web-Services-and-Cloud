

namespace Messages.RestServices.DataModels
{
    using System;
    using System.Linq.Expressions;
    using Messages.Data.Models;     

    public class UserMessageDataModel
    {
        public static Expression<Func<UserMessage, UserMessageDataModel>> DataModel
        {
            get
            {
                return x => new UserMessageDataModel()
                {
                    Text = x.Text,
                    SendToUsername = x.SendToUser.UserName,
                    SendByUsername = x.SendByUser.UserName
                };
            }
        }

        public string SendByUsername { get; set; }

        public string SendToUsername { get; set; }

        public string Text { get; set; }
    }
}