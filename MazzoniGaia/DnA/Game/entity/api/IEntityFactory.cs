

using DnA.Game.enitity.MovableEntity.impl;

namespace DnA.Game.enitity.Api{
    /// <summary>
    ///  A factory with the purpose of being able to create various types of entities.
    /// </summary>
    public interface IEntityFactory {

        /// <summary>
        /// A constant for the height of some entities.
        /// </summary>
        const int DEF_HEIGHT = 4;
        /// <summary>
        /// A constant for the width of some entities.
        /// </summary>
        const int DEF_WIDTH = 4;
        /// <summary>
        /// A constant for the width of the diamond.
        /// </summary>
        const int DIAMOND_WIDTH = 6;
        /// <summary>
        /// A constant for the height of the diamond.
        /// </summary>
        const int DIAMOND_HEIGHT = 6;
        /// <summary>
        /// A constant for the height of the button.
        /// </summary>
        const int BUTTON_HEIGHT = 2;
        /// <summary>
        /// A constant for the height of the lever.
        /// </summary>
        const int LEVER_HEIGHT = 5;
        /// <summary>
        /// A constant for the height of the puddle.
        /// </summary>
        const int PUDDLE_HEIGHT = 3;
        /// <summary>
        /// A constant for the width of the puddle.
        /// </summary>
        const int PUDDLE_WIDTH = 10;
        /// <summary>
        /// A constant for the height of the door.
        /// </summary>
        const int DOOR_HEIGHT = 15;
        /// <summary>
        /// A constant for the width of the door.
        /// </summary>
        const int DOOR_WIDTH = 10;
        /// <summary>
        /// A constant for the width of the platforms.
        /// </summary>
        const int PLATFORM_WIDTH = 40;
        /// <summary>
        /// A constant for the height of the player.
        /// </summary>
        const int PLAYER_HEIGHT = 7;
        /// <summary>
        /// A constant for the width of the player.
        /// </summary>
        const int PLAYER_WIDTH = 6;
    
        /// <summary>
        /// A method that creates an Entity of a wanted type.
        /// </summary>
        /// <param name="movablePlatform"> the optional MovablePlatform that the Entity can control. 
        /// It shoudl be present if a BUTTON or a LEVER is being created</param>
        /// <param name="type"> the type of the Entity</param>
        /// <param name="position"> the type </param>
        /// If two positions are passed as parameters, the first is the originalPosition, and the second is the FinalPosition.
        /// Two positions should be passed if the Entity being created is of the type MOVABLEPLATFORM
        /// <returns> the Entity created </returns>
        /// </summary>
    IEntity CreateEntity(MovablePlatform? movablePlatform, IEntity.EntityType type, params Position2d[] position); 

    }
}
