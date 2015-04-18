using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Messages.Data.Models
{
    public class Channel
    {
        public ICollection<ChannelMessage> channelMessage;

        public Channel()
        {
            this.channelMessage = new HashSet<ChannelMessage>();
        }

        [Key]
        public int Id { get; set; }

        [Index(IsUnique = true)]
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; }

        public virtual ICollection<ChannelMessage> ChannelMessage
        {
            get { return this.channelMessage; }
            set { this.channelMessage = value; }
        }
    }
}
