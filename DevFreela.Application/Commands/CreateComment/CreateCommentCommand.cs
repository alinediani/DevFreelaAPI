using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevFreela.Application.Commands.CreateComment
{
    public class CreateCommentCommand : IRequest<Unit>
    {
        public string Content { get; set; }
        public int IdProject { get; set; }
        public int IdUser { get; set; }
    }
}
