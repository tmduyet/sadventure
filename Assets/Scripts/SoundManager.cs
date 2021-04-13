using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip Jump, Death, Landing, Walking, button;
    static AudioSource amthanh;
   
    // Start is called before the first frame update
    void Start()
    {
        button = Resources.Load<AudioClip>("button");
        Walking = Resources.Load<AudioClip>("Walking");
        Landing = Resources.Load<AudioClip>("Landing");
        Death = Resources.Load<AudioClip>("Death");
        Jump = Resources.Load<AudioClip>("Jump");
        amthanh = GetComponent<AudioSource>();
    }

    // Update is called once per frame
 
     public static void listen(string clip)
    {
        switch (clip)
        {
            case "Jump":
                amthanh.clip = Jump;
                amthanh.PlayOneShot(Jump);
                break;
            case "Death":
                amthanh.clip = Death;
                amthanh.PlayOneShot(Death);
                break;
            case "Walking":
                amthanh.clip = Walking;
                amthanh.PlayOneShot(Walking);
                break;
            case "button":
                amthanh.clip = button;
                amthanh.PlayOneShot(button);
                break;

        }


    }
    
}
