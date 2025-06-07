using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string key;
    public AudioClip clip;
}

public class SFXManager : MonoBehaviour
{
    public static SFXManager Instance;

    private CustomHashMap soundMap;
    private AudioSource audioSource;
    public Sound[] sounds;


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("Missing AudioSource on SFXManager!");
        }

        soundMap = new CustomHashMap();

        foreach (Sound s in sounds)
        {
            if (s != null && s.clip != null)
            {
                Debug.Log("Registering SFX: " + s.key);
                soundMap.Put(s.key, s.clip);
            }
        }
    }

    public void PlaySFX(string key)
    {
        AudioClip clip = soundMap.Get(key);
        if (clip != null)
        {
            // Create a temporary AudioSource if spatial audio needed
            AudioSource.PlayClipAtPoint(clip, Vector3.zero); // or a fixed position
        }
        else
        {
            Debug.LogWarning("SFX not found: " + key);
        }
    }
}
