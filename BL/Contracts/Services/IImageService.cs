using BL.DTO.Entities;
using Domains.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BL.Contracts.Services
{
    public interface IImageService : IBaseService<TbImage, ImageDto>
    {
        public IEnumerable<ImageDto> Get(Expression<Func<TbImage, bool>> predicate = null);

    }
}
