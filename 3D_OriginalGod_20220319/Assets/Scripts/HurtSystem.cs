using UnityEngine;
using UnityEngine.UI;

namespace Walter
{
    /// <summary>
    /// ���˨t��
    /// </summary>
    public class HurtSystem : MonoBehaviour
    {
        [SerializeField, Header("��q"), Range(0, 5000)]
        private float hp = 100;
        [Header("�������")]
        [SerializeField]
        private Text textHp;
        [SerializeField]
        private Image ImgHp;

        private float hpMax;

        private void Awake()
        {
            hpMax = hp;
            UpdateHealthUI();
        }

        /// <summary>
        /// ��s��q����
        /// </summary>
        private void UpdateHealthUI()
        {
            textHp.text = hp + " / " + hpMax;
            ImgHp.fillAmount = hp / hpMax;
        }

        public void GetHurt(float damage)
        {
            hp -= damage;
            UpdateHealthUI();
        }
    }
}
