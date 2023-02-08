using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    public GameObject Camera;
    public bool Entered;
    // Start is called before the first frame update
    void Start()
    {
        Entered = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(Entered == false)
        {
            Camera.SetActive(false);
            Entered = true;
        }
        else
        {
            Camera.SetActive(true);
            Entered = false;
        }

    }

}
