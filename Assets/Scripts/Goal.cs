using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] private float _centralRadius;
    [SerializeField] private GameEvent _goalReached;
    [SerializeField] private GameObjectRuntimeSet _skully;
    private GameObject _skullyGO;
    private bool _eventRaised = false;


    private void OnEnable()
    {
        _eventRaised = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        _skullyGO = _skully.GetItems()[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (_skullyGO != null)
        {
            float dist = (_skullyGO.transform.position - transform.position).magnitude;
            _skullyGO.TryGetComponent<Skull>(out Skull skl);
            bool isActive = skl.IsActive;
            if (dist <= _centralRadius && !_eventRaised && isActive)
            {
                AudioManager.instance.Play("Echoes");
                _goalReached.Raise();
                _eventRaised = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Skull>(out Skull skl))
        {
            skl.StopAtPos(transform.position);
        }
    }

    private void OnDisable()
    {
        _eventRaised = false;
    }
}
