using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Flamingo
{
public class BattleController : MonoBehaviour
{
    [SerializeField] private NFTCreature _creature1;     /// <summary>Creature 1.</summary>
    [SerializeField] private NFTCreature _creature2;     /// <summary>Creature 2.</summary>
    [SerializeField] private BattleUI _battleUI;         /// <summary>Battle's UI.</summary>

    /// <summary>Gets and Sets creature1 property.</summary>
    public NFTCreature creature1
    {
        get { return _creature1; }
        set { _creature1 = value; }
    }

    /// <summary>Gets and Sets creature2 property.</summary>
    public NFTCreature creature2
    {
        get { return _creature2; }
        set { _creature2 = value; }
    }

    /// <summary>Gets and Sets battleUI property.</summary>
    public BattleUI battleUI
    {
        get { return _battleUI; }
        set { _battleUI = value; }
    }

    /// <summary>BattleController's instance initialization when loaded [Before scene loads].</summary>
    private void Awake()
    {
        battleUI.AssignCreature(creature1);
        battleUI.NFTCreature1UI.AssignCreature(creature1);
        battleUI.NFTCreature2UI.AssignCreature(creature2);
    }
}
}