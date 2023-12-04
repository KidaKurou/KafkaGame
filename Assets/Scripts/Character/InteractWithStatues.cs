using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractWithStatues : MonoBehaviour
{
    [SerializeField] private List<string> interactiveStatues = null;
    [SerializeField] private Text tipText = null;
    [SerializeField] private SwitcherPlayer switcherPlayer = null;
    private int isPlayerNear = 0;
    private GameObject statue;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == interactiveStatues[0])
        {
            TextString();
            statue = collision.gameObject.transform.parent.gameObject;
            isPlayerNear = 1;
        }
        else if(collision.gameObject.tag == interactiveStatues[1])
        {
            TextString();
            statue = collision.gameObject.transform.parent.gameObject;
            isPlayerNear = 2;
        }
        else if(collision.gameObject.tag == interactiveStatues[2])
        {
            TextString();
            statue = collision.gameObject.transform.parent.gameObject;
            isPlayerNear = 3;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
         isPlayerNear = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            switch (isPlayerNear)
            {
                case 1:
                    switcherPlayer.SwitchPlayer(1);
                    transform.parent = statue.transform;
                    break;
                case 2:
                    switcherPlayer.SwitchPlayer(2);
                    transform.parent = statue.transform;
                    break;
                case 3:
                    switcherPlayer.SwitchPlayer(3);
                    transform.parent = statue.transform;
                    break;
            }
        }
    }

    private void TextString()
    {
        tipText.text = "press R";
        tipText.color = Color.green;
        tipText.gameObject.SetActive(true);
    }
}
