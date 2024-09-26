using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCreationTabs : MonoBehaviour
{
    public GameObject hairTab;
    public GameObject faceTab;
    public GameObject clothesTab;
    public GameObject accessoriesTab;

    public GameObject hairPage;
    public GameObject facePage;
    public GameObject clothesPage;
    public GameObject accessoriesPage;
    public List<GameObject> tabs;
    public List<GameObject> pages;
    public Button leftBtn;
    public Button rightBtn;
    private int currentIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        tabs.Add(hairTab);
        tabs.Add(faceTab);
        tabs.Add(clothesTab);
        tabs.Add(accessoriesTab);

        pages.Add(hairPage);
        pages.Add(facePage);
        pages.Add(clothesPage);
        pages.Add(accessoriesPage);


        leftBtn.onClick.AddListener(MoveToPrevious);
        rightBtn.onClick.AddListener(MoveToNext);
        UpdateTab();
        UpdatePage();
    }
    void MoveToPrevious()
    {
        currentIndex--;
        if(currentIndex < 0)
        {
            currentIndex = tabs.Count - 1;
        }
        UpdateTab();
        UpdatePage();

    }
    void MoveToNext()
    {
        currentIndex++;
        if(currentIndex>= tabs.Count)
        {
            currentIndex = 0;
        }
        UpdateTab();
        UpdatePage();
    }
    void UpdateTab()
    {
        UpdateHelper(tabs);
        
    }
    void UpdatePage()
    {
        UpdateHelper(pages);
    }
    void UpdateHelper(List<GameObject> list)
    {
        list[currentIndex].SetActive(true);
        foreach(GameObject o in list)
        {
            if(o != list[currentIndex] && o.activeInHierarchy == true)
            {
                o.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
