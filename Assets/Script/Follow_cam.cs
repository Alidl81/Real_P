using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow_cam : MonoBehaviour
{
    public Transform target;
    public Transform cam;
    public Camera camCamera;
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (camCamera.orthographicSize == 4.5)
        {
            cam.position = new Vector3(28, 2.2f, -10);

        }
        else
        {
            cam.position = new Vector3(target.position.x, target.position.y + 1, -10);
        }
    }
 

}
