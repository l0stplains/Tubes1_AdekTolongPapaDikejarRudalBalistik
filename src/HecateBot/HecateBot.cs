using System;
using System.Drawing;
using Robocode.TankRoyale.BotApi;
using Robocode.TankRoyale.BotApi.Events;

namespace Tubes1_AdekTolongPapaDikejarRudalBalistik.HecateBot
{
    public class HecateBot : Bot
    {
        private int turnDir = 1;
        private int moveDir = 1;
        private double oldEnergy = 100;
        private Enemy target;
        private Random random = new Random();

        static void Main(string[] args)
        {
            new HecateBot().Start();
        }

        HecateBot() : base(BotInfo.FromFile("HecateBot.json")) { }

        public override void Run()
        {
            BodyColor = Color.LightBlue;
            GunColor = Color.DarkBlue;
            RadarColor = Color.Black;
            BulletColor = Color.LightBlue;

            AdjustGunForBodyTurn = true;
            AdjustRadarForGunTurn = true;

            while (IsRunning)
            {
                SetTurnRadarLeft(360);

                if (Energy < 30)
                {
                    MoveToCorner();
                    MaxSpeed = 4; 
                }
                else if (Energy > 70)
                {
                    MaxSpeed = 10;
                    if (target != null)
                        MoveTowardEnemy(target);
                    else
                        Patrol();
                }
                else
                {
                    MaxSpeed = 6;
                    Patrol();
                }

                Go();
            }
        }

        public override void OnScannedBot(ScannedBotEvent e)
        {
            Enemy enemy = new Enemy(e.ScannedBotId, e.X, e.Y, e.Energy, BearingTo(e.X, e.Y), e.Direction, e.Speed);
            
            if (target == null || 
                enemy.Energy < target.Energy || 
                DistanceTo(enemy.X, enemy.Y) < DistanceTo(target.X, target.Y))
            {
                target = enemy;
            }

            double absBearing = BearingTo(e.X, e.Y) + Direction;

            double bulletPower;
            if (Energy < 30)
                bulletPower = 1.0;  
            else if (Energy > 70)
                bulletPower = 3.0; 
            else
                bulletPower = Math.Min(2.0, Energy / 20);

            double enemySpeed = e.Speed;
            double futureX = e.X + Math.Cos(ToRadians(e.Direction)) * enemySpeed * 5;
            double futureY = e.Y + Math.Sin(ToRadians(e.Direction)) * enemySpeed * 5;
            double futureBearing = BearingTo(futureX, futureY) + Direction;

            SetTurnGunLeft(NormalizeRelativeAngle(futureBearing - GunDirection));

            if (GunHeat == 0 && Energy > bulletPower * 2)
            {
                SetFire(bulletPower);
            }

            if (e.Energy < oldEnergy && oldEnergy - e.Energy >= 0.1)
            {
                moveDir *= -1;
                SetForward(100 * moveDir);
            }
            oldEnergy = e.Energy;
        }

        private void MoveToCorner()
        {
            double distanceToWall = DistanceToWall();
            if (distanceToWall > 50)
            {
                SetForward(distanceToWall - 20);
                SetTurnLeft(45 * turnDir);
            }
            else
            {
                SetTurnLeft(90 * turnDir);
            }
        }

        private void Patrol()
        {
            if (DistanceRemaining < 10)
            {
                moveDir *= -1;
                SetForward(150 * moveDir);
            }
            SetTurnLeft(30 * turnDir);
        }

        private void MoveTowardEnemy(Enemy enemy)
        {
            double bearing = BearingTo(enemy.X, enemy.Y);
            SetTurnLeft(bearing);
            SetForward(DistanceTo(enemy.X, enemy.Y) * 0.7);
        }

        public override void OnHitByBullet(HitByBulletEvent e)
        {
            if (Energy < 40)
            {
                Back(100);
            }
            else
            {
                turnDir *= -1;
                TurnLeft(30 * turnDir);
            }
        }

        public override void OnHitBot(HitBotEvent e)
        {
            if (Energy > e.Energy + 10)
            {
                Fire(3);
                Forward(50);
            }
            else
            {
                Back(100);
            }
        }
        private double DistanceToWall()
        {
            double angleRad = ToRadians(Direction);
            double dx = Math.Cos(angleRad);
            double dy = Math.Sin(angleRad);
            return Math.Min(
                dx > 0 ? (ArenaWidth - X) / dx : -X / dx,
                dy > 0 ? (ArenaHeight - Y) / dy : -Y / dy
            );
        }

        private static double ToDegrees(double radians) => radians * 180 / Math.PI;
        private static double ToRadians(double degrees) => degrees * Math.PI / 180;
    }

    public class Enemy
    {
        public int Id;
        public double X, Y, Energy, Bearing, Direction, Speed;
        public Enemy(int id, double x, double y, double energy, double bearing, double heading, double speed)
        {
            Id = id; X = x; Y = y; Energy = energy;
            Bearing = bearing; Direction = heading; Speed = speed;
        }
    }
}