using UnityEngine.Events;

namespace CupflowNetwork
{
    public class GetObtainedAchievementsIdsRequest : RequestHandler<string[], object>
    {
        const string ACTION = "getUserObtainedAchievementsIds";
        public GetObtainedAchievementsIdsRequest(UnityAction<string[]> OnResponse, UnityAction<string> OnError) : base(ACTION, null, OnResponse, OnError) { }
    }
}