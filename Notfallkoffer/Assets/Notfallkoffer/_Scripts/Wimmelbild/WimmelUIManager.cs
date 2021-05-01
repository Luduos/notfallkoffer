using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WimmelUIManager : MonoBehaviour
{
    public static WimmelUIManager instance;
    public GameObject hiddenCatIconPrefab;
    public GameObject hiddenCatsIconHolder;

    private List<GameObject> hiddenCatsIconList;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != null)
            Destroy(gameObject);

        hiddenCatsIconList = new List<GameObject>();
    }

    public void PopulateHiddenCatIcon(List<HiddenCatsData> activeHiddenCatsList)
    {
        hiddenCatsIconList.Clear();

        for (int i = 0; i < activeHiddenCatsList.Count; i++)
        {
            GameObject icon = Instantiate(hiddenCatIconPrefab, hiddenCatsIconHolder.transform);
            icon.name = activeHiddenCatsList[i].catObject.name;
            Image catImage = icon.gameObject.GetComponent<Image>();

            catImage.sprite = activeHiddenCatsList[i].catObject.GetComponent<SpriteRenderer>().sprite;

            hiddenCatsIconList.Add(icon);
        }
    }

    public void CheckSelectedHiddenCat(string objectName)
    {
        for (int i = 0; i < hiddenCatsIconList.Count; i++)
        {
            if(hiddenCatsIconList[i].name == objectName)
            {
                LeanTween.scale(hiddenCatsIconList[i], Vector3.zero, .1f).setOnComplete(() => hiddenCatsIconList[i].SetActive(false));           
                break;
            }
        }
    }
   


}
