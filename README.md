# FearStories
เป็นเกมแนวสวมบทบาท ที่ได้รับแรงบันดาลใจจากเรื่องเล่าในรายการของ The Ghost Radio เกี่ยวกับเรื่องราวของ "เรือนจำแดนใหม่" ใส่ความเป็น Thai Culture ลงไปในเกม Horror เสียงภาพ และกราฟิกสไตล์ การ์ตูนไทยเล่มละบาทห้าบาท เกมเน้นบรรยากาศ 

## Download
https://thanetsak.itch.io/fear-stories

### โครงสร้างโปรเจกต์:
1.ไฟล์ที่ใช้ในการควบคุมมุมมองภาพ(Camera)
  - 'CameraController.cs'
  - ScreenBox.cs
  - ScreenBoxController.cs
  - ZoomCamera.cs
2.ไฟล์ที่ใช้ในการเปลี่ยนฉาก(Scene.Management)
  - ChangeMap.cs
  - ChangeSceneDelay.cs
  - NextScene.cs
  - SceneEntrance.cs
  - SceneExit.cs
  - SceneLoad.cs
3.ไฟล์ที่ใช้ควบคุม สถานะ,ท่าทาง,การเคลื่อนไหว ของตัวละครผู้เล่น(Player)
  - Controller.cs
  - PlayerScripts.cs
  - Spacebar.cs
  - Stumble.cs
4.ไฟล์ที่ใช้จัดการบทสนทนาและข้อความ(Dialogue)
  - Dialogue.cs
  - DialogueManager.cs
  - DialogueShow.cs
  - DialogueTrigger.cs
5.ไฟล์ที่ใช้ในการปฏิสัมพันธ์กับตัวละครผู้เล่น(Trigger)
  - Fl3GhostSwitch.cs
  - Fl3LightOffSwitch.cs
  - FlashingLight.cs
  - FontBackScript.cs
  - GarbageDrop.cs
  - LevelUp.cs
  - LevelSwitch.cs
  - MakeWish.cs
  - MapSwitch.cs
  - NursingSwitch.cs
  - PutDownOffering.cs
  - SoundSwitch.cs
6.ไฟล์ที่ใช้ควบคุมตัวศัตรู(Ghost)
  - GhostEnemy.cs
  - GhostOn.cs
  - GhostOnSleep.cs
  - GhostShowHide.cs
  - LookAtFollow.cs
7.ไฟล์ที่ใช้ในการเริ่มต้นและควบคุมการเปลี่ยนแปลงเกม(Level)
  - MoveObject.cs
  - OnlyLevel.cs
  - PlayerLevel.cs
  - SetLevel.cs
  - StartScene.cs
