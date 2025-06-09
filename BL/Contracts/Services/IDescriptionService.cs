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
    public interface IDescriptionService : IBaseService<TbDescription, DescriptionDto>
    {
        public DescriptionDto Find(Expression<Func<TbDescription, bool>> predicate);
    }
}
