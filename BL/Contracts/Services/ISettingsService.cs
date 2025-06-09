using BL.DTO.Entities;
using BL.Services;
using DAL.Models;
using Domains.Entities;

using Shared.GeneralModels.SearchCriteriaModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BL.Contracts.Services
{
    public interface ISettingsService : IBaseService<TbSettings, SettingsDto>
    {
        public new Task<bool> Save(SettingsDto dto, Guid userId);
        public SettingsDto GetSettings();

    }
}
