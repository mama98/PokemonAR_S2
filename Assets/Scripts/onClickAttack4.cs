using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // IMPORTANT!!!!!!!!

public class onClickAttack4 : MonoBehaviour
{
    public GameObject Pkm_attacker;
    public GameObject BattleState;
    public GameObject Pkm_attacked;
    public GameObject OuterDialogueBox;
    public GameObject DialogueText;

    private Text DialogueToDisp;  // public if you want to drag your text object in there manually
    // Start is called before the first frame update

    public void onClickAttaque4()
    {
        BattleState.GetComponent<BattleManagerMachine>().manager.GetComponent<BattleManager>().currentState = BattleManager.BattleStates.ANIMATION;
        DialogueToDisp = DialogueText.GetComponent<Text>();
        OuterDialogueBox.SetActive(true);
        DialogueToDisp.text = "Charmander attacks with Scorch!";
        StartCoroutine(Test());
    }

    IEnumerator Test()
    {
        yield return new WaitForSeconds(2);
        OuterDialogueBox.SetActive(false);
        Pkm_attacked.GetComponent<HeroStateMachine>().hero.health_points = Pkm_attacked.GetComponent<HeroStateMachine>().hero.health_points - Pkm_attacker.GetComponent<HeroStateMachine>().hero.damage_attack4;

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
