using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Robocode.TankRoyale.BotApi;
using Robocode.TankRoyale.BotApi.Events;
using SvgNet.Interfaces;

namespace Tubes1_AdekTolongPapaDikejarRudalBalistik.DantolBot;

public interface IBotHandle {
    public Task Go();
    public int MyId { get; }
    public string Variant { get; }
    public string Version { get; }
    public string GameType { get; }
    public int ArenaWidth { get; }
    public int ArenaHeight { get; }
    public int NumberOfRounds { get; }
    public double GunCoolingRate { get; }
    public int? MaxInactivityTurns { get; }
    public int TurnTimeout { get; }
    public int TimeLeft { get; }
    public int RoundNumber { get; }
    public int TurnNumber { get; }
    public int EnemyCount { get; }
    public double Energy { get; }
    public bool IsDisabled { get; }
    public double X { get; }
    public double Y { get; }
    public double Direction { get; }
    public double GunDirection { get; }
    public double RadarDirection { get; }
    public double Speed { get; }
    public double GunHeat { get; }
    public IEnumerable<BulletState> BulletStates { get; }
    public IList<BotEvent> Events { get; }
    public void ClearEvents();
    public double TurnRate { get; set; }
    public double MaxTurnRate { get; set; }
    public double GunTurnRate { get; set; }
    public double MaxGunTurnRate { get; set; }
    public double RadarTurnRate { get; set; }
    public double MaxRadarTurnRate { get; set; }
    public double TargetSpeed { get; set; }
    public double MaxSpeed { get; set; }
    public bool SetFire(double firepower);
    public double Firepower { get; }
    public void SetRescan();
    public void SetFireAssist(bool enable);
    public bool Interruptible { set; }
    public bool AdjustGunForBodyTurn { get; set; }
    public bool AdjustRadarForBodyTurn { get; set; }
    public bool AdjustRadarForGunTurn { get; set; }
    public bool AddCustomEvent(Condition condition);
    public bool RemoveCustomEvent(Condition condition);
    public void SetStop();
    public void SetStop(bool overwrite);
    public void SetResume();
    public bool IsStopped { get; }
    public ICollection<int> TeammateIds { get; }
    public bool IsTeammate(int botId);
    public void BroadcastTeamMessage(object message);
    public void SendTeamMessage(int teammateId, object message);
    public Color? BodyColor { get; set; }
    public Color? TurretColor { get; set; }
    public Color? RadarColor { get; set; }
    public Color? BulletColor { get; set; }
    public Color? ScanColor { get; set; }
    public Color? TracksColor { get; set; }
    public Color? GunColor { get; set; }
    public bool IsDebuggingEnabled { get; }
    public IGraphics Graphics { get; }
    public void AddConnectedEventListener(Action<ConnectedEvent> connectedEventListener);
    public void AddDisconnectedEventListener(Action<DisconnectedEvent> disconnectedEventListener);
    public void AddConnectionErrorEventListener(Action<ConnectionErrorEvent> connectionErrorEventListener);
    public void AddGameStartedEventListener(Action<GameStartedEvent> gameStatedEventListener);
    public void AddGameEndedEventListener(Action<GameEndedEvent> gameEndedEventListener);
    public void AddRoundStartedEventListener(Action<RoundStartedEvent> roundStartedEventListener);
    public void AddRoundEndedEventListener(Action<RoundEndedEvent> roundEndedEventListener);
    public void AddTickEventListener(Action<TickEvent> tickEventListener);
    public void AddBotDeathEventListener(Action<BotDeathEvent> botDeathEventListener);
    public void AddDeathEventListener(Action<DeathEvent> deathEventListener);
    public void AddHitBotEventListener(Action<HitBotEvent> botHitBotEventListener);
    public void AddHitWallEventListener(Action<HitWallEvent> botHitWallEventListener);
    public void AddBulletFiredEventListener(Action<BulletFiredEvent> bulletFiredEventListener);
    public void AddHitByBulletEventListener(Action<HitByBulletEvent> hitByBulletEventListener);
    public void AddBulletHitEventListener(Action<BulletHitBotEvent> bulletHitBotEventListener);
    public void AddBulletHitBulletEventListener(Action<BulletHitBulletEvent> bulletHitBulletEventListener);
    public void AddBulletHitWallEventListener(Action<BulletHitWallEvent> bulletHitWallEventListener);
    public void AddScannedBotEventListener(Action<ScannedBotEvent> scannedBotEventListener);
    public void AddSkippedTurnEventListener(Action<SkippedTurnEvent> skippedTurnEventListener);
    public void AddWonRoundEventListener(Action<WonRoundEvent> wonRoundEventListener);
    public void AddCustomEventEventListener(Action<CustomEvent> customEventListener);
    public void AddTeamMessageEventListener(Action<TeamMessageEvent> teamMessageEventListener);
    public void RemoveConnectedEventListener(Action<ConnectedEvent> connectedEventListener);
    public void RemoveDisconnectedEventListener(Action<DisconnectedEvent> disconnectedEventListener);
    public void RemoveConnectionErrorEventListener(Action<ConnectionErrorEvent> connectionErrorEventListener);
    public void RemoveGameStartedEventListener(Action<GameStartedEvent> gameStatedEventListener);
    public void RemoveGameEndedEventListener(Action<GameEndedEvent> gameEndedEventListener);
    public void RemoveRoundStartedEventListener(Action<RoundStartedEvent> roundStartedEventListener);
    public void RemoveRoundEndedEventListener(Action<RoundEndedEvent> roundEndedEventListener);
    public void RemoveTickEventListener(Action<TickEvent> tickEventListener);
    public void RemoveBotDeathEventListener(Action<BotDeathEvent> botDeathEventListener);
    public void RemoveDeathEventListener(Action<DeathEvent> deathEventListener);
    public void RemoveHitBotEventListener(Action<HitBotEvent> botHitBotEventListener);
    public void RemoveHitWallEventListener(Action<HitWallEvent> botHitWallEventListener);
    public void RemoveBulletFiredEventListener(Action<BulletFiredEvent> bulletFiredEventListener);
    public void RemoveHitByBulletEventListener(Action<HitByBulletEvent> hitByBulletEventListener);
    public void RemoveBulletHitEventListener(Action<BulletHitBotEvent> bulletHitBotEventListener);
    public void RemoveBulletHitBulletEventListener(Action<BulletHitBulletEvent> bulletHitBulletEventListener);
    public void RemoveBulletHitWallEventListener(Action<BulletHitWallEvent> bulletHitWallEventListener);
    public void RemoveScannedBotEventListener(Action<ScannedBotEvent> scannedBotEventListener);
    public void RemoveSkippedTurnEventListener(Action<SkippedTurnEvent> skippedTurnEventListener);
    public void RemoveWonRoundEventListener(Action<WonRoundEvent> wonRoundEventListener);
    public void RemoveCustomEventEventListener(Action<CustomEvent> customEventListener);
    public void RemoveTeamMessageEventListener(Action<TeamMessageEvent> teamMessageEventListener);
    public double CalcMaxTurnRate(double speed);
    public double CalcBulletSpeed(double firepower);
    public double CalcGunHeat(double firepower);
    public double CalcBearing(double direction);
    public double CalcGunBearing(double direction);
    public double CalcRadarBearing(double direction);
    public double DirectionTo(double x, double y);
    public double BearingTo(double x, double y);
    public double GunBearingTo(double x, double y);
    public double RadarBearingTo(double x, double y);
    public double DistanceTo(double x, double y);
    public double NormalizeAbsoluteAngle(double angle);
    public double NormalizeRelativeAngle(double angle);
    public double CalcDeltaAngle(double targetAngle, double sourceAngle);
    public int GetEventPriority(Type eventType);
    public void SetEventPriority(Type eventType, int priority);
    public bool IsRunning { get; }
    public void SetForward(double distance);
    public void SetBack(double distance);
    public double DistanceRemaining { get; }
    public void SetTurnLeft(double degrees);
    public void SetTurnRight(double degrees);
    public double TurnRemaining { get; }
    public void SetTurnGunLeft(double degrees);
    public void SetTurnGunRight(double degrees);
    public double GunTurnRemaining { get; }
    public void SetTurnRadarLeft(double degrees);
    public void SetTurnRadarRight(double degrees);
    public double RadarTurnRemaining { get; }
}
public class NativeBotHandle(Bot botImpl) : IBotHandle {
    private readonly Bot _botImpl = botImpl;
    private readonly ConcurrentDictionary<Action<ConnectedEvent>, bool> _connectedEventListeners = [];
    private readonly ConcurrentDictionary<Action<DisconnectedEvent>, bool> _disconnectedEventListeners = [];
    private readonly ConcurrentDictionary<Action<ConnectionErrorEvent>, bool> _connectionErrorEventListeners = [];
    private readonly ConcurrentDictionary<Action<GameStartedEvent>, bool> _gameStatedEventListeners = [];
    private readonly ConcurrentDictionary<Action<GameEndedEvent>, bool> _gameEndedEventListeners = [];
    private readonly ConcurrentDictionary<Action<RoundStartedEvent>, bool> _roundStartedEventListeners = [];
    private readonly ConcurrentDictionary<Action<RoundEndedEvent>, bool> _roundEndedEventListeners = [];
    private readonly ConcurrentDictionary<Action<TickEvent>, bool> _tickEventListeners = [];
    private readonly ConcurrentDictionary<Action<BotDeathEvent>, bool> _botDeathEventListeners = [];
    private readonly ConcurrentDictionary<Action<DeathEvent>, bool> _deathEventListeners = [];
    private readonly ConcurrentDictionary<Action<HitBotEvent>, bool> _botHitBotEventListeners = [];
    private readonly ConcurrentDictionary<Action<HitWallEvent>, bool> _botHitWallEventListeners = [];
    private readonly ConcurrentDictionary<Action<BulletFiredEvent>, bool> _bulletFiredEventListeners = [];
    private readonly ConcurrentDictionary<Action<HitByBulletEvent>, bool> _hitByBulletEventListeners = [];
    private readonly ConcurrentDictionary<Action<BulletHitBotEvent>, bool> _bulletHitBotEventListeners = [];
    private readonly ConcurrentDictionary<Action<BulletHitBulletEvent>, bool> _bulletHitBulletEventListeners = [];
    private readonly ConcurrentDictionary<Action<BulletHitWallEvent>, bool> _bulletHitWallEventListeners = [];
    private readonly ConcurrentDictionary<Action<ScannedBotEvent>, bool> _scannedBotEventListeners = [];
    private readonly ConcurrentDictionary<Action<SkippedTurnEvent>, bool> _skippedTurnEventListeners = [];
    private readonly ConcurrentDictionary<Action<WonRoundEvent>, bool> _wonRoundEventListeners = [];
    private readonly ConcurrentDictionary<Action<CustomEvent>, bool> _customEventListeners = [];
    private readonly ConcurrentDictionary<Action<TeamMessageEvent>, bool> _teamMessageEventListeners = [];
    public Func<Task>? WaitNextTurn;
    public Task Go() {
        if(WaitNextTurn is null)
            throw new Exception("Illegal invocation");
        return WaitNextTurn();
    }
    public int MyId { get => _botImpl.MyId; }
    public string Variant { get => _botImpl.Variant; }
    public string Version { get => _botImpl.Version; }
    public string GameType { get => _botImpl.GameType; }
    public int ArenaWidth { get => _botImpl.ArenaWidth; }
    public int ArenaHeight { get => _botImpl.ArenaHeight; }
    public int NumberOfRounds { get => _botImpl.NumberOfRounds; }
    public double GunCoolingRate { get => _botImpl.GunCoolingRate; }
    public int? MaxInactivityTurns { get => _botImpl.MaxInactivityTurns; }
    public int TurnTimeout { get => _botImpl.TurnTimeout; }
    public int TimeLeft { get => _botImpl.TimeLeft; }
    public int RoundNumber { get => _botImpl.RoundNumber; }
    public int TurnNumber { get => _botImpl.TurnNumber; }
    public int EnemyCount { get => _botImpl.EnemyCount; }
    public double Energy { get => _botImpl.Energy; }
    public bool IsDisabled { get => _botImpl.IsDisabled; }
    public double X { get => _botImpl.X; }
    public double Y { get => _botImpl.Y; }
    public double Direction { get => _botImpl.Direction; }
    public double GunDirection { get => _botImpl.GunDirection; }
    public double RadarDirection { get => _botImpl.RadarDirection; }
    public double Speed { get => _botImpl.Speed; }
    public double GunHeat { get => _botImpl.GunHeat; }
    public IEnumerable<BulletState> BulletStates { get => _botImpl.BulletStates; }
    public IList<BotEvent> Events { get => _botImpl.Events; }
    public void ClearEvents() {}
    public double TurnRate { get => _botImpl.TurnRate; set => _botImpl.TurnRate = value; }
    public double MaxTurnRate { get => _botImpl.MaxTurnRate; set => _botImpl.MaxTurnRate = value; }
    public double GunTurnRate { get => _botImpl.GunTurnRate; set => _botImpl.GunTurnRate = value; }
    public double MaxGunTurnRate { get => _botImpl.MaxGunTurnRate; set => _botImpl.MaxGunTurnRate = value; }
    public double RadarTurnRate { get => _botImpl.RadarTurnRate; set => _botImpl.RadarTurnRate = value; }
    public double MaxRadarTurnRate { get => _botImpl.MaxRadarTurnRate; set => _botImpl.MaxRadarTurnRate = value; }
    public double TargetSpeed { get => _botImpl.TargetSpeed; set => _botImpl.TargetSpeed = value; }
    public double MaxSpeed { get => _botImpl.MaxSpeed; set => _botImpl.MaxSpeed = value; }
    public bool SetFire(double firepower) => _botImpl.SetFire(firepower);
    public double Firepower { get => _botImpl.Firepower; }
    public void SetRescan() => _botImpl.SetRescan();
    public void SetFireAssist(bool enable) => _botImpl.SetFireAssist(enable);
    public bool Interruptible { set => _botImpl.Interruptible = value; }
    public bool AdjustGunForBodyTurn { get => _botImpl.AdjustGunForBodyTurn; set => _botImpl.AdjustGunForBodyTurn = value; }
    public bool AdjustRadarForBodyTurn { get => _botImpl.AdjustRadarForBodyTurn; set => _botImpl.AdjustRadarForBodyTurn = value; }
    public bool AdjustRadarForGunTurn { get => _botImpl.AdjustRadarForGunTurn; set => _botImpl.AdjustRadarForGunTurn = value; }
    public bool AddCustomEvent(Condition condition) => _botImpl.AddCustomEvent(condition);
    public bool RemoveCustomEvent(Condition condition) => _botImpl.RemoveCustomEvent(condition);
    public void SetStop() => _botImpl.SetStop();
    public void SetStop(bool overwrite) => _botImpl.SetStop(overwrite);
    public void SetResume() => _botImpl.SetResume();
    public bool IsStopped { get => _botImpl.IsStopped; }
    public ICollection<int> TeammateIds { get => _botImpl.TeammateIds; }
    public bool IsTeammate(int botId) => _botImpl.IsTeammate(botId);
    public void BroadcastTeamMessage(object message) => _botImpl.BroadcastTeamMessage(message);
    public void SendTeamMessage(int teammateId, object message) => _botImpl.SendTeamMessage(teammateId, message);
    public Color? BodyColor { get => _botImpl.BodyColor; set => _botImpl.BodyColor = value; }
    public Color? TurretColor { get => _botImpl.TurretColor; set => _botImpl.TurretColor = value; }
    public Color? RadarColor { get => _botImpl.RadarColor; set => _botImpl.RadarColor = value; }
    public Color? BulletColor { get => _botImpl.BulletColor; set => _botImpl.BulletColor = value; }
    public Color? ScanColor { get => _botImpl.ScanColor; set => _botImpl.ScanColor = value; }
    public Color? TracksColor { get => _botImpl.TracksColor; set => _botImpl.TracksColor = value; }
    public Color? GunColor { get => _botImpl.GunColor; set => _botImpl.GunColor = value; }
    public bool IsDebuggingEnabled { get => _botImpl.IsDebuggingEnabled; }
    public IGraphics Graphics { get => _botImpl.Graphics; }
    public void AddConnectedEventListener(Action<ConnectedEvent> connectedEventListener) => _connectedEventListeners.TryAdd(connectedEventListener, true);
    public void AddDisconnectedEventListener(Action<DisconnectedEvent> disconnectedEventListener) => _disconnectedEventListeners.TryAdd(disconnectedEventListener, true);
    public void AddConnectionErrorEventListener(Action<ConnectionErrorEvent> connectionErrorEventListener) => _connectionErrorEventListeners.TryAdd(connectionErrorEventListener, true);
    public void AddGameStartedEventListener(Action<GameStartedEvent> gameStatedEventListener) => _gameStatedEventListeners.TryAdd(gameStatedEventListener, true);
    public void AddGameEndedEventListener(Action<GameEndedEvent> gameEndedEventListener) => _gameEndedEventListeners.TryAdd(gameEndedEventListener, true);
    public void AddRoundStartedEventListener(Action<RoundStartedEvent> roundStartedEventListener) => _roundStartedEventListeners.TryAdd(roundStartedEventListener, true);
    public void AddRoundEndedEventListener(Action<RoundEndedEvent> roundEndedEventListener) => _roundEndedEventListeners.TryAdd(roundEndedEventListener, true);
    public void AddTickEventListener(Action<TickEvent> tickEventListener) => _tickEventListeners.TryAdd(tickEventListener, true);
    public void AddBotDeathEventListener(Action<BotDeathEvent> botDeathEventListener) => _botDeathEventListeners.TryAdd(botDeathEventListener, true);
    public void AddDeathEventListener(Action<DeathEvent> deathEventListener) => _deathEventListeners.TryAdd(deathEventListener, true);
    public void AddHitBotEventListener(Action<HitBotEvent> botHitBotEventListener) => _botHitBotEventListeners.TryAdd(botHitBotEventListener, true);
    public void AddHitWallEventListener(Action<HitWallEvent> botHitWallEventListener) => _botHitWallEventListeners.TryAdd(botHitWallEventListener, true);
    public void AddBulletFiredEventListener(Action<BulletFiredEvent> bulletFiredEventListener) => _bulletFiredEventListeners.TryAdd(bulletFiredEventListener, true);
    public void AddHitByBulletEventListener(Action<HitByBulletEvent> hitByBulletEventListener) => _hitByBulletEventListeners.TryAdd(hitByBulletEventListener, true);
    public void AddBulletHitEventListener(Action<BulletHitBotEvent> bulletHitBotEventListener) => _bulletHitBotEventListeners.TryAdd(bulletHitBotEventListener, true);
    public void AddBulletHitBulletEventListener(Action<BulletHitBulletEvent> bulletHitBulletEventListener) => _bulletHitBulletEventListeners.TryAdd(bulletHitBulletEventListener, true);
    public void AddBulletHitWallEventListener(Action<BulletHitWallEvent> bulletHitWallEventListener) => _bulletHitWallEventListeners.TryAdd(bulletHitWallEventListener, true);
    public void AddScannedBotEventListener(Action<ScannedBotEvent> scannedBotEventListener) => _scannedBotEventListeners.TryAdd(scannedBotEventListener, true);
    public void AddSkippedTurnEventListener(Action<SkippedTurnEvent> skippedTurnEventListener) => _skippedTurnEventListeners.TryAdd(skippedTurnEventListener, true);
    public void AddWonRoundEventListener(Action<WonRoundEvent> wonRoundEventListener) => _wonRoundEventListeners.TryAdd(wonRoundEventListener, true);
    public void AddCustomEventEventListener(Action<CustomEvent> customEventListener) => _customEventListeners.TryAdd(customEventListener, true);
    public void AddTeamMessageEventListener(Action<TeamMessageEvent> teamMessageEventListener) => _teamMessageEventListeners.TryAdd(teamMessageEventListener, true);
    public void RemoveConnectedEventListener(Action<ConnectedEvent> connectedEventListener) => _connectedEventListeners.TryRemove(connectedEventListener, out _);
    public void RemoveDisconnectedEventListener(Action<DisconnectedEvent> disconnectedEventListener) => _disconnectedEventListeners.TryRemove(disconnectedEventListener, out _);
    public void RemoveConnectionErrorEventListener(Action<ConnectionErrorEvent> connectionErrorEventListener) => _connectionErrorEventListeners.TryRemove(connectionErrorEventListener, out _);
    public void RemoveGameStartedEventListener(Action<GameStartedEvent> gameStatedEventListener) => _gameStatedEventListeners.TryRemove(gameStatedEventListener, out _);
    public void RemoveGameEndedEventListener(Action<GameEndedEvent> gameEndedEventListener) => _gameEndedEventListeners.TryRemove(gameEndedEventListener, out _);
    public void RemoveRoundStartedEventListener(Action<RoundStartedEvent> roundStartedEventListener) => _roundStartedEventListeners.TryRemove(roundStartedEventListener, out _);
    public void RemoveRoundEndedEventListener(Action<RoundEndedEvent> roundEndedEventListener) => _roundEndedEventListeners.TryRemove(roundEndedEventListener, out _);
    public void RemoveTickEventListener(Action<TickEvent> tickEventListener) => _tickEventListeners.TryRemove(tickEventListener, out _);
    public void RemoveBotDeathEventListener(Action<BotDeathEvent> botDeathEventListener) => _botDeathEventListeners.TryRemove(botDeathEventListener, out _);
    public void RemoveDeathEventListener(Action<DeathEvent> deathEventListener) => _deathEventListeners.TryRemove(deathEventListener, out _);
    public void RemoveHitBotEventListener(Action<HitBotEvent> botHitBotEventListener) => _botHitBotEventListeners.TryRemove(botHitBotEventListener, out _);
    public void RemoveHitWallEventListener(Action<HitWallEvent> botHitWallEventListener) => _botHitWallEventListeners.TryRemove(botHitWallEventListener, out _);
    public void RemoveBulletFiredEventListener(Action<BulletFiredEvent> bulletFiredEventListener) => _bulletFiredEventListeners.TryRemove(bulletFiredEventListener, out _);
    public void RemoveHitByBulletEventListener(Action<HitByBulletEvent> hitByBulletEventListener) => _hitByBulletEventListeners.TryRemove(hitByBulletEventListener, out _);
    public void RemoveBulletHitEventListener(Action<BulletHitBotEvent> bulletHitBotEventListener) => _bulletHitBotEventListeners.TryRemove(bulletHitBotEventListener, out _);
    public void RemoveBulletHitBulletEventListener(Action<BulletHitBulletEvent> bulletHitBulletEventListener) => _bulletHitBulletEventListeners.TryRemove(bulletHitBulletEventListener, out _);
    public void RemoveBulletHitWallEventListener(Action<BulletHitWallEvent> bulletHitWallEventListener) => _bulletHitWallEventListeners.TryRemove(bulletHitWallEventListener, out _);
    public void RemoveScannedBotEventListener(Action<ScannedBotEvent> scannedBotEventListener) => _scannedBotEventListeners.TryRemove(scannedBotEventListener, out _);
    public void RemoveSkippedTurnEventListener(Action<SkippedTurnEvent> skippedTurnEventListener) => _skippedTurnEventListeners.TryRemove(skippedTurnEventListener, out _);
    public void RemoveWonRoundEventListener(Action<WonRoundEvent> wonRoundEventListener) => _wonRoundEventListeners.TryRemove(wonRoundEventListener, out _);
    public void RemoveCustomEventEventListener(Action<CustomEvent> customEventListener) => _customEventListeners.TryRemove(customEventListener, out _);
    public void RemoveTeamMessageEventListener(Action<TeamMessageEvent> teamMessageEventListener) => _teamMessageEventListeners.TryRemove(teamMessageEventListener, out _);
    public void OnConnected(ConnectedEvent connectedEvent) { foreach(var connectedEventListener in _connectedEventListeners.Keys) connectedEventListener(connectedEvent); }
    public void OnDisconnected(DisconnectedEvent disconnectedEvent) { foreach(var disconnectedEventListener in _disconnectedEventListeners.Keys) disconnectedEventListener(disconnectedEvent); }
    public void OnConnectionError(ConnectionErrorEvent connectionErrorEvent) { foreach(var connectionErrorEventListener in _connectionErrorEventListeners.Keys) connectionErrorEventListener(connectionErrorEvent); }
    public void OnGameStarted(GameStartedEvent gameStatedEvent) { foreach(var gameStatedEventListener in _gameStatedEventListeners.Keys) gameStatedEventListener(gameStatedEvent); }
    public void OnGameEnded(GameEndedEvent gameEndedEvent) { foreach(var gameEndedEventListener in _gameEndedEventListeners.Keys) gameEndedEventListener(gameEndedEvent); }
    public void OnRoundStarted(RoundStartedEvent roundStartedEvent) { foreach(var roundStartedEventListener in _roundStartedEventListeners.Keys) roundStartedEventListener(roundStartedEvent); }
    public void OnRoundEnded(RoundEndedEvent roundEndedEvent) { foreach(var roundEndedEventListener in _roundEndedEventListeners.Keys) roundEndedEventListener(roundEndedEvent); }
    public void OnTick(TickEvent tickEvent) { foreach(var tickEventListener in _tickEventListeners.Keys) tickEventListener(tickEvent); }
    public void OnBotDeath(BotDeathEvent botDeathEvent) { foreach(var botDeathEventListener in _botDeathEventListeners.Keys) botDeathEventListener(botDeathEvent); }
    public void OnDeath(DeathEvent deathEvent) { foreach(var deathEventListener in _deathEventListeners.Keys) deathEventListener(deathEvent); }
    public void OnHitBot(HitBotEvent botHitBotEvent) { foreach(var botHitBotEventListener in _botHitBotEventListeners.Keys) botHitBotEventListener(botHitBotEvent); }
    public void OnHitWall(HitWallEvent botHitWallEvent) { foreach(var botHitWallEventListener in _botHitWallEventListeners.Keys) botHitWallEventListener(botHitWallEvent); }
    public void OnBulletFired(BulletFiredEvent bulletFiredEvent) { foreach(var bulletFiredEventListener in _bulletFiredEventListeners.Keys) bulletFiredEventListener(bulletFiredEvent); }
    public void OnHitByBullet(HitByBulletEvent hitByBulletEvent) { foreach(var hitByBulletEventListener in _hitByBulletEventListeners.Keys) hitByBulletEventListener(hitByBulletEvent); }
    public void OnBulletHit(BulletHitBotEvent bulletHitBotEvent) { foreach(var bulletHitBotEventListener in _bulletHitBotEventListeners.Keys) bulletHitBotEventListener(bulletHitBotEvent); }
    public void OnBulletHitBullet(BulletHitBulletEvent bulletHitBulletEvent) { foreach(var bulletHitBulletEventListener in _bulletHitBulletEventListeners.Keys) bulletHitBulletEventListener(bulletHitBulletEvent); }
    public void OnBulletHitWall(BulletHitWallEvent bulletHitWallEvent) { foreach(var bulletHitWallEventListener in _bulletHitWallEventListeners.Keys) bulletHitWallEventListener(bulletHitWallEvent); }
    public void OnScannedBot(ScannedBotEvent scannedBotEvent) { foreach(var scannedBotEventListener in _scannedBotEventListeners.Keys) scannedBotEventListener(scannedBotEvent); }
    public void OnSkippedTurn(SkippedTurnEvent skippedTurnEvent) { foreach(var skippedTurnEventListener in _skippedTurnEventListeners.Keys) skippedTurnEventListener(skippedTurnEvent); }
    public void OnWonRound(WonRoundEvent wonRoundEvent) { foreach(var wonRoundEventListener in _wonRoundEventListeners.Keys) wonRoundEventListener(wonRoundEvent); }
    public void OnCustomEvent(CustomEvent customEvent) { foreach(var customEventListener in _customEventListeners.Keys) customEventListener(customEvent); }
    public void OnTeamMessage(TeamMessageEvent teamMessageEvent) { foreach(var teamMessageEventListener in _teamMessageEventListeners.Keys) teamMessageEventListener(teamMessageEvent); }
    public double CalcMaxTurnRate(double speed) => _botImpl.CalcMaxTurnRate(speed);
    public double CalcBulletSpeed(double firepower) => _botImpl.CalcBulletSpeed(firepower);
    public double CalcGunHeat(double firepower) => _botImpl.CalcGunHeat(firepower);
    public double CalcBearing(double direction) => _botImpl.CalcBearing(direction);
    public double CalcGunBearing(double direction) => _botImpl.CalcGunBearing(direction);
    public double CalcRadarBearing(double direction) => _botImpl.CalcRadarBearing(direction);
    public double DirectionTo(double x, double y) => _botImpl.DirectionTo(x, y);
    public double BearingTo(double x, double y) => _botImpl.BearingTo(x, y);
    public double GunBearingTo(double x, double y) => _botImpl.GunBearingTo(x, y);
    public double RadarBearingTo(double x, double y) => _botImpl.RadarBearingTo(x, y);
    public double DistanceTo(double x, double y) => _botImpl.DistanceTo(x, y);
    public double NormalizeAbsoluteAngle(double angle) => _botImpl.NormalizeAbsoluteAngle(angle);
    public double NormalizeRelativeAngle(double angle) => _botImpl.NormalizeRelativeAngle(angle);
    public double CalcDeltaAngle(double targetAngle, double sourceAngle) => _botImpl.CalcDeltaAngle(targetAngle, sourceAngle);
    public int GetEventPriority(Type eventType) => _botImpl.GetEventPriority(eventType);
    public void SetEventPriority(Type eventType, int priority) => _botImpl.SetEventPriority(eventType, priority);
    public bool IsRunning { get => _botImpl.IsRunning && WaitNextTurn is not null; }
    public void SetForward(double distance) => _botImpl.SetForward(distance);
    public void SetBack(double distance) => _botImpl.SetBack(distance);
    public double DistanceRemaining { get => _botImpl.DistanceRemaining; }
    public void SetTurnLeft(double degrees) => _botImpl.SetTurnLeft(degrees);
    public void SetTurnRight(double degrees) => _botImpl.SetTurnRight(degrees);
    public double TurnRemaining { get => _botImpl.TurnRemaining; }
    public void SetTurnGunLeft(double degrees) => _botImpl.SetTurnGunLeft(degrees);
    public void SetTurnGunRight(double degrees) => _botImpl.SetTurnGunRight(degrees);
    public double GunTurnRemaining { get => _botImpl.GunTurnRemaining; }
    public void SetTurnRadarLeft(double degrees) => _botImpl.SetTurnRadarLeft(degrees);
    public void SetTurnRadarRight(double degrees) => _botImpl.SetTurnRadarRight(degrees);
    public double RadarTurnRemaining { get => _botImpl.RadarTurnRemaining; }
}
public class DelegateBotHandle() : IBotHandle {
    private readonly object _delegateLock = new();
    private IBotHandle? _delegate;
    private TaskCompletionSource? _delegateUnsetResolver;
    public IBotHandle? Delegate {
        get {
            lock(_delegateLock) {
                return _delegate;
            }
        }
        set {
            lock(_delegateLock) {
                if(_delegate == value) return;
                if(_delegate is not null) {
                    _delegateUnsetResolver!.TrySetCanceled();
                    _delegateUnsetResolver = null;
                }
                _delegate = value;
                if(_delegate is not null)
                    _delegateUnsetResolver = new();
            }
        }
    }
    public Task Go() {
        IBotHandle delegate_;
        TaskCompletionSource delegateUnsetResolver_;
        lock(_delegateLock) {
            if(_delegate is null || _delegateUnsetResolver is null)
                throw new OperationCanceledException();
            delegate_ = _delegate;
            delegateUnsetResolver_ = _delegateUnsetResolver;
        }
        return Task.WhenAny([delegate_.Go(), delegateUnsetResolver_.Task]);
    }
    public int MyId { get => Delegate!.MyId; }
    public string Variant { get => Delegate!.Variant; }
    public string Version { get => Delegate!.Version; }
    public string GameType { get => Delegate!.GameType; }
    public int ArenaWidth { get => Delegate!.ArenaWidth; }
    public int ArenaHeight { get => Delegate!.ArenaHeight; }
    public int NumberOfRounds { get => Delegate!.NumberOfRounds; }
    public double GunCoolingRate { get => Delegate!.GunCoolingRate; }
    public int? MaxInactivityTurns { get => Delegate!.MaxInactivityTurns; }
    public int TurnTimeout { get => Delegate!.TurnTimeout; }
    public int TimeLeft { get => Delegate!.TimeLeft; }
    public int RoundNumber { get => Delegate!.RoundNumber; }
    public int TurnNumber { get => Delegate!.TurnNumber; }
    public int EnemyCount { get => Delegate!.EnemyCount; }
    public double Energy { get => Delegate!.Energy; }
    public bool IsDisabled { get => Delegate!.IsDisabled; }
    public double X { get => Delegate!.X; }
    public double Y { get => Delegate!.Y; }
    public double Direction { get => Delegate!.Direction; }
    public double GunDirection { get => Delegate!.GunDirection; }
    public double RadarDirection { get => Delegate!.RadarDirection; }
    public double Speed { get => Delegate!.Speed; }
    public double GunHeat { get => Delegate!.GunHeat; }
    public IEnumerable<BulletState> BulletStates { get => Delegate!.BulletStates; }
    public IList<BotEvent> Events { get => Delegate!.Events; }
    public void ClearEvents() => Delegate!.ClearEvents();
    public double TurnRate { get => Delegate!.TurnRate; set => Delegate!.TurnRate = value; }
    public double MaxTurnRate { get => Delegate!.MaxTurnRate; set => Delegate!.MaxTurnRate = value; }
    public double GunTurnRate { get => Delegate!.GunTurnRate; set => Delegate!.GunTurnRate = value; }
    public double MaxGunTurnRate { get => Delegate!.MaxGunTurnRate; set => Delegate!.MaxGunTurnRate = value; }
    public double RadarTurnRate { get => Delegate!.RadarTurnRate; set => Delegate!.RadarTurnRate = value; }
    public double MaxRadarTurnRate { get => Delegate!.MaxRadarTurnRate; set => Delegate!.MaxRadarTurnRate = value; }
    public double TargetSpeed { get => Delegate!.TargetSpeed; set => Delegate!.TargetSpeed = value; }
    public double MaxSpeed { get => Delegate!.MaxSpeed; set => Delegate!.MaxSpeed = value; }
    public bool SetFire(double firepower) => Delegate!.SetFire(firepower);
    public double Firepower { get => Delegate!.Firepower; }
    public void SetRescan() => Delegate!.SetRescan();
    public void SetFireAssist(bool enable) => Delegate!.SetFireAssist(enable);
    public bool Interruptible { set => Delegate!.Interruptible = value; }
    public bool AdjustGunForBodyTurn { get => Delegate!.AdjustGunForBodyTurn; set => Delegate!.AdjustGunForBodyTurn = value; }
    public bool AdjustRadarForBodyTurn { get => Delegate!.AdjustRadarForBodyTurn; set => Delegate!.AdjustRadarForBodyTurn = value; }
    public bool AdjustRadarForGunTurn { get => Delegate!.AdjustRadarForGunTurn; set => Delegate!.AdjustRadarForGunTurn = value; }
    public bool AddCustomEvent(Condition condition) => Delegate!.AddCustomEvent(condition);
    public bool RemoveCustomEvent(Condition condition) => Delegate!.RemoveCustomEvent(condition);
    public void SetStop() => Delegate!.SetStop();
    public void SetStop(bool overwrite) => Delegate!.SetStop(overwrite);
    public void SetResume() => Delegate!.SetResume();
    public bool IsStopped { get => Delegate is null || Delegate.IsStopped; }
    public ICollection<int> TeammateIds { get => Delegate!.TeammateIds; }
    public bool IsTeammate(int botId) => Delegate!.IsTeammate(botId);
    public void BroadcastTeamMessage(object message) => Delegate!.BroadcastTeamMessage(message);
    public void SendTeamMessage(int teammateId, object message) => Delegate!.SendTeamMessage(teammateId, message);
    public Color? BodyColor { get => Delegate!.BodyColor; set => Delegate!.BodyColor = value; }
    public Color? TurretColor { get => Delegate!.TurretColor; set => Delegate!.TurretColor = value; }
    public Color? RadarColor { get => Delegate!.RadarColor; set => Delegate!.RadarColor = value; }
    public Color? BulletColor { get => Delegate!.BulletColor; set => Delegate!.BulletColor = value; }
    public Color? ScanColor { get => Delegate!.ScanColor; set => Delegate!.ScanColor = value; }
    public Color? TracksColor { get => Delegate!.TracksColor; set => Delegate!.TracksColor = value; }
    public Color? GunColor { get => Delegate!.GunColor; set => Delegate!.GunColor = value; }
    public bool IsDebuggingEnabled { get => Delegate!.IsDebuggingEnabled; }
    public IGraphics Graphics { get => Delegate!.Graphics; }
    public void AddConnectedEventListener(Action<ConnectedEvent> connectedEventListener) => Delegate!.AddConnectedEventListener(connectedEventListener);
    public void AddDisconnectedEventListener(Action<DisconnectedEvent> disconnectedEventListener) => Delegate!.AddDisconnectedEventListener(disconnectedEventListener);
    public void AddConnectionErrorEventListener(Action<ConnectionErrorEvent> connectionErrorEventListener) => Delegate!.AddConnectionErrorEventListener(connectionErrorEventListener);
    public void AddGameStartedEventListener(Action<GameStartedEvent> gameStatedEventListener) => Delegate!.AddGameStartedEventListener(gameStatedEventListener);
    public void AddGameEndedEventListener(Action<GameEndedEvent> gameEndedEventListener) => Delegate!.AddGameEndedEventListener(gameEndedEventListener);
    public void AddRoundStartedEventListener(Action<RoundStartedEvent> roundStartedEventListener) => Delegate!.AddRoundStartedEventListener(roundStartedEventListener);
    public void AddRoundEndedEventListener(Action<RoundEndedEvent> roundEndedEventListener) => Delegate!.AddRoundEndedEventListener(roundEndedEventListener);
    public void AddTickEventListener(Action<TickEvent> tickEventListener) => Delegate!.AddTickEventListener(tickEventListener);
    public void AddBotDeathEventListener(Action<BotDeathEvent> botDeathEventListener) => Delegate!.AddBotDeathEventListener(botDeathEventListener);
    public void AddDeathEventListener(Action<DeathEvent> deathEventListener) => Delegate!.AddDeathEventListener(deathEventListener);
    public void AddHitBotEventListener(Action<HitBotEvent> botHitBotEventListener) => Delegate!.AddHitBotEventListener(botHitBotEventListener);
    public void AddHitWallEventListener(Action<HitWallEvent> botHitWallEventListener) => Delegate!.AddHitWallEventListener(botHitWallEventListener);
    public void AddBulletFiredEventListener(Action<BulletFiredEvent> bulletFiredEventListener) => Delegate!.AddBulletFiredEventListener(bulletFiredEventListener);
    public void AddHitByBulletEventListener(Action<HitByBulletEvent> hitByBulletEventListener) => Delegate!.AddHitByBulletEventListener(hitByBulletEventListener);
    public void AddBulletHitEventListener(Action<BulletHitBotEvent> bulletHitBotEventListener) => Delegate!.AddBulletHitEventListener(bulletHitBotEventListener);
    public void AddBulletHitBulletEventListener(Action<BulletHitBulletEvent> bulletHitBulletEventListener) => Delegate!.AddBulletHitBulletEventListener(bulletHitBulletEventListener);
    public void AddBulletHitWallEventListener(Action<BulletHitWallEvent> bulletHitWallEventListener) => Delegate!.AddBulletHitWallEventListener(bulletHitWallEventListener);
    public void AddScannedBotEventListener(Action<ScannedBotEvent> scannedBotEventListener) => Delegate!.AddScannedBotEventListener(scannedBotEventListener);
    public void AddSkippedTurnEventListener(Action<SkippedTurnEvent> skippedTurnEventListener) => Delegate!.AddSkippedTurnEventListener(skippedTurnEventListener);
    public void AddWonRoundEventListener(Action<WonRoundEvent> wonRoundEventListener) => Delegate!.AddWonRoundEventListener(wonRoundEventListener);
    public void AddCustomEventEventListener(Action<CustomEvent> customEventListener) => Delegate!.AddCustomEventEventListener(customEventListener);
    public void AddTeamMessageEventListener(Action<TeamMessageEvent> teamMessageEventListener) => Delegate!.AddTeamMessageEventListener(teamMessageEventListener);
    public void RemoveConnectedEventListener(Action<ConnectedEvent> connectedEventListener) => Delegate!.RemoveConnectedEventListener(connectedEventListener);
    public void RemoveDisconnectedEventListener(Action<DisconnectedEvent> disconnectedEventListener) => Delegate!.RemoveDisconnectedEventListener(disconnectedEventListener);
    public void RemoveConnectionErrorEventListener(Action<ConnectionErrorEvent> connectionErrorEventListener) => Delegate!.RemoveConnectionErrorEventListener(connectionErrorEventListener);
    public void RemoveGameStartedEventListener(Action<GameStartedEvent> gameStatedEventListener) => Delegate!.RemoveGameStartedEventListener(gameStatedEventListener);
    public void RemoveGameEndedEventListener(Action<GameEndedEvent> gameEndedEventListener) => Delegate!.RemoveGameEndedEventListener(gameEndedEventListener);
    public void RemoveRoundStartedEventListener(Action<RoundStartedEvent> roundStartedEventListener) => Delegate!.RemoveRoundStartedEventListener(roundStartedEventListener);
    public void RemoveRoundEndedEventListener(Action<RoundEndedEvent> roundEndedEventListener) => Delegate!.RemoveRoundEndedEventListener(roundEndedEventListener);
    public void RemoveTickEventListener(Action<TickEvent> tickEventListener) => Delegate!.RemoveTickEventListener(tickEventListener);
    public void RemoveBotDeathEventListener(Action<BotDeathEvent> botDeathEventListener) => Delegate!.RemoveBotDeathEventListener(botDeathEventListener);
    public void RemoveDeathEventListener(Action<DeathEvent> deathEventListener) => Delegate!.RemoveDeathEventListener(deathEventListener);
    public void RemoveHitBotEventListener(Action<HitBotEvent> botHitBotEventListener) => Delegate!.RemoveHitBotEventListener(botHitBotEventListener);
    public void RemoveHitWallEventListener(Action<HitWallEvent> botHitWallEventListener) => Delegate!.RemoveHitWallEventListener(botHitWallEventListener);
    public void RemoveBulletFiredEventListener(Action<BulletFiredEvent> bulletFiredEventListener) => Delegate!.RemoveBulletFiredEventListener(bulletFiredEventListener);
    public void RemoveHitByBulletEventListener(Action<HitByBulletEvent> hitByBulletEventListener) => Delegate!.RemoveHitByBulletEventListener(hitByBulletEventListener);
    public void RemoveBulletHitEventListener(Action<BulletHitBotEvent> bulletHitBotEventListener) => Delegate!.RemoveBulletHitEventListener(bulletHitBotEventListener);
    public void RemoveBulletHitBulletEventListener(Action<BulletHitBulletEvent> bulletHitBulletEventListener) => Delegate!.RemoveBulletHitBulletEventListener(bulletHitBulletEventListener);
    public void RemoveBulletHitWallEventListener(Action<BulletHitWallEvent> bulletHitWallEventListener) => Delegate!.RemoveBulletHitWallEventListener(bulletHitWallEventListener);
    public void RemoveScannedBotEventListener(Action<ScannedBotEvent> scannedBotEventListener) => Delegate!.RemoveScannedBotEventListener(scannedBotEventListener);
    public void RemoveSkippedTurnEventListener(Action<SkippedTurnEvent> skippedTurnEventListener) => Delegate!.RemoveSkippedTurnEventListener(skippedTurnEventListener);
    public void RemoveWonRoundEventListener(Action<WonRoundEvent> wonRoundEventListener) => Delegate!.RemoveWonRoundEventListener(wonRoundEventListener);
    public void RemoveCustomEventEventListener(Action<CustomEvent> customEventListener) => Delegate!.RemoveCustomEventEventListener(customEventListener);
    public void RemoveTeamMessageEventListener(Action<TeamMessageEvent> teamMessageEventListener) => Delegate!.RemoveTeamMessageEventListener(teamMessageEventListener);
    public double CalcMaxTurnRate(double speed) => Delegate!.CalcMaxTurnRate(speed);
    public double CalcBulletSpeed(double firepower) => Delegate!.CalcBulletSpeed(firepower);
    public double CalcGunHeat(double firepower) => Delegate!.CalcGunHeat(firepower);
    public double CalcBearing(double direction) => Delegate!.CalcBearing(direction);
    public double CalcGunBearing(double direction) => Delegate!.CalcGunBearing(direction);
    public double CalcRadarBearing(double direction) => Delegate!.CalcRadarBearing(direction);
    public double DirectionTo(double x, double y) => Delegate!.DirectionTo(x, y);
    public double BearingTo(double x, double y) => Delegate!.BearingTo(x, y);
    public double GunBearingTo(double x, double y) => Delegate!.GunBearingTo(x, y);
    public double RadarBearingTo(double x, double y) => Delegate!.RadarBearingTo(x, y);
    public double DistanceTo(double x, double y) => Delegate!.DistanceTo(x, y);
    public double NormalizeAbsoluteAngle(double angle) => Delegate!.NormalizeAbsoluteAngle(angle);
    public double NormalizeRelativeAngle(double angle) => Delegate!.NormalizeRelativeAngle(angle);
    public double CalcDeltaAngle(double targetAngle, double sourceAngle) => Delegate!.CalcDeltaAngle(targetAngle, sourceAngle);
    public int GetEventPriority(Type eventType) => Delegate!.GetEventPriority(eventType);
    public void SetEventPriority(Type eventType, int priority) => Delegate!.SetEventPriority(eventType, priority);
    public bool IsRunning { get => Delegate is not null && Delegate.IsRunning; }
    public void SetForward(double distance) => Delegate!.SetForward(distance);
    public void SetBack(double distance) => Delegate!.SetBack(distance);
    public double DistanceRemaining { get => Delegate!.DistanceRemaining; }
    public void SetTurnLeft(double degrees) => Delegate!.SetTurnLeft(degrees);
    public void SetTurnRight(double degrees) => Delegate!.SetTurnRight(degrees);
    public double TurnRemaining { get => Delegate!.TurnRemaining; }
    public void SetTurnGunLeft(double degrees) => Delegate!.SetTurnGunLeft(degrees);
    public void SetTurnGunRight(double degrees) => Delegate!.SetTurnGunRight(degrees);
    public double GunTurnRemaining { get => Delegate!.GunTurnRemaining; }
    public void SetTurnRadarLeft(double degrees) => Delegate!.SetTurnRadarLeft(degrees);
    public void SetTurnRadarRight(double degrees) => Delegate!.SetTurnRadarRight(degrees);
    public double RadarTurnRemaining { get => Delegate!.RadarTurnRemaining; }
}
public abstract class BotTask : IBotHandle {
    private readonly IBotHandle _botHandle;
    private readonly ConcurrentDictionary<Task, bool> _eventTasks = [];
    private readonly ConcurrentDictionary<Func<ConnectedEvent, Task>, bool> _connectedEventListeners = [];
    private readonly ConcurrentDictionary<Func<DisconnectedEvent, Task>, bool> _disconnectedEventListeners = [];
    private readonly ConcurrentDictionary<Func<ConnectionErrorEvent, Task>, bool> _connectionErrorEventListeners = [];
    private readonly ConcurrentDictionary<Func<GameStartedEvent, Task>, bool> _gameStatedEventListeners = [];
    private readonly ConcurrentDictionary<Func<GameEndedEvent, Task>, bool> _gameEndedEventListeners = [];
    private readonly ConcurrentDictionary<Func<RoundStartedEvent, Task>, bool> _roundStartedEventListeners = [];
    private readonly ConcurrentDictionary<Func<RoundEndedEvent, Task>, bool> _roundEndedEventListeners = [];
    private readonly ConcurrentDictionary<Func<TickEvent, Task>, bool> _tickEventListeners = [];
    private readonly ConcurrentDictionary<Func<BotDeathEvent, Task>, bool> _botDeathEventListeners = [];
    private readonly ConcurrentDictionary<Func<DeathEvent, Task>, bool> _deathEventListeners = [];
    private readonly ConcurrentDictionary<Func<HitBotEvent, Task>, bool> _botHitBotEventListeners = [];
    private readonly ConcurrentDictionary<Func<HitWallEvent, Task>, bool> _botHitWallEventListeners = [];
    private readonly ConcurrentDictionary<Func<BulletFiredEvent, Task>, bool> _bulletFiredEventListeners = [];
    private readonly ConcurrentDictionary<Func<HitByBulletEvent, Task>, bool> _hitByBulletEventListeners = [];
    private readonly ConcurrentDictionary<Func<BulletHitBotEvent, Task>, bool> _bulletHitBotEventListeners = [];
    private readonly ConcurrentDictionary<Func<BulletHitBulletEvent, Task>, bool> _bulletHitBulletEventListeners = [];
    private readonly ConcurrentDictionary<Func<BulletHitWallEvent, Task>, bool> _bulletHitWallEventListeners = [];
    private readonly ConcurrentDictionary<Func<ScannedBotEvent, Task>, bool> _scannedBotEventListeners = [];
    private readonly ConcurrentDictionary<Func<SkippedTurnEvent, Task>, bool> _skippedTurnEventListeners = [];
    private readonly ConcurrentDictionary<Func<WonRoundEvent, Task>, bool> _wonRoundEventListeners = [];
    private readonly ConcurrentDictionary<Func<CustomEvent, Task>, bool> _customEventListeners = [];
    private readonly ConcurrentDictionary<Func<TeamMessageEvent, Task>, bool> _teamMessageEventListeners = [];
    private readonly Action<ConnectedEvent> _connectedEventAsyncHandler;
    private readonly Action<DisconnectedEvent> _disconnectedEventAsyncHandler;
    private readonly Action<ConnectionErrorEvent> _connectionErrorEventAsyncHandler;
    private readonly Action<GameStartedEvent> _gameStatedEventAsyncHandler;
    private readonly Action<GameEndedEvent> _gameEndedEventAsyncHandler;
    private readonly Action<RoundStartedEvent> _roundStartedEventAsyncHandler;
    private readonly Action<RoundEndedEvent> _roundEndedEventAsyncHandler;
    private readonly Action<TickEvent> _tickEventAsyncHandler;
    private readonly Action<BotDeathEvent> _botDeathEventAsyncHandler;
    private readonly Action<DeathEvent> _deathEventAsyncHandler;
    private readonly Action<HitBotEvent> _botHitBotEventAsyncHandler;
    private readonly Action<HitWallEvent> _botHitWallEventAsyncHandler;
    private readonly Action<BulletFiredEvent> _bulletFiredEventAsyncHandler;
    private readonly Action<HitByBulletEvent> _hitByBulletEventAsyncHandler;
    private readonly Action<BulletHitBotEvent> _bulletHitBotEventAsyncHandler;
    private readonly Action<BulletHitBulletEvent> _bulletHitBulletEventAsyncHandler;
    private readonly Action<BulletHitWallEvent> _bulletHitWallEventAsyncHandler;
    private readonly Action<ScannedBotEvent> _scannedBotEventAsyncHandler;
    private readonly Action<SkippedTurnEvent> _skippedTurnEventAsyncHandler;
    private readonly Action<WonRoundEvent> _wonRoundEventAsyncHandler;
    private readonly Action<CustomEvent> _customEventAsyncHandler;
    private readonly Action<TeamMessageEvent> _teamMessageEventAsyncHandler;
    public BotTask(IBotHandle botHandle) {
        _botHandle = botHandle;
        _connectedEventAsyncHandler = e => { foreach(var connectedEventListener in _connectedEventListeners.Keys) _eventTasks.TryAdd(connectedEventListener(e), true); };
        _disconnectedEventAsyncHandler = e => { foreach(var disconnectedEventListener in _disconnectedEventListeners.Keys) _eventTasks.TryAdd(disconnectedEventListener(e), true); };
        _connectionErrorEventAsyncHandler = e => { foreach(var connectionErrorEventListener in _connectionErrorEventListeners.Keys) _eventTasks.TryAdd(connectionErrorEventListener(e), true); };
        _gameStatedEventAsyncHandler = e => { foreach(var gameStatedEventListener in _gameStatedEventListeners.Keys) _eventTasks.TryAdd(gameStatedEventListener(e), true); };
        _gameEndedEventAsyncHandler = e => { foreach(var gameEndedEventListener in _gameEndedEventListeners.Keys) _eventTasks.TryAdd(gameEndedEventListener(e), true); };
        _roundStartedEventAsyncHandler = e => { foreach(var roundStartedEventListener in _roundStartedEventListeners.Keys) _eventTasks.TryAdd(roundStartedEventListener(e), true); };
        _roundEndedEventAsyncHandler = e => { foreach(var roundEndedEventListener in _roundEndedEventListeners.Keys) _eventTasks.TryAdd(roundEndedEventListener(e), true); };
        _tickEventAsyncHandler = e => { foreach(var tickEventListener in _tickEventListeners.Keys) _eventTasks.TryAdd(tickEventListener(e), true); };
        _botDeathEventAsyncHandler = e => { foreach(var botDeathEventListener in _botDeathEventListeners.Keys) _eventTasks.TryAdd(botDeathEventListener(e), true); };
        _deathEventAsyncHandler = e => { foreach(var deathEventListener in _deathEventListeners.Keys) _eventTasks.TryAdd(deathEventListener(e), true); };
        _botHitBotEventAsyncHandler = e => { foreach(var botHitBotEventListener in _botHitBotEventListeners.Keys) _eventTasks.TryAdd(botHitBotEventListener(e), true); };
        _botHitWallEventAsyncHandler = e => { foreach(var botHitWallEventListener in _botHitWallEventListeners.Keys) _eventTasks.TryAdd(botHitWallEventListener(e), true); };
        _bulletFiredEventAsyncHandler = e => { foreach(var bulletFiredEventListener in _bulletFiredEventListeners.Keys) _eventTasks.TryAdd(bulletFiredEventListener(e), true); };
        _hitByBulletEventAsyncHandler = e => { foreach(var hitByBulletEventListener in _hitByBulletEventListeners.Keys) _eventTasks.TryAdd(hitByBulletEventListener(e), true); };
        _bulletHitBotEventAsyncHandler = e => { foreach(var bulletHitBotEventListener in _bulletHitBotEventListeners.Keys) _eventTasks.TryAdd(bulletHitBotEventListener(e), true); };
        _bulletHitBulletEventAsyncHandler = e => { foreach(var bulletHitBulletEventListener in _bulletHitBulletEventListeners.Keys) _eventTasks.TryAdd(bulletHitBulletEventListener(e), true); };
        _bulletHitWallEventAsyncHandler = e => { foreach(var bulletHitWallEventListener in _bulletHitWallEventListeners.Keys) _eventTasks.TryAdd(bulletHitWallEventListener(e), true); };
        _scannedBotEventAsyncHandler = e => { foreach(var scannedBotEventListener in _scannedBotEventListeners.Keys) _eventTasks.TryAdd(scannedBotEventListener(e), true); };
        _skippedTurnEventAsyncHandler = e => { foreach(var skippedTurnEventListener in _skippedTurnEventListeners.Keys) _eventTasks.TryAdd(skippedTurnEventListener(e), true); };
        _wonRoundEventAsyncHandler = e => { foreach(var wonRoundEventListener in _wonRoundEventListeners.Keys) _eventTasks.TryAdd(wonRoundEventListener(e), true); };
        _customEventAsyncHandler = e => { foreach(var customEventListener in _customEventListeners.Keys) _eventTasks.TryAdd(customEventListener(e), true); };
        _teamMessageEventAsyncHandler = e => { foreach(var teamMessageEventListener in _teamMessageEventListeners.Keys) _eventTasks.TryAdd(teamMessageEventListener(e), true); };
    }
    public async Task Setup() {
        Interlocked.CompareExchange(ref _waitGoResolver, new(), null);
        AddConnectedEventListener(_connectedEventAsyncHandler);
        AddDisconnectedEventListener(_disconnectedEventAsyncHandler);
        AddConnectionErrorEventListener(_connectionErrorEventAsyncHandler);
        AddGameStartedEventListener(_gameStatedEventAsyncHandler);
        AddGameEndedEventListener(_gameEndedEventAsyncHandler);
        AddRoundStartedEventListener(_roundStartedEventAsyncHandler);
        AddRoundEndedEventListener(_roundEndedEventAsyncHandler);
        AddTickEventListener(_tickEventAsyncHandler);
        AddBotDeathEventListener(_botDeathEventAsyncHandler);
        AddDeathEventListener(_deathEventAsyncHandler);
        AddHitBotEventListener(_botHitBotEventAsyncHandler);
        AddHitWallEventListener(_botHitWallEventAsyncHandler);
        AddBulletFiredEventListener(_bulletFiredEventAsyncHandler);
        AddHitByBulletEventListener(_hitByBulletEventAsyncHandler);
        AddBulletHitEventListener(_bulletHitBotEventAsyncHandler);
        AddBulletHitBulletEventListener(_bulletHitBulletEventAsyncHandler);
        AddBulletHitWallEventListener(_bulletHitWallEventAsyncHandler);
        AddScannedBotEventListener(_scannedBotEventAsyncHandler);
        AddSkippedTurnEventListener(_skippedTurnEventAsyncHandler);
        AddWonRoundEventListener(_wonRoundEventAsyncHandler);
        AddCustomEventEventListener(_customEventAsyncHandler);
        AddTeamMessageEventListener(_teamMessageEventAsyncHandler);
        AddConnectedEventListener(OnConnected);
        AddDisconnectedEventListener(OnDisconnected);
        AddConnectionErrorEventListener(OnConnectionError);
        AddGameStartedEventListener(OnGameStarted);
        AddGameEndedEventListener(OnGameEnded);
        AddRoundStartedEventListener(OnRoundStarted);
        AddRoundEndedEventListener(OnRoundEnded);
        AddTickEventListener(OnTick);
        AddBotDeathEventListener(OnBotDeath);
        AddDeathEventListener(OnDeath);
        AddHitBotEventListener(OnHitBot);
        AddHitWallEventListener(OnHitWall);
        AddBulletFiredEventListener(OnBulletFired);
        AddHitByBulletEventListener(OnHitByBullet);
        AddBulletHitEventListener(OnBulletHit);
        AddBulletHitBulletEventListener(OnBulletHitBullet);
        AddBulletHitWallEventListener(OnBulletHitWall);
        AddScannedBotEventListener(OnScannedBot);
        AddSkippedTurnEventListener(OnSkippedTurn);
        AddWonRoundEventListener(OnWonRound);
        AddCustomEventEventListener(OnCustomEvent);
        AddTeamMessageEventListener(OnTeamMessage);
        await Initialize();
    }
    public Task<bool> Loop() {
        return Step();
    }
    public async Task Destroy() {
        await Finalize();
        RemoveConnectedEventListener(OnConnected);
        RemoveDisconnectedEventListener(OnDisconnected);
        RemoveConnectionErrorEventListener(OnConnectionError);
        RemoveGameStartedEventListener(OnGameStarted);
        RemoveGameEndedEventListener(OnGameEnded);
        RemoveRoundStartedEventListener(OnRoundStarted);
        RemoveRoundEndedEventListener(OnRoundEnded);
        RemoveTickEventListener(OnTick);
        RemoveBotDeathEventListener(OnBotDeath);
        RemoveDeathEventListener(OnDeath);
        RemoveHitBotEventListener(OnHitBot);
        RemoveHitWallEventListener(OnHitWall);
        RemoveBulletFiredEventListener(OnBulletFired);
        RemoveHitByBulletEventListener(OnHitByBullet);
        RemoveBulletHitEventListener(OnBulletHit);
        RemoveBulletHitBulletEventListener(OnBulletHitBullet);
        RemoveBulletHitWallEventListener(OnBulletHitWall);
        RemoveScannedBotEventListener(OnScannedBot);
        RemoveSkippedTurnEventListener(OnSkippedTurn);
        RemoveWonRoundEventListener(OnWonRound);
        RemoveCustomEventEventListener(OnCustomEvent);
        RemoveTeamMessageEventListener(OnTeamMessage);
        RemoveConnectedEventListener(_connectedEventAsyncHandler);
        RemoveDisconnectedEventListener(_disconnectedEventAsyncHandler);
        RemoveConnectionErrorEventListener(_connectionErrorEventAsyncHandler);
        RemoveGameStartedEventListener(_gameStatedEventAsyncHandler);
        RemoveGameEndedEventListener(_gameEndedEventAsyncHandler);
        RemoveRoundStartedEventListener(_roundStartedEventAsyncHandler);
        RemoveRoundEndedEventListener(_roundEndedEventAsyncHandler);
        RemoveTickEventListener(_tickEventAsyncHandler);
        RemoveBotDeathEventListener(_botDeathEventAsyncHandler);
        RemoveDeathEventListener(_deathEventAsyncHandler);
        RemoveHitBotEventListener(_botHitBotEventAsyncHandler);
        RemoveHitWallEventListener(_botHitWallEventAsyncHandler);
        RemoveBulletFiredEventListener(_bulletFiredEventAsyncHandler);
        RemoveHitByBulletEventListener(_hitByBulletEventAsyncHandler);
        RemoveBulletHitEventListener(_bulletHitBotEventAsyncHandler);
        RemoveBulletHitBulletEventListener(_bulletHitBulletEventAsyncHandler);
        RemoveBulletHitWallEventListener(_bulletHitWallEventAsyncHandler);
        RemoveScannedBotEventListener(_scannedBotEventAsyncHandler);
        RemoveSkippedTurnEventListener(_skippedTurnEventAsyncHandler);
        RemoveWonRoundEventListener(_wonRoundEventAsyncHandler);
        RemoveCustomEventEventListener(_customEventAsyncHandler);
        RemoveTeamMessageEventListener(_teamMessageEventAsyncHandler);
        _eventTasks.Clear();
        Volatile.Write(ref _waitGoResolver, null);
    }
    protected virtual Task Initialize() => Task.CompletedTask;
    protected abstract Task<bool> Step();
    protected virtual Task Finalize() => Task.CompletedTask;
    public ConcurrentDictionary<Task, bool> EventTasks { get => _eventTasks; }
    protected virtual Task OnConnected(ConnectedEvent connectedEvent) { return Task.CompletedTask; }
    protected virtual Task OnDisconnected(DisconnectedEvent disconnectedEvent) { return Task.CompletedTask; }
    protected virtual Task OnConnectionError(ConnectionErrorEvent connectionErrorEvent) { return Task.CompletedTask; }
    protected virtual Task OnGameStarted(GameStartedEvent gameStatedEvent) { return Task.CompletedTask; }
    protected virtual Task OnGameEnded(GameEndedEvent gameEndedEvent) { return Task.CompletedTask; }
    protected virtual Task OnRoundStarted(RoundStartedEvent roundStartedEvent) { return Task.CompletedTask; }
    protected virtual Task OnRoundEnded(RoundEndedEvent roundEndedEvent) { return Task.CompletedTask; }
    protected virtual Task OnTick(TickEvent tickEvent) { return Task.CompletedTask; }
    protected virtual Task OnBotDeath(BotDeathEvent botDeathEvent) { return Task.CompletedTask; }
    protected virtual Task OnDeath(DeathEvent deathEvent) { return Task.CompletedTask; }
    protected virtual Task OnHitBot(HitBotEvent botHitBotEvent) { return Task.CompletedTask; }
    protected virtual Task OnHitWall(HitWallEvent botHitWallEvent) { return Task.CompletedTask; }
    protected virtual Task OnBulletFired(BulletFiredEvent bulletFiredEvent) { return Task.CompletedTask; }
    protected virtual Task OnHitByBullet(HitByBulletEvent hitByBulletEvent) { return Task.CompletedTask; }
    protected virtual Task OnBulletHit(BulletHitBotEvent bulletHitBotEvent) { return Task.CompletedTask; }
    protected virtual Task OnBulletHitBullet(BulletHitBulletEvent bulletHitBulletEvent) { return Task.CompletedTask; }
    protected virtual Task OnBulletHitWall(BulletHitWallEvent bulletHitWallEvent) { return Task.CompletedTask; }
    protected virtual Task OnScannedBot(ScannedBotEvent scannedBotEvent) { return Task.CompletedTask; }
    protected virtual Task OnSkippedTurn(SkippedTurnEvent skippedTurnEvent) { return Task.CompletedTask; }
    protected virtual Task OnWonRound(WonRoundEvent wonRoundEvent) { return Task.CompletedTask; }
    protected virtual Task OnCustomEvent(CustomEvent customEvent) { return Task.CompletedTask; }
    protected virtual Task OnTeamMessage(TeamMessageEvent teamMessageEvent) { return Task.CompletedTask; }
    private TaskCompletionSource? _waitGoResolver;
    public virtual Task WaitGo() {
        TaskCompletionSource resolver = new();
        return (Interlocked.CompareExchange(ref _waitGoResolver, resolver, null) ?? resolver).Task;
    }
    public async Task Go() {
        var resolver = Volatile.Read(ref _waitGoResolver) ?? throw new OperationCanceledException();
        var result = _botHandle.Go();
        resolver.TrySetResult();
        await result;
        if(Interlocked.CompareExchange(ref _waitGoResolver, new(), resolver) is null)
            throw new OperationCanceledException();
    }
    public int MyId { get => _botHandle.MyId; }
    public string Variant { get => _botHandle.Variant; }
    public string Version { get => _botHandle.Version; }
    public string GameType { get => _botHandle.GameType; }
    public int ArenaWidth { get => _botHandle.ArenaWidth; }
    public int ArenaHeight { get => _botHandle.ArenaHeight; }
    public int NumberOfRounds { get => _botHandle.NumberOfRounds; }
    public double GunCoolingRate { get => _botHandle.GunCoolingRate; }
    public int? MaxInactivityTurns { get => _botHandle.MaxInactivityTurns; }
    public int TurnTimeout { get => _botHandle.TurnTimeout; }
    public int TimeLeft { get => _botHandle.TimeLeft; }
    public int RoundNumber { get => _botHandle.RoundNumber; }
    public int TurnNumber { get => _botHandle.TurnNumber; }
    public int EnemyCount { get => _botHandle.EnemyCount; }
    public double Energy { get => _botHandle.Energy; }
    public bool IsDisabled { get => _botHandle.IsDisabled; }
    public double X { get => _botHandle.X; }
    public double Y { get => _botHandle.Y; }
    public double Direction { get => _botHandle.Direction; }
    public double GunDirection { get => _botHandle.GunDirection; }
    public double RadarDirection { get => _botHandle.RadarDirection; }
    public double Speed { get => _botHandle.Speed; }
    public double GunHeat { get => _botHandle.GunHeat; }
    public IEnumerable<BulletState> BulletStates { get => _botHandle.BulletStates; }
    public IList<BotEvent> Events { get => _botHandle.Events; }
    public void ClearEvents() => _botHandle.ClearEvents();
    public double TurnRate { get => _botHandle.TurnRate; set => _botHandle.TurnRate = value; }
    public double MaxTurnRate { get => _botHandle.MaxTurnRate; set => _botHandle.MaxTurnRate = value; }
    public double GunTurnRate { get => _botHandle.GunTurnRate; set => _botHandle.GunTurnRate = value; }
    public double MaxGunTurnRate { get => _botHandle.MaxGunTurnRate; set => _botHandle.MaxGunTurnRate = value; }
    public double RadarTurnRate { get => _botHandle.RadarTurnRate; set => _botHandle.RadarTurnRate = value; }
    public double MaxRadarTurnRate { get => _botHandle.MaxRadarTurnRate; set => _botHandle.MaxRadarTurnRate = value; }
    public double TargetSpeed { get => _botHandle.TargetSpeed; set => _botHandle.TargetSpeed = value; }
    public double MaxSpeed { get => _botHandle.MaxSpeed; set => _botHandle.MaxSpeed = value; }
    public bool SetFire(double firepower) => _botHandle.SetFire(firepower);
    public double Firepower { get => _botHandle.Firepower; }
    public void SetRescan() => _botHandle.SetRescan();
    public void SetFireAssist(bool enable) => _botHandle.SetFireAssist(enable);
    public bool Interruptible { set => _botHandle.Interruptible = value; }
    public bool AdjustGunForBodyTurn { get => _botHandle.AdjustGunForBodyTurn; set => _botHandle.AdjustGunForBodyTurn = value; }
    public bool AdjustRadarForBodyTurn { get => _botHandle.AdjustRadarForBodyTurn; set => _botHandle.AdjustRadarForBodyTurn = value; }
    public bool AdjustRadarForGunTurn { get => _botHandle.AdjustRadarForGunTurn; set => _botHandle.AdjustRadarForGunTurn = value; }
    public bool AddCustomEvent(Condition condition) => _botHandle.AddCustomEvent(condition);
    public bool RemoveCustomEvent(Condition condition) => _botHandle.RemoveCustomEvent(condition);
    public void SetStop() => _botHandle.SetStop();
    public void SetStop(bool overwrite) => _botHandle.SetStop(overwrite);
    public void SetResume() => _botHandle.SetResume();
    public bool IsStopped { get => _botHandle.IsStopped; }
    public ICollection<int> TeammateIds { get => _botHandle.TeammateIds; }
    public bool IsTeammate(int botId) => _botHandle.IsTeammate(botId);
    public void BroadcastTeamMessage(object message) => _botHandle.BroadcastTeamMessage(message);
    public void SendTeamMessage(int teammateId, object message) => _botHandle.SendTeamMessage(teammateId, message);
    public Color? BodyColor { get => _botHandle.BodyColor; set => _botHandle.BodyColor = value; }
    public Color? TurretColor { get => _botHandle.TurretColor; set => _botHandle.TurretColor = value; }
    public Color? RadarColor { get => _botHandle.RadarColor; set => _botHandle.RadarColor = value; }
    public Color? BulletColor { get => _botHandle.BulletColor; set => _botHandle.BulletColor = value; }
    public Color? ScanColor { get => _botHandle.ScanColor; set => _botHandle.ScanColor = value; }
    public Color? TracksColor { get => _botHandle.TracksColor; set => _botHandle.TracksColor = value; }
    public Color? GunColor { get => _botHandle.GunColor; set => _botHandle.GunColor = value; }
    public bool IsDebuggingEnabled { get => _botHandle.IsDebuggingEnabled; }
    public IGraphics Graphics { get => _botHandle.Graphics; }
    public void AddConnectedEventListener(Func<ConnectedEvent, Task> connectedEventListener) => _connectedEventListeners.TryAdd(connectedEventListener, true);
    public void AddDisconnectedEventListener(Func<DisconnectedEvent, Task> disconnectedEventListener) => _disconnectedEventListeners.TryAdd(disconnectedEventListener, true);
    public void AddConnectionErrorEventListener(Func<ConnectionErrorEvent, Task> connectionErrorEventListener) => _connectionErrorEventListeners.TryAdd(connectionErrorEventListener, true);
    public void AddGameStartedEventListener(Func<GameStartedEvent, Task> gameStatedEventListener) => _gameStatedEventListeners.TryAdd(gameStatedEventListener, true);
    public void AddGameEndedEventListener(Func<GameEndedEvent, Task> gameEndedEventListener) => _gameEndedEventListeners.TryAdd(gameEndedEventListener, true);
    public void AddRoundStartedEventListener(Func<RoundStartedEvent, Task> roundStartedEventListener) => _roundStartedEventListeners.TryAdd(roundStartedEventListener, true);
    public void AddRoundEndedEventListener(Func<RoundEndedEvent, Task> roundEndedEventListener) => _roundEndedEventListeners.TryAdd(roundEndedEventListener, true);
    public void AddTickEventListener(Func<TickEvent, Task> tickEventListener) => _tickEventListeners.TryAdd(tickEventListener, true);
    public void AddBotDeathEventListener(Func<BotDeathEvent, Task> botDeathEventListener) => _botDeathEventListeners.TryAdd(botDeathEventListener, true);
    public void AddDeathEventListener(Func<DeathEvent, Task> deathEventListener) => _deathEventListeners.TryAdd(deathEventListener, true);
    public void AddHitBotEventListener(Func<HitBotEvent, Task> botHitBotEventListener) => _botHitBotEventListeners.TryAdd(botHitBotEventListener, true);
    public void AddHitWallEventListener(Func<HitWallEvent, Task> botHitWallEventListener) => _botHitWallEventListeners.TryAdd(botHitWallEventListener, true);
    public void AddBulletFiredEventListener(Func<BulletFiredEvent, Task> bulletFiredEventListener) => _bulletFiredEventListeners.TryAdd(bulletFiredEventListener, true);
    public void AddHitByBulletEventListener(Func<HitByBulletEvent, Task> hitByBulletEventListener) => _hitByBulletEventListeners.TryAdd(hitByBulletEventListener, true);
    public void AddBulletHitEventListener(Func<BulletHitBotEvent, Task> bulletHitBotEventListener) => _bulletHitBotEventListeners.TryAdd(bulletHitBotEventListener, true);
    public void AddBulletHitBulletEventListener(Func<BulletHitBulletEvent, Task> bulletHitBulletEventListener) => _bulletHitBulletEventListeners.TryAdd(bulletHitBulletEventListener, true);
    public void AddBulletHitWallEventListener(Func<BulletHitWallEvent, Task> bulletHitWallEventListener) => _bulletHitWallEventListeners.TryAdd(bulletHitWallEventListener, true);
    public void AddScannedBotEventListener(Func<ScannedBotEvent, Task> scannedBotEventListener) => _scannedBotEventListeners.TryAdd(scannedBotEventListener, true);
    public void AddSkippedTurnEventListener(Func<SkippedTurnEvent, Task> skippedTurnEventListener) => _skippedTurnEventListeners.TryAdd(skippedTurnEventListener, true);
    public void AddWonRoundEventListener(Func<WonRoundEvent, Task> wonRoundEventListener) => _wonRoundEventListeners.TryAdd(wonRoundEventListener, true);
    public void AddCustomEventEventListener(Func<CustomEvent, Task> customEventListener) => _customEventListeners.TryAdd(customEventListener, true);
    public void AddTeamMessageEventListener(Func<TeamMessageEvent, Task> teamMessageEventListener) => _teamMessageEventListeners.TryAdd(teamMessageEventListener, true);
    public void RemoveConnectedEventListener(Func<ConnectedEvent, Task> connectedEventListener) => _connectedEventListeners.TryRemove(connectedEventListener, out _);
    public void RemoveDisconnectedEventListener(Func<DisconnectedEvent, Task> disconnectedEventListener) => _disconnectedEventListeners.TryRemove(disconnectedEventListener, out _);
    public void RemoveConnectionErrorEventListener(Func<ConnectionErrorEvent, Task> connectionErrorEventListener) => _connectionErrorEventListeners.TryRemove(connectionErrorEventListener, out _);
    public void RemoveGameStartedEventListener(Func<GameStartedEvent, Task> gameStatedEventListener) => _gameStatedEventListeners.TryRemove(gameStatedEventListener, out _);
    public void RemoveGameEndedEventListener(Func<GameEndedEvent, Task> gameEndedEventListener) => _gameEndedEventListeners.TryRemove(gameEndedEventListener, out _);
    public void RemoveRoundStartedEventListener(Func<RoundStartedEvent, Task> roundStartedEventListener) => _roundStartedEventListeners.TryRemove(roundStartedEventListener, out _);
    public void RemoveRoundEndedEventListener(Func<RoundEndedEvent, Task> roundEndedEventListener) => _roundEndedEventListeners.TryRemove(roundEndedEventListener, out _);
    public void RemoveTickEventListener(Func<TickEvent, Task> tickEventListener) => _tickEventListeners.TryRemove(tickEventListener, out _);
    public void RemoveBotDeathEventListener(Func<BotDeathEvent, Task> botDeathEventListener) => _botDeathEventListeners.TryRemove(botDeathEventListener, out _);
    public void RemoveDeathEventListener(Func<DeathEvent, Task> deathEventListener) => _deathEventListeners.TryRemove(deathEventListener, out _);
    public void RemoveHitBotEventListener(Func<HitBotEvent, Task> botHitBotEventListener) => _botHitBotEventListeners.TryRemove(botHitBotEventListener, out _);
    public void RemoveHitWallEventListener(Func<HitWallEvent, Task> botHitWallEventListener) => _botHitWallEventListeners.TryRemove(botHitWallEventListener, out _);
    public void RemoveBulletFiredEventListener(Func<BulletFiredEvent, Task> bulletFiredEventListener) => _bulletFiredEventListeners.TryRemove(bulletFiredEventListener, out _);
    public void RemoveHitByBulletEventListener(Func<HitByBulletEvent, Task> hitByBulletEventListener) => _hitByBulletEventListeners.TryRemove(hitByBulletEventListener, out _);
    public void RemoveBulletHitEventListener(Func<BulletHitBotEvent, Task> bulletHitBotEventListener) => _bulletHitBotEventListeners.TryRemove(bulletHitBotEventListener, out _);
    public void RemoveBulletHitBulletEventListener(Func<BulletHitBulletEvent, Task> bulletHitBulletEventListener) => _bulletHitBulletEventListeners.TryRemove(bulletHitBulletEventListener, out _);
    public void RemoveBulletHitWallEventListener(Func<BulletHitWallEvent, Task> bulletHitWallEventListener) => _bulletHitWallEventListeners.TryRemove(bulletHitWallEventListener, out _);
    public void RemoveScannedBotEventListener(Func<ScannedBotEvent, Task> scannedBotEventListener) => _scannedBotEventListeners.TryRemove(scannedBotEventListener, out _);
    public void RemoveSkippedTurnEventListener(Func<SkippedTurnEvent, Task> skippedTurnEventListener) => _skippedTurnEventListeners.TryRemove(skippedTurnEventListener, out _);
    public void RemoveWonRoundEventListener(Func<WonRoundEvent, Task> wonRoundEventListener) => _wonRoundEventListeners.TryRemove(wonRoundEventListener, out _);
    public void RemoveCustomEventEventListener(Func<CustomEvent, Task> customEventListener) => _customEventListeners.TryRemove(customEventListener, out _);
    public void RemoveTeamMessageEventListener(Func<TeamMessageEvent, Task> teamMessageEventListener) => _teamMessageEventListeners.TryRemove(teamMessageEventListener, out _);
    public void AddConnectedEventListener(Action<ConnectedEvent> connectedEventListener) => _botHandle.AddConnectedEventListener(connectedEventListener);
    public void AddDisconnectedEventListener(Action<DisconnectedEvent> disconnectedEventListener) => _botHandle.AddDisconnectedEventListener(disconnectedEventListener);
    public void AddConnectionErrorEventListener(Action<ConnectionErrorEvent> connectionErrorEventListener) => _botHandle.AddConnectionErrorEventListener(connectionErrorEventListener);
    public void AddGameStartedEventListener(Action<GameStartedEvent> gameStatedEventListener) => _botHandle.AddGameStartedEventListener(gameStatedEventListener);
    public void AddGameEndedEventListener(Action<GameEndedEvent> gameEndedEventListener) => _botHandle.AddGameEndedEventListener(gameEndedEventListener);
    public void AddRoundStartedEventListener(Action<RoundStartedEvent> roundStartedEventListener) => _botHandle.AddRoundStartedEventListener(roundStartedEventListener);
    public void AddRoundEndedEventListener(Action<RoundEndedEvent> roundEndedEventListener) => _botHandle.AddRoundEndedEventListener(roundEndedEventListener);
    public void AddTickEventListener(Action<TickEvent> tickEventListener) => _botHandle.AddTickEventListener(tickEventListener);
    public void AddBotDeathEventListener(Action<BotDeathEvent> botDeathEventListener) => _botHandle.AddBotDeathEventListener(botDeathEventListener);
    public void AddDeathEventListener(Action<DeathEvent> deathEventListener) => _botHandle.AddDeathEventListener(deathEventListener);
    public void AddHitBotEventListener(Action<HitBotEvent> botHitBotEventListener) => _botHandle.AddHitBotEventListener(botHitBotEventListener);
    public void AddHitWallEventListener(Action<HitWallEvent> botHitWallEventListener) => _botHandle.AddHitWallEventListener(botHitWallEventListener);
    public void AddBulletFiredEventListener(Action<BulletFiredEvent> bulletFiredEventListener) => _botHandle.AddBulletFiredEventListener(bulletFiredEventListener);
    public void AddHitByBulletEventListener(Action<HitByBulletEvent> hitByBulletEventListener) => _botHandle.AddHitByBulletEventListener(hitByBulletEventListener);
    public void AddBulletHitEventListener(Action<BulletHitBotEvent> bulletHitBotEventListener) => _botHandle.AddBulletHitEventListener(bulletHitBotEventListener);
    public void AddBulletHitBulletEventListener(Action<BulletHitBulletEvent> bulletHitBulletEventListener) => _botHandle.AddBulletHitBulletEventListener(bulletHitBulletEventListener);
    public void AddBulletHitWallEventListener(Action<BulletHitWallEvent> bulletHitWallEventListener) => _botHandle.AddBulletHitWallEventListener(bulletHitWallEventListener);
    public void AddScannedBotEventListener(Action<ScannedBotEvent> scannedBotEventListener) => _botHandle.AddScannedBotEventListener(scannedBotEventListener);
    public void AddSkippedTurnEventListener(Action<SkippedTurnEvent> skippedTurnEventListener) => _botHandle.AddSkippedTurnEventListener(skippedTurnEventListener);
    public void AddWonRoundEventListener(Action<WonRoundEvent> wonRoundEventListener) => _botHandle.AddWonRoundEventListener(wonRoundEventListener);
    public void AddCustomEventEventListener(Action<CustomEvent> customEventListener) => _botHandle.AddCustomEventEventListener(customEventListener);
    public void AddTeamMessageEventListener(Action<TeamMessageEvent> teamMessageEventListener) => _botHandle.AddTeamMessageEventListener(teamMessageEventListener);
    public void RemoveConnectedEventListener(Action<ConnectedEvent> connectedEventListener) => _botHandle.RemoveConnectedEventListener(connectedEventListener);
    public void RemoveDisconnectedEventListener(Action<DisconnectedEvent> disconnectedEventListener) => _botHandle.RemoveDisconnectedEventListener(disconnectedEventListener);
    public void RemoveConnectionErrorEventListener(Action<ConnectionErrorEvent> connectionErrorEventListener) => _botHandle.RemoveConnectionErrorEventListener(connectionErrorEventListener);
    public void RemoveGameStartedEventListener(Action<GameStartedEvent> gameStatedEventListener) => _botHandle.RemoveGameStartedEventListener(gameStatedEventListener);
    public void RemoveGameEndedEventListener(Action<GameEndedEvent> gameEndedEventListener) => _botHandle.RemoveGameEndedEventListener(gameEndedEventListener);
    public void RemoveRoundStartedEventListener(Action<RoundStartedEvent> roundStartedEventListener) => _botHandle.RemoveRoundStartedEventListener(roundStartedEventListener);
    public void RemoveRoundEndedEventListener(Action<RoundEndedEvent> roundEndedEventListener) => _botHandle.RemoveRoundEndedEventListener(roundEndedEventListener);
    public void RemoveTickEventListener(Action<TickEvent> tickEventListener) => _botHandle.RemoveTickEventListener(tickEventListener);
    public void RemoveBotDeathEventListener(Action<BotDeathEvent> botDeathEventListener) => _botHandle.RemoveBotDeathEventListener(botDeathEventListener);
    public void RemoveDeathEventListener(Action<DeathEvent> deathEventListener) => _botHandle.RemoveDeathEventListener(deathEventListener);
    public void RemoveHitBotEventListener(Action<HitBotEvent> botHitBotEventListener) => _botHandle.RemoveHitBotEventListener(botHitBotEventListener);
    public void RemoveHitWallEventListener(Action<HitWallEvent> botHitWallEventListener) => _botHandle.RemoveHitWallEventListener(botHitWallEventListener);
    public void RemoveBulletFiredEventListener(Action<BulletFiredEvent> bulletFiredEventListener) => _botHandle.RemoveBulletFiredEventListener(bulletFiredEventListener);
    public void RemoveHitByBulletEventListener(Action<HitByBulletEvent> hitByBulletEventListener) => _botHandle.RemoveHitByBulletEventListener(hitByBulletEventListener);
    public void RemoveBulletHitEventListener(Action<BulletHitBotEvent> bulletHitBotEventListener) => _botHandle.RemoveBulletHitEventListener(bulletHitBotEventListener);
    public void RemoveBulletHitBulletEventListener(Action<BulletHitBulletEvent> bulletHitBulletEventListener) => _botHandle.RemoveBulletHitBulletEventListener(bulletHitBulletEventListener);
    public void RemoveBulletHitWallEventListener(Action<BulletHitWallEvent> bulletHitWallEventListener) => _botHandle.RemoveBulletHitWallEventListener(bulletHitWallEventListener);
    public void RemoveScannedBotEventListener(Action<ScannedBotEvent> scannedBotEventListener) => _botHandle.RemoveScannedBotEventListener(scannedBotEventListener);
    public void RemoveSkippedTurnEventListener(Action<SkippedTurnEvent> skippedTurnEventListener) => _botHandle.RemoveSkippedTurnEventListener(skippedTurnEventListener);
    public void RemoveWonRoundEventListener(Action<WonRoundEvent> wonRoundEventListener) => _botHandle.RemoveWonRoundEventListener(wonRoundEventListener);
    public void RemoveCustomEventEventListener(Action<CustomEvent> customEventListener) => _botHandle.RemoveCustomEventEventListener(customEventListener);
    public void RemoveTeamMessageEventListener(Action<TeamMessageEvent> teamMessageEventListener) => _botHandle.RemoveTeamMessageEventListener(teamMessageEventListener);
    public double CalcMaxTurnRate(double speed) => _botHandle.CalcMaxTurnRate(speed);
    public double CalcBulletSpeed(double firepower) => _botHandle.CalcBulletSpeed(firepower);
    public double CalcGunHeat(double firepower) => _botHandle.CalcGunHeat(firepower);
    public double CalcBearing(double direction) => _botHandle.CalcBearing(direction);
    public double CalcGunBearing(double direction) => _botHandle.CalcGunBearing(direction);
    public double CalcRadarBearing(double direction) => _botHandle.CalcRadarBearing(direction);
    public double DirectionTo(double x, double y) => _botHandle.DirectionTo(x, y);
    public double BearingTo(double x, double y) => _botHandle.BearingTo(x, y);
    public double GunBearingTo(double x, double y) => _botHandle.GunBearingTo(x, y);
    public double RadarBearingTo(double x, double y) => _botHandle.RadarBearingTo(x, y);
    public double DistanceTo(double x, double y) => _botHandle.DistanceTo(x, y);
    public double NormalizeAbsoluteAngle(double angle) => _botHandle.NormalizeAbsoluteAngle(angle);
    public double NormalizeRelativeAngle(double angle) => _botHandle.NormalizeRelativeAngle(angle);
    public double CalcDeltaAngle(double targetAngle, double sourceAngle) => _botHandle.CalcDeltaAngle(targetAngle, sourceAngle);
    public int GetEventPriority(Type eventType) => _botHandle.GetEventPriority(eventType);
    public void SetEventPriority(Type eventType, int priority) => _botHandle.SetEventPriority(eventType, priority);
    public bool IsRunning { get => _botHandle.IsRunning; }
    public void SetForward(double distance) => _botHandle.SetForward(distance);
    public Task Forward(double distance) {
        if(IsStopped) return Go();
        SetForward(distance);
        return WaitFor(() => DistanceRemaining == 0 && Speed == 0);
    }
    public void SetBack(double distance) => _botHandle.SetBack(distance);
    public Task Back(double distance) => Forward(-distance);
    public double DistanceRemaining { get => _botHandle.DistanceRemaining; }
    public void SetTurnLeft(double degrees) => _botHandle.SetTurnLeft(degrees);
    public Task TurnLeft(double degrees) {
        if(IsStopped) return Go();
        SetTurnLeft(degrees);
        return WaitFor(() => TurnRemaining == 0);
    }
    public void SetTurnRight(double degrees) => _botHandle.SetTurnRight(degrees);
    public Task TurnRight(double degrees) => TurnLeft(-degrees);
    public double TurnRemaining { get => _botHandle.TurnRemaining; }
    public void SetTurnGunLeft(double degrees) => _botHandle.SetTurnGunLeft(degrees);
    public Task TurnGunLeft(double degrees) {
        if(IsStopped) return Go();
        SetTurnGunLeft(degrees);
        return WaitFor(() => GunTurnRemaining == 0);
    }
    public void SetTurnGunRight(double degrees) => _botHandle.SetTurnGunRight(degrees);
    public Task TurnGunRight(double degrees) => TurnGunLeft(-degrees);
    public double GunTurnRemaining { get => _botHandle.GunTurnRemaining; }
    public void SetTurnRadarLeft(double degrees) => _botHandle.SetTurnRadarLeft(degrees);
    public Task TurnRadarLeft(double degrees) {
        if(IsStopped) return Go();
        SetTurnRadarLeft(degrees);
        return WaitFor(() => RadarTurnRemaining == 0);
    }
    public void SetTurnRadarRight(double degrees) => _botHandle.SetTurnRadarRight(degrees);
    public Task TurnRadarRight(double degrees) => TurnRadarLeft(-degrees);
    public double RadarTurnRemaining { get => _botHandle.RadarTurnRemaining; }
    public Task Fire(double firepower) {
        if(SetFire(firepower))
            return Go();
        return Task.CompletedTask;
    }
    public Task Stop() => Stop(false);
    public Task Stop(bool overwrite) {
        SetStop(overwrite);
        return Go();
    }
    public Task Resume() {
        SetResume();
        return Go();
    }
    public Task Rescan() {
        SetRescan();
        return Go();
    }
    public async Task WaitFor(Func<bool> condition) { do { await Go(); } while(IsRunning && !condition()); }
    public Task WaitFor(Condition condition) => WaitFor(condition.Test);
}

public class RainbowColorBotTask(IBotHandle botHandle) : BotTask(botHandle) {
    private double colorHue = 0;
    protected override async Task<bool> Step() {
        colorHue += Speed + 5;
        if(colorHue >= 360)
            colorHue %= colorHue;
        BodyColor = ColorFromHSV(colorHue, 1d, 1d);
        TurretColor = ColorFromHSV(colorHue, 1d, 1d);
        RadarColor = ColorFromHSV(colorHue, 1d, 1d);
        BulletColor = ColorFromHSV(colorHue, 1d, 1d);
        ScanColor = ColorFromHSV(colorHue, 1d, 1d);
        TracksColor = ColorFromHSV(colorHue, 1d, 1d);
        GunColor = ColorFromHSV(colorHue, 1d, 1d);
        await WaitFor(() => true);
        return IsRunning;
    }
    private static Color ColorFromHSV(double hue, double saturation, double value) {
        int hi = Convert.ToInt32(Math.Floor(hue / 60)) % 6;
        double f = hue / 60 - Math.Floor(hue / 60);
        double v = value * 255;
        double p = v * (1 - saturation);
        double q = v * (1 - f * saturation);
        double t = v * (1 - (1 - f) * saturation);
        return hi switch {
            0 => Color.FromArgb(255, (int) v, (int) t, (int) p),
            1 => Color.FromArgb(255, (int) q, (int) v, (int) p),
            2 => Color.FromArgb(255, (int) p, (int) v, (int) t),
            3 => Color.FromArgb(255, (int) p, (int) q, (int) v),
            4 => Color.FromArgb(255, (int) t, (int) p, (int) v),
            _ => Color.FromArgb(255, (int) v, (int) p, (int) q),
        };
    }
}
public class CornerStrategyBotTask(IBotHandle botHandle) : BotTask(botHandle) {
    private int enemies;
    private int corner = 90 * new Random().Next(4);
    private bool stopWhenSeeEnemy;
    private int gunIncrement;
    protected override async Task Initialize() {
        enemies = EnemyCount;
        gunIncrement = 3;
        stopWhenSeeEnemy = false;
        await TurnLeft(CalcBearing(corner));
        stopWhenSeeEnemy = true;
        await Forward(5000);
        await TurnRight(90);
        await Forward(5000);
        await TurnGunRight(90);
    }
    protected override async Task<bool> Step() {
        for(int i = 0; i < 30; i++)
            await TurnGunRight(gunIncrement);
        gunIncrement *= -1;
        return IsRunning;
    }
    protected override async Task OnScannedBot(ScannedBotEvent e) {
        var distance = DistanceTo(e.X, e.Y);
        if(!stopWhenSeeEnemy) {
            await SmartFire(distance);
            return;
        }
        await Stop();
        await SmartFire(distance);
        await Rescan();
        await Resume();
    }
    private async Task SmartFire(double distance) {
        if(distance > 200 || Energy < 15)
            await Fire(1);
        else if(distance > 50)
            await Fire(2);
        else
            await Fire(3);
    }
    protected override async Task OnDeath(DeathEvent e) {
        if(enemies == 0)
            return;
        if(EnemyCount / (double) enemies >= .75) {
            corner += 90;
            corner %= 360;
        }
        return;
    }
}
public class CrazyStrategyBotTask(IBotHandle botHandle) : BotTask(botHandle) {
    private bool movingForward;
    protected override async Task<bool> Step() {
        SetForward(40000);
        movingForward = true;
        await TurnRight(90);
        await TurnLeft(180);
        await TurnRight(180);
        return IsRunning;
    }
    private void ReverseDirection() {
        if(movingForward) {
            SetBack(40000);
            movingForward = false;
        } else {
            SetForward(40000);
            movingForward = true;
        }
    }
    protected override async Task OnScannedBot(ScannedBotEvent e) {
        await Fire(1);
    }
    protected override async Task OnHitWall(HitWallEvent e) {
        ReverseDirection();
    }
    protected override async Task OnHitBot(HitBotEvent e) {
        if(e.IsRammed) {
            ReverseDirection();
        }
    }
}
public class SpinStrategyBotTask(IBotHandle botHandle) : BotTask(botHandle) {
    protected async override Task<bool> Step() {
        SetTurnLeft(10000);
        MaxSpeed = 5;
        await Forward(10000);
        return IsRunning;
    }
    protected override async Task OnScannedBot(ScannedBotEvent scannedBotEvent) {
        await Fire(3);
    }
    protected override async Task OnHitBot(HitBotEvent botHitBotEvent) {
        var bearing = BearingTo(botHitBotEvent.X, botHitBotEvent.Y);
        if(bearing > -10 && bearing < 10)
            await Fire(3);
        if(botHitBotEvent.IsRammed)
            await TurnLeft(10);
    }
}
public class WallsStrategyBotTash(IBotHandle botHandle) : BotTask(botHandle) {
    bool peek;
    double moveAmount;
    protected override async Task Initialize() {
        moveAmount = Math.Max(ArenaWidth, ArenaHeight);
        peek = false;
        await TurnRight(Direction % 90);
        await Forward(moveAmount);
        peek = true;
        await TurnGunRight(90);
        await TurnRight(90);
    }
    protected override async Task<bool> Step() {
        peek = true;
        await Forward(moveAmount);
        peek = false;
        await TurnRight(90);
        return IsRunning;
    }
    protected override async Task OnHitBot(HitBotEvent e) {
        var bearing = BearingTo(e.X, e.Y);
        if(bearing > -90 && bearing < 90)
            await Back(100);
        else
            await Forward(100);
    }
    protected override async Task OnScannedBot(ScannedBotEvent e) {
        SetFire(2);
        if(peek)
            await Rescan();
    }
}
public class StrategySwitcherBotTask(IBotHandle botHandle, Func<IBotHandle, BotTask>[] strategyConstructors) : BotTask(botHandle) {
    protected readonly (BotTask, DelegateBotHandle)[] strategies = [..strategyConstructors.Select(c => {
        var botHandle = new DelegateBotHandle();
        return (c(botHandle), botHandle);
    })];
    protected readonly List<int> indices = [];
    protected int strategyIndex = -1;
    protected bool switchingStrategy;
    protected override async Task Initialize() {
        for(int i = 0; i < strategies.Length; i++)
            indices.Add(i);
    }
    protected override async Task<bool> Step() {
        if(strategyIndex == -1) {
            await Go();
            return IsRunning;
        }
        var strategy = strategies[strategyIndex];
        if(strategy.Item2.Delegate is null) {
            await Go();
            return IsRunning;
        }
        bool shouldContinue;
        try {
            shouldContinue = await strategy.Item1.Loop();
        } catch(OperationCanceledException) {
            return IsRunning;
        }
        if(!shouldContinue && strategies[strategyIndex] == strategy) {
            indices.Remove(strategyIndex);
            await ChangeToStrategyIndex(-1);
        }
        return IsRunning;
    }
    protected override async Task Finalize() {
        await ChangeToStrategyIndex(-1);
        indices.Clear();
    }
    protected async Task ChangeToStrategyIndex(int index) {
        if(index == strategyIndex || switchingStrategy) return;
        switchingStrategy = true;
        try {
            if(strategyIndex != -1) {
                var oldStrategy = strategies[strategyIndex];
                if(oldStrategy.Item2.Delegate is not null) {
                    await oldStrategy.Item1.Destroy();
                    oldStrategy.Item2.Delegate = null;
                }
            }
            strategyIndex = index;
            if(strategyIndex == -1)
                return;
            SetForward(0);
            SetTurnLeft(0);
            await WaitFor(() => Speed == 0 && TurnRemaining == 0);
            AdjustGunForBodyTurn = true;
            AdjustRadarForGunTurn = true;
            AdjustRadarForBodyTurn = true;
            SetTurnGunLeft(CalcGunBearing(Direction));
            SetTurnRadarLeft(CalcRadarBearing(Direction));
            await WaitFor(() => GunTurnRemaining == 0 && RadarTurnRemaining == 0);
            SetTurnGunLeft(CalcGunBearing(Direction));
            SetTurnRadarLeft(CalcRadarBearing(Direction));
            await WaitFor(() => GunTurnRemaining == 0 && RadarTurnRemaining == 0);
            AdjustGunForBodyTurn = false;
            AdjustRadarForGunTurn = false;
            AdjustRadarForBodyTurn = false;
            var strategy = strategies[index];
            strategy.Item2.Delegate = this;
            await strategy.Item1.Setup();
        } finally {
            switchingStrategy = false;
        }
    }
}
public class StrategyInitializerBulletDamage(BotTask botTask, double initialWeight) {
    public readonly BotTask botTask = botTask;
    public readonly double initialWeight = initialWeight;
}
public class StrategySwitchBulletDamage : StrategySwitcherBotTask {
    private readonly Dictionary<BotTask, double> weights;
    private int lastSwitch = 0;
    private double hitByBulletPower = 0;
    private readonly Random random = new();
    private static Func<IBotHandle, BotTask>[] TransformBotConstructors(Func<IBotHandle, StrategyInitializerBulletDamage>[] strategyConstructors, out Dictionary<BotTask, double> weights) {
        var weights_ = weights = [];
        return [..strategyConstructors.Select(strategyConstructor => (Func<IBotHandle, BotTask>) ((botHandle) => {
            var initializer = strategyConstructor(botHandle);
            weights_.Add(initializer.botTask, initializer.initialWeight);
            return initializer.botTask;
        }))];
    }
    public StrategySwitchBulletDamage(IBotHandle botHandle, Func<IBotHandle, StrategyInitializerBulletDamage>[] strategyConstructors) : 
        base(botHandle, TransformBotConstructors(strategyConstructors, out var weights)) {
        this.weights = weights;
    }
    protected override async Task Initialize() {
        await base.Initialize();
        await ChangeToStrategyIndex(WeightedRandomIndex());
        hitByBulletPower = 0;
        lastSwitch = TurnNumber;
    }
    protected override async Task<bool> Step() {
        if(strategyIndex == -1) {
            if(indices.Count == 0)
                return false;
            await ChangeToStrategyIndex(WeightedRandomIndex());
            hitByBulletPower = 0;
            lastSwitch = TurnNumber;
        }
        return await base.Step();
    }
    protected override async Task OnTick(TickEvent tickEvent) {
        if(TurnNumber - lastSwitch >= 500) {
            await ChangeToStrategyIndex(WeightedRandomIndex());
            hitByBulletPower = 0;
            lastSwitch = TurnNumber;
        }
    }
    protected override async Task OnHitByBullet(HitByBulletEvent hitByBulletEvent) {
        hitByBulletPower += hitByBulletEvent.Bullet.Power;
        if(strategyIndex == -1) return;
        weights[strategies[strategyIndex].Item1] -= Math.Pow(0.9, hitByBulletEvent.Bullet.Power);
        if(hitByBulletPower >= 3) {
            await ChangeToStrategyIndex(WeightedRandomIndex());
            hitByBulletPower = 0;
            lastSwitch = TurnNumber;
        }
    }
    protected override async Task OnBulletHit(BulletHitBotEvent bulletHitBotEvent) {
        if(strategyIndex == -1) return;
        weights[strategies[strategyIndex].Item1] += Math.Pow(1.1, bulletHitBotEvent.Bullet.Power);
    }
    private int WeightedRandomIndex() {
        if(indices.Count == 0) return -1;
        double totalWeight = strategies.Where((_, i) => indices.Contains(i)).Sum(s => weights[s.Item1]);
        double roll = random.NextDouble() * totalWeight;
        double cumulative = 0.0;
        foreach(var i in indices) {
            cumulative += weights[strategies[i].Item1];
            if(roll < cumulative) return i;
        }
        return indices.Last();
    }
}

public class DedicatedThreadTaskScheduler : TaskScheduler {
    private readonly Thread _thread;
    private readonly BlockingCollection<Task> _tasks = [];
    public DedicatedThreadTaskScheduler() {
        _thread = new Thread(ThreadWorker) {
            IsBackground = true
        };
    }
    public void Start() {
        _thread.Start();
    }
    public void Stop() {
        _tasks.CompleteAdding();
        _thread.Join();
        _tasks.Dispose();
    }
    private void ThreadWorker() {
        foreach(var task in _tasks.GetConsumingEnumerable())
            TryExecuteTask(task);
    }
    protected override IEnumerable<Task> GetScheduledTasks() => [.._tasks];
    protected override void QueueTask(Task task) => _tasks.Add(task);
    protected override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued) {
        if(Thread.CurrentThread != _thread) return false;
        return TryExecuteTask(task);
    }

    public Task Post(Action fn) => Task.Factory.StartNew(fn, default, TaskCreationOptions.DenyChildAttach, this);
    public Task Post(Func<Task> fn) => Task.Factory.StartNew(fn, default, TaskCreationOptions.DenyChildAttach, this).Unwrap();
    public Task<T> Post<T>(Func<Task<T>> fn) => Task.Factory.StartNew(fn, default, TaskCreationOptions.DenyChildAttach, this).Unwrap();
}

public class DantolBot : Bot {
    static void Main(string[] args) {
        new DantolBot().Start();
    }

    readonly NativeBotHandle _nativeBotHandle;
    readonly List<BotTask> _botTasks;
    readonly DedicatedThreadTaskScheduler _ts;

    DantolBot() : base(BotInfo.FromFile("DantolBot.json")) {
        _nativeBotHandle = new(this);
        _botTasks = [];
        _ts = new();
        _ts.Start();

        _botTasks.Add(new RainbowColorBotTask(_nativeBotHandle));
        _botTasks.Add(new StrategySwitchBulletDamage(_nativeBotHandle, [
            botHandle => new(new CrazyStrategyBotTask(botHandle), 1d),
            botHandle => new(new CornerStrategyBotTask(botHandle), 1d),
            botHandle => new(new SpinStrategyBotTask(botHandle), 3d),
            botHandle => new(new WallsStrategyBotTash(botHandle), 2d)
        ]));
    }

    public override void Run() {
        ConcurrentDictionary<BotTask, Task> setupTasks = [];
        ConcurrentDictionary<BotTask, Task<bool>> loopTasks = [];
        ConcurrentDictionary<BotTask, Task> destroyTasks = [];
        ConcurrentQueue<TaskCompletionSource> nextTurnResolvers = [];
        TaskCompletionSource cancelResolver = new();
        _nativeBotHandle.WaitNextTurn = async () => {
            var nextTurnResolver = new TaskCompletionSource();
            nextTurnResolvers.Enqueue(nextTurnResolver);
            await nextTurnResolver.Task;
        };
        foreach(var botTask in _botTasks)
            setupTasks[botTask] = _ts.Post(botTask.Setup);
        try {
            while(IsRunning) {
                try {
                    TaskCompletionSource cancelLoop = new();
                    Task.WhenAll(_botTasks.Select(botTask => _ts.Post(async () => {
                        if(destroyTasks.ContainsKey(botTask))
                            return;
                        var setupTask = setupTasks[botTask];
                        var eventTasks = botTask.EventTasks;
                        while(!cancelResolver.Task.IsCompleted && !cancelLoop.Task.IsCompleted) {
                            var waitGoTask = botTask.WaitGo();
                            foreach(var eventTask in eventTasks.Keys) {
                                await Task.WhenAny([eventTask, waitGoTask, cancelLoop.Task, cancelResolver.Task]);
                                if(eventTask.IsCompleted) {
                                    eventTasks.TryRemove(eventTask, out _);
                                    continue;
                                }
                                if(cancelLoop.Task.IsCompleted) break;
                                if(cancelResolver.Task.IsCompleted) break;
                                if(waitGoTask.IsCompleted) break;
                            }
                            if(!setupTask.IsCompleted) {
                                await Task.WhenAny([setupTask, waitGoTask, cancelLoop.Task, cancelResolver.Task]);
                                if(cancelLoop.Task.IsCompleted) break;
                                if(cancelResolver.Task.IsCompleted) break;
                                if(waitGoTask.IsCompleted) break;
                            }
                            if(!loopTasks.TryGetValue(botTask, out var loopTask))
                                loopTask = loopTasks[botTask] = botTask.Loop();
                            await Task.WhenAny([loopTask, waitGoTask, cancelLoop.Task, cancelResolver.Task]);
                            if(cancelLoop.Task.IsCompleted) break;
                            if(cancelResolver.Task.IsCompleted) break;
                            if(waitGoTask.IsCompleted) break;
                            bool shouldContinue = await loopTask;
                            loopTasks.TryRemove(botTask, out _);
                            if(shouldContinue) continue;
                            destroyTasks[botTask] = _ts.Post(botTask.Destroy);
                            break;
                        }
                    }))).Wait(10);
                    cancelLoop.TrySetResult();
                } catch(OperationCanceledException) {
                    // Ignored
                }
                EnableEventHandling(true);
                Go();
                var nextTurnResolversCopy = nextTurnResolvers.ToArray();
                nextTurnResolvers.Clear();
                foreach(var nextTurnResolver in nextTurnResolversCopy)
                    nextTurnResolver.TrySetResult();
            }
        } finally {
            _nativeBotHandle.WaitNextTurn = null;
            cancelResolver.TrySetResult();
            foreach(var botTask in _botTasks) {
                if(destroyTasks.ContainsKey(botTask)) continue;
                destroyTasks[botTask] = _ts.Post(botTask.Destroy);
            }
            Task.WhenAll([..destroyTasks.Values]).Wait();
            var nextTurnResolversCopy = nextTurnResolvers.ToArray();
            nextTurnResolvers.Clear();
            foreach(var nextTurnResolver in nextTurnResolversCopy)
                nextTurnResolver.TrySetResult();
        }
    }

    public override void OnConnected(ConnectedEvent connectedEvent) => _ts.Post(() => _nativeBotHandle.OnConnected(connectedEvent));
    public override void OnDisconnected(DisconnectedEvent disconnectedEvent) => _ts.Post(() => _nativeBotHandle.OnDisconnected(disconnectedEvent));
    public override void OnConnectionError(ConnectionErrorEvent connectionErrorEvent) => _ts.Post(() => _nativeBotHandle.OnConnectionError(connectionErrorEvent));
    public override void OnGameStarted(GameStartedEvent gameStatedEvent) => _ts.Post(() => _nativeBotHandle.OnGameStarted(gameStatedEvent));
    public override void OnGameEnded(GameEndedEvent gameEndedEvent) => _ts.Post(() => _nativeBotHandle.OnGameEnded(gameEndedEvent));
    public override void OnRoundStarted(RoundStartedEvent roundStartedEvent) => _ts.Post(() => _nativeBotHandle.OnRoundStarted(roundStartedEvent));
    public override void OnRoundEnded(RoundEndedEvent roundEndedEvent) => _ts.Post(() => _nativeBotHandle.OnRoundEnded(roundEndedEvent));
    public override void OnTick(TickEvent tickEvent) => _ts.Post(() => _nativeBotHandle.OnTick(tickEvent));
    public override void OnBotDeath(BotDeathEvent botDeathEvent) => _ts.Post(() => _nativeBotHandle.OnBotDeath(botDeathEvent));
    public override void OnDeath(DeathEvent deathEvent) => _ts.Post(() => _nativeBotHandle.OnDeath(deathEvent));
    public override void OnHitBot(HitBotEvent botHitBotEvent) => _ts.Post(() => _nativeBotHandle.OnHitBot(botHitBotEvent));
    public override void OnHitWall(HitWallEvent botHitWallEvent) => _ts.Post(() => _nativeBotHandle.OnHitWall(botHitWallEvent));
    public override void OnBulletFired(BulletFiredEvent bulletFiredEvent) => _ts.Post(() => _nativeBotHandle.OnBulletFired(bulletFiredEvent));
    public override void OnHitByBullet(HitByBulletEvent hitByBulletEvent) => _ts.Post(() => _nativeBotHandle.OnHitByBullet(hitByBulletEvent));
    public override void OnBulletHit(BulletHitBotEvent bulletHitBotEvent) => _ts.Post(() => _nativeBotHandle.OnBulletHit(bulletHitBotEvent));
    public override void OnBulletHitBullet(BulletHitBulletEvent bulletHitBulletEvent) => _ts.Post(() => _nativeBotHandle.OnBulletHitBullet(bulletHitBulletEvent));
    public override void OnBulletHitWall(BulletHitWallEvent bulletHitWallEvent) => _ts.Post(() => _nativeBotHandle.OnBulletHitWall(bulletHitWallEvent));
    public override void OnScannedBot(ScannedBotEvent scannedBotEvent) => _ts.Post(() => _nativeBotHandle.OnScannedBot(scannedBotEvent));
    public override void OnSkippedTurn(SkippedTurnEvent skippedTurnEvent) => _ts.Post(() => _nativeBotHandle.OnSkippedTurn(skippedTurnEvent));
    public override void OnWonRound(WonRoundEvent wonRoundEvent) => _ts.Post(() => _nativeBotHandle.OnWonRound(wonRoundEvent));
    public override void OnCustomEvent(CustomEvent customEvent) => _ts.Post(() => _nativeBotHandle.OnCustomEvent(customEvent));
    public override void OnTeamMessage(TeamMessageEvent teamMessageEvent) => _ts.Post(() => _nativeBotHandle.OnTeamMessage(teamMessageEvent));
}
