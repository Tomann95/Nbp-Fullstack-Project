# 💰 NBP Currency (Fullstack App)

Aplikacja typu Fullstack służąca do pobierania, archiwizacji oraz prezentacji oficjalnych kursów walut z API Narodowego Banku Polskiego.
Projekt łączy Frontend (Angular) z Backendem (.NET) oraz konteneryzowaną bazą danych (PostgreSQL).

<div align="center">
  <img width="975" alt="Ekran Główny" src="https://github.com/user-attachments/assets/fed3baa2-f95d-4617-8612-be9166412729" />
  <br/><br/>
  <img width="975" alt="Tabela Wyników" src="https://github.com/user-attachments/assets/ec26166e-1ea8-4472-8bb6-53d4e95f5905" />
</div>

## 🚀 Technologie
Projekt został zrealizowany z użyciem następujących technologii:

* **Frontend:** Angular 18 (Standalone Components), TypeScript, Bootstrap 5
* **Backend:** .NET 8 (C#), Entity Framework Core
* **Baza Danych:** PostgreSQL (uruchamiana w Dockerze)
* **Narzędzia:** Docker, Swagger UI, Git

## ✨ Główne funkcjonalności
* **Integracja z API NBP:** Pobieranie aktualnych kursów walut (tabela A) dla wybranej daty.
* **Archiwizacja danych:** Pobrane kursy są automatycznie zapisywane w lokalnej bazie danych PostgreSQL, co zapobiega wielokrotnemu odpytywaniu zewnętrznego API.
* **Przegląd historii:** Wyświetlanie wszystkich zarchiwizowanych kursów w formie czytelnej tabeli, sortowanej od najnowszych wpisów.
* **Architektura Client-Server:** Pełna separacja warstwy prezentacji (Angular) od logiki biznesowej (API).
* **Obsługa błędów:** System komunikatów dla użytkownika (np. brak danych dla danej daty, błędy połączenia).





   

