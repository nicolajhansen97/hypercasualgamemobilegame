using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [Header(" Sounds ")]
    [SerializeField] private AudioSource doorHitSound;
    [SerializeField] private AudioSource playerDiesSound;
    [SerializeField] private AudioSource levelCompleteSound;
    [SerializeField] private AudioSource gameOverSound;
    [SerializeField] private AudioSource buttonSound;

    // Start is called before the first frame update
    void Start()
    {
        PlayerDetection.onDoorsHit += PlayDoorHitSound;

        GameManager.onGameStateChanged += GameStateChangedCallback;

        Enemy.onRunnerDied += PlayRunnerDiedSound;
    }

    private void OnDestroy()
    {
        PlayerDetection.onDoorsHit -= PlayDoorHitSound;

        GameManager.onGameStateChanged -= GameStateChangedCallback;

        Enemy.onRunnerDied -= PlayRunnerDiedSound;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GameStateChangedCallback(GameManager.GameState gameState)
    {
       if(gameState == GameManager.GameState.LevelComplete)
        {
            levelCompleteSound.Play();
        }
       else if(gameState == GameManager.GameState.Gameover)
        {
            gameOverSound.Play();
        }
    }

    private void PlayDoorHitSound()
    {
        doorHitSound.Play();
    }

    private void PlayRunnerDiedSound()
    {
        playerDiesSound.Play();
    }

    public void EnableSounds()
    {
        doorHitSound.volume = 1;
        playerDiesSound.volume = 1;
        levelCompleteSound.volume = 1;
        gameOverSound.volume = 1;
        buttonSound.volume = 1;
    }

    public void DisableSounds()
    {
        doorHitSound.volume = 0;
        playerDiesSound.volume = 0;
        levelCompleteSound.volume = 0;
        gameOverSound.volume = 0;
        buttonSound.volume = 0;
    }
}
