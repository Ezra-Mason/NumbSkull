using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitCounter : MonoBehaviour
{
    [SerializeField] private Text _hitText;
    [SerializeField] private IntVariable _hits;
    [SerializeField] private int _currentCount;
    [SerializeField] private int _previousCount;
    // Start is called before the first frame update
    void Start()
    {
        _currentCount = _hits.Value;
        _previousCount = 0;
        UpdateUI(_currentCount);
    }

    // Update is called once per frame
    void Update()
    {
        if (_currentCount != _hits.Value)
        {
            _previousCount = _currentCount;
            _currentCount = _hits.Value;
            UpdateUI(_currentCount);
        }
    }

    private void UpdateUI(int value)
    {
        _hitText.text = "Hits: " + value;
    }
}
