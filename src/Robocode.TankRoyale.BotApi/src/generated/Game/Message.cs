//----------------------
// <auto-generated>
//     Generated using the NJsonSchema v11.0.2.0 (Newtonsoft.Json v13.0.0.0) (http://NJsonSchema.org)
// </auto-generated>
//----------------------


namespace Robocode.TankRoyale.Schema.Game
{
    #pragma warning disable // Disable all warnings

    /// <summary>
    /// Abstract message exchanged between server and client
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "11.0.2.0 (Newtonsoft.Json v13.0.0.0)")]
    public class Message
    {
        [Newtonsoft.Json.JsonProperty("type", Required = Newtonsoft.Json.Required.Always)]
        public string Type { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "11.0.2.0 (Newtonsoft.Json v13.0.0.0)")]
    public enum MessageType
    {

        [System.Runtime.Serialization.EnumMember(Value = @"BotHandshake")]
        BotHandshake = 0,


        [System.Runtime.Serialization.EnumMember(Value = @"ControllerHandshake")]
        ControllerHandshake = 1,


        [System.Runtime.Serialization.EnumMember(Value = @"ObserverHandshake")]
        ObserverHandshake = 2,


        [System.Runtime.Serialization.EnumMember(Value = @"ServerHandshake")]
        ServerHandshake = 3,


        [System.Runtime.Serialization.EnumMember(Value = @"BotReady")]
        BotReady = 4,


        [System.Runtime.Serialization.EnumMember(Value = @"BotIntent")]
        BotIntent = 5,


        [System.Runtime.Serialization.EnumMember(Value = @"BotInfo")]
        BotInfo = 6,


        [System.Runtime.Serialization.EnumMember(Value = @"BotListUpdate")]
        BotListUpdate = 7,


        [System.Runtime.Serialization.EnumMember(Value = @"GameStartedEventForBot")]
        GameStartedEventForBot = 8,


        [System.Runtime.Serialization.EnumMember(Value = @"GameStartedEventForObserver")]
        GameStartedEventForObserver = 9,


        [System.Runtime.Serialization.EnumMember(Value = @"GameEndedEventForBot")]
        GameEndedEventForBot = 10,


        [System.Runtime.Serialization.EnumMember(Value = @"GameEndedEventForObserver")]
        GameEndedEventForObserver = 11,


        [System.Runtime.Serialization.EnumMember(Value = @"GameAbortedEvent")]
        GameAbortedEvent = 12,


        [System.Runtime.Serialization.EnumMember(Value = @"GamePausedEventForObserver")]
        GamePausedEventForObserver = 13,


        [System.Runtime.Serialization.EnumMember(Value = @"GameResumedEventForObserver")]
        GameResumedEventForObserver = 14,


        [System.Runtime.Serialization.EnumMember(Value = @"RoundStartedEvent")]
        RoundStartedEvent = 15,


        [System.Runtime.Serialization.EnumMember(Value = @"RoundEndedEventForBot")]
        RoundEndedEventForBot = 16,


        [System.Runtime.Serialization.EnumMember(Value = @"RoundEndedEventForObserver")]
        RoundEndedEventForObserver = 17,


        [System.Runtime.Serialization.EnumMember(Value = @"ChangeTps")]
        ChangeTps = 18,


        [System.Runtime.Serialization.EnumMember(Value = @"TpsChangedEvent")]
        TpsChangedEvent = 19,


        [System.Runtime.Serialization.EnumMember(Value = @"BotPolicyUpdate")]
        BotPolicyUpdate = 20,


        [System.Runtime.Serialization.EnumMember(Value = @"BotDeathEvent")]
        BotDeathEvent = 21,


        [System.Runtime.Serialization.EnumMember(Value = @"BotHitBotEvent")]
        BotHitBotEvent = 22,


        [System.Runtime.Serialization.EnumMember(Value = @"BotHitWallEvent")]
        BotHitWallEvent = 23,


        [System.Runtime.Serialization.EnumMember(Value = @"BulletFiredEvent")]
        BulletFiredEvent = 24,


        [System.Runtime.Serialization.EnumMember(Value = @"BulletHitBotEvent")]
        BulletHitBotEvent = 25,


        [System.Runtime.Serialization.EnumMember(Value = @"BulletHitBulletEvent")]
        BulletHitBulletEvent = 26,


        [System.Runtime.Serialization.EnumMember(Value = @"BulletHitWallEvent")]
        BulletHitWallEvent = 27,


        [System.Runtime.Serialization.EnumMember(Value = @"HitByBulletEvent")]
        HitByBulletEvent = 28,


        [System.Runtime.Serialization.EnumMember(Value = @"ScannedBotEvent")]
        ScannedBotEvent = 29,


        [System.Runtime.Serialization.EnumMember(Value = @"SkippedTurnEvent")]
        SkippedTurnEvent = 30,


        [System.Runtime.Serialization.EnumMember(Value = @"TickEventForBot")]
        TickEventForBot = 31,


        [System.Runtime.Serialization.EnumMember(Value = @"TickEventForObserver")]
        TickEventForObserver = 32,


        [System.Runtime.Serialization.EnumMember(Value = @"WonRoundEvent")]
        WonRoundEvent = 33,


        [System.Runtime.Serialization.EnumMember(Value = @"TeamMessageEvent")]
        TeamMessageEvent = 34,


        [System.Runtime.Serialization.EnumMember(Value = @"StartGame")]
        StartGame = 35,


        [System.Runtime.Serialization.EnumMember(Value = @"StopGame")]
        StopGame = 36,


        [System.Runtime.Serialization.EnumMember(Value = @"PauseGame")]
        PauseGame = 37,


        [System.Runtime.Serialization.EnumMember(Value = @"ResumeGame")]
        ResumeGame = 38,


        [System.Runtime.Serialization.EnumMember(Value = @"NextTurn")]
        NextTurn = 39,


    }
}