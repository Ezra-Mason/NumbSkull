using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelNumberUI : MonoBehaviour
{
    [SerializeField] private Text _levelText;
    [SerializeField] private IntVariable _currentLevel;
    [SerializeField] private IntVariable _maxLevel;
    [SerializeField] private int _currentCount;
    [SerializeField] private int _maxCount;
    // Start is called before the first frame update
    void Start()
    {
        _currentCount = _currentLevel.Value;
        _maxCount = _maxLevel.Value;
        UpdateUI(_currentCount);
    }

    // Update is called once per frame
    void Update()
    {
        if (_currentCount != _currentLevel.Value)
        {
            _currentCount = _currentLevel.Value;
            UpdateUI(_currentCount);
        }
    }

    private void UpdateUI(int value)
    {
        _levelText.text = "Level " + value +" / "+_maxCount;
    }
}
