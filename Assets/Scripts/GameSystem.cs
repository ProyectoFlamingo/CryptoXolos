using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using Random = UnityEngine.Random;

namespace Flamingo
{
[Flags]
public enum Types
{
    None = 0,
    _1 = 1 << 0,
    _2 = 1 << 1,
    _3 = 1 << 2,
    _4 = 1 << 3,
    _5 = 1 << 4,
    _6 = 1 << 5,
    _7 = 1 << 6,
    _8 = 1 << 7,
    _9 = 1 << 8,
    _10 = 1 << 9,
}

public enum MoveType
{
    Status,
    Attack
}

public enum AttackType
{
    Physical,
    Special
}

public enum Gender
{
    Male,
    Female
}

public static class GameSystem
{
    public static readonly Dictionary<Types, Types> weaknessChart;      /// <summary>Types' Weakness' Chart.</summary>
    public static readonly Dictionary<Types, Types> resistanceChart;    /// <summary>Types' Resistances' Chart.</summary>
    public static readonly Dictionary<Types, Types> immunityChart;      /// <summary>Types' Immunities' Chart.</summary>
    public static float[,] typesChart;

    /// <summary>Static's Constructor.</summary>
    static GameSystem()
    {
        weaknessChart = new Dictionary<Types, Types>()
        {
            { Types._1, Types._2 },
            { Types._2, Types._3 },
            { Types._3, Types._1 },
            { Types._4, Types.None },
            { Types._5, Types.None },
            { Types._6, Types.None },
            { Types._7, Types.None },
            { Types._8, Types.None },
            { Types._9, Types.None },
            { Types._10, Types.None }
        };

        resistanceChart = new Dictionary<Types, Types>()
        {
            { Types._1, Types._1 | Types._3 },
            { Types._2, Types._1 | Types._2 },
            { Types._3, Types._2 | Types._3 },
            { Types._4, Types.None },
            { Types._5, Types.None },
            { Types._6, Types.None },
            { Types._7, Types.None },
            { Types._8, Types.None },
            { Types._9, Types.None },
            { Types._10, Types.None }
        };

        immunityChart = new Dictionary<Types, Types>()
        {
            { Types._1, Types.None },
            { Types._2, Types.None },
            { Types._3, Types.None },
            { Types._4, Types.None },
            { Types._5, Types.None },
            { Types._6, Types.None },
            { Types._7, Types.None },
            { Types._8, Types.None },
            { Types._9, Types.None },
            { Types._10, Types.None }
        };
    }

    public static float CalculateDamage(NFTCreature _creature, AttackMove _attack, params NFTCreature[] _creatures)
    {
        NFTCreature creature = _creatures[0];
        AttackType attackType = _attack.attackType;
        Types attackElementType = _attack.type;
        float level = (float)_creature.level;
        float a = attackType == AttackType.Physical ? _creature.attack : _creature.specialAttack;
        float d = attackType == AttackType.Physical ? creature.defense : creature.specialDefense;
        float e = GetDamageMultiplier(creature.typeA, creature.typeB, attackElementType);
        float STAB = CalculateSTAB(_creature.typeA, attackElementType) * CalculateSTAB(_creature.typeB, attackElementType);
        float r = Random.Range(0.85f, 1.0f);

        return ((((2.0f * level) + 2.0f) * _attack.damage * (a / d)) / 50.0f) * STAB * r * e;
    }

    public static float CalculateSTAB(Types _types, Types _attackType)
    {
        return ((_types | _attackType) == _types) ? 1.5f : 1.0f;
    }

    /// <summary>Gets Damage Multiplier from Creature's Types and Attack's Type.</summary>
    public static float GetDamageMultiplier(Types a, Types b, Types _attackTypes)
    {
        return GetDamageMultiplier(a, _attackTypes) * GetDamageMultiplier(b, _attackTypes);
    }

    /// <summary>Gets Damage Multiplier from Creature's Types and Attack's Type.</summary>
    public static float GetDamageMultiplier(Types _type, Types _attackTypes)
    {
        if(_type == Types.None) return 1.0f;

        Types typeWeaknesses = weaknessChart[_type];
        Types typeResistances = resistanceChart[_type];
        Types typeImmunities = immunityChart[_type];

        if((typeWeaknesses | _attackTypes) == typeWeaknesses) return 2.0f;
        if((typeResistances | _attackTypes) == typeResistances) return 0.5f;
        if((typeImmunities | _attackTypes) == typeImmunities) return 0.0f;
        else return 1.0f;
    }
}
}