# MSSQLUtils
Утилита для MS SQL базы данных:
1. Пакетная обработка процедур

Если необходимо произвести изменения в нескольких десятках-сотнях процедур нажатием одной кнопки, например заменить GETDATE() на GETUTCDATE()
		<details>
		  <summary>Скриншоты</summary>
			![img](replace0.png)
			![img](replace1.png)
			![img](replace2.png)
			![img](replace3.png)
		</details>
2. Дерево вызовов

Если необходимо построить в древовидном виде список зависимых процедур.
Можно искать как "вниз" (app_proc1 -> app_proc2 -> ...) так и "вверх" (app_proc2 -> app_proc1, app_proc3 -> app_proc1)
		<details>
		  <summary>Скриншоты</summary>
			![img](tree0.png)
			![img](tree1.png)
			![img](tree2.png)
			![img](tree3.png)
		</details>
3. Сравнение процедур/функций/view между собой в пределах разных баз данных.
		<details>
		  <summary>Скриншоты</summary>
			![img](merge0.png)
			![img](merge1.png)
		</details>
4. Просмотр содержимого сборок на c# языке
		<details>
		  <summary>Скриншоты</summary>
			![img](assembles0.png)
			![img](assembles1.png)
		</details>

# Используемые компоненты:
- FCTB - FastColoredTextBox для подсветки синтаксиса
- Menees - для декомпиляции сборок
- Microsoft.SqlServer.Management.SqlParser - для парсинга SQL запросов

# Средство разработки
SharpDevelop 5.1