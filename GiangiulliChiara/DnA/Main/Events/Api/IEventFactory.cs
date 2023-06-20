using DnA.Main.Extra;
using OOP22_D_n_A_csharp.MazzoniGaia.DnA.GMain.ObjMain.MovableEntity.Impl;
using OOP22_D_n_A_csharp.MazzoniGaia.DnA.GMain.ObjMain.StillEntity.Impl;
using OOP22_D_n_A_csharp.MazzoniGaia.DnA.ObjMain.StillEntity.Impl;

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
    IEvent HitPlatformEvent(Entity platform, Player player);

    /// <summary>
    /// Models the collision event with a movable platform.
    /// </summary>
    /// <param name="movablePlatform">The hit movable platform.</param>
    /// <param name="player">The player.</param>
    /// <returns>The new event.</returns>
    IEvent HitMovablePlatformEvent(MovablePlatform movablePlatform, Player player);

    /// <summary>
    /// Models the collision event with the horizontal borders.
    /// </summary>
    /// <param name="player">The player.</param>
    /// <returns>The new event.</returns>
    IEvent HitBorderXEvent(Player player);

    /// <summary>
    /// Models the collision event with the vertical borders.
    /// </summary>
    /// <param name="player">The player.</param>
    /// <returns>The new event.</returns>
    IEvent HitBorderYEvent(Player player);

    /// <summary>
    /// Models the collision event with a button.
    /// </summary>
    /// <param name="button">The hit button.</param>
    /// <param name="player">The player.</param>
    /// <returns>The new event.</returns>
    IEvent HitButtonEvent(ActivableObjectImpl button, Player player);

    /// <summary>
    /// Models the collision event with a door.
    /// </summary>
    /// <param name="door">The hit door.</param>
    /// <param name="player">The player.</param>
    /// <returns>The new event.</returns>
    IEvent HitDoorEvent(Door door, Player player);

    /// <summary>
    /// Models the collision event with a lever.
    /// </summary>
    /// <param name="lever">The hit lever.</param>
    /// <param name="player">The player.</param>
    /// <returns>The new event.</returns>
    IEvent HitLeverEvent(ActivableObjectImpl lever, Player player);

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