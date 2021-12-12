using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StringRandomise : MonoBehaviour
{
    [SerializeField] private StringCollection _strings;
    [SerializeField] private Text _text;
    private void OnEnable()
    {
        int rand = Random.Range(0, _strings.Strings.Length);
        _text.text = _strings.Strings[rand];
    }

}
