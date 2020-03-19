using UnityEngine;
using System.Collections;
using UnityEngine.UI;  // IMPORTANT!!!!!!!!


public class HPDisplay : MonoBehaviour
{
    public GameObject Pkm;


    public Text hpToDisplay;  // public if you want to drag your text object in there manually

    void Start()
    {
         hpToDisplay = GetComponent<Text>();  // if you want to reference it by code - tag it if you have several texts
        
    }
    void Update()
   {
        hpToDisplay.text = Pkm.GetComponent<HeroStateMachine>().hero.health_points.ToString();
    }

}