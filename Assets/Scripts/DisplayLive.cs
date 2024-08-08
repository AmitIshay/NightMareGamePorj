using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Add this to use the Text component

public class DisplayLive : MonoBehaviour
{
    public Text liveText;
    public bool enterance=false;
    int lives = 3;
    [SerializeField] float impactTime = 0.6f;


    // Start is called before the first frame update
    void Start()
    {
        liveText.enabled = false;
    }

    public void ShowDamageImpactt()
    {
        StartCoroutine(ShowSplatter());
    }
    IEnumerator ShowSplatter() {
        UpdateLiveText(); // Update the liveText with the current lives
        liveText.enabled = true;
        yield return new WaitForSeconds(impactTime);
        liveText.enabled = false;
    }
        void UpdateLiveText()
    {
        lives--;
        liveText.text = "You left with " + lives + " lives";
    }
}
