using UnityEngine;

public class AudioManager : SingletoneMonoBehaviour<AudioManager>
{
    #region Variables

    public AudioSource Source;

    #endregion


    #region Public methods

    public void PlayOnShot(AudioClip clip)
    {
        Source.PlayOneShot(clip);
    }

    #endregion
}