using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class KillAllScript : MonoBehaviour
{
    public Text hellText;
    public float fadeSpeed = 5;
     public bool enterance=false;
    // Start is called before the first frame update
    void Start()
    {
        hellText.color = Color.white;

    }

    // Update is called once per frame
    void Update()
    {
        ColorChange();
    }

    void OnTriggerEnter(Collider col){
        //timerIsRunning = true;
        if (col.gameObject.tag == "Player")  enterance = true;
    }
    void OnTriggerExit(Collider col) {
        if (col.gameObject.tag == "Player")  enterance = false;
     }
    private void ColorChange(){
      if (enterance)
        hellText.color = Color.Lerp(hellText.color, Color.white, fadeSpeed *Time.deltaTime);
      if (!enterance)
        hellText.color = Color.Lerp(hellText.color, Color.clear, fadeSpeed *Time.deltaTime);
    }
}
