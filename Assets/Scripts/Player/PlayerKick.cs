using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKick : MonoBehaviour
{
    [SerializeField] private GameObjectRuntimeSet _skully;
    private GameObject _skullyGO;
    private Rigidbody _skullyRB;
    [SerializeField] private PlayerAnimationController _animationController;
    [SerializeField] private GameEvent _shake;
    [SerializeField] private IntVariable _hits;
    [SerializeField] private Vector3 _toSkull;
    [SerializeField] private float _force = 5f;
    [SerializeField] private Transform _aimPoint;
    [SerializeField] private float _radius;
    [SerializeField] bool _canKick = false;
    [SerializeField] private float _fov;
    [SerializeField] private float _angle;
    [SerializeField] private float _dot;
    [SerializeField] private float _wobble = 1f;



    // Start is called before the first frame update
    void Start()
    {
        _skullyGO = _skully.GetItems()[0];
        _skullyRB = _skullyGO.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        _toSkull = _skullyGO.transform.position - transform.position;
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        _angle = Mathf.Acos(Vector3.Dot(forward, _toSkull) / (forward.magnitude * _toSkull.magnitude)) * Mathf.Rad2Deg;
        _dot = Vector3.Dot(forward,_toSkull);
        if (_toSkull.magnitude <= _radius && _angle <=_fov &&_dot>0f)
        {
            _canKick = true;
        }
        else
        {
            _canKick = false;
        }

        if (_canKick && Input.GetButtonDown("Fire1"))
        {
            Kick();
        }

        if (Input.GetButtonDown("Fire1"))
        {
            _animationController.Kick();
        }
    }



    void Kick()
    {
        AudioManager.instance.Play("Bones");
        _shake.Raise();
        _animationController.DustBurst();
        _hits.SetValue(_hits.Value + 1);
        float xWobble = Random.Range(-1 * _wobble, _wobble);
        float yWobble = Random.Range(-1 * _wobble, _wobble);

        Vector3 dir = new Vector3(_toSkull.x + xWobble, 0f, _toSkull.z+yWobble);
        _skullyRB.velocity = Vector3.zero;
        _skullyRB.AddForce(dir.normalized * _force, ForceMode.Impulse);
        _skullyGO.TryGetComponent<Skull>(out Skull skl);
        skl.Flash();
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, _radius);
    }
}
