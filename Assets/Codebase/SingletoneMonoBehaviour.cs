using UnityEngine;

public class SingletoneMonoBehaviour<T> : MonoBehaviour
{
    #region Variables

    private static T _instance;

    #endregion


    #region Properties

    public static T Instance => _instance;

    #endregion


    #region Unity lifecycle

    protected virtual void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);

            return;
        }

        _instance = GetComponent<T>();
        DontDestroyOnLoad(gameObject);
    }

    #endregion
}