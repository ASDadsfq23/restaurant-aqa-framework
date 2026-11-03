# Green & Tasty — AQA Framework (Homework 8)

Автоматизовані тести для сервісу «Green & Tasty» (Напрям 1: Group Pre-Order, 1-й рівень складності).

## Технологічний стек
- **Framework:** Reqnroll (BDD / Gherkin) + TUnit + Playwright (.NET 10)
- **Pattern:** Screenplay / Step Definitions

## Конфігурація середовища
Створіть файл `.env` у кореневій папці проєкту (на основі `.env.example`) та пропишіть адреси вашого AWS-розгортання:

```env
UI_URL=https://<ваш-id>.cloudfront.net
API_URL=https://<ваш-id>.execute-api.us-west-2.amazonaws.com/dev
```

## Поведінка та контракт API (Напрям 1)
Сценарії покривають перевірку доступу та отримання деталей групового замовлення (`/group-orders/{id}`):
- Запити без авторизаційного токена або з недійсним ID повертають статус `403 Forbidden` згідно з налаштуваннями безпеки AWS API Gateway.

## Запуск тестів Напряму 1

1. **Збірка проєкту:**

   ```powershell
   dotnet build
   ```

2. **Запуск сценаріїв Напряму 1:**

   ```powershell
   dotnet run --no-build -- --treenode-filter "/*/*/*/*[Category=direction1]"
   ```
