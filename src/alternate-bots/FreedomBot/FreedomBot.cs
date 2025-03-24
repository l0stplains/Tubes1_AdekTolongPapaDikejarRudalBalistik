using System;
using System.Drawing;
using System.IO.Pipes;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Win32;
using Robocode.TankRoyale.BotApi;
using Robocode.TankRoyale.BotApi.Events;

public enum Side
{
    Left,
    Right,
    Top,
    Bottom
}

public enum Corner
{
    TopLeft,
    TopRight,
    BottomLeft,
    BottomRight
}

namespace Tubes1_AdekTolongPapaDikejarRudalBalistik.FreedomBot
{
    public class FreedomBot : Bot
    {
        public const double TankHeight = 36;
        public const double TankWidth = 36;
        public const double TankRadius = 18;
        public const double CornerOffset = 100;
        public const double radius = 20;
        public double cornerX = 0, cornerY = 0;

        public double direction = 1; // 1 for clockwise, -1 for counter-clockwise
        public Side CurrentSide;
        public Corner CurrentCorner;

        static void Main(string[] args)
        {
            new FreedomBot().Start();
        }

        FreedomBot() : base(BotInfo.FromFile("FreedomBot.json")) { }

        public override void Run()
        {
            BodyColor = Color.White;
            GunColor = Color.Red;
            TurretColor = Color.Blue;
            TracksColor = Color.Red;
            RadarColor = Color.White;
            ScanColor = Color.LightGray;

            InitiatePosition();

            AdjustGunForBodyTurn = true;
            AdjustRadarForGunTurn = true;

            while (IsRunning)
            {
                DoMove();
                SetTurnRadarLeft(1000);
                Go();
            }

        }


        public override void OnScannedBot(ScannedBotEvent e)
        {
            Enemy enemy = new Enemy(e);
            DoScan(enemy);
            DoFire(enemy);
        }
        public void DoScan(Enemy enemy)
        {
            if (enemy == null)
            {
                SetTurnRadarLeft(360);
            }
            else
            {
                double absBearing = BearingTo(enemy.X, enemy.Y) + Direction;
                double turn = NormalizeRelativeAngle(absBearing - RadarDirection);
                SetTurnRadarLeft(turn * 2);
            }
        }
        public void DoFire(Enemy enemy)
        {
            if (enemy != null)
            {
                // circular targeting, assumes enemy will move in a circle
                // reference : https://robowiki.net/wiki/Circular_Targeting
                double absBearing = BearingTo(enemy.X, enemy.Y) + Direction;
                double bulletPower = Math.Min(3, Math.Max(600 / DistanceTo(enemy.X, enemy.Y), 1));

                double deltaTime = 0;
                double predictedX = enemy.X, predictedY = enemy.Y;
                while (enemy.Speed != 0 && (++deltaTime) * (20.0 - 3.0 * bulletPower) <
                      DistanceTo(predictedX, predictedY))
                {
                    predictedX += Math.Sin(enemy.Direction) * enemy.Speed;
                    predictedY += Math.Cos(enemy.Direction) * enemy.Speed;
                    if (predictedX < 18.0
                        || predictedY < 18.0
                        || predictedX > ArenaWidth - 18.0
                        || predictedY > ArenaHeight - 18.0)
                    {
                        predictedX = Math.Min(Math.Max(18.0, predictedX),
                                    ArenaWidth - 18.0);
                        predictedY = Math.Min(Math.Max(18.0, predictedY),
                                    ArenaHeight - 18.0);
                        break;
                    }
                }
                double theta = NormalizeAbsoluteAngle(Math.Atan2(
                    predictedY - Y, predictedX - X));

                SetTurnGunLeft(NormalizeRelativeAngle(theta - GunDirection + absBearing));
                SetFire(bulletPower);

            }
        }
        // move in circle and cornerX and cornerY as center
        public void DoMove()
        {

            if (DistanceRemaining == 0 && TurnRemaining == 0)
            {
                SetForward(double.PositiveInfinity);
            }

            double angularVelocity = Speed / radius * (180 / Math.PI);

            TurnRate = angularVelocity * direction;
        }
        public override void OnHitBot(HitBotEvent e)
        {
            var bearing = BearingTo(e.X, e.Y);
            if (bearing > -10 && bearing < 10)
            {
                Fire(3);
            } else {
                Back(100);
            }
            if (e.IsRammed)
            {
                TurnLeft(10);
            }
        }

        private void InitiatePosition()
        {
            MaxSpeed = 8;
            // determine which corner of the map the bot is closest to and move towards that corner
            CurrentCorner = DetermineClosestCorner();
            switch (CurrentCorner)
            {
                case Corner.TopLeft:
                    CurrentSide = Side.Left;
                    break;
                case Corner.TopRight:
                    CurrentSide = Side.Top;
                    break;
                case Corner.BottomRight:
                    CurrentSide = Side.Right;
                    break;
                case Corner.BottomLeft:
                    CurrentSide = Side.Bottom;
                    break;
            }
            MoveToCorner(CurrentCorner, CornerOffset + radius + 2);
            double angle = 0;
            switch (CurrentCorner)
            {
                case Corner.TopLeft:
                    angle = NormalizeRelativeAngle(BearingTo(0, ArenaHeight));
                    break;
                case Corner.TopRight:
                    angle = NormalizeRelativeAngle(BearingTo(ArenaWidth, ArenaHeight));
                    break;
                case Corner.BottomLeft:
                    angle = NormalizeRelativeAngle(BearingTo(0, 0));
                    break;
                case Corner.BottomRight:
                    angle = NormalizeRelativeAngle(BearingTo(ArenaWidth, 0));
                    break;
            }
            SetTurnGunLeft(NormalizeRelativeAngle(angle - GunDirection + 180));
            TurnLeft(NormalizeRelativeAngle(angle - 90));

            switch (CurrentCorner)
            {
                case Corner.TopLeft:
                    cornerX = CornerOffset;
                    cornerY = ArenaHeight - CornerOffset;
                    break;
                case Corner.TopRight:
                    cornerX = ArenaWidth - CornerOffset;
                    cornerY = ArenaHeight - CornerOffset;
                    break;
                case Corner.BottomLeft:
                    cornerX = CornerOffset;
                    cornerY = CornerOffset;
                    break;
                case Corner.BottomRight:
                    cornerX = ArenaWidth - CornerOffset;
                    cornerY = CornerOffset;
                    break;
            }
            MaxSpeed = 5;
        }

        private Corner DetermineClosestCorner()
        {
            double topLeft = DistanceTo(0, ArenaHeight);
            double topRight = DistanceTo(ArenaWidth, ArenaHeight);
            double bottomLeft = DistanceTo(0, 0);
            double bottomRight = DistanceTo(ArenaWidth, 0);

            double min = Math.Min(Math.Min(topLeft, topRight), Math.Min(bottomLeft, bottomRight));

            if (min == topLeft)
            {
                return Corner.TopLeft;
            }
            else if (min == topRight)
            {
                return Corner.TopRight;
            }
            else if (min == bottomLeft)
            {
                return Corner.BottomLeft;
            }
            else
            {
                return Corner.BottomRight;
            }
        } 
        private void MoveToCorner(Corner corner, double offset)
        {
            double cornerX, cornerY;
            switch (corner)
            {
                case Corner.TopLeft:
                    cornerX = 0 + offset;
                    cornerY = ArenaHeight - offset;
                    break;
                case Corner.TopRight:
                    cornerX = ArenaWidth - offset;
                    cornerY = ArenaHeight - offset;
                    break;
                case Corner.BottomLeft:
                    cornerX = 0 + offset;
                    cornerY = 0 + offset;
                    break;
                case Corner.BottomRight:
                    cornerX = ArenaWidth - offset;
                    cornerY = 0 + offset;
                    break;
                default:
                    cornerX = 0;
                    cornerY = 0;
                    break;
            }
            TurnLeft(NormalizeRelativeAngle(BearingTo(cornerX, cornerY)));
            Forward(DistanceTo(cornerX, cornerY));
            CurrentCorner = corner;
        }
        // moves straight to the desired side (not turning only determine the distance and moves forward or backward based on the current direction and side so it doesnt need to rotate)
        private void MoveToSide(Side side)
        {
            // determine the closest distance to the side while keeping direction
            double closestDistance = 0;
            switch (side)
            {
                case Side.Left:
                    closestDistance = DistanceTo(0, Y);
                    break;
                case Side.Right:
                    closestDistance = DistanceTo(ArenaWidth, Y);
                    break;
                case Side.Top:
                    closestDistance = DistanceTo(X, ArenaHeight);
                    break;
                case Side.Bottom:
                    closestDistance = DistanceTo(X, 0);
                    break;
            }
            closestDistance -= TankRadius; // prevent collision

            // calculate the angle to the side
            double angle = 0;
            switch (side)
            {
                case Side.Left:
                    angle = BearingTo(0, Y);
                    break;
                case Side.Right:
                    angle = BearingTo(ArenaWidth, Y);
                    break;
                case Side.Top:
                    angle = BearingTo(X, ArenaHeight);
                    break;
                case Side.Bottom:
                    angle = BearingTo(X, 0);
                    break;
            }

            // determine if backward movement is more efficient
            bool isBackward = Math.Abs(angle) > 90;

            // convert angle to radians for Math.Cos
            double angleRadians = Math.Abs(angle) * Math.PI / 180;

            // if moving backward, adjust the angle for proper calculation
            if (isBackward)
            {
                angleRadians = Math.PI - angleRadians;
            }

            //   distance using Cos gives adjacent/hypotenuse ratio
            //  divide by cos to get the hypotenuse (actual travel distance)
            double distance = closestDistance / Math.Cos(angleRadians);

            if (isBackward)
            {
                Back(distance - 1);
            }
            else
            {
                Forward(distance - 1);
            }

            // the gun direction to paralel with side direction

            double direction = 0;
            switch (CurrentCorner)
            {
                case Corner.TopLeft:
                    switch (side)
                    {
                        case Side.Top:
                            direction = 270;
                            break;
                        case Side.Left:
                            direction = 0;
                            break;
                    }
                    break;
                case Corner.TopRight:
                    switch (side)
                    {
                        case Side.Top:
                            direction = 270;
                            break;
                        case Side.Right:
                            direction = 180;
                            break;
                    }
                    break;
                case Corner.BottomLeft:
                    switch (side)
                    {
                        case Side.Bottom:
                            direction = 90;
                            break;
                        case Side.Left:
                            direction = 0;
                            break;
                    }
                    break;
                case Corner.BottomRight:
                    switch (side)
                    {
                        case Side.Bottom:
                            direction = 90;
                            break;
                        case Side.Right:
                            direction = 180;
                            break;
                    }
                    break;
            }

            SetTurnGunLeft(NormalizeRelativeAngle(direction - GunDirection));

            Go();
            CurrentSide = side;
        }

        private double HitChance(double distance, double anglediff)
        {
            double anglediffrad = anglediff * Math.PI / 180;
            double chance;
            if (distance > 200)
            {
                chance = Math.Max(Math.Cos(anglediffrad), 0) * Math.Max(1 - Math.Pow(distance / 900, 1.5), 0.1);
            }
            else
            {
                chance = Math.Max(1 - Math.Pow(distance / 900, 1.5), 0.1);
            }
            return chance;
        }

    }
    // attributes same as ScannedBot
    public class Enemy
    {
        public int ScannedByBotId { get; }
        public int ScannedBotId { get; }

        public double Energy { get; }

        public double X { get; }

        public double Y { get; }

        public double Direction { get; }

        public double Speed { get; }

        public Enemy(ScannedBotEvent e) => (ScannedByBotId, ScannedBotId, Energy, X, Y, Direction, Speed) =
            (e.ScannedByBotId, e.ScannedBotId, e.Energy, e.X, e.Y, e.Direction, e.Speed);
    }
}
