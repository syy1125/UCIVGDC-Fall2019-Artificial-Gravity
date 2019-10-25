using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HoverTextUI : MonoBehaviour
{
    // Start is called before the first frame update
    private Text HoverText;
    void Awake()
    {
        HoverText = GetComponent<Text>();   
    }

    // Update is called once per frame
    void Update()
    {
        HoverText.text = PlayerInteract.HoverText;
    }
}
