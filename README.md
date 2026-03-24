# Equipment Rental System

## Opis projektu

Aplikacja konsolowa do zarządzania wypożyczalnią sprzętu. System umożliwia dodawanie użytkowników i sprzętu, obsługę wypożyczeń, zwrotów oraz naliczanie kar za opóźnienia.

**Typy sprzętu:**

* Camera
* Laptop
* Microphone

**Typy użytkowników:**

* Student
* Employee

---

## Architektura (warstwy)

CLI (Program / ConsoleUI) -> Services (RentalService, EquipmentService) -> Models (Equipment, User, Rental)

### Opis warstw

* **Models** - struktury danych i dziedziczenie (OOP)
* **Services** - logika biznesowa (wypożyczenia, dostępność, kary)
* **CLI** - interfejs użytkownika (menu, input/output)

---

## Kluczowe decyzje projektowe

* Dziedziczenie:

  * `Equipment` -> Camera, Laptop, Microphone
  * `User` -> Student, Employee

* Rozdzielenie odpowiedzialności:

  * `EquipmentService` -> zarządzanie sprzętem
  * `RentalService` -> logika wypożyczeń

* Brak wydzielenia dodatkowej warstwy typu RentalApp z uwagi na poprawienie czytelności kodu/brak innej obługi niż przez CLI

* `DateTime?` dla daty zwrotu (brak wartości = brak zwrotu)

* Walidacja wejścia przez `TryParse`

* Dane przechowywane w pamięci (`List<T>`)

* Autogenerownie Id obiektów wewnątrz ich modeli

* Kara za oddanie sprzętu po terminie wyliczana jako 5% wartości sprzętu za każdy opóźniony dzień

---

## Funkcjonalności

1. Dodawanie użytkowników
2. Dodawanie sprzętu
3. Wyświetlanie całego sprzętu
4. Wyświetlanie dostępnego sprzętu
5. Wypożyczanie sprzętu
6. Zwrot sprzętu + kara
7. Oznaczenie sprzętu jako niedostępny (serwis/awaria)
8. Lista wypożyczeń użytkownika
9. Lista przeterminowanych wypożyczeń
10. Raport systemu

---

## Kompilacja i uruchomienie

```
dotnet build
dotnet run
```

---

## Obsługa

Po uruchomieniu:

```
1. Add user
2. Add equipment
3. Show all equipment
...
0. Exit
```

* wybierz numer opcji
* wprowadź dane
* system wykona operację
* aby wyjść wpisz: 0

---

## Scenariusz demonstracyjny( znajduje się w /APBD_Wypozyczalnia_Proj/Test/RunDemo.cs )

* dodanie sprzętu
* dodanie użytkowników 
* poprawne wypożyczenie
* próba wypożyczenia niedostępnego sprzętu
* zwrot w terminie
* zwrot po terminie (kara)
* raport końcowy

---

## Autor

Konrad Drewnowski s33534 - Projekt edukacyjny
