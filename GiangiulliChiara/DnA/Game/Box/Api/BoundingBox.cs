using DnA.Game.Common;

namespace DnA.Game.Box.Api{
    /// <summary>
    /// Interface for the boundaries of an <see cref="Entity"/>.
    /// </summary>
    public interface IBoundingBox 
    {   
    /// <summary>
    /// Checks if the <see cref="Entity"/> modeled by this box is colliding with another <see cref="Entity"/>.
    /// </summary>
    /// <param name="p">The position of the other <see cref="Entity"/>.</param>
    /// <param name="height">The height of the other <see cref="Entity"/>.</param>
    /// <param name="width">The width of the other <see cref="Entity"/>.</param>
    /// <returns>true if the entities are colliding</returns>
    bool IsCollidingWith(Position2d p, double height, double width);

    /// <summary>
    /// Checks if the collision between the two entities is on the left or the right side.
    /// </summary>
    /// <param name="p">The position of the other <see cref="Entity"/>.</param>
    /// <param name="height">The height of the other <see cref="Entity"/>.</param>
    /// <param name="width">The width of the other <see cref="Entity"/>.</param>
    /// <returns>true if the collision is on the left or the right side</returns>
    bool SideCollision(Position2d p, double height, double width);

    
    /// <summary>
    /// Gets the position of the box.
    /// </summary>
    /// <returns>The position (upper-left corner) of the box.</returns>
    Position2d GetPosition();

    /// <summary>
    /// Sets the position of the box.
    /// </summary>
    /// <param name="pos">The position to set.</param>
    void SetPosition(Position2d pos);

   /// <summary>
    /// Gets the height of the box.
    /// </summary>
    /// <returns>The height of the box.</returns>
    double GetHeight();

    /// <summary>
    /// Gets the width of the box.
    /// </summary>
    /// <returns>The width of the box.</returns>
    double GetWidth();
    }
}

