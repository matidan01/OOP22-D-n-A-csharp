using DnA.Game.Player.api;
using DnA.GMain.ObjMain.Entity.Api;
using DnA.GMain.ObjMain.MovableEntity.Impl;
using DnA.GMain.ObjMain.StillEntity.Impl;
using DnA.Main.Extra;
using DnA.ObjMain.StillEntity.Impl;

namespace DnA.Main.Events.Api
{
    /// <summary>
    /// Interface of a factory that creates events.
    /// </summary>
    public interface IEventFactory
{
    /// <summary>
    /// Models the collision event with a platform.
    /// </summary>
    /// <param name="platform">The hit platform.</param>
    /// <param name="player">The player.</param>
    /// <returns>The new event.</returns>
    IEvent HitPlatformEvent(IEntity platform, IPlayer player);

    /// <summary>
    /// Models the collision event with a movable platform.
    /// </summary>
    /// <param name="movablePlatform">The hit movable platform.</param>
    /// <param name="player">The player.</param>
    /// <returns>The new event.</returns>
    IEvent HitMovablePlatformEvent(MovablePlatform movablePlatform, IPlayer player);

    /// <summary>
    /// Models the collision event with the horizontal borders.
    /// </summary>
    /// <param name="player">The player.</param>
    /// <returns>The new event.</returns>
    IEvent HitBorderXEvent(IPlayer player);

    /// <summary>
    /// Models the collision event with the vertical borders.
    /// </summary>
    /// <param name="player">The player.</param>
    /// <returns>The new event.</returns>
    IEvent HitBorderYEvent(IPlayer player);

    /// <summary>
    /// Models the collision event with a button.
    /// </summary>
    /// <param name="button">The hit button.</param>
    /// <param name="player">The player.</param>
    /// <returns>The new event.</returns>
    IEvent HitButtonEvent(ActivableObjectImpl button, IPlayer player);

    /// <summary>
    /// Models the collision event with a door.
    /// </summary>
    /// <param name="door">The hit door.</param>
    /// <param name="player">The player.</param>
    /// <returns>The new event.</returns>
    IEvent HitDoorEvent(Door door, IPlayer player);

    /// <summary>
    /// Models the collision event with a lever.
    /// </summary>
    /// <param name="lever">The hit lever.</param>
    /// <param name="player">The player.</param>
    /// <returns>The new event.</returns>
    IEvent HitLeverEvent(ActivableObjectImpl lever, IPlayer player);

    /// <summary>
    /// Models the collision event with a diamond.
    /// </summary>
    /// <param name="diamond">The hit diamond.</param>
    /// <returns>The new event.</returns>
    IEvent HitDiamondEvent(Diamond diamond);

    /// <summary>
    /// Models the successful completion of the level.
    /// </summary>
    /// <returns>The new event.</returns>
    IEvent VictoryEvent();

    /// <summary>
    /// Models the failure of the level.
    /// </summary>
    /// <returns>The new event.</returns>
    IEvent GameOverEvent();
}

}