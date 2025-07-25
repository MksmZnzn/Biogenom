# Biogenom Test Project

## Описание проекта
В рамках тестового задания реализован микросервис для анализа нутриционного состояния пользователя.

Сервис позволяет:
- Загружать оценку состояния пользователя (`NutritionAssessment`) с данными о нутриентах и рекомендуемых добавках;
- Автоматически агрегировать список полезных эффектов (`Benefits`) на основе добавок;
- Возвращать клиенту сводный отчёт в виде DTO (`NutritionReportDto`);
- Осуществлять покрытие бизнес-логики unit-тестами.

Проект построен по принципам **чистой архитектуры (Onion Architecture)** с разделением на слои:
- **Domain** — бизнес-сущности: Nutrient, Supplement, Benefit;
- **Application** — интерфейсы, DTO, AutoMapper-конфигурации;
- **Persistence** — реализация сервисов и репозиториев;
- **WebApi** — конечные точки API (контроллеры);
- **Test** — модульные тесты.

Основной сценарий:
1. Репозиторий возвращает заранее подготовленный `NutritionAssessment`;
2. Сервис преобразует его в `NutritionReportDto`, собирает список всех уникальных Benefits;
3. API возвращает результат в JSON через Swagger-интерфейс.

## Структура базы данных

### Таблица: Users

| Поле     | Тип     | Описание               |
|----------|---------|------------------------|
| Id       | int     | Уникальный идентификатор пользователя |
| Name     | string  | Имя пользователя       |

---

### Таблица: NutritionAssessments

| Поле           | Тип       | Описание                      |
|----------------|-----------|-------------------------------|
| Id             | int       | Уникальный ID оценки питания |
| AssessmentDate | DateTime  | Дата оценки                  |
| Status         | string    | Статус (например, "Дефицит") |
| UserId         | int       | Внешний ключ на пользователя |

---

### Таблица: Nutrients

| Поле             | Тип       | Описание                       |
|------------------|-----------|--------------------------------|
| Id               | int       | ID нутриента                  |
| Name             | string    | Название ("Витамин C" и т.д.) |
| CurrentValue     | double    | Текущее значение              |
| NormValue        | double    | Нормальное значение           |
| FromSupplements  | double?   | Из добавок                    |
| FromFood         | double?   | Из пищи                       |
| NutritionAssessmentId | int | Внешний ключ на оценку питания |

---

### Таблица: Supplements

| Поле                | Тип     | Описание                        |
|---------------------|---------|---------------------------------|
| Id                  | int     | ID добавки (БАД)               |
| Name                | string  | Название ("ED Smart")          |
| Description         | string  | Описание                       |
| AlternativesCount   | int     | Кол-во альтернатив             |
| NutritionAssessmentId | int   | Внешний ключ на оценку питания |

---

### Таблица: Benefits

| Поле         | Тип     | Описание                                |
|--------------|---------|-----------------------------------------|
| Id           | int     | ID преимущества                        |
| Text         | string  | Текст ("Улучшает усвоение веществ")    |
| SupplementId | int?    | Внешний ключ на Supplement (опционально) |
