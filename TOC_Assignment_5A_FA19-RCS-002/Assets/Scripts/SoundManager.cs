using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour
{

    //sounds used in game
    public AudioSource clickSound;
    //public AudioSource switchSound;
    //public AudioSource diamondSound;
    //public AudioSource fallSound;

    // Use this for initialization
    void Start()
    {

    }


    //play sound if it's enabled in menu
    public void PlaySound(AudioSource sound)
    {
       // if (PlayerPrefs.GetInt("sound", 1) == 1)
         //{
            sound.Play();
        //}
    }


}
