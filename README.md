# 2D Top-Down Shooter Education Project

이 프로젝트는 대구가톨릭대학교 게임공학과 게임 개발 동아리 **Yggdrasil(위그드라실)**의 내부 교육을 목적으로 제작된 리포지토리입니다. 2D 탑다운 슈팅 게임의 기초적인 메커니즘을 구현하며 유니티 엔진의 핵심 기능을 학습합니다.

## 📚 리소스 출처 명시
본 프로젝트는 **Unity Learn**의 공식 튜토리얼인 **[[2D Adventure Game: Robot Repair](https://learn.unity.com/project/2d-adventure-game-robot-repair)](https://learn.unity.com/course/691f277138cfaaa01c448657?start=true)**의 에셋과 리소스를 참고 및 활용하여 제작되었습니다.

---

## 🛠 핵심 스크립트 분석 및 기능

### 1. PlayerController (플레이어 제어)
플레이어의 이동, 애니메이션 상태 전달, 그리고 발사체 생성을 담당합니다.
- **8방향 이동**: `Input.GetAxisRaw`를 통해 수평/수직 입력을 받아 `speed`에 맞춰 캐릭터를 이동시킵니다.
- **방향 기억 (LookDir)**: 입력이 0보다 클 때만 `LookDir`을 갱신하여, 이동을 멈춰도 캐릭터가 마지막으로 바라본 방향으로 총을 쏠 수 있게 설계되었습니다.
- **애니메이터 연동**: `Look X`, `Look Y`, `Speed` 파라미터를 실시간으로 갱신하여 방향별 애니메이션과 걷기 상태를 전환합니다.
- **발사 메커니즘**: `Fire1` 입력 시 `Instantiate`로 발사체를 생성하고 `AddForce`를 이용해 `LookDir` 방향으로 물리적인 힘을 가합니다.

### 2. Projectile (발사체 로직)
플레이어가 발사한 투사체의 충돌 판정 및 데미지 전달을 처리합니다.
- **충돌 감지**: `OnTriggerEnter2D`를 사용하여 물체와의 접촉을 감지합니다.
- **데미지 시스템**: 충돌한 오브젝트의 태그가 **"Enemy"**인 경우, 해당 오브젝트의 `Enemy` 스크립트를 참조해 `TakeDamage(1f)`를 호출합니다.
- **메모리 관리**: 어떤 물체와든 충돌이 발생하면 `Destroy(gameObject)`를 통해 발사체를 제거합니다.

### 3. Enemy (적 시스템)
적 캐릭터의 생명력과 상태 변화를 관리합니다.
- **체력 시스템**: 기본 HP(5.0)를 보유하며, 데미지를 입을 때마다 남은 체력을 `Debug.Log`로 출력합니다.
- **사망 로직**: `HP <= 0`이 되는 시점에 `Death()` 메서드를 실행하여 적의 제거 또는 사망 연출을 처리합니다.

---

## 🚀 프로젝트 설정 요구사항 (교육생 필독)
스크립트의 정상적인 작동을 위해 유니티 에디터 내 다음 설정이 반드시 필요합니다.

1.  **Tags**: 적 오브젝트의 Tag를 반드시 **"Enemy"**로 설정해야 데미지 판정이 동작합니다.
2.  **Physics 2D**:
    - **Projectile**: `Rigidbody2D`와 `BoxCollider2D` (Is Trigger 체크됨)가 포함되어야 합니다.
    - **Enemy**: `Enemy` 스크립트와 `Collider2D`가 포함되어야 합니다.
3.  **Animator**: `PlayerController`는 애니메이터 내에 `Look X(float)`, `Look Y(float)`, `Speed(float)` 파라미터가 정의되어 있어야 합니다.

---
**Maintainer**: Bae Jiwoo (Yggdrasil President)  
**Organization**: Daegu Catholic University - Game Engineering / **Yggdrasil**
