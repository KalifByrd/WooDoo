using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Camera cam;

    private Vector3 destination;
    public GameObject airProjectile;
    public GameObject fireProjectile;
    public Transform firePoint;
    public float projectileSpeed = 3f;
    [SerializeField] int offSetPercent;
    

    void Awake()
    {
        airProjectile = GameObject.Find("AirProjcetile");
        airProjectile.SetActive(false);

        fireProjectile = GameObject.Find("FireProjectile");
        fireProjectile.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ShootProjectile()
    {
        if(gameObject.GetComponent<CustomTag>().HasTag("AirAligned"))
        {
            Debug.Log("we can shoot");
            RayCastProjectile();
            SpawnProjcetile(firePoint, airProjectile);
        }
        if(gameObject.GetComponent<CustomTag>().HasTag("FireAligned"))
        {
            Debug.Log("we can shoot");
            RayCastProjectile();
            SpawnProjcetile(firePoint, fireProjectile);
        }
    }

    void RayCastProjectile()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit))
        {
            destination = hit.point;
        }
        else
        {
            destination = ray.GetPoint(1000);
        }
    }

    void SpawnProjcetile(Transform firePoint, GameObject projectile)
    {
        projectile.transform.position = firePoint.position;
        projectile.SetActive(true);
        projectile.GetComponent<Rigidbody>().velocity = (destination)+ gameObject.transform.forward * projectileSpeed;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
