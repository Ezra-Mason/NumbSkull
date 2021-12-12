using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundtrackLoader : MonoBehaviour
{
    [SerializeField] private string _soundTrack = "Soundtrack";
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance.Play(_soundTrack);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
