using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharacterState
{
    Moving,
    Idle
}

public class CharacterMove : MonoBehaviour {
    public float speed = 3;
    private CharacterDir dir;
    private CharacterController controller;
    [HideInInspector]
    public CharacterState state;
    [HideInInspector]
    public bool isMoving = false;

	// Use this for initialization
	void Start () {
        dir = GetComponent<CharacterDir>();
        controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        // 得到当前位置与目标位置的距离
        float distance = Vector3.Distance(dir.targetPos, transform.position);
        if (distance > 0.1f)        // 若没有到达目标位置
        {
            // 简单移动
            controller.SimpleMove(transform.forward * speed);
            state = CharacterState.Moving;
            isMoving = true;
        }
        else
        {
            state = CharacterState.Idle;
            isMoving = false;
        }
	}
}
