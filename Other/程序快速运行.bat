@echo off
for /L %%a in (
 10,-1,0
) do (
 echo 10�������QuickSetup.exe
 echo ��ʣ�� %%a ��
 ping -n 2 localhost 1>nul 2>nul
 cls
)
start QuickSetup.exe
PAUSE