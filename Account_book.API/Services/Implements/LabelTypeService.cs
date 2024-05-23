using Account_book.API.Domain.Response;
using Account_book.API.Repositories.Interfaces;
using Account_book.API.Services.Interfaces;

namespace Account_book.API.Services.Implements
{
    public class LabelTypeService: ILabelTypeService
    {
        private readonly ILabelTypeRepository _labelTypeRepository;
        public LabelTypeService(ILabelTypeRepository labelTypeRepository) 
        {
            _labelTypeRepository = labelTypeRepository;
        }

        public async Task<IResultResponse> GetAll() 
        {
            var result = await _labelTypeRepository.GetAll();
            return ResponseExtension.Query.QuerySuccess(result);
        }
    }
}
