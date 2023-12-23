using UnityEngine.Events;

namespace CupflowNetwork
{
    public class GetGameAchievementsRequest : RequestHandler<Achievement[], GetGameAchievementsParams>
    {
        const string ACTION = "getGameAchievements";
        public GetGameAchievementsRequest(UnityAction<Achievement[]> OnResponse, UnityAction<string> OnError, GetGameAchievementsParams reqParams) : base(ACTION, reqParams, OnResponse, OnError) { }
    }
}