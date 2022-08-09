Remove-Item "D:\ProjectOnline\resources\client-core\*"  -Recurse
Copy-Item -Path "E:\OneDrive\Repo\Project Online\data\resources\ProlineCore\*" -Destination "D:\ProjectOnline\resources\client-core\" -Recurse
Copy-Item -Path "E:\OneDrive\Repo\ClassicOnline\data\components\ProlineCore\*" -Destination "D:\ProjectOnline\resources\client-core\" -Recurse
Copy-Item -Path "E:\OneDrive\Repo\ClassicOnline\data\core\*" -Destination "D:\ProjectOnline\resources\client-core\" -Recurse
Copy-Item -Path "E:\artifacts\ProlineCore\*" -Destination "D:\ProjectOnline\resources\client-core\" -Recurse
Copy-Item -Path "E:\artifacts\ClassicOnline\*" -Destination "D:\ProjectOnline\resources\client-core\" -Recurse
Remove-Item "D:\ProjectOnline\resources\client-core\CitizenFX.Core.*.dll" -Recurse
Remove-Item "D:\ProjectOnline\resources\client-core\*.pdb" -Recurse