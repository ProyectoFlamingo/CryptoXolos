using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Flamingo
{
public delegate void OnNFTCreatureEvent(NFTCreature _creature, int _ID);

public class NFTCreature : Character
{
    public event OnNFTCreatureEvent onNFTCreatureEvent;

    [SerializeField] private int _level;
    [SerializeField] private Types _typeA;
    [SerializeField] private Types _typeB;
    [SerializeField] private int _baseHP;
    [SerializeField] private int _baseAttack;
    [SerializeField] private int _baseDefense;
    [SerializeField] private int _baseSpecialAttack;
    [SerializeField] private int _baseSpecialDefense;
    [SerializeField] private int _baseSpeed;
    [Space(5f)]
    [Header("Moveset:")]
    [SerializeField] private Move _move1;     /// <summary>Move 1.</summary>
    [SerializeField] private Move _move2;     /// <summary>Move 2.</summary>
    [SerializeField] private Move _move3;     /// <summary>Move 3.</summary>
    [SerializeField] private Move _move4;     /// <summary>Move 4.</summary>
    private float _HP;
    private float _attack;
    private float _defense;
    private float _specialAttack;
    private float _specialDefense;
    private float _speed;
    private float _currentHP;

#region Getters/Setters
    /// <summary>Gets and Sets level property.</summary>
    public int level
    {
        get { return _level; }
        set { _level = value; }
    }

    /// <summary>Gets and Sets typeA property.</summary>
    public Types typeA
    {
        get { return _typeA; }
        set { _typeA = value; }
    }

    /// <summary>Gets and Sets typeB property.</summary>
    public Types typeB
    {
        get { return _typeB; }
        set { _typeB = value; }
    }

    /// <summary>Gets and Sets baseHP property.</summary>
    public int baseHP
    {
        get { return _baseHP; }
        set { _baseHP = value; }
    }

    /// <summary>Gets and Sets baseAttack property.</summary>
    public int baseAttack
    {
        get { return _baseAttack; }
        set { _baseAttack = value; }
    }

    /// <summary>Gets and Sets baseDefense property.</summary>
    public int baseDefense
    {
        get { return _baseDefense; }
        set { _baseDefense = value; }
    }

    /// <summary>Gets and Sets baseSpecialAttack property.</summary>
    public int baseSpecialAttack
    {
        get { return _baseSpecialAttack; }
        set { _baseSpecialAttack = value; }
    }

    /// <summary>Gets and Sets baseSpecialDefense property.</summary>
    public int baseSpecialDefense
    {
        get { return _baseSpecialDefense; }
        set { _baseSpecialDefense = value; }
    }

    /// <summary>Gets and Sets baseSpeed property.</summary>
    public int baseSpeed
    {
        get { return _baseSpeed; }
        set { _baseSpeed = value; }
    }

    /// <summary>Gets and Sets HP property.</summary>
    public float HP
    {
        get { return _HP; }
        set { _HP = value; }
    }

    /// <summary>Gets and Sets attack property.</summary>
    public float attack
    {
        get { return _attack; }
        set { _attack = value; }
    }

    /// <summary>Gets and Sets defense property.</summary>
    public float defense
    {
        get { return _defense; }
        set { _defense = value; }
    }

    /// <summary>Gets and Sets specialAttack property.</summary>
    public float specialAttack
    {
        get { return _specialAttack; }
        set { _specialAttack = value; }
    }

    /// <summary>Gets and Sets specialDefense property.</summary>
    public float specialDefense
    {
        get { return _specialDefense; }
        set { _specialDefense = value; }
    }

    /// <summary>Gets and Sets speed property.</summary>
    public float speed
    {
        get { return _speed; }
        set { _speed = value; }
    }

    /// <summary>Gets and Sets currentHP property.</summary>
    public float currentHP
    {
        get { return _currentHP; }
        set { _currentHP = value; }
    }

    /// <summary>Gets and Sets move1 property.</summary>
    public Move move1
    {
        get { return _move1; }
        set { _move1 = value; }
    }

    /// <summary>Gets and Sets move2 property.</summary>
    public Move move2
    {
        get { return _move2; }
        set { _move2 = value; }
    }

    /// <summary>Gets and Sets move3 property.</summary>
    public Move move3
    {
        get { return _move3; }
        set { _move3 = value; }
    }

    /// <summary>Gets and Sets move4 property.</summary>
    public Move move4
    {
        get { return _move4; }
        set { _move4 = value; }
    }

    /// <summary>Gets HPRatio property.</summary>
    public float HPRatio { get { return currentHP / HP; } }
#endregion

    /// <summary>NFTCreature's instance initialization when loaded [Before scene loads].</summary>
    private void Awake()
    {
        currentHP = baseHP;
        HP = baseHP;
    }

    public void ApplyDamage(float _damage)
    {
        currentHP = Mathf.Max(currentHP - _damage, 0.0f);
        InvokeIDEvent(0);
    }

    public void InvokeIDEvent(int _ID)
    {
        if(onNFTCreatureEvent != null) onNFTCreatureEvent(this, _ID);
    }
}
}