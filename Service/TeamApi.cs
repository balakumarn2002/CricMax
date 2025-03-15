using IPL.Common.DBModels;
using IPL.Common.Interfaces;

namespace IPL.Service
{
    public class TeamApi : ITeamApi
    {
        private readonly CricketContext _cricketContext;

        public TeamApi(CricketContext cricketContext)
        {
            _cricketContext = cricketContext;
        }

        public Task<Team> GetAsync(int teamId)
        {
            throw new NotImplementedException();
        }
        public Task<string> DeleteAsync(int teamId)
        {
            throw new NotImplementedException();
        }

                public Task<string> SaveAsync(Team team)
        {
            throw new NotImplementedException();
        }
    }
}
