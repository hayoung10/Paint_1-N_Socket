# Paint_1-N_Socket
Paint with 1:N Socket (Multiple Clients)  


2019.06.07 프로젝트 과제  
그림판  
- 다중 소켓 통신을 이용하여 그림 데이터를 공유해 동시에 여러 사용자가 그림을 그릴 수 있는 그림판 프로그램
- 주요기능  
> 1:N 소켓 통신 (다중 클라이언트)  
> 그림판  
> 실시간 화면 공유  
> 더블 버퍼링  
> 서버 정보 저장  
> 다중 채팅  
- 환경 및 프로젝트 출력 형식
> Visual Studio 2015 C#  
> HW6 : 클래스 라이브러리  
> PacketServer : Windows 응용 프로그램  
> PacketClient : Windows 응용 프로그램  


-----------


## 서버/클라이언트 연결
1. 서버에서 각각 IP와 포트번호를 입력하여 **서버열기** 버튼을 클릭
2. 클라이언트에서도 각각 IP와 포트번호를 입력하고 채팅에서 사용할 ID도 입력한 후, **접속** 버튼을 클릭
    + 서버를 먼저 열고 클라이언트를 접속해야 함  
    + 서버와 클라이언트의 각각 form 형식  
    <img src="/Screenshots/form.JPG">


## 그림판
- 기능은 일반적인 그림판과 유사
  - 도구에 pen, line, rectangle, circle 등 그릴 수 있는 도구가 존재
  - 선 두께와 색 채우기 조절 가능
  - 선과 면의 색상 선택 가능
- 더블 버퍼링 사용
  - 두 개의 버퍼를 사용하려 하나의 버퍼로 데이터를 처리하고 다른 버퍼로 데이터를 기록하는 방식
  
  
## 다중 클라이언트
- 최대 10개의 클라이언트가 서버와 통신하여 그림판을 공유함
- 실시간 통신으로, 클라이언트에서 마우스 클릭을 떼는 순간 그린 그림을 서버와 다른 클라이언트들에게 지속적으로 업데이트 됨
- 서버에 그려진 모든 그림 정보가 서버측 컴퓨터에 저장됨
  - 서버를 다시 실행해도 이전 그림 정보가 남아있음
  - 그림정보는 /PacketServer/bin/Debug 내에 paint.jpg로 저장되어 있음
  - 새 그림판을 원할 경우 paint.jpg를 삭제하고 서버를 실행시키면 됨
- 다중 채팅이 가능함
  - 클라이언트 화면의 하단 박스에 메시지를 입력하고 **Say** 버튼을 누르면 메시지가 전송됨
  - 채팅 내용은 서버와 모든 클라이언트에 출력됨
    - 늦게 들어온 클라이언트는 들어온 때부터 채팅 메시지가 보임

-------

## Screenshots
- 서버/클라이언트 접속 예시  
<img src="/Screenshots/server_connect.JPG" width="300"> <img src="/Screenshots/client_connect.JPG" width="300">

- 서버의 그림 정보와 채팅 내용 모습  
<img src="/Screenshots/server_log.JPG" width="500">

- 다중 클라이언트 모습  
<img src="/Screenshots/clients.JPG" width="800">
