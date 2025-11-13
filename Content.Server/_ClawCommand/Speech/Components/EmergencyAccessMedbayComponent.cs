using Content.Server._ClawCommand.Station.Systems;
using Content.Server.Station.Systems;
using Content.Shared.Access;
using Robust.Shared.Prototypes;

namespace Content.Server._ClawCommand.Station.Components;

/// <summary>
/// Used for a few automated systems more than just emergency accessing the medbay.
/// </summary>
[RegisterComponent, Access(typeof(EmergencyAccessMedbayStateSystem), typeof(CodeBlueSecretStateSystem), typeof(StationSystem))]

public sealed partial class EmergencyAccessMedbayStateComponent : Component
{
    [DataField]
    public int DoctorCount = 0;

    [DataField]
    public LocId RevokeACOMessage = "doctors-arrived-revoke-aco-announcement";

    [DataField]
    public bool IsAAInPlay = false;

    [DataField]
    public bool IsAutoCodeBlueInPlay = false;

    [DataField]
    public LocId AAUnlockedMessage = "no-doctors-aa-unlocked-announcement";

}
