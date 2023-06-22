using Microsoft.VisualStudio.TestTools.UnitTesting;
using DnA.Main.Box.Api;
using DnA.Main.Box.Impl;
using DnA.Main.Common;
using static DnA.Game.Player.api.IPlayer;
using DnA.Game.Player.api;
using DnA.GMain.ObjMain.Entity.Api;
using DnA.Main.Game.Impl;
using DnA.Game.Player.impl;

namespace DnA.Test
{

[TestClass]
public class CollisionTest
{
    private const double X = 10;
    private const double Y = 20;
    private static readonly Position2d POS = new (X, Y);
    private const double HEIGHT = 4;
    private const double WIDTH = 4;
    private readonly IBoundingBox BOX = new RectBoundingBox(POS, HEIGHT, WIDTH);
    private const int GAMEHEIGHT = 400;
    private const int GAMEWIDTH = 400;
    private readonly GameState GAME = new (GAMEWIDTH, GAMEHEIGHT, new List<IEntity>(), new List<IPlayer>());
    private readonly Player CHARACTER = new (POS, new Vector2d(0, 0), HEIGHT, WIDTH, PlayerType.ANGEL);

    /// <summary>
    /// Test the collision between rectangular boxes.
    /// </summary>
    [TestMethod]
    public void TestRectCollision()
    {
        //(0,0) angolo in alto a sx
        Assert.IsTrue(BOX.IsCollidingWith(POS, HEIGHT, WIDTH));
        Assert.IsTrue(BOX.IsCollidingWith(POS, HEIGHT / 2, WIDTH / 2));
        Assert.IsTrue(BOX.IsCollidingWith(new Position2d(X - WIDTH, Y), HEIGHT, WIDTH));
        Assert.IsTrue(BOX.IsCollidingWith(new Position2d(X, Y - HEIGHT), HEIGHT, WIDTH));
        Assert.IsTrue(BOX.IsCollidingWith(new Position2d(X + WIDTH, Y), HEIGHT, WIDTH));
        Assert.IsTrue(BOX.IsCollidingWith(new Position2d(X, Y + HEIGHT), HEIGHT, WIDTH));

        Assert.IsFalse(BOX.IsCollidingWith(new Position2d(X, 0), HEIGHT, WIDTH));
        Assert.IsFalse(BOX.IsCollidingWith(new Position2d(0, Y), HEIGHT, WIDTH));
        Assert.IsFalse(BOX.IsCollidingWith(new Position2d(X + WIDTH + 1, Y), HEIGHT, WIDTH));
        Assert.IsFalse(BOX.IsCollidingWith(new Position2d(X, Y + HEIGHT + 1), HEIGHT, WIDTH));
        Assert.IsFalse(BOX.IsCollidingWith(new Position2d(X - WIDTH - 1, Y), HEIGHT, WIDTH));
        Assert.IsFalse(BOX.IsCollidingWith(new Position2d(X, Y - HEIGHT - 1), HEIGHT, WIDTH));
    }

    /// <summary>
    /// Test if the collision is on the left or the right side.
    /// </summary>
    [TestMethod]
    public void TestSideCollision()
    {
        //(0,0) angolo in alto a sx
        Assert.IsTrue(BOX.SideCollision(new Position2d(X + WIDTH, Y), HEIGHT, WIDTH));
        Assert.IsTrue(BOX.SideCollision(new Position2d(X - WIDTH, Y), HEIGHT, WIDTH));
        Assert.IsTrue(BOX.SideCollision(new Position2d(X + WIDTH, Y - HEIGHT), HEIGHT, WIDTH));
        Assert.IsTrue(BOX.SideCollision(new Position2d(X - WIDTH, Y + HEIGHT), HEIGHT, WIDTH));
        Assert.IsTrue(BOX.SideCollision(new Position2d(X + WIDTH + 1, Y - 1), HEIGHT, WIDTH));

        Assert.IsFalse(BOX.SideCollision(POS, HEIGHT, WIDTH));
        Assert.IsFalse(BOX.SideCollision(new Position2d(X, Y - HEIGHT), HEIGHT, WIDTH));
        Assert.IsFalse(BOX.SideCollision(new Position2d(X, Y + HEIGHT), HEIGHT, WIDTH));
        Assert.IsFalse(BOX.SideCollision(new Position2d(X + WIDTH / 2, Y + HEIGHT), HEIGHT, WIDTH));
        Assert.IsFalse(BOX.SideCollision(new Position2d(X + WIDTH - 1, Y), HEIGHT / 2, WIDTH / 2));
    }

    /// <summary>
    /// Test the collision between the character and the borders.
    /// </summary>
    [TestMethod]
    public void TestBordersCollision()
    {
        //(0,0) angolo in alto a sx
        double eastBorderX = GAME.GetBoundingBox().GetWidth();
        double westBorderX = 0;
        double northBorderY = 0;
        double southBorderY = GAME.GetBoundingBox().GetHeight();

        CHARACTER.SetPosition(new Position2d(eastBorderX - WIDTH - 1, 1));
        Assert.IsFalse(GAME.CheckVerticalBorders(CHARACTER.GetPosition().GetX(), CHARACTER.GetBoundingBox().GetWidth()));
        CHARACTER.SetPosition(new Position2d(eastBorderX - WIDTH, 1));
        Assert.IsTrue(GAME.CheckVerticalBorders(CHARACTER.GetPosition().GetX(), CHARACTER.GetBoundingBox().GetWidth()));

        CHARACTER.SetPosition(new Position2d(westBorderX + 1, 1));
        Assert.IsFalse(GAME.CheckVerticalBorders(CHARACTER.GetPosition().GetX(), CHARACTER.GetBoundingBox().GetWidth()));
        CHARACTER.SetPosition(new Position2d(westBorderX, 1));
        Assert.IsTrue(GAME.CheckVerticalBorders(CHARACTER.GetPosition().GetX(), CHARACTER.GetBoundingBox().GetWidth()));

        CHARACTER.SetPosition(new Position2d(1, northBorderY + 1));
        Assert.IsFalse(GAME.CheckHorizontalBorders(CHARACTER.GetPosition().GetY(), CHARACTER.GetBoundingBox().GetHeight()));
        CHARACTER.SetPosition(new Position2d(1, northBorderY));
        Assert.IsTrue(GAME.CheckHorizontalBorders(CHARACTER.GetPosition().GetY(), CHARACTER.GetBoundingBox().GetHeight()));

        CHARACTER.SetPosition(new Position2d(1, southBorderY - HEIGHT - 1));
        Assert.IsFalse(GAME.CheckHorizontalBorders(CHARACTER.GetPosition().GetY(), CHARACTER.GetBoundingBox().GetHeight()));
        CHARACTER.SetPosition(new Position2d(1, southBorderY - HEIGHT));
        Assert.IsTrue(GAME.CheckHorizontalBorders(CHARACTER.GetPosition().GetY(), CHARACTER.GetBoundingBox().GetHeight()));
    }
}

}