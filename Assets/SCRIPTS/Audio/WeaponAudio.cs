using UnityEngine;
using FMODUnity;

public class WeaponAudio : MonoBehaviour
{
    [SerializeField] private EventReference shootSfxRef;
    [SerializeField] private EventReference reloadSfxRef;

    public void PlayShoot()
    {
        // Plays at the object's world position (3D spatialized automatically)
        RuntimeManager.PlayOneShot(shootSfxRef, transform.position);
    }

    public void PlayReload()
    {
        RuntimeManager.PlayOneShot(reloadSfxRef, transform.position);
    }
}