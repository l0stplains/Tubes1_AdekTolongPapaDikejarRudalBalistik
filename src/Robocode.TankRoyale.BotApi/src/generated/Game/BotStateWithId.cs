//----------------------
// <auto-generated>
//     Generated using the NJsonSchema v11.0.2.0 (Newtonsoft.Json v13.0.0.0) (http://NJsonSchema.org)
// </auto-generated>
//----------------------


namespace Robocode.TankRoyale.Schema.Game
{
    #pragma warning disable // Disable all warnings

    /// <summary>
    /// Current state of a bot, which included an id
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "11.0.2.0 (Newtonsoft.Json v13.0.0.0)")]
    public class BotStateWithId : BotState
    {
        /// <summary>
        /// Unique display id of bot in the battle (like an index).
        /// </summary>
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Always)]
        public int Id { get; set; }

        /// <summary>
        /// Unique session id used for identifying the bot.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("sessionId", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string SessionId { get; set; }

        /// <summary>
        /// Last data received for standard out (stdout)
        /// </summary>
        [Newtonsoft.Json.JsonProperty("stdOut", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string StdOut { get; set; }

        /// <summary>
        /// Last data received for standard err (stderr)
        /// </summary>
        [Newtonsoft.Json.JsonProperty("stdErr", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string StdErr { get; set; }

        /// <summary>
        /// Debug graphics to be drawn as overlay on the battlefield if debugging is enabled
        /// </summary>
        [Newtonsoft.Json.JsonProperty("debugGraphics", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string DebugGraphics { get; set; }


    }
}