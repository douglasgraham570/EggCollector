using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggDropper : MonoBehaviour
{
    public GameObject egg;
    public float speed = 1f;
    public float secondsBetweenDrop = 1f;
    public float collisionWidth = 10f;
    public float changeOfDirectionSwitch = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        //Dropping apples every second

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

        } else if (Random.value < changeOfDirectionSwitch)
        {
            speed *= -1; //Change direction
        }

    }
}
