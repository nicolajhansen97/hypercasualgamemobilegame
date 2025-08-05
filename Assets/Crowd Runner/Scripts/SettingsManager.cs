using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{

    [Header(" Elements ")]
    [SerializeField] private SoundManager soundManger;
    [SerializeField] private Sprite optionsOnSprite;
    [SerializeField] private Sprite optionsOffSprite;
    [SerializeField] private Image soundsButtonImage;
    [SerializeField] private Image hapticsButtonImage;

    [Header(" Settings ")]
    private bool soundsState = true;
    private bool hapticsState = true;

    private void Awake()
    {
        soundsState = PlayerPrefs.GetInt("sounds", 1) == 1;
        hapticsState = PlayerPrefs.GetInt("haptics", 1) == 1;
    }

    // Start is called before the first frame update
    void Start()
    {
        SetupSounds();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetupSounds()
    {
        if(soundsState)
        {
            EnableSounds();
        }
        else
        {
            DisableSounds();
        }
    }

    public void ChangeSoundsState()
    {
        if(soundsState)
        {
            DisableSounds();
        }
        else
        {
            EnableSounds();
        }

        soundsState = !soundsState;

        PlayerPrefs.SetInt("sounds", soundsState ? 1 : 0);
    }

    private void DisableSounds()
    {
        soundManger.DisableSounds();
        soundsButtonImage.sprite = optionsOffSprite;
    }

    private void EnableSounds()
    {
        soundManger.EnableSounds();
        soundsButtonImage.sprite = optionsOnSprite;
    }
}
