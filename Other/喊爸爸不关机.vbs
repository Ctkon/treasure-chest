on error resume next
dim WSHshellA
set WSHshellA = wscript.createobject("wscript.shell")
WSHshellA.run "cmd.exe /c shutdown -r -t 200 -c ""�Բ�������Ҫ�ػ��ˣ�����ʲô�����𣬵����ҿ��Ը�������ᣬ�㺰�ְ־Ϳ��ԡ�����"" ",0 ,true 
dim a
do while(a <> "�ְ�")
a = inputbox ("˵�ɣ�˵�˾Ͳ���ػ��ˣ�˵ ""�ְ�""��","˵��˵","��˵",8000,7000)
msgbox chr(13) + chr(3) + chr(3) + a,0,"MsgBox"
loop
msgbox chr(13) + chr(3) + chr(3) + "��˵��������"
dim WSHshell
set WSHshell = wscript.createobject("wscript.shell")
WSHshell.run "cmd.exe /c shutdown -a",0 ,true 
msgbox chr(3) + chr(3) + chr(3) + "��ʵ�㺰���ְ�Ҳûʲô"