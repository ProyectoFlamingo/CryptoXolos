using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Flamingo
{
public class Character : MonoBehaviour
{
    [SerializeField] private string _name;          /// <summary>Character's Name.</summary>
    [SerializeField] private Gender _gender;        /// <summary>Character's Gender.</summary>

    /// <summary>Gets and Sets name property.</summary>
    public string name
    {
        get { return _name; }
        set { _name = value; }
    }

    /// <summary>Gets and Sets gender property.</summary>
    public Gender gender
    {
        get { return _gender; }
        set { _gender = value; }
    }
}
}