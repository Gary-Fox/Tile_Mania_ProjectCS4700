// Add to a CameraShake.cs script on the Virtual Camera
//using Cinemachine;
/* using Unity.Cinemachine;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake Instance { get; private set; }

    CinemachineVirtualCamera vcam;
    CinemachineBasicMultiChannelPerlin noise;
    float shakeTimer;

    void Awake()
    {
        Instance = this;
        vcam = GetComponent<CinemachineVirtualCamera>();
        noise = vcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    void Update()
    {
        if (shakeTimer > 0)
        {
            shakeTimer -= Time.deltaTime;
            if (shakeTimer <= 0)
            {
                noise.m_AmplitudeGain = 0;
                noise.m_FrequencyGain = 0;
            }
        }
    }

    public void Shake(float intensity = 1f, float duration = 0.2f)
    {
        noise.m_AmplitudeGain = intensity;
        noise.m_FrequencyGain = 2f;
        shakeTimer = duration;
    }
}*/