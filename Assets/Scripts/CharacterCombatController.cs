using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCombatController : MonoBehaviour
{
    [Range (0.2f, 1.4f)]
    public float attackCD = 0.5f;

    private float timeSinceLastAttack;
    private CharacterMoveController cMV;

    // Start is called before the first frame update
    void Start()
    {
        cMV = GetComponent<CharacterMoveController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!cMV.IsGrounded && Input.GetMouseButtonDown(0) && timeSinceLastAttack > attackCD)
        {
            Attack();
        }
        updateRef();
    }

    private void UpdateAnim()
    {   
        cMV.Anim.SetTrigger("attack");
    }

    private void Attack()
    {
        UpdateAnim();
        timeSinceLastAttack = 0.0f;
    }

    private void updateRef()
    {
        timeSinceLastAttack += Time.deltaTime;
    }

}
