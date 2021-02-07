using UnityEngine;
using UnityEngine.UI;

using System.Collections;

public class SoundManager : SingeltonBase<SoundManager>
{
    /* -------------- 	Game specific sounds --------------- */
    public AudioClip levelUpSound;
    // Done
    public AudioClip buttonClickSound;


    public Button musicON;
	public Button musicOFF;
	public Button musicON1;
	public Button musicOFF1;
    // with menus
    public AudioClip menuBGSound;
    // Done
    public AudioClip gamePlayBGSound;
    // Done
    public AudioClip levelCompleteSound;
    // Done
    public AudioClip levelFailSound;
    public AudioClip reviveSound;
    public AudioClip go321Sound;
    public AudioClip destroySound;
    public AudioClip comboSound;
    public AudioClip shapeMatchSound;
    public AudioClip swipeSound;
    public AudioClip partyPop;
    public AudioClip tapRoateSound;
    public AudioClip flipSound;
    public AudioClip fallSound;



    /* Audio Source */
    public AudioSource gamePlayEffectsSource;
    public AudioSource BackgroundSoundSource;
    public AudioSource CarEnvSound;
    public AudioSource runSoundSource;
    public AudioSource healthSoundSource;





    public bool isDualSound = false;
    private bool isGamePlaySound = false;

    void Start()
    {
		
        DontDestroyOnLoad(this);
        if (!this.GetComponent<AudioSource>().isPlaying)
        {
            this.GetComponent<AudioSource>().Play();
        }

        //MusicONOFF(PlayerPrefs.GetString("music", "ON"));
        MusicONOFF(PlayerPrefs.GetInt("musicMute") == 0);

    }

    public void MusicONOFF(bool boo)
    {
        if (boo)
        {
            UnMuteMusic();
            UnMuteSound();
            print("UnMuteMusic");
        }
        else
        {
            MuteMusic();
            MuteSound();
            print("MuteMusic");
        }
    }

    public void ButtonClickSound()
    {
        gamePlayEffectsSource.PlayOneShot(buttonClickSound);
    }

    #region Mute/UnMute_Handling
    public void MuteSound()
    {
        variables.isSoundON = false;
        gamePlayEffectsSource.mute = true;
        PlayerPrefs.SetInt("soundMute", 1);
    }

    public void UnMuteSound()
    {
        variables.isSoundON = true;
        gamePlayEffectsSource.mute = false;
        PlayerPrefs.SetInt("soundMute", 0);

    }

    public void MuteMusic()
    {
        variables.isMusicON = false;
        GetComponent<AudioSource>().mute = true;
        PlayerPrefs.SetInt("musicMute", 1);

    }

    public void UnMuteMusic()
    {
        variables.isMusicON = true;
        GetComponent<AudioSource>().mute = false;
        PlayerPrefs.SetInt("musicMute", 0);

    }
    #endregion

    public void PlayMenuBGSound()
    {
        this.GetComponent<AudioSource>().clip = menuBGSound;
        this.GetComponent<AudioSource>().Play();
		this.GetComponent<AudioSource>().volume = 0.307f;
       // CarEnvSound.Play();
    }

    public void PlayGamePlaySound()
    {
        this.GetComponent<AudioSource>().clip = gamePlayBGSound;
        this.GetComponent<AudioSource>().Play();
		this.GetComponent<AudioSource>().volume = 0.307f;
    }


    
	public void buttonClick()
    {
		gamePlayEffectsSource.GetComponent<AudioSource>().clip = buttonClickSound;
        gamePlayEffectsSource.GetComponent<AudioSource>().Play();
    }

    public void go321()
    {
        gamePlayEffectsSource.GetComponent<AudioSource>().clip = go321Sound;
        gamePlayEffectsSource.GetComponent<AudioSource>().Play();
    }
    public void revive()
    {
        gamePlayEffectsSource.GetComponent<AudioSource>().clip = reviveSound;
        gamePlayEffectsSource.GetComponent<AudioSource>().Play();
    }

    public void menuBG()
    {
		gamePlayEffectsSource.GetComponent<AudioSource>().clip = menuBGSound;
        gamePlayEffectsSource.GetComponent<AudioSource>().Play();
    }

	public void levelComplete()
    {
		gamePlayEffectsSource.GetComponent<AudioSource>().clip = levelCompleteSound;
        gamePlayEffectsSource.GetComponent<AudioSource>().Play();
    }

    public void comboEffect()
    {
        gamePlayEffectsSource.GetComponent<AudioSource>().clip = comboSound;
        gamePlayEffectsSource.GetComponent<AudioSource>().Play();
    }
    public void partyPoper()
    {
        CarEnvSound.GetComponent<AudioSource>().clip = partyPop;
        CarEnvSound.GetComponent<AudioSource>().Play();
    }
    public void flip()
    {
        CarEnvSound.GetComponent<AudioSource>().clip = flipSound;
        CarEnvSound.GetComponent<AudioSource>().Play();
    }
    public void fall()
    {
        CarEnvSound.GetComponent<AudioSource>().clip = fallSound;
        CarEnvSound.GetComponent<AudioSource>().Play();
    }
    public void shapeMatch()
    {
        gamePlayEffectsSource.GetComponent<AudioSource>().clip = shapeMatchSound;
        gamePlayEffectsSource.GetComponent<AudioSource>().Play();
    }
    public void tapRotate()
    {
        gamePlayEffectsSource.GetComponent<AudioSource>().clip = tapRoateSound;
        gamePlayEffectsSource.GetComponent<AudioSource>().Play();
    }
    public void swipe()
    {
        gamePlayEffectsSource.GetComponent<AudioSource>().clip = swipeSound;
        gamePlayEffectsSource.GetComponent<AudioSource>().Play();
        print("swipe");
    }
    public void destroyEffect()
    {
        CarEnvSound.GetComponent<AudioSource>().clip = destroySound;
        CarEnvSound.GetComponent<AudioSource>().Play();
    }


    public void levelFail()
    {
        float exampleInt = GetComponent<AudioSource>().volume;
        iTween.ValueTo(gameObject, iTween.Hash(
            "from", exampleInt,
            "to", 0,
            "time", 1.2f,
            "onupdatetarget", gameObject,
            "onupdate", "changeVolume",
            "easetype", iTween.EaseType.easeOutQuad
            )
        );

        gamePlayEffectsSource.GetComponent<AudioSource>().clip = levelFailSound;
        gamePlayEffectsSource.GetComponent<AudioSource>().Play();
    }

    void changeVolume(float val)
    {
        this.GetComponent<AudioSource>().volume = val;
    }


    public void VolumeUp()
    {
        float startPoint = 0;
        float endPoint = 0.307f;

        iTween.ValueTo(gameObject, iTween.Hash(
            "from", startPoint,
            "to", endPoint,
            "time", 2,
            "onupdatetarget", gameObject,
            "onupdate", "changeVolume",
            "easetype", iTween.EaseType.easeOutQuad
            )
        );
    }




}