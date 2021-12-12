using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "String Collection")]
public class StringCollection : ScriptableObject
{
    [SerializeField] private string[] _strings;

    public string[] Strings => _strings;

}
