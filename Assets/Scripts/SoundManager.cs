using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


//class handles the playing of all sound effects and music. Also handles any real-time mixing audio functionality.
public class SoundManager : MonoBehaviour {

    //singleton/static instance variable, we never want more than one sound manager in the scene
    static SoundManager instance = null;

    //static dictonaries for sfx and music audio sources(source outputs, volumes, etc... are set in inspector)
    //lookup sfx and music using string key from respective dictionaries
    public static Dictionary<string, AudioSource> SFX;
    public static Dictionary<string, AudioSource> Music;

    //master mixer variable for controlling volumes of sound groups
    public AudioMixer masterMixer;

    //mixer snapshots
    public AudioMixerSnapshot paused;
    public AudioMixerSnapshot unPaused;

    void Awake() {
        //if a sound manager already exists destroy any new copies
        if (instance != null) {
            Destroy(gameObject);
        } else {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }

    // Use this for initialization
    void Start() {
            //inititialize sfx dictionary
            SFX = new Dictionary<string, AudioSource>();

            AudioSource[] SFXsources = this.transform.FindChild("SFX").GetComponentsInChildren<AudioSource>();

            for (int i = 0; i < SFXsources.Length; i++) {
                SFX[SFXsources[i].gameObject.name] = SFXsources[i];
            }

            //initialize music dictionary
            Music = new Dictionary<string, AudioSource>();

            AudioSource[] MusicSources = this.transform.FindChild("Music").GetComponentsInChildren<AudioSource>();

            for (int i = 0; i < MusicSources.Length; i++) {
                Music[MusicSources[i].gameObject.name] = MusicSources[i];
            }
    }


    //these play functions are for hooking into the canvas button event system calls from the inspector
    //couldn't figure out how to use dictionary for this instead
    public void PlaySFX(string key) {
        SFX[key].Play();
    }

    public void PlayMusic(string key) {
        Music[key].Play();
    }

    //these functions hook into the slider components on the options menu portion of the canvas system
    //the slider objects call these functions from the inspector, they hadle master volume controls for groups
    public void SetSfxLevel(float sfxLvl) {
        masterMixer.SetFloat("sfxVol", sfxLvl);
    }

    public void SetMusicLevel(float musLvl) {
        masterMixer.SetFloat("musicVol", musLvl);
    }

    //these functions are called by pause manager to switch between a pause and un-paused mixer snapshot(just toggles a low pass filter on the music)
    public void TogglePauseSnapshot(bool pausedByPass) {
        if (pausedByPass) {
            paused.TransitionTo(.01f);
        } else {
            unPaused.TransitionTo(.01f);
        }
    }
}
