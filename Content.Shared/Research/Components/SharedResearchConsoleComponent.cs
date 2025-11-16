using Robust.Shared.Serialization;
using Content.Shared._ClawCommand.Research;

namespace Content.Shared.Research.Components
{
    [NetSerializable, Serializable]
    public enum ResearchConsoleUiKey : byte
    {
        Key,
    }

    [Serializable, NetSerializable]
    public sealed class ConsoleUnlockTechnologyMessage : BoundUserInterfaceMessage
    {
        public string Id;

        public ConsoleUnlockTechnologyMessage(string id)
        {
            Id = id;
        }
    }

    [Serializable, NetSerializable]
    public sealed class ConsoleServerSelectionMessage : BoundUserInterfaceMessage
    {

    }

    [Serializable, NetSerializable]
    public sealed class ResearchConsoleBoundInterfaceState : BoundUserInterfaceState
    {
        public int Points;
        public float SoftCapMultiplier;
        /// <summary>
        /// Goobstation field - all researches and their availablities
        /// </summary>
        public Dictionary<string, ResearchAvailability> Researches;
        public ResearchConsoleBoundInterfaceState(int points, float softCapMultiplier, Dictionary<string, ResearchAvailability> researches)   // Goobstation R&D console rework = researches field
        {
            Points = points;
            SoftCapMultiplier = softCapMultiplier;
            Researches = researches;    // Goobstation R&D console rework
        }
    }
}
