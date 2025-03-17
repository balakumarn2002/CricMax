using Aveon.CMS.Model;
using IPL.Common.Models;

namespace IPL.Common.Interfaces
{
    public interface ITeamApi
    {
        Task<ICollection<Common.Models.Team>> GetAsync(int teamId);

        Task<ApiResult<string>> SaveAsync(Common.Models.Team team);

        Task<ApiResult<string>> DeleteAsync(int teamId);
    }
}
