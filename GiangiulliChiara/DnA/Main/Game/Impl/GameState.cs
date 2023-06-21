using DnA.Main.Game.Api;
using DnA.Main.Extra;
using DnA.Main.Box.Api;
using DnA.Main.Box.Impl;
using DnA.Main.Events.Impl;
using DnA.Main.Events.Api;
using DnA.Main.Common;
using DnA.Game.Player.impl;
using DnA.GMain.ObjMain.Entity.Api;
using DnA.Game.Player.api;
using DnA.ObjMain.StillEntity.Impl;
using DnA.GMain.ObjMain.MovableEntity.Impl;

namespace DnA.Main.Game.Impl
{
    /// <summary>
    /// Represents the state of the game.
    /// </summary>
    public class GameState : IGameState
    {
        /// <summary>
        /// The constant value of the game's gravity.
        /// </summary>
        public const double GRAVITY = 0.8;

        private readonly List<IEntity> _entities;
        private readonly List<IPlayer> _characters;
        private readonly IBoundingBox _boundingBox;
        private readonly IEventFactory _eventFactory = new EventFactoryImpl();
        private readonly EventQueue _eventQueue = new ();
        private double _score;

        /// <summary>
        /// <see cref="GameStateImpl"/> constructor.
        /// </summary>
        /// <param name="width">The width of the game.</param>
        /// <param name="height">The height of the game.</param>
        /// <param name="entities">The entities of the game.</param>
        /// <param name="players">The players of the game.</param>
        public GameState(int width, int height, List<IEntity> entities, List<IPlayer> players)
        {
            _boundingBox = new RectBoundingBox(new Position2d(0, 0), height, width);
            _entities = new List<IEntity>(entities);
            _characters = new List<IPlayer>(players);
            _score = 0;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void Update()
        {
            _characters.ForEach(c =>
            {
                Gravity(c);
                CheckCollisions(c);
                CheckBorders(c);
            });

            _eventQueue.ManageEvents(this);

            _characters.ForEach(c => c.Update());

            _entities
                .OfType<MovablePlatform>()
                .ToList()
                .ForEach(entity => entity.MovablePlatformUpdate());
        }

        /// <summary>
        /// Manages the gravity of the player.
        /// </summary>
        /// <param name="player">The player to manage.</param>
        private static void Gravity(IPlayer player)
        {
            if (player.GetVector().GetY() < GRAVITY)
            {
                player.GetVector().SumY(IPlayer.STANDARDVELOCITY);
            }
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns><inheritdoc/></returns>
        public IBoundingBox GetBoundingBox()
        {
            return new RectBoundingBox(_boundingBox.GetPosition(), _boundingBox.GetHeight(), _boundingBox.GetWidth());
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns><inheritdoc/></returns>
        public void AddEntity(IEntity e)
        {
            _entities.Add(e);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns><inheritdoc/></returns>
        public void RemoveEntity(IEntity e)
        {
            _entities.Remove(e);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns><inheritdoc/></returns>
        public List<IEntity> GetEntities()
        {
            return new List<IEntity>(_entities);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns><inheritdoc/></returns>
        public List<IPlayer> GetCharacters()
        {
            return new List<IPlayer>(_characters);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns><inheritdoc/></returns>
        public double GetScore()
        {
            return _score;
        }

        /// <summary>
        /// Manages when a character leaves an activable object or a door.
        /// </summary>
        /// <param name="character">The player to check.</param>
        private void FreeObject(IPlayer character)
        {
            var box = character.GetBoundingBox();
            _entities
                .Where(e => !e.GetBoundingBox().IsCollidingWith(box.GetPosition(), box.GetHeight(), box.GetWidth()))
                .ToList()
                .ForEach(e =>
                {
                    Player? objPlayer;
                    switch (e.Type())
                    {
                        case EntityType.BUTTON:
                        case EntityType.LEVER:
                            objPlayer = ((ActivableObjectImpl)e).GetPlayer();
                            if (objPlayer != null && objPlayer.Equals(character))
                            {
                                if (e.Type() == EntityType.BUTTON)
                                {
                                    ((ActivableObjectImpl)e).Deactivate();
                                }
                                ((ActivableObjectImpl)e).ResetPlayer();
                            }
                            break;
                        case EntityType.DEVIL_DOOR:
                        case EntityType.ANGEL_DOOR:
                            objPlayer = ((Door)e).GetPlayer();
                            if (objPlayer != null && objPlayer.Equals(character))
                            {
                                ((Door)e).CloseDoor();
                                ((Door)e).ResetPlayer();
                            }
                            break;
                        default:
                            break;
                    }
                });
        }

        /// <summary>
        /// Checks if both doors are open.
        /// </summary>
        /// <returns>true if both doors are open.</returns>
        private bool CheckForEndGame()
        {
            return _entities
                .OfType<Door>()
                .Where(entity => entity.GetDoorState() == Door.DoorState.OPEN_DOOR)
                .Count() == 2;
        }

        /// <summary>
        /// Checks the collision of a character with the entities in the game.
        /// </summary>
        /// <param name="character">The moving player.</param>
        private void CheckCollisions(IPlayer character)
        {
            var chPos = character.GetPosition().Sum(character.GetVector());
            var chHeight = character.GetBoundingBox().GetHeight();
            var chWidth = character.GetBoundingBox().GetWidth();

            _entities
                .Where(e => e.GetBoundingBox().IsCollidingWith(chPos, chHeight, chWidth))
                .ToList()
                .ForEach(e =>
                {
                    switch (e.Type())
                    {
                        case EntityType.PLATFORM:
                            _eventQueue.AddEvent(_eventFactory.HitPlatformEvent(e, character));
                            break;
                        case EntityType.MOVABLEPLATFORM:
                            _eventQueue.AddEvent(_eventFactory.HitPlatformEvent(e, character));
                            _eventQueue.AddEvent(_eventFactory.HitMovablePlatformEvent((MovablePlatform)e, character));
                            break;
                        case EntityType.BUTTON:
                            _eventQueue.AddEvent(_eventFactory.HitButtonEvent((ActivableObjectImpl)e, character));
                            break;
                        case EntityType.LEVER:
                            _eventQueue.AddEvent(_eventFactory.HitLeverEvent((ActivableObjectImpl)e, character));
                            break;
                        case EntityType.ANGEL_DOOR:
                        case EntityType.DEVIL_DOOR:
                            _eventQueue.AddEvent(_eventFactory.HitDoorEvent((Door)e, character));
                            if (CheckForEndGame())
                            {
                                _eventQueue.ClearQueue();
                                _eventQueue.AddEvent(_eventFactory.VictoryEvent());
                            }
                            break;
                        case EntityType.DIAMOND:
                            _eventQueue.AddEvent(_eventFactory.HitDiamondEvent((Diamond)e));
                            _score += ((Diamond)e).GetValue();
                            break;
                        case EntityType.RED_PUDDLE:
                        case EntityType.BLUE_PUDDLE:
                        case EntityType.PURPLE_PUDDLE:
                            _eventQueue.AddEvent(_eventFactory.HitPlatformEvent(e, character));
                            if (((Puddle)e).KillPlayer(character))
                            {
                                _eventQueue.AddEvent(_eventFactory.GameOverEvent());
                            }
                            break;
                        default:
                            throw new ArgumentException();
                    }
                });

            FreeObject(character);
        }

        /// <summary>
        /// Checks the collision of a character with the vertical borders.
        /// </summary>
        /// <param name="pos">The x coordinate of the character's position.</param>
        /// <param name="length">The length of the character.</param>
        /// <returns>true if the character is colliding with a vertical border.</returns>
        public bool CheckVerticalBorders(double pos, double length)
        {
            var sxBorder = _boundingBox.GetPosition().GetX();
            var dxBorder = _boundingBox.GetPosition().GetX() + _boundingBox.GetWidth();

            return pos <= sxBorder || pos + length >= dxBorder;
        }

        /// <summary>
        /// Checks the collision of a character with the horizontal borders.
        /// </summary>
        /// <param name="pos">The y-coordinate of the character's position.</param>
        /// <param name="height">The height of the character.</param>
        /// <returns>true if the character is colliding with a horizontal border.</returns>
        public bool CheckHorizontalBorders(double pos, double height)
        {
            var northBorder = _boundingBox.GetPosition().GetY();
            var southBorder = _boundingBox.GetPosition().GetY() + _boundingBox.GetHeight();

            return pos <= northBorder || pos + height >= southBorder;
        }

        /// <summary>
        /// Checks the collision of a character with the borders.
        /// </summary>
        /// <param name="character">The moving player.</param>
        private void CheckBorders(IPlayer character)
        {
            var chPos = character.GetPosition().Sum(character.GetVector());
            var chHeight = character.GetBoundingBox().GetHeight();
            var chLength = character.GetBoundingBox().GetWidth();

            if (CheckVerticalBorders(chPos.GetX(), chLength))
            {
                _eventQueue.AddEvent(_eventFactory.HitBorderYEvent(character));
            }
            if (CheckHorizontalBorders(chPos.GetY(), chHeight))
            {
                _eventQueue.AddEvent(_eventFactory.HitBorderXEvent(character));
            }
        }
    }

}