using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour
{
    [Header("CurrentEnvironment")]
    public int currentEnvironmentIndex;
    public string currentEnvironmentName;
    public List<GameObject> dontDestroyOnLoad;
    public GameObject helpObj;
    // Start is called before the first frame update
    void Start()
    {
        InitiateEnviornment();

    }
    private void InitiateEnviornment()
    {  
        //DontDestroyOnLoad(playerCharacter);
        
        currentEnvironmentIndex = SceneManager.GetActiveScene().buildIndex;
        currentEnvironmentName = SceneManager.GetActiveScene().name;
        Debug.Log(dontDestroyOnLoad.Count);
        if(dontDestroyOnLoad.Count > 0)
        {
            foreach(GameObject dontDestroyOnLoadObj in dontDestroyOnLoad)
            {
                Destroy(dontDestroyOnLoadObj);
            }
        }
        
        
    }
    public void StartGame()
    {
        Debug.Log(dontDestroyOnLoad.Count);
        DontDestroyOnLoad(gameObject);
        //dontDestroyOnLoad.Add(gameObject);
        LoadEnvironment("Void");
    }
    public void HelpBtn()
    {
        if(!helpObj.activeInHierarchy)
        {
            helpObj.SetActive(true);
        }
        else
        {
            helpObj.SetActive(false);
        }
        
    }
    public void ExitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;

        InitiateEnviornment();
    }
    public GameObject GetSceneIndex(Scene scene, int gameObjectIndex)
    {
        GameObject[] rootGameObjects = scene.GetRootGameObjects(); 
        return rootGameObjects[gameObjectIndex];
    }

    public void LoadEnvironment(string environmentToLoad)
    {
        SceneManager.LoadScene(environmentToLoad);

        SceneManager.sceneLoaded += OnSceneLoaded;
        
        
        Wait(1);
        
        Start();
    }

    public IEnumerator Wait(int n)
    {
        yield return new WaitForSeconds(n);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
