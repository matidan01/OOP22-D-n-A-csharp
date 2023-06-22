

using DnA.Game.Player.api;
using DnA.Game.Player.impl;
using DnA.GMain.ObjMain.Entity.Api;
using DnA.GMain.ObjMain.MovableEntity.Impl;
using DnA.Main.Common;
using DnA.ObjMain.Entity.Impl;
using static DnA.GMain.ObjMain.Entity.Api.IEntity;

namespace DNA.Model.Game.Level
{
    public class Level
    {
        private List<IEntity> entities = new();
        private List<Player> characters = new();
        private Stream ? nameFile;
        private IEntityFactory entityFactory = new EntityFactoryImpl();

        public Level(int lvl)
        {
            NameFile(lvl);
        }

        public void EntitiesList()
        {
            using StreamReader reader = new(nameFile);
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] splittedC = line.Split(' ');
                switch (splittedC[0])
                {
                    case "angel":
                        Player angel = new(
                            new Position2d(double.Parse(splittedC[1]), double.Parse(splittedC[2])),
                            new Vector2d(0, 0), IEntityFactory.PLAYER_HEIGHT, IEntityFactory.PLAYER_WIDTH,
                            IPlayer.PlayerType.ANGEL);
                        characters.Add(angel);
                        break;

                    case "devil":
                        Player devil = new(
                            new Position2d(double.Parse(splittedC[1]), double.Parse(splittedC[2])),
                            new Vector2d(0, 0), IEntityFactory.PLAYER_HEIGHT, IEntityFactory.PLAYER_WIDTH,
                            IPlayer.PlayerType.DEVIL);
                        characters.Add(devil);
                        break;

                    case "dDevil":
                        entities.Add(entityFactory.CreateEntity(null, EntityType.DEVIL_DOOR,
                            new Position2d(double.Parse(splittedC[1]), double.Parse(splittedC[2]))));
                        break;

                    case "dAngel":
                        entities.Add(entityFactory.CreateEntity(null, EntityType.ANGEL_DOOR,
                            new Position2d(double.Parse(splittedC[1]), double.Parse(splittedC[2]))));
                        break;

                    case "diamond":
                        entities.Add(entityFactory.CreateEntity(null, EntityType.DIAMOND,
                            new Position2d(double.Parse(splittedC[1]), double.Parse(splittedC[2]))));
                        break;

                    case "button":
                        entities.Add(entityFactory.CreateEntity((MovablePlatform ?)entities.FindLast(e => e.GetType() == EntityType.MOVABLEPLATFORM),
                            EntityType.BUTTON,
                            new Position2d(double.Parse(splittedC[1]), double.Parse(splittedC[2]))));
                        break;

                    case "lever":
                        entities.Add(entityFactory.CreateEntity((MovablePlatform ?)entities.FindLast(e => e.GetType() == EntityType.MOVABLEPLATFORM),
                            EntityType.LEVER,
                            new Position2d(double.Parse(splittedC[1]), double.Parse(splittedC[2]))));
                        break;

                    case "platform":
                        entities.Add(entityFactory.CreateEntity(null, EntityType.PLATFORM,
                            new Position2d(double.Parse(splittedC[1]), double.Parse(splittedC[2]))));
                        break;

                    case "movablePlatform":
                        entities.Add(entityFactory.CreateEntity(null, EntityType.MOVABLEPLATFORM,
                            new Position2d(double.Parse(splittedC[1]), double.Parse(splittedC[2])),
                            new Position2d(double.Parse(splittedC[3]), double.Parse(splittedC[4]))));
                        break;

                    case "rPuddle":
                        entities.Add(entityFactory.CreateEntity(null, EntityType.RED_PUDDLE,
                            new Position2d(double.Parse(splittedC[1]), double.Parse(splittedC[2]))));
                        break;

                    case "bPuddle":
                        entities.Add(entityFactory.CreateEntity(null, EntityType.BLUE_PUDDLE,
                            new Position2d(double.Parse(splittedC[1]), double.Parse(splittedC[2]))));
                        break;

                    case "pPuddle":
                        entities.Add(entityFactory.CreateEntity(null, EntityType.PURPLE_PUDDLE,
                            new Position2d(double.Parse(splittedC[1]), double.Parse(splittedC[2]))));
                        break;

                    default:
                        break;
                }
            }
        }

        public List<IEntity> GetEntities()
        {
            return new List<IEntity>(entities);
        }

        public List<IPlayer> GetCharacters()
        {
            return new List<IPlayer>(characters);
        }

        private void NameFile(int lvl)
        {
            switch (lvl)
            {
                case 1:
                    nameFile = typeof(Level).Assembly.GetManifestResourceStream("DNA.Levels.lvl1.txt");
                    break;
                case 2:
                    nameFile = typeof(Level).Assembly.GetManifestResourceStream("DNA.Levels.lvl2.txt");
                    break;
                case 3:
                    nameFile = typeof(Level).Assembly.GetManifestResourceStream("DNA.Levels.lvl3.txt");
                    break;
                default:
                    break;
            }
        }
    }
}
