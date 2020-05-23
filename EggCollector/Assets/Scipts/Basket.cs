
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{

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

        if (collidedWith.tag == "Egg")
        {
            Destroy(collidedWith);
        }
    }
}
