using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {
    private Transform player;
    private Vector3 offset;

    public float distance = 0;
    public float scrollSpeed = 10;

    private bool isRotate = false;
    public float rotateSpeed = 2;

	// Use this for initialization
	void Start () {
        // 获取人物位置
        player = GameObject.FindGameObjectWithTag(Tags.player).transform;
        offset = transform.position - player.position;          // 人物位置与相机偏移
        transform.LookAt(player);                               // 相机看向人物
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = player.position + offset;          // 相机跟随人物
        ScrollView();
        RotateView();
	}

    // 鼠标中轴控制视野的远近
    void ScrollView()
    {
        distance = offset.magnitude;                     // 相机与人物的距离
        // 根据中轴控制视野远近
        distance += Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;
        distance = Mathf.Clamp(distance, 3, 18);
        offset = offset.normalized * distance;
    }

    // 控制视野旋转
    void RotateView()
    {
        if (Input.GetMouseButtonDown(0) && !UICamera.isOverUI)        // 监听鼠标左键
        {
            isRotate = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            isRotate = false;
        }
        if (isRotate)
        {
            // 以人物为中心，绕y轴旋转
            transform.RotateAround(player.position, Vector3.up, Input.GetAxis("Mouse X")*rotateSpeed);
            Vector3 originalPos = transform.position;           // 记录当前位置和旋转
            Quaternion originalRot = transform.rotation;
            // 以人物为中心，绕视野x轴旋转
            transform.RotateAround(player.position, transform.right, -Input.GetAxis("Mouse Y")*rotateSpeed);
            float x = transform.eulerAngles.x;
            if (x < 10 || x > 80)                               // 控制上下旋转范围
            {
                transform.position = originalPos;
                transform.rotation = originalRot;
            }

            offset = transform.position - player.position;
        }
    }
}
