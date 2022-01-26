using UnityEngine;

public class AudioManager : MonoBehaviour
{
    #region Variables

    public AudioSource Source;
    
    private static AudioManager _instance;

    #endregion


    #region Properties

    public static AudioManager Instance => _instance;

    #endregion


    #region Unity lifecycle

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);

            return;
        }

        _instance = this;
        DontDestroyOnLoad(gameObject);
    }

    #endregion


    #region Public methods

    public void PlayOnShot(AudioClip clip)
    {
        Source.PlayOneShot(clip);
    }

    #endregion
}
