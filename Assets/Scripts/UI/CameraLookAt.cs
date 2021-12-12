using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraLookAt : MonoBehaviour
{
    [SerializeField] private GameObjectRuntimeSet _player;
    [SerializeField] private GameObjectRuntimeSet _skully;
    private bool _lookingAtPlayer = true;
    [SerializeField] private Cinemachine.CinemachineVirtualCamera _vcam;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LookAt()
    {
        if (_lookingAtPlayer)
        {


        }
    }
}
