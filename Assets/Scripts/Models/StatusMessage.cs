using UnityEngine.Networking;

namespace Models
{
    public class StatusMessage : MessageBase
    {
        public StatusMsg Status;
    }

    public enum StatusMsg
    {
        Sending,
        Deleting,
        Printing,
        Editing
    }
}