using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Flamingo
{
public class NFTCreatureUI : MonoBehaviour
{
    [Header("Text:")]
    [SerializeField] private Text _creatureNameText;            /// <summary>Creature Name's Text.</summary>
    [SerializeField] private Text _creatureLevelText;           /// <summary>Creature Level's Text.</summary>
    [SerializeField] private Text _creatureCurrentHPText;       /// <summary>Creature's Current HP's Text.</summary>
    [SerializeField] private Text _creatureMaxHPText;           /// <summary>Creature's Max HP's Text.</summary>
    [Space(5f)]
    [Header("HP Bar's Attributes:")]
    [SerializeField] private RectTransform _HPBar;              /// <summary>HP's Bar.</summary>
    [SerializeField] private float _HPBarAnimationDuration;     /// <summary>HP Bar's Animation Duration.</summary>
    private NFTCreature _creature;                              /// <summary>Creature's Reference.</summary>

    /// <summary>Gets creatureNameText property.</summary>
    public Text creatureNameText { get { return _creatureNameText; } }

    /// <summary>Gets creatureLevelText property.</summary>
    public Text creatureLevelText { get { return _creatureLevelText; } }

    /// <summary>Gets creatureCurrentHPText property.</summary>
    public Text creatureCurrentHPText { get { return _creatureCurrentHPText; } }

    /// <summary>Gets creatureMaxHPText property.</summary>
    public Text creatureMaxHPText { get { return _creatureMaxHPText; } }

    /// <summary>Gets HPBar property.</summary>
    public RectTransform HPBar { get { return _HPBar; } }

    /// <summary>Gets HPBarAnimationDuration property.</summary>
    public float HPBarAnimationDuration { get { return _HPBarAnimationDuration; } }

    /// <summary>Gets and Sets creature property.</summary>
    public NFTCreature creature
    {
        get { return _creature; }
        private set { _creature = value; }
    }

    /// <summary>NFTCreatureUI's instance initialization when loaded [Before scene loads].</summary>
    private void Awake()
    {
        
    }

    public void AssignCreature(NFTCreature _creature)
    {
        if(creature != null)
        {
            creature.onNFTCreatureEvent -= OnNFTCreatureEvent;
        }
        creature = _creature;

        creature.onNFTCreatureEvent += OnNFTCreatureEvent;

        creatureNameText.text = creature.name;
        creatureLevelText.text = creature.level.ToString();
        creatureCurrentHPText.text = creature.currentHP.ToString();
        creatureMaxHPText.text = creature.HP.ToString();
    }

    private void OnNFTCreatureEvent(NFTCreature _creature, int _ID)
    {
        if(creature != _creature) return;

        switch(_ID)
        {
            case 0:
            HPBar.localScale = new Vector3(_creature.HPRatio, 1.0f, 1.0f);
            break;
        }
    }
}
}