using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static SFXManager Instance;

    private CustomHashMap soundMap;
    private AudioSource audioSource;

    [System.Serializable]
    public class SoundEntry
    {
        public string key;
        public AudioClip clip;
    }

    public SoundEntry[] sounds;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Initialize();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Initialize()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        soundMap = new CustomHashMap();

        foreach (SoundEntry entry in sounds)
        {
            soundMap.Put(entry.key, entry.clip);
        }
    }

    public void PlaySFX(string key)
    {
        AudioClip clip = soundMap.Get(key);
        if (clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}
