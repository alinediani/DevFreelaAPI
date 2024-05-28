using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevFreela.Application.Commands.UpdateProject
{
    public class UpdateProjectCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal TotalCost { get; set; }
    }
}
