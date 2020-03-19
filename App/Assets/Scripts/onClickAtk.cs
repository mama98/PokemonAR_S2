using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onClickAtk : MonoBehaviour
{
    public GameObject attaque;
    public GameObject sac;
    public GameObject attaque1;
    public GameObject attaque2;
    public GameObject attaque3;
    public GameObject attaque4;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void onClickAttaque()
    {
        attaque.SetActive(false);
        sac.SetActive(false);
        attaque1.SetActive(true);
        attaque2.SetActive(true);
        attaque3.SetActive(true);
        attaque4.SetActive(true);
    }
}
