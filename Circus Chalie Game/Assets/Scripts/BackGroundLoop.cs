using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundLoop : MonoBehaviour
{
    public GameObject FinishBackGroundPrefab;

    private float width;
    private float width_add;

    private void Awake()
    {
        BoxCollider2D backgroundCollider = GetComponent<BoxCollider2D>();
        width = backgroundCollider.size.x;
        width_add = width * 2.5f;
    }
    void Start()
    {

    }

    void Update()
    {
        if (transform.position.x <= -width_add)
        {
            if (GameManager.instance.max_loop == true) { return; }

            if (GameManager.instance.loop_count < 1)
            {
                GameManager.instance.loop_count += 1;
                Reposition();
            }
            else if (GameManager.instance.loop_count >= 1)
            {
                GameManager.instance.max_loop = true;
                LastPosition();
            }
        }
    }

    //   두 벡터를 더한다.
    private void Reposition()
    {
        Vector2 offset = new Vector2((width * 6f) - 0.02f, 0);
        transform.position = transform.position.AddVector(offset);
        Debug.LogFormat("현재 loop_count는 : {0}", GameManager.instance.loop_count);
    }

    private void LastPosition()
    {
        Debug.Log("작동중이다");
        Vector2 offset = new Vector2((width * 3.5f) - 0.03f, +0.02f);
        GameObject finish_back_ground = Instantiate(FinishBackGroundPrefab, offset, transform.rotation);
    }
}
