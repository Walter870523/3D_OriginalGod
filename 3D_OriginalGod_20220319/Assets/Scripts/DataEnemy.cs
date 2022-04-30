using UnityEngine;

namespace Walter
{
    /// <summary>
    /// �ĤH���
    /// 1.��q
    /// 2.����
    /// 3.���ʳt��
    /// 4.�l�ܽd��
    /// 5.�����d��
    /// 6.�g���
    /// 7.��������
    /// 8.�������ƶq
    /// 9.���������v
    /// </summary>
    // Creat Asset Mwnu �إ߸�ƿﶵ
    // menuName �ﶵ�W�١A�i�H�ϥ� / �إߤl�ﶵ(��ĳ�^��)
    // fileName �ɮצW��(��ĳ�^��)
    [CreateAssetMenu(menuName = "Walter/Data Enemy", fileName = "Data Enemy")]
    public class DataEnemy : ScriptableObject
    {
        [Header("��q"), Range(0, 1000)]
        public float hp;
        [Header("����"), Range(0, 100)]
        public float attack;
        [Header("�����N�o"), Range(0, 5)]
        public float cd;
        [Header("����"), Range(0, 2)]
        public float delaySendDamage;
        [Header("���ʳt��"), Range(0, 50)]
        public float speed;
        [Header("�l�ܽd��"), Range(7, 50)]
        public float rangeTrack;
        [Header("�����ϰ�첾")]
        public Vector3 v3AttackOffset;
        [Header("�����ϰ�ؤo")]
        public Vector3 v3AttackSize = Vector3.one;
        [Header("�����d��"), Range(0, 7)]
        public float rangeAttack;
        [Header("�g���"), Range(0, 1000)]
        public float exp;
        [Header("��������")]
        public GameObject goCoin;
        [Header("�����ƶq"), Range(0, 500)]
        public int coinCount;
        [Header("�����������v"), Range(0, 1)]
        public float coinProbability;
    }
}
