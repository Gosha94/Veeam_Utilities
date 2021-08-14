# Veeam_Utilities

Решение состоит из двух проектов:
1) WinWatcher - утилита, которая мониторит процессы Windows и "убивает" те процессы, которые работают слишком долго.

Пример использования для мониторинга процесса Opera.exe
  1) Открываем cmd.exe
  2) D:
  2) cd D:\Projects\_NET\Veeam_Utilities\WinWatcher\bin\Debug\netcoreapp3.1\
  3) WinWatcher.exe opera.exe 1 1
  
2) VacancyFinder - утилита, использующая Selenium WebDriver для выполнения автоматических действий в браузере
