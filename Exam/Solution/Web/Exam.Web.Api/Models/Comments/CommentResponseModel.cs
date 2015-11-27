namespace Exam.Web.Api.Models.Comments
{
    using System;
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mappings;

    public class CommentResponseModel : IMapFrom<Comment>, IHaveCustomMappings
    {
        public string Content
        {
            get; set;
        }

        public string UserName
        {
            get; set;
        }

        public DateTime CreatedOn
        {
            get; set;
        }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Comment, CommentResponseModel>()
                .ForMember(c => c.Content, opts => opts.MapFrom(c => c.Content))
                .ForMember(c => c.UserName, opts => opts.MapFrom(c => c.UserName.UserName))
                .ForMember(c => c.CreatedOn, opts => opts.MapFrom(c => c.DateMade));
        }
    }
}