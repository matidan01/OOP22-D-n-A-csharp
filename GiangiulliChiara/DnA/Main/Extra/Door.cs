namespace DnA.Main.Extra
{
    public class Door : Entity
    {
        public enum DoorState
        {
            OpenDoor,
            ClosedDoor
        }

        internal void CloseDoor()
        {
            throw new NotImplementedException();
        }

        internal DoorState GetDoorState()
        {
            throw new NotImplementedException();
        }

        internal Player? GetPlayer()
        {
            throw new NotImplementedException();
        }

        internal void OpenDoor(Player player)
        {
            throw new NotImplementedException();
        }

        internal void ResetPlayer()
        {
            throw new NotImplementedException();
        }
    }
}