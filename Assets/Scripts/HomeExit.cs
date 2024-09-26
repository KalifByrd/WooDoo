using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeExit : MonoBehaviour
{
    public GameManager gameManager;
    public SimpleHome simpleHome;
    
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Someone entered");
        if (other.tag == "Player")
        {
            simpleHome = gameManager.currentPlayerHome.GetComponent<SimpleHome>();
            if(gameManager.currentEnvironmentName == "PlayerHome")
            {
                simpleHome.interior = GameObject.Find("PlayerHomeParent");
            }
            else if(gameManager.currentEnvironmentName == "SavedPlayerHome")
            {
                Scene currentDontDestroyOnLoad = GameObject.Find("PlayerHomeParent").scene;
                Debug.Log("homeindex = " + simpleHome.index);
                simpleHome.interior = gameManager.GetSceneIndex(currentDontDestroyOnLoad, simpleHome.index);
                
            }
            
            
            gameManager.ExitHome();
            

        }

    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
