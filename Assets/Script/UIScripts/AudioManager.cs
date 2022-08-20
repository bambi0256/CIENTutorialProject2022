using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
}
public class AudioManager : MonoBehaviour
{
    public static AudioManager instance; 

    [SerializeField] Sound[] sfx = null;
    [SerializeField] Sound[] bgm = null;

    [SerializeField] AudioSource bgmPlayer = null;
    [SerializeField] AudioSource[] sfxPlayer = null;
    
  void Start()
    {
        instance = this;
        PlayBGM("MainMenu");
    }

    public void PlayBGM (string bgmName)
    {
        for(int i = 0; i < bgm.Length; i++)
        {
            if(bgmName == bgm[i].name)
            {
                bgmPlayer.clip = bgm[i].clip;
                bgmPlayer.Play();
            }
        }
    }
    public void PlaySFX(string SFXName)
    {
        for (int i = 0; i < sfx.Length; i++)
        {
            if (SFXName == sfx[i].name)
            {
                for(int j = 0; j < sfxPlayer.Length; j++)
                {
                    if (!sfxPlayer[j].isPlaying)
                    {
                        sfxPlayer[j].clip = sfx[i].clip;
                        sfxPlayer[j].Play();
                        return;
                    }
                }
                Debug.Log("All audio Player is playing");
                return;
            }
        }
        Debug.Log(SFXName + "is not exist");
    }



    // Start is called before the first frame update
  
    // Update is called once per frame
    void Update()
    {
        
    }
}
