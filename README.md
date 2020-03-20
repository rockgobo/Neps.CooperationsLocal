
-	GIT (https://git-scm.com/) Version-Kontrollsystem
-	NodeJs (https://nodejs.org/en/) Brauchst du für den Packetmanager um die Abhängigkeiten und das restliche Tooling zu installieren

Alles installieren und dann folgende Schritte durchgehen:

1.	Das Projekt unter https://github.com/rockgobo/Neps.CooperationsLocal clonen, dazu in deiner Console (windows-Taste „cmd“ eingeben und Enter drücken) in ein Verzeichnis deiner Wahl wechseln und dort „git clone https://github.com/rockgobo/Neps.CooperationsLocal.git“ eingeben.
2.	Dann in das Verzeichnis wechseln und „npm install“ eingeben, dann sollte er über NodeJs Packetmanager NPM die Abhängigkeiten laden
3.	Über „npm install http-server -g“ einen kleinen http Server installieren
4.	Über „http-server ./“ kann du den Server starten und in einem beliebigen Browser solltest du jetzt unter „http://localhost:8080“ kannst du die Karte mit den Logos usw. sehen
5.	Jetzt kannst du munter in dem Code arbeiten und im Browser immer die Ergebnisse sehen, mit Hilfe von Git hast du auch gleich alles in einer Versionkontrolle falls du dich mal verrennst (Falls eine Änderung erfolgreich war am besten gleich commiten)

Die Daten liegen im Verzeichnis „/data/“ in der Datei „network.de.js“. Wenn du fertig bist legst du alles erstmal lokal bei dir in die Versionskontrolle und dann kannst du alles in das Repository auf Github pushen, dort sehe ich dann deine Änderungen.
