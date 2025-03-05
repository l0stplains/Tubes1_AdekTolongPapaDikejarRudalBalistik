//----------------------
// <auto-generated>
//     Generated using the NJsonSchema v11.0.2.0 (Newtonsoft.Json v13.0.0.0) (http://NJsonSchema.org)
// </auto-generated>
//----------------------


namespace Robocode.TankRoyale.Schema.Game
{
    #pragma warning disable // Disable all warnings

    /// <summary>
    /// Event occurring when game has ended. Gives all game results visible for a bot.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "11.0.2.0 (Newtonsoft.Json v13.0.0.0)")]
    public class GameEndedEventForBot : Message
    {
        /// <summary>
        /// Number of rounds played
        /// </summary>
        [Newtonsoft.Json.JsonProperty("numberOfRounds", Required = Newtonsoft.Json.Required.Always)]
        public int NumberOfRounds { get; set; }

        /// <summary>
        /// Bot results of the battle
        /// </summary>
        [Newtonsoft.Json.JsonProperty("results", Required = Newtonsoft.Json.Required.Always)]
        public ResultsForBot Results { get; set; }


    }
}