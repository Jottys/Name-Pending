using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraChange : MonoBehaviour
{
    public GameObject MainCamera;
    private bool Entered;
    public bool Cut;
    private CinemachineBrain brain;


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
            if(Cut == true)
            {
                brain = FindObjectOfType<CinemachineBrain>();
                brain.m_DefaultBlend.m_Time = 0;
            }
            else
            {
                brain.m_DefaultBlend.m_Time = 1;
            }

            MainCamera.SetActive(false);
            Entered = true;
        }
        else
        {

            if (Cut == true)
            {
                brain = FindObjectOfType<CinemachineBrain>();
                brain.m_DefaultBlend.m_Time = 0;
            }
            else
            {
                brain.m_DefaultBlend.m_Time = 1;
            }

            MainCamera.SetActive(true);
            Entered = false;
        }

    }

}
