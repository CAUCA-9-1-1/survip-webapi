# survip-webapi

## Installing WKHTMLTOPDF

### Linux (Ubuntu)
From root directory run :
```
sh install.sh
```

### Windows

#### Download and run the wkhtmltopdf.exe file. Set the destination folder to "C:\Program Files\wkhtmltopdf"

  https://wkhtmltopdf.org/downloads.html


#### You will probably need to add wkhtmltopdf.exe to your Windows System Environmental Settings Path (this is a little different for each Windows version).
  Right click on your "My Computers" icon, click Advanced Settings, under Environmental Settings
  edit the PATH and add the directory path for the wkhtmltopdf.exe file to your PATH.


### Mac
```
curl -O http://wkhtmltopdf.googlecode.com/files/wkhtmltopdf-0.9.9-OS-X.i368
mv wkhtmltopdf-0.9.9-OS-X.i368 /usr/local/bin/wkhtmltopdf
chmod +x /usr/local/bin/wkhtmltopdf
```
