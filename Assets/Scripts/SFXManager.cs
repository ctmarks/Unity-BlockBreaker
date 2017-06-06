using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour {

    public static Dictionary<string, AudioSource> AudioSources;

	// Use this for initialization
	void Start () {
		if(AudioSources == null){
            AudioSources = new Dictionary<string, AudioSource>();

            AudioSource[] sources = this.GetComponentsInChildren<AudioSource>();   

            for(int i = 0; i < sources.Length; i++) {
                AudioSources[sources[i].gameObject.name] = sources[i];
            }
        } else {
            Destroy(gameObject);
            print("Destroyed extra SFX manager");
        }

        GameObject.DontDestroyOnLoad(this);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlaySFX(string key) {
        AudioSources[key].Play();
    }
}
