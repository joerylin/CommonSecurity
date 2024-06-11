# Common Security
## 需求情境
#### 一、提供專案共用加/解密元件使用
#### 二、目前支援的演算法類型
- 無須加密金鑰(Key)或初始值(IV:Initial Value)
1. Base 64  
2. MD5 ：無法反解密！
- 須加密金鑰(Key)或初始值(IV:Initial Value)
3. DES：Key、IV使用8個字元；若無IV取Key為IV
4. AES：Key使用32個字元、IV使用16個字元；，若無IV取Key前16碼為IV
#### 三、工具下載
- [加/解密小工具：Common.SecurityTool.zip](https://drive.google.com/file/d/15Fv6m6KY28uJAjSsL5lGx3HDLOWDubbA/view?usp=sharing)
- [供專案參考使用共用元件dll](https://drive.google.com/file/d/1YLlUo-mEwSG8kMQ7bEB1uTtIJaUP4URR/view?usp=sharing)

#### 二、appsettings.json 設定檔
```
{
    "DESSettings": { //加密金鑰KEY(8個字元) ，初始化向量IV(8個字元)
        "KEY": "12345678",
        "IV": "87654321"
    },
    "AESSettings": { //加密金鑰KEY(32個字元) ，初始化向量IV(16個字元)
        "KEY": "123456789012345678901234567890AB",
        "IV": "1234567890ABCDEF"
    },
    "AppSettings": {
        "Algorithm":  [ "Base64", "MD5", "DES", "AES" ] 
    }
}
```

#####  說明：
- DESSettings 、AESSettings：需要設定 Key、IV，請自行修改
-  AppSettings：
    - Algorithm ：提供Winform 下拉演算法的種類，目前支援4種類型
