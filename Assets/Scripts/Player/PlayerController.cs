using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _speed = 5f;
    [SerializeField] private Transform _camera;

    [SerializeField] private Vector3 _moveDirection = new Vector3();
    public Vector3 Move => _moveDirection;

    [SerializeField] private Vector3 _resetPosition;

    [SerializeField] private bool _canMove = true;
    [SerializeField] private IntVariable _hits;
    

    // Start is called before the first frame update
    void Start()
    {
        _camera = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        _moveDirection = new Vector3(horizontal, 0f, vertical).normalized;
        if (_moveDirection.magnitude >= 0.1 && _canMove)
        {
            float targetAngle = Mathf.Atan2(_moveDirection.x, _moveDirection.z) * Mathf.Rad2Deg + _camera.eulerAngles.y;
            Vector3 move = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            transform.Translate(move.normalized * _speed * Time.deltaTime, Space.World);
        }
        if (_rb.velocity.magnitude>0.1f)
        {
            _rb.velocity = Vector3.zero;
        }
    }

    public void ResetPosition()
    {
        _rb.velocity = Vector3.zero;
        transform.position = _resetPosition;
        _hits.SetValue(0);
    }

    public void StopMovement()
    {
        _canMove = false;
    }
    public void StartMovement()
    {
        _canMove = true;
    }
}
