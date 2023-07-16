using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xThrow = Input.GetAxis("Horizontal");
        float yThrow = Input.GetAxis("Vertical");
        float offset = 0.1f;
        float xPos = transform.localPosition.x;
        float yPos = transform.localPosition.y;
        float zPos = transform.localPosition.z;
        
        
        if(Input.GetKey(KeyCode.D))
        {
            xPos += offset;
        }
        else if(Input.GetKey(KeyCode.A))
        {
            xPos -= offset;
        }
        
        if(Input.GetKey(KeyCode.W))
        {
            yPos += offset;
        }
        else if(Input.GetKey(KeyCode.S))
        {
            yPos -= offset;
        }

        if(Input.GetKey(KeyCode.RightArrow))
        {
            xPos += offset;
        }
        else if(Input.GetKey(KeyCode.LeftArrow))
        {
            xPos -= offset;
        }
        
        if(Input.GetKey(KeyCode.UpArrow))
        {
            yPos += offset;
        }
        else if(Input.GetKey(KeyCode.DownArrow))
        {
            yPos -= offset;
        }

        transform.localPosition = new Vector3(xPos, yPos, zPos);
    }
}
