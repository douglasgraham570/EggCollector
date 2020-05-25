using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{
    public static float bottomY = -20f;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < bottomY)
        {
            Destroy(this.gameObject);

            //get a reference to the game manager
            GameManager gameManager = Camera.main.GetComponent<GameManager>();

            //call the public eggDestroyed function of the gameManager script
            gameManager.EggDestroyed();
        }
    }
}
