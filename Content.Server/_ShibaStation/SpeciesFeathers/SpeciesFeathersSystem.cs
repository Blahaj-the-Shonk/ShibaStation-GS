using Content.Shared.Weapons.Melee.Events;
using System.Numerics;
using Robust.Shared.Random;
using Content.Shared.Throwing;

namespace Content.Server._ShibaStation.SpeciesFeathers;

/// <summary>
/// This handles creating feathers when hit
/// </summary>
public sealed class SpeciesFeathersSystem : EntitySystem
{
    [Dependency] private readonly IRobustRandom _random = default!;
    [Dependency] private readonly ThrowingSystem _throwingSystem = default!;

    /// <inheritdoc/>
    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<SpeciesFeathersComponent, ComponentStartup>(OnStartupComponent); //for colours
        SubscribeLocalEvent<SpeciesFeathersComponent, AttackedEvent>(OnAttacked);

    }

    private void OnStartupComponent(EntityUid uid, SpeciesFeathersComponent component, ComponentStartup args)
    {
        //get the base colour of the species its applied too, guessing from one of the components
    }

    private void OnAttacked(EntityUid uid, SpeciesFeathersComponent component, AttackedEvent args)
    {
        ThrowObject(uid, component.FeatherId, component.FeatherVelocity, component.FeatherVelocityRange, component.NumFeathers);
    }

    private void ThrowObject(EntityUid uid, string prototypeid, float velocity, float velocityRange, int numFeathers)
    {
        for (int i = 0; i < numFeathers; i++)
        {
            var throwAngle = _random.NextFloat(-180f, 180f);
            var throwVector = new Vector2((float) Math.Sin(throwAngle), (float) Math.Cos(throwAngle));
            var throwRandom = _random.NextFloat(-velocityRange, velocityRange);
            var entity = SpawnNextToOrDrop(prototypeid, uid);
            _throwingSystem.TryThrow(entity, throwVector, velocity + throwRandom);
        }
    }
}
