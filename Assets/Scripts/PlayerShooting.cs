using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private float _force = 5f;
    [SerializeField] private bool _canShoot = true;
    [SerializeField] private float _fireRate = 1f;
    [SerializeField] private float _timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        _timer = _fireRate;
    }

    // Update is called once per frame
    void Update()
    {
        if (_timer <= 0f && !_canShoot)
        {
            _canShoot = true;
        }
        if (_timer>0f)
        {
            _timer -= Time.deltaTime;
            _canShoot = false;
        }

        if (Input.GetButton("Fire1") && _canShoot)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        _timer = _fireRate;
        GameObject go = Instantiate(_bulletPrefab);
        go.transform.position = _shootPoint.position;
        Rigidbody rb = go.GetComponent<Rigidbody>();
        Vector3 dir = _shootPoint.position - transform.position;
        rb.AddForce(dir * _force, ForceMode.Impulse);
    }
}
