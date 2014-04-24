﻿using ECommon.IoC;
using ENode.Commanding;
using Forum.Commands.Post;
using Forum.Domain.Posts;

namespace Forum.CommandHandlers
{
    [Component]
    internal sealed class PostCommandHandler :
        ICommandHandler<CreatePostCommand>,
        ICommandHandler<ChangePostCommand>
    {
        public void Handle(ICommandContext context, CreatePostCommand command)
        {
            context.Add(new Post(command.AggregateRootId, command.Subject, command.Body, command.SectionId, command.AuthorId));
        }
        public void Handle(ICommandContext context, ChangePostCommand command)
        {
            context.Get<Post>(command.AggregateRootId).ChangeSubjectAndBody(command.Subject, command.Body);
        }
    }
}