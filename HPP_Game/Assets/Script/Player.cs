using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;

public class Player : MonoBehaviour
{
    

    //���� ����

    public float MoveSpeed = 5f;
    private Rigidbody2D rb;
    private Animator myAnim;
    public PlayerState PlayerStates = new PlayerState();




    private void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.Space) && PlayerStates.IsSit)
        {
            Debug.Log("Is Sitting");
            PlayerStates.IsSit = false;
            MoveSpeed = 300f;
        }
        

    }
    private void Start()
    {
        PlayerStates = FindObjectOfType<PlayerState>();
        rb = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        Move();
        MoveAnim();
    }

    private void Move()
    {

        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized * Time.deltaTime * MoveSpeed ; 
        /*float hor = Input.GetAxisRaw("Horizontal");
        float var = Input.GetAxisRaw("Vertical");
        Vector3 moveVector = new Vector3(hor, var).normalized;
        transform.position += MoveSpeed * moveVector * Time.deltaTime;
        Debug.Log(rb.velocity);*/

    }
    public void SetSit()
    {
       PlayerStates.IsSit = true;

    }
    public void SetIsSit()
    {

    }
    

    public void MoveAnim()
    {
        myAnim.SetFloat("moveX", rb.velocity.x);
        myAnim.SetFloat("moveY",rb.velocity.y);
        if(Input.GetAxisRaw("Horizontal") == 1 | Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            myAnim.SetFloat("LastX", Input.GetAxisRaw("Horizontal"));
            myAnim.SetFloat("LastY", Input.GetAxisRaw("Vertical"));
        }
    }
    

}
