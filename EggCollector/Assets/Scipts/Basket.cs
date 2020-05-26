
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour
{
    public Text scoreGT;
    int score;

    private void Start()
    {
        score = 0;

        //find reference to scoreCounter object
        GameObject ScoreGO = GameObject.Find("ScoreCounter");

        //assign scoreCounter's text to scoreGT
        scoreGT = ScoreGO.GetComponent<Text>();

        //initialize the starting score to "0"
        scoreGT.text = "Score: 0";
    }

    // Update is called once per frame
    void Update()
    {
         //gets current screen position of mouse
        Vector3 mouse2D = Input.mousePosition;

        //camera's z-position sets how far to push the mouse into 3D
        mouse2D.z = -Camera.main.transform.position.z;
          
        //Convert the point from 2D screen space into 3D game world space
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mouse2D);

        //move the x position of the basket to that of the mouse
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;

    }

    private void OnCollisionEnter(Collision collision)
    {
        //Find out what hit the basket
        GameObject collidedWith = collision.gameObject;

        if (collidedWith.tag == "Egg" || collidedWith.tag == "Red Egg")
        {
            Destroy(collidedWith);
        }

        score += 1;
        //convert score back to a string and display it
        scoreGT.text = "Score: " + score;

        //track the high score
        if (score > ScoreManager.highScore)
        {
            ScoreManager.highScore = score;
        }
    }
}
