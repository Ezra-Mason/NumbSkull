using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    [SerializeField] private GameObject _collider;
    [SerializeField] private GameObject _trigger;
    private void OnCollisionEnter(Collision collision)
    {
            _collider.SetActive(false);
            _trigger.SetActive(true);
            AudioManager.instance.Play("Spikes");
    }

    private void OnTriggerExit(Collider other)
    {

            _collider.SetActive(true);
            _trigger.SetActive(false);
            AudioManager.instance.Play("Spikes");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
