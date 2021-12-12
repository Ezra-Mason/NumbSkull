using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHockey : MonoBehaviour
{
    [SerializeField] private Transform _arm;
    [SerializeField] private float _rotateSpeed = 4f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Jump"))
        {
            _arm.transform.Rotate(Vector3.up, _rotateSpeed * Time.deltaTime);
        }
    }


}
