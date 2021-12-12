using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private float duration = 0.3f;
    [SerializeField] private float amplitude = 1.3f;

    [SerializeField] private float timeElapsed = 0f;

    [SerializeField] private Cinemachine.CinemachineVirtualCamera vcam;
    [SerializeField] private Cinemachine.CinemachineBasicMultiChannelPerlin noiseSettings;
    [SerializeField] private bool isShaking = false;

    // Start is called before the first frame update
    void Start()
    {

        //get the cinemachine camera and its noise settings for the shake
        vcam = GetComponent<Cinemachine.CinemachineVirtualCamera>();
        if (vcam != null)
            noiseSettings = vcam.GetCinemachineComponent<Cinemachine.CinemachineBasicMultiChannelPerlin>();
    }

    // Update is called once per frame
    void Update()
    {
        if (vcam!=null || noiseSettings!=null)
        {
            //apply shake while timer is going and decreasing timer
            if (timeElapsed > 0)
            {
                noiseSettings.m_AmplitudeGain = amplitude;
                timeElapsed -= Time.deltaTime;
            }
            else
            {
                noiseSettings.m_AmplitudeGain = 0f;
                timeElapsed = 0f;
            }

            //continuous shake mode while bool is true
            if (isShaking)
                noiseSettings.m_AmplitudeGain = amplitude;
            
        }
    }

    //method for timed screen shake
    public void Shake()
    {
        timeElapsed = duration;
    }

    //starting the continuous shake
    public void StartShake()
    {
        noiseSettings.m_AmplitudeGain = amplitude;
        isShaking = true;
    }

    //stop the continuous shake
    public void StopShake()
    {
        noiseSettings.m_AmplitudeGain = 0f;
        isShaking = false;
    }
}
