; Имя приложения
#define   Name       "ContactsApp"
; Версия приложения
#define   Version    "1.0"
; Имя исполняемого модуля
#define   ExeName    "ContactsApp.exe"
[Setup]

AppId={{790B5E14-38BE-45EB-808D-1CBBF053BBE3}

AppName= {#Name}
AppVersion={#Version}

DefaultDirName ={pf}\{#Name}
DefaultGroupName={#Name}

;OutputDir =C:\Vikont\test-setup
OutputDir =..\InstallScripts
OutputBaseFileName=test-setup

;SetupIconFile=C:\Users\Viktor\Downloads\ico_doc_iso.ico

Compression=lzma
SolidCompression=yes

[Languages]
;Name: "english"; MessagesFile: "C:\Program Files (x86)\Inno Setup 5\Default.isl";
Name: "english"; MessagesFile: "compiler:Default.isl"; 
;Name: "russian"; MessagesFile: "C:\Program Files (x86)\Inno Setup 5\Languages\Russian.isl";

[Tasks]
; Создание иконки на рабочем столе
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]

; Исполняемый файл
Source: "..\ContactsAppUI\ContactsAppUI\bin\Release\ContactsAppUI.exe"; DestDir: "{app}"; Flags: ignoreversion

; Прилагающиеся ресурсы
Source: "..\ContactsAppUI\ContactsAppUI\bin\Release\*.dll"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs