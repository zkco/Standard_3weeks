# Standard_3weeks
Sparta BootCamp Standard Class Learning

Project date 2024 10 28 - 2024 11 01

Update Q1 in 20241029
숙련 1강 ~ 숙련 3강

**분석 문제** : 분석한 내용을 직접 작성하고, 강의의 코드를 다시 한번 작성하며 복습해봅시다.

- Q1. 입문 주차와 비교해서 입력 받는 방식의 차이와 공통점을 비교해보세요.

  A1. 입문 주차의 경우 Send Message 방식을 이용하여 스크립트 내부에 구현된 OnLook과 OnMove 등의 메소드를 찾아내서 실행하는 방식인 반면
  숙련주차에서는 Invoke Unity Event 방식을 사용하여 유니티 내부에서 CallbackContext를 받아와
  동작에 따른 반환값을 스크립트 내부로 직접 불러와서 그에 따른 값을 지정하고
  Input > Event에 해당 스크립트를 배치해 메소드를 실행시키는 차이점이 있다.
  
  공통점으로는 Input Action에서 Actions와 Action Maps을 설정하여 키를 지정하는 방식과
  CallbackContext를 받아오는 방식이 InputValue를 받아오는 방식과 비슷하다.

  
- Q2. `CharacterManager`와 `Player`의 역할에 대해 고민해보세요.

  A2. Character 매니저는 싱글톤 디자인 패턴으로 작성되었으며 게임 내에서 유일한 존재인 플레이어에 대한 접근을 용이하게 해주며
      DontDestroyOnLoad를 통해 다른 씬으로 이동하여도 파괴되지 않게 만들었기 때문에 Player 내부에 작성되는 변수들에 접근할 수 있게 해준다.
      Player는 CharacterManager.Instance를 통해 접근할 수 있으며 내부에 다른 스크립트를 변수로 두어
      CharacterManager.Instance.Player.controller와 같이 해당 스크립트에 대한 접근을 가능하게 해준다.
  
- Q3. 핵심 로직을 분석해보세요 (`Move`, `CameraLook`, `IsGrounded`)

  A3. Move 메소드는 플레이어가 이동할 방향과 속도를 만들어 벡터값을 제작하여 플레이어의 이동에 직접적으로 관여하고
      CameraLook 메소드는 마우스의 위치를 읽어 카메라를 X 또는 Y 축을 기준으로 회전시켜 뷰를 이동할 수 있으며
      IsGrounded는 플레이어를 기준으로 전,후,좌,우에서 바닥을 향해 레이를 계산하여 땅이라고 생각되는 레이어에
      해당 ray가 닿을 경우에만 땅에 있는 것으로 간주하게 되며 이 경우 True 값을 반환하여 점프가 가능하게 하고
      이 외의 상황에서는 점프가 불가능하게 한다.

  
- Q4. `Move`와 `CameraLook` 함수를 각각 `FixedUpdate`, `LateUpdate`에서 호출하는 이유에 대해 생각해보세요.

  A4. Update는 매 프레임마다 체크하지만 FixedUpdate는 정해진 타임스텝에 따라 호출되기 때문에 물리적인 충돌오류를 방지하기 위해 사용됨
      이전에 테스트 해본 결과 속도가 일정 이상일 때 Update문에 구현한 이동방식은 물체를 뚫고 이동하는 경우도 발생했음

      LateUpdate는 라이프 사이클에 따라 Update 함수가 종료된 후에 실행되고
      객체를 따라가도록 설정해야하는데 RigidBody가 적용되지 않은 물체를 따라가는 경우에
      Update에 이동 계산이 적용되어있는 경우 객체를 따라가지 못할 수도 있어서?

**확장 문제** : 강의 내용을 바탕으로 새로운 기능을 추가 구현해봅시다.

- Q1. 새로운 입력 값을 받아 환경설정 창을 만들어보세요.
- Q2. 설정창이 떴을 때 마우스 커서가 보이고 카메라 회전을 막는 기능을 코드로 구현해보세요.
