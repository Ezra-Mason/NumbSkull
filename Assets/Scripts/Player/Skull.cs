using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skull : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private GameObjectRuntimeSet _skully;
    [SerializeField] private Rigidbody _rb;
    private bool _isActive = true;
    public bool IsActive => _isActive;
    private bool _lerpingTo;
    private Vector3 _target;
    [Header("Auto Movement")]
    [SerializeField] private float _lerpSpeed = 5f;
    [SerializeField] private Vector3 _resetPosition;
    [Header("Flashing")]
    [SerializeField] private Material _flashMat;
    [SerializeField] private Material _defaultMat;
    [SerializeField] private MeshRenderer _gfx;
    [SerializeField] private float _time;
   

    // Start is called before the first frame update
    void OnEnable()
    {
        _skully.Add(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        float distance = (_target - transform.position).magnitude;
        if (_lerpingTo)
        {
            transform.position = Vector3.Lerp(transform.position, _target, _lerpSpeed * Time.fixedDeltaTime) ;
            if (distance >= 0.025f)
            {
                transform.position = _target;
                _lerpingTo = false;
            }
        }
    }

    private void OnDisable()
    {
        _skully.Remove(gameObject);
    }

    public void StopAtPos(Vector3 target)
    {
        _lerpSpeed = _rb.velocity.magnitude;
        _rb.velocity = Vector3.zero;
        _lerpingTo = true;
        _target = target;
        //StartCoroutine(LerpTo(target));
    }

    public void ResetPosition()
    {
        _lerpingTo = false;
        _rb.velocity = Vector3.zero;
        transform.position = _resetPosition;
    }

    private void OnCollisionEnter(Collision collision)
    {
        AudioManager.instance.Play("Bump");
    }

    public void SetActive()
    {
        _isActive = true;
    }
    public void SetUnactive()
    {
        _isActive = false;
    }

    public void Flash()
    {
        StartCoroutine(SetMat());
    }

    IEnumerator SetMat()
    {
        _gfx.material = _flashMat;
        yield return new WaitForSeconds(_time);
        _gfx.material = _defaultMat;
    }
}
