using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubCookie2 : MonoBehaviour
{
    //変数
    Transform _pos;

    // Start is called before the first frame update
    void Start()
    {
        _pos = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        //指定位置まで行ったら消える
        if(_pos.position.y <-24.0f)
        {
            Destroy(this.gameObject);
        }
    }
}
