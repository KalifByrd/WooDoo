using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Transform player;
    Vector3 offSet = new Vector3(0.0f,2.24f,-3.1f);
    // Start is called before the first frame update
    void Start()
    {
      player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
      Vector3 position = transform.position ;
      position.x = player.position.x;
      position.z = (player.position + offSet).z;
      position.y = (player.position + offSet).y;
      transform.position = position;
    }
}
