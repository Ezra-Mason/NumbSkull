using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Int Variable")]
public class IntVariable : ScriptableObject
{
    [SerializeField] private int _value;
    public int Value => _value;

    public void SetValue(int newValue)
    {
        _value = newValue;
    }
}
