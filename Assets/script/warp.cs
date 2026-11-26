using System.Collections.Generic;
using UnityEngine;

public class WarpHole : MonoBehaviour
{
    private static List<WarpHole> allWarps = new List<WarpHole>();

    [SerializeField] private Transform exitPoint;

    // --- �N�[���_�E���p�̐ÓI�ϐ��i��`��ǉ��E�C���j ---
    private static GameObject lastWarpedTarget = null;
    private static float lastWarpedTime = 0f;
    private const float WarpCooldown = 0.2f; // ���[�v��A���Ƀ��[�v�\�ɂȂ�܂ł̎��ԁi�b�j

    private void OnEnable()
    {
        allWarps.Add(this);
    }

    private void OnDisable()
    {
        allWarps.Remove(this);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        GameObject target = collision.gameObject;

        // �N�[���_�E�����͓����I�u�W�F�N�g�̃��[�v�������s��Ȃ�
        if (target == lastWarpedTarget && Time.time - lastWarpedTime < WarpCooldown)
        {
            return;
        }

        ExecuteWarp(target);
    }

    private void ExecuteWarp(GameObject target)
    {
        List<WarpHole> candidateWarps = new List<WarpHole>(allWarps);
        candidateWarps.Remove(this);

        if (candidateWarps.Count == 0) return;

        // �����_����1�I��
        int randomIndex = Random.Range(0, candidateWarps.Count);
        WarpHole destinationWarp = candidateWarps[randomIndex];

        // ���W���ړ�������
        Transform destTransform = destinationWarp.exitPoint != null ? destinationWarp.exitPoint : destinationWarp.transform;
        target.transform.position = destTransform.position;

        // �Ō�Ƀ��[�v�������^�[�Q�b�g�Ǝ��Ԃ��L�^
        lastWarpedTarget = target;
        lastWarpedTime = Time.time;

        // �����X�g���̌�������
        Rigidbody2D rb = target.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity *= 0.6f;
        }
    }
}