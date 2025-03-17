using IPL.Models;
using IPL.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Aveon.CMS.Model;

namespace IPL.Service
{
    public class TeamApi : ITeamApi
    {
        private readonly CricketContext _cricketContext;

        public TeamApi(CricketContext cricketContext)
        {
            _cricketContext = cricketContext;
        }

        public async Task<ICollection<Common.Models.Team>> GetAsync(int teamId)
        {
            try
            {
                var teams = await (from t in _cricketContext.Teams.AsNoTracking()
                                   where t.TeamSeq == teamId
                                   select new Common.Models.Team
                                   {
                                       IplSeq = t.IplSeq,
                                       TeamName = t.TeamName,
                                       TeamSeq = t.TeamSeq,
                                       NoOfPlayers = t.NoOfPlayers,
                                       TeamSponsor = t.TeamSponsor,
                                       TeamStadium = t.TeamStadium,
                                       NoOfTrophy = t.NoOfTrophy
                                   }).ToListAsync();

                return teams;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occured while getting team", ex);
            }
        }

        public async Task<ApiResult<string>> SaveAsync(Common.Models.Team team)
        {
            var result = new ApiResult<string>();

            try
            {
                var dbTeam = await _cricketContext.Teams.Where(i => i.TeamSeq == team.TeamSeq).FirstOrDefaultAsync();

                if (dbTeam == null)
                {
                    dbTeam = new Team();
                    dbTeam.CreatedBySeq = 1;
                    dbTeam.CreatedByDtTm = DateTime.Now;
                    _cricketContext.Teams.Add(dbTeam);
                }

                dbTeam.ModifiedDtTm = DateTime.Now;
                dbTeam.ModifiedBySeq = 1;
                dbTeam.TeamName = team.TeamName;
                dbTeam.TeamSponsor = team.TeamSponsor;
                dbTeam.TeamStadium = team.TeamStadium;
                dbTeam.NoOfPlayers = team.NoOfPlayers;
                dbTeam.NoOfTrophy = team.NoOfTrophy;
                dbTeam.IplSeq = team.IplSeq;

                await _cricketContext.SaveChangesAsync();

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while saving", ex);
            }
        }

        public async Task<ApiResult<string>> DeleteAsync(int teamId)
        {
            var result = new ApiResult<string>();

            try
            {
                var dbTeam = await _cricketContext.Teams.FirstOrDefaultAsync(i => i.TeamSeq == teamId);

                if (dbTeam == null)
                {
                    throw new Exception("The team is not found");

                }
                _cricketContext.Remove(dbTeam);

                return result;


            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while deleting", ex);
            }
        }
    }
}
