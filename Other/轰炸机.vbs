set Hone=WScript.CreateObject("WScript.Shell")
Hone.AppActivate "���ս��"
for i=1 to 100
WScript.sleep 1
Hone.SendKeys "^v"
Hone.SendKeys "%s"
Next
Msgbox"��ը���!",7,"����"
