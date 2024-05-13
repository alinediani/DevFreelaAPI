using DevFreela.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevFreela.Application.Services.Interfaces
{
    public interface ISkillService
    {
        List<SkillViewModel> GetAll();
    }
}
