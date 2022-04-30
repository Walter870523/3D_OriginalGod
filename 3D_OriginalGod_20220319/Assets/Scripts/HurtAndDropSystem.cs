using UnityEngine;

namespace Walter
{
    /// <summary>
    /// 
    /// </summary>
    public class HurtAndDropSystem : HurtSystem
    {
        [SerializeField, Header("�ĤH���")]
        private DataEnemy data;
        [SerializeField, Header("�e���ĤH���")]
        private Transform traCanvasHp;

        /// <summary>
        /// ��v��
        /// </summary>
        private Transform traCamera;

        private void Awake()
        {
            traCamera = GameObject.Find("��v��").transform;
        }

        private void Update()
        {
            CanvasHpLookCamera();
        }

        /// <summary>
        /// �e����� ���V ��v��
        /// </summary>
        private void CanvasHpLookCamera()
        {
            traCanvasHp.eulerAngles = traCamera.eulerAngles;
        }
    }
}
