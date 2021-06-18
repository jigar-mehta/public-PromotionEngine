using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace PromotionEngine.Service.AutoPromotion.Controllers
{
    [ApiController]
    public class HealthCheckController : ControllerBase
    {
        [Route("ping")]
        public async Task<bool> Ping()
        {
            return true;
        }
    }
}
