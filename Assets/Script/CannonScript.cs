using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CannonScript : MonoBehaviour
{
    public Slider forceSlider;

    public GameObject Ball;
    public Transform ballPos;

    public int cannonForce;

    private void Start()
    {
        cannonForce = 5;
        //this.transform.rotation = Quaternion.AngleAxis(90, Vector3.forward);
        //Debug.Log(spdPoints);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject NewBall = Instantiate(Ball, ballPos.position, ballPos.rotation);
            NewBall.GetComponent<Rigidbody>().AddRelativeForce(Vector3.right * cannonForce * 500, ForceMode.Impulse);
        }
    }

    private void FixedUpdate()
    {
        //Debug.Log(transform.rotation.z);
        float horizontalMove = Input.GetAxisRaw("Horizontal");
        if (transform.rotation.z < -0.01256293f && horizontalMove < 0)
        {
            horizontalMove = 0;
            //transform.Rotate(0, 0, horizontalMove);
        }
        else if (transform.rotation.z > 0.1103964f && horizontalMove > 0)
        {
            horizontalMove = 0;
            //transform.Rotate(0, 0, horizontalMove);
        }
        transform.Rotate(0, 0, horizontalMove);
        cannonForce += (int)Input.GetAxisRaw("Vertical") * 10;
        forceSlider.value = cannonForce/10;
    }

    public void SetCannonForce()
    {
        cannonForce = (int)forceSlider.value * 10;
    }
}
