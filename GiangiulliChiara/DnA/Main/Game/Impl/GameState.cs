using DnA.Main.Game.Api;
using DnA.Main.Extra;
using DnA.Main.Box.Api;
using DnA.Main.Box.Impl;
using DnA.Main.Events.Impl;
using DnA.Main.Events.Api;
using DnA.Main.Common;
using static DnA.Main.Extra.Entity;
using OOP22_D_n_A_csharp.MazzoniGaia.DnA.ObjMain.StillEntity.Impl;
using OOP22_D_n_A_csharp.MazzoniGaia.DnA.GMain.ObjMain.MovableEntity.Impl;
using OOP22_D_n_A_csharp.MazzoniGaia.DnA.GMain.ObjMain.StillEntity.Impl;

namespace DnA.Main.Game.Impl
{
    /// <summary>
    /// Represents the state of the game.
    /// </summary>
    public class GameStateImpl : IGameState
    {
        /// <summary>
        /// The constant value of the game's gravity.
        /// </summary>
        public const double GRAVITY = 0.8;

        private List<Entity> entities;
        private List<Player> characters;
        private IBoundingBox boundingBox;
        private IEventFactory eventFactory = new EventFactoryImpl();
        private EventQueue eventQueue = new EventQueue();
        private double score;

        /// <summary>
        /// <see cref="GameStateImpl"/> constructor.
        /// </summary>
        /// <param name="width">The width of the game.</param>
        /// <param name="height">The height of the game.</param>
        /// <param name="entities">The entities of the game.</param>
        /// <param name="players">The players of the game.</param>
        public GameStateImpl(int width, int height, List<Entity> entities, List<Player> players)
        {
            this.boundingBox = new RectBoundingBox(new Position2d(0, 0), height, width);
            this.entities = new List<Entity>(entities);
            this.characters = new List<Player>(players);
            this.score = 0;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void Update()
        {
            characters.ForEach(c =>
            {
                Gravity(c);
                CheckCollisions(c);
                CheckBorders(c);
            });

            eventQueue.ManageEvents(this);

            characters.ForEach(c => c.Update());

            entities
                .OfType<MovablePlatform>()
                .ToList()
                .ForEach(entity => entity.MovablePlatformUpdate());
        }

        /// <summary>
        /// Manages the gravity of the player.
        /// </summary>
        /// <param name="player">The player to manage.</param>
        private void Gravity(Player player)
        {
            if (player.GetVector().GetY() < GRAVITY)
            {
                player.GetVector().SumY(Player.STANDARDVELOCITY);
            }
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns><inheritdoc/></returns>
        public IBoundingBox GetBoundingBox()
        {
            return new RectBoundingBox(boundingBox.GetPosition(), boundingBox.GetHeight(), boundingBox.GetWidth());
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns><inheritdoc/></returns>
        public void AddEntity(Entity e)
        {
            entities.Add(e);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns><inheritdoc/></returns>
        public void RemoveEntity(Entity e)
        {
            entities.Remove(e);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns><inheritdoc/></returns>
        public List<Entity> GetEntities()
        {
            return new List<Entity>(entities);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns><inheritdoc/></returns>
        public List<Player> GetCharacters()
        {
            return new List<Player>(characters);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns><inheritdoc/></returns>
        public double GetScore()
        {
            return score;
        }

        /// <summary>
        /// Manages when a character leaves an activable object or a door.
        /// </summary>
        /// <param name="character">The player to check.</param>
        private void FreeObject(Player character)
        {
            var box = character.GetBoundingBox();
            entities
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
            return entities
                .OfType<Door>()
                .Where(entity => entity.GetDoorState() == Door.DoorState.OpenDoor)
                .Count() == 2;
        }

        /// <summary>
        /// Checks the collision of a character with the entities in the game.
        /// </summary>
        /// <param name="character">The moving player.</param>
        private void CheckCollisions(Player character)
        {
            var chPos = character.GetPosition().Sum(character.GetVector());
            var chHeight = character.GetBoundingBox().GetHeight();
            var chWidth = character.GetBoundingBox().GetWidth();

            entities
                .Where(e => e.GetBoundingBox().IsCollidingWith(chPos, chHeight, chWidth))
                .ToList()
                .ForEach(e =>
                {
                    switch (e.Type())
                    {
                        case EntityType.PLATFORM:
                            eventQueue.AddEvent(eventFactory.HitPlatformEvent(e, character));
                            break;
                        case EntityType.MOVABLEPLATFORM:
                            eventQueue.AddEvent(eventFactory.HitPlatformEvent(e, character));
                            eventQueue.AddEvent(eventFactory.HitMovablePlatformEvent((MovablePlatform)e, character));
                            break;
                        case EntityType.BUTTON:
                            eventQueue.AddEvent(eventFactory.HitButtonEvent((ActivableObjectImpl)e, character));
                            break;
                        case EntityType.LEVER:
                            eventQueue.AddEvent(eventFactory.HitLeverEvent((ActivableObjectImpl)e, character));
                            break;
                        case EntityType.ANGEL_DOOR:
                        case EntityType.DEVIL_DOOR:
                            eventQueue.AddEvent(eventFactory.HitDoorEvent((Door)e, character));
                            if (CheckForEndGame())
                            {
                                eventQueue.ClearQueue();
                                eventQueue.AddEvent(eventFactory.VictoryEvent());
                            }
                            break;
                        case EntityType.DIAMOND:
                            eventQueue.AddEvent(eventFactory.HitDiamondEvent((Diamond)e));
                            score += ((Diamond)e).GetValue();
                            break;
                        case EntityType.RED_PUDDLE:
                        case EntityType.BLUE_PUDDLE:
                        case EntityType.PURPLE_PUDDLE:
                            eventQueue.AddEvent(eventFactory.HitPlatformEvent(e, character));
                            if (((Puddle)e).KillPlayer(character))
                            {
                                eventQueue.AddEvent(eventFactory.GameOverEvent());
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
            var sxBorder = boundingBox.GetPosition().GetX();
            var dxBorder = boundingBox.GetPosition().GetX() + boundingBox.GetWidth();

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
            var northBorder = boundingBox.GetPosition().GetY();
            var southBorder = boundingBox.GetPosition().GetY() + boundingBox.GetHeight();

            return pos <= northBorder || pos + height >= southBorder;
        }

        /// <summary>
        /// Checks the collision of a character with the borders.
        /// </summary>
        /// <param name="character">The moving player.</param>
        private void CheckBorders(Player character)
        {
            var chPos = character.GetPosition().Sum(character.GetVector());
            var chHeight = character.GetBoundingBox().GetHeight();
            var chLength = character.GetBoundingBox().GetWidth();

            if (CheckVerticalBorders(chPos.GetX(), chLength))
            {
                eventQueue.AddEvent(eventFactory.HitBorderYEvent(character));
            }
            if (CheckHorizontalBorders(chPos.GetY(), chHeight))
            {
                eventQueue.AddEvent(eventFactory.HitBorderXEvent(character));
            }
        }
    }

}