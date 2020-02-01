using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    Animator m_animator;

    // Start is called before the first frame update
    void Start()
    {
        m_animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void handleAnim(int stance)
    {
        switch (stance)
        {
            case 1:
                FireAttack();
                break;
            case 2:
                FireDefense();
                break;
            case 3:
                FireAttack();
                break;
        }
    }

    public void FireAttack()
    {
        m_animator.SetTrigger("attack");
    }

    public void FireSpecial()
    {
        m_animator.SetTrigger("special");
    }

    public void FireDeath()
    {
        m_animator.SetBool("death", true);
    }

    public void FireHit()
    {
        m_animator.SetTrigger("hit");
    }

    public void FireDefense()
    {
        m_animator.SetTrigger("defense");
    }

    public void FireVictory()
    {
        m_animator.SetBool("victory", true);
    }
}
