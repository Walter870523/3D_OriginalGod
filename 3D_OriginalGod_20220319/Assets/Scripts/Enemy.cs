using UnityEngine;
using UnityEngine.AI;

namespace Walter
{
    /// <summary>
    /// �ĤH:�򥻦欰
    /// �l�ܡB�����B���˻P���`
    /// </summary>
    public class Enemy : MonoBehaviour
    {
        [SerializeField, Header("�Ǫ����")]
        private DataEnemy data;
        [SerializeField, Header("���a����W��")]
        private string namePlayer = "�����֤k";
        [SerializeField, Header("�l�ܥؼйϼh")]
        private LayerMask layerTrack;

        private Animator ani;
        private NavMeshAgent nav;
        private Transform traPlayer;
        private float timeAttack;
        private string parameterWalk = "�}������";
        private string parameterAttack = "Ĳ�o����";
        private HurtSystem hurtPlayer;

        private void Awake()
        {
            ani = GetComponent<Animator>();
            nav = GetComponent<NavMeshAgent>();

            traPlayer = GameObject.Find(namePlayer).transform;
            hurtPlayer = traPlayer.GetComponent<HurtSystem>();

            nav.speed = data.speed;
            nav.stoppingDistance = data.rangeAttack;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(0, 0, 1, 0.35f);
            Gizmos.DrawSphere(transform.position, data.rangeTrack);

            Gizmos.color = new Color(1, 0, 0, 0.35f);
            Gizmos.DrawSphere(transform.position, data.rangeAttack);

            Gizmos.color = new Color(1, 0.7f, 0, 0.6f);
            Gizmos.matrix = Matrix4x4.TRS(
                transform.position + transform.TransformDirection(data.v3AttackOffset),
                transform.rotation, transform.lossyScale);
            Gizmos.DrawCube(Vector3.zero, data.v3AttackSize);
        }

        private void Update()
        {
            CheckPlayerInTrackRange();
        }

        private void CheckPlayerInTrackRange()
        {
            Collider[] hits = Physics.OverlapSphere(transform.position, data.rangeTrack, layerTrack);
            
            if(hits.Length > 0)
            {
                MoveToPlayer();
            }
            else
            {
                nav.isStopped = true;                // ���� �����N�z��
                ani.SetBool(parameterWalk, false);   // ����
            }
        }

        /// <summary>
        /// ���ʦܪ��a��m
        /// </summary>
        private void MoveToPlayer()
        {
            nav.isStopped = false;                               // ��_ �����N�z��
            nav.SetDestination(traPlayer.position);

            // print("�Z�� : " + nav.remaininngDistance);        

            if(nav.remainingDistance < data.rangeAttack)         // �p�G �Ѿl�Z�� < �����d�� �N�i�����
            {
                if(timeAttack >= data.cd)
                {
                    print("<color=red>����</color>");
                    timeAttack = 0;
                    ani.SetTrigger(parameterAttack);             // �N�o�����
                    CheckAttackArea();
                }
                else
                {
                    timeAttack += Time.deltaTime;
                    ani.SetBool(parameterWalk, false);           // �N�o���j�A������
                }
            }
            else
            {
                ani.SetBool(parameterWalk, true);                        // �Ѿl�Z�� > �����d�� �i�樫���ʧ@
            }
        }
        
        /// <summary>
        /// �ˬd�����ϰ�
        /// </summary>
        private void CheckAttackArea()
        {
            transform.LookAt(traPlayer);            // ���۪��a

            // Physics.OverlapBox �x���л\�I��
            // (�����I�A�@�b�ؤo�A���סA�ϼh)
            // Quaternion.identity �s����
            Collider[] hits = Physics.OverlapBox(
                transform.position + transform.TransformDirection(data.v3AttackOffset),
                data.v3AttackOffset / 2, Quaternion.identity, layerTrack);

            if(hits.Length > 0)
            {
                //print("<color=yellow>�ĤH�������ؼ� : " + hits[0].name + "</color>");
                
                hurtPlayer.GetHurt(data.attack);        // �ǻ������O�����a�����˨t��
            }
        }
    }
}