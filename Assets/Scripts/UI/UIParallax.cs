using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIParallax : MonoBehaviour
{
    private Vector3 _startPos;

    [SerializeField] private float _parallaxAmount;

    // Start is called before the first frame update
    void Start()
    {
        _startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 _target = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        _target.z = 0;
        gameObject.transform.position = _target;
        transform.position = new Vector3(_startPos.x + (_target.x * _parallaxAmount), _startPos.y + (_target.y * _parallaxAmount), 0);

    }
}
