using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gold : MonoBehaviour
{
    private com comScript;
    private user userScript;
    private TimerBar timerScript;

    private bool isInsideBox = false; // ���� �ȿ� �ִ��� ����
    private bool BoxCenter = false; // ���� �߾ӿ� �ִ��� ����

    private float moveSpeed = 20f; // �̵� �ӵ�
    private float wait_time = 3f; // ��� �ð�
    private float minus_time = 0f; // �ð� ����
    public void time_down_func()
    {
        
        for (int i = 0; i <= GameObject.Find("Center").GetComponent<TimerBar>().time_down_count; i += 5)
        {
            if (wait_time >= 0.5f|| moveSpeed>=3.5f || GameObject.Find("Spawner").GetComponent<spawner>().currentCoolTime<= 0.25f)
            {
                wait_time-= 0.2f;
            }
            else
            {
                
            }
          

            
        }
    }

  
      
    
    private void Start()
    {
        
      time_down_func();
        comScript = FindObjectOfType<com>();
        userScript = FindObjectOfType<user>();
        timerScript = FindObjectOfType<TimerBar>();
    }

    private void waiting()
    {
        Destroy(gameObject);
  //      userScript.DefenseFail(10);

        GameObject.Find("Canvas").GetComponent<GameManager>().key_move_bool = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Box"))
        {
            isInsideBox = true; // ���� �ȿ� ��
           
        }
        else if (collision.CompareTag("Center"))
        {
            // Ű �̵� ���θ� false�� �����Ͽ� ��� ����
            GameObject.Find("Canvas").GetComponent<GameManager>().key_move_bool = false;
            Invoke("waiting", wait_time - minus_time); // ������ ��� �ð� ���Ŀ� waiting �Լ� ȣ��
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Box"))
        {
            isInsideBox = false; // ���ڿ��� ����
        }
        else if (collision.CompareTag("Center"))
        {
            BoxCenter = false; // �߾ӿ��� ����
        }
     
    }

    private void Update()
    {
        
        if (GameObject.Find("Canvas").GetComponent<GameManager>().slow_lv)
        {
            wait_time =2f;
        }
       
        Collider2D itemCollider = GetComponent<Collider2D>();
        Collider2D boxCollider = GameObject.FindGameObjectWithTag("Box").GetComponent<Collider2D>();

        if (GameObject.Find("Canvas").GetComponent<GameManager>().key_move_bool == false)
        {
            // ������Ʈ�� ���� �ȿ� �����Ƿ� �̵��� ����
            // ������Ʈ�� ���� �ȿ� ���� �� �߰����� �ڵ带 ���� �� ����
        }
        else
        {
            // ������Ʈ�� ���� �ȿ� �����Ƿ� ���ʿ��� ���������� ������ �ӵ��� �̵�
            Vector3 newPosition = transform.position + Vector3.right * moveSpeed * Time.deltaTime;
            transform.position = newPosition;
        }

        if (isInsideBox && Input.GetKeyDown(KeyCode.G))
        {
            GameObject.Find("Canvas").GetComponent<GameManager>().key_move_bool = true;
            
            if (boxCollider.bounds.Contains(itemCollider.bounds.min) && boxCollider.bounds.Contains(itemCollider.bounds.max))
            {
                GameObject.Find("Com").GetComponent<com>().G+=50;
                GameObject.Find("Com").GetComponent<com>().txtload();
                Destroy(gameObject);
                timerScript.OnDestroy();
            }
        }
       
    }
}
