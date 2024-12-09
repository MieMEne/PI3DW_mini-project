using System.Collections;
using System.Collections.Generic;
using TMPro; 
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public GameObject Panel;
    public GameObject restartButton;
    private float delay = 1.5f;

    public RectTransform score; // Assign the UI element in inspector

    public Vector2 newSize = new Vector2(400, 100); // New size for text element
    public Vector3 newPosition = new Vector3(33, 13, 0); // New position for text element
    public TextMeshProUGUI uiText; // Assign TextMeshPro element in inspector
    public int newFontSize = 50;


    // Start is called before the first frame update
    void Start()
    {
        Panel.SetActive(false);
        restartButton.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("finishLine"))
        {
            StartCoroutine(delayScreen());
        }
    }

    private IEnumerator delayScreen()
    {
        yield return new WaitForSeconds(delay);
        showReplayScreen();
    }

    public void showReplayScreen()
    {
        Panel.SetActive(true);
        restartButton.SetActive(true);
        score.sizeDelta = newSize;
        score.anchoredPosition = newPosition;
        uiText.fontSize = newFontSize;
    }

    public void HideReplayScreen()
    {
        Panel.SetActive(false);
        restartButton.SetActive(false);
    }
}
// Some code has been inspired by chatGPT