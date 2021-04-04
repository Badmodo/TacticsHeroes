using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatMenu : MonoBehaviour
{
    public static CombatMenu Instance;

    [SerializeField] CanvasGroup cvsGroup;
    [SerializeField] Button btnCombat1;
    [SerializeField] Button btnCombat2;
    [SerializeField] Button btnCombat3;
    [SerializeField] Button btnCombat4;

    Text btnText1;
    Text btnText2;
    Text btnText3;
    Text btnText4;

    Action btnCallback1;
    Action btnCallback2;
    Action btnCallback3;
    Action btnCallback4;

    public void Awake()
    {
        Instance = this;
        btnText1 = btnCombat1.GetComponentInChildren<Text>();
        btnText2 = btnCombat2.GetComponentInChildren<Text>();
        btnText3 = btnCombat3.GetComponentInChildren<Text>();
        btnText4 = btnCombat4.GetComponentInChildren<Text>();
    }

    public void DisplayMenu (Action btnCallback1, Action btnCallback2, 
        Action btnCallback3, Action btnCallback4 )
    {
        cvsGroup.alpha = 1;
        this.btnCallback1 = btnCallback1;
        this.btnCallback2 = btnCallback2;
        this.btnCallback3 = btnCallback3;
        this.btnCallback4 = btnCallback4;
    }

    public void PressedBtn1 ()
    {
        //will be attack
        btnCallback1?.Invoke();
        Hide();
    }

    public void PressedBtn2()
    {
        //will be special attack with a enemry rating
        btnCallback2?.Invoke();
        //Hide();
    }

    public void PressedBtn3()
    {
        //will be an item or spell or block
        btnCallback3?.Invoke();
        Hide();
    }
    public void PressedBtn4()
    {
        //this will skip combat
        btnCallback4?.Invoke();
        Hide();
    }

    void Hide ()
    {
        cvsGroup.alpha = 0;
    }
}
