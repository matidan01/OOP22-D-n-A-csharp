using DnA.Main.Events.Api;
using DnA.Main.Extra;
using OOP22_D_n_A_csharp.MazzoniGaia.DnA.ObjMain.StillEntity.Impl;
using static DnA.Game.Player.impl.State;
namespace DnA.Main.Events.Impl
{
    /// <summary>
    /// Class that implements the <see cref="IEventFactory"/> interface.
    /// </summary>
    public class EventFactoryImpl : IEventFactory
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns><inheritdoc/></returns>
        public IEvent HitPlatformEvent(Entity platform, Player player) => new Event(game =>
            {
                if (player.GetBoundingBox().SideCollision(platform.GetPosition(), platform.GetBoundingBox().GetHeight(), platform.GetBoundingBox().GetWidth()))
                {
                    player.ResetX();
                }
                else
                {
                    player.ResetY();
                }
                if (player.GetStateCopy()._stateX.Equals(StateEnum.STATE_JUMPING) && player.GetPosition().GetX() < platform.GetPosition().GetY())
                {
                    player.SetStateX(StateEnum.STATE_STANDING);
                }
            }); 

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns><inheritdoc/></returns>
        public IEvent HitMovablePlatformEvent(MovablePlatform platform, Player player) => new Event(game =>
            {
                player.SetVectorY(player.GetVector().GetY() + platform.GetVector().GetY());
                if (player.GetVector().GetX() == 0 && platform.GetPreviousVector().GetX() != 0)
                {
                    player.SetVectorX(platform.GetPreviousVector().GetX());
                }
                else
                {
                    player.SetVectorX(player.GetVector().GetX() + platform.GetVector().GetX()- platform.GetPreviousVector().GetX());
                }
                if (platform.GetVector().GetX() != 0 || platform.GetPreviousVector().GetX() != 0)
                {
                    platform.SetPreviousVector(platform.GetVector());
                }
                if (player.GetPosition().GetY() + player.GetBoundingBox().GetHeight() > platform.GetPosition().GetY() && player.GetPosition().GetY() + player.GetBoundingBox().GetHeight() < platform.GetPosition().GetY() + platform.GetBoundingBox().GetHeight())
                {
                    player.SetPositionY(platform.GetPosition().GetY() - player.GetBoundingBox().GetHeight());
                }
            });

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns><inheritdoc/></returns>
        public IEvent HitButtonEvent(ActivableObjectImpl button, Player player) => new Event(game =>
            {
                if (button.GetPlayer() == null)
                {
                    button.SetPlayer(player);
                    if (!button.IsActivated())
                    {
                        button.Activate();
                    }
                    else
                    {
                        button.Deactivate();
                        button.ResetPlayer();
                    }
                }
            });

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns><inheritdoc/></returns>
        public IEvent HitDoorEvent(Door door, Player player) => new Event(game =>
            {
                if (door.GetPlayer() == null)
                {
                    door.OpenDoor(player);
                }
            });

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns><inheritdoc/></returns>
        public IEvent HitLeverEvent(ActivableObjectImpl lever, Player player) => new Event(game =>
            {
                if (lever.GetPlayer() == null)
                {
                    lever.SetPlayer(player);
                    if (lever.IsActivated())
                    {
                        lever.Deactivate();
                    }
                    else
                    {
                        lever.Activate();
                    }
                }
            });

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns><inheritdoc/></returns>
        public IEvent HitDiamondEvent(Diamond diamond) => new Event(game =>
            {
                game.RemoveEntity(diamond);
                GameEngineImpl.PlaySound("Diamond_sound");
            });

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns><inheritdoc/></returns>
        public IEvent HitBorderXEvent(Player player) => new Event(game =>
            {
                player.ResetY();
                if (player.GetStateCopy()._stateX.Equals(StateEnum.STATE_JUMPING))
                {
                    player.SetStateX(StateEnum.STATE_STANDING);
                }
            });

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns><inheritdoc/></returns>
        public IEvent HitBorderYEvent(Player player) => new Event(game =>
            {
                player.ResetX();
            });

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns><inheritdoc/></returns>
        public IEvent VictoryEvent() => new Event(game =>
            {
                GameEngineImpl.PlaySound("Victory_sound");
                GameEngineImpl.GetGameThread().VictoryGame();
            });

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns><inheritdoc/></returns>
        public IEvent GameOverEvent() => new Event(game =>
            {
                GameEngineImpl.PlaySound("GameOver_sound");
                GameEngineImpl.GetGameThread().LoosingGame();
            });
    }

}