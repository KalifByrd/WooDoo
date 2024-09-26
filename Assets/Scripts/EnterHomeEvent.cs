using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterHomeEvent : MonoBehaviour
{
    // Start is called before the first frame update
    public GameManager gameManager;
    public SimpleHome simpleHome;
    
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        
    }
    void OnTriggerEnter(Collider other)
    {
        
       
        if(other.tag == "Player")
        {
            simpleHome = transform.parent.gameObject.GetComponent<SimpleHome>();
            GameObject exitPointObject = gameObject.transform.parent.GetChild(3).gameObject;
            gameManager.playerHouseExitPoint = new Vector3(exitPointObject.transform.position.x, exitPointObject.transform.position.y, exitPointObject.transform.position.z);
            gameManager.currentPlayerHome = simpleHome.gameObject;
            if(gameManager.previousePlayerHomeSave == gameManager.playerHomeSave)
            {
                gameManager.previousePlayerHomeSave = null;
            }
            
            gameManager.EnterHome();
            gameManager.previousePlayerHomeSave = gameManager.playerHomeSave;
            
            
            
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
