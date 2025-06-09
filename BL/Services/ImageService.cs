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
    public class ImageService : BaseService<TbImage , ImageDto>, IImageService
    {
        private readonly ITableRepository<TbImage > _baseTableRepository;
        private readonly IBaseMapper _mapper;
        public ImageService(ITableRepository<TbImage > baseTableRepository, IBaseMapper mapper) : base(baseTableRepository, mapper)
        {
            _baseTableRepository = baseTableRepository;
            _mapper = mapper;
        }
        public  IEnumerable<ImageDto> Get(Expression<Func<TbImage, bool>> predicate = null)
        {
            var entitiesList = _baseTableRepository.Get(predicate);
            var dtoList = _mapper.MapList<TbImage, ImageDto>(entitiesList);
            return dtoList;

        }
    }
}
