# TerraTech Platform REST API Technical Stories

## Overview
This document contains API-focused technical stories intended for frontend or backend developers integrating with the agriculture platform REST API.

Base resource route: `/api/v1` (kebab-case route naming convention).

## Technical Stories

### TS020 — Interactive API Documentation (Swagger)
As a developer, I want to access the interactive API documentation (Swagger/OpenAPI) so that I can understand how to consume the endpoints correctly.
#### Acceptance criteria:
- Scenario: Successful access to documentation
    - Given a request `GET /api/v1/api-docs` (or `/swagger-ui.html`) is received
    - When the API processes the documentation request
    - Then the API responds with `200 OK` and returns the Swagger UI interface with all current endpoints documented (methods, parameters, and response schemas).
---
### TS021 — Retrieve sensor data by id
As a frontend developer, I want to request a `GET /api/v1/sensors/{id}/data` endpoint so that I can obtain the latest values of a specific sensor.
#### Acceptance criteria:
- Scenario: Found
    - Given a request `GET /api/v1/sensors/{id}/data` is received
    - When the API finds the resource associated with the provided `{id}`
    - Then the API responds with `200 OK` and returns a JSON object with the latest values recorded by the sensor.
- Scenario: Not found
    - Given a request `GET /api/v1/sensors/{id}/data` for a non-existent `{id}` is received
    - When the API does not find the resource
    - Then the API responds with `404 Not Found`.
---
### TS022 — Receive recommendation data via webhook
As a backend developer, I want to implement a `POST /api/v1/recommendations/webhook` endpoint so that I can receive data from the recommendation engine and store it in the database.
#### Acceptance criteria:
- Scenario: Successful receive and store
    - Given a request `POST /api/v1/recommendations/webhook` that includes a valid payload is received
    - When the API validates the structure of the received data and persists it successfully
    - Then the API responds with `201 Created` (or `200 OK`) to confirm the receipt of the recommendation data.
- Scenario: Validation error
    - Given a request `POST /api/v1/recommendations/webhook` with missing required fields or invalid data types is received
    - When the API validation fails
    - Then the API responds with `400 Bad Request` and a localized error message describing the validation failure.
---
### TS023 — Retrieve weather forecast data
As a frontend developer, I want to request weather forecast data via an endpoint (e.g., `GET /api/v1/weather/forecast?location={coordinates}`) so that I can display it alongside soil data to coordinate irrigation.
#### Acceptance criteria:
- Scenario: Forecast successfully retrieved
    - Given a request `GET /api/v1/weather/forecast?location={coordinates}` is received
    - When the API successfully fetches data from the third-party weather service
    - Then the API responds with `200 OK` and returns the structured weather forecast for the requested location.
- Scenario: External service error
    - Given a request `GET /api/v1/weather/forecast?location={coordinates}` is received
    - When the third-party weather provider experiences downtime or a timeout
    - Then the API responds with `502 Bad Gateway` or `503 Service Unavailable` and a standard error message.
---
### TS024 — Retrieve recent satellite image by crop id
As a frontend developer, I want to request a recent satellite image via an endpoint (e.g., `GET /api/v1/crops/{cropId}/satellite-image`) so that I can visually identify areas with growth problems.
#### Acceptance criteria:
- Scenario: Image found
    - Given a request `GET /api/v1/crops/{cropId}/satellite-image` is received
    - When the API retrieves the metadata and the latest image URL for the `{cropId}`
    - Then the API responds with `200 OK` and returns the satellite image data (e.g., capture date, image URL, coordinates).
- Scenario: Image not available
    - Given a request `GET /api/v1/crops/{cropId}/satellite-image` is received
    - When the API finds no recent image records for the `{cropId}`
    - Then the API responds with `404 Not Found`.