using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhysics : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private Vector3 _move = new Vector3();
    [SerializeField] private Vector3 _input = new Vector3();
    [SerializeField] private float _speed;
    [SerializeField] private Transform _camera;
    [SerializeField] private float _turnSmooth = 0.1f;
    float TURN_SMOOTH_VELOCITY;

    // Start is called before the first frame update
    void Start()
    {
        _camera = Camera.main.transform;
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        _input = new Vector3(horizontal, 0f, vertical).normalized;

    }

    private void FixedUpdate()
    {
        if (_input.magnitude >= 0.1)
        {
            float targetAngle = Mathf.Atan2(_input.x, _input.z) * Mathf.Rad2Deg + _camera.eulerAngles.y;
            _move = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            float tempAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref TURN_SMOOTH_VELOCITY, _turnSmooth);
            //transform.rotation = Quaternion.Euler(0f, tempAngle, 0f);
            transform.Translate(_move.normalized * _speed * Time.deltaTime, Space.World);
            //_rb.AddForce(_move * _speed * Time.fixedDeltaTime, ForceMode.Force);
        }

    }
}
