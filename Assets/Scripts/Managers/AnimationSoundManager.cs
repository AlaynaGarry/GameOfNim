using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationSoundManager : MonoBehaviour
{
    public void PlaySound(AudioClip clip)
    {
        //its a meeee, not marioooo - Alexis
        AudioManager.Instance.PlaySFX(clip);
    }
}
