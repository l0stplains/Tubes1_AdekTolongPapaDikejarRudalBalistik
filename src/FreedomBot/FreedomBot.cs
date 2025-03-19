using System;
using System.Drawing;
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

public enum State{
    MoveToCorner,
    MoveCornerInterrupted,
    MoveSideToSide,
    MoveSideToSideInterrupted,
    // etc, not all states are listed yet

}

namespace Tubes1_AdekTolongPapaDikejarRudalBalistik.FreedomBot
{
    public class FreedomBot : Bot
    {
        public const double TankHeight = 36;
        public const double TankWidth = 36;
        public const double TankRadius = 18;

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

            while (IsRunning)
            {
                switch (CurrentCorner)
                {
                    case Corner.TopLeft:
                        switch (CurrentSide)
                        {
                            case Side.Top:
                                MoveToSide(Side.Left);
                                break;
                            case Side.Left:
                                MoveToSide(Side.Top);
                                break;
                        }
                        break;
                    case Corner.TopRight:
                        switch (CurrentSide)
                        {
                            case Side.Top:
                                MoveToSide(Side.Right);
                                break;
                            case Side.Right:
                                MoveToSide(Side.Top);
                                break;
                        }
                        break;
                    case Corner.BottomLeft:
                        switch (CurrentSide)
                        {
                            case Side.Bottom:
                                MoveToSide(Side.Left);
                                break;
                            case Side.Left:
                                MoveToSide(Side.Bottom);
                                break;
                        }
                        break;
                    case Corner.BottomRight:
                        switch (CurrentSide)
                        {
                            case Side.Bottom:
                                MoveToSide(Side.Right);
                                break;
                            case Side.Right:
                                MoveToSide(Side.Bottom);
                                break;
                        }
                        break;
                }
            }

        }

        public override void OnScannedBot(ScannedBotEvent e)
        {
            Stop();
            Fire(1);
            Resume();
        }

        private void InitiatePosition()
        {
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
            MoveToCorner(CurrentCorner, 50);
            // rotate to the opposite corner using bearing to and normalize relative angle
            switch (CurrentCorner)
            {
                case Corner.TopLeft:
                    TurnLeft(NormalizeRelativeAngle(BearingTo(ArenaWidth, 0)));
                    break;
                case Corner.TopRight:
                    TurnLeft(NormalizeRelativeAngle(BearingTo(0, 0)));
                    break;
                case Corner.BottomLeft:
                    TurnLeft(NormalizeRelativeAngle(BearingTo(ArenaWidth, ArenaHeight)));
                    break;
                case Corner.BottomRight:
                    TurnLeft(NormalizeRelativeAngle(BearingTo(0, ArenaHeight)));
                    break;
            }
            TurnLeft(90);
            TurnGunRight(90);
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

        /// <summary>
        /// Rotates the CurrentSide attribute to the next side in clockwise order
        /// </summary>
        private void RotateCurrentSide()
        {
            switch (CurrentSide)
            {
                case Side.Left:
                    CurrentSide = Side.Top;
                    break;
                case Side.Right:
                    CurrentSide = Side.Bottom;
                    break;
                case Side.Top:
                    CurrentSide = Side.Right;
                    break;
                case Side.Bottom:
                    CurrentSide = Side.Left;
                    break;
                default:
                    CurrentSide = Side.Left;
                    break;
            }
        }

        /// <summary>
        /// Moves the bot to the specified corner with a buffer of offset
        /// 
        /// For example if the corner is TopLeft and the offset is 50, it will move to (0 + 50, ArenaHeight - 50)
        /// 
        /// <param name="corner"></param>
        /// <param name="offset"></param>
        // </summary>
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
            switch(CurrentCorner){
                case Corner.TopLeft:
                    switch(side){
                        case Side.Top:
                            direction = 270;
                            break;
                        case Side.Left:
                            direction = 0;
                            break;
                    }
                    break;
                case Corner.TopRight:
                    switch(side){
                        case Side.Top:
                            direction = 270;
                            break;
                        case Side.Right:
                            direction = 180;
                            break;
                    }
                    break;
                case Corner.BottomLeft:
                    switch(side){
                        case Side.Bottom:
                            direction = 90;
                            break;
                        case Side.Left:
                            direction = 0;
                            break;
                    }
                    break;
                case Corner.BottomRight:
                    switch(side){
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
    }
}
