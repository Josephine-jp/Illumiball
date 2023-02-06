using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    //ホールがどのボールを吸い寄せるかタグで指定
    public string targetTag;
    bool isHolding;

    public bool IsHolding()
    {
        return isHolding;
    }
    
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == targetTag)
        {
            isHolding = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == targetTag)
        {
            isHolding = false;
        }
    }


    void OnTriggerStay(Collider other) 
    {
        //コライダに触れているオブジェクトのRigitbodyコンポーネントを取得
        Rigidbody r = other.gameObject.GetComponent<Rigidbody>();

        //ボールのある方向を計算
        Vector3 direction = other.gameObject.transform.position - transform.position;
        direction.Normalize();

        //タグに応じてのホールの挙動
        if (other.gameObject.tag == targetTag)
        {
            //中心でボールを止めるため減速させる
            r.velocity *= 0.9f;
            r.AddForce(direction * -20.0f,ForceMode.Acceleration);
        }
        else
        {
            r.AddForce(direction * 80.0f,ForceMode.Acceleration);
        }
    }
}
