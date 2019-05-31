using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSounds : MonoBehaviour {

    public AudioSource myFx;
    public AudioClip hoverFX;
    public AudioClip clickFx;

    public void PlaySoundWhenHover()
    {
        myFx.PlayOneShot(hoverFX);
    }

    public void PlaySoundWhenClicked()
    {
        myFx.PlayOneShot(clickFx);
    }
}
