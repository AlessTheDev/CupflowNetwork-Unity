namespace CupflowNetwork
{
    public struct AddGameRequestParams
    {
        public string GameId { get; set; }
        public string GameSecret { get; set; }  

        public AddGameRequestParams(string gameId, string gameSecret)
        {
            GameId = gameId;
            GameSecret = gameSecret;
        }
    }
}