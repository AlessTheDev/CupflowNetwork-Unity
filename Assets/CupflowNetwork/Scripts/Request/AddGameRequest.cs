using UnityEngine.Events;

namespace CupflowNetwork
{
    public class AddGameRequest : RequestHandler<bool, AddGameRequestParams>
    {
        const string ACTION = "addGame";
        public AddGameRequest(UnityAction<bool> OnResponse, UnityAction<string> OnError, AddGameRequestParams reqParams) : base(ACTION, reqParams, OnResponse, OnError) { }
    }
}