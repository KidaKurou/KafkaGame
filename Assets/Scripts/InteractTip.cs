using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractTip : MonoBehaviour
{
    [SerializeField] private Text tipText;
    [SerializeField] private GameObject mirage;
    [SerializeField] private GameObject reality;
    [SerializeField] private float fadeSpeed = 10;
    private bool isPlayerNear = false;
    private bool isMirageActive = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Interact"))
        {
            tipText.text = "press E";
            tipText.color = Color.blue;
            tipText.gameObject.SetActive(true);
            isPlayerNear = true;
            reality = collision.transform.parent.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Interact"))
        {
            tipText.gameObject.SetActive(false);
            isPlayerNear = false;
        }
    }

    private void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {
            isMirageActive = !isMirageActive; // Toggle the state of the mirage
            MirageTransition(isMirageActive);
        }
    }

    private void MirageTransition(bool showMirage)
    {
        if (showMirage)
        {
            // Start showing the mirage
            StartCoroutine(FadeInMirage());
        }
        else
        {
            // Start hiding the mirage
            StartCoroutine(FadeOutMirage());
        }
    }

    private IEnumerator FadeInMirage()
    {
        mirage.SetActive(true); // Make sure the parent object is active
        foreach (Transform child in mirage.transform)
        {
            SpriteRenderer sr = child.GetComponent<SpriteRenderer>();
            if (sr != null)
            {
                for (float alpha = 0f; alpha <= 1f; alpha += Time.deltaTime * fadeSpeed)
                {
                    Color newColor = sr.color;
                    newColor.a = alpha;
                    sr.color = newColor;
                    yield return null;
                }
            }
        }
        foreach (Transform child in reality.transform)
        {
            SpriteRenderer sr = child.GetComponent<SpriteRenderer>();
            if (sr != null)
            {
                for (float alpha = 1f; alpha >= 0f; alpha -= Time.deltaTime * fadeSpeed)
                {
                    Color newColor = sr.color;
                    newColor.a = alpha;
                    sr.color = newColor;
                    yield return null;
                }
            }
        }

    }

    private IEnumerator FadeOutMirage()
    {
        foreach (Transform child in mirage.transform)
        {
            SpriteRenderer sr = child.GetComponent<SpriteRenderer>();
            if (sr != null)
            {
                for (float alpha = 1f; alpha >= 0f; alpha -= Time.deltaTime * fadeSpeed)
                {
                    Color newColor = sr.color;
                    newColor.a = alpha;
                    sr.color = newColor;
                    yield return null;
                }
            }
        }
        mirage.SetActive(false); // Deactivate the parent object after fading out
        foreach (Transform child in reality.transform)
        {
            SpriteRenderer sr = child.GetComponent<SpriteRenderer>();
            if (sr != null)
            {
                for (float alpha = 0f; alpha <= 1f; alpha += Time.deltaTime * fadeSpeed)
                {
                    Color newColor = sr.color;
                    newColor.a = alpha;
                    sr.color = newColor;
                    yield return null;
                }
            }
        }
    }
}
