# Common Security
## �ݨD����
#### �@�B���ѱM�צ@�Υ[/�ѱK����ϥ�
#### �G�B�ثe�䴩���t��k����
- �L���[�K���_(Key)�Ϊ�l��(IV:Initial Value)
1. Base 64  
2. MD5 �G�L�k�ϸѱK�I
- ���[�K���_(Key)�Ϊ�l��(IV:Initial Value)
3. DES�GKey�BIV�ϥ�8�Ӧr���F�Y�LIV��Key��IV
4. AES�GKey�ϥ�32�Ӧr���BIV�ϥ�16�Ӧr���F�A�Y�LIV��Key�e16�X��IV
#### �T�B�u��U��
- [�[/�ѱK�p�u��GCommon.SecurityTool.zip](https://drive.google.com/file/d/15Fv6m6KY28uJAjSsL5lGx3HDLOWDubbA/view?usp=sharing)
- [�ѱM�װѦҨϥΦ@�Τ���dll](https://drive.google.com/file/d/1YLlUo-mEwSG8kMQ7bEB1uTtIJaUP4URR/view?usp=sharing)

#### �G�Bappsettings.json �]�w��
```
{
    "DESSettings": { //�[�K���_KEY(8�Ӧr��) �A��l�ƦV�qIV(8�Ӧr��)
        "KEY": "12345678",
        "IV": "87654321"
    },
    "AESSettings": { //�[�K���_KEY(32�Ӧr��) �A��l�ƦV�qIV(16�Ӧr��)
        "KEY": "123456789012345678901234567890AB",
        "IV": "1234567890ABCDEF"
    },
    "AppSettings": {
        "Algorithm":  [ "Base64", "MD5", "DES", "AES" ] 
    }
}
```

#####  �����G
- DESSettings �BAESSettings�G�ݭn�]�w Key�BIV�A�Цۦ�ק�
-  AppSettings�G
    - Algorithm �G����Winform �U�Ժt��k�������A�ثe�䴩4������
