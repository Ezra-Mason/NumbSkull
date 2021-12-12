using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] private float _centralRadius;
    [SerializeField] private GameObjectRuntimeSet _skully;
    private GameObject _skullyGO;


    // Start is called before the first frame update
    void Start()
    {
        _skullyGO = _skully.GetItems()[0];
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Skull>(out Skull skl))
        {
            skl.StopAtPos(transform.position);
            AudioManager.instance.Play("Slime");
        }
    }


}
