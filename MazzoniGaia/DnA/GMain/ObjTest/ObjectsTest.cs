using DnA.Game.Player.api;
using DnA.Game.Player.impl;
using DnA.GMain.ObjMain.Entity.Api;
using DnA.GMain.ObjMain.Entity.Impl;
using DnA.GMain.ObjMain.MovableEntity.Impl;
using DnA.GMain.ObjMain.StillEntity.Impl;
using DnA.Main.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DnA.GMain.ObjTest
{
    [TestClass]
    public class ObjectsTest
    {
        private static readonly EntityFactoryImpl ENTITYFACTORY = new ();
        private const double X = 10;
        private const double Y = 20;
        private static readonly Position2d POS = new (X, Y);
        private static readonly Position2d POS2 = new (X + X, Y + Y);
        private static readonly Position2d POS3 = new (X + 15, Y + 15);
        private const double HEIGHT = 4;
        private const double WIDTH = 4;
        private static readonly IPlayer ANGEL = new Player(POS, new Vector2d(0, 0), HEIGHT, WIDTH, IPlayer.PlayerType.ANGEL);
        private static readonly IPlayer DEVIL = new Player(POS2, new Vector2d(0, 0), HEIGHT, WIDTH, IPlayer.PlayerType.DEVIL);
        private static readonly MovablePlatform PLATFORM = new(POS, new Vector2d(0, 0), HEIGHT, WIDTH, IEntity.EntityType.MOVABLEPLATFORM, POS);
        private static readonly IEntity BUTTON = ENTITYFACTORY.CreateEntity(PLATFORM, IEntity.EntityType.BUTTON, POS);
        private static readonly IEntity LEVER = ENTITYFACTORY.CreateEntity(PLATFORM, IEntity.EntityType.LEVER, POS2);
        private static readonly IEntity ANGELDOOR = ENTITYFACTORY.CreateEntity(null, IEntity.EntityType.ANGEL_DOOR, POS);
        private static readonly IEntity DEVILDOOR = ENTITYFACTORY.CreateEntity(null, IEntity.EntityType.DEVIL_DOOR, POS2);
        private static readonly IEntity RED_PUDDLE = ENTITYFACTORY.CreateEntity(null, IEntity.EntityType.RED_PUDDLE, POS3);

        [TestMethod]
        public void TestMovablePlatformMethods()
        {
            Position2d finalPos = new (X + 100, Y + 100); // test vector 0.5, 0.5
            PLATFORM.SetFinalPosition(finalPos);
            PLATFORM.FindVector(PLATFORM.GetOriginalPosition(), PLATFORM.GetFinalPosition());
            Assert.AreEqual(PLATFORM.GetVector(), new Vector2d(+0.5, +0.5));

            finalPos = new Position2d(X + 100, Y - 100); // test vector 0.5, -0.5
            PLATFORM.SetFinalPosition(finalPos);
            PLATFORM.FindVector(PLATFORM.GetOriginalPosition(), PLATFORM.GetFinalPosition());
            Assert.AreEqual(PLATFORM.GetVector(), new Vector2d(+0.5, -0.5));

            finalPos = new Position2d(X - 100, Y + 100); // test vector -0.5, 0.5
            PLATFORM.SetFinalPosition(finalPos);
            PLATFORM.FindVector(PLATFORM.GetOriginalPosition(), PLATFORM.GetFinalPosition());
            Assert.AreEqual(PLATFORM.GetVector(), new Vector2d(-0.5, +0.5));

            finalPos = new Position2d(X - 100, Y - 100); // test vector -0.5, -0.5
            PLATFORM.SetFinalPosition(finalPos);
            PLATFORM.FindVector(PLATFORM.GetOriginalPosition(), PLATFORM.GetFinalPosition());
            Assert.AreEqual(PLATFORM.GetVector(), new Vector2d(-0.5, -0.5));

            PLATFORM.SetPosition(PLATFORM.GetFinalPosition());
            PLATFORM.SetLastPosition();
            PLATFORM.FindLimit();
            Assert.AreEqual(PLATFORM.GetPosition(), PLATFORM.GetFinalPosition());
        }

        [TestMethod]
        public void TestDoor()
        {
            Assert.AreEqual(((Door)ANGELDOOR).GetDoorState(), Door.DoorState.CLOSED_DOOR);
            Assert.AreEqual(((Door)DEVILDOOR).GetDoorState(), Door.DoorState.CLOSED_DOOR);
            ((Door)ANGELDOOR).OpenDoor(ANGEL);
            ((Door)DEVILDOOR).OpenDoor(DEVIL);
            Assert.AreEqual(((Door)ANGELDOOR).GetDoorState(), Door.DoorState.OPEN_DOOR);
            Assert.AreEqual(((Door)DEVILDOOR).GetDoorState(), Door.DoorState.OPEN_DOOR);
        }

        [TestMethod]
        public void TestActivableObject()
        {
            ((ActivableObjectImpl)BUTTON).Activate();
            Assert.IsTrue(((ActivableObjectImpl)BUTTON).IsActivated());
            Assert.AreEqual(((ActivableObjectImpl)BUTTON).GetMovablePlatform()?.GetPosition(), PLATFORM.GetFinalPosition());
            ((ActivableObjectImpl)LEVER).Deactivate();
            Assert.IsFalse(((ActivableObjectImpl)LEVER).IsActivated());
            Assert.AreEqual(((ActivableObjectImpl)LEVER).GetMovablePlatform()?.GetPosition(), PLATFORM.GetOriginalPosition());
        }

        [TestMethod]
        public void TestPuddles()
        {
            Assert.IsTrue(((Puddle)RED_PUDDLE).KillPlayer(ANGEL));
            Assert.IsFalse(((Puddle)RED_PUDDLE).KillPlayer(DEVIL));
        }
    }
}
