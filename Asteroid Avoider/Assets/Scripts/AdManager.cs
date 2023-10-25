using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour, IUnityAdsInitializationListener, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] private string androidGameId;
    [SerializeField] private string iOSGameId;
    [SerializeField] private bool testMode = true;
    [SerializeField] private string androidAdUnitId;
    [SerializeField] private string iOSAdUnitId;

    public static AdManager Instance;

    private string gameId;
    private string adUnitId;
    private GameOverHandler gameOverHandler;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        { 
            Destroy(gameObject); 
        }
        else
        {
            InitialiseAds();

            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void InitialiseAds()
    {
#if UNITY_IOS
        gameId = iOSGameId;
        adUnitId = iOSAdUnitId;

#elif UNITY_ANDROID
        gameId = androidGameId;
        adUnitId = androidAdUnitId;

#elif UNITY_EDITOR
        gameId = androidGameId;
        adUnitId = androidAdUnitId;
#endif
        if(!Advertisement.isInitialized)
            Advertisement.Initialize(gameId, testMode, this);
    }

    public void OnInitializationComplete()
    {
        //throw new System.NotImplementedException();
        Debug.Log("Unity Ads initialization complete.");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        //throw new System.NotImplementedException();
        Debug.Log($"Unity Ads Initilialization Failed: {error.ToString()} - {message}");
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
        //throw new System.NotImplementedException();
        Advertisement.Show(placementId, this);    
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        //throw new System.NotImplementedException();
        Debug.Log($"Errror loading Ad Unit {adUnitId}: {error.ToString()} - {message}");
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        //throw new System.NotImplementedException();
        Debug.Log($"Error showing Ad Unit {adUnitId}: {error.ToString()} - {message}");
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        //throw new System.NotImplementedException();
        if (placementId.Equals(adUnitId) 
            && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED))
        {
            gameOverHandler.ContinueGame();
        }
    }

    public void ShowAd(GameOverHandler gameOverHandler)
    {
        this.gameOverHandler = gameOverHandler;

        Advertisement.Load(adUnitId, this);
    }
}
