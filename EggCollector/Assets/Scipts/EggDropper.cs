using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggDropper : MonoBehaviour
{
    public GameObject eggPrefab;
    public GameObject redEggPrefab;
    public float speed = 1f;
    public float minTimeBetweenDrops = .25f;
    public float eggDropRatio = .02f;
    public float collisionWidth = 10f;
    public float changeOfDirectionSwitch = 0.1f;
    public float eggOffset = 1f;
    public float elapsedTimeMultiplier = .01f;
    public float eggDropChange = .00001f;
    public float maxDropRatio = .125f;
    public float initialTimeUntilRed = 10f;
    public float redDropRatio = .1f;
    public float redBufferTime = 1f;
    private float elapsedTimeDrops = 0f;
    private float elapsedTimeRed = 0f;
    private float elapsedTime = 0f;


    // Update is called once per frame
    void Update()
    {

        //Basic movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

       //Changing direction
        if (pos.x < -collisionWidth)
        {
            speed = Mathf.Abs(speed); //hits left side
        } else if (pos.x > collisionWidth)
        {
            speed = -Mathf.Abs(speed); //hits right side

        } 
    }

    private void FixedUpdate()
    {
        //increase elapsed time for red egg and egg drops
        elapsedTimeRed += .02f;
        elapsedTimeDrops += .02f;

        if (Random.value < changeOfDirectionSwitch)
        {
            speed *= -1; //Change direction
            elapsedTime += elapsedTimeMultiplier;

            //increases speed in direction the dropper is going
            if (speed < 0)
            {
                speed += Mathf.Log10(elapsedTime);
            }
            else if (speed > 0)
            {
                speed -= Mathf.Log10(elapsedTime);
            }

            //Debug.Log("Current dropper speed: " + speed);

            //Debug.Log("Egg Drop Ratio: " + eggDropRatio);
        }

        //Increase egg drop ratio
        if (eggDropRatio < maxDropRatio)
        {
            eggDropRatio += eggDropChange;
        }



        //drop an egg or red egg if enough time has passed since a red egg

        if (Random.value < eggDropRatio && elapsedTimeDrops > minTimeBetweenDrops) {

            elapsedTimeDrops = 0f;
            //drops a normal egg unless enough time has passed since red is chosen
            if (Random.value < redDropRatio && initialTimeUntilRed < elapsedTimeRed
                && elapsedTimeRed > redBufferTime) {
                DropRedEgg();
                elapsedTimeRed = 0f;
            } else
            {
                DropEgg();
            }

        }
 
    }

    //drops an egg
    void DropEgg()
    {
        GameObject egg = Instantiate(eggPrefab) as GameObject;
        Vector3 posUnder = transform.position;
        posUnder.y -= eggOffset;
        egg.transform.position = posUnder;
    }

    //drops a red egg
    void DropRedEgg()
    {
        GameObject redEgg = Instantiate(redEggPrefab) as GameObject;
        Vector3 posUnder = transform.position;
        posUnder.y -= eggOffset;
        redEgg.transform.position = posUnder;
    }

}
