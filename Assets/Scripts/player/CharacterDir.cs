using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDir : MonoBehaviour {
    public GameObject effectClickPrefab;
    private bool isMoving = false;
    [HideInInspector]
    public Vector3 targetPos = Vector3.zero;

    private CharacterMove move;

    void Start()
    {
        targetPos = transform.position;
        move = GetComponent<CharacterMove>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            bool isCollider = Physics.Raycast(ray, out hitInfo);
            if (isCollider && hitInfo.collider.tag == Tags.ground)
            {
                isMoving = true;
                targetPos = hitInfo.point;
                ShowEffectClick(targetPos);
                LookAtTarget(targetPos);
            }
        }
        if (Input.GetMouseButtonUp(1))
        {
            isMoving = false;
        }
        if (isMoving)
        {
            // 射线检测
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            bool isCollider = Physics.Raycast(ray, out hitInfo);
            if (isCollider && hitInfo.collider.tag == Tags.ground)
            {
                targetPos = hitInfo.point;
                LookAtTarget(targetPos);        // 朝向目标位置
            }
        }
        else
        {
            if (move.isMoving)
            {
                LookAtTarget(targetPos);
            }
        }
     }

    void ShowEffectClick(Vector3 pos)
    {
        pos.y += 0.2f;
        GameObject.Instantiate(effectClickPrefab, pos, Quaternion.identity);
    }

    // 朝向目标位置
    void LookAtTarget(Vector3 target)
    {
        target.y = transform.position.y;        // 绕y轴旋转，注意高度要保持一致
        transform.LookAt(target);               // 朝向目标
    }
}
