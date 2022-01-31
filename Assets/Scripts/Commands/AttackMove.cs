using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Flamingo
{
[CreateAssetMenu]
public class AttackMove : Move
{
    [Space(5f)]
    [Header("Attack's Attributes:")]
    [SerializeField] private AttackType _attackType;     /// <summary>Attack's Type.</summary>
    [SerializeField] private Types _type;                /// <summary>Attack'sElement Type.</summary>
    [SerializeField] private float _damage;              /// <summary>Damage.</summary>

    /// <summary>Gets attackType property.</summary>
    public AttackType attackType { get { return _attackType; } }

    /// <summary>Gets type property.</summary>
    public Types type { get { return _type; } }

    /// <summary>Gets damage property.</summary>
    public float damage { get { return _damage; } }

    /// <summary>Performs Move.</summary>
    /// <param name="_creature">NFTCreature that will perform the Move.</param>
    /// <param name="_creatures">Targets'.</param>
    public override void Perform(NFTCreature _creature, params NFTCreature[] _creatures)
    {
        float damage = GameSystem.CalculateDamage(_creature, this, _creatures);

        Debug.Log("[AttackMove] Performing Attack With " + damage + " Damage.");
        _creatures[0].ApplyDamage(damage);
    }

    /// <returns>Move's Type.</returns>
    public override MoveType GetMoveType() { return MoveType.Attack; }
}
}