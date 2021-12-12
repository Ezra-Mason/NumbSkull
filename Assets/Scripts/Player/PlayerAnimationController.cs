using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private PlayerController _playerController;
    private bool _dustStarted;
    [SerializeField] private GameObject _dust;
    [SerializeField] private ParticleSystem _dustBurst;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _animator.SetFloat("Speed", _playerController.Move.magnitude);
/*        if (Input.GetAxis("Horizontal")!=0 || Input.GetAxis("Vertical") != 0 && !_dustStarted)
        {
            _dustStarted = true;
            _dust.SetActive(_dustStarted);
        }
        else
        {
            _dustStarted = false;
            _dust.SetActive(_dustStarted);
        }
*/    }

    public void Kick()
    {
        _animator.SetTrigger("Kick");
    }

    public void DustBurst()
    {
        _dustBurst.Play();
    }
}
