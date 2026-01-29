using UnityEngine;
[RequireComponent(typeof(Camera))]
public class Cursor : MonoBehaviour
{
    // 床のレイヤー名。床以外はレイに衝突しないようにする。
    private const string FLOOR_LAYER_NAME = "Floor";
    // 衝突しているか否か
    private bool isHit_;
    // レイの情報
    private Ray ray_;
    // 衝突の情報
    private RaycastHit raycastHit_;
    // カメラ
    private Camera camera_;

    private void Start()
    {
        camera_ = GetComponent<Camera>();
    }
    void Update()
    {
        // カメラからのレイを算出
        ray_ = camera_.ScreenPointToRay(Input.mousePosition);
        // レイを飛ばす。戻り値はboolで、衝突したかどうか。
        // 衝突しているとraycastHitから衝突の情報が取得できる
        isHit_ = Physics.Raycast(
          ray_,
          out raycastHit_,
          1000,
          LayerMask.GetMask(FLOOR_LAYER_NAME)
        );
    }

    public bool GetIsHit() { return isHit_; }
    public Ray GetRay() { return ray_; }
    public RaycastHit GetRaycastHit() { return raycastHit_; }


}
