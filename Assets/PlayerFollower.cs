using UnityEngine;

[RequireComponent(typeof(Cursor))]
public class PlayerFollower : MonoBehaviour
{
    [SerializeField]
    // 追跡する対象
    private GameObject target_;//player
    [SerializeField, Range(0.0f, 1.0f)]
    // カメラをどれくらいカーソルへ寄せるか。
    float interpolatedValue_ = 0.5f;
    // マウスカーソルの情報
    private Cursor cursor_;
    // カメラとプレイヤーの位置関係をあらかじめ記録しておく
    private Vector3 offset_;
    private void Start()
    {
        cursor_ = GetComponent<Cursor>();
        // 現在のプレイヤーとカメラの位置関係を保存しておく。
        offset_ =
          transform.position -
          target_.transform.position;
    }
    void Update()
    {
        Vector3 mousePosition =
          cursor_.GetRaycastHit().point;
        Vector3 targetPosition =
          target_.transform.position;
        // PlayerとMouseカーソルの中間を注視する
        Vector3 lookAt = Vector3.Lerp(
          targetPosition,
          mousePosition,
          interpolatedValue_
        );
        // 注視点からoffsetを足してカメラを離す
        transform.position = lookAt + offset_;
    }


}
