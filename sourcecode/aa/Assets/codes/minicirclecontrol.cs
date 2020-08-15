using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minicirclecontrol : MonoBehaviour
{
    Rigidbody2D phy;
    public float speed;
    bool motioncontrol = false;
    GameObject gamecontrol;
    void Start()
    {
        phy = GetComponent<Rigidbody2D>();
        gamecontrol = GameObject.FindGameObjectWithTag("gamecontroltag");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!motioncontrol)
        {
            phy.MovePosition(phy.position + Vector2.up * speed * Time.deltaTime);
        }
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "rotatingcircletag")
        {
            transform.SetParent(col.transform);
            motioncontrol = true;
        }
        if(col.tag == "minicircletag")
        {
            gamecontrol.GetComponent<gameControl>().firstgameOver();
        }
    }
}
