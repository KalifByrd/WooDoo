using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCustomizationManager : MonoBehaviour
{
    public GameObject swimF;
    public GameObject swimM;
    public GameObject sailorF;
    public GameObject sailorM;
    public GameObject sailorJacketF;
    public GameObject sailorSweaterM;
    public GameObject currentFace;
    public GameObject currentHairBase;
    public GameObject currentHairFront;
    
    public GameObject currentOutfit;
    public GameObject leftEye;
    public GameObject rightEye;
    private Transform facePosition;
    private Transform hairBaseParent;
    private Transform hairFrontParent;
    public Transform playerParent;
    
    private Transform headPostion;
    private Transform leftEyePosition;
    private Transform rightEyePosition;

    
    // Start is called before the first frame update
    void Start()
    {
        currentOutfit = playerParent.GetChild(0).gameObject;
        currentFace = currentOutfit.transform.GetChild(3).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(2).GetChild(0).GetChild(3).gameObject;
        facePosition = currentFace.transform;
        
        hairBaseParent = facePosition.GetChild(0);
        hairFrontParent = facePosition.GetChild(1);
    }

    private void GetHeadPos()
    {
        headPostion = currentOutfit.transform.GetChild(3).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(2).GetChild(0);
    }
    private void GetLeftEyePos()
    {
        leftEyePosition = currentOutfit.transform.GetChild(3).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(2).GetChild(0).GetChild(0);
    }
    private void GetRightEyePos()
    {
        rightEyePosition = currentOutfit.transform.GetChild(3).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(2).GetChild(0).GetChild(1);
    }

    private void PutHairBaseOnFace(GameObject hairBase, GameObject face)
    {
        hairBase.transform.parent = hairBaseParent;
    }
    private void PutHairFrontOnHead(GameObject hairFront, GameObject face)
    {
        hairFront.transform.parent = hairFrontParent;
    }
    private void UpdateHead()
    {
        GetHeadPos();
        GetLeftEyePos();
        GetRightEyePos();

        currentFace.transform.parent = headPostion;
        leftEye.transform.parent = leftEyePosition;
        rightEye.transform.parent = rightEyePosition;
    }
    
    public void ChangeOutfitSwimM()
    {
        currentFace = currentOutfit.transform.GetChild(3).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(2).GetChild(0).GetChild(3).gameObject;
        
        GameObject outfitChoice = Instantiate(swimM,new Vector3(-0.8139123f, 0f, -9.582646f), Quaternion.Euler(0, 180, 0), playerParent);
        outfitChoice.SetActive(true);
        currentOutfit = playerParent.GetChild(1).gameObject;
        UpdateHead();
        Destroy(playerParent.GetChild(0).gameObject);
    }
    public void ChangeOutfitSwimF()
    {
        currentFace = currentOutfit.transform.GetChild(3).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(2).GetChild(0).GetChild(3).gameObject;
        
        Instantiate(swimF, playerParent);
        currentOutfit = playerParent.GetChild(1).gameObject;
        UpdateHead();
        Destroy(playerParent.GetChild(0).gameObject);
    }
    public void ChangeOutfitSailorM()
    {
        currentFace = currentOutfit.transform.GetChild(3).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(2).GetChild(0).GetChild(3).gameObject;

        Instantiate(sailorM, playerParent);
        currentOutfit = playerParent.GetChild(1).gameObject;
        UpdateHead();
        Destroy(playerParent.GetChild(0).gameObject);
    }
    public void ChangeOutfitSailorF()
    {
        currentFace = currentOutfit.transform.GetChild(3).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(2).GetChild(0).GetChild(3).gameObject;
        
        Instantiate(sailorF, playerParent);
        currentOutfit = playerParent.GetChild(1).gameObject;
        UpdateHead();
        Destroy(playerParent.GetChild(0).gameObject);
    }
    public void ChangeOutfitSailorSweaterM()
    {
        currentFace = currentOutfit.transform.GetChild(3).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(2).GetChild(0).GetChild(3).gameObject;
        
        Instantiate(sailorSweaterM, playerParent);
        currentOutfit = playerParent.GetChild(1).gameObject;
        UpdateHead();
        Destroy(playerParent.GetChild(0).gameObject);
    }
    public void ChangeOutfitJacketF()
    {
        currentFace = currentOutfit.transform.GetChild(3).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(2).GetChild(0).GetChild(3).gameObject;
        
        Instantiate(sailorJacketF, playerParent);
        currentOutfit = playerParent.GetChild(1).gameObject;
        UpdateHead();
        Destroy(playerParent.GetChild(0).gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
