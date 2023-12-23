namespace CupflowNetwork
{
    public struct GetGameAchievementsParams
    {
        public string GameId { get; set; }
        public GetGameAchievementsParams(string gameId)
        {
            GameId = gameId;
        }
    } 
}