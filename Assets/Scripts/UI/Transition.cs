using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Transition : MonoBehaviour
{
    // Start is called before the first frame update
    public float TransitionDuration;
    private Image Overlay;
    public bool TransitionIntoLevel = false;
    public static Transition Instance;
    
    void Awake()
    {
        Instance = this;
        Overlay = GetComponent<Image>();
        if(TransitionIntoLevel){
            StartCoroutine(LoadLevel("",true));
        }
    }

   
    public static IEnumerator LoadLevel(string SceneToLoad, bool Reversed){
        if(Transition.Instance == null){
            if(SceneToLoad != "")
                SceneManager.LoadScene(SceneToLoad);
            yield break;
        }

        Image Overlay = Transition.Instance.Overlay;
        float Duration = Transition.Instance.TransitionDuration;
        Overlay.enabled = true;
        float timer = 0;
        while(timer < Duration){
            timer += Time.deltaTime;
            if(!Reversed){
                //transparent to opaque
                Color c = Overlay.color;
                Overlay.color = new Color(c.r,c.g,c.b,timer/Duration);
            } else {
                //opaque to transparent
                Color c = Overlay.color;
                Overlay.color = new Color(c.r,c.g,c.b,1-(timer/Duration));
            }
            yield return new WaitForEndOfFrame();
        }
        if(SceneToLoad != ""){
            SceneManager.LoadScene(SceneToLoad);
        }
    }
}
