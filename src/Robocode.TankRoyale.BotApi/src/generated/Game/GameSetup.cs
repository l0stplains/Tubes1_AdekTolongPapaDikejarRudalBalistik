//----------------------
// <auto-generated>
//     Generated using the NJsonSchema v11.0.2.0 (Newtonsoft.Json v13.0.0.0) (http://NJsonSchema.org)
// </auto-generated>
//----------------------


namespace Robocode.TankRoyale.Schema.Game
{
    #pragma warning disable // Disable all warnings

    /// <summary>
    /// Game setup
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "11.0.2.0 (Newtonsoft.Json v13.0.0.0)")]
    public class GameSetup
    {
        /// <summary>
        /// Type of game
        /// </summary>
        [Newtonsoft.Json.JsonProperty("gameType", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string GameType { get; set; }

        /// <summary>
        /// Width of arena measured in units
        /// </summary>
        [Newtonsoft.Json.JsonProperty("arenaWidth", Required = Newtonsoft.Json.Required.Always)]
        public int ArenaWidth { get; set; }

        /// <summary>
        /// Flag specifying if the width of arena is fixed for this game type
        /// </summary>
        [Newtonsoft.Json.JsonProperty("isArenaWidthLocked", Required = Newtonsoft.Json.Required.Always)]
        public bool IsArenaWidthLocked { get; set; }

        /// <summary>
        /// Height of arena measured in units
        /// </summary>
        [Newtonsoft.Json.JsonProperty("arenaHeight", Required = Newtonsoft.Json.Required.Always)]
        public int ArenaHeight { get; set; }

        /// <summary>
        /// Flag specifying if the height of arena is fixed for this game type
        /// </summary>
        [Newtonsoft.Json.JsonProperty("isArenaHeightLocked", Required = Newtonsoft.Json.Required.Always)]
        public bool IsArenaHeightLocked { get; set; }

        /// <summary>
        /// Minimum number of bots participating in battle
        /// </summary>
        [Newtonsoft.Json.JsonProperty("minNumberOfParticipants", Required = Newtonsoft.Json.Required.Always)]
        public int MinNumberOfParticipants { get; set; }

        /// <summary>
        /// Flag specifying if the minimum number of bots participating in battle is fixed for this game type
        /// </summary>
        [Newtonsoft.Json.JsonProperty("isMinNumberOfParticipantsLocked", Required = Newtonsoft.Json.Required.Always)]
        public bool IsMinNumberOfParticipantsLocked { get; set; }

        /// <summary>
        /// Maximum number of bots participating in battle (is optional)
        /// </summary>
        [Newtonsoft.Json.JsonProperty("maxNumberOfParticipants", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? MaxNumberOfParticipants { get; set; }

        /// <summary>
        /// Flag specifying if the maximum number of bots participating in battle is fixed for this game type
        /// </summary>
        [Newtonsoft.Json.JsonProperty("isMaxNumberOfParticipantsLocked", Required = Newtonsoft.Json.Required.Always)]
        public bool IsMaxNumberOfParticipantsLocked { get; set; }

        /// <summary>
        /// Number of rounds in battle
        /// </summary>
        [Newtonsoft.Json.JsonProperty("numberOfRounds", Required = Newtonsoft.Json.Required.Always)]
        public int NumberOfRounds { get; set; }

        /// <summary>
        /// Flag specifying if the number-of-rounds is fixed for this game type
        /// </summary>
        [Newtonsoft.Json.JsonProperty("isNumberOfRoundsLocked", Required = Newtonsoft.Json.Required.Always)]
        public bool IsNumberOfRoundsLocked { get; set; }

        /// <summary>
        /// Gun cooling rate. The gun needs to cool down to a gun heat of zero before the gun is able to fire
        /// </summary>
        [Newtonsoft.Json.JsonProperty("gunCoolingRate", Required = Newtonsoft.Json.Required.Always)]
        public double GunCoolingRate { get; set; }

        /// <summary>
        /// Flag specifying if the gun cooling rate is fixed for this game type
        /// </summary>
        [Newtonsoft.Json.JsonProperty("isGunCoolingRateLocked", Required = Newtonsoft.Json.Required.Always)]
        public bool IsGunCoolingRateLocked { get; set; }

        /// <summary>
        /// Maximum number of inactive turns allowed, where a bot does not take any action before it is zapped by the game
        /// </summary>
        [Newtonsoft.Json.JsonProperty("maxInactivityTurns", Required = Newtonsoft.Json.Required.Always)]
        public int MaxInactivityTurns { get; set; }

        /// <summary>
        /// Flag specifying if the inactive turns is fixed for this game type
        /// </summary>
        [Newtonsoft.Json.JsonProperty("isMaxInactivityTurnsLocked", Required = Newtonsoft.Json.Required.Always)]
        public bool IsMaxInactivityTurnsLocked { get; set; }

        /// <summary>
        /// Turn timeout in microseconds (1 / 1,000,000 second) for sending intent after having received 'tick' message
        /// </summary>
        [Newtonsoft.Json.JsonProperty("turnTimeout", Required = Newtonsoft.Json.Required.Always)]
        public int TurnTimeout { get; set; }

        /// <summary>
        /// Number of turns before game ends
        /// </summary>
        [Newtonsoft.Json.JsonProperty("maxTurnCount", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? MaxTurnCount { get; set; }

        /// <summary>
        /// Flag specifying if the turn timeout is fixed for this game type
        /// </summary>
        [Newtonsoft.Json.JsonProperty("isTurnTimeoutLocked", Required = Newtonsoft.Json.Required.Always)]
        public bool IsTurnTimeoutLocked { get; set; }

        /// <summary>
        /// Time limit in microseconds (1 / 1,000,000 second) for sending ready message after having received 'game started' message
        /// </summary>
        [Newtonsoft.Json.JsonProperty("readyTimeout", Required = Newtonsoft.Json.Required.Always)]
        public int ReadyTimeout { get; set; }

        /// <summary>
        /// Flag specifying if the ready timeout is fixed for this game type
        /// </summary>
        [Newtonsoft.Json.JsonProperty("isReadyTimeoutLocked", Required = Newtonsoft.Json.Required.Always)]
        public bool IsReadyTimeoutLocked { get; set; }

        /// <summary>
        /// Default number of turns to show per second for an observer/UI
        /// </summary>
        [Newtonsoft.Json.JsonProperty("defaultTurnsPerSecond", Required = Newtonsoft.Json.Required.Always)]
        public int DefaultTurnsPerSecond { get; set; }


    }
}