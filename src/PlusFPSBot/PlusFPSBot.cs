using System;
using System.Drawing;
using System.Threading;
using Robocode.TankRoyale.BotApi;
using Robocode.TankRoyale.BotApi.Events;

namespace Tubes1_AdekTolongPapaDikejarRudalBalistik.PlusFPSBot
{
    public class PlusFPSBot : Bot
    {
        static void Main(string[] args)
        {
            new PlusFPSBot().Start();
        }

        PlusFPSBot() : base(BotInfo.FromFile("PlusFPSBot.json")) { }

        public override void Run()
        {
            double hue = 0.0;
            while (IsRunning)
            {
                BodyColor = ColorFromHSV(hue, 1.0, 1.0);

                hue = (hue + 1.0) % 360;

                // delay
                TurnRight(1);
            }
        }

        public static Color ColorFromHSV(double hue, double saturation, double value)
        {
            int hi = Convert.ToInt32(Math.Floor(hue / 60)) % 6;
            double f = hue / 60 - Math.Floor(hue / 60);

            value = value * 255;
            int v = Convert.ToInt32(value);
            int p = Convert.ToInt32(value * (1 - saturation));
            int q = Convert.ToInt32(value * (1 - f * saturation));
            int t = Convert.ToInt32(value * (1 - (1 - f) * saturation));

            switch (hi)
            {
                case 0:
                    return Color.FromArgb(v, t, p);
                case 1:
                    return Color.FromArgb(q, v, p);
                case 2:
                    return Color.FromArgb(p, v, t);
                case 3:
                    return Color.FromArgb(p, q, v);
                case 4:
                    return Color.FromArgb(t, p, v);
                default:
                    return Color.FromArgb(v, p, q);
            }
        }
    }
}

