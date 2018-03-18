using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour {
    private CharacterMove move;
    private Animation animation;

	// Use this for initialization
	void Start () {
        move = GetComponent<CharacterMove>();
        animation = GetComponent<Animation>();
	}

    // LateUpdate 运行稍晚于 Update
	void LateUpdate () {
        if (move.state == CharacterState.Moving)    // 移动状态
        {
            PlayAnimation("Run");
        }
        else if(move.state == CharacterState.Idle)  // 静止状态
        {
            PlayAnimation("Idle");
        }
	}

    // 播放animationName动画
    void PlayAnimation(string animationName)
    {
        animation.CrossFade(animationName, 0.1f);
    }
}
