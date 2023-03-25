using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float RotationSpeed;
    public Transform Ltarget;
    public Transform Rtarget;
    private Vector3 zAxis = new Vector3(0, 0, 1);
    bool GoLeft = false;
    bool GoRight = false;
    public GameObject BaseSpawn;

    public int score;

    // only one key will move fish
    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) & !Input.GetKey(KeyCode.RightArrow))
        {
            GoLeft = true;
        }
        else if (Input.GetKey(KeyCode.RightArrow) & !Input.GetKey(KeyCode.LeftArrow))
        {
            GoRight = true;
        }

        //out of bounds reset
        if (transform.position.y > 20 || transform.position.y < -20 || transform.position.x > 45 || transform.position.x < -45)
        {
            transform.position = new Vector3(0, 0, 0);
            transform.rotation = new Quaternion(0, 0, 180, 0);
            Rtarget.transform.position = new Vector3(2f, .5f, 0);
            Ltarget.transform.position = new Vector3(-2f, .5f, 0);
        }

        //end goal
        if (score == 5)
        {
            Instantiate(BaseSpawn, new Vector3(0, 0, 0), Quaternion.identity);
            score += 1;
        }
    }

    // Fish rotates around either left or right targets
    // zAxis modifies whether it is clockwise or counterclockwise
    // Left and right targets also rotate relative to the other
    void FixedUpdate()
    {
        if (GoLeft)
        {
            transform.RotateAround(Ltarget.position, zAxis, RotationSpeed);
            Rtarget.transform.RotateAround(Ltarget.position, zAxis, RotationSpeed);
            GoLeft = false;
        }
        else if (GoRight)
        {
            transform.RotateAround(Rtarget.position, -zAxis, RotationSpeed);
            Ltarget.transform.RotateAround(Rtarget.position, -zAxis, RotationSpeed);
            GoRight = false;
        }
    }
    public void AddScore (int amount)
    {
        score += amount;
    }
}
