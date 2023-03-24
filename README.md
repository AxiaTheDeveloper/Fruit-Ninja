# Fruit-Ninja

IMPLEMENTASI Game Optimization
- Texture 2D menggunakan filter mode Point(no filter)
![image](https://user-images.githubusercontent.com/101692512/227444452-8afa6ff7-d61f-4f01-beed-d72c9f0ac80a.png)


- Penggunaan Couroutine dibanding Invoke()
![image](https://user-images.githubusercontent.com/101692512/227447812-cd14587e-513e-42d5-a5b3-2e6ae64069ea.png)
menggunakkan courotine untuk delay transisi UI

![image](https://user-images.githubusercontent.com/101692512/227447927-981ad675-86ab-4411-b546-44cf0b268dd9.png)
menggunakkan Couroutine untuk delay spawn object yang akan dipotong pemain

- Membuat const string untuk tags atau trigger pada animasi
![image](https://user-images.githubusercontent.com/101692512/227444852-f5da1a31-757a-47a8-968f-66491b915ece.png)
![image](https://user-images.githubusercontent.com/101692512/227447357-15f56964-5838-4bc8-aa5a-8f395fe54562.png)

Player Tag yang dipakai di comparetag diletakkan di const string

![image](https://user-images.githubusercontent.com/101692512/227447468-296c4eef-ef4e-4d84-ac65-4484712ff20c.png)
Untuk memanggil trigger animasi, stringnya diletakkan di cons string




- Menghilangkan function yang kosong atau tidak dipakai
![image](https://user-images.githubusercontent.com/101692512/227445068-2b360ba1-cd41-4a5f-b500-418705c2c2c8.png)
menghilangkan function Start() karena tidak dipakai

![image](https://user-images.githubusercontent.com/101692512/227445241-41291b5d-81b8-41a1-9ea8-105ec6025d25.png)
menghilangkan function Update() karena tidak dipakai


- Menggunakkan CompareTag() dibanding Gameobject.Tag()
![image](https://user-images.githubusercontent.com/101692512/227444792-44376d27-446b-4205-8fcd-e948643c14cc.png)
![image](https://user-images.githubusercontent.com/101692512/227448100-bba5783c-aa7c-468f-9d7e-abe7fd2011c2.png)



IMPLEMENTASI SOLID

- SRP (Single Responsibility Principle) : 
Fruit.cs, FruitCuttedVisual.cs, FruitScore.cs, FruitVisual.cs, KnifeBehaviour.cs, KnifeVisual.cs, AudioScrptableObject.cs, FruitsSpawnScriptableObject.cs, AudioManager.cs, Bomb.cs, FruitNinjaGameManager.cs, FruitNinjaScoreGameManager.cs, GameInput.cs, GamUI.cs, ObjectSpawner.cs, ScoreUI.cs
