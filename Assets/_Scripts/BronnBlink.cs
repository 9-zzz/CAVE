using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BronnBlink : MonoBehaviour
{

    Image blinky;
    public Slider blinkbar;

    void Awake()
    {
        blinky = GameObject.Find("blinky").GetComponent<Image>();
    }

    // Use this for initialization
    void Start()
    {
        Color tmp = new Color(0, 0, 0, 1);
        blinky.color = tmp;
        blinky.CrossFadeAlpha(0, 0, true);
        StartCoroutine(blinker());
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.B))
        {
            blinkbar.value = 0;
        }
    }

    IEnumerator blinker()
    {
        while (true)
        {
            if(blinkbar.value > 0)
            {
            yield return new WaitForSeconds(1);
            blinkbar.value -= 1;
            }

            if(blinkbar.value == 0)
            {
            blinky.CrossFadeAlpha(1, 0.25f, true);
            yield return new WaitForSeconds(0.35f);
            blinky.CrossFadeAlpha(0, 0.15f, true);
            blinkbar.value = blinkbar.maxValue;
            }
        }

    }

}