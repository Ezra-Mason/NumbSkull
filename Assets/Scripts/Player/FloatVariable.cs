using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Float Variable")]
public class FloatVariable : ScriptableObject
{
    [SerializeField] private float _value;
    public float Value => _value;

    public void SetValue(float newValue)
    {
        _value = newValue;
    }

}
