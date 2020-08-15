using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class maincircle : MonoBehaviour
{
    public GameObject minicircle;
    GameObject gamecontrol;

    void Start()
    {
        gamecontrol = GameObject.FindGameObjectWithTag("gamecontroltag");
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            createMiniCircle();
        }
    }

    void createMiniCircle()
    {
        Instantiate(minicircle, transform.position, transform.rotation);
        gamecontrol.GetComponent<gameControl>().circleTexts();
    }
}
