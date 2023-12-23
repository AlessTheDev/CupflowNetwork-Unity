namespace CupflowNetwork
{
    [System.Serializable]
    public struct Achievement
    {
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string image { get; set; }
        public Game game { get; set; }
    }
}