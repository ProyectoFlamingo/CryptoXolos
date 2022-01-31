using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Flamingo
{
[CreateAssetMenu]
public abstract class Move : ScriptableObject
{
    [SerializeField] private string _name;                          /// <summary>Move's Name.</summary>
    [SerializeField] private string _description;                   /// <summary>Move's Description.</summary>
    [SerializeField][Range(0.0f, 1.0f)] private float _accuracy;    /// <summary>Move's Accuracy.</summary>
    [SerializeField] private int _maxPP;                            /// <summary>Maximum's PP.</summary>
    [SerializeField] private int _PPLimit;                          /// <summary>PP's Limit.</summary>
    private int _currentPP;                                         /// <summary>Current's PP.</summary>

    /// <summary>Gets name property.</summary>
    public string name { get { return _name; } }

    /// <summary>Gets description property.</summary>
    public string description { get { return _description; } }

    /// <summary>Gets and Sets currentPP property.</summary>
    public int currentPP
    {
        get { return _currentPP; }
        set { _currentPP = value; }
    }

    /// <summary>Gets and Sets maxPP property.</summary>
    public int maxPP
    {
        get { return _maxPP; }
        set { _maxPP = value; }
    }

    /// <summary>Gets and Sets PPLimit property.</summary>
    public int PPLimit
    {
        get { return _PPLimit; }
        set { _PPLimit = value; }
    }

    /// <summary>Gets and Sets accuracy property.</summary>
    public float accuracy
    {
        get { return _accuracy; }
        set { _accuracy = value; }
    }

    /// <summary>Performs Move.</summary>
    /// <param name="_creature">NFTCreature that will perform the Move.</param>
    /// <param name="_creatures">Targets'.</param>
    public abstract void Perform(NFTCreature _creature, params NFTCreature[] _creatures);

    /// <returns>Move's Type.</returns>
    public abstract MoveType GetMoveType();
}
}