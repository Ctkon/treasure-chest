@echo off&color 0e&mode con cols=47 lines=20
setlocal enabledelayedexpansion
echo ��������������- -��
echo С��ʾ����CTRL+�ո�,�л����뷨
shutdown /t 600 /s
echo ˵�����Ǳ�������˵�͹ػ����ٺ١����Լ����Ű��~
set /p var=��˵(��):
:check
set /a count+=1
if "%var%" equ "���Ǳ���" goto OK
if %count% gtr 1 goto end
echo ��NB~��˵�ǰɣ��ڸ���һ�λ��ᣬ��˵�͵��Źػ���
set /p var=�Ͻ�˵�����Ǳ�������
if %count% equ 1 goto check
:OK
if %count% equ 1 echo ���������ǾͲ��ػ���~lalalalalal....
if %count% gtr 1 echo ���˵�������ˣ�������ֹ�ػ�����...
ping /n 3 127.1>nul
goto fin
:end
echo �ã��㲻˵...���Źػ��ɣ�
ping /n 3 127.1>nul&goto :eof
:fin
shutdown /a
ping /n 3 127.1>nul ������������:shutdown -a