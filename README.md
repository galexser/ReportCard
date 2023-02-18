<h1 align="center">ReportCard</h1>

<h3>Создание БД</h3>
<ol>
	<li>Установить <a href="https://mariadb.org/download/?t=mariadb&p=mariadb&r=11.0.0&os=windows&cpu=x86_64&pkg=zip&m=docker_ru">MariaDB</a> версии 10.3 выше</a></li>
	<li>Создать базу данных с помощью скрипта
		<ol type="1">
			<li>create_empty.sql - пустая база (Добавлен 1 Сотрудник и 1 Отдел для начального заполнения данными)</li>
			<li>create_example.sql - база данных пример</li>
		</ol>
	</li>
	<li>Создать пользователя для подключения. Примерный скрипт:
	<code>
CREATE USER 'ReportUser'@'%' IDENTIFIED BY PASSWORD 'password';
GRANT SELECT, INSERT, DELETE, EXECUTE, SHOW VIEW  ON *.* TO 'ReportUser'@'%';
GRANT SELECT, INSERT, UPDATE, DELETE, EXECUTE, SHOW VIEW, EVENT  ON `report`.* TO 'ReportUser'@'%';
FLUSH PRIVILEGES;
	</code>
	</li>
	<li>Если была создана пустая БД, необходимо заполнить справочники в интерфейсе ПО (Кодировки дней - обязательный справочник)</li>
</ol>

<h3>Установка приложения</h3>
<ol>
	<li>Скопировать каталог ReportCard в любую директорию на компьютере</li>
	<li>В файле ReportCard.exe.config в строке подключени <add name="report" connectionString="Server=127.0.0.1;Port=3306;Database=report;Uid=ReportUser;Pwd=ReportUser;" providerName="MySqlConnector" /> 
	<code>
	Server=<b>127.0.0.1</b> на Server=<b>[Ип адрес сервер с БД]</b>
	Uid=<b>ReportUser</b> на Uid=<b>[Имя рание созданного пользователя]</b>
	Pwd=<b>ReportUser</b> на Pwd=<b>[Пароль ранее созданного пользователя]</b>
	</code>
	</li>
</ol>
