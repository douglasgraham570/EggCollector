using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject basketPrefab;
    public int numBaskets = 3;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;
    public List<GameObject> basketList;

    // Start is called before the first frame update
    void Start()
    {

        basketList = new List<GameObject>();

        for (int i = 0; i < numBaskets; i++)
        {
            GameObject tBasketGO = Instantiate(basketPrefab) as GameObject;
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO);
        }
    }

    public void EggDestroyed()
    {
        //destroy all of the falling eggs
        GameObject[] tEggArray = GameObject.FindGameObjectsWithTag("Egg");

        foreach (GameObject tGO in tEggArray)
        {
            Destroy(tGO);
        }

        Debug.Log(basketList.Count);


            //Destroy one of the baskets

            //Get the index of the last basket
            int basketIndex = basketList.Count - 1;

            //Get a reference to the last basket by using index
            GameObject tBasketGO = basketList[basketIndex];
            //Remove the basket from the list and destroy the gameObject

            basketList.RemoveAt(basketIndex);
            Destroy(tBasketGO);

            //Reset the game if we run out of baskets
            if (basketList.Count == 0)
            {
                SceneManager.LoadScene("_Scene_1");
            }
        //}
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(basketList.Count);
    }
}
