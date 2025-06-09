namespace BL.Contracts.Services
{
    public interface IBaseService<TS, TD>
    {
        IEnumerable<TD> GetAll();
        TD FindById(Guid Id);
        bool Save(TD entity, Guid userId);
        bool Create(TD entity, Guid creatorId);
        bool Update(TD entity, Guid updaterId);
        bool Delete(Guid id);
    }
}
