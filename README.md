# Dynamic Application

## Allows emplyers create job application form, dynamically allowing them add questions with various options, load questions for an "application form" and stores users(applicants) answers

### Dependencies

- Net 8
- Azure cosmos DB

### Available Endpoints

- api/employers/program -POST "Creates Application and Questions" , returns ProgramId
- api/employers/program/question -PUT "Edits a question"
- api/employers/program/question/:id  -GET "Gets a question" , id is questionId

- api/programs/:id/questions -GET "GET program(application) questions, optional filtering via QuestionType" , id is ProgramId
- api/programs/answer -POST "Submits program question answers"

### Note
Api has no authentication scheme, and has laxed model validations

### Getting started

- Clone repo, make sure you have .Net 8 installed on your machine
- Update appsettings with DB credentials (Auto container creation)
- Run App

### Calling the API Endpoints
This could be easily done via Swagger UI

### POST Request Samples

- api/employers/program -POST "Creates Application and Questions"

```json
	{
  "name": "Cp Program",
  "description": "This is a test program",
  "programQuestions": [
    {
      "questionText": "what is your name",
      "questionType": 1,
      "options": [
        "string"
      ]
    },
 {
      "questionText": "Are you a christian",
      "questionType": 2,
      "options": [
        "string"
      ]
    },
 {
      "questionText": "How old are you",
      "questionType": 6,
      "options": [
        "string"
      ]
    },
 {
      "questionText": "what is your best spoken language",
      "questionType": 3,
      "options": [
        "english",
"french"
      ]
    },
 {
      "questionText": "select your programming languages",
      "questionType": 4,
      "options": [
        "c#", "golang", "java"
      ]
    }
  ]
}
```

QuestionType Enum Definition: 
    Paragraph = 1,
    YesNo,
    Dropdown,
    Multichoice,
    Date,
    Number


- api/programs/answer -POST "Submits program question answers"
```json
{
  "answers": [
    {
      "userId": "kelechi",
      "questionId": "fce1cb92-770f-41fc-0efb-08dc7397231a",
      "questionAnswer": ["c#", "golang"]
    },
     {
      "userId": "kelechi",
      "questionId": "ggd1cb92-770f-41fc-0efb-08dc7397231a",
      "questionAnswer": "yes"
    }
  ]
}
```