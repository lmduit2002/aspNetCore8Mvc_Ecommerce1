using aspNetCore8Mvc_Ecommerce1.Dtos;
using aspNetCore8Mvc_Ecommerce1.ViewModels;

namespace aspNetCore8Mvc_Ecommerce1.Intfs
{
    public interface IHangHoaAppService
    {
        Task<List<HangHoaVM>> HangHoa_SEARCH(HangHoaSearch? model);
    }
}
