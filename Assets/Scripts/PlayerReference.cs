using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReference : MonoBehaviour
{
    public static GameObject player;

    private void Awake()
    {
        if(player == null)
        {
            player = gameObject;
            DontDestroyOnLoad(gameObject);
        }
        else if(player != gameObject)
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
