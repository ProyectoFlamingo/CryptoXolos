using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Flamingo
{
public class BattleUI : MonoBehaviour
{
    [SerializeField] private NFTCreatureUI _NFTCreature1UI;             /// <summary>UI For Creature 1.</summary>
    [SerializeField] private NFTCreatureUI _NFTCreature2UI;             /// <summary>UI For Creature 2.</summary>
    [SerializeField] private BattleController _battleController;        /// <summary>Battle's Controller.</summary>
    [SerializeField] private Button _move1Button;                       /// <summary>Move 1's Button.</summary>
    [SerializeField] private Button _move2Button;                       /// <summary>Move 2's Button.</summary>
    [SerializeField] private Button _move3Button;                       /// <summary>Move 3's Button.</summary>
    [SerializeField] private Button _move4Button;                       /// <summary>Move 4's Button.</summary>
    [SerializeField] private Text _move1ButtonText;                     /// <summary>Move 1's Button's Text.</summary>
    [SerializeField] private Text _move2ButtonText;                     /// <summary>Move 2's Button's Text.</summary>
    [SerializeField] private Text _move3ButtonText;                     /// <summary>Move 3's Button's Text.</summary>
    [SerializeField] private Text _move4ButtonText;                     /// <summary>Move 4's Button's Text.</summary>
    private NFTCreature _creature;                                      /// <summary>Creature's Reference.</summary>

    /// <summary>Gets NFTCreature1UI property.</summary>
    public NFTCreatureUI NFTCreature1UI { get { return _NFTCreature1UI; } }

    /// <summary>Gets NFTCreature2UI property.</summary>
    public NFTCreatureUI NFTCreature2UI { get { return _NFTCreature2UI; } }

    /// <summary>Gets and Sets battleController property.</summary>
    public BattleController battleController
    {
        get { return _battleController; }
        set { _battleController = value; }
    }

    /// <summary>Gets move1Button property.</summary>
    public Button move1Button { get { return _move1Button; } }

    /// <summary>Gets move2Button property.</summary>
    public Button move2Button { get { return _move2Button; } }

    /// <summary>Gets move3Button property.</summary>
    public Button move3Button { get { return _move3Button; } }

    /// <summary>Gets move4Button property.</summary>
    public Button move4Button { get { return _move4Button; } }

    /// <summary>Gets move1ButtonText property.</summary>
    public Text move1ButtonText { get { return _move1ButtonText; } }

    /// <summary>Gets move2ButtonText property.</summary>
    public Text move2ButtonText { get { return _move2ButtonText; } }

    /// <summary>Gets move3ButtonText property.</summary>
    public Text move3ButtonText { get { return _move3ButtonText; } }

    /// <summary>Gets move4ButtonText property.</summary>
    public Text move4ButtonText { get { return _move4ButtonText; } }

    /// <summary>Gets and Sets creature property.</summary>
    public NFTCreature creature
    {
        get { return _creature; }
        private set { _creature = value; }
    }

    /// <summary>BattleUI's instance initialization when loaded [Before scene loads].</summary>
    private void Awake()
    {
        move1Button.enabled = false;
        move2Button.enabled = false;
        move3Button.enabled = false;
        move4Button.enabled = false;
        move1ButtonText.text = string.Empty;
        move2ButtonText.text = string.Empty;
        move3ButtonText.text = string.Empty;
        move4ButtonText.text = string.Empty;

        move1Button.onClick.AddListener(OnMove1Selected);
        move2Button.onClick.AddListener(OnMove2Selected);
        move3Button.onClick.AddListener(OnMove3Selected);
        move4Button.onClick.AddListener(OnMove4Selected);
    }

    public void AssignCreature(NFTCreature _creature)
    {
        if(_creature == null) return;

        if(_creature.move1 != null)
        {
            move1Button.enabled = true;
            move1ButtonText.text = _creature.move1.name;
        }
        else
        {
            move1Button.enabled = false;
            move1ButtonText.text = string.Empty;
        }

        if(_creature.move2 != null)
        {
            move2Button.enabled = true;
            move2ButtonText.text = _creature.move2.name;
        }
        else
        {
            move2Button.enabled = false;
            move2ButtonText.text = string.Empty;
        }

        if(_creature.move3 != null)
        {
            move3Button.enabled = true;
            move3ButtonText.text = _creature.move3.name;
        }
        else
        {
            move3Button.enabled = false;
            move3ButtonText.text = string.Empty;
        }

        if(_creature.move4 != null)
        {
            move4Button.enabled = true;
            move4ButtonText.text = _creature.move4.name;
        }
        else
        {
            move4Button.enabled = false;
            move4ButtonText.text = string.Empty;
        }

        creature = _creature;
    }

    private void OnMove1Selected()
    {
        if(creature == null || creature.move1 == null) return;

        creature.move1.Perform(creature, battleController.creature2);
    }

    private void OnMove2Selected()
    {
        if(creature == null || creature.move2 == null) return;

        creature.move2.Perform(creature, battleController.creature2);
    }

    private void OnMove3Selected()
    {
        if(creature == null || creature.move3 == null) return;

        creature.move3.Perform(creature, battleController.creature2);
    }

    private void OnMove4Selected()
    {
        if(creature == null || creature.move4 == null) return;

        creature.move4.Perform(creature, battleController.creature2);
    }
}
}