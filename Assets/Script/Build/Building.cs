using UnityEngine;

public class Building : MonoBehaviour
{
    public Type type;

    public enum Type  // 건축물 타입 지정
    {
        Normal, // 건축물이 아닌 것들
        Wall,   // 벽
        Floor, // 바닥
    }
}
