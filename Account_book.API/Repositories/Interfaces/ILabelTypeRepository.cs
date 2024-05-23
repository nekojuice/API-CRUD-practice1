using Account_book.API.Domain.Entity;

namespace Account_book.API.Repositories.Interfaces
{
    public interface ILabelTypeRepository
    {
        public Task<IEnumerable<LabelType>> GetAll();
    }
}
