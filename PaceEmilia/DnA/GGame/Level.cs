using System;
using System.Collections.Generic;
using System.IO;

namespace DNA.Model.Game.Level
{
    public class Level
    {
        private List<Entity> entities = new List<Entity>();
        private List<Player> characters = new List<Player>();
        private Stream nameFile;
        private EntityFactoryImpl entityFactoryImpl = new EntityFactoryImpl();

        public Level(int lvl)
        {
            NameFile(lvl);
        }

        public void EntitiesList()
        {
            using (StreamReader reader = new StreamReader(nameFile))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] splittedC = line.Split(' ');
                    switch (splittedC[0])
                    {
                        case "angel":
                            PlayerImpl angel = new PlayerImpl(
                                new Position2d(double.Parse(splittedC[1]), double.Parse(splittedC[2])),
                                new Vector2d(0, 0), EntityFactory.PLAYER_HEIGHT, EntityFactory.PLAYER_WIDTH,
                                PlayerImpl.PlayerType.Angel);
                            characters.Add(angel);
                            break;

                        case "devil":
                            PlayerImpl devil = new PlayerImpl(
                                new Position2d(double.Parse(splittedC[1]), double.Parse(splittedC[2])),
                                new Vector2d(0, 0), EntityFactory.PLAYER_HEIGHT, EntityFactory.PLAYER_WIDTH,
                                PlayerImpl.PlayerType.Devil);
                            characters.Add(devil);
                            break;

                        case "dDevil":
                            entities.Add(entityFactoryImpl.CreateEntity(null, EntityType.DevilDoor,
                                new Position2d(double.Parse(splittedC[1]), double.Parse(splittedC[2]))));
                            break;

                        case "dAngel":
                            entities.Add(entityFactoryImpl.CreateEntity(null, EntityType.AngelDoor,
                                new Position2d(double.Parse(splittedC[1]), double.Parse(splittedC[2]))));
                            break;

                        case "diamond":
                            entities.Add(entityFactoryImpl.CreateEntity(null, EntityType.Diamond,
                                new Position2d(double.Parse(splittedC[1]), double.Parse(splittedC[2]))));
                            break;

                        case "button":
                            entities.Add(entityFactoryImpl.CreateEntity((MovablePlatform)entities.FindLast(e => e.Type == EntityType.MovablePlatform),
                                EntityType.Button,
                                new Position2d(double.Parse(splittedC[1]), double.Parse(splittedC[2]))));
                            break;

                        case "lever":
                            entities.Add(entityFactoryImpl.CreateEntity((MovablePlatform)entities.FindLast(e => e.Type == EntityType.MovablePlatform),
                                EntityType.Lever,
                                new Position2d(double.Parse(splittedC[1]), double.Parse(splittedC[2]))));
                            break;

                        case "platform":
                            entities.Add(entityFactoryImpl.CreateEntity(null, EntityType.Platform,
                                new Position2d(double.Parse(splittedC[1]), double.Parse(splittedC[2]))));
                            break;

                        case "movablePlatform":
                            entities.Add(entityFactoryImpl.CreateEntity(null, EntityType.MovablePlatform,
                                new Position2d(double.Parse(splittedC[1]), double.Parse(splittedC[2])),
                                new Position2d(double.Parse(splittedC[3]), double.Parse(splittedC[4]))));
                            break;

                        case "rPuddle":
                            entities.Add(entityFactoryImpl.CreateEntity(null, EntityType.RedPuddle,
                                new Position2d(double.Parse(splittedC[1]), double.Parse(splittedC[2]))));
                            break;

                        case "bPuddle":
                            entities.Add(entityFactoryImpl.CreateEntity(null, EntityType.BluePuddle,
                                new Position2d(double.Parse(splittedC[1]), double.Parse(splittedC[2]))));
                            break;

                        case "pPuddle":
                            entities.Add(entityFactoryImpl.CreateEntity(null, EntityType.PurplePuddle,
                                new Position2d(double.Parse(splittedC[1]), double.Parse(splittedC[2]))));
                            break;

                        default:
                            break;
                    }
                }
            }
        }

        public List<Entity> GetEntities()
        {
            return new List<Entity>(entities);
        }

        public List<Player> GetCharacters()
        {
            return new List<Player>(characters);
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
