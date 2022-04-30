using UnityEngine;

namespace Walter
{
    /// <summary>
    /// 
    /// </summary>
    public class HurtAndDropSystem : HurtSystem
    {
        [SerializeField, Header("敵人資料")]
        private DataEnemy data;
        [SerializeField, Header("畫布敵人血條")]
        private Transform traCanvasHp;

        /// <summary>
        /// 攝影機
        /// </summary>
        private Transform traCamera;

        private void Awake()
        {
            traCamera = GameObject.Find("攝影機").transform;
        }

        private void Update()
        {
            CanvasHpLookCamera();
        }

        /// <summary>
        /// 畫布血條 面向 攝影機
        /// </summary>
        private void CanvasHpLookCamera()
        {
            traCanvasHp.eulerAngles = traCamera.eulerAngles;
        }
    }
}
