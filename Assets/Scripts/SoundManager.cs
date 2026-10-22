using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    public AudioClip hop;
    public AudioClip dash;
    public AudioClip eatFly;
    public AudioClip carHit;
    public AudioClip waterSplash;
    public AudioClip safeSpot;
    public AudioClip win;
    public AudioClip gameOver;
    public AudioClip backgroundMusic;
    [Range(0f, 1f)] public float musicVolume = 0.3f;

    private AudioSource source;
    private AudioSource musicSource;

    void Awake()
    {
        Instance = this;
        source = GetComponent<AudioSource>();
        source.playOnAwake = false;

        musicSource = gameObject.AddComponent<AudioSource>();
        musicSource.clip = backgroundMusic;
        musicSource.loop = true;
        musicSource.volume = musicVolume;
        musicSource.playOnAwake = false;
    }

    void Start()
    {
        if (backgroundMusic != null) musicSource.Play();
    }

    void Play(AudioClip clip)
    {
        if (clip != null) source.PlayOneShot(clip);
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }

    public void PlayHop() { Play(hop); }
    public void PlayDash() { Play(dash); }
    public void PlayEatFly() { Play(eatFly); }
    public void PlayCarHit() { Play(carHit); }
    public void PlayWater() { Play(waterSplash); }
    public void PlaySafeSpot() { Play(safeSpot); }
    public void PlayWin() { Play(win); }
    public void PlayGameOver() { Play(gameOver); }
}