using aspNetCore8Mvc_Ecommerce1.Data;

namespace aspNetCore8Mvc_Ecommerce1.Models.Services.HangHoa
{
    public class HangHoaServicesInject
    {
        private readonly Hshop2023Context _context;
        public HangHoaServicesInject(Hshop2023Context context)
        {
            _context = context;
        }

        public int Test() { return 1; }
    }
}
