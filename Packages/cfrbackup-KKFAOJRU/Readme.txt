Quick Heal - Backup and Restore
-------------------------------

This feature automatically and periodically (multiple times a day), 
takes a backup of all your important and well-known file formats like 
PDF and Microsoft Office files that are present on your computer. 
If you have updated any file then the feature will automatically take 
the backup of the latest copy.

This folder is created by Quick Heal Backup and Restore feature.
This backup can be used to restore files in case some Ransomware encrypts your files.
Visit http://blogs.quickheal.com/how-to-recover-files-after-a-ransomware-attack/ for more information.

  # By default this feature is turned ON and it is pre-configured to take backup of the following file types:
	.doc, .odp, .txt, .docx, .ods, .wps, .dps, 
	.odt, .wpt, .dpt, .pdf, .xls, .et, .ppt, 
	.xlsx, .ett, .pptx, .odg, .rtf, .docm, .xlsm and .pptm
  
  # How to Disable the feature?
    ---------------------------
     1. Open Quick Heal -> Settings.
     2. Turn "Off" Self Protection using the toggle button.
     3. Navigate to Quick Heal Installation directory.
     4. Open CFRUCONF.INI in Notepad. 
     5. Change value of "IS_BACKUP_ON" and set it to "0". 
    	i.e. 	[SETTINGS]
		IS_BACKUP_ON=0
	(To enable the feature, please set the value to "1".)
     6. Save the file.
     7. Go to Quick Heal -> Settings.
     8. Turn "ON" Self Protection using the toggle button.

In case of any query or to configure the backup feature to backup some other file types than mentioned above,
and for further assistance, please reach out to our Support Team using the available options.
Open Quick Heal -> Go to Help -> Support.