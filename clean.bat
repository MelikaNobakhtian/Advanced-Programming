rmdir /s /q .vs
rmdir /s /q %TEMP%\VisualStudioTestExplorerExtensions
for /f %%i in ('dir /s /b bin obj TestResults packages') do @rmdir /s /q %%i