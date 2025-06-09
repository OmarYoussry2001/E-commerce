using BL.DTO.Entities;
using BL.Services;
using DAL.Models;
using Domains.Entities;
using Shared.GeneralModels.SearchCriteriaModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Contracts.Services
{
    public interface ITypeService : IBaseService<TbType, TypeDto>
    {
        public new Task<bool> Save(TypeDto dto, Guid userId);

    }
}
