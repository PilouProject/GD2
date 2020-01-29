using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    public GameObject Player; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FireAttack()
    {
        Animator m_animator = Player.GetComponent<Animator>();
        m_animator.SetTrigger("attack");
    }

    public void FireSpecial()
    {
        Animator m_animator = Player.GetComponent<Animator>();
        m_animator.SetTrigger("special");
    }

    public void FireDeath()
    {
        Animator m_animator = Player.GetComponent<Animator>();
        m_animator.SetBool("death", true);
    }
}
