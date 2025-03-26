namespace Content.Server._ShibaStation.SpeciesFeathers;

/// <summary>
/// This is used for...
/// </summary>
[RegisterComponent]
public sealed partial class SpeciesFeathersComponent : Component
{
    [ViewVariables(VVAccess.ReadOnly), DataField]
    public Color FeatherColor = Color.FromHex("#00000000");
    //to be set to the entities base colour

    [ViewVariables(VVAccess.ReadOnly), DataField]
    public string FeatherId = "BikeHorn";

    [ViewVariables(VVAccess.ReadOnly), DataField]
    public float FeatherVelocity = 7f;

    [ViewVariables(VVAccess.ReadOnly), DataField]
    public float FeatherVelocityRange = 7f;

    [ViewVariables(VVAccess.ReadOnly), DataField]
    public int NumFeathers = 5;
}
