using BL.Contracts.IMapper;
using BL.Contracts.Services;
using BL.DTO.Entities;
using DAL.Contracts.Repositories.Generic;
using Domains.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class DescriptionService : BaseService<TbDescription, DescriptionDto>, IDescriptionService
    {
        private readonly ITableRepository<TbDescription> _baseTableRepository;
        private readonly IBaseMapper _mapper;
        public DescriptionService(ITableRepository<TbDescription> baseTableRepository, IBaseMapper mapper) : base(baseTableRepository, mapper)
        {
            _baseTableRepository = baseTableRepository;
            _mapper = mapper;
        }
        public DescriptionDto Find(Expression<Func<TbDescription, bool>> predicate)
        {
           var entity = _baseTableRepository.Find(predicate);   
            var dto = _mapper.MapModel<TbDescription, DescriptionDto>(entity);
            return dto; 
        }
    }
}
