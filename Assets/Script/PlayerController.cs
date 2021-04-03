﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : TacticsMove
{
    void Start () 
	{
        //from the parent Tactics move
        Init();
        animator.SetBool("isIdle", true);
    }

    void Update ()
    {
        Debug.DrawRay(transform.position, transform.forward);

        //move or cant move based on whos turn
        if (state == States.Standby)
        {
            return;
        }
        if (state == States.MoveCalculation)
        {
            FindSelectableTiles();
            CheckMouse();
        }
        else if (state == States.Move)
        {
            Move();
        }
    }

    void CheckMouse()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "Tile")
                {
                    Tile t = hit.collider.GetComponent<Tile>();

                    if (t.selectable)
                    {
                        MoveToTile(t);
                        GoToState(States.Move);
                        //StartCoroutine(TestBattle());
                    }
                }
            }
        }
    }
    //IEnumerator TestBattle()
    //{
    //    Debug.Log("Test Battlet in player controller");
    //    yield return new WaitForSeconds(5f);
    //    TurnManager.EndTurn();
    //    //yield return null;
    //}

    #region Combat Variables

    protected override void Attacks()
    {
        GoToState(States.Combat);
        combatMenu.DisplayMenu(() => SkipTurn(), () => SkipTurn(), () => SkipTurn(),
            () => SkipTurn());
    }

    protected void SkipTurn ()
    {
        GoToState(States.Standby);
        TurnManager.EndTurn();
    }



    public void Attack()
    {
        StartCoroutine(attack());
    }

    public IEnumerator attack()
    {
        animator.SetBool("isIdle", false);
        animator.SetBool("isAttacking", true);
        yield return new WaitForSeconds(1.5f);
        animator.SetBool("isAttacking", false);
        animator.SetBool("isIdle", true);

        //attack

        //change state based on what happened
    }

    public void SpecialAttack()
    {
        StartCoroutine(attackSpecial());
    }

    public IEnumerator attackSpecial()
    {
        animator.SetBool("isIdle", false);
        animator.SetBool("isSpecialAttack", true);
        yield return new WaitForSeconds(1.5f);
        animator.SetBool("isSpecialAttack", false);
        animator.SetBool("isIdle", true);

        //special attack 

        //change state based on what happened
    }

    public void TakeHit()
    {
        StartCoroutine(hit());
    }

    public IEnumerator hit()
    {
        animator.SetBool("isIdle", false);
        animator.SetBool("isHit", true);
        yield return new WaitForSeconds(1.5f);
        animator.SetBool("isHit", false);
        animator.SetBool("isIdle", true);

        //takes associated damage

        //change state based on what happened
    }

    public void Die()
    {
        StartCoroutine(die());
    }

    public IEnumerator die()
    {
        animator.SetBool("isIdle", false);
        animator.SetBool("isDead", true);
        yield return new WaitForSeconds(1.5f);

        //Died
    }

    //public bool TakeDamage(int damage)
    //{
    //    //find a way to add current health
    //    currentHp -= damage;

    //    if (currentHp <= 0f)
    //    {
    //        return true;
    //    }
    //    else
    //    {
    //        return false;
    //    }
    //}

    #endregion
}

internal class SelectionFieldAttribute : Attribute
{

}