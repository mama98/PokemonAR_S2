using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // IMPORTANT!!!!!!!!


public class BattleManager : MonoBehaviour
{
    public enum BattleStates
    {
        START,
        PLAYERCHOICE,
        ENEMYCHOICE,
        ANIMATION,
        LOSE,
        WIN
    }

    public BattleStates currentState;
    public GameObject attaque;
    public GameObject sac;
    public GameObject attaque1;
    public GameObject attaque2;
    public GameObject attaque3;
    public GameObject attaque4;
    public GameObject Enemy;
    public GameObject PanelBattleState;
    public GameObject WinOrLoseText;
    public GameObject PanelDialog;
    private Text BattleStateToDisplay;  // public if you want to drag your text object in there manually

    // Start is called before the first frame update
    void Start()
    {
        currentState = BattleStates.START;
        BattleStateToDisplay = WinOrLoseText.GetComponent<Text>();
    }


    // Update is called once per frame
    void Update()
    {
        switch(currentState)
        {
            case (BattleStates.START):
                attaque.SetActive(false);
                sac.SetActive(false);
                PanelDialog.SetActive(true);
                if(Input.GetMouseButtonDown(0))
                {
                    PanelDialog.SetActive(false);
                    currentState = BattleStates.PLAYERCHOICE; 
                }
                break;
            case (BattleStates.PLAYERCHOICE):
                attaque.SetActive(true);
                sac.SetActive(true);
                break;
            case (BattleStates.ANIMATION):
                attaque.SetActive(false);
                sac.SetActive(false);
                attaque1.SetActive(false);
                attaque2.SetActive(false);
                attaque3.SetActive(false);
                attaque4.SetActive(false);
                break;
            case (BattleStates.ENEMYCHOICE):
                attaque.SetActive(false);
                sac.SetActive(false);
                attaque1.SetActive(false);
                attaque2.SetActive(false);
                attaque3.SetActive(false);
                attaque4.SetActive(false);
                Enemy.GetComponent<EnnemyAttack>().EnemyAttaque();
                break;
            case (BattleStates.LOSE):
                attaque.SetActive(false);
                sac.SetActive(false);
                BattleStateToDisplay.text = "You Lose!";
                PanelBattleState.SetActive(true);
                WinOrLoseText.SetActive(true);
                break;
            case (BattleStates.WIN):
                attaque.SetActive(false);
                sac.SetActive(false);
                PanelBattleState.SetActive(true);
                BattleStateToDisplay.text = "You Win!";
                WinOrLoseText.SetActive(true);
                break;
        }
    }
}
