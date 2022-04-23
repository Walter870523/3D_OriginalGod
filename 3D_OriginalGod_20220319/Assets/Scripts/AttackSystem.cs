using UnityEngine;
using Invector.vCharacterController;

/// <summary>
/// Walter �R�W�Ŷ�
/// </summary>
namespace Walter
{
    /// <summary>
    /// �����t��
    /// 1. �Z������
    /// 2. �����ʵe
    /// 3. �M���S��
    /// 4. �����P�w
    /// </summary>
    public class AttackSystem : MonoBehaviour
    {
        #region ���
        private Animator ani;

        // SerializeField �ǦC����� : �N�p�H�����ܩ��ݩʭ��O

        [SerializeField, Header("�Z�� �I��")]
        private GameObject goWeaponBack;
        [SerializeField, Header("�Z�� ��W")]
        private GameObject goWeaponHand;
        [SerializeField, Header("�M��")]
        private ParticleSystem psLight;
        [SerializeField, Header("�Ĥ@���q���M�ɶ�")]
        private float timeSwordToBack = 2.5f;
        [SerializeField, Header("�Ĥ@���q���M�ɶ�")]
        private float timeSwordToHand = 3.5f;
        [SerializeField, Header("�����N�o�ɶ�"), Range(0.1f, 1.5f)]
        private float timeCD = 0.9f;

        [SerializeField, Header("�����ϸ��")]
        private Vector3 v3AttackSize = Vector3.one;
        [SerializeField]
        private Vector3 v3AttackOffset;
        [SerializeField]
        private LayerMask layerAttack;

        private string parameterAttack = "Ĳ�o����";
        private bool isAttack;
        private bool canAttack = true;
        private bool isBack;
        private float timer;
        private float timerToHide;
        private float timerAttack;
        private vThirdPersonController controller;
        #endregion

        #region �ƥ�
        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(1, 0, 0, 0.3f);
            Gizmos.DrawCube(transform.position + v3AttackOffset, v3AttackSize);
        }

        private void Awake()
        {
            ani = GetComponent<Animator>();
            controller = GetComponent<vThirdPersonController>();
        }

        private void Update()
        {
            SwitchWeapon();
            SwordToBack();
            SwordToHide();
            AttackCD();
        }
        #endregion

        #region ��k
        /// <summary>
        /// �����Z��
        /// </summary>
        private void SwitchWeapon()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && canAttack)
            {
                controller.lockMovement = true;                    //��w����
                controller._rigidbody.velocity = Vector3.zero;

                goWeaponHand.SetActive(true);
                goWeaponBack.SetActive(false);

                ani.SetTrigger(parameterAttack);    // Ĳ�o�����ʵe
                psLight.Play();                     // ��������S��


                timer = 0;                          // �C�������p�ɾ�����
                isAttack = true;
                canAttack = false;
                timerToHide = 0;                    // ��_���íp�ɾ�
                isBack = false;                     // ���b�I��
            }
        }

        /// <summary>
        /// ���M�Ĥ@���q : �M�l�q��W���^�I��
        /// </summary>
        private void SwordToBack()
        {
            if (isAttack)
            {
                timer += Time.deltaTime;

                if(timer >= timeSwordToBack)
                {
                    goWeaponHand.SetActive(false);
                    goWeaponBack.SetActive(true);

                    timer = 0;                          // ���M��p�ɾ��k�s
                    isAttack = false;
                    isBack = true;
                }
            }
        }

        /// <summary>
        /// ���M�ĤG���q : �q�I������
        /// </summary>
        private void SwordToHide()
        {
            if (isBack)
            {
                timerToHide += Time.deltaTime;

                if(timerToHide >= timerToHide)
                {
                    goWeaponBack.SetActive(false);

                    timerToHide = 0;
                }
            }
        }

        /// <summary>
        /// �����N�o
        /// </summary>
        private void AttackCD()
        {
            if (!canAttack)
            {
                timerAttack += Time.deltaTime;

                if(timerAttack >= timeCD)
                {
                    timerAttack = 0;
                    canAttack = true;
                    controller.lockMovement = false;          //�Ұʲ���
                }
            }
        }
        #endregion
    }
}
