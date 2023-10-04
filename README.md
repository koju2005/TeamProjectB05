## 팀명
I들속에 E하나(Cont.)

## 게임명
Bug Isekai Survivor (오류세계 서바이벌)
## 게임 배경
- 코딩에 미쳐있던 주인공, 야근에 시달리며 레드불을 사러 편의점에가다 트럭에 치이게 되는데...
- 코드적 오류가 넘치는 이세계에 떨어진 주인공! 외눈박이 슬라임, 드래곤, 가시거북이, 심지어 총쓰는 x친 오크까지!
- 나갈려고발버둥 치는것과 적응해서 사는것은 주인공의 선택! 과연 우리의 주인공의 선택은?
***
## 👥 프로젝트 참여 인원
김경환, 김강현, 박민호, 최장범, 이도현
## ⚙️ 개발환경
Unity 2022.3.5f1

C#

## 💻 에셋
- 맵
  - https://assetstore.unity.com/packages/3d/environments/landscapes/low-poly-simple-nature-pack-162153
  - https://assetstore.unity.com/packages/3d/environments/low-poly-rock-pack-57874
- 시작화면 배경
  - https://assetstore.unity.com/packages/2d/environments/free-parallax-forest-background-hq-158680#content
- 몬스터
  - https://assetstore.unity.com/packages/3d/characters/creatures/dragon-for-boss-monster-hp-79398
  - https://assetstore.unity.com/packages/3d/characters/animals/free-stylized-bear-rpg-forest-animal-228910
  - https://assetstore.unity.com/packages/3d/characters/creatures/rpg-monster-duo-pbr-polyart-157762
  - https://assetstore.unity.com/packages/3d/characters/creatures/cyber-monsters-2-161380#content
- 장비, 무기, 채집도구
- 재료
- 건축
- 플레이어
  - https://assetstore.unity.com/packages/3d/characters/humanoids/fantasy/free-low-poly-human-rpg-character-219979
- 사운드
  - https://assetstore.unity.com/packages/audio/music/orchestral/orch-bgm-52167
  - https://assetstore.unity.com/packages/audio/sound-fx/footstep-snow-and-grass-90678
## ⏰ 개발일정
2023.09.25 ~ 2023.10.04

## 🖼️ 와이어 프레임
https://www.figma.com/file/vjdwOTuufkE4VLVbz1SwAi/Untitled?type=design&node-id=0-1&mode=design&t=YdxvYH5BKD6Q96gv-0

<img width="524" alt="스크린샷 2023-10-04 102553" src="https://github.com/koju2005/TeamProjectB05/assets/141592625/155c6971-ac09-4206-9993-8ef4fb6594b3">
<img width="658" alt="스크린샷 2023-10-04 102604" src="https://github.com/koju2005/TeamProjectB05/assets/141592625/fb3d3007-c2d1-4c82-8cbb-d1e16f90598c">

## 기능
### 게임시작 화면
- 게임명
- Press to Start
- 배경 이미지
- BGM
### 로딩 화면
- 로딩 바
- 게임 팁 텍스트
### 메인화면
- 플레이어
- 몬스터
- 나무 오브젝트
- 강물
- BGM / 효과음
- 건설
- UI
  - HUD
  - 인벤토리
  - Quick Slot
  - build key
- 아이템
  - 자원
  - 무기
  - 장비
  - 미니맵
### 역할분담
- 이도현(팀장)
  - 인벤토리
- 김강현
  - UI / 플레이어, 아이템
  - 플레이어 - 플레이어 이동 /점프 /체력/스태미나/배고픔
  - 미니맵
- 김경환
  - 건축
    - 아이템으로 만들어서 배치
    - 러스트처럼 도면들고 오브젝트를 설치하는 방식
      - 설치전에 빨간색 반투명, 파란색 반투명으로 설치가능여부 식별
      - 바닥(지붕)
      - 벽(창문O,X)
      - 방벽(울타리)
      - 문
- 최장범
  - 몬스터
    - 근거리
      - 곰
      - 드래곤
      - 슬라임
      - 가시거북
    - 원거리
      - 거너(오크)
  - 사운드
    - 발걸음 소리 / 몬스터 공격 효과음
    - BGM
  - 시작화면
  - 로딩화면
- 박민호
  - 장비, 아이템 제작 기능

### 버그 리포트
- [ ]  9/26
- [x]  몬스터 애니메이션 누락 버그
- [x]  몬스터 땅에서 안걸어다니고 땅 밑으로 꺼지는 버그
- [ ]  9/27
- [x]  몬스터-곰이 뒤로 걸어서 플레이어에게 접근하고 플레이어가 존재하지 않는곳에 공격을 시행하는 버그
- [x]  몬스터(거너) 걷는 모션이 정지하는 버그
- [x]  플레이어 shift 대쉬시에 움직이는 방향 변경되는 버그
- [x]  목재랑 돌 스프라이트랑 콜라이더가 따로 움직이는 버그
- [ ]  10/2
- [x]  앞으로 가기 방향키 누른 채로 shift눌렀다 때면 계속해서 속도 증가 하는 버그
- [ ]  10/3
- [ ]  플레이어 shift대쉬시에 움직이는 방향 변경되는 버그

### 어려웠던 부분 Or 아쉬웠던 점
- 이도현
    - 습득한 아이템을 인벤토리에 추가하는 로직을 짜는 게 굉장히 어려웠다. 그리고 인벤토리인데 다른 작업자분들께서 쓰기 좋게 구현하지 못한 것이 아쉬웠다.
- 김강현
    - UI 구성시 배치가 제일 까다로웠다. 크기가 맞으면 보기에 안좋고 크기가 안맞으면 또 깔끔하고 쉽지않은 작업이였다.
- 김경환
    - 다른 건축물이 필요한 건축물의 경우 위치를 자동으로 잡아주는 기능을 만드는게 어려웠다. 그걸 위해서 건축물 마다 따로 변수를 할당해서 위치를 잡아주었다.
- 최장범
    - 몬스터들의 전투방식 구현이 어려웠다. 맵을 돌아다니면서 플레이어와 움직이는 몹들이 전투를 하는 방식을 처음에는 구상했었는데 준비한 맵에 비해 몬스터 수와 종류가 많다보니 움직임을 구현하면 이동에 꼬임이 발생하고 자잘한 오류들이 생겨, 와우의 전투방식을 이용하여 몬스터의 어그로를 플레이어가 끌면 전투가 발생하도록 수정했다. 처음 생각했던 바를 그대로 구현할 실력이 되지 않아 아쉬웠지만 최대한 게임의 분위기에 맞춰서 작업을 하려고 노력했던것 같다.
- 박민호
    - 아이템 제작 기능이 인벤토리의 영향을 많이 받다보니 미리 인벤토리를 예상하고 제작기능을 만들었을 때 예상과 차이가 있는 부분에 맞게 기능을 수정하는 일이 어려웠던 것 같다.
