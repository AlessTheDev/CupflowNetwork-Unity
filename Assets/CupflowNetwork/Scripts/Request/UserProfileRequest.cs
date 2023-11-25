using UnityEngine.Events;

namespace CupflowNetwork
{
    public class UserProfileRequest : RequestHandler<UserProfile, object>
    {
        const string ACTION = "getUserProfile";
        public UserProfileRequest(UnityAction<UserProfile> OnResponse, UnityAction<string> OnError) : base(ACTION, null, OnResponse, OnError){}
    }
}