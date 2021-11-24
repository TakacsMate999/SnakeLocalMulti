using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static AudioClip appleSound, gameOverSound;
    static AudioSource audiosrc;

    // Start is called before the first frame update
    void Start()
    {
        appleSound = Resources.Load<AudioClip>("AppleSound");
        gameOverSound= Resources.Load<AudioClip>("GameOverSound");
        audiosrc = GetComponent<AudioSource>();
    }

    public static void PlaySound(string s)
    {
        if (s == "apple")
        {
            audiosrc.PlayOneShot(appleSound);
        }
        if (s == "gameOver")
        {
            audiosrc.PlayOneShot(gameOverSound);
        }
    }
}
