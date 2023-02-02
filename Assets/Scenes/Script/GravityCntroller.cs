using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityCntroller : MonoBehaviour
{
    //重力加速度
    const float Gravity = 9.81f;
    //重力の適用具合
    public float gravityScale = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vector = new Vector3();
        //キーの入力を検知しベクトルを設定検
        vector.x = Input.GetAxis("Horizontal");
        vector.z = Input.GetAxis("Vertical");

        //高さ方向の判定はキーのzとする
        if(Input.GetKey("z"))
        {
            vector.y = 1.0f;
        }
        else
        {
            vector.y = -1.0f;    
        }
        //シーンの重力を入力ベクトルの方向に合わせて変化させる
        Physics.gravity = Gravity * vector.normalized * gravityScale;

    }
}
