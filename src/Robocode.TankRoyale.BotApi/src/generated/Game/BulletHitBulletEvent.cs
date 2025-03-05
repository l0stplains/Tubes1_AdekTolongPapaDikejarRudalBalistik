//----------------------
// <auto-generated>
//     Generated using the NJsonSchema v11.0.2.0 (Newtonsoft.Json v13.0.0.0) (http://NJsonSchema.org)
// </auto-generated>
//----------------------


namespace Robocode.TankRoyale.Schema.Game
{
    #pragma warning disable // Disable all warnings

    /// <summary>
    /// Event occurring when a bullet has hit another bullet
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "11.0.2.0 (Newtonsoft.Json v13.0.0.0)")]
    public class BulletHitBulletEvent : Event
    {
        /// <summary>
        /// Bullet that hit another bullet
        /// </summary>
        [Newtonsoft.Json.JsonProperty("bullet", Required = Newtonsoft.Json.Required.Always)]
        public BulletState Bullet { get; set; }

        /// <summary>
        /// The other bullet that was hit by the bullet
        /// </summary>
        [Newtonsoft.Json.JsonProperty("hitBullet", Required = Newtonsoft.Json.Required.Always)]
        public BulletState HitBullet { get; set; }


    }
}