using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationSoundManager : MonoBehaviour
{
    public void PlaySound(AudioClip clip)
    {
        AudioManager.Instance.PlaySFX(clip);
    }
}
