using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameControl : MonoBehaviour
{
    GameObject rotatingCircle;
    GameObject mainCircle;
    public Animator animator;
    public Text levelnumber;
    public Text one;
    public Text two;
    public Text three;
    public int circlecount;
    bool control = true;
    void Start()
    {
        PlayerPrefs.SetInt("saveLevel", int.Parse(SceneManager.GetActiveScene().name));
        rotatingCircle = GameObject.FindGameObjectWithTag("rotatingcircletag");
        mainCircle = GameObject.FindGameObjectWithTag("maincircletag");
        levelnumber.text = SceneManager.GetActiveScene().name;

        if(circlecount < 2)
        {
            one.text = circlecount + "";
        }
        else if (circlecount < 3)
        {
            one.text = circlecount + "";
            two.text = (circlecount -1 )  + "";
        }
        else
        {
            one.text = circlecount + "";
            two.text = (circlecount - 1) + "";
            three.text = (circlecount - 2) + "";
        }
    }

    public void circleTexts()
    {
        circlecount--;
        if (circlecount < 2)
        {
            one.text = circlecount + "";
            two.text = "";
            three.text = "";
        }
        else if (circlecount < 3)
        {
            one.text = circlecount + "";
            two.text = (circlecount - 1) + "";
            three.text = "";
        }
        else
        {
            one.text = circlecount + "";
            two.text = (circlecount - 1) + "";
            three.text = (circlecount - 2) + "";
        }
        if(circlecount == 0)
        {
            StartCoroutine(newlevel());
        }
    }
    IEnumerator newlevel()
    {
        rotatingCircle.GetComponent<rotating>().enabled = false;
        mainCircle.GetComponent<maincircle>().enabled = false;
        yield return new WaitForSeconds(1);
        if (control)
        {
            animator.SetTrigger("newlevel");
            yield return new WaitForSeconds(1.5f);
            SceneManager.LoadScene(int.Parse(SceneManager.GetActiveScene().name) + 1);

        }
    }

    public void firstgameOver()
    {
        StartCoroutine(gameOver());
    }

    IEnumerator gameOver()
    {
        rotatingCircle.GetComponent<rotating>().enabled = false;
        mainCircle.GetComponent<maincircle>().enabled = false;
        animator.SetTrigger("gameOver");
        control = false;
        yield return new WaitForSeconds(1);
        
        SceneManager.LoadScene("mainmenu");
    }
}
