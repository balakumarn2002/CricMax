using IPL.Common.DBModels;

namespace IPL.Common.Interfaces
{
    public interface ITeamApi
    {
        Task<Team> GetAsync(int teamId);

        Task<string> SaveAsync(Team team);

        Task<string> DeleteAsync(int teamId);
    }
}
