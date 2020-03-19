using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // IMPORTANT!!!!!!!!

public class EnnemyAttack : MonoBehaviour
{
    public GameObject Pkm_attacker;
    public GameObject BattleState;
    public GameObject Pkm_attacked;
    public GameObject OuterDialogueBox;
    public GameObject DialogueText;
    // Start is called before the first frame update

    void Start()
    {

    }

    private Text DialogueToDisp;  // public if you want to drag your text object in there manually

    public void EnemyAttaque()
    {
        BattleState.GetComponent<BattleManagerMachine>().manager.GetComponent<BattleManager>().currentState = BattleManager.BattleStates.ANIMATION;
        DialogueToDisp = DialogueText.GetComponent<Text>();
        OuterDialogueBox.SetActive(true);
        DialogueToDisp.text = "Bulbasaur attacks with Slam!";
        StartCoroutine(Test());
    }

    IEnumerator Test()
    {
        yield return new WaitForSeconds(2);
        OuterDialogueBox.SetActive(false);
        Pkm_attacked.GetComponent<HeroStateMachine>().hero.health_points = Pkm_attacked.GetComponent<HeroStateMachine>().hero.health_points - Pkm_attacker.GetComponent<HeroStateMachine>().hero.damage_attack1;

        if (Pkm_attacked.GetComponent<HeroStateMachine>().hero.health_points <= 0)
        {
            Pkm_attacked.GetComponent<HeroStateMachine>().hero.health_points = 0;
            BattleState.GetComponent<BattleManagerMachine>().manager.GetComponent<BattleManager>().currentState = BattleManager.BattleStates.LOSE;
            Pkm_attacked.SetActive(false);
        }
        else
        {
            BattleState.GetComponent<BattleManagerMachine>().manager.GetComponent<BattleManager>().currentState = BattleManager.BattleStates.PLAYERCHOICE;
        }
    }
}
/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // IMPORTANT!!!!!!!!

public class EnnemyAttack : MonoBehaviour
{
    public GameObject Pkm_attacker;
    public GameObject BattleState;
    public GameObject Pkm_attacked;
    public GameObject OuterDialogueBox;
    public GameObject DialogueText;
    public GameObject attaque;
    public GameObject sac;

    private Text DialogueToDisp;  // public if you want to drag your text object in there manually
    // Start is called before the first frame update

    public void onClickEnnemyAttack()
    {
        BattleState.GetComponent<BattleManagerMachine>().manager.GetComponent<BattleManager>().currentState = BattleManager.BattleStates.ANIMATION;
        DialogueToDisp = DialogueText.GetComponent<Text>();
        OuterDialogueBox.SetActive(true);
        DialogueToDisp.text = "Bulbasaur attacks with Slam!";
        StartCoroutine(Test());
    }

    IEnumerator Test()
    {
        yield return new WaitForSeconds(2);
        OuterDialogueBox.SetActive(false);
        Pkm_attacked.GetComponent<HeroStateMachine>().hero.health_points = Pkm_attacked.GetComponent<HeroStateMachine>().hero.health_points - Pkm_attacker.GetComponent<HeroStateMachine>().hero.damage_attack1;

        if (Pkm_attacked.GetComponent<HeroStateMachine>().hero.health_points <= 0)
        {
            Pkm_attacked.GetComponent<HeroStateMachine>().hero.health_points = 0;
            BattleState.GetComponent<BattleManagerMachine>().manager.GetComponent<BattleManager>().currentState = BattleManager.BattleStates.WIN;
            Pkm_attacked.SetActive(false);
        }
        else
        {
            BattleState.GetComponent<BattleManagerMachine>().manager.GetComponent<BattleManager>().currentState = BattleManager.BattleStates.ENEMYCHOICE;
        }
    }

}
 
*/
