using System;
using System.Drawing;
using Robocode.TankRoyale.BotApi;
using Robocode.TankRoyale.BotApi.Events;

namespace Tubes1_AdekTolongPapaDikejarRudalBalistik.MainBot;

public class MainBot : Bot
{
    static void Main(string[] args)
    {
        new MainBot().Start();
    }

    MainBot() : base(BotInfo.FromFile("MainBot.json")) { }

    public override void Run()
    {
        BodyColor = Color.Gray;

        while (IsRunning)
        {
            Forward(100); Back(100); Fire(1);
        }
    }

    public override void OnScannedBot(ScannedBotEvent e)
    {
        Console.WriteLine("I see a bot at " + e.X + ", " + e.Y);
    }

    public override void OnHitBot(HitBotEvent e)
    {
        Console.WriteLine("Ouch! I hit a bot at " + e.X + ", " + e.Y);
    }

    public override void OnHitWall(HitWallEvent e)
    {
        Console.WriteLine("Ouch! I hit a wall, must turn back!");
    }
}
