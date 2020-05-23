using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggDropper : MonoBehaviour
{
    public GameObject eggPrefab;
    public float speed = 1f;
    public float secondsBetweenDrop = 1f;
    public float collisionWidth = 10f;
    public float changeOfDirectionSwitch = 0.1f;
    public float eggOffset = 1f;

    // Start is called before the first frame update
    void Start()
    {
        //Dropping eggs every second
        InvokeRepeating("DropEgg", 2f, secondsBetweenDrop);
    }

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
        if (Random.value < changeOfDirectionSwitch)
        {
            speed *= -1; //Change direction
        }
    }

    void DropEgg()
    {
        GameObject egg = Instantiate(eggPrefab) as GameObject;
        Vector3 posUnder = transform.position;
        posUnder.y -= eggOffset;
        egg.transform.position = posUnder;
    }
}
