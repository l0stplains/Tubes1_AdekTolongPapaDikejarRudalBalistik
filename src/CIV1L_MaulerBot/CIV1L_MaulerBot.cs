using System;
using System.Drawing;
using System.Collections.Generic;
using Robocode.TankRoyale.BotApi;
using Robocode.TankRoyale.BotApi.Events;

namespace Tubes1_AdekTolongPapaDikejarRudalBalistik.CIV1L_MaulerBot
{
    public class CIV1L_MaulerBot : Bot
    {
        private int oldTurn = 0;
        private double turn = 2;
        private int turnDir = 1;
        private int moveDir = 1;
        private double oldEnergy = 100;
        private double cornerRadius = 50;
        private State state = new State();
        private Enemy target;
        private Random random = new Random();

        // private bool fourHappend = false;
        static void Main(string[] args)
        {
            new CIV1L_MaulerBot().Start();
        }

        CIV1L_MaulerBot() : base(BotInfo.FromFile("CIV1L_MaulerBot.json")) { }
        public override void Run()
        {

            BodyColor = Color.DarkGreen;
            GunColor = Color.SandyBrown;
            RadarColor = Color.ForestGreen;
            TurretColor = Color.Black;
            ScanColor = Color.White;
            BulletColor = Color.Red;
            TracksColor = Color.SandyBrown;

            AdjustGunForBodyTurn = true;
            AdjustRadarForGunTurn = true;

            while (IsRunning)
            {
                UpdateState();
                target = null;
                SetTurnRadarLeft(1000);
                if (state.combatState == CombatState.Melee)
                {
                    MaxSpeed = 5;
                    MaxTurnRate = Constants.MaxTurnRate;
                    // a heuristic to avoid getting stuck (barely happens)
                    if(TurnNumber % 240 == 0){
                        double distance = DistanceToWall() - 80;
                        MaxSpeed = 8;
                        Forward(distance);
                    }
                    else
                    {
                        SetTurnLeft(double.PositiveInfinity * turnDir);
                        SetForward(double.PositiveInfinity);
                    }
                }

                Go();
            }
        }

        public void UpdateState()
        {
            // why not EnemyCount > 1?
            // As said from https://robowiki.net/wiki/Melee_Strategy#10_bots_on_the_field
            // "This is where you'll be the happiest with solid targeting. 
            // Here's why: when you're down to 4 bots, as David pointed out, 
            // there's a really good chance that you're all in corners. 
            // If the next bot who dies is the one across from you 
            // (the one you probably weren't targeting), you are probably next, 
            // because you're the most obvious target for both of the remaining enemies."
            if (EnemyCount > 3) 
            {
                state.combatState = CombatState.Melee;
            } /* else if(EnemyCount > 2){
                if(!fourHappend){
                    TurnRadarLeft(360);
                    fourHappend = true;
                }
                state.combatState = CombatState.Four; 
            }*/
            else
            {
                state.combatState = CombatState.By1;
            }
        }

        public override void OnScannedBot(ScannedBotEvent e)
        {
            Enemy enemy = new Enemy(e.ScannedBotId, e.X, e.Y, e.Energy, BearingTo(e.X, e.Y), e.Direction, e.Speed);
            if (target == null || target.Id == e.ScannedBotId || DistanceTo(e.X, e.Y) < DistanceTo(target.X, target.Y))
            {
                target = enemy;
            }
            UpdateState();
            double absBearing = BearingTo(e.X, e.Y) + Direction;

            double bulletPower;
            double randomGuessFactor;
            double maxEscapeAngle;
            double randomAngle;
            double firingAngle;

            if (state.combatState == CombatState.By1)
            {
                SetTurnRadarLeft(NormalizeRelativeAngle(
                    absBearing - RadarDirection) * 2);
                turn += 0.2 * new Random().NextDouble();
                if (turn > 8) turn = 2;

                if (oldEnergy - e.Energy <= 3 && oldEnergy - e.Energy >= 0.1)
                {
                    if (new Random().NextDouble() > 0.5) turnDir *= -1;
                    if (new Random().NextDouble() > 0.8) moveDir *= -1;
                }

                MaxTurnRate = turn;
                MaxSpeed = 12 - turn;
                oldEnergy = e.Energy;
                bulletPower = Math.Min(2.4, Math.Max(Math.Min(e.Energy / 4, Energy / 10), 0.1));

                // There is a very annoying WhiteWhale movement that is very hard to hit
                // if the enemy is moving in a straight line "perpendicular" to us,
                // our bullets will never hit it because we didn't predict its movement
                // and most of the time the bullet will miss behind the enemy
                // but fortunately, it really good against oscillating movement

                randomGuessFactor = (new Random().NextDouble() - .5) * 2;
                maxEscapeAngle = Math.Asin(8.2 / (20 - (3 * bulletPower)));//farthest the enemy can move in the amount of time it would take for a bullet to reach them
                randomAngle = randomGuessFactor * maxEscapeAngle;//random firing angle
                firingAngle = NormalizeRelativeAngle(absBearing - GunDirection + ToDegrees(randomAngle / 3 * e.Speed / 5));//amount to turn our gun
                SetTurnGunLeft(NormalizeRelativeAngle(firingAngle));
                // Oscillating movement inspired from MicroAspid 1.2
                if (DistanceRemaining == 0) { moveDir = -moveDir; SetForward(185 * moveDir); }
                SetTurnLeft(BearingTo(e.X, e.Y) + 180 / 2 - ToDegrees(0.5236 * moveDir * (DistanceTo(e.X, e.Y) > 100 ? 1 : -1)));
                if (GunHeat <= 0.1)
                {
                    SetFire(bulletPower);
                }
            }
            else if (state.combatState == CombatState.Melee)
            {

                absBearing = BearingTo(target.X, target.Y) + Direction;
                SetTurnRadarLeft(NormalizeRelativeAngle(absBearing - RadarDirection) * 2);
                bulletPower = Math.Min(3, Math.Max(300 / DistanceTo(target.X, target.Y) + 2, 1));
                randomGuessFactor = (new Random().NextDouble() - .5) * 2;
                maxEscapeAngle = Math.Asin(8.2 / (20 - (3 * bulletPower)));
                randomAngle = randomGuessFactor * maxEscapeAngle;
                firingAngle = NormalizeRelativeAngle(absBearing - GunDirection + ToDegrees(randomAngle / 3 * target.Speed / 5));
                SetTurnGunLeft(NormalizeRelativeAngle(firingAngle));
                if (TurnNumber % 60 == 0)
                {
                    target = null;
                    SetTurnRadarLeft(360);
                }
                else
                {
                    if (GunHeat <= 0.1)
                    {
                        SetFire(bulletPower);
                    }
                }
            }
            
            oldTurn = TurnNumber; 

            ClearEvents();
        }
        public override void OnHitBot(HitBotEvent e)
        {
            var bearing = BearingTo(e.X, e.Y);
            if (bearing > -10 && bearing < 10 && e.Energy < Energy)
            {
                Fire(3);
            } else {
                target = new Enemy(e.VictimId, e.X, e.Y, e.Energy, BearingTo(e.X, e.Y), NormalizeAbsoluteAngle(Direction + BearingTo(e.X, e.Y) + 180), 0);
                Back(100);
            }
            if (e.IsRammed)
            {
                turnDir *= -1;
                TurnLeft(10 * turnDir);
            }
        }
        public override void OnHitByBullet(HitByBulletEvent e)
        {
            turnDir *= -1;
            TurnLeft(10 * turnDir);
        }
        private double DistanceToWall()
        {
            double angleRad = ToRadians(Direction);

            double dx = Math.Cos(angleRad);
            double dy = Math.Sin(angleRad);

            double minDistance = double.PositiveInfinity;

            if (dx > 0)
            {
                double distanceRight = (ArenaWidth - X) / dx;
                minDistance = Math.Min(minDistance, distanceRight);
            }

            if (dx < 0)
            {
                double distanceLeft = -X / dx;
                minDistance = Math.Min(minDistance, distanceLeft);
            }

            if (dy > 0)
            {
                double distanceTop = (ArenaHeight - Y) / dy;
                minDistance = Math.Min(minDistance, distanceTop);
            }

            if (dy < 0)
            {
                double distanceBottom = -Y / dy;
                minDistance = Math.Min(minDistance, distanceBottom);
            }
            return minDistance;
        }
        private static double ToDegrees(double radians)
        {
            return radians * 180 / Math.PI;
        }

        private static double ToRadians(double degrees)
        {
            return degrees * Math.PI / 180;
        }
        private class State
        {
            public CombatState combatState;
        }

        private class Enemy
        {
            public int Id;
            public double X;
            public double Y;
            public double Energy, Bearing, Direction, Speed;

            // ugh i really want to implement Wave Surfing
            // but deadline is tight tight tight

            // public Vector<BulletWave> waves;	// BulletWaves are stored per enemy, for ease of access

            public Enemy(int id, double X, double Y, double energy, double bearing, double heading, double speed)
            {
                this.Id = id;
                this.X = X;
                this.Y = Y;
                this.Energy = energy;
                this.Bearing = bearing;
                this.Direction = heading;
                this.Speed = speed;
                // this.waves = waves;
            }
        }

        private enum CombatState
        {
            Melee,
            Four, // not implemented
            By1,
        }

    }

}