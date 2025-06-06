using System.Collections;
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

    public void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }
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



    public void PlaySFX(string key, float duration = -1f)
    {
        AudioClip clip = soundMap.Get(key);
        if (clip != null)
        {
            audioSource.clip = clip;
            audioSource.Play();

            if (duration > 0f && duration < clip.length)
            {
                StartCoroutine(StopClipAfter(duration));
            }
        }
        else
        {
            Debug.LogWarning("Sound not found for key: " + key);
        }
    }

    private IEnumerator StopClipAfter(float time)
    {
        yield return new WaitForSeconds(time);
        audioSource.Stop();
    }
}