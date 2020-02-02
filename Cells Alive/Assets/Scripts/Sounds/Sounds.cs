using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour {
    // Start is called before the first frame update

    public AudioClip Main;
    public AudioClip Button;
    public AudioClip MainShoot;
    public AudioClip SecondShoot;

    public AudioSource source;

    void Start() {
        source = GetComponent<AudioSource>();
        DontDestroyOnLoad(this.gameObject);
    }

    public void buttonSound() {
        source.Play();
    }

}
