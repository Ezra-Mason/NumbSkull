using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{

    [SerializeField] private string _breakSFX = "Crack";
    [SerializeField] private ParticleSystem _breakParticles;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Skull>(out Skull skl))
        {
            Break();
        }
    }
    void Break()
    {
        AudioManager.instance.Play(_breakSFX);
        _breakParticles.Play();
        gameObject.SetActive(false);
    }
}
