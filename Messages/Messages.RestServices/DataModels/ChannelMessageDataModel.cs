using System.Web.WebPages;

namespace Messages.RestServices.DataModels
{
    using System;
    using System.Linq.Expressions;
    using Messages.Data.Models;

    public class ChannelMessageDataModel
    {
        public static Expression<Func<ChannelMessage, ChannelMessageDataModel>> DataModel
        {
            get
            {
                return x => new ChannelMessageDataModel()
                {
                   Text = x.Text,
                   UserName = x.User.UserName,
                   ChannelName = x.Channel.Name
                };
            }
        }
        
        public string Text { get; set; }

        public string UserName { get; set; }

        public string ChannelName { get; set; }

        public static ChannelMessageDataModel ReturnFix(ChannelMessage ch)
        {
            var chMessage = new ChannelMessageDataModel();
            chMessage.ChannelName = ch.Channel.Name;
            chMessage.Text = ch.Text;

            if (ch.UserId != null)
            {
                chMessage.UserName = ch.User.UserName;
            }

            return chMessage;
            
        }
    }
}